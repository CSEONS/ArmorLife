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
        _Enemy.ClearTarget();
        ClearParent(_Enemy.transform);
    }

    public override void Exit()
    {

    }

    public override void Run()
    {
        if (_stunned.StunValue > 0)
        {
            _stunned.StunValue -= Time.deltaTime;
            return;
        }

        _Enemy.SwitchEnemyState<EnemyDeathState>();
    }

    public void ClearParent(Transform entity)
    {
        entity.transform.parent = null;
    }
}