using UnityEngine;

namespace Nashet.SimpleRunner.Configs.PlayerEffects
{
	/// <summary>
	/// The only purpose of this class is to hold config data for running effect
	/// </summary>
	[CreateAssetMenu(fileName = nameof(CollectableEffectRunConfig), menuName = "SimpleRunner/" + nameof(CollectableEffectRunConfig))]
	public class CollectableEffectRunConfig : CollectableEffectConfig
	{
		public float speed;
	}
}
