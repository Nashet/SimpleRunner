using UnityEngine;

namespace Nashet.SimpleRunner.Gameplay.Contracts
{
	public delegate void OnUpdateHappenedDelegate(float fixedDeltaTime, Vector2 playerPosition);

	public interface IWorldViewModel : IUpdatable
	{
		event OnUpdateHappenedDelegate OnUpdateHappened;

		void InitializeWithView(IWorldView worldView, IPlayerView playerView, ICameraView cameraView);
	}
}