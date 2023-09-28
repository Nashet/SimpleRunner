using Nashet.SimpleRunner.Configs.PlayerEffects;
using UnityEngine;

namespace Nashet.SimpleRunner.Configs
{
	[CreateAssetMenu(fileName = "MapGenerationConfig", menuName = "SimpleRunner/MapGenerationConfig")]
	public class MapGenerationConfig : ScriptableObject
	{
		public PlayerEffectBaseConfig defaultPlayerAction;
	}
}
