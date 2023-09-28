using Nashet.SimpleRunner.Configs;
using Nashet.SimpleRunner.Configs.PlayerEffects;
using Nashet.SimpleRunner.Gameplay.Models;
using Nashet.SimpleRunner.Gameplay.Views; // todo renove it
using UnityEngine;

namespace Nashet.SimpleRunner.Gameplay.ViewModels
{
	public delegate void OnEffectEnded();

	/// <summary>
	/// The only purpose of this class is to be the intermediate between the view and the model of the player.
	/// </summary>
	public class PlayerViewModel
	{
		public event OnPlayerMovedDelegate OnPlayerMoved;
		public event OnEffectEnded OnEffectEnded;

		private PlayerMovementModel playerModel;

		private CollectableEffectConfig defaultAction;
		private CollectableEffectConfig currentAction;
		private float currentActionDuration;

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

		public PlayerViewModel(CollectableEffectConfig defaultAction, Vector2 startingPosition)
		{
			playerModel = new PlayerMovementModel(startingPosition);
			playerModel.OnPlayerMoved += OnPlayerMovedhandler;

			SetDefaultAction(defaultAction);
			this.defaultAction = defaultAction;
		}

		private void OnPlayerMovedhandler(Vector3 newPosition)
		{
			OnPlayerMoved?.Invoke(newPosition);
		}

		public void InitializeWithView(IPlayerView playerView, CameraView cameraView)
		{
			playerModel.Position = playerView.Position;

			playerView.OnPlayerCollided += OnPlayerCollidedHandler;

			OnPlayerMoved += playerView.PlayerMovedHandler;
			OnPlayerMoved += cameraView.PlayerMovedHandler;
		}

		private void OnPlayerCollidedHandler(GameObject other)
		{
			GameObject coin = other.gameObject;
			var collectable = coin.GetComponent<CollectablesView>();
			SetNewAction(collectable.CollidableObjectType);
		}

		private void SetDefaultAction(CollectableEffectConfig newEffect)
		{
			this.currentAction = newEffect;
			currentMovementStrategy = MovementStrategyFactory.CreateMovementStrategy(newEffect);
			Debug.LogError($"new strategy is default {currentMovementStrategy}");
		}

		private void SetNewAction(CollectableObjectTypeConfig newEffect)
		{
			this.currentAction = newEffect.effect;
			currentActionDuration = newEffect.effectTime;
			currentMovementStrategy = MovementStrategyFactory.CreateMovementStrategy(newEffect.effect);
			Debug.LogError($"new strategy is {currentMovementStrategy}");
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
