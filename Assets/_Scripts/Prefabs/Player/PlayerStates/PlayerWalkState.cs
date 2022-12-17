using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    public PlayerWalkState(Player player, Animator animator, Weapon weapon, Rigidbody2D rigidbody2D, PlayerAnimations playerAnimations) : base(player, animator, weapon, rigidbody2D, playerAnimations)
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