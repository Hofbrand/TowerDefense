﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;

    [HideInInspector]
    public float speed;
    [HideInInspector]
    public float health;

    public float startHealth = 100;

    public int value = 50;

    public GameObject deathEffect;

    private bool isDead = false;

    [Header("Unity stuff")]
    public Image healthBar;

    private void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if(health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Slow(float pct)
    {
        speed = startSpeed*(1f - pct);
    }

    void Die()
    {
        isDead = true;

        PlayerStats.Money += value;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        WaveSpawner.EnemiesAlive--;
        
        Destroy(gameObject);
    }
}
