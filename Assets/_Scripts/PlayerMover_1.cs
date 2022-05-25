using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class PlayerMover_1 : MonoBehaviour
{
    [SerializeField]
    public float speed;
    [SerializeField]
    private float cickCooldown;

    [Space]
    [SerializeField]
    private Sprite cickSprite;
    [SerializeField]
    private Sprite idleState;
    
    [Space]
    [SerializeField]
    private BoxCollider2D cickColider;
    private bool cickState;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;


    private Vector2 playerInput;
    private Vector2 movePosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        movePosition = rb.position;
        Camera.main.gameObject.AddComponent<CameraFollow>();
        Camera.main.gameObject.GetComponent<CameraFollow>().target = transform;
    }

    private void Update()
    {
        playerInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movePosition = rb.position + (playerInput * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Cick();
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(movePosition);
        SetPlayerRotation();
    }

    void SetPlayerRotation()
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Vector2.Angle(Vector2.up, position - transform.position);
        transform.eulerAngles = new Vector3(0f, 0f, transform.position.x < position.x ? -angle : angle);
    }

    void Cick()
    {
        if (!cickState)
        {
            StartCoroutine(Cicked());
        }
    }

    private IEnumerator Cicked()
    {
        cickState = true;
        spriteRenderer.sprite = cickSprite;
        cickColider.enabled = true;
        
        yield return new WaitForSeconds(cickCooldown);
        spriteRenderer.sprite = idleState;
        cickColider.enabled = false;
        cickState = false;
    }
}
