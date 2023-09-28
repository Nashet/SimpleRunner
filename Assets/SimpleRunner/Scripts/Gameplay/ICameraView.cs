using UnityEngine;

namespace Nashet.SimpleRunner.Gameplay
{
	public interface ICameraView
	{
		void PlayerMovedHandler(Vector3 newPosition);
	}
}