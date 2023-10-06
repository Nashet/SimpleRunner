using UnityEngine;

namespace Nashet.SimpleRunner.Gameplay.Models
{
	public delegate void OnPlayerMovedDelegate(Vector3 newPosition);

	/// <summary>
	/// That class is a model of MVVM pattern. Its suposed to be used by IPlayerMovementStrategy.
	/// That purpose to only store data, no logic allowed here.
	/// </summary>
	public class PlayerMovementModel
	{
		public event OnPlayerMovedDelegate OnPlayerMoved;

		public Rigidbody2D Rb { get; private set; }
		public float Direction;

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

		public PlayerMovementModel(Vector2 startingPosition, Rigidbody2D rb)
		{
			_position = startingPosition;
			this.Rb = rb;
		}
	}
}
