using Nashet.SimpleRunner.Contracts.Patterns;
using Nashet.SimpleRunner.Gameplay.Contracts;
using Nashet.SimpleRunner.Gameplay.Models;
using System;
using UnityEngine;

namespace Nashet.SimpleRunner.Gameplay.ViewModels
{
	/// <summary>
	/// State pattern
	/// </summary>
	public class PlayerMovementStatePattern : IPlayerMovementStatePattern
	{
		public event StateChangedDelegate OnStateChanged;
		public event PropertyChangedEventHandler<IPlayerMovementStatePattern> OnPropertyChanged;

		// A reference to the current state of the Context.
		private IPlayerMovementStrategy defaultState = null;
		public IPlayerMovementStrategy state { get; private set; }
		public float lastTimeStrategyChanged { get; private set; }

		public PlayerMovementStatePattern(IPlayerMovementStrategy state)
		{
			defaultState = state;
			this.ChangeStateTo(state);
		}

		// The Context allows changing the State object at runtime.
		public void ChangeStateTo(IPlayerMovementStrategy state)
		{
			Debug.Log($"Applied effect is ({state})");
			Console.WriteLine($"Context: Transition to {state.GetType().Name}.");
			this.state = state;
			this.state.SetContext(this);
			lastTimeStrategyChanged = Time.time;
			OnStateChanged?.Invoke(state);
			RiseOnPropertyChanged(nameof(state));
		}

		// The Context delegates part of its behavior to the current State
		// object.
		public void Move(PlayerMovementModel playerModel, float deltaTime)
		{
			if (state != defaultState && Time.time - lastTimeStrategyChanged > state.config.effectTime)
			{
				ChangeStateToDefault();
			}
			this.state.Move(playerModel, deltaTime);
		}

		private void ChangeStateToDefault()
		{
			ChangeStateTo(defaultState);
		}

		public void RiseOnPropertyChanged(string propertyName)
		{
			OnPropertyChanged?.Invoke(this, propertyName);
		}
	}
}