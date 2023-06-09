using Assets.Scripts.Infrastructure.Factory;
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
    public Transform SpawnPoint;
    public float TimeBetweenWaves;

    private int _waveNumber = 0;

    public Text waveCountdownText;

    public GameManager gameManager;
    private IGameFactory _factory;

    private void Awake()
    {
        _factory = AllServices.Container.Single<IGameFactory>();
    }

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        while (_waveNumber < Waves.Count)
        {
            Wave wave = Waves[_waveNumber];
            yield return SpawnWave(wave);

            _waveNumber++;

            if (_waveNumber < Waves.Count)
                yield return new WaitForSeconds(TimeBetweenWaves);
        }
    }

    private IEnumerator SpawnWave(Wave wave)
    {
        PlayerStats.Rounds++;
        EnemiesAlive = wave.Count;

        for (int i = 0; i < wave.Count; i++)
        {
            SpawnEnemy(wave.Enemy);
            yield return new WaitForSeconds(wave.TimeBetweenEnemies);
        }
    }

    private void SpawnEnemy(EnemyType enemyType)
    {
        _factory.CreateEnemy(enemyType, SpawnPoint);
    }
}