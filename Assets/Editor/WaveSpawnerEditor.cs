using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WaveSpawner))]
public class WaveSpawnerEditor : Editor
{
    [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
    public static void RenderCustomGizmo(WaveSpawner waveSpawner, GizmoType gizmo)
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(waveSpawner.transform.position, 1f);
    }
}
