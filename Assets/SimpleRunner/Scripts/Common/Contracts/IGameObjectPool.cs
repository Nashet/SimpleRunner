using UnityEngine;

namespace Nashet.SimpleRunner.Contracts.Patterns
{
	/// <summary>
	/// Represents object pool pattern
	/// </summary>
	public interface IGameObjectPool
	{
		GameObject GetPooledObject();
		void ReturnToPool(GameObject obj);
	}
}