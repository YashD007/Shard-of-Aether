using UnityEngine;

public class PlayerJump : MonoBehaviour
{
   public float bounceForce = 10f; // Force applied when bouncing off an enemy

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyHead"))
        {
            // Bounce the player upwards
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, bounceForce);

            // Optional: Trigger an animation or sound effect on the enemy
            Enemy enemy = collision.GetComponentInParent<Enemy>();
            if (enemy != null)
            {
                enemy.OnBounce(); // Call a method to handle visual feedback
            }
        }
    }    
}
