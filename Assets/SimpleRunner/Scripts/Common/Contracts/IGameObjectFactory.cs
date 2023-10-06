using UnityEngine;

namespace Assets.SimpleRunner.Patterns.Contracts //todo rename it
{
	/// <summary>
	/// Represents factory pattern. Creates standart gameobjects
	/// </summary>
	public interface IGameObjectFactory
	{
		GameObject CreateObject();
		void DestroyObject(GameObject obj);
	}
}