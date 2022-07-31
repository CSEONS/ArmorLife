using Pathfinding;
using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    private float _atackDistance;

    public EnemyChaseState(Enemy enemy, IEnemyStateSwitcher stateSwitcher) : base(enemy, stateSwitcher)
    {
        _atackDistance = enemy.AtackDistance;
    }

    public override void Enter()
    {
        Debug.Log(this);
        _enemy.SetAIPathDestinationSetterTarget(_enemy.GetCurrentTarget);
    }

    public override void Exit()
    {

    }

    public override void Run()
    {
        if(_enemy.EndReachedDistance >= (Vector3.Distance(_enemy.transform.position, _enemy.GetCurrentTarget.position)))
        {
            _enemy.SwitchEnemyState<EnemyClingToTargetState>();
        }
    }
}