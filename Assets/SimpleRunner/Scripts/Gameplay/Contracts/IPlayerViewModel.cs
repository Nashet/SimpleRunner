using Nashet.SimpleRunner.Contracts.Patterns;
using UnityEngine;

namespace Nashet.SimpleRunner.Gameplay.Contracts
{
	public delegate void OnEffectEndedDelegate();
	public delegate void OnCollectedObjectDelegate(GameObject obj);

	public interface IPlayerViewModel : IUpdatable, IPropertyChangeNotifier<IPlayerViewModel>, ISubscriber<IPlayerMovementStatePattern>, ISubscriber<IPlayerInput>
	{
		Vector2 Position { get; }
		float Direction { get; }
		IPlayerMovementStatePattern playerMovementContext { get; }

		event OnCollectedObjectDelegate OnCollectedObject;
		event OnEffectEndedDelegate OnEffectEnded;

		void InitializeWithView(IPlayerView playerView, ICameraView cameraView, IPlayerInput playerInput, IPlayerSoundsView playerSoundsView);
	}
}