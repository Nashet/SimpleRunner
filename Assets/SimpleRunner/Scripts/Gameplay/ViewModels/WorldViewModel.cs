﻿
using Assets.SimpleRunner.Patterns;
using Nashet.SimpleRunner.Configs;
using UnityEngine;

namespace Nashet.SimpleRunner.Gameplay.ViewModels
{
	public delegate void OnUpdateHappenedDelegate(float fixedDeltaTime, Vector2 playerPosition);
	/// <summary>
	/// The purpose of this class is to communicate with nested View Models.
	/// </summary>
	public class WorldViewModel
	{
		public event OnUpdateHappenedDelegate OnUpdateHappened;

		private PlayerViewModel playerVM;
		private CoinSpawnerViewModel coinSpawnerVM;
		private GameplayConfig gameplayConfig;
		private IGameObjectFactory backgroundObjectFactory;

		public WorldViewModel(GameplayConfig gameplayConfig, IGameObjectFactory gameObjectFactory, GameObjectPoolFactory backgroundObjectFactory)
		{
			this.gameplayConfig = gameplayConfig;
			this.backgroundObjectFactory = backgroundObjectFactory;
			playerVM = new PlayerViewModel(gameplayConfig);
			coinSpawnerVM = new CoinSpawnerViewModel(playerVM, gameplayConfig, gameObjectFactory);
		}

		public void InitializeWithView(IWorldView worldView, IPlayerView playerView, ICameraView cameraView)
		{
			playerVM.InitializeWithView(playerView, cameraView);
			OnUpdateHappened += worldView.UpdateHappenedHandler;
			worldView.Initialize(gameplayConfig, backgroundObjectFactory);
		}

		internal void Update(float fixedDeltaTime)
		{
			playerVM.Update(fixedDeltaTime);
			OnUpdateHappened?.Invoke(fixedDeltaTime, playerVM.Position);
		}
	}
}