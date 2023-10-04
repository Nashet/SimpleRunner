using UnityEngine;

namespace Assets.SimpleRunner.Patterns.Contracts
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