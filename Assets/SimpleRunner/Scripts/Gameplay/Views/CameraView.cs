using Nashet.SimpleRunner.Gameplay.Contracts;
using UnityEngine;

namespace Nashet.SimpleRunner.Gameplay.Views
{
	/// <summary>
	/// The only purpose of that class is to move camera when player moves
	/// </summary>
	public class CameraView : MonoBehaviour, ICameraView
	{
		public void PropertyChangedHandler(IPlayerViewModel playerViewModel, string propertyName)
		{
			switch (propertyName)
			{

				case nameof(IPlayerViewModel.Position):
					UpdatePosition(playerViewModel.Position);
					break;
			}
		}

		private void UpdatePosition(Vector2 newPosition)
		{
			var oldPosition = transform.position;
			transform.position = new Vector3(newPosition.x, oldPosition.y, oldPosition.z);
		}
	}
}
