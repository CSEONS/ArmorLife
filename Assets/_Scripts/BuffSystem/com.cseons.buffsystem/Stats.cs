using System;
using UnityEngine;

[Serializable]
public struct Stats
{
    public float Health;
    public float Stamina;
    public float Speed;
    public float SpreentMultiple;

    public Stats(Stats stats)
    {
        Health = stats.Health;
        Stamina = stats.Stamina;
        Speed = stats.Speed;
        SpreentMultiple = stats.SpreentMultiple;
    }

    public static Stats operator +(Stats firstStats, Stats secondStats)
    {
        return new Stats()
        {
            Health = firstStats.Health + secondStats.Health,
            Stamina = firstStats.Stamina + secondStats.Stamina,
            Speed = firstStats.Speed + secondStats.Speed,
            SpreentMultiple = firstStats.SpreentMultiple + secondStats.SpreentMultiple
        };
    }

    public static Stats operator *(Stats firstStats, Stats secondStats)
    {
        return new Stats()
        {
            Health = firstStats.Health * secondStats.Health,
            Stamina = firstStats.Stamina * secondStats.Stamina,
            Speed = firstStats.Speed * secondStats.Speed,
            SpreentMultiple = secondStats.SpreentMultiple * secondStats.SpreentMultiple
        };
    }

    public static Stats operator -(Stats firstStats, Stats secondStats)
    {
        return new Stats()
        {
            Health = firstStats.Health - secondStats.Health,
            Stamina = firstStats.Stamina - secondStats.Stamina,
            Speed = firstStats.Speed - secondStats.Speed,
            SpreentMultiple = firstStats.SpreentMultiple - secondStats.SpreentMultiple
        };
    }

    public override string ToString()
    {
        return $"{nameof(Health)}: {Health}\n" +
               $"{nameof(Stamina)}: {Stamina}\n" +
               $"{nameof(Speed)}: {Speed}\n" +
               $"{nameof(SpreentMultiple)}: {SpreentMultiple}";
    }
}