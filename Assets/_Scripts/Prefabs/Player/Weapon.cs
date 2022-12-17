using System;
using UnityEngine;

[Serializable]
public class Weapon
{
    [SerializeField] protected int _Ammo;
    [SerializeField] protected float _Cooldown;
    public virtual void Atack() { }
}