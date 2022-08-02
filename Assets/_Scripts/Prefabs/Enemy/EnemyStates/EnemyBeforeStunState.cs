using UnityEngine;

public class EnemyBeforeStunState : EnemyBaseState
{
    private IStunned _stunned;

    public EnemyBeforeStunState(Enemy enemy, IEnemyStateSwitcher stateSwitcher, IStunned stunned) : base(enemy, stateSwitcher) 
    {
        _stunned = stunned;
    }

    public override void Enter()
    {
        _Enemy.ClearTarget();
    }

    public override void Exit()
    {
        
    }

    public override void Run()
    {
        if (_stunned.StunValue > _stunned.StunResist)
        {
            _stunned.IsStuned = true;
            _Enemy.SwitchEnemyState<EnemyStunState>();
            return;
        }

        _Enemy.SwitchEnemyState<EnemyFindTargetState>();
    }
}