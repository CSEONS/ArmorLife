public interface IPlayerStateSwicther
{
    public void SwitchState<T>() where T : PlayerBaseState;
}