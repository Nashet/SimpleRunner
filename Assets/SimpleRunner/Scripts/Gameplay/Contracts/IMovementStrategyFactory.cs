using Nashet.SimpleRunner.Configs;

namespace Nashet.SimpleRunner.Gameplay.Contracts
{
	public interface IMovementStrategyFactory
	{
		IPlayerMovementStrategy Get(CollectableObjectTypeConfig config, GameplayConfig gameplayConfig);
	}
}