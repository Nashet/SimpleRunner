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


		public IPlayerMovementStatePattern playerMovementContext { get; private set; }
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

			defaultMovementSate = movementStrategyFactory.Get(gameplayConfig.defaultPlayerAction, gameplayConfig);
			this.playerMovementContext = new PlayerMovementStatePattern(defaultMovementSate);
			playerMovementContext.OnStateChanged += OnMovementStateChangedHandler;
			jumpMovementSate = movementStrategyFactory.Get(gameplayConfig.playerJumpAction, gameplayConfig);
			playerMovementContext.OnPropertyChanged += PropertyChangedHandler;
		}

		private void OnMovementStateChangedHandler(IPlayerMovementStrategy newState)
		{
			if (newState == defaultMovementSate)
				OnEffectEnded?.Invoke();
		}

		private void OnPlayerMovedHandler(Vector3 newPosition)
		{
			RiseOnPropertyChanged(nameof(Position));
		}

		public void InitializeWithView(IPlayerView playerView, ICameraView cameraView, IPlayerInput playerInput, IPlayerSoundsView playerSoundsView)
		{
			playerModel.Position = playerView.Position;
			playerView.OnPlayerCollided += OnPlayerCollidedHandler;

			OnPropertyChanged += playerView.PropertyChangedHandler;
			OnPropertyChanged += cameraView.PropertyChangedHandler;
			OnPropertyChanged += playerSoundsView.PropertyChangedHandler;
			OnCollectedObject += playerSoundsView.CoinCollectedHandler;

			playerInput.OnPropertyChanged += PropertyChangedHandler;
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
			var currentMovementStrategy = movementStateFactory.Get(newEffect, gameplayConfig);
			playerMovementContext.ChangeStateTo(currentMovementStrategy);
		}

		public void Update(float deltaTime)
		{
			playerMovementContext.Move(playerModel, deltaTime);
		}

		public void PropertyChangedHandler(IPlayerMovementStatePattern sender, string propertyName)
		{
			if (propertyName == nameof(IPlayerMovementStatePattern.state))
			{
				RiseOnPropertyChanged(nameof(playerMovementContext));
			}
		}

		public void PropertyChangedHandler(IPlayerInput sender, string propertyName)
		{
			if (propertyName == nameof(IPlayerInput.HorizontalInput))
			{
				if (sender.VerticalInput > 0)
					playerMovementContext.ChangeStateTo(jumpMovementSate);

				if (sender.HorizontalInput != 0)
				{
					playerModel.Direction = sender.HorizontalInput;
					RiseOnPropertyChanged(nameof(Direction));
				}
			}
		}

		public void RiseOnPropertyChanged(string propertyName)
		{
			OnPropertyChanged?.Invoke(this, propertyName);
		}
	}
}
