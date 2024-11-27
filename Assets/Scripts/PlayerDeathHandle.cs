using UnityEngine;
using UnityEngine.SceneManagement; // To reload the scene

public class PlayerDeathHandler : MonoBehaviour
{
    // Tag for the enemy objects
    [SerializeField] private string enemyTag = "Enemy";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has the "Enemy" tag
        if (collision.gameObject.CompareTag(enemyTag))
        {
            DieAndRestart();
        }
    }

    private void DieAndRestart()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

