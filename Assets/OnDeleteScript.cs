using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDeleteScript : MonoBehaviour
{
    AIDestinationSetter ai;

    private void Start()
    {
        ai = GetComponent<AIDestinationSetter>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ai.target = GameObject.FindObjectOfType<Player>().transform;
        }
    }
}


