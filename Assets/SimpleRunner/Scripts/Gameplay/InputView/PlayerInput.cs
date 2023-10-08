using Nashet.SimpleRunner.Contracts.Patterns;
using Nashet.SimpleRunner.Gameplay.Contracts;
using UnityEngine;

namespace Nashet.SimpleRunner.Gameplay.InputView
{
	/// <summary>
	/// The only goal is to handle player input
	/// </summary>
	public class PlayerInput : MonoBehaviour, IPlayerInput
	{
		public float HorizontalInput { get; private set; }
		public float VerticalInput { get; private set; }

		public event PropertyChangedEventHandler<IPlayerInput> OnPropertyChanged;

		public void RiseOnPropertyChanged(string propertyName)
		{
			OnPropertyChanged?.Invoke(this, propertyName);
		}

		private void Update()
		{
			if (Input.anyKeyDown)
			{
				HorizontalInput = Input.GetAxis("Horizontal");
				VerticalInput = Input.GetAxis("Vertical");
				RiseOnPropertyChanged(nameof(HorizontalInput));
			}
		}
	}
}
