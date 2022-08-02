using UnityEngine;

public abstract class EnemyBaseState
{
    protected readonly Enemy _Enemy;
    protected readonly IEnemyStateSwitcher _StateSwitcher;

    public EnemyBaseState(Enemy enemy, IEnemyStateSwitcher stateSwitcher)
    {
        _Enemy = enemy;
        _StateSwitcher = stateSwitcher;
    }

    public abstract void Enter();

    public abstract void Run();

    public abstract void Exit();
}