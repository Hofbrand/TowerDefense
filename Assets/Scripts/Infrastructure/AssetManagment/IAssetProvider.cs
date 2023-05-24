using Assets.Scripts.Infrastructure.Services;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.AssetManagment
{
    public interface IAssetProvider : IService
    {
        void Instantiate(string path);

        void Instantiate(string path, Transform at);
    }
}