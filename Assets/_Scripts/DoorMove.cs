using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMove : MonoBehaviour
{
    public Transform Door;
    private Vector3 _startPos;
    public Vector3 Offset;
    public float Step;

    private void Start()
    {
        _startPos = Door.position;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {

        Door.position = Vector3.Lerp(_startPos, _startPos + Offset, Step) * Time.deltaTime;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
