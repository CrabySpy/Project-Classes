using UnityEngine;
using UnityEngine.SceneManagement;

public class EndFlag : MonoBehaviour
{
    public GameObject victoryScreen; // Drag VictoryScreen here in Inspector

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            victoryScreen.SetActive(true);
            Time.timeScale = 0f; // Pause game
        }
    }

    // Button click method
    public void ReturnToMenu()
    {
        Time.timeScale = 1f; // Unpause
        SceneManager.LoadScene("MainMenu");
    }
}