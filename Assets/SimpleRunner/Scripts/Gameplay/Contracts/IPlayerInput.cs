namespace Nashet.SimpleRunner.Gameplay.Contracts
{
	public delegate void ControlGivenDelegate(float horizontalInput, float verticalInput);

	public interface IPlayerInput
	{
		event ControlGivenDelegate OnContolGiven;
	}
}