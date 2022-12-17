using UnityEngine;

public abstract class PlayerBaseState
{
    protected Player _Player;
    protected Animator _Animator;
    protected Weapon _Weapon;
    protected Rigidbody2D _Rigidbody2D;
    protected PlayerAnimations _PlayerAnimations;

    public PlayerBaseState(Player player, Animator animator, Weapon weapon, Rigidbody2D rigidbody, PlayerAnimations playerAnimations)
    {
        _Player = player;
        _Animator = animator;
        _Weapon = weapon;
        _Rigidbody2D = rigidbody;
        _PlayerAnimations = playerAnimations;
    }

    public virtual void Atack()
    {
        _Weapon.Atack();
    }

    public virtual void Move(Vector2 direction)
    {
        _Rigidbody2D.MovePosition(_Rigidbody2D.position + direction * _Player.Stats.Speed * Time.deltaTime);
    }

    public void Kick(Transform _atackOriginPoint)
    {
        var allInKickZone = Physics2D.OverlapCircleAll(_Player.AtackOriginPoint.position, _Player.KickAtackDistance);

        foreach (var kicked in allInKickZone)
        {
            if (kicked.TryGetComponent<IStunned>(out IStunned stunned))
            {
                stunned.Stun();
                var kickedDirection = (Vector2)(kicked.transform.position - _Player.AtackOriginPoint.position);
                Repulsion(kicked, kickedDirection * _Player.KickForce);
            }
        }

        _Animator.Play(_PlayerAnimations.Kick.name);
        _Player.SwitchState<PlayerKickState>();
    }

    public virtual void UseAbility()
    {
        throw new System.NotImplementedException();
    }

    private void Repulsion(Collider2D colider, Vector2 direction)
    {
        colider.transform.position += (Vector3)direction;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void Empty() { }
}