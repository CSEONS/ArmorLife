using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnyAI : MonoBehaviour
{
    public Transform target;
    public bool haveTarget;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        target = collision.gameObject.transform;
    }

    private void FixedUpdate()
    {
        agent.SetDestination(target.position);
        agent.transform.position = new Vector3(agent.transform.position.x, agent.transform.position.y, -5);
    }

}
