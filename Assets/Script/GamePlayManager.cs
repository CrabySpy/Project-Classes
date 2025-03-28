using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    [SerializeField] 
    private Transform respawnPoint;
    public GameObject[] Characters; // Prefab list of characters
    private const string SELECTED_CHARACTER_INDEX = "SelectedCharacterIndex";

    void Start()
    {
        int selectedCharIndex = PlayerPrefs.GetInt(SELECTED_CHARACTER_INDEX, 0);

        // ✅ Instantiate the selected character
        GameObject playerObj = Instantiate(Characters[selectedCharIndex], respawnPoint.position, Quaternion.identity);

        // ✅ Assign the player to the camera after instantiation
        CameraFollow camFollow = Camera.main.GetComponent<CameraFollow>();
        if (camFollow != null && playerObj != null)
        {
            camFollow.SetPlayer(playerObj.transform);
        }
    }
}
