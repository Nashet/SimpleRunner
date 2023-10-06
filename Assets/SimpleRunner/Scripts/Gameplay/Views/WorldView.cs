using Nashet.SimpleRunner.Configs;
using Nashet.SimpleRunner.Contracts.Patterns;
using Nashet.SimpleRunner.Gameplay.Contracts;
using System.Collections.Generic;
using UnityEngine;

namespace Nashet.SimpleRunner.Gameplay.Views
{
	/// <summary>
	/// Purpose of this class is to generate visuals for background objects
	/// </summary>
	public class WorldView : MonoBehaviour, IWorldView
	{
		private GameplayConfig gameplayConfig;
		private IGameObjectFactory gameObjectFactory;
		private Queue<GameObject> gameObjects = new();

		public void Initialize(GameplayConfig gameplayConfig, IGameObjectFactory gameObjectFactory)
		{
			this.gameplayConfig = gameplayConfig;
			this.gameObjectFactory = gameObjectFactory;
		}

		public void UpdateHappenedHandler(float fixedDeltaTime, Vector2 playerPosition)
		{
			var chanceToGenerateBackgroundObject = Random.Range(0f, 1f);
			if (chanceToGenerateBackgroundObject >= gameplayConfig.backgroundObjectGenerationChance)
			{
				return;
			}

			var randomXScale = Random.Range(4, 13);
			var randomYScale = Random.Range(5, 23);


			var backgroundObject = gameObjectFactory.CreateObject();

			backgroundObject.transform.position = new Vector3(playerPosition.x + 20 + randomXScale, randomYScale - 10, 0);

			backgroundObject.transform.localScale = new Vector3(randomYScale, randomXScale, 1);
			var randomColor = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
			backgroundObject.GetComponent<SpriteRenderer>().color = randomColor;
			backgroundObject.SetActive(true);
			gameObjects.Enqueue(backgroundObject);

			if (gameObjects.Count > gameplayConfig.maxAmountOfBackgroundObjects)
			{
				var obj = gameObjects.Dequeue();
				gameObjectFactory.DestroyObject(obj);
			}
		}
	}
}