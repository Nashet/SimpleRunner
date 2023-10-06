using Assets.SimpleRunner.Patterns.Contracts;
using Nashet.SimpleRunner.Configs;
using Nashet.SimpleRunner.Gameplay.Contracts;
using UnityEngine;

namespace Nashet.SimpleRunner.Gameplay.ViewModels
{
	public class OneCoinSpawnerViewModel : CoinSpawnerViewModel
	{
		public OneCoinSpawnerViewModel(IPlayerViewModel playerVM, GameplayConfig gameplayConfig, IGameObjectFactory gameObjectFactory) : base(playerVM, gameplayConfig, gameObjectFactory)
		{ }
		protected override void SpawnNewCoin(Vector2 position)
		{
			var newObject = gameObjectFactory.CreateObject();
			newObject.transform.position = position;
			newObject.SetActive(true);
			var collectableView = newObject.GetComponent<ICollectableView>();

			collectableView.CollidableObjectType = gameplayConfig.collectableObjectTypes.Find(x => x.effect.type == Configs.PlayerEffects.CollectableEffectType.Flight);
			newObject.GetComponent<SpriteRenderer>().sprite = collectableView.CollidableObjectType.sprite;
		}

	}
}
