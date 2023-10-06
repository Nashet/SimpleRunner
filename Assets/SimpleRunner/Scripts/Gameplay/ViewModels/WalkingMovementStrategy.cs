using Nashet.SimpleRunner.Configs;
using Nashet.SimpleRunner.Configs.PlayerEffects;
using Nashet.SimpleRunner.Gameplay.Models;
using UnityEngine;

namespace Nashet.SimpleRunner.Gameplay.ViewModels
{
	/// <summary>
	/// That class provides the player movement strategy for the walking effect.
	/// Walking speed is set in the config, it might be positive or negative
	/// </summary>
	public class WalkingMovementStrategy : PlayerMovementState
	{
		private CollectableEffectRunConfig config;
		public WalkingMovementStrategy(CollectableObjectTypeConfig config) : base(config)
		{
			this.config = config.effect as CollectableEffectRunConfig;
		}

		public override void Move(PlayerMovementModel playerModel, float deltaTime)
		{
			playerModel.Rb.velocity = new Vector3(config.speed, 0, 0);
			playerModel.Position = playerModel.Rb.position;
		}

		public override string ToString()
		{
			return $"WalkingMovementStrategy {config.speed}";
		}
	}
}
