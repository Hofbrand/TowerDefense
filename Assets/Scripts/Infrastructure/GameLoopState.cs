﻿using Assets.Scripts.Infrastructure.States;

namespace Assets.Scripts.Infrastructure
{
    public class GameLoopState : IState
    {
        private GameStateMachine _gameStateMachine;

        public GameLoopState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
        }

        public void Exit()
        {
        }
    }
}