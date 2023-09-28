using UnityEngine;

namespace Nashet.SimpleRunner.Gameplay
{
	public delegate void OnPlayerCollidedDelegate(GameObject otherObject);

	/// <summary>
	/// Thats an interface for the player view. 
	/// </summary>
	public interface IPlayerView
	{
		Vector3 Position { get; }

		event OnPlayerCollidedDelegate OnPlayerCollided;
		void PlayerMovedHandler(Vector3 newPosition);
	}
}