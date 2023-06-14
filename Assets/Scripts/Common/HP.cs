using Assets.Scripts.Infrastructure.EnemyLogic;
using System;
using UnityEngine;

namespace Assets.Scripts.Turrt
{
    public class HP :  MonoBehaviour
    {
        public Action<float, float> OnHPChanged { get; internal set; }
        public EnemyAnimator EnemyAnimator;

        public int MaxHP = 100;

        private int _currentHP;

        public int CurrentHP 
        {
            get => _currentHP;
            set
            {
                if (_currentHP != value) 
                _currentHP = value;

                OnHPChanged?.Invoke(_currentHP, MaxHP);

                Debug.Log($"CurrentHP {value}");
            }
        }
        
        private void Start()
        {
            CurrentHP = MaxHP;
        }

        public void TakeDamage(int damage)
        {
            if(EnemyAnimator)
            {
                EnemyAnimator.PlayHit();
            }

            Debug.Log($"TakeDamage {damage}");
            CurrentHP -= damage;
        }
    }
}
