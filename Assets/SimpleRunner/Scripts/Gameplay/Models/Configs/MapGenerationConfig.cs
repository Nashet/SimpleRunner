using System.Collections.Generic;
using UnityEngine;

namespace Nashet.SimpleRunner.Configs
{
	[CreateAssetMenu(fileName = "MapGenerationConfig", menuName = "SimpleRunner/MapGenerationConfig")]
	public class MapGenerationConfig : ScriptableObject
	{
		public List<CollidableObjectConfig> objects = new();
	}
}
