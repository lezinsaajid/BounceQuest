using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour
{
    public AudioClip goalSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(HandleGoal());
        }
    }

    IEnumerator HandleGoal()
    {
        // Play goal sound
        if (goalSound != null)
        {
            AudioSource.PlayClipAtPoint(goalSound, Camera.main.transform.position);
        }

        // Wait so sound can play
        yield return new WaitForSeconds(1f);

        // Load next level
        if (GameManager.Instance != null)
        {
            GameManager.Instance.LoadNextLevel();
        }
    }
}