using System;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.EnemyLogic
{
    [RequireComponent(typeof(Collider))]
    public class TriggerObserver : MonoBehaviour
    {
        public event Action<Collider> TriggerEnter;
        public event Action<Collider> TriggerExit;

        private void OnTriggerEnter(Collider other)
        {
            // debug log
            Debug.LogError("TriggerObserver OnTriggerEnter");
            TriggerEnter?.Invoke(other);
        }

        private void OnTriggerExit(Collider other) =>
          TriggerExit?.Invoke(other);
    }
}