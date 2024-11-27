using UnityEngine;

public class EnemyCollisionHandler : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with another enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Make them pass through each other by temporarily disabling physics response
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>(), true);

            // Optionally: Apply custom logic here (e.g., adjust position, bounce off, etc.)
            Vector2 direction = (transform.position - collision.transform.position).normalized;
            rb.AddForce(direction * 0.5f, ForceMode2D.Impulse);

            // Re-enable collision after a short delay
            StartCoroutine(ReenableCollision(collision.collider));
        }
    }

    private System.Collections.IEnumerator ReenableCollision(Collider2D collider)
    {
        yield return new WaitForSeconds(0.5f); // Wait 0.5 seconds
        Physics2D.IgnoreCollision(collider, GetComponent<Collider2D>(), false);
    }
}


