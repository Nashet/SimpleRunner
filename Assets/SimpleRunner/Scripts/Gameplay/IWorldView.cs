using Assets.SimpleRunner.Patterns;
using UnityEngine;

namespace Nashet.SimpleRunner.Gameplay
{
	public interface IWorldView
	{
		void Initialize(Configs.GameplayConfig gameplayConfig, IGameObjectFactory gameObjectFactory);
		void UpdateHappenedHandler(float fixedDeltaTime, Vector2 playerPosition);
	}
}