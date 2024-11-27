using UnityEngine;

public class PlayerBounce : MonoBehaviour
{
    public float bounceForce = 10f; // Adjust this to set the bounce strength

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player collides with an enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Get collision normal
            ContactPoint2D contact = collision.contacts[0];
            if (contact.normal.y > 0.5f) // Check if hitting from above
            {
                Bounce();
            }
        }
    }

    private void Bounce()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, bounceForce); // Apply upward force
    }
}

