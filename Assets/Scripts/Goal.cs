using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Reached goal, load next level
            if (GameManager.Instance != null)
            {
                GameManager.Instance.LoadNextLevel();
            }
        }
    }
}
