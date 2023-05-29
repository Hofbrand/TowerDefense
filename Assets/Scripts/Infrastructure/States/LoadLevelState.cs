using Assets.Scripts.Infrastructure.Factory;
using Assets.Scripts.Infrastructure.StaticData;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly SceneFader _fader;
        private readonly IGameFactory _factory;
        private readonly IStaticDataService _staticData;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, SceneFader fader, IGameFactory factory, IStaticDataService staticData)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _fader = fader;
            _factory = factory;
            _staticData = staticData;
        }

        public void Enter(string name)
        {
            _fader.Show();
            _sceneLoader.Load(name, OnLoaded);
        }

        private void OnLoaded()
        {
            InitGameWorld();
            _gameStateMachine.Enter<GameLoopState>();
        }

        private void InitGameWorld()
        {
            _factory.CreateHUD();
            InitSpawners();
        }

        private void InitSpawners()
        {
            string sceneKey = SceneManager.GetActiveScene().name;
            LevelStaticData levelStaticData = _staticData.ForLevel(sceneKey);
            foreach(var spawner in GameObject.FindGameObjectsWithTag("WaveSpawner"))
            {

            }
            _factory.InitWaveSpawner(levelStaticData);
        }

        public void Exit()
        {
            _fader.Hide();
        }
    }
}
