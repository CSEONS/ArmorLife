using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Ruin))]
public class Sicker : Enemy, IStunned, ICling
{
    [SerializeField] private float _clingTimePerSecond;
    [SerializeField] private float _stunResist;
    [SerializeField] private float _stunTimePreSecond;
    public float StunResist { get; set; }
    public float StunDuration { get; set; }
    public float StunValue { get; set; }
    public float AcceptedStun { get; set; }
    public float ClingTimePerSecond { get; set; }
    public bool IsStuned { get; set; }

    private void Start()
    {
        _States = new List<EnemyBaseState>
        {
            new EnemyFindTargetState(this, this),
            new EnemyChaseState(this, this),
            new EnemyBeforeStunState(this, this, this),
            new EnemyClingToTargetState(this, this, this),
            new EnemyDeathState(this, this),
            new EnemyStunState(this, this, this)
        };

        ClingTimePerSecond = _clingTimePerSecond;
        StunResist = _stunResist;

        _CurrentState = _States.FirstOrDefault();
        _CurrentState.Enter();
    }

    private void Update()
    {
        _CurrentState.Run();
    }

    public void Stun()
    {
        if (IsStuned)
            return;


        StunValue = _stunTimePreSecond;
        SwitchEnemyState<EnemyBeforeStunState>();
    }
}
