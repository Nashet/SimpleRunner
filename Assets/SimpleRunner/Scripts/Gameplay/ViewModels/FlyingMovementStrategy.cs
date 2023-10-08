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
		private CollectableEffectFlightConfig typedConfig;

		public FlyingMovementStrategy(CollectableObjectTypeConfig flightConfig) : base(flightConfig)
		{
			typedConfig = flightConfig.effect as CollectableEffectFlightConfig;
		}

		public override void Move(PlayerMovementModel playerModel, float deltaTime)
		{
			var mustLand = Time.time - context.lastTimeStrategyChanged > config.effectTime - typedConfig.timeToLand;
			//if (mustLand)
			//	Debug.Log($"Must land");
			var convertedDirection = playerModel.Direction >= 0 ? 1 : -1;
			playerModel.Rb.velocity = new Vector3(typedConfig.speed * convertedDirection, mustLand ? 0 : typedConfig.takeofSpeed, 0);
			if (playerModel.Rb.position.y > typedConfig.height)
			{
				playerModel.Rb.position = new Vector2(playerModel.Rb.position.x, typedConfig.height);
			}
			playerModel.Position = playerModel.Rb.position;
		}

		public override string ToString()
		{
			return $"FlyingMovementStrategy {typedConfig.speed}";
		}
	}
}