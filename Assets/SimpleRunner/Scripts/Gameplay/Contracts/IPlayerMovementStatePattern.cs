using Nashet.SimpleRunner.Gameplay.Models;

namespace Nashet.SimpleRunner.Gameplay.Contracts
{
	public delegate void StateChangedDelegate(IPlayerMovementStrategy newState);

	public interface IPlayerMovementStatePattern
	{
		event StateChangedDelegate OnStateChanged;

		void ChangeStateTo(IPlayerMovementStrategy state);
		void Move(PlayerMovementModel playerModel, float deltaTime);
	}
}
