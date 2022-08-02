

using System;
using UnityEngine;

public class EnemyClingToTargetState : EnemyBaseState
{
    private ICling _cling;
    public EnemyClingToTargetState(Enemy enemy, IEnemyStateSwitcher stateSwitcher, ICling cling) : base(enemy, stateSwitcher)
    {
        _cling = cling;
    }

    public override void Enter()
    {
        _Enemy.transform.SetParent(_Enemy.GetCurrentTarget);
        _Enemy.ClearTarget();
        _Enemy.EnableAIPath(false);
    }

    

    public override void Exit()
    {
        _Enemy.EnableAIPath(true);
        ClearParrent();
    }

    public override void Run()
    {
        if (_cling.ClingTimePerSecond <= 0)
        {
            _Enemy.SwitchEnemyState<EnemyDeathState>();
        }

        _cling.ClingTimePerSecond -= Time.deltaTime;
    }

    private void ClearParrent()
    {
        _Enemy.transform.parent = null;
    }
}