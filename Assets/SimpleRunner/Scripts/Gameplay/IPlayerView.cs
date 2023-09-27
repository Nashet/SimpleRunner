namespace Nashet.SimpleRunner.Gameplay
{
	public delegate void PlayerCollided();

	/// <summary>
	/// Thats an interface for the player view. It provides an event for when the player collides with something.
	/// </summary>
	public interface IPlayerView
	{
		event PlayerCollided OnPlayerCollided;
	}
}