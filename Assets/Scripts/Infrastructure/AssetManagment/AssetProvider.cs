using UnityEngine;

namespace Assets.Scripts.Infrastructure.AssetManagment
{
    public class AssetProvider : IAssetProvider
    {
        public void Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            Object.Instantiate(prefab);
        }
    }
}