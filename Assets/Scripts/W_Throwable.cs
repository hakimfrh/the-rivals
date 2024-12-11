using UnityEngine;

public class W_Throwable : MonoBehaviour
{

    public float speed;
    public float rotationSpeed;
    public float damage;
    public float colldown;
    public AudioClip sfxThrow;
    public AudioClip sfxHit;
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
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().hit(damage);
            other.gameObject.GetComponent<PlayerController>().playSfx(sfxHit);
        }
        Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
