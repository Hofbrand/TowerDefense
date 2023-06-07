using UnityEngine;

namespace Assets.Scripts.EnemyLogic
{
    public class PhysicsDebug
    {
        public static void DrawDebug(Vector3 worldPos, float radius, float seconds)
        {
            //draw rays in each direction
            UnityEngine.Debug.DrawRay(worldPos, Vector3.up * radius, UnityEngine.Color.red, seconds);
            UnityEngine.Debug.DrawRay(worldPos, Vector3.down * radius, UnityEngine.Color.red, seconds);
            UnityEngine.Debug.DrawRay(worldPos, Vector3.left * radius, UnityEngine.Color.red, seconds);
            UnityEngine.Debug.DrawRay(worldPos, Vector3.right * radius, UnityEngine.Color.red, seconds);
            UnityEngine.Debug.DrawRay(worldPos, Vector3.back * radius, UnityEngine.Color.red, seconds);
            UnityEngine.Debug.DrawRay(worldPos, Vector3.fwd * radius, UnityEngine.Color.red, seconds);
        }
    }
}
