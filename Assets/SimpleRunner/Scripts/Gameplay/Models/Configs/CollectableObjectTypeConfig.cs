using Nashet.SimpleRunner.Configs.PlayerEffects;
using UnityEngine;

namespace Nashet.SimpleRunner.Configs
{
	/// <summary>
	/// The only purpose of this class is to hold the config for the different coins or another collectable objects.
	/// It can contains properties common for all effects.
	/// </summary>
	[CreateAssetMenu(fileName = "CollectableObjectTypeConfig", menuName = "SimpleRunner/CollectableObjectTypeConfig")]
	public class CollectableObjectTypeConfig : ScriptableObject
	{
		public Sprite sprite;
		public float effectTime = 10f;
		public CollectableEffectConfig effect;
	}
}
