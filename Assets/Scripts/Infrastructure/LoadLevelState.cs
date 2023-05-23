namespace Assets.Scripts.Infrastructure
{
    public class LoadLevelState : IState
    {
        private GameStateMachine _gameStateMachine;
        private SceneLoader _sceneLoader;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.Load("MainMenu");
        }

        public void Exit()
        {
        }
    }
}
