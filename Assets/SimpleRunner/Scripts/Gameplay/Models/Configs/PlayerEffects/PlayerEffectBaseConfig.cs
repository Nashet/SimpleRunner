using System;
using UnityEngine;

namespace Nashet.SimpleRunner.Configs.PlayerEffects
{

	[Serializable]
	public enum PlayerEffectType
	{
		Run,
		Flight,
	}

	/// <summary>
	/// That abstract class provides nessessary fields for all player effects.
	/// Childs of this class will have additional fields needed for specific effect.
	/// </summary>
	public abstract class PlayerEffectBaseConfig : ScriptableObject
	{
		public PlayerEffectType type;
	}
}
