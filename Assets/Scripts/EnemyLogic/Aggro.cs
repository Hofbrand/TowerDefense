using System;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.EnemyLogic
{
    public class Aggro : MonoBehaviour
    {
        public TriggerObserver TriggerObserver;
        public EnemyMovement Follow;

        private void Start()
        {
            TriggerObserver.TriggerEnter += TriggerEnter;
            TriggerObserver.TriggerExit += TriggerExit;
        }

        private void SwitchFollowOff()
        {
            Follow.enabled = false;
            Follow.Agent.isStopped = true;
        }

        private void TriggerExit(Collider obj)
        {
            SwitchFollowOn();
        }

        private void SwitchFollowOn()
        {
            Follow.enabled = true;
        }

        private void TriggerEnter(Collider obj)
        {
            //consol write info
            Debug.LogError("Aggro TriggerEnter");
            SwitchFollowOff();
        }
    }
}