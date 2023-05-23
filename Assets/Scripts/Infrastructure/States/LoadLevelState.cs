using Assets.Scripts.Infrastructure.Factory;

namespace Assets.Scripts.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private GameStateMachine _gameStateMachine;
        private SceneLoader _sceneLoader;
        private SceneFader _fader;
        private IGameFactory _factory;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, SceneFader fader, IGameFactory factory)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _fader = fader;
            _factory = factory;
        }

        public void Enter(string name)
        {
            _fader.Show();
            _sceneLoader.Load(name, OnLoaded);
        }

        private void OnLoaded()
        {
            _factory.CreateHUD();

            _gameStateMachine.Enter<GameLoopState>();
        }

        public void Exit()
        {
            _fader.Hide();
        }
    }
}
