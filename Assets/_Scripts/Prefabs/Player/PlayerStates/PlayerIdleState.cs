using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(Player player, Animator animator, Weapon weapon, Rigidbody2D rigidbody, PlayerAnimations playerAnimations) : base(player, animator, weapon, rigidbody, playerAnimations)
    {
    }

    public override void Move(Vector2 direction)
    {
        if (direction.magnitude != 0)
        {
            _Player.SwitchState<PlayerWalkState>();
        }
    }

    public override void Enter()
    {

    }

    public override void Exit()
    {

    }
}