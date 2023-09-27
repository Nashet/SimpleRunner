namespace Nashet.SimpleRunner.Gameplay.ViewModels
{
	/// <summary>
	/// The only purpose of this class is intermediate between the view and the model of some collectable object.
	/// </summary>
	public class CollectableViewModel
	{
		private int v1;
		private int v2;

		public CollectableViewModel(int v1, int v2)
		{
			this.v1 = v1;
			this.v2 = v2;
		}
		public void Initialize(ICollectableView collectable)
		{
			//collectable.OnPlayerCollided += collectable;
		}
	}
}