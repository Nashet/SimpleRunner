using Assets.SimpleRunner.Common.Patterns;
using Nashet.SimpleRunner.Configs;
using Nashet.SimpleRunner.Contracts.Patterns;
using Nashet.SimpleRunner.Gameplay.Contracts;
using UnityEngine;

namespace Nashet.SimpleRunner.Gameplay.ViewModels
{
	/// <summary>
	/// The purpose of this class is to communicate with nested View Models.
	/// </summary>
	public class WorldViewModel : IWorldViewModel
	{
		public event OnUpdateHappenedDelegate OnUpdateHappened;

		private IPlayerViewModel playerVM;
		private GameplayConfig gameplayConfig;
		private IGameObjectFactory backgroundObjectFactory;

		public WorldViewModel(GameplayConfig gameplayConfig, IGameObjectFactory gameObjectFactory,
			GameObjectPoolFactory backgroundObjectFactory, IMovementStrategyFactory movementStrategyFactory, Rigidbody2D rigidbody2D)
		{
			this.gameplayConfig = gameplayConfig;
			this.backgroundObjectFactory = backgroundObjectFactory;
			playerVM = new PlayerViewModel(gameplayConfig, movementStrategyFactory, rigidbody2D);
			new CoinSpawnerViewModel(playerVM, gameplayConfig, gameObjectFactory);
		}

		public void InitializeWithView(IWorldView worldView, IPlayerView playerView, ICameraView cameraView, IPlayerInput playerInput, IPlayerSoundsView playerSoundsView)
		{
			playerVM.InitializeWithView(playerView, cameraView, playerInput, playerSoundsView);
			OnUpdateHappened += worldView.UpdateHappenedHandler;
			worldView.Initialize(gameplayConfig, backgroundObjectFactory);
		}

		public void Update(float fixedDeltaTime)
		{
			playerVM.Update(fixedDeltaTime);
			OnUpdateHappened?.Invoke(fixedDeltaTime, playerVM.Position);
		}
	}
}
