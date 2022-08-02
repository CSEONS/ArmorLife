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
        _Enemy.SetAIPathDestinationSetterTarget(_Enemy.GetCurrentTarget);
    }

    public override void Exit()
    {

    }

    public override void Run()
    {
        if(_Enemy.EndReachedDistance >= (Vector3.Distance(_Enemy.transform.position, _Enemy.GetCurrentTarget.position)))
        {
            _Enemy.SwitchEnemyState<EnemyClingToTargetState>();
        }
    }
}