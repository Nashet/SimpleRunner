using Assets.SimpleRunner.Patterns.Contracts;
using UnityEngine;

namespace Nashet.SimpleRunner.Gameplay.Contracts
{
	public interface IWorldView
	{
		void Initialize(Configs.GameplayConfig gameplayConfig, IGameObjectFactory gameObjectFactory);
		void UpdateHappenedHandler(float fixedDeltaTime, Vector2 playerPosition);
	}
}