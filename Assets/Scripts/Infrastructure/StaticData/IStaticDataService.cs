using Assets.Scripts.Infrastructure.Services;

namespace Assets.Scripts.Infrastructure.StaticData
{
    public interface IStaticDataService : IService
    {
        EnemyStaticData ForEnemy(EnemyType type);
        void LoadMonsters();
    }
}