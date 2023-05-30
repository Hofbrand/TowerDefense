using Assets.Scripts.Infrastructure.AssetManagment;
using Assets.Scripts.Infrastructure.StaticData;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private const string WaveTag = "WaveSpawner";
        private const string Target = "Target";

        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticData;
       
        public Transform TargetTransform { get; private set; }

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
            InitTarget();
            InitEnemy(data, enemyMB);
        }

        public void CreateHUD()
        {
            _assetProvider.Instantiate(AssetPath.HudPath);
        }

        public void InitWaveSpawner(LevelStaticData levelStaticData)
        {
            WaveSpawner waveSpawner = GameObject.FindWithTag(WaveTag).GetComponent<WaveSpawner>();
       
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
        }

        private void InitEnemy(EnemyStaticData data, Enemy enemyMB)
        {
            enemyMB.health = data.StartHealth;
            enemyMB.value = data.Value;
            enemyMB.deathEffect = data.DeathEffect;
            enemyMB.startSpeed = data.StartSpeed;   
        }

        public void EnableFPSCamera()
        {
            Camera currentCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
            currentCamera.enabled = false;
            Camera fps = GameObject.FindWithTag("FPS").GetComponent<Camera>();
            fps.enabled = true;
        }
    }
}