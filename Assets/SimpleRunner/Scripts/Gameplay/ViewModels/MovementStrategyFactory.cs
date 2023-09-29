using Nashet.SimpleRunner.Configs;
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
		//toso: its possible to cache strategies and reuse them
		public static IPlayerMovementStrategy CreateMovementStrategy(CollectableEffectConfig config, GameplayConfig gameplayConfig)
		{
			return config.type switch
			{
				CollectableEffectType.Run => new WalkingMovementStrategy(config as CollectableEffectRunConfig, gameplayConfig),
				CollectableEffectType.Flight => new FlyingMovementStrategy(config as CollectableEffectFlightConfig),
				// Add more cases for other movement types as needed
				_ => throw new ArgumentException("Unsupported PlayerEffectType type: " + config.type),
			};
		}
	}
}
