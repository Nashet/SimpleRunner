﻿using Nashet.SimpleRunner.Configs;
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
		[SerializeField] private string configHolderName = "ConfigHolder";

		public WorldViewModel WorldGeneratorVM { get; private set; }

		private void Start()
		{
			var configService = new SOConfigService(configHolderName);

			WorldGeneratorVM = new WorldViewModel(configService.GetConfig<MapGenerationConfig>());

			WorldGeneratorVM.InitializeWithView(playerView);
		}
	}
}
