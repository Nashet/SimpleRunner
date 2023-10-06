using Nashet.SimpleRunner.Configs;
using Nashet.SimpleRunner.Gameplay.Contracts;
using Nashet.SimpleRunner.Gameplay.Models;
using UnityEngine;

namespace Nashet.SimpleRunner.Gameplay.ViewModels
{
	/// <summary>
	/// The only purpose of this class is to be the intermediate between the view and the model of the player.
	/// </summary>
	public class PlayerViewModel : IPlayerViewModel
	{
		public event OnPlayerMovedDelegate OnPlayerMoved;
		public event OnEffectEndedDelegate OnEffectEnded;
		public event OnCollectedObjectDelegate OnCollectedObject;


		private GameplayConfig gameplayConfig;
		public Vector2 Position => playerModel.Position;
		private PlayerMovementModel playerModel;

		private IPlayerMovementStatePattern playerMovementContext;
		private IPlayerMovementStrategy defaultMovementSate;
		private IPlayerMovementStrategy jumpMovementSate;
		private IMovementStrategyFactory movementStateFactory;

		public PlayerViewModel(GameplayConfig gameplayConfig, IMovementStrategyFactory movementStrategyFactory, Rigidbody2D rigidbody2D)
		{
			this.gameplayConfig = gameplayConfig;
			this.movementStateFactory = movementStrategyFactory;

			playerModel = new PlayerMovementModel(gameplayConfig.playerStartingPosition, rigidbody2D);
			playerModel.OnPlayerMoved += OnPlayerMovedHandler;
			playerModel.Position = rigidbody2D.position;

			defaultMovementSate = movementStrategyFactory.CreateMovementStrategy(gameplayConfig.defaultPlayerAction, gameplayConfig);
			this.playerMovementContext = new PlayerMovementStatePattern(defaultMovementSate);
			playerMovementContext.OnStateChanged += OnMovementStateChangedHandler;
			jumpMovementSate = movementStrategyFactory.CreateMovementStrategy(gameplayConfig.playerJumpAction, gameplayConfig);
		}

		private void OnMovementStateChangedHandler(IPlayerMovementStrategy newState)
		{
			if (newState == defaultMovementSate)
				OnEffectEnded?.Invoke();
		}

		private void OnPlayerMovedHandler(Vector3 newPosition)
		{
			OnPlayerMoved?.Invoke(newPosition);
		}

		public void InitializeWithView(IPlayerView playerView, ICameraView cameraView, IPlayerInput playerInput)
		{
			playerModel.Position = playerView.Position;
			playerView.OnPlayerCollided += OnPlayerCollidedHandler;

			OnPlayerMoved += playerView.PlayerMovedHandler;
			OnPlayerMoved += cameraView.PlayerMovedHandler;
			playerInput.OnMouseClicked += MouseClickedHandler;
		}

		private void MouseClickedHandler()
		{
			playerMovementContext.ChangeStateTo(jumpMovementSate);
		}

		private void OnPlayerCollidedHandler(GameObject other)
		{
			if (!other.TryGetComponent<ICollectableView>(out var collectable))
				throw new System.Exception("Collectable is null");
			OnCollectedObject?.Invoke(other);
			SetNewMovementState(collectable.CollidableObjectType);
		}

		private void SetNewMovementState(CollectableObjectTypeConfig newEffect)
		{
			var currentMovementStrategy = movementStateFactory.CreateMovementStrategy(newEffect, gameplayConfig);
			playerMovementContext.ChangeStateTo(currentMovementStrategy);
		}

		public void Update(float deltaTime)
		{
			playerMovementContext.Move(playerModel, deltaTime);
		}
	}
}
