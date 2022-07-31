using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class DrawPlayerGizmos : MonoBehaviour
{
    [SerializeField]
    private Player _player;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_player.AtackOriginPoint.position, _player.PunchAtackDistance);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(_player.AtackOriginPoint.position, _player.KickAtackDistance);
    }
}
