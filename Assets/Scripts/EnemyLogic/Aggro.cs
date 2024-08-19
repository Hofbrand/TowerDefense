using Assets.Scripts.Turrt;
using System;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.EnemyLogic
{
    public class Aggro : MonoBehaviour
    {
        public TriggerObserver TriggerObserver;
        public EnemyMovement Follow;
        public Death MyDeath;

        private void Start()
        {
            MyDeath.Happened += OnMyDeath;
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
            Follow.Agent.isStopped = false;
        }

        private void TriggerEnter(Collider obj)
        {
            TriggerObserver.Death.Happened += OnDeath;
            SwitchFollowOff();
        }

        private void OnDeath()
        {
            
           SwitchFollowOn();
        }

        private void OnMyDeath()
        {
            SwitchFollowOff();
        }

        private void OnTakeHit()
        {
            SwitchFollowOff();
        }

        private void OnHitEnded()
        {
            SwitchFollowOn();
        }

        private void OnDestroy()
        {
            TriggerObserver.TriggerEnter -= TriggerEnter;
            TriggerObserver.TriggerExit -= TriggerExit;
        }
    }
}