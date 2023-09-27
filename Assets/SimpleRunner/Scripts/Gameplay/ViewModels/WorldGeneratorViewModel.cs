
using Nashet.SimpleRunner.Configs;
using Nashet.SimpleRunner.Patterns;

namespace Nashet.SimpleRunner.Gameplay.ViewModels
{
	/// <summary>
	/// The purpose of this class is to communicate with world model and with nested view models
	/// </summary>
	public class WorldGeneratorViewModel
	{
		private PlayerViewModel playerVM;
		private IGameObjectFactory gameObjectFactory;

		public WorldGeneratorViewModel(MapGenerationConfig mapGenerationConfig)
		{

		}

		public void Initialize(IPlayerView playerView, IGameObjectFactory gameObjectFactory)
		{
			this.gameObjectFactory = gameObjectFactory;

			playerVM = new PlayerViewModel(0, 0);
			playerVM.Initialize(playerView);

			for (int i = 0; i < 10; i++)
			{
				var collecctableVM = new CollectableViewModel(0, 0);
				var gameObject = gameObjectFactory.CreateObject();

				collecctableVM.Initialize(gameObject.GetComponent<ICollectableView>());
			}
		}
	}
}
