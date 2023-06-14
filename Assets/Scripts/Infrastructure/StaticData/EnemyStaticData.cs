using UnityEngine;

namespace Assets.Scripts.Infrastructure.StaticData
{
    [CreateAssetMenu(fileName ="Enemy", menuName = "Static data/Enemy")]
    public class EnemyStaticData : ScriptableObject
    {
        public EnemyType Type;

        [Range(1f, 1000f)]
        public int StartHealth;
        [Range(1f, 100f)]
        public float StartSpeed;
        [Range(1,100)]
        public int Value;

        public GameObject Prefab;
        public GameObject DeathEffect;
    }
}
