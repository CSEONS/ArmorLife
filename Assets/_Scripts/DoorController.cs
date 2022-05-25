using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator animator;
    public AnimationClip open;
    public AnimationClip close;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetBool("isOpen", true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetBool("isOpen", false);
    }
}
