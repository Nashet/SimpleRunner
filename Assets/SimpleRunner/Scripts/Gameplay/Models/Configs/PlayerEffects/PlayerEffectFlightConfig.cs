using UnityEngine;

namespace Nashet.SimpleRunner.Configs.PlayerEffects
{
	[CreateAssetMenu(fileName = "PlayerEffectFlightConfig", menuName = "SimpleRunner/PlayerEffectFlightConfig")]
	public class PlayerEffectFlightConfig : PlayerEffectBaseConfig
	{
		public float speed;
		public float height;
	}
}
