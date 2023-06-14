using Assets.Scripts.Infrastructure.EnemyLogic;
using Assets.Scripts.Infrastructure.Factory;
using Assets.Scripts.Infrastructure.Services;
using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent Agent;

    private const float MinDistance = 9f;

    private Transform target;
    private int wavepointIndex = 0;
    private IGameFactory _gameFactory;

    void Start()
    {
        _gameFactory = AllServices.Container.Single<IGameFactory>();
        target = _gameFactory.TargetTransform;

        Agent.destination = target.position;
    }

    private void Update()
    {
        if (TargetNotReached())
        {
            Agent.destination = target.position;
            return;
        }
    }

    private bool TargetNotReached()
    {
        return Vector3.Distance(Agent.transform.position, target.position) >= MinDistance;
    }

    void EndPath()
    {
        PlayerStats.lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
