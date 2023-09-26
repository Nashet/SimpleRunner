namespace Nashet.SimpleRunner.Gameplay.ViewModels
{
	internal class CollectableViewModel
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