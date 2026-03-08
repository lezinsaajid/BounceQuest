using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

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
    private Vector3 checkpointPosition;
    private PlayerController currentPlayer;
    private bool hasCheckpoint = false;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        currentPlayer = FindFirstObjectByType<PlayerController>();

        if (currentPlayer != null)
            checkpointPosition = currentPlayer.transform.position;

        UpdateScoreText();
    }

    public void SetCheckpoint(Vector3 newCheckpoint)
    {
        checkpointPosition = newCheckpoint;
        hasCheckpoint = true;
    }

    void Update()
    {
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

        // Play sound
        if (gameOverSound != null)
        {
            AudioSource.PlayClipAtPoint(gameOverSound, Camera.main.transform.position);
        }

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        if (restartHintText != null)
            restartHintText.gameObject.SetActive(!hasCheckpoint);

        if (currentPlayer != null)
        {
            currentPlayer.enabled = false;
            currentPlayer.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            
            SpriteRenderer sr = currentPlayer.GetComponent<SpriteRenderer>();
            if (sr != null)
                sr.enabled = false;
        }

        if (hasCheckpoint)
        {
            StartCoroutine(RespawnPlayer());
        }
    }

    IEnumerator RespawnPlayer(){
    yield return new WaitForSeconds(1.5f);

    if (currentPlayer != null)
    {
        Rigidbody2D rb = currentPlayer.GetComponent<Rigidbody2D>();
        SpriteRenderer sr = currentPlayer.GetComponent<SpriteRenderer>();

        // Move player slightly above checkpoint
        currentPlayer.transform.position = checkpointPosition + Vector3.up * 1.5f;

        // Reset physics
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;

        // Re-enable player
        currentPlayer.enabled = true;
        Debug.Log("Player respawned at " + checkpointPosition);
        // Make sure the sprite is visible
        if (sr != null)
            sr.enabled = true;

        // Reset scale just in case
        currentPlayer.transform.localScale = Vector3.one;
    }

    if (gameOverPanel != null)
        gameOverPanel.SetActive(false);

    isGameOver = false;
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