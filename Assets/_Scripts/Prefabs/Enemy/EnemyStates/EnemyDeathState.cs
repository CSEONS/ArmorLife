using UnityEngine;

public class EnemyDeathState : EnemyBaseState
{
    public EnemyDeathState(Enemy enemy, IEnemyStateSwitcher stateSwitcher) : base(enemy, stateSwitcher)
    {
    }

    public override void Enter()
    {
        _enemy.gameObject.SetActive(false);
        Debug.LogWarning("Not implement!");
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }

    public override void Run()
    {
        throw new System.NotImplementedException();
    }
}