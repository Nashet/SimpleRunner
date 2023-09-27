using UnityEngine;

namespace Nashet.SimpleRunner.Configs
{
	[CreateAssetMenu(fileName = "GameplayConfig", menuName = "SimpleRunner/GameplayConfig")]
	public class GameplayConfig : ScriptableObject
	{
		public int ExplodeLineTreshold = 3;
	} //add comments
	//	may be better to keep coins in scene
	//	better delete pool for now
	//	do I actually need configs?
}
