
using Nashet.SimpleRunner.Configs;
using UnityEngine;

namespace Nashet.SimpleRunner.Gameplay.ViewModels
{
	/// <summary>
	/// The purpose of this class is to communicate with nested View Models.
	/// </summary>
	public class WorldGeneratorViewModel // todo rename it
	{
		private PlayerViewModel playerVM;
		private MapGenerationConfig mapGenerationConfig;

		public WorldGeneratorViewModel(MapGenerationConfig mapGenerationConfig)
		{
			this.mapGenerationConfig = mapGenerationConfig;

			Vector2 playerStartingPosition = new Vector2(0, 0);
			playerVM = new PlayerViewModel(mapGenerationConfig.defaultPlayerAction, playerStartingPosition);
		}

		public void InitializeWithView(IPlayerView playerView)
		{
			playerVM.InitializeWithView(playerView);
		}

		internal void Update(float fixedDeltaTime)
		{
			playerVM.Update(fixedDeltaTime);
		}
	}
}
