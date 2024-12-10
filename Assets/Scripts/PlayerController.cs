using NUnit.Framework;
using Unity.VisualScripting;
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
    public GameObject weapon;

    //audio jumpnya
    public AudioClip jumpSound;
    public AudioClip attacksound;

    private Rigidbody2D player;
    private bool isGrounded = false;
    private float currentSpeed;
    private float targetSpeed = 0f;
    private float lastAttackTime = 0f;
    private bool isFacingRight = true;
    private AudioSource audioSource;

    private Animator Anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        audioSource = GetComponentInChildren<AudioSource>();
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
            if (isFacingRight)
            {
                transform.Rotate(new Vector3(0, 180, 0));
            }
            isFacingRight = false;
        }
        else if (Input.GetKey(Right))
        {
            targetSpeed = moveSpeed;
            if (!isFacingRight)
            {
                transform.Rotate(new Vector3(0, -180, 0));
            }
            isFacingRight = true;
        }
        else
        {
            targetSpeed = 0;
        }
        if (Input.GetKeyDown(Jump) && isGrounded)
        {
            player.linearVelocity = new Vector2(player.linearVelocity.x, jumpForce);
            if (jumpSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(jumpSound);
            }
        }

        if (Input.GetKeyDown(Shoot))
        {
            if (!weapon.IsUnityNull())
            {
                W_Throwable weaponScript = weapon.GetComponent<W_Throwable>();
                if (Time.time > lastAttackTime + weaponScript.colldown)
                {
                    audioSource.PlayOneShot(attacksound);
                    Instantiate(weapon, new Vector3(transform.position.x + (isFacingRight ? 1f : -1f), transform.position.y), transform.rotation);
                    lastAttackTime = Time.time;
                }
            }
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
        Anim.SetFloat("Speed", Mathf.Abs(currentSpeed));
        Anim.SetBool("Grounded", isGrounded);
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
