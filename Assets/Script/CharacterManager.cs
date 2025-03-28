using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class CharacterManager : MonoBehaviour
{
    public SpriteRenderer sr;
    public List<GameObject> Characters = new List<GameObject>();
    private int selectedChar = 0;
    private string SELECTED_CHARACTER_INDEX = "SelectedCharacterIndex";

    public void NextOption()
    {
        selectedChar += 1;

        if (selectedChar == Characters.Count)
        {
            selectedChar = 0;
        }

        UpdateCharacterPreview();
    }

    public void BackOption()
    {
        selectedChar -= 1;

        if (selectedChar < 0)
        {
            selectedChar = Characters.Count - 1;
        }

        UpdateCharacterPreview();
    }

    private void UpdateCharacterPreview()
    {
        
        sr.sprite = Characters[selectedChar].GetComponent<SpriteRenderer>().sprite;
    }

    public void PlayGame()
    {
        PlayerPrefs.SetInt(SELECTED_CHARACTER_INDEX, selectedChar);
        PlayerPrefs.Save();
        SceneManager.LoadScene("GamePlay");
    }
}
