using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowWatter : MonoBehaviour
{
    public float slowmo;
    private float currentSpeed;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentSpeed = collision.GetComponent<PlayerMover_1>().speed;
        collision.GetComponent<PlayerMover_1>().speed /= slowmo;
            
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<PlayerMover_1>().speed = currentSpeed;
    }
}
