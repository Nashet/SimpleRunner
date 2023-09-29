using Nashet.SimpleRunner.Configs.PlayerEffects;
using UnityEngine;

namespace Nashet.SimpleRunner.Gameplay.Models
{
	public delegate void OnPlayerMovedDelegate(Vector3 newPosition);

	public class PlayerMovementModel
	{
		public event OnPlayerMovedDelegate OnPlayerMoved;

		private Vector3 _position;
		public Vector3 Position
		{
			get { return _position; }
			set
			{
				_position = value;
				OnPlayerMoved?.Invoke(_position);
			}
		}

		public PlayerMovementModel(Vector2 startingPosition)
		{
			_position = startingPosition;
		}
	}
}
