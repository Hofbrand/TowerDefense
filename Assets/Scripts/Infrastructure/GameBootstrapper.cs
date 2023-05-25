using Assets.Scripts.Infrastructure.States;
using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;
        public SceneFader Fader;

        private void Awake()
        {
            _game = new Game(this, Fader);
            _game.StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}
