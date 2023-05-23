namespace Assets.Scripts.Infrastructure
{
    internal class Game
    {
        public GameStateMachine StateMachine;
        public Game()
        {
            StateMachine = new GameStateMachine();
        }

    }
}