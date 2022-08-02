using UnityEngine;

public class EnemyFindTargetState : EnemyBaseState
{
    public EnemyFindTargetState(Enemy enemy, IEnemyStateSwitcher stateSwitcher) : base(enemy, stateSwitcher) { }

    private void FindTarget(Transform sicker)
    {
        var allEntitysInDetectionZone = DetectAllInRadius(_Enemy);

        foreach (var entiy in allEntitysInDetectionZone)
        {
            if (entiy.TryGetComponent<Player>(out Player player))
            {
                _Enemy.SetCurrenTarget(player.transform);
                _Enemy.SwitchEnemyState<EnemyChaseState>();
                return;
            }
        }
    }

    private Collider2D[] DetectAllInRadius(Enemy enemy)
    {
        var allInRadius = Physics2D.OverlapCircleAll(_Enemy.transform.position, _Enemy.DetectionZoneDistance);
        return allInRadius;
    }

    public override void Run()
    {
        FindTarget(_Enemy.transform);
    }

    public override void Enter()
    {

    }

    public override void Exit()
    {

    }
}