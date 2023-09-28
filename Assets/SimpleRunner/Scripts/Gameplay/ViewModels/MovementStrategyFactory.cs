using Nashet.SimpleRunner.Configs.PlayerEffects;
using System;

namespace Nashet.SimpleRunner.Gameplay.ViewModels
{
	/// <summary>
	/// Factory for creating movement strategies for player effects.
	/// Add more cases for other movement types as needed
	/// </summary>
	public static class MovementStrategyFactory
	{
		//todo: might be better to use DI instead of static factory
		public static IPlayerMovementStrategy CreateMovementStrategy(PlayerEffectBaseConfig config)
		{
			return config.type switch
			{
				PlayerEffectType.Run => new WalkingMovementStrategy(config as PlayerEffectSpeedConfig),
				PlayerEffectType.Flight => new FlyingMovementStrategy(config as PlayerEffectFlightConfig),
				// Add more cases for other movement types as needed
				_ => throw new ArgumentException("Unsupported PlayerEffectType type: " + config.type),
			};
		}
	}
}
