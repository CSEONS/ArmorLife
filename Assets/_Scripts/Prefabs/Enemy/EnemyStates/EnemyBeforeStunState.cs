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
        
    }

    public override void Exit()
    {
        
    }

    public override void Run()
    {
        if (_stunned.stunValue > _stunned.stunResist)
        {
            _stunned.isStuned = true;
            _enemy.SwitchEnemyState<EnemyStunState>();
            return;
        }

        _enemy.SwitchEnemyState<EnemyFindTargetState>();
    }
}