using UnityEngine;

[ExecuteInEditMode]
[RequireComponent (typeof(Enemy))]
public class DrawingEnemyGizmos : MonoBehaviour
{
    private Enemy _enemy;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(_enemy.transform.position, _enemy.DetectionZoneDistance);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_enemy.transform.position, _enemy.AtackDistance);
    }
}