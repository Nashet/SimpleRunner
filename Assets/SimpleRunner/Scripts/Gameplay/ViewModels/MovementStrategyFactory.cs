using Nashet.SimpleRunner.Configs;
using Nashet.SimpleRunner.Configs.PlayerEffects;
using Nashet.SimpleRunner.Gameplay.Contracts;
using System;

namespace Nashet.SimpleRunner.Gameplay.ViewModels
{
	/// <summary>
	/// Factory for creating movement strategies for player effects.
	/// Add more cases for other movement types as needed
	/// </summary>
	public class MovementStrategyFactory : IMovementStrategyFactory
	{
		//toso: its possible to cache strategies and reuse them
		public IPlayerMovementStrategy CreateMovementStrategy(CollectableObjectTypeConfig config, GameplayConfig gameplayConfig)
		{
			return config.effect.type switch
			{
				CollectableEffectType.Run => new WalkingMovementStrategy(config),
				CollectableEffectType.Flight => new FlyingMovementStrategy(config),
				// Add more cases for other movement types as needed
				_ => throw new ArgumentException("Unsupported PlayerEffectType type: " + config.effect.type),
			};
		}
	}
}
