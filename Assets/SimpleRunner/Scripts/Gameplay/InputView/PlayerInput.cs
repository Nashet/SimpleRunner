using Nashet.SimpleRunner.Gameplay.Contracts;
using UnityEngine;

namespace Nashet.SimpleRunner.Gameplay.InputView
{
	/// <summary>
	/// The only goal is thandle player input
	/// </summary>
	public class PlayerInput : MonoBehaviour, IPlayerInput
	{
		public event MouseClicked OnMouseClicked;

		private void Update()
		{
			if (Input.GetMouseButtonUp(0))
				OnMouseClicked?.Invoke();
		}
	}
}
