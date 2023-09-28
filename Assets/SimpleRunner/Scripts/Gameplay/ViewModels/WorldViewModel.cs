
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

		public WorldViewModel(GameplayConfig gameplayConfig)
		{
			playerVM = new PlayerViewModel(gameplayConfig.defaultPlayerAction, gameplayConfig.playerStartingPosition);
		}

		public void InitializeWithView(IPlayerView playerView, Views.CameraView cameraView)
		{
			playerVM.InitializeWithView(playerView, cameraView);
		}

		internal void Update(float fixedDeltaTime)
		{
			playerVM.Update(fixedDeltaTime);
		}
	}
}
