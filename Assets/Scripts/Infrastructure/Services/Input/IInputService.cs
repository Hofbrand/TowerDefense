using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.Input
{
    public interface IInputService : IService
    {
        Vector3 Axis { get; }

        bool IsAttackButtonUp();
    }
}
