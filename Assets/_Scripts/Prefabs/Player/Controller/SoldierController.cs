using UnityEngine;

public class SoldierController: KeyboradController
{
    private Soldire _soldire;


    private void Start()
    {
        _soldire = GameObject.FindObjectOfType<Soldire>();
    }

    private void Update()
    {
        if(_soldire.state != Player.States.Kick)
        {
            _soldire.Move(GetInpuAxisFloat());
        }

        if (Input.GetKeyDown(Keys.Atack) && _soldire.state != Player.States.Kick && _soldire.state != Player.States.Punch)
        {
            _soldire.Punch();
        }

        if (Input.GetKey(Keys.Kick))
        {
            _soldire.KickCast();
        }

        
        _soldire.TurnToMouse();
    }
}
