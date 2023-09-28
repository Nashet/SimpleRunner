using Nashet.SimpleRunner.Configs.PlayerEffects;
using Nashet.SimpleRunner.Gameplay.Models;

namespace Nashet.SimpleRunner.Gameplay.ViewModels
{
	/// <summary>
	/// Thats an implementation of the player movement strategy pattern for the flying effect.
	/// </summary>
	internal class FlyingMovementStrategy : IPlayerMovementStrategy
	{
		private float flightSpeed;
		private float height;
		public FlyingMovementStrategy(CollectableEffectFlightConfig flightConfig)
		{
			flightSpeed = flightConfig.speed;
			height = flightConfig.height;
		}

		public void Move(PlayerMovementModel playerModel, float deltaTime)
		{
			throw new System.NotImplementedException();
		}
	}
}