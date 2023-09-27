using System;
using UnityEngine;

namespace Nashet.SimpleRunner.Configs.PlayerEffects
{
	[CreateAssetMenu(fileName = "PlayerEffectSpeedConfig", menuName = "SimpleRunner/PlayerEffectSpeedConfig")]
	public class PlayerEffectSpeedConfig : PlayerEffectBaseConfig
	{
		public float speed;
	}
}
