using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Soldier : Player
{
    private void Start()
    {
        _States = new List<PlayerBaseState>
        {
            new PlayerIdleState(this, this._Animator),
            new PlayerWalkState(this, this._Animator),
            new PlayerRunState(this, this._Animator),
        };

        _CurrentState = _States.FirstOrDefault();
        _CurrentState.Enter();
    }
}