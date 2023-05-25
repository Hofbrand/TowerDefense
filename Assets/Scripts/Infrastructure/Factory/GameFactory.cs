using Assets.Scripts.Infrastructure.AssetManagment;
using Assets.Scripts.Infrastructure.StaticData;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticData;

        public GameFactory(IAssetProvider assetProvider, IStaticDataService staticData)
        {
            _staticData = staticData;
            _assetProvider = assetProvider;
        }

        public void CreateEnemy(EnemyType type ,Transform at)
        {
            EnemyStaticData data = _staticData.ForEnemy(type);

            GameObject enemy = Object.Instantiate(data.Prefab, at.position, Quaternion.identity);
            var enemyMB = enemy.GetComponent<Enemy>();
            InitEnemy(data, enemyMB);
        }
        public void CreateHUD()
        {
            _assetProvider.Instantiate(AssetPath.HudPath);
        }

        public void InitWaveSpawner(LevelStaticData levelStaticData)
        {
            WaveSpawner waveSpawner = GameObject.FindWithTag("WaveSpawner").GetComponent<WaveSpawner>();
       
            waveSpawner.Waves = levelStaticData.Waves;
            waveSpawner.enabled = true;
        }

        private void InitEnemy(EnemyStaticData data, Enemy enemyMB)
        {
            enemyMB.health = data.StartHealth;
            enemyMB.value = data.Value;
            enemyMB.deathEffect = data.DeathEffect;
            enemyMB.startSpeed = data.StartSpeed;   
        }
    }
}