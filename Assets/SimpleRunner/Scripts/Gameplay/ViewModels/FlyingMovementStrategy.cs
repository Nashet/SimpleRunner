using Nashet.SimpleRunner.Configs;
using Nashet.SimpleRunner.Configs.PlayerEffects;
using Nashet.SimpleRunner.Gameplay.Models;
using UnityEngine;

namespace Nashet.SimpleRunner.Gameplay.ViewModels
{
	/// <summary>
	/// Thats an implementation of the player movement strategy pattern for the flying effect.
	/// </summary>
	public class FlyingMovementStrategy : PlayerMovementState
	{
		private CollectableEffectFlightConfig config;

		public FlyingMovementStrategy(CollectableObjectTypeConfig flightConfig) : base(flightConfig)
		{
			config = flightConfig.effect as CollectableEffectFlightConfig;
		}

		public override void Move(PlayerMovementModel playerModel, float deltaTime)
		{
			var mustLand = Time.time - context.lastTimeStrategyChanged > EffectDuration - config.timeToLand;
			//if (mustLand)
			//	Debug.Log($"Must land");
			playerModel.Rb.velocity = new Vector3(config.speed, mustLand ? 0 : config.takeofSpeed, 0);
			if (playerModel.Rb.position.y > config.height)
			{
				playerModel.Rb.position = new Vector2(playerModel.Rb.position.x, config.height);
			}
			playerModel.Position = playerModel.Rb.position;
		}

		public override string ToString()
		{
			return $"FlyingMovementStrategy {config.speed}";
		}
	}
}