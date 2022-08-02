using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator Animator;
    public AnimationClip Open;
    public AnimationClip Close;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Animator.SetBool("isOpen", true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Animator.SetBool("isOpen", false);
    }
}
