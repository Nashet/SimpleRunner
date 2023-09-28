using Nashet.SimpleRunner.Configs.PlayerEffects;
using UnityEngine;

namespace Nashet.SimpleRunner.Gameplay.Views
{
	/// <summary>
	/// The only purpose of this class is to handle visuals of the collectable objects
	/// and to keep connection with the config of that collectbale object.
	/// </summary>
	public class CollectablesView : MonoBehaviour, ICollectableView //todo why S?
	{
		[SerializeField] private PlayerEffectBaseConfig _playerEffectBaseConfig;
		public PlayerEffectBaseConfig PlayerEffectBaseConfig => _playerEffectBaseConfig;
	}
}
