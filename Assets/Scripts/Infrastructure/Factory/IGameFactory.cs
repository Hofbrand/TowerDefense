using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.StaticData;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        Transform TargetTransform { get; }

        void CreateHUD();
        void CreateEnemy(EnemyType type,Transform at);
        void InitWaveSpawner(LevelStaticData levelStaticData);
    }
}