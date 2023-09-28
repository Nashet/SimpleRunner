﻿using Nashet.SimpleRunner.Configs.PlayerEffects;
using UnityEngine;

namespace Nashet.SimpleRunner.Gameplay.Models
{
	public delegate void OnPlayerMovedDelegate(Vector3 newPosition);

	public class PlayerModel//todo rename it
	{
		public event OnPlayerMovedDelegate OnPlayerMoved;

		private Vector3 _position;
		private PlayerEffectBaseConfig defaultAction;

		public Vector3 Position
		{
			get { return _position; }
			set
			{
				_position = value;
				OnPlayerMoved?.Invoke(_position);
			}
		}

		public PlayerModel(PlayerEffectBaseConfig defaultAction, Vector2 startingPosition)
		{
			this.defaultAction = defaultAction;
			_position = startingPosition;
		}
	}
}
