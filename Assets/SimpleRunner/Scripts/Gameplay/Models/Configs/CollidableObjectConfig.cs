using UnityEngine;

namespace Nashet.SimpleRunner.Configs
{
	[CreateAssetMenu(fileName = "CollidableObjectConfig", menuName = "SimpleRunner/CollidableObjectConfig")]
	public class CollidableObjectConfig : ScriptableObject
	{
		public string Id;
		public Sprite sprite;

		public Vector2 position;
		public CollidableObjectTypeConfig collidableType;
	}
}
