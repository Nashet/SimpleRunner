using Assets.SimpleRunner.Common.Patterns;
using Nashet.SimpleRunner.Common.Services;
using Nashet.SimpleRunner.Configs;
using Nashet.SimpleRunner.Gameplay.Contracts;
using Nashet.SimpleRunner.Gameplay.InputView;
using Nashet.SimpleRunner.Gameplay.ViewModels;
using Nashet.SimpleRunner.Gameplay.Views;
using UnityEngine;

namespace Nashet.SimpleRunner
{
	/// <summary>Injects dependencies into the scene.
	/// Here you can choose which implementation you are going to use
	/// </summary>
	public class SceneStarter : MonoBehaviour
	{
		[SerializeField] private PlayerView playerView;
		[SerializeField] private string configHolderName;
		[SerializeField] private CameraView cameraView;
		[SerializeField] private GameObjectPool coinObjectPool;
		[SerializeField] private GameObjectPool backgroundObjectPool;
		[SerializeField] private WorldView worldView;
		[SerializeField] private PlayerInput playerInput;
		[SerializeField] private Rigidbody2D rigidbody2;
		[SerializeField] private PlayerSoundsView playerSoundsView;

		public IWorldViewModel WorldVM { get; private set; }

		private void Start()
		{
			var configService = new SOConfigService(configHolderName);

			var coinObjectFactory = new GameObjectPoolFactory(coinObjectPool);
			var backgroundObjectFactory = new GameObjectPoolFactory(backgroundObjectPool);
			var gameplayConfig = configService.GetConfig<GameplayConfig>();
			MovementStrategyFactory movementStrategyFactory = new();
			WorldVM = new WorldViewModel(gameplayConfig, coinObjectFactory, backgroundObjectFactory, movementStrategyFactory, rigidbody2);

			WorldVM.InitializeWithView(worldView, playerView, cameraView, playerInput, playerSoundsView);//todo try without that
		}
	}
}
