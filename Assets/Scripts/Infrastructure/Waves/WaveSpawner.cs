﻿using Assets.Scripts.Infrastructure.Factory;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.StaticData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    public static int EnemiesAlive = 0;

    public List<Wave> Waves;
    public Transform spawnPoint;

    public float timeBetweenWaves = 1f;
    private float countdown = 2f;

    private int waveNumber = 0;

    public Text waveCountdownText;

    public GameManager gameManager;
    private IGameFactory _factory;

    private void Awake()
    {
        _factory = AllServices.Container.Single<IGameFactory>();
    }

    private void Update()
    {
        if (EnemiesAlive > 0)
        {
 //           waveCountdownText.text = string.Format("{0:00.00}", 0f);
            return;
        }

        if (waveNumber == Waves.Count)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

//        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;

        Wave wave = Waves[waveNumber];

        EnemiesAlive = wave.count;
        
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);//waveEnemy as param
            yield return new WaitForSeconds(1f/wave.rate);
        }

        waveNumber++;

    }

    private void SpawnEnemy(EnemyType enemyType)
    {
        _factory.CreateEnemy(enemyType, spawnPoint);
    }
}