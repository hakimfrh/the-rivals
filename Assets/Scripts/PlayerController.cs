using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public float acceleration;
    public float deceleration;

    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Jump;
    public KeyCode Shoot;

    private Rigidbody2D player;
    private bool isGrounded = false;
    private float currentSpeed;
    private float targetSpeed = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(Left) && Input.GetKey(Right))
        {
            targetSpeed = 0;
        }
        else if (Input.GetKey(Left))
        {
            targetSpeed = -moveSpeed;
        }
        else if (Input.GetKey(Right))
        {
            targetSpeed = moveSpeed;
        }
        else
        {
            targetSpeed = 0;
        }

        if (Input.GetKeyDown(Jump) && isGrounded)
        {
            player.linearVelocity = new Vector2(player.linearVelocity.x, jumpForce);
        }
    }
    void FixedUpdate()
    {
        // Smoothly lerp kecepatan horizontal
        if (targetSpeed != 0)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, acceleration * Time.fixedDeltaTime);
        }
        else
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration * Time.fixedDeltaTime);
        }

        // Terapkan kecepatan pada Rigidbody
        player.linearVelocity = new Vector2(currentSpeed, player.linearVelocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
