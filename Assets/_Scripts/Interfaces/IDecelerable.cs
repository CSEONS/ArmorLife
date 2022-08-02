public interface IDecelerable
{
    public float DecelerateTime { get; set; }
    void Decelerate(float DecelerateMultiple);
}
