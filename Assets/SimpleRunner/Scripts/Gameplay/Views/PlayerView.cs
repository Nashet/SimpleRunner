using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Nashet.SimpleRunner.Gameplay.Views
{
	/// <summary>
	/// The only purpose of this class is to handle visuals of the player
	/// </summary>
	public class PlayerView : MonoBehaviour, IPlayerView
	{
		public event PlayerCollided OnPlayerCollided;
		private void OnCollisionEnter(Collision collision)
		{
			if (collision.gameObject.CompareTag("Obstacle"))
			{
				OnPlayerCollided?.Invoke();
			}
		}
	}
}
