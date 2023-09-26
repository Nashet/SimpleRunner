using UnityEngine;

namespace Nashet.SimpleRunner.Patterns
{
	public class GameObjectFactory : IGameObjectFactory
	{
		private readonly ObjectPool objectPool;

		public GameObjectFactory()
		{
		}

		public GameObjectFactory(ObjectPool pool)
		{
			objectPool = pool;
		}

		public GameObject CreateObject()
		{
			GameObject obj = objectPool.GetPooledObject();

			obj.SetActive(true);
			return obj;
		}
	}
}
