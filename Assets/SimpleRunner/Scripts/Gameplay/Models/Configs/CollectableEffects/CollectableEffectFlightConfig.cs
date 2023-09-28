using UnityEngine;

namespace Nashet.SimpleRunner.Configs.PlayerEffects
{
	/// <summary>
	/// The only purpose of this class is to hold config data for fying effect
	/// </summary>
	[CreateAssetMenu(fileName = nameof(CollectableEffectFlightConfig), menuName = "SimpleRunner/" + nameof(CollectableEffectFlightConfig))]
	public class CollectableEffectFlightConfig : CollectableEffectConfig
	{
		public float speed;
		public float height;
	}
}
