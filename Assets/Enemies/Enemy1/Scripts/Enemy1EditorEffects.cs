using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy1))]
public class Enemy1EditorEffects : MonoBehaviour
{
    [SerializeField] [Range(-10f, 10f)] private float sphereCentreYOffset = 1f;
    [SerializeField] private Enemy1 enemy;

    private void OnDrawGizmos()
    {
        DrawEnemyRadiusInFormOfSphere(enemy.EnemyRadius, Color.red, sphereCentreYOffset);
    }

    private void DrawEnemyRadiusInFormOfSphere(float radius, Color color)
    {
        Gizmos.color = color;
        Gizmos.DrawWireSphere(this.transform.position, radius);
    }

    private void DrawEnemyRadiusInFormOfSphere(float radius, Color color, float yOffset)
    {
        Gizmos.color = color;
        Gizmos.DrawWireSphere(new Vector3
            (this.transform.position.x, this.transform.position.y + yOffset, this.transform.position.z), radius);
    }
}
