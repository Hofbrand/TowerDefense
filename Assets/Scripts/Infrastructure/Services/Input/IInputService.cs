using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.Input
{
    public interface IInputService : IService
    {
        Vector3 Axis { get; }

        Vector3 AxisR { get; }

        bool IsAttackButtonUp();
    }
}
