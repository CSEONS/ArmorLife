using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMove : MonoBehaviour
{
    public Transform door;
    private Vector3 startPos;
    public Vector3 offset;
    public float step;

    private void Start()
    {
        startPos = door.position;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {

        door.position = Vector3.Lerp(startPos, startPos + offset, step) * Time.deltaTime;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
