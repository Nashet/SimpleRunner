using Nashet.SimpleRunner.Gameplay.Models;

namespace Nashet.SimpleRunner.Gameplay.ViewModels
{
	/// <summary>
	/// The only purpose of this class is to be the intermediate between the view and the model of the player.
	/// </summary>
	public class PlayerViewModel
	{
		public PlayerViewModel(float startingPosition, float startingSpeed)
		{
			new PlayerModel(startingPosition, startingSpeed);
		}

		public void Initialize(IPlayerView playerView)
		{
			playerView.OnPlayerCollided += OnPlayerCollidedHandler;
		}

		private void OnPlayerCollidedHandler()
		{

		}

		public void Update(float deltaTime)
		{

		}
	}
}
