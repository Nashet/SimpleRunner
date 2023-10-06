using System.Collections.Generic;
using UnityEngine;

namespace Nashet.SimpleRunner.Configs
{
	/// <summary>
	/// The purpose of this class is to store configs related to general gameplay.
	/// </summary>
	[CreateAssetMenu(fileName = "GameplayConfig", menuName = "SimpleRunner/GameplayConfig")]
	public class GameplayConfig : ScriptableObject
	{
		public CollectableObjectTypeConfig defaultPlayerAction;
		public CollectableObjectTypeConfig playerJumpAction;
		public Vector2 playerStartingPosition;
		public Vector2 coinGenerationPosition;
		public List<CollectableObjectTypeConfig> collectableObjectTypes;

		[Header("Between 0 and 1")]
		public float backgroundObjectGenerationChance;
		public int maxAmountOfBackgroundObjects;
	}
}
