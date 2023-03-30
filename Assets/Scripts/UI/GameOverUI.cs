using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{

    public TMP_Text survivedText;

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void Awake()
    {
        survivedText.text = "Survived: " + DataHolder.wave.ToString() + " waves";
        var saveData = new GameData(DataHolder.wave);
        SavesSystem.SaveGame(saveData);
        Debug.Log("Saved");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
