using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.Input
{
    public abstract class InputService : IInputService
    {
        protected const string Axis1 = "Horizontal";
        protected const string Axis2 = "Vertical";
        protected const string AxisR1 = "RHorizontal";
        protected const string AxisR2 = "RVertical";
        protected const string Button = "Fire";

        public abstract Vector3 Axis { get; }

        public abstract Vector3 AxisR { get; }

        public static Vector3 SimpleInputAxis()
        {
            return new Vector3(SimpleInput.GetAxis(Axis1), 0,SimpleInput.GetAxis(Axis2));
        }

        public static Vector3 SimpleInputAxisR()
        {
            return new Vector3(SimpleInput.GetAxis(AxisR1), 0, SimpleInput.GetAxis(AxisR2));
        }

        public bool IsAttackButtonUp() => SimpleInput.GetButtonUp(Button);
    }
}
