using Assets.Scripts.Infrastructure.AssetManagment;
using Assets.Scripts.Infrastructure.Factory;
using Assets.Scripts.Infrastructure.Services;

namespace Assets.Scripts.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private const string Name = "Bootstrap";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = services;

            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.Load(Name, EnterLoadLevel);
        }

        private void EnterLoadLevel()
        {
            _stateMachine.Enter<LoadLevelState, string>("Level01");
        }

        private void RegisterServices()
        {
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAssetProvider>()));
        }

        public void Exit()
        {
        }
    }
}
