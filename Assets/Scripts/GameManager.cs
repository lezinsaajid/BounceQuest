using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI Elements")]
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;
    public TextMeshProUGUI restartHintText;

    [Header("Audio")]
    public AudioClip gameOverSound;

    private int score = 0;
    private bool isGameOver = false;

    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        UpdateScoreText();
    }

    void Update()
    {
        // Restart Level Input (R)
        if (Input.GetKeyDown(KeyCode.R) && isGameOver)
        {
            RestartLevel();
        }
    }

    public void AddScore(int amount)
    {
        if (isGameOver) return;

        score += amount;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;

        // Play Game Over sound
        if (gameOverSound != null)
        {
            AudioSource.PlayClipAtPoint(gameOverSound, Camera.main.transform.position);
        }

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        if (restartHintText != null)
            restartHintText.gameObject.SetActive(true);

        // Stop the player
        PlayerController player = FindFirstObjectByType<PlayerController>();

        if (player != null)
        {
            player.enabled = false;
            player.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("Game Finished! Returning to Main Menu.");
            SceneManager.LoadScene(0);
        }
    }
}