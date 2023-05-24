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

        public void Instantiate(string path, Transform at)
        {
            var prefab = Resources.Load<GameObject>(path);
            Object.Instantiate(prefab, at.position, Quaternion.identity);
        }
    }
}