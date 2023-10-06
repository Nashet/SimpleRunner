using Nashet.SimpleRunner.Configs;
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
		protected IPlayerMovementStatePattern context;
		private CollectableObjectTypeConfig config;

		protected PlayerMovementState(CollectableObjectTypeConfig config)
		{
			this.config = config;
		}

		public float EffectDuration => config.effectTime;

		public void SetContext(IPlayerMovementStatePattern context)
		{
			this.context = context;
		}

		public abstract void Move(PlayerMovementModel playerModel, float deltaTime);
	}
}