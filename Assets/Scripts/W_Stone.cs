using UnityEngine;

public class W_Stone : MonoBehaviour
{

    public float speed;
    public GameObject hitEffect;
    private Rigidbody2D Rbody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Rbody.linearVelocity = new Vector2(speed*(transform.rotation.y!=0?-1f:1f) , 0);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Border")){
            Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if(other.gameObject.CompareTag("Ground")){
            Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if(other.gameObject.CompareTag("Player")){
            Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
