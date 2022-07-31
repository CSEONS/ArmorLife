using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    public PlayerWalkState(Player player, Animator animator) : base(player, animator)
    {
    }

    public override void Move(Vector2 direction)
    {
        base.Move(direction.normalized);

        if (direction.magnitude != 0 && _Player.Sprinted)
        {
            _Player.SwitchState<PlayerRunState>();  
        }

        if (direction.magnitude == 0)
        {
            _Player.SwitchState<PlayerIdleState>();
        }
    }
}