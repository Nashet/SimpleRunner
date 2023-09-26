namespace Nashet.SimpleRunner.Gameplay
{
	public delegate void PlayerCollided();

	public interface IPlayerView
	{
		event PlayerCollided OnPlayerCollided;
	}
}