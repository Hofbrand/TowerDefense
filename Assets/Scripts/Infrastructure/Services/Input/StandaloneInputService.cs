using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.Input
{
    public class StandaloneInputService : InputService
    {
        public override Vector3 Axis
        {
            get
            {
                Vector3 axis = SimpleInputAxis();

                if (axis == Vector3.zero)
                    axis = UnityAxis();

                return axis;
            }
        }

        private static Vector3 UnityAxis()
        {
            return new Vector3(UnityEngine.Input.GetAxis(Axis1), 0,UnityEngine.Input.GetAxis(Axis2));
        }
    }
}
