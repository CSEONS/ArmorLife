using UnityEngine;

public class PlayerRunState : PlayerBaseState
{
    public PlayerRunState(Player player, Animator animator, Weapon weapon, Rigidbody2D rigidbody2D, PlayerAnimations playerAnimations) : base(player, animator, weapon, rigidbody2D, playerAnimations)
    {
    }

    public override void Move(Vector2 direction)
    {
        if (_Player.Sprinted)
        {
            base.Move(direction.normalized * _Player.Stats.SpreentMultiple);
        }
        else
        {
            _Player.SwitchState<PlayerWalkState>();
        }
    }
}