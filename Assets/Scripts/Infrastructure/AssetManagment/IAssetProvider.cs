using Assets.Scripts.Infrastructure.Services;

namespace Assets.Scripts.Infrastructure.AssetManagment
{
    public interface IAssetProvider : IService
    {
        void Instantiate(string path);
    }
}