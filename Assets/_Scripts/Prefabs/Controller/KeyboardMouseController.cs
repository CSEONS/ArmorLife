using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMouseController : MonoBehaviour
{
    public Player Player;
    public float MoveDeathZoneRadius;

    private void Start()
    {
        Player = GameObject.FindObjectOfType<Player>();
    }

    private void FixedUpdate()
    {
        Vector2 direction = new Vector2();

        direction += Input.GetKey(KeyCode.A) ? Vector2.left : Vector2.zero;

        direction += Input.GetKey(KeyCode.D) ? Vector2.right: Vector2.zero;

        direction += Input.GetKey(KeyCode.W) ? Vector2.up : Vector2.zero;

        direction += Input.GetKey(KeyCode.S) ? Vector2.down: Vector2.zero;

        Player.Move(direction);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            Player.Kick();

        if (Input.GetKeyDown(KeyCode.B))
            Player.UseAbility();

        if (Input.GetMouseButton(0))
            Player.Atack();

        Player.Sprinted = Input.GetKey(KeyCode.LeftShift);

        TurnToCamera();
    }

    public virtual void TurnToCamera()
    {
        if (Player.CurrentState == typeof(PlayerKickState))
            return;

        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Vector2.Angle(Vector2.up, position - Player.transform.position);
        Player.transform.eulerAngles = new Vector3(0f, 0f, Player.transform.position.x < position.x ? -angle : angle);
    }
}
