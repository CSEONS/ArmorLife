using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour, IPlayerStateSwicther
{
    protected PlayerBaseState _currentState;
    protected List<PlayerBaseState> _states;

    [SerializeField] protected float _MoveSpeed;
    [SerializeField] protected float _SpreentMultiple;
    [SerializeField] protected float _PunchAtackDistance;
    [SerializeField] protected float _KickAtackDistance;
    [SerializeField] protected float _Damage;
    [SerializeField] protected float _StunningForce;
    [SerializeField] protected float _KickForce;

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
        _currentState.Move(direction);
    }

    public void TurnToCamera()
    {
        _currentState.TurnToCamera();
    }

    public void Kick()
    {
        _currentState.Kick(_atackOriginPoint);
    }

    public virtual void Punch()
    {
        _currentState.Punch(_atackOriginPoint);
    }

    public virtual void UseAbility()
    {
        _currentState.UseAbility();
    }

    public void SwitchState<T>() where T : PlayerBaseState
    {
        var switchedState = _states.FirstOrDefault(x => x is T);
        _currentState.Exit();
        switchedState.Enter();
        _currentState = switchedState;
    }
}
