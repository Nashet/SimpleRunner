using System.Collections.Generic;
using UnityEngine;

namespace Nashet.SimpleRunner.Configs
{
	/// <summary>
	/// The only purpose of this class is to hold all other configs
	/// </summary>
	[CreateAssetMenu(fileName = "ConfigHolder", menuName = "SimpleRunner/ConfigHolder")]
	public class ConfigHolder : ScriptableObject
	{
		public List<ScriptableObject> AllConfigs;
	}
}
