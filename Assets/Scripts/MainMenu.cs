using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Load the first level (assuming Level1 is index 1)
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game"); // This works in Editor
        Application.Quit();     // Works in build
    }
}