﻿using Nashet.SimpleRunner.Configs.PlayerEffects;
using Nashet.SimpleRunner.Gameplay.Models;
using UnityEngine;

namespace Nashet.SimpleRunner.Gameplay.ViewModels
{
	/// <summary>
	/// Thats an implementation of the player movement strategy pattern for the flying effect.
	/// </summary>
	internal class FlyingMovementStrategy : IPlayerMovementStrategy
	{
		private float flightSpeed;
		private float maxHeight;
		private float takeofSpeed;
		public FlyingMovementStrategy(CollectableEffectFlightConfig flightConfig)
		{
			flightSpeed = flightConfig.speed;
			maxHeight = flightConfig.height;
			takeofSpeed = flightConfig.takeofSpeed;
		}

		public void Move(PlayerMovementModel playerModel, float deltaTime)
		{
			var oldPosition = playerModel.Position;
			float newY = oldPosition.y < maxHeight ? oldPosition.y + takeofSpeed : oldPosition.y;
			playerModel.Position = new Vector3(oldPosition.x + flightSpeed, newY, oldPosition.z);
		}

		override public string ToString()
		{
			return $"FlyingMovementStrategy {flightSpeed}";
		}
	}
}