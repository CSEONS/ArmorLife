using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Sicker : Enemy, IStunned, ICling
{
    [SerializeField] private float _clingTimePerSecond;
    [SerializeField] private float _stunResist;
    public float stunResist { get; set; }
    public float stunDuration { get; set; }
    public float stunValue { get; set; }
    public float acceptedStun { get; set; }
    public float ClingTimePerSecond { get; set; }
    public bool isStuned { get; set; }

    private void Start()
    {
        _states = new List<EnemyBaseState>
        {
            new EnemyFindTargetState(this, this),
            new EnemyChaseState(this, this),
            new EnemyBeforeStunState(this, this, this),
            new EnemyClingToTargetState(this, this, this),
            new EnemyDeathState(this, this),
            new EnemyStunState(this, this, this)
        };

        ClingTimePerSecond = _clingTimePerSecond;
        stunResist = _stunResist;

        _currentState = _states.FirstOrDefault();
        _currentState.Enter();
    }

    private void Update()
    {
        _currentState.Run();
    }

    public void Stun(float value)
    {
        if (isStuned)
            return;

        stunValue += value;
        SwitchEnemyState<EnemyBeforeStunState>();
    }
}
