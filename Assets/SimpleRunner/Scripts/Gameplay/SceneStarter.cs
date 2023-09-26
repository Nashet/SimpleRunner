using Nashet.SimpleRunner.Gameplay.ViewModels;
using Nashet.SimpleRunner.Gameplay.Views;
using Nashet.SimpleRunner.Patterns;
using UnityEngine;

namespace Nashet.SimpleRunner
{	public class SceneStarter : MonoBehaviour
	{
		[SerializeField] private WorldGeneratorView worldGeneratorView;
		[SerializeField] private PlayerView playerPrefab;

		private void Awake()
		{
			var worldGeneratorVM = new WorldGeneratorViewModel();

			var gameObjectFactory = new GameObjectFactory();
			worldGeneratorVM.Initialize((Gameplay.IPlayerView)playerPrefab, gameObjectFactory);
		}
	}
}
