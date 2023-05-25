using Assets.Scripts.Infrastructure.Services;

namespace Assets.Scripts.Infrastructure.StaticData
{
    public interface IStaticDataService : IService
    {
        EnemyStaticData ForEnemy(EnemyType type);
        LevelStaticData ForLevel(string sceneKey);
        void LoadLevels();
        void LoadMonsters();
    }
}