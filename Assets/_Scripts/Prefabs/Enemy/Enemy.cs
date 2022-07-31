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
        _aiPath.endReachedDistance = AtackDistance;
    }

    public float EndReachedDistance => _aiPath.endReachedDistance;

    

    public bool haveTarget => _currentFoundTarget != null;
    public Transform GetCurrentTarget => _currentFoundTarget;

    protected EnemyBaseState _currentState;
    protected List<EnemyBaseState> _states;

    [SerializeField]
    protected AIDestinationSetter _aiDestionationSetter;
    [SerializeField]
    protected AIPath _aiPath;


    private Transform _currentFoundTarget;


    [SerializeField]
    public float DetectionZoneDistance;
    [SerializeField]
    public float AtackDistance;

    

    protected void SetStates(EnemyBaseState state)
    {
        _currentState = state;
    }

    public void SetCurrenTarget(Transform target)
    {
        _currentFoundTarget = target;
    }

    public void SetAIPathDestinationSetterTarget(Transform target)
    {
        _aiDestionationSetter.target = _currentFoundTarget;
    }

    public void SwitchEnemyState<T>() where T : EnemyBaseState
    {
        var switchedState = _states.FirstOrDefault(a => a is T);

        if (switchedState is null)
            throw new NotImplementedException($"Missing states in List \"_states\"");

        _currentState.Exit();
        switchedState.Enter();
        _currentState = switchedState;
    }

    public void EnableAIPath(bool value)
    {
        _aiPath.enabled = value;
    }

    public void ClearParent()
    {
        transform.parent = null;
    }

    public void ClearTarget()
    {
        _aiDestionationSetter.target = null;
    }
}
