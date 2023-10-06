using Assets.SimpleRunner.Patterns.Contracts;
using Nashet.SimpleRunner.Configs;
using Nashet.SimpleRunner.Gameplay.Contracts;
using UnityEngine;

namespace Nashet.SimpleRunner.Gameplay.ViewModels
{
	public class CoinSpawnerViewModel : ICoinSpawnerViewModel
	{
		protected IPlayerViewModel playerVM;
		protected GameplayConfig gameplayConfig;
		protected IGameObjectFactory gameObjectFactory;

		public CoinSpawnerViewModel(IPlayerViewModel playerVM, GameplayConfig gameplayConfig, IGameObjectFactory gameObjectFactory)
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

		private static Vector2 GetCoinSpawnPosition(IPlayerViewModel playerVM, GameplayConfig gameplayConfig)
		{
			var playerOfset = new Vector2(playerVM.Position.x, 0);
			return playerOfset + gameplayConfig.coinGenerationPosition;
		}

		private void OnEffectEndedHandler()
		{
			SpawnNewCoin(GetCoinSpawnPosition(playerVM, gameplayConfig));
		}

		protected virtual void SpawnNewCoin(Vector2 position)
		{
			var newObject = gameObjectFactory.CreateObject();
			newObject.transform.position = position;
			newObject.SetActive(true);
			var collectableView = newObject.GetComponent<ICollectableView>();

			var randomElement = Random.Range(0, gameplayConfig.collectableObjectTypes.Count); //todo inject Random

			collectableView.CollidableObjectType = gameplayConfig.collectableObjectTypes[randomElement];
			newObject.GetComponent<SpriteRenderer>().sprite = collectableView.CollidableObjectType.sprite;
		}
	}
}
