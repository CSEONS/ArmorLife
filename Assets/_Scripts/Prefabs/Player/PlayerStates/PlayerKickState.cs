using UnityEngine;

public class PlayerKickState : PlayerBaseState
{
    public PlayerKickState(Player player, Animator animator, Weapon weapon, Rigidbody2D rigidbody, PlayerAnimations playerAnimations) : base(player, animator, weapon, rigidbody, playerAnimations)
    {
    }

    public override void Move(Vector2 direction)
    {
        var currentAnimation = _Animator.GetCurrentAnimatorStateInfo(0);

        if (currentAnimation.IsName(_PlayerAnimations.Kick.name))
            return;

        _Player.SwitchState<PlayerIdleState>();
    }
}