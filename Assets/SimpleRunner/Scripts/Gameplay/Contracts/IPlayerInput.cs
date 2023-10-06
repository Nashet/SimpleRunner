namespace Nashet.SimpleRunner.Gameplay.Contracts
{
	public delegate void MouseClicked();
	public interface IPlayerInput
	{
		event MouseClicked OnMouseClicked;
	}
}