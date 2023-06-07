using System;
using UnityEngine;

namespace Assets.Scripts.Turrt
{
    public class HP :  MonoBehaviour
    {
        public int MaxHP = 100;

        private int _currentHP;
        public int CurrentHP 
        {
            get => _currentHP;
            set
            {
                if (_currentHP != value) 
                OnHPChanged?.Invoke(_currentHP, MaxHP);

                _currentHP = value;
            }
        }
        
        private void Start()
        {
            CurrentHP = MaxHP;
        }

        public static Action<float, float> OnHPChanged { get; internal set; }

        public void TakeDamage(int damage)
        {
            CurrentHP -= damage;
            if (CurrentHP <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
