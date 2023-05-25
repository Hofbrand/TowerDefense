using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<EnemyType, EnemyStaticData> _enemies;
        private Dictionary<string, LevelStaticData> _levels;

        public void LoadMonsters()
        {
            _enemies = Resources.LoadAll<EnemyStaticData>("SO/Enemy").ToDictionary(x => x.Type, x => x);
        }

        public void LoadLevels()
        {
            _levels = Resources.LoadAll<LevelStaticData>("SO/Level").ToDictionary( x => x.LevelKey, x => x);
        }

        public EnemyStaticData ForEnemy(EnemyType type) 
        {
            return _enemies.TryGetValue(type, out EnemyStaticData enemyStaticData) ? enemyStaticData : null;
        }

        public LevelStaticData ForLevel(string sceneKey)
        {
            var g = _levels.TryGetValue(sceneKey, out LevelStaticData levelStaticData);
            Debug.LogError(levelStaticData.Waves.Count);

            return g  ? levelStaticData : null;

        }
    }
}
