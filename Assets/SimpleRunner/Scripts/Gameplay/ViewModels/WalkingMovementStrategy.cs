﻿using Nashet.SimpleRunner.Configs;
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
		private float runSpeed;
		private GameplayConfig gameplayConfig;

		public WalkingMovementStrategy(CollectableObjectTypeConfig config, GameplayConfig gameplayConfig) : base(config.effectTime)
		{
			var walkingConfig = config.effect as CollectableEffectRunConfig;
			runSpeed = walkingConfig.speed;
			this.gameplayConfig = gameplayConfig;
		}

		public override void Move(PlayerMovementModel playerModel, float deltaTime)
		{
			var oldPosition = playerModel.Position;
			var newYPosition = oldPosition.y;

			if (oldPosition.y > gameplayConfig.playerStartingPosition.y)
			{
				newYPosition = oldPosition.y - runSpeed;
			}
			else if (oldPosition.y < gameplayConfig.playerStartingPosition.y)
			{
				newYPosition = gameplayConfig.playerStartingPosition.y;
			}
			playerModel.Position = new Vector3(oldPosition.x + runSpeed, newYPosition, oldPosition.z);
		}

		override public string ToString()
		{
			return $"WalkingMovementStrategy {runSpeed}";
		}
	}
}
