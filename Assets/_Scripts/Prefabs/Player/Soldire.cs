using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Soldire : Player
{
    [SerializeField]
    private float _maxHealth;
    [SerializeField]
    private float _maxSpeed;

    private Rigidbody2D rb;

    private void Start()
    {
        Health = _maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    public override void UseAbility()
    {
        
    }

    
}
