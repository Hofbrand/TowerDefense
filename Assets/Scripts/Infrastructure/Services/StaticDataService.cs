using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<EnemyType, EnemyStaticData> _enemies;

        public void LoadMonsters()
        {
            _enemies = Resources.LoadAll<EnemyStaticData>("SO/Enemy").ToDictionary(x => x.Type, x => x);
        }

        public EnemyStaticData ForEnemy(EnemyType type)
        {
            return _enemies.TryGetValue(type, out EnemyStaticData enemyStaticData) ? enemyStaticData : null;
        }

    }
}
