using Assets.Scripts.Infrastructure.EnemyLogic;
using System;
using UnityEngine;

namespace Assets.Scripts.Turrt
{
    public class Death :  MonoBehaviour
    {
        public Action Happened;
        public EnemyAnimator EnemyAnimator;
        public HP HP;
        public bool IsDead => HP.CurrentHP <= 0;

        private void Start()
        {
            HP.OnHPChanged += HPChanged;
        }

        private void Died()
        {
            Destroy(gameObject);    
        }

        private void OnDestroy()
        => HP.OnHPChanged -= HPChanged;

        private void HPChanged(float arg1, float arg2)
        {
            Debug.Log($"HP changed from {arg1} to {arg2}");
            if (HP.CurrentHP <= 0)
                Die();
        }

        private void Die()
        {
            Happened?.Invoke();

            if (EnemyAnimator != null)
                EnemyAnimator.PlayDeath();

            Died();
        }
    }
}
