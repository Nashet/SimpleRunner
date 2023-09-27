using Nashet.SimpleRunner.Configs.PlayerEffects;
using System;
using UnityEngine;

namespace Nashet.SimpleRunner.Configs
{
	/// <summary>
	/// The only purpose of this class is to hold the config for the different coins or another collectable objects.
	/// It can contains properties common for all effects.
	/// </summary>
	[CreateAssetMenu(fileName = "CollidableObjectTypeConfig", menuName = "SimpleRunner/CollidableObjectTypeConfig")]
	public class CollidableObjectTypeConfig : ScriptableObject
	{
		public float effectTime = 10f;
		public PlayerEffectBaseConfig effect;
	}
}
