using Pathfinding;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Ruin : MonoBehaviour
{
    [SerializeField] private float _scatterForce;
    [SerializeField] private float _torqueForce;
    [SerializeField] private float _linearDrag;
    [SerializeField] private float _angularDrag;

    public void RuinChilds()
    {
        var allChilds = GetAllChilds();

        StopParentAnimations(allChilds.FirstOrDefault().parent);
        AddRigidBody2D(allChilds);
        AddCircleColider2D(allChilds);
        DisableUnnecessuaryComponents(allChilds.FirstOrDefault().parent);
        Scatter(allChilds);
    }

    private Transform[] GetAllChilds()
    {
        var childCount = transform.childCount;
        Transform[] allChilds = new Transform[childCount];
        for (int i = 0; i < childCount; i++)
        {
            allChilds[i] = transform.GetChild(i);
        }

        return allChilds;
    }

    private void AddRigidBody2D(Transform[] transforms)
    {
        foreach (var item in transforms)
        {
            var rb = item.gameObject.AddComponent<Rigidbody2D>();
            rb.gravityScale = 0;
            rb.drag = _linearDrag;
            rb.angularDrag = _angularDrag;
        }
    }

    private void AddCircleColider2D(Transform[] transforms)
    {
        foreach (var item in transforms)
        {
            item.gameObject.AddComponent<CircleCollider2D>();
        }
    }

    private void Scatter(Transform[] transforms)
    {
        foreach (var item in transforms)
        {
            var rb = item.GetComponent<Rigidbody2D>();
            rb.AddRelativeForce(Extensions.GetRandomVector(new Vector2(_scatterForce, _scatterForce)), ForceMode2D.Impulse);
        }
    }

    private void StopParentAnimations(Transform parent)
    {
        parent.TryGetComponent<Animator>(out Animator animator);

        animator.enabled = false;
    }

    private void DisableUnnecessuaryComponents(Transform parent)
    {
            parent.GetComponent<AIPath>().enabled = false;
            parent.GetComponent<AIDestinationSetter>().enabled = false;
    }
}
