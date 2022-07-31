using UnityEngine;

public abstract class EnemyBaseState
{
    protected readonly Enemy _enemy;
    protected readonly IEnemyStateSwitcher _stateSwitcher;

    public EnemyBaseState(Enemy enemy, IEnemyStateSwitcher stateSwitcher)
    {
        _enemy = enemy;
        _stateSwitcher = stateSwitcher;
    }

    public abstract void Enter();

    public abstract void Run();

    public abstract void Exit();
}