using Nashet.SimpleRunner.Gameplay.Models;

namespace Nashet.SimpleRunner.Gameplay.ViewModels
{
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
