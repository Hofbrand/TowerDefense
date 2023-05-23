using System;
using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private const string HudPath = "HUD/HUD";
        private GameStateMachine _gameStateMachine;
        private SceneLoader _sceneLoader;
        private SceneFader _fader;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, SceneFader fader) : this(gameStateMachine, sceneLoader)
        {
            _fader = fader;
        }

        public void Enter(string name)
        {
            _fader.Show();
            _sceneLoader.Load(name, OnLoaded);
        }

        private void OnLoaded()
        {
            var prefab = Resources.Load<GameObject>(HudPath);
            UnityEngine.Object.Instantiate(prefab);

            _gameStateMachine.Enter<GameLoopState>();
        }

        public void Exit()
        {
            _fader.Hide();
        }
    }
}
