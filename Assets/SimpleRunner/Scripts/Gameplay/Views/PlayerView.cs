using Nashet.SimpleRunner.Gameplay.Contracts;
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

		private SpriteRenderer spriteRenderer;

		private void Awake()
		{
			spriteRenderer = GetComponent<SpriteRenderer>();
		}

		public void PropertyChangedHandler(IPlayerViewModel playerViewModel, string propertyName)
		{
			switch (propertyName)
			{
				case nameof(IPlayerViewModel.Direction):
					UpdateSpriteFlip(playerViewModel.Direction);
					break;
				case nameof(IPlayerViewModel.Position):
					UpdatePosition(playerViewModel.Position);
					break;
			}
		}

		private void UpdateSpriteFlip(float direction)
		{
			bool flipX = direction < 0;

			if (spriteRenderer.flipX != flipX)
				spriteRenderer.flipX = flipX;
		}

		private void UpdatePosition(Vector3 position)
		{
			transform.position = position;
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			OnPlayerCollided?.Invoke(other.gameObject);
		}
	}
}