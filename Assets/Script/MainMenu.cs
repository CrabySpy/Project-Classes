using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // This function will be called when the Play button is clicked
    public void PlayGame()
    {
        SceneManager.LoadScene("GamePlay");
    }
}