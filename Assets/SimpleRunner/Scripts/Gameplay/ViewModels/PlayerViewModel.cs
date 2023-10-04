using Nashet.SimpleRunner.Configs;
using Nashet.SimpleRunner.Gameplay.Contracts;
using Nashet.SimpleRunner.Gameplay.Models;
using UnityEngine;

namespace Nashet.SimpleRunner.Gameplay.ViewModels
{
	public delegate void OnEffectEndedDelegate();
	public delegate void OnCollectedObjectDelegate(GameObject obj);

	/// <summary>
	/// The only purpose of this class is to be the intermediate between the view and the model of the player.
	/// </summary>
	public class PlayerViewModel
	{
		public event OnPlayerMovedDelegate OnPlayerMoved;
		public event OnEffectEndedDelegate OnEffectEnded;
		public event OnCollectedObjectDelegate OnCollectedObject;


		private GameplayConfig gameplayConfig;
		public Vector2 Position => playerModel.Position;
		private PlayerMovementModel playerModel;

		private PlayerMovementContext playerMovementContext;
		private IMovementStrategyFactory movementStateFactory;
		private IPlayerMovementStrategy defaultMovementSate;

		public PlayerViewModel(GameplayConfig gameplayConfig, IMovementStrategyFactory movementStrategyFactory)
		{
			this.gameplayConfig = gameplayConfig;
			this.movementStateFactory = movementStrategyFactory;

			defaultMovementSate = movementStrategyFactory.CreateMovementStrategy(gameplayConfig.defaultPlayerAction, gameplayConfig);
			this.playerMovementContext = new PlayerMovementContext(defaultMovementSate);
			playerMovementContext.OnStateChanged += OnMovementStateChangedHandler;

			playerModel = new PlayerMovementModel(gameplayConfig.playerStartingPosition);
			playerModel.OnPlayerMoved += OnPlayerMovedHandler;
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

		public void InitializeWithView(IPlayerView playerView, ICameraView cameraView)
		{
			playerModel.Position = playerView.Position;

			playerView.OnPlayerCollided += OnPlayerCollidedHandler;

			OnPlayerMoved += playerView.PlayerMovedHandler;
			OnPlayerMoved += cameraView.PlayerMovedHandler;
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
