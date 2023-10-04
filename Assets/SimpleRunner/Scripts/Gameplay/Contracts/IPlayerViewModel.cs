using Nashet.SimpleRunner.Gameplay.Models;
using UnityEngine;

namespace Nashet.SimpleRunner.Gameplay.Contracts
{
	public delegate void OnEffectEndedDelegate();
	public delegate void OnCollectedObjectDelegate(GameObject obj);

	public interface IPlayerViewModel : IUpdatable
	{
		Vector2 Position { get; }

		event OnCollectedObjectDelegate OnCollectedObject;
		event OnEffectEndedDelegate OnEffectEnded;
		event OnPlayerMovedDelegate OnPlayerMoved;

		void InitializeWithView(IPlayerView playerView, ICameraView cameraView);
	}
}