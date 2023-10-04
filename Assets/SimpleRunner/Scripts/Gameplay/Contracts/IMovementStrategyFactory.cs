using Nashet.SimpleRunner.Configs;

namespace Nashet.SimpleRunner.Gameplay.Contracts
{
	public interface IMovementStrategyFactory
	{
		IPlayerMovementStrategy CreateMovementStrategy(CollectableObjectTypeConfig config, GameplayConfig gameplayConfig);
	}
}