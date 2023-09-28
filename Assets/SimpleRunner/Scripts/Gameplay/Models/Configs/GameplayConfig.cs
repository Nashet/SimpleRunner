using Nashet.SimpleRunner.Configs.PlayerEffects;
using UnityEngine;

namespace Nashet.SimpleRunner.Configs
{
	[CreateAssetMenu(fileName = "GameplayConfig", menuName = "SimpleRunner/GameplayConfig")]
	public class GameplayConfig : ScriptableObject
	{
		public CollectableEffectConfig defaultPlayerAction;
		public Vector2 playerStartingPosition = new Vector2(0, 0);
	}
}
