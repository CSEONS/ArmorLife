using System;
using UnityEngine;

public abstract class BaseBuff : ScriptableObject, ICloneable
{
    public Stats Multiplied;
    public Stats Added;
    public float Duration;
    protected float PassedTime;

    public bool IsFinished { get; protected set; } = false;

    private void OnEnable()
    {
        IsFinished = false;
    }

    public object Clone()
    {
        return MemberwiseClone();
    }

    public abstract void Execute(IBuffed buffed);
    public abstract void Tick(IBuffed buffed);
}