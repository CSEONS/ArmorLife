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
        


        _soldire.TurnToMouse();
    }
}
