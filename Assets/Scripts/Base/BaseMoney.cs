using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMoney : MonoBehaviour
{
    private static int coins;
    private static int gems;
    public static int scoreMultiplyer;


    public static void AddCoins(int amount)
    {
        coins += amount * scoreMultiplyer;
    }

    public static void AddGems(int amount)
    {
        gems += amount;
    }

    public static void RemoveCoins(int amount) 
    {
        coins -= amount;
    }

    public static void RemoveGems(int amount)
    {
        gems -= amount;
    }

    public static int GetCoins() 
    {
        return coins;
    }

    public static int GetGems()
    {
        return gems;
    }

    public override string ToString()
    {
        return $"coins: {coins}, Gems: {gems}";
    }
}
