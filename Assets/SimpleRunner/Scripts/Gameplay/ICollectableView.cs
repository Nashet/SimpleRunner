
using Nashet.SimpleRunner.Configs;
using UnityEngine;

namespace Nashet.SimpleRunner.Gameplay
{
	/// <summary>
	/// Thats an interface to a view of collectable object.
	/// </summary>
	public interface ICollectableView
	{
		CollectableObjectTypeConfig CollidableObjectType { get; set; }
	}
}
