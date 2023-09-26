using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Nashet.SimpleRunner.Gameplay.Views
{
	public class PlayerView : MonoBehaviour
	{
		public event PlayerCollided OnPlayerCollided;
		private void OnCollisionEnter(Collision collision)
		{
			if (collision.gameObject.tag == "Obstacle")
			{
				OnPlayerCollided?.Invoke();
			}
		}
	}
}
