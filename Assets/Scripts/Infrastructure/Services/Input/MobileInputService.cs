using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.Input
{
    public class MobileInputService : InputService
    {
        public override Vector3 Axis => SimpleInputAxis();
    }
}
