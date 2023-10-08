using Nashet.SimpleRunner.Gameplay.Contracts;
using UnityEngine;

namespace Nashet.SimpleRunner.Gameplay.Views
{
	public class PlayerSoundsView : MonoBehaviour, IPlayerSoundsView
	{
		public AudioClip coinCollected;
		private AudioSource audioSource;

		private void Start()
		{
			audioSource = GetComponent<AudioSource>();
		}

		private void PlaySound(AudioClip soundClip)
		{
			audioSource.clip = soundClip;
			audioSource.Play();
		}

		public void CoinCollectedHandler(GameObject obj)
		{
			PlaySound(coinCollected);
		}

		public void PropertyChangedHandler(IPlayerViewModel sender, string propertyName)
		{
			if (propertyName == nameof(IPlayerViewModel.playerMovementContext))
			{
				AudioClip onCollectedSound = sender.playerMovementContext.state.config.onCollectedSound;
				if (onCollectedSound != null)
				{
					PlaySound(onCollectedSound);
				}
			}
		}
	}
}
