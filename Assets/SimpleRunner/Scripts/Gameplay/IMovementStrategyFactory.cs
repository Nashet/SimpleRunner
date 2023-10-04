using Nashet.SimpleRunner.Configs;
using Nashet.SimpleRunner.Configs.PlayerEffects;

namespace Nashet.SimpleRunner.Gameplay
{
	public interface IMovementStrategyFactory
	{
		IPlayerMovementStrategy CreateMovementStrategy(CollectableEffectConfig config, GameplayConfig gameplayConfig);
	}
}