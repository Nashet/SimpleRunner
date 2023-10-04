using Nashet.SimpleRunner.Configs;
using Nashet.SimpleRunner.Configs.PlayerEffects;
using Nashet.SimpleRunner.Gameplay.Models;
using Nashet.SimpleRunner.Gameplay.Views; // todo renove it
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

		public Vector2 Position => playerModel.Position;

		private PlayerMovementModel playerModel;

		private CollectableEffectConfig defaultAction;
		private CollectableEffectConfig currentAction;
		private float currentActionDuration;
		private IMovementStrategyFactory movementStrategyFactory;
		private GameplayConfig gameplayConfig;

		private IPlayerMovementStrategy _currentMovementStrategy;
		private IPlayerMovementStrategy currentMovementStrategy
		{
			set
			{
				_currentMovementStrategy = value;
				lastTimeStrategyChanged = Time.time;
			}
			get => _currentMovementStrategy;
		}

		private float lastTimeStrategyChanged;

		public PlayerViewModel(GameplayConfig gameplayConfig, IMovementStrategyFactory movementStrategyFactory)
		{
			this.movementStrategyFactory = movementStrategyFactory;
			this.gameplayConfig = gameplayConfig;
			defaultAction = gameplayConfig.defaultPlayerAction;
			playerModel = new PlayerMovementModel(gameplayConfig.playerStartingPosition);
			playerModel.OnPlayerMoved += OnPlayerMovedhandler;

			SetDefaultAction(defaultAction);
		}

		private void OnPlayerMovedhandler(Vector3 newPosition)
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
			var collectable = other.GetComponent<CollectablesView>();
			if (collectable == null)
				throw new System.Exception("Collectable is null");
			OnCollectedObject?.Invoke(other);
			SetNewAction(collectable.CollidableObjectType);
		}

		private void SetDefaultAction(CollectableEffectConfig newEffect)
		{
			this.currentAction = newEffect;
			currentMovementStrategy = movementStrategyFactory.CreateMovementStrategy(newEffect, gameplayConfig);
			Debug.Log($"Applied effect is default ({currentMovementStrategy})");
		}

		private void SetNewAction(CollectableObjectTypeConfig newEffect)
		{
			this.currentAction = newEffect.effect;
			currentActionDuration = newEffect.effectTime;
			currentMovementStrategy = movementStrategyFactory.CreateMovementStrategy(newEffect.effect, gameplayConfig);
			Debug.Log($"Applied effect is is {currentMovementStrategy}");
		}

		public void Update(float deltaTime)
		{
			if (currentAction != defaultAction && Time.time - lastTimeStrategyChanged > currentActionDuration)
			{
				SetDefaultAction(defaultAction);
				OnEffectEnded?.Invoke();
			}
			currentMovementStrategy.Move(playerModel, deltaTime);
		}
	}
}
