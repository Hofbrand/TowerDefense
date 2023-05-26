using Assets.Scripts.Infrastructure.Factory;
using Assets.Scripts.Infrastructure.Services;
using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent Agent;

    private const float MinDistance = 1f;

    private Transform target;
    private int wavepointIndex = 0;
    private IGameFactory _gameFactory;

    private Enemy enemy;

    void Start()
    {
        _gameFactory = AllServices.Container.Single<IGameFactory>();
        target = _gameFactory.TargetTransform;
        Debug.LogError(target.gameObject.name);
        Debug.LogError(target.position);
        enemy = GetComponent<Enemy>();

        Agent.destination = target.position;
    }

    private bool TargetNotReached()
    {
        return Vector3.Distance(Agent.transform.position, target.position) >= MinDistance;
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.waypoints.Length - 1)
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        target = Waypoints.waypoints[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
