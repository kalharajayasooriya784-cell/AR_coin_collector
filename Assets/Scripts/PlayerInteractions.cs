using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public float fallLimitY = -10f;     // fall below this = respawn[cite: 5]

    private Vector3 startPosition;
    private Rigidbody2D rb;

    void Start()
    {
        startPosition = transform.position;     // remember where we started[cite: 5]
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (transform.position.y < fallLimitY)
        {
            Respawn();
        }
    }

    // TRIGGER = something we pass THROUGH (coins, goal, etc.)
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            GameManager.instance.AddCoin();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Goal"))
        {
            GameManager.instance.LevelComplete();
        }
        else if (other.CompareTag("Spike"))
        {
            Respawn();
        }
    }

    // COLLISION = something SOLID we bump into (spikes)[cite: 5]
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hazard") || collision.gameObject.CompareTag("Hazard"))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        transform.position = startPosition;     //[cite: 5]
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;   // stop all movement[cite: 5]
        }
    }
}