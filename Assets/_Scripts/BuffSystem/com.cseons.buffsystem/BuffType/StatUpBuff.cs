using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "StatUpBuff")]
public class StatUpBuff : BaseBuff
{
    private bool isNotExecute = true;
    public override void Execute(IBuffed buffed)
    {
        buffed.BaseStats += (buffed.InitStats * Multiplied) + Added;
    }

    public override void Tick(IBuffed buffed)
    {
        PassedTime += Time.deltaTime;

        if (isNotExecute)
        {
            Execute(buffed);
            isNotExecute = false;
        }

        if (PassedTime > Duration)
        {
            PassedTime = 0;
            buffed.BaseStats -= ((buffed.InitStats * Multiplied) + Added);
            IsFinished = true;
        }
    }
}