using UnityEngine;

public class W_Throwable : MonoBehaviour
{

    public float speed;
    public float rotationSpeed;
    public float damage;
    public float colldown;
    public GameObject hitEffect;
    private Rigidbody2D Rbody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rbody = GetComponent<Rigidbody2D>();
        Rbody.AddTorque(rotationSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        Rbody.linearVelocity = new Vector2(speed * (transform.rotation.y != 0 ? -1f : 1f), 0);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player1")
        {
            FindAnyObjectByType<GameManager>().hitPlayer1(damage);
        }
        if (other.gameObject.name == "Player2")
        {
            FindAnyObjectByType<GameManager>().hitPlayer2(damage);
        }
        Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
