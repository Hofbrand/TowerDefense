﻿using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.StaticData;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        void CreateHUD();
        void CreateEnemy(EnemyType type,Transform at);
    }
}