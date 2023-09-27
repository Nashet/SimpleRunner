using Nashet.SimpleRunner.Configs;
using Nashet.SimpleRunner.Gameplay.ViewModels;
using Nashet.SimpleRunner.Gameplay.Views;
using Nashet.SimpleRunner.Patterns;
using Nashet.SimpleRunner.Services;
using UnityEngine;

namespace Nashet.SimpleRunner
{
	/// <summary>Injects dependencies into the scene.
	/// Here you can choose which implementation you are going to use
	/// </summary>
	public class SceneStarter : MonoBehaviour
	{
		[SerializeField] private WorldGeneratorView worldGeneratorView;
		[SerializeField] private PlayerView playerPrefab;
		[SerializeField] private ObjectPool objectPool;
		[SerializeField] private string configHolderName = "ConfigHolder";

		private void Awake()
		{
			var configService = new SOConfigService(configHolderName);
			var gameObjectFactory = new PooledGameObjectFactory(objectPool);

			var worldGeneratorVM = new WorldGeneratorViewModel(configService.GetConfig<MapGenerationConfig>());

			// disable that method if you want to turn off graphical visualisation of game progress
			worldGeneratorVM.Initialize(playerPrefab, gameObjectFactory);
		}
	}
}
