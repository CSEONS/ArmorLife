public interface IEnemyStateSwitcher
{
    void SwitchEnemyState<T>() where T : EnemyBaseState;
}