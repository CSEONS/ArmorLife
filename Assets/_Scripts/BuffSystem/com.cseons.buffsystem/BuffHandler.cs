using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class BuffHandler : IBuffAccept
{
    private List<BaseBuff> _buffs = new List<BaseBuff>();

    public void Accept(BaseBuff buff)
    {
        _buffs.Add(buff);
    }

    public void Handle(IBuffed buffed)
    {
        if (_buffs.Count <= 0)
            return;

        List<BaseBuff> expiredBuffs = new List<BaseBuff>();

        foreach (BaseBuff buff in _buffs)
        {

            if (buff.IsFinished)
            {
                expiredBuffs.Add(buff);
            }    
            buff.Tick(buffed);
        }

        _buffs.RemoveAll(x => expiredBuffs.Exists(y => y == x));
        expiredBuffs.Clear();
    }
}