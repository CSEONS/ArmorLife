using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float Step = 0.9f;
    public Transform Target;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Target.position + Vector3.back * 10, Step);
    }
}
