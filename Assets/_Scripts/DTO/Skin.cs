using UnityEngine;

[CreateAssetMenu(fileName = "Skin", menuName = "Player/Skin")]
public class Skin : ScriptableObject
{
    public Sprite Head;
    public Sprite Body;
    public Sprite Shoulder_left;
    public Sprite Shoulder_right;
    public Sprite Forearm_left;
    public Sprite Forearm_right;
    public Sprite Wrist_left;
    public Sprite Wrist_right;
    public Sprite Foot;
}