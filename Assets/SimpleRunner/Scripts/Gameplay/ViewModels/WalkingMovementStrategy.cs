using Nashet.SimpleRunner.Configs.PlayerEffects;
using Nashet.SimpleRunner.Gameplay.Models;
using UnityEngine;

namespace Nashet.SimpleRunner.Gameplay.ViewModels
{
	/// <summary>
	/// That class provides the player movement strategy for the walking effect.
	/// Walking speed is set in the config, it might be positive or negative
	/// </summary>
	public class WalkingMovementStrategy : IPlayerMovementStrategy
	{
		private float runSpeed;

		public WalkingMovementStrategy(CollectableEffectRunConfig config)
		{
			runSpeed = config.speed;
		}

		public void Move(PlayerMovementModel playerModel, float deltaTime)
		{
			var oldPosition = playerModel.Position;
			playerModel.Position = new Vector3(oldPosition.x + runSpeed, oldPosition.y, oldPosition.z);
		}

		override public string ToString()
		{
			return $"WalkingMovementStrategy {runSpeed}";
		}
	}
}
