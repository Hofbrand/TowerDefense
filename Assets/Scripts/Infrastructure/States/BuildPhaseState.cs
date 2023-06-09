using Assets.Scripts.Infrastructure.Factory;
using Assets.Scripts.Infrastructure.States;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    public class BuildPhaseState : IState
    {
        private GameStateMachine _gameStateMachine;
        private readonly IGameFactory _gameFactory;
        private double seconds = 15;

        public BuildPhaseState(GameStateMachine gameStateMachine, IGameFactory gameFactory)
        {
            _gameStateMachine = gameStateMachine;
            _gameFactory = gameFactory;
        }

        public async void Enter()
        {
            await Task.Delay(TimeSpan.FromSeconds(seconds));
            _gameStateMachine.Enter<ActionPhaseState>();
            _gameFactory.EnableCamera("FPS");
        }

        public void Exit()
        {
           _gameFactory.EnableSpawner();
            GameObject.FindGameObjectWithTag("Build").GetComponent<BuildManager>().TurnOff();
            //turn off hud 
            DisableShop();
            EnableActiobHud();
        //   _gameFactory.EnableCamera("FPS");
        }

        private void DisableShop()
        {
            GameObject.FindGameObjectWithTag("Shop").gameObject.SetActive(false);
        }

        private void EnableActiobHud()
        {
            GameObject.FindGameObjectWithTag("Action").GetComponent<Canvas>().enabled = true;
        }
    
    }
}