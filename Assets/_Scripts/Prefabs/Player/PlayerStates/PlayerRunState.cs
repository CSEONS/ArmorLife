using UnityEngine;

public class PlayerRunState : PlayerBaseState
{
    public PlayerRunState(Player player, Animator animator) : base(player, animator)
    {
    }

    public override void Move(Vector2 direction)
    {
        if (_Player.Sprinted)
        {
            base.Move(direction.normalized * _Player.SpreentMultiple);
        }
        else
        {
            _Player.SwitchState<PlayerWalkState>();
        }
    }
}