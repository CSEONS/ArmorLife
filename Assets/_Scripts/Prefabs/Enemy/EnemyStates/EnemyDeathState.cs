using UnityEngine;

public class EnemyDeathState : EnemyBaseState
{
    public EnemyDeathState(Enemy enemy, IEnemyStateSwitcher stateSwitcher) : base(enemy, stateSwitcher)
    {
    }

    public override void Enter()
    {
        _Enemy.GetComponent<Ruin>().RuinChilds();
    }

    public override void Exit()
    {
        
    }

    public override void Run()
    {
        
    }
}