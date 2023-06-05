using Assets.Scripts.Infrastructure.EnemyLogic;
using Assets.Scripts.Infrastructure.Factory;
using Assets.Scripts.Infrastructure.Services;
using System;
using UnityEngine;
using UnityEngine.AI;



[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent Agent;

    private const float MinDistance = 9f;

    private Transform target;
    private int wavepointIndex = 0;
    private IGameFactory _gameFactory;

    private Enemy enemy;

    void Start()
    {
        _gameFactory = AllServices.Container.Single<IGameFactory>();
        target = _gameFactory.TargetTransform;
        enemy = GetComponent<Enemy>();

        Agent.destination = target.position;
    }

    private void Update()
    {
        //if target is not reached agent will move
        if (TargetNotReached())
        {
            Agent.destination = target.position;
            return;
        }
        //if target is reached agent will stop
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
