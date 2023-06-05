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
    public Transform spawnPoint;

    public float timeBetweenWaves = 1f;
    public float timeBetweenEnemies = 0.5f; // Delay between spawning each enemy in a wave

    private int waveNumber = 0;

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

    IEnumerator SpawnWaves()
    {
        while (waveNumber < Waves.Count)
        {
            Wave wave = Waves[waveNumber];
            yield return SpawnWave(wave);

            waveNumber++;

            if (waveNumber < Waves.Count)
                yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    IEnumerator SpawnWave(Wave wave)
    {
        PlayerStats.Rounds++;
        EnemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(timeBetweenEnemies);
        }
    }

    private void SpawnEnemy(EnemyType enemyType)
    {
        _factory.CreateEnemy(enemyType, spawnPoint);
    }
}