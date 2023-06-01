using UnityEngine;

namespace Assets.Scripts.Infrastructure.CameraLogic
{
    public class FPSCameraController : MonoBehaviour
    {
        public float RotationAngleX;
        public float Distance;
        public float Offset;

        private Transform _following;

        private void LateUpdate()
        {
            if (_following == null) { return; }

            Vector3 followingPointPosition = FollowingPointPosition();

            Quaternion rotation = Quaternion.Euler(RotationAngleX, 0, 0);
            Vector3 offset = rotation * new Vector3(0, 0, -Distance);

            transform.position = followingPointPosition + offset;
            transform.rotation = Quaternion.LookRotation(transform.forward, Vector3.up);
        }

        public void Follow(GameObject following)
        {
            _following = following.transform;
        }

        private Vector3 FollowingPointPosition()
        {
            Vector3 followingPosition = _following.position;
            followingPosition.y += Offset;

            return followingPosition;
        }
    }
}