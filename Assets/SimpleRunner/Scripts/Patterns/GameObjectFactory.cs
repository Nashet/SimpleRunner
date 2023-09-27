using UnityEngine;

namespace Nashet.SimpleRunner.Patterns
{
	/// <summary>
	/// That particular implementation of IGameObjectFactory is used to create objects from the object pool.
	/// </summary>
	public class PooledGameObjectFactory : IGameObjectFactory
	{
		private readonly ObjectPool objectPool;

		public PooledGameObjectFactory(ObjectPool pool)
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
