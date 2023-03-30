using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class MainMenuUI : MonoBehaviour
{
    public GameObject[] Menus;
    public TMP_Text highscore;
    public TMP_Text coins;

    private void Awake()
    {
        UpdateValues();
    }

    private void UpdateValues()
    {
        GameData data = SavesSystem.LoadGame();
        highscore.text = "Your previous score: " + data.highScore.ToString();
        coins.text = "Coins: " + data.coins.ToString();
    }

    public void MenuSwitch(GameObject menu)
    {
        for(int I = 0; I < Menus.Length; I++) 
        {
            Menus[I].SetActive(false);
        }
        menu.SetActive(true);
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
