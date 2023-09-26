namespace Nashet.SimpleRunner.Gameplay.Models
{
	public class PlayerModel
	{
		private float _position;
		private float _speed;

		public float Position { get { return _position; } set { _position = value; } }
		public float Speed { get { return _speed; } set { _speed = value; } }

		public PlayerModel(float startingPosition, float startingSpeed)
		{
			_position = startingPosition;
			_speed = startingSpeed;
		}

		public void Update(float deltaTime)
		{
			_position += _speed * deltaTime;
		}
	}
}
