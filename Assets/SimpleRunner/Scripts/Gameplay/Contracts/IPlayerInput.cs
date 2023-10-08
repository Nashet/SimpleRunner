using Nashet.SimpleRunner.Contracts.Patterns;

namespace Nashet.SimpleRunner.Gameplay.Contracts
{
	public interface IPlayerInput : IPropertyChangeNotifier<IPlayerInput>
	{
		float HorizontalInput { get; }
		float VerticalInput { get; }
	}
}