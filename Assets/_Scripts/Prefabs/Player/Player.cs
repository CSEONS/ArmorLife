using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Player : MonoBehaviour, IDamagable, IDecelerable
{
    [SerializeField]
    private float _maxHealth;
    public float Health {get; set;}
    public States state = States.Idle;

    [SerializeField]
    private float _maxSpeed;

    protected Transform _footPosition;
    protected Transform _leftHand;
    protected Transform _rightHand;

    protected Rigidbody2D _rb;
    protected Animator _animator;

    LayerMask _layerMaskEnemy;

    [SerializeField]
    private float _kickRadius;
    [SerializeField]
    private float _kickDistance;


    public enum States
    {
        Idle,
        Walk,
        Run,
        Kick,
    }

    public enum Childs
    {
        Foot
    }

    public enum Animations
    {
        Idle,
        Walk,
        Run,
        Kick,
        Punch,
        PunchAlt
    }

    enum BodyParts
    {
        Foot,
        LeftHand,
        RightHand,
    }

    public void Init()
    {
        state = States.Idle;
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        _footPosition = transform.Find(nameof(BodyParts.Foot));
        _leftHand = transform.Find(nameof(BodyParts.LeftHand));
        _rightHand = transform.Find(nameof(BodyParts.RightHand));
        _rb.gravityScale = 0;
        Health = _maxHealth;
    }

    public void ApplyDamage(float damage)
    {
        Health -= damage;
    }

    public void Move(Vector2 direction)
    {
        _rb.MovePosition(_rb.position + direction * _maxSpeed * Time.deltaTime);
    }

    public void Punch()
    {
        int nextPunch = Random.Range(0, 1);
        
        switch (nextPunch)
        {
            case 0: 
                _animator.SetTrigger(nameof(Animations.Punch));
                break;

            case 1:
                _animator.SetTrigger(nameof(Animations.PunchAlt));
                break;

            default:
                break;
        }
    }

    public void TurnToMouse()
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Vector2.Angle(Vector2.up, position - transform.position);
        transform.eulerAngles = new Vector3(0f, 0f, transform.position.x < position.x ? -angle : angle);
    }

    public abstract void UseAbility();

    public void KickStart()
    {
        if (state == States.Kick)
            return;
        state = States.Kick;
        _animator.Play(nameof(Animations.Kick));
    }

    public void KickStay()
    {
        RaycastHit2D[] hit = Physics2D.CircleCastAll(_footPosition.position, _kickRadius, transform.up, _kickDistance, _layerMaskEnemy);

        foreach (var enemy in hit)
        {
            if (enemy.transform.TryGetComponent<IEnemy>(out IEnemy currentEnemy))
            {
                currentEnemy.Stun();
                print("Enemy kicked");
            }
        }
        print("Kick cast end");
    }

    private void KickEnd()
    {
        state = States.Idle;
    }

    private void KickCast()
    {
        
    }
}