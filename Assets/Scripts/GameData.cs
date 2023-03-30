using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int highScore;
    public int coins;

    public GameData(int highScore)
    {
        this.highScore = highScore;
    }

    public void UpdateScore(int score)
    {
        highScore = score;
    }

    public void UpdateCoins(int coins)
    {
        this.coins = coins;
    }

    public void ResetData()
    {
        highScore = 0;
        coins = 0;
    }
}