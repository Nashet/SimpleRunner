
using Assets.SimpleRunner.Patterns;
using Assets.SimpleRunner.Patterns.Contracts;
using Nashet.SimpleRunner.Configs;
using Nashet.SimpleRunner.Gameplay.Contracts;

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

		public WorldViewModel(GameplayConfig gameplayConfig, IGameObjectFactory gameObjectFactory, GameObjectPoolFactory backgroundObjectFactory, IMovementStrategyFactory movementStrategyFactory)
		{
			this.gameplayConfig = gameplayConfig;
			this.backgroundObjectFactory = backgroundObjectFactory;
			playerVM = new PlayerViewModel(gameplayConfig, movementStrategyFactory);
			var coinSpawnerVM = new CoinSpawnerViewModel(playerVM, gameplayConfig, gameObjectFactory);
		}

		public void InitializeWithView(IWorldView worldView, IPlayerView playerView, ICameraView cameraView)
		{
			playerVM.InitializeWithView(playerView, cameraView);
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
