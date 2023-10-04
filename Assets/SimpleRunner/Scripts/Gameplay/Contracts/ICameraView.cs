using UnityEngine;

namespace Nashet.SimpleRunner.Gameplay.Contracts
{
	public interface ICameraView
	{
		void PlayerMovedHandler(Vector3 newPosition);
	}
}