

using System;
using UnityEngine;

public class EnemyClingToTargetState : EnemyBaseState
{
    private Collider2D[] _allColider;
    private ICling _cling;
    public EnemyClingToTargetState(Enemy enemy, IEnemyStateSwitcher stateSwitcher, ICling cling) : base(enemy, stateSwitcher)
    {
        _cling = cling;
    }

    public override void Enter()
    {
        Debug.Log(this);
        _enemy.transform.SetParent(_enemy.GetCurrentTarget);
        _enemy.ClearTarget();
        _enemy.EnableAIPath(false);
    }

    

    public override void Exit()
    {
        _enemy.EnableAIPath(true);
        ClearParrent();
    }

    public override void Run()
    {
        if (_cling.ClingTimePerSecond <= 0)
        {
            _enemy.SwitchEnemyState<EnemyDeathState>();
        }

        _cling.ClingTimePerSecond -= Time.deltaTime;
    }

    private void ClearParrent()
    {
        _enemy.transform.parent = null;
    }
}