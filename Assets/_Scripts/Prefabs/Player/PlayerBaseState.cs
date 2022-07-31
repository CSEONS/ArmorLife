using UnityEngine;

public abstract class PlayerBaseState
{
    protected Player _Player;
    protected Animator _Animator;

    public PlayerBaseState(Player player, Animator animator)
    {
        _Player = player;
        _Animator = animator;
    }

    public virtual void Move(Vector2 direction)
    {
        _Player.RigidBody2D.MovePosition(_Player.RigidBody2D.position + direction * _Player.MoveSpeed * Time.deltaTime);
    }

    public virtual void TurnToCamera()
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Vector2.Angle(Vector2.up, position - _Player.transform.position);
        _Player.transform.eulerAngles = new Vector3(0f, 0f, _Player.transform.position.x < position.x ? -angle : angle);
    }

    public virtual void Punch(Transform atackOriginPoint)
    {
        var allInAffectedArea = Physics2D.OverlapCircleAll(atackOriginPoint.position, _Player.PunchAtackDistance);

        var atackAlt = Random.Range(0, 2) > 0 ? true : false;

        if (atackAlt)
        {
            _Player._Animator.Play(nameof(Player.Animations.PunchAlt));
        }
        else
        {
            _Player._Animator.Play(nameof(Player.Animations.Punch));
        }


        foreach(var entity in allInAffectedArea)
        {
            if (entity.TryGetComponent<IDamagable>(out IDamagable damaged))
            {
                damaged.ApplyDamage(_Player.Damage);
            }
        }
    }

    public void Kick(Transform _atackOriginPoint)
    {
        var allInKickZone = Physics2D.OverlapCircleAll(_Player.AtackOriginPoint.position, _Player.KickAtackDistance);

        foreach (var kicked in allInKickZone)
        {
            if (kicked.TryGetComponent<IStunned>(out IStunned stunned))
            {
                stunned.Stun(_Player.StunningForce);
                var kickedDirection = (Vector2)(kicked.transform.position - _Player.AtackOriginPoint.position);
                Repulsion(kicked, kickedDirection * _Player.KickForce);
            }
        }

        _Animator.Play(nameof(Player.Animations.Kick));
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