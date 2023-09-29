using Assets.SimpleRunner.Patterns;
using Nashet.SimpleRunner.Configs;
using System;
using UnityEngine;

namespace Nashet.SimpleRunner.Gameplay.ViewModels
{
	public class CoinSpawnerViewModel
	{
		private PlayerViewModel playerVM;
		private GameplayConfig gameplayConfig;
		private IGameObjectFactory gameObjectFactory;

		public CoinSpawnerViewModel(PlayerViewModel playerVM, GameplayConfig gameplayConfig, IGameObjectFactory gameObjectFactory)
		{
			this.gameObjectFactory = gameObjectFactory;
			this.gameplayConfig = gameplayConfig;
			this.playerVM = playerVM;
			playerVM.OnEffectEnded += OnEffectEndedHandler;
			playerVM.OnCollectedObject += OnCollectedObjectHandler;
			SpawnNewCoin(GetCoinSpawnPosition(playerVM, gameplayConfig));
		}

		private void OnCollectedObjectHandler(GameObject obj)
		{
			gameObjectFactory.DestroyObject(obj);
		}

		private static Vector2 GetCoinSpawnPosition(PlayerViewModel playerVM, GameplayConfig gameplayConfig)
		{
			var playerOfset = new Vector2(playerVM.Position.x, 0); //todo check for immutability
			return playerOfset + gameplayConfig.coinGenerationPosition;
		}

		private void OnEffectEndedHandler()
		{
			SpawnNewCoin(GetCoinSpawnPosition(playerVM, gameplayConfig));
		}

		private void SpawnNewCoin(Vector2 position)
		{
			var newObject = gameObjectFactory.CreateObject();
			newObject.transform.position = position;
			newObject.SetActive(true);
			var collectableView = newObject.GetComponent<ICollectableView>();

			var randomElement = UnityEngine.Random.Range(0, gameplayConfig.collectableObjectTypes.Count);

			collectableView.CollidableObjectType = gameplayConfig.collectableObjectTypes[randomElement];
			newObject.GetComponent<SpriteRenderer>().sprite = collectableView.CollidableObjectType.sprite;
		}
	}
}
