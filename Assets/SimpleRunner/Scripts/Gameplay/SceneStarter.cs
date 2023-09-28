using Assets.SimpleRunner.Patterns;
using Nashet.SimpleRunner.Configs;
using Nashet.SimpleRunner.Gameplay.ViewModels;
using Nashet.SimpleRunner.Gameplay.Views;
using Nashet.SimpleRunner.Services;
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
		[SerializeField] private GameObjectPool objectPool;

		public WorldViewModel WorldVM { get; private set; }

		private void Start()
		{
			var configService = new SOConfigService(configHolderName);

			var gameObjectFactory = new GameObjectPoolFactory(objectPool);
			WorldVM = new WorldViewModel(configService.GetConfig<GameplayConfig>(), gameObjectFactory);

			WorldVM.InitializeWithView(playerView, cameraView);
		}
	}
}
