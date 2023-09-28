using UnityEngine;

namespace Nashet.SimpleRunner.Configs
{
	/// <summary>
	/// That class provides data for particular coin or another collectable object.
	[CreateAssetMenu(fileName = "CollectableObjectConfig", menuName = "SimpleRunner/CollectableObjectConfig")]
	public class CollectableObjectConfig : ScriptableObject
	{
		public Sprite sprite;
		public CollectableObjectTypeConfig collidableType;
	}
}
