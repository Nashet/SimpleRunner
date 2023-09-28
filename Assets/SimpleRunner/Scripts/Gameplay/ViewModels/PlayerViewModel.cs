using Nashet.SimpleRunner.Configs.PlayerEffects;
using Nashet.SimpleRunner.Gameplay.Models;
using UnityEngine;

namespace Nashet.SimpleRunner.Gameplay.ViewModels
{
	/// <summary>
	/// The only purpose of this class is to be the intermediate between the view and the model of the player.
	/// </summary>
	public class PlayerViewModel
	{
		public event OnPlayerMovedDelegate OnPlayerMoved;

		private PlayerModel playerModel;
		private IPlayerMovementStrategy movementStrategy;

		public PlayerViewModel(PlayerEffectBaseConfig defaultAction, Vector2 startingPosition)
		{
			playerModel = new PlayerModel(defaultAction, startingPosition);
			playerModel.OnPlayerMoved += OnPlayerMovedhandler;
			ReceiveEffect(defaultAction);
		}

		private void OnPlayerMovedhandler(Vector3 newPosition)
		{
			OnPlayerMoved?.Invoke(newPosition);
		}

		public void InitializeWithView(IPlayerView playerView)
		{
			playerModel.Position = playerView.Position;

			playerView.OnPlayerCollided += OnPlayerCollidedHandler;

			OnPlayerMoved += playerView.PlayerMovedHandler;
		}

		private void OnPlayerCollidedHandler(PlayerEffectBaseConfig playerEffectBaseConfig)
		{
			ReceiveEffect(playerEffectBaseConfig);
		}

		private void ReceiveEffect(PlayerEffectBaseConfig config)
		{
			movementStrategy = MovementStrategyFactory.CreateMovementStrategy(config);
			Debug.LogError($"new strategy is {movementStrategy.GetType()}");
		}

		public void Update(float deltaTime)
		{
			movementStrategy.Move(playerModel, deltaTime);
		}
	}
}
