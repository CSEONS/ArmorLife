using Pathfinding;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour, IEnemyStateSwitcher
{
    public void Awake()
    {
        _AIPath.endReachedDistance = AtackDistance;
    }

    public float EndReachedDistance => _AIPath.endReachedDistance;
    public bool HaveTarget => _currentFoundTarget != null;
    public Transform GetCurrentTarget => _currentFoundTarget;

    protected EnemyBaseState _CurrentState;
    protected List<EnemyBaseState> _States;

    [SerializeField] protected AIDestinationSetter _AIDestionationSetter;
    [SerializeField] protected AIPath _AIPath;

    [SerializeField] public float DetectionZoneDistance;
    [SerializeField] public float AtackDistance;

    private Transform _currentFoundTarget;


    protected void SetStates(EnemyBaseState state)
    {
        _CurrentState = state;
    }

    public void SetCurrenTarget(Transform target)
    {
        _currentFoundTarget = target;
    }

    public void SetAIPathDestinationSetterTarget(Transform target)
    {
        _AIDestionationSetter.target = _currentFoundTarget;
    }

    public void SwitchEnemyState<T>() where T : EnemyBaseState
    {
        var switchedState = _States.FirstOrDefault(a => a is T);

        if (switchedState is null)
            throw new NotImplementedException($"Missing states in List \"_states\"");

        _CurrentState.Exit();
        switchedState.Enter();
        _CurrentState = switchedState;
    }

    public void EnableAIPath(bool value)
    {
        _AIPath.enabled = value;
    }

    public void ClearTarget()
    {
        _AIDestionationSetter.target = null;
    }
}
