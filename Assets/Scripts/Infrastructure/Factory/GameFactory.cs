using Assets.Scripts.Infrastructure.AssetManagment;

namespace Assets.Scripts.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;

        public GameFactory(IAssetProvider assetProvider) => _assetProvider = assetProvider;

        public void CreateHUD()
        {
            _assetProvider.Instantiate(AssetPath.HudPath);
        }
    }
}