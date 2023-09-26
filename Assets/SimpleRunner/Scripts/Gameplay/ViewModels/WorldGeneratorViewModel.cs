
using Nashet.SimpleRunner.Patterns;

namespace Nashet.SimpleRunner.Gameplay.ViewModels
{
	public class WorldGeneratorViewModel
	{
		private readonly PlayerViewModel player;
		private IGameObjectFactory gameObjectFactory;

		public WorldGeneratorViewModel()
		{
			player = new PlayerViewModel(0, 0);

			for (int i = 0; i < 10; i++)
			{
				var collecctableVM = new CollectableViewModel(0, 0);
				collecctableVM.Initialize(gameObjectFactory.CreateObject().GetComponent<ICollectableView>());
			}
		}

		public void Initialize(IPlayerView playerView, IGameObjectFactory gameObjectFactory)
		{
			this.gameObjectFactory = gameObjectFactory;
			OnPlayerViewCreatedHandler(playerView);			
		}

		private void OnPlayerViewCreatedHandler(IPlayerView playerView)
		{
			player.Initialize(playerView);
		}
	}
}
