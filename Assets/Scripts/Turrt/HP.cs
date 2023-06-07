using System;
using UnityEngine;

namespace Assets.Scripts.Turrt
{
    public class HP :  MonoBehaviour
    {
        public Action<float, float> OnHPChanged { get; internal set; }

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

        public void TakeDamage(int damage)
        {
            CurrentHP -= damage;
  
        }
    }
}
