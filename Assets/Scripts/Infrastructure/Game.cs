using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.States;

namespace Assets.Scripts.Infrastructure
{
    public class Game 
    {
        public GameStateMachine StateMachine;
         
        public Game(ICoroutineRunner coroutineRunner, SceneFader fader)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), fader, AllServices.Container);
        }

    }
}