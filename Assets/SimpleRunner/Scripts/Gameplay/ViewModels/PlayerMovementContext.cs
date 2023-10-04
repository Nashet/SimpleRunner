using Nashet.SimpleRunner.Gameplay.Contracts;
using Nashet.SimpleRunner.Gameplay.Models;
using System;
using UnityEngine;

namespace Nashet.SimpleRunner.Gameplay.ViewModels
{
	public delegate void StateChangedDelegate(IPlayerMovementStrategy newState);
	/// <summary>
	/// State pattern
	/// </summary>
	public class PlayerMovementContext
	{
		public event StateChangedDelegate OnStateChanged;
		// A reference to the current state of the Context.
		private IPlayerMovementStrategy defaultState = null;
		private IPlayerMovementStrategy state = null;
		private float lastTimeStrategyChanged;

		public PlayerMovementContext(IPlayerMovementStrategy state)
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
		}

		// The Context delegates part of its behavior to the current State
		// object.
		public void Move(PlayerMovementModel playerModel, float deltaTime)
		{
			if (state != defaultState && Time.time - lastTimeStrategyChanged > state.CurrentActionDuration)
			{
				ChangeStateToDefault();
			}
			this.state.Move(playerModel, deltaTime);
		}

		private void ChangeStateToDefault()
		{
			ChangeStateTo(defaultState);
		}
	}
}