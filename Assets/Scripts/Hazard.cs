using UnityEngine;

public class Hazard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            KillPlayer(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            KillPlayer(collision.gameObject);
        }
    }

    private void KillPlayer(GameObject playerObject)
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.GameOver();
        }

        // Hide player visually but keep object alive if needed, or destroy it
        // For simple setup, destroying it
        Destroy(playerObject);
    }
}
