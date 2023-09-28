using System;
using UnityEngine;

namespace Nashet.SimpleRunner.Gameplay.Views
{
	public class CameraView : MonoBehaviour
	{
		internal void PlayerMovedHandler(Vector3 newPosition)
		{
			var oldPosition = transform.position;
			transform.position = new Vector3(newPosition.x, oldPosition.y, oldPosition.z);
		}
	}
}
