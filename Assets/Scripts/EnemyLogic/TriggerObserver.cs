using Assets.Scripts.Turrt;
using System;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.EnemyLogic
{
    [RequireComponent(typeof(Collider))]
    public class TriggerObserver : MonoBehaviour
    {
        public event Action<Collider> TriggerEnter;
        public event Action<Collider> TriggerExit;

        public Death Death;

        private void OnTriggerEnter(Collider other)
        {
            // debug log
            Debug.LogError("TriggerObserver OnTriggerEnter");
            Death = other.GetComponent<Death>();
            TriggerEnter?.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            Death = null;
            TriggerExit?.Invoke(other);
        }
    }
}