using UnityEngine;

public class EnemyFindTargetState : EnemyBaseState
{
    public EnemyFindTargetState(Enemy enemy, IEnemyStateSwitcher stateSwitcher) : base(enemy, stateSwitcher) { }

    private void FindTarget(Transform sicker)
    {
        var allEntitysInDetectionZone = DetectAllInRadius(_enemy);

        foreach (var entiy in allEntitysInDetectionZone)
        {
            if (entiy.TryGetComponent<Player>(out Player player))
            {
                _enemy.SetCurrenTarget(player.transform);
                _enemy.SwitchEnemyState<EnemyChaseState>();
                return;
            }
        }
    }

    private Collider2D[] DetectAllInRadius(Enemy enemy)
    {
        var allInRadius = Physics2D.OverlapCircleAll(_enemy.transform.position, _enemy.DetectionZoneDistance);
        return allInRadius;
    }

    public override void Run()
    {
        FindTarget(_enemy.transform);
    }

    public override void Enter()
    {

    }

    public override void Exit()
    {

    }
}