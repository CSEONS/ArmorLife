using UnityEngine;

public class EnemyStunState : EnemyBaseState
{
    private IStunned _stunned;
    public EnemyStunState(Enemy enemy, IEnemyStateSwitcher stateSwitcher, IStunned stunned) : base(enemy, stateSwitcher)
    {
        _stunned = stunned;
    }

    public override void Enter()
    {
        _enemy.ClearTarget();
        _enemy.ClearParent();
    }

    public override void Exit()
    {

    }

    public override void Run()
    {
        if (_stunned.stunValue > 0)
        {
            _stunned.stunValue -= Time.deltaTime;
            return;
        }

        _enemy.SwitchEnemyState<EnemyDeathState>();
    }
}