using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowWatter : MonoBehaviour
{
    public float slowmo;
    private float currentSpeed;

    private Dictionary<int, IDecelerable> _currentSlowObjects;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IDecelerable>(out IDecelerable decelerating))
        {
            decelerating.Decelerate();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IDecelerable>(out IDecelerable decelerating))
        {
            decelerating.RemoveDeceleration();
        }
    }
}
