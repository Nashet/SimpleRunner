using UnityEngine;

namespace Nashet.SimpleRunner.Patterns
{
	/// <summary>
	/// The only purpose of this interface is to hide the way we create objects.
	/// </summary>
	public interface IGameObjectFactory
	{
		GameObject CreateObject();
	}
}