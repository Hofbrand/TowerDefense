using System;
using System.Diagnostics;

namespace Assets.Scripts.Infrastructure.States
{
    public class ActionPhaseState : IState
    {
        public void Enter()
        {
            Console.Write("Action phase");
        }

        public void Exit()
        {
        }
    }
}
