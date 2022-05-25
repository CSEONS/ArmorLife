using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float step = 0.9f;

    public Transform target;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + Vector3.back * 10, step);
    }
}
