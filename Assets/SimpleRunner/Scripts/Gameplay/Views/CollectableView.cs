using Nashet.SimpleRunner.Configs;
using UnityEngine;

namespace Nashet.SimpleRunner.Gameplay.Views
{
	/// <summary>
	/// The only purpose of this class is to handle visuals of the collectable objects
	/// and to keep connection with the config of that collectbale object.
	/// </summary>
	public class CollectableView : MonoBehaviour, ICollectableView
	{
		[SerializeField] private CollectableObjectTypeConfig _playerEffect;
		public CollectableObjectTypeConfig CollidableObjectType
		{
			get
			{
				return _playerEffect;
			}
			set
			{
				_playerEffect = value;
			}
		}
	}
}
