using System;
using UnityEngine;

namespace Assets.Scripts.Turrt
{
    public class Death :  MonoBehaviour
    {
        public Action Happened;

        public HP HP;

        private void Start() => HP.OnHPChanged += HPChanged;

        private void OnDestroy()
        => HP.OnHPChanged -= HPChanged;

        private void HPChanged(float arg1, float arg2)
        {
            if (HP.CurrentHP <= 0)
                Die();
        }

        private void Die()
        {
            Happened?.Invoke();
            Destroy(gameObject);
        }
    }
}
