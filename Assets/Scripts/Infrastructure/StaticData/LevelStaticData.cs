using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.StaticData
{
    [CreateAssetMenu(fileName = "Level",menuName =" Static data/Level")]
    public class LevelStaticData : ScriptableObject
    {
        public string LevelKey;
        public float TimeBetweenWaves;
        public List<Wave> Waves;
    }
}