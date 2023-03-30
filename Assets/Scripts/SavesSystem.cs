using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavesSystem : MonoBehaviour
{

    public static void SaveGame(GameData data)
    {
        GameData previousData = LoadGame();
        PlayerPrefs.SetInt("highScore", data.highScore);
    }

    public static GameData LoadGame()
    {
        GameData data = new GameData(PlayerPrefs.GetInt("highScore"));
        return data;
    }

}
