using Assets.Scripts.Infrastructure.AssetManagment;
using Assets.Scripts.Infrastructure.EnemyLogic;
using Assets.Scripts.Infrastructure.StaticData;
using Assets.Scripts.Turrt;
using Cinemachine;
using System;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private const string WaveTag = "WaveSpawner";
        private const string Target = "Target";

        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticData;
       
        public Action OnTargetCreated;

        public Transform TargetTransform { get; private set; }

        public GameFactory(IAssetProvider assetProvider, IStaticDataService staticData)
        {
            _staticData = staticData;
            _assetProvider = assetProvider;
        }

        public void CreateEnemy(EnemyType type ,Transform at)
        {
            EnemyStaticData data = _staticData.ForEnemy(type);

            GameObject enemy = UnityEngine.Object.Instantiate(data.Prefab, at.position, Quaternion.identity);
            InitTarget();
            InitEnemy(data, enemy);
        }

        public void CreateHUD()
        {
            _assetProvider.Instantiate(AssetPath.HudPath);
        }

        public void InitWaveSpawner(LevelStaticData levelStaticData)
        {
            WaveSpawner waveSpawner = GameObject.FindWithTag(WaveTag).GetComponent<WaveSpawner>();
            waveSpawner.TimeBetweenWaves = levelStaticData.TimeBetweenWaves;
            waveSpawner.Waves = levelStaticData.Waves;
        }

        public void EnableSpawner()
        {
            WaveSpawner waveSpawner = GameObject.FindWithTag(WaveTag).GetComponent<WaveSpawner>();

            waveSpawner.enabled = true;
        }

        private void InitTarget()
        {
            TargetTransform = GameObject.FindWithTag(Target).transform;
            OnTargetCreated?.Invoke();
        }

        private void InitEnemy(EnemyStaticData data, GameObject enemy)
        {
            var hp = enemy.GetComponent<HP>();
            var death = enemy.GetComponent<Death>();
            hp.MaxHP = data.StartHealth;
            //var enemyMb = enemy.GetComponent<Enemy>();
            //enemyMb.value = data.Value;
            //enemyMb.deathEffect = data.DeathEffect;
            //enemyMb.startSpeed = data.StartSpeed;
        }

        public void EnableCamera(string cam)
        {
            CinemachineVirtualCamera vCam = GameObject.FindWithTag(cam).GetComponent<CinemachineVirtualCamera>();
            vCam.MoveToTopOfPrioritySubqueue();
        }
    }
}