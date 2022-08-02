using UnityEngine;

public interface IStunned
{
    public float StunResist { get; set; }
    public float StunValue { get; set; }
    public float AcceptedStun { get; set; }
    public float StunDuration { get; set; }
    public bool IsStuned { get; set; }
    public void Stun();
}