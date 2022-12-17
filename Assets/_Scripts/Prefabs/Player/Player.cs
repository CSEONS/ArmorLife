using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerBodyPartsSpriteRendererContainer))]
public class Player : MonoBehaviour, IPlayerStateSwicther
{
    public float KickAtackDistance => _kickAtackDistance;
    public float KickForce => _kickForce;
    public Transform AtackOriginPoint => _foot;
    public Type CurrentState => _currentState.GetType();

    [HideInInspector] public bool Sprinted;

    public Stats Stats;

    [SerializeField] private float _kickAtackDistance;
    [SerializeField] private float _kickForce;
    [SerializeField] private Transform _foot;
    [SerializeField] private Skin _skin;
    [SerializeField] private List<Weapon> _weapons;

    private PlayerBaseState _currentState;
    private List<PlayerBaseState> _States;
    private PlayerBodyPartsSpriteRendererContainer _bodySpriteRendererContainer;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private PlayerAnimations _playerAnimations;
    private Weapon _currentWeapon;

    public enum Animations
    {
        Punch,
        PunchAlt,
        Kick,
        Idle,
        Run
    }

    private void Start()
    {
        _bodySpriteRendererContainer = GetComponent<PlayerBodyPartsSpriteRendererContainer>();
        _playerAnimations = GetComponent<PlayerAnimations>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        _bodySpriteRendererContainer.Change(_skin);


        _States = new List<PlayerBaseState>
        {
            new PlayerIdleState(this, _animator, _currentWeapon, _rigidbody2D, _playerAnimations),
            new PlayerWalkState(this, _animator, _currentWeapon, _rigidbody2D, _playerAnimations),
            new PlayerRunState(this, _animator, _currentWeapon, _rigidbody2D, _playerAnimations),
            new PlayerKickState(this, _animator, _currentWeapon, _rigidbody2D, _playerAnimations)
            
        };

        _currentState = _States.FirstOrDefault();
        _currentState.Enter();
        //_currentWeapon = _weapons.First();
    }

    private void Update()
    {
        Debug.Log(_currentState);
    }

    public void Atack()
    {
        _currentState.Atack();
    }

    public void Move(Vector2 direction)
    {
        _currentState.Move(direction);
    }

    public void Kick()
    {
        _currentState.Kick(AtackOriginPoint);
    }

    public virtual void UseAbility()
    {
        _currentState.UseAbility();
    }

    public void SwitchState<T>() where T : PlayerBaseState
    {
        var switchedState = _States.FirstOrDefault(x => x is T);

        if (switchedState is null)
            throw new NotImplementedException($"The instance {nameof(T)} is missing. in {nameof(_States)}");

        _currentState.Exit();
        switchedState.Enter();
        _currentState = switchedState;
    }

    public void ChangeSkin()
    {

    }
}
