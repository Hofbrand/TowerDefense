using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.StaticData;
using System;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        //Action OnTargetCreated;
        Transform TargetTransform { get; }

        void CreateHUD();
        void CreateEnemy(EnemyType type,Transform at);
        void InitWaveSpawner(LevelStaticData levelStaticData);
        void EnableSpawner();
        void EnableCamera(string cam);
    }
}