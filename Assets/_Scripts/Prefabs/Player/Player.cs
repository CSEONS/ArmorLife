using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour, IPlayerStateSwicther
{
    protected PlayerBaseState _CurrentState;
    protected List<PlayerBaseState> _States;
    //protected List<Effects> _Effects;


    [SerializeField] protected float _MoveSpeed;
    [SerializeField] protected float _SpreentMultiple;
    [SerializeField] protected float _PunchAtackDistance;
    [SerializeField] protected float _KickAtackDistance;
    [SerializeField] protected float _Damage;
    [SerializeField] protected float _StunningForce;
    [SerializeField] protected float _KickForce;

    protected readonly float _BaseSpeed;

    [SerializeField] private Transform _atackOriginPoint;

    public Animator _Animator;
    public Rigidbody2D RigidBody2D;
    public bool Sprinted;

    private Vector2 _mooveDirection;

    public float PunchAtackDistance => _PunchAtackDistance;
    public float KickAtackDistance => _KickAtackDistance;
    public float StunningForce => _StunningForce;
    public float Damage => _Damage;
    public float MoveSpeed => _MoveSpeed;
    public float SpreentMultiple => _SpreentMultiple;
    public float KickForce => _KickForce;
    public Transform AtackOriginPoint => _atackOriginPoint;
    public Vector2 MoveDirection => _mooveDirection;

    
    public enum Animations
    {
        Punch,
        PunchAlt,
        Kick,
        Idle,
        Run
    }


    public void Move(Vector2 direction)
    {
        _mooveDirection = direction;
        _CurrentState.Move(direction);
    }

    public void TurnToCamera()
    {
        _CurrentState.TurnToCamera();
    }

    public void Kick()
    {
        _CurrentState.Kick(_atackOriginPoint);
    }

    public virtual void Punch()
    {
        _CurrentState.Punch(_atackOriginPoint);
    }

    public virtual void UseAbility()
    {
        _CurrentState.UseAbility();
    }

    public void ChangeSpeed(float value)
    {
        _MoveSpeed = value;
    }

    public void ResetSpeed()
    {
        _MoveSpeed = _BaseSpeed;
    }

    public void SwitchState<T>() where T : PlayerBaseState
    {
        var switchedState = _States.FirstOrDefault(x => x is T);
        _CurrentState.Exit();
        switchedState.Enter();
        _CurrentState = switchedState;
    }
}
