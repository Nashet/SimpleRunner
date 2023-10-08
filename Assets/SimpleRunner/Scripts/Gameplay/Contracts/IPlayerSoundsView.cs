using Nashet.SimpleRunner.Contracts.Patterns;
using UnityEngine;

namespace Nashet.SimpleRunner.Gameplay.Contracts
{
	public interface IPlayerSoundsView : ISubscriber<IPlayerViewModel>
	{
		void CoinCollectedHandler(GameObject obj);
	}
}