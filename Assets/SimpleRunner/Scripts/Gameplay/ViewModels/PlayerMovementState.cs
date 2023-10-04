using Nashet.SimpleRunner.Gameplay.Contracts;
using Nashet.SimpleRunner.Gameplay.Models;

namespace Nashet.SimpleRunner.Gameplay.ViewModels
{
	// The base State class declares methods that all Concrete State should
	// implement and also provides a backreference to the Context object,
	// associated with the State. This backreference can be used by States to
	// transition the Context to another State.
	public abstract class PlayerMovementState : IPlayerMovementStrategy
	{
		protected IPlayerMovementStatePattern _context;
		private float _currentActionDuration;

		protected PlayerMovementState(float currentActionDuration)
		{
			_currentActionDuration = currentActionDuration;
		}

		public float CurrentActionDuration => _currentActionDuration;

		public void SetContext(IPlayerMovementStatePattern context)
		{
			this._context = context;
		}

		public abstract void Move(PlayerMovementModel playerModel, float deltaTime);
	}
}