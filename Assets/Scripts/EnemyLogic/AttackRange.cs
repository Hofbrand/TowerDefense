using System;
using System.Runtime.Serialization;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.EnemyLogic
{
    public class AttackRange : MonoBehaviour
    {
        public TriggerObserver TriggerObserver;
        public Attack Attack;

        private void Start()
        {
            TriggerObserver.TriggerEnter += OnTriggerEnter;
            TriggerObserver.TriggerExit += OnTriggerExit;
        }

        private void OnTriggerExit(Collider obj)
        {
            Attack.Disable();
        }

        private void OnTriggerEnter(Collider obj)
        {
            Attack.Enable();
            TriggerObserver.Death.Happened += OnDeath;
        }

        private void OnDeath()
        {
           Attack.Disable();
        }
    }
}
