
using Assets.SimpleRunner.Patterns;
using Nashet.SimpleRunner.Configs;
using UnityEngine;

namespace Nashet.SimpleRunner.Gameplay.ViewModels
{
	/// <summary>
	/// The purpose of this class is to communicate with nested View Models.
	/// </summary>
	public class WorldViewModel
	{
		private PlayerViewModel playerVM;
		private CoinSpawnerViewModel coinSpawnerVM;

		public WorldViewModel(GameplayConfig gameplayConfig, IGameObjectFactory gameObjectFactory)
		{
			playerVM = new PlayerViewModel(gameplayConfig);
			coinSpawnerVM = new CoinSpawnerViewModel(playerVM, gameplayConfig, gameObjectFactory);
		}

		public void InitializeWithView(IPlayerView playerView, ICameraView cameraView)
		{
			playerVM.InitializeWithView(playerView, cameraView);
		}

		internal void Update(float fixedDeltaTime)
		{
			playerVM.Update(fixedDeltaTime);
		}
	}
}
