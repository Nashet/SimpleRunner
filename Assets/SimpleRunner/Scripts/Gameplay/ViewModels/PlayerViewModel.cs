using Nashet.SimpleRunner.Configs;
using Nashet.SimpleRunner.Contracts.Patterns;
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
		public event OnEffectEndedDelegate OnEffectEnded;
		public event OnCollectedObjectDelegate OnCollectedObject;
		public event PropertyChangedEventHandler<IPlayerViewModel> OnPropertyChanged;

		private GameplayConfig gameplayConfig;
		private PlayerMovementModel playerModel;

		public Vector2 Position => playerModel.Position;
		public float Direction => playerModel.Direction;


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
			OnPropertyChanged?.Invoke(this, nameof(Position));
		}

		public void InitializeWithView(IPlayerView playerView, ICameraView cameraView, IPlayerInput playerInput)
		{
			playerModel.Position = playerView.Position;
			playerView.OnPlayerCollided += OnPlayerCollidedHandler;
			playerInput.OnContolGiven += ControlGivenHandler;

			OnPropertyChanged += playerView.PropertyChangedHandler;
			OnPropertyChanged += cameraView.PropertyChangedHandler;
		}

		private void ControlGivenHandler(float horizontalInput, float verticalInput)
		{
			if (verticalInput > 0)
				playerMovementContext.ChangeStateTo(jumpMovementSate);

			if (horizontalInput != 0)
			{
				playerModel.Direction = horizontalInput;
				OnPropertyChanged?.Invoke(this, nameof(Direction));
			}
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
