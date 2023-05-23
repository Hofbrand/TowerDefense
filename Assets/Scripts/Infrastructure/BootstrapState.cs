namespace Assets.Scripts.Infrastructure
{
    public class BootstrapState : IState
    {
        public void Enter()
        {
            RegisterServices();
        }

        private void RegisterServices()
        {
        }

        public void Exit()
        {
        }
    }
}
