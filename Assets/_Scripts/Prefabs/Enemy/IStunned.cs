using UnityEngine;

public interface IStunned
{
    public float stunResist { get; set; }
    public float stunValue { get; set; }
    public float acceptedStun { get; set; }
    public float stunDuration { get; set; }
    public bool isStuned { get; set; }
    public void Stun(float value);
}