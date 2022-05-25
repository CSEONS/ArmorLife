using UnityEngine;


public abstract class Player : MonoBehaviour, IDamagable, IDecelerable
{
    public float Health {get; set;}
    public States state = States.Idle;

    public enum States
    {
        Idle,
        Walk,
        Run,
        Kick
    }

    public void ApplyDamage(float damage)
    {
        Health -= damage;
    }

    public void Move(Vector2 direction)
    {

    }

    public void TurnToMouse()
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Vector2.Angle(Vector2.up, position - transform.position);
        transform.eulerAngles = new Vector3(0f, 0f, transform.position.x < position.x ? -angle : angle);
    }

    public abstract void UseAbility();
}