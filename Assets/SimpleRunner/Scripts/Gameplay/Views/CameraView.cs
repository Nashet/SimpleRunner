using System;
using UnityEngine;

namespace Nashet.SimpleRunner.Gameplay.Views
{
	/// <summary>
	/// The only purpose of that class is to move camera when player moves
	/// </summary>
	public class CameraView : MonoBehaviour, ICameraView
	{
		public void PlayerMovedHandler(Vector3 newPosition)
		{
			var oldPosition = transform.position;
			transform.position = new Vector3(newPosition.x, oldPosition.y, oldPosition.z);
		}
	}
}
