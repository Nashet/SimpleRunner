using Nashet.SimpleRunner.Gameplay.Contracts;
using UnityEngine;

namespace Nashet.SimpleRunner.Gameplay.InputView
{
	/// <summary>
	/// The only goal is to handle player input
	/// </summary>
	public class PlayerInput : MonoBehaviour, IPlayerInput
	{
		public event ControlGivenDelegate OnContolGiven;

		private void Update()
		{
			if (Input.anyKeyDown)
			{
				float horizontalInput = Input.GetAxis("Horizontal");
				float verticalInput = Input.GetAxis("Vertical");
				OnContolGiven?.Invoke(horizontalInput, verticalInput);
			}
		}
	}
}
