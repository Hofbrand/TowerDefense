using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Infrastructure.EnemyLogic
{
    public class Enemy : MonoBehaviour
    {
        public float startSpeed = 10f;

        [HideInInspector]
        public float speed;
        [HideInInspector]
        public float health;
        public EnemyAnimator Animator;

        public float startHealth = 100;

        public int value = 50;

        public GameObject deathEffect;

        private bool isDead = false;

        [Header("Unity stuff")]
        public Image healthBar;


        public void TakeDamage(float amount)
        {
            health -= amount;
            Animator.PlayHit();

            healthBar.fillAmount = health / startHealth;

            if (health <= 0 && !isDead)
            {
                Die();
            }
        }

        void Die()
        {
            isDead = true;

            PlayerStats.Money += value;

            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);

            WaveSpawner.EnemiesAlive--;
            Animator.PlayDeath();
            Destroy(gameObject,2f);
        }
    }
}