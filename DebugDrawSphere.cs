using UnityEngine;

public class DebugDrawSphere : MonoBehaviour
{
    void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.5f);
    }
}