using Nashet.SimpleRunner.Gameplay.Models;
using Nashet.SimpleRunner.Gameplay.ViewModels;

namespace Nashet.SimpleRunner.Gameplay.Contracts
{
	/// <summary>
	/// Strategy pattern for the player movement.
	/// If we need new type of movement we can just add new implementation of this interface.
	/// And use Factory pattern to create the right strategy.
	/// </summary>
	public interface IPlayerMovementStrategy
	{
		void Move(PlayerMovementModel playerModel, float deltaTime);
		void SetContext(PlayerMovementContext context);
		float CurrentActionDuration { get; }
	}
}
