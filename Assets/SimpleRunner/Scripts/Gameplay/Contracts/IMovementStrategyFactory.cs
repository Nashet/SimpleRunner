using Nashet.SimpleRunner.Configs;

namespace Nashet.SimpleRunner.Gameplay.Contracts
{
	public interface IMovementStrategyFactory
	{
		//todo rename
		IPlayerMovementStrategy CreateMovementStrategy(CollectableObjectTypeConfig config, GameplayConfig gameplayConfig);
	}
}