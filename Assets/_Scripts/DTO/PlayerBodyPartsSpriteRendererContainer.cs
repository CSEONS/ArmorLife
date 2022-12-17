using System;
using UnityEngine;

public class PlayerBodyPartsSpriteRendererContainer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _head;
    [SerializeField] private SpriteRenderer _body;
    [SerializeField] private SpriteRenderer _shoulder_left;
    [SerializeField] private SpriteRenderer _shoulder_right;
    [SerializeField] private SpriteRenderer _forearm_left;
    [SerializeField] private SpriteRenderer _forearm_right;
    [SerializeField] private SpriteRenderer _wrist_left;
    [SerializeField] private SpriteRenderer _wrist_right;
    [SerializeField] private SpriteRenderer _foot;

    internal void Change(Skin skin)
    {
        _head.sprite = skin.Head;
        _body.sprite = skin.Body;
        _shoulder_left.sprite = skin.Shoulder_left;
        _shoulder_right.sprite = skin.Shoulder_right;
        _forearm_left.sprite = skin.Forearm_left;
        _forearm_right.sprite = skin.Forearm_right;
        _wrist_left.sprite = skin.Wrist_left;
        _wrist_right.sprite = skin.Wrist_right;

    }
}