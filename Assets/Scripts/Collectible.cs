using UnityEngine;

public class Collectible : MonoBehaviour
{
    [Header("Settings")]
    public int scoreValue = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Add score and destroy ring
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddScore(scoreValue);
            }
            
            // Optional: Play a sound or particle effect here
            
            Destroy(gameObject);
        }
    }
}
