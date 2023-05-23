using System;

namespace Assets.Scripts.Infrastructure
{
    public class BootstrapState : IState
    {
        private const string Name = "Bootstrap";
        private readonly GameStateMachine _stateMachine;
        private SceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            RegisterServices();

            _sceneLoader.Load(Name, EnterLoadLevel);
        }

        private void EnterLoadLevel()
        {
            _stateMachine.Enter<LoadLevelState, string>("MainMenu");
        }

        private void RegisterServices()
        {
        }

        public void Exit()
        {
        }
    }
}
