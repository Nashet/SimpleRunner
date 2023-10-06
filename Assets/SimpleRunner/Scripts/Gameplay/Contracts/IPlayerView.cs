using Nashet.SimpleRunner.Contracts.Patterns;
using UnityEngine;

namespace Nashet.SimpleRunner.Gameplay.Contracts
{
	public delegate void OnPlayerCollidedDelegate(GameObject otherObject);

	/// <summary>
	/// Thats an interface for the player view. 
	/// </summary>
	public interface IPlayerView : ISubscriber<IPlayerViewModel>
	{
		Vector3 Position { get; }

		event OnPlayerCollidedDelegate OnPlayerCollided;
	}
}