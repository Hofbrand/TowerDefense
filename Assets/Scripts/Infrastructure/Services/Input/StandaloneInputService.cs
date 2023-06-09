using System;
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

        public override Vector3 AxisR
        {
            get
            {
                Vector3 axis = SimpleInputAxisR();

                if (axis == Vector3.zero)
                    axis = UnityAxisR();

                return axis;
            }
        }

        private Vector3 UnityAxisR()
        {
            return new Vector3(UnityEngine.Input.GetAxis(AxisR1), 0, UnityEngine.Input.GetAxis(AxisR2));
        }

        private static Vector3 UnityAxis()
        {
            return new Vector3(UnityEngine.Input.GetAxis(Axis1), 0,UnityEngine.Input.GetAxis(Axis2));
        }
    }
}
