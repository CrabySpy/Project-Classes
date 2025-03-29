using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayManager : MonoBehaviour
{
    [SerializeField] 
    private Transform respawnPoint;
    public GameObject[] Characters; // Prefab list of characters
    private const string SELECTED_CHARACTER_INDEX = "SelectedCharacterIndex";

    void Start()
    {
        int selectedCharIndex = PlayerPrefs.GetInt(SELECTED_CHARACTER_INDEX, 0);

    
        GameObject playerObj = Instantiate(Characters[selectedCharIndex], respawnPoint.position, Quaternion.identity);

        
        CameraFollow camFollow = Camera.main.GetComponent<CameraFollow>();
        if (camFollow != null && playerObj != null)
        {
            camFollow.SetPlayer(playerObj.transform);
        }


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {  
            BackToMainMenu();
        }
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
