using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int value = 10;
    public AudioClip collectSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collected!");
            // Add score
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddScore(value);
            }

            // Play sound
            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, Camera.main.transform.position, 1f);
            }

            Destroy(gameObject);
        }
    }
}