using UnityEngine;

namespace Nashet.SimpleRunner.Gameplay.Views
{
	/// <summary>
	/// The purpose of this class is to handle visuals of the player and handle collisions.
	/// </summary>
	public class PlayerView : MonoBehaviour, IPlayerView
	{
		public Vector3 Position => transform.position;

		public event OnPlayerCollidedDelegate OnPlayerCollided;

		public void PlayerMovedHandler(Vector3 newPosition)
		{
			transform.position = newPosition;
		}

		void OnTriggerEnter2D(Collider2D other)
		{
			OnPlayerCollided?.Invoke(other.gameObject);
		}
	}
}
