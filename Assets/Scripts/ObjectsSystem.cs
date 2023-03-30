using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectsSystem : MonoBehaviour
{
    public static List<GameObject> powerups;
    public static List<GameObject> enemies;

    public static void Instantiate(GameObject obj, string tag)
    {
        switch (tag) 
        {
            case "Enemy":
                enemies.Add(Instantiate(obj));
                break;
            case "Powerup":
                powerups.Add(Instantiate(obj));
                break;
        }
    }

    public static void Destroy(GameObject obj, string tag) 
    {
        switch (tag)
        {
            case "Enemy":
                enemies.Add(Instantiate(obj));
                break;
            case "Powerup":
                powerups.Add(Instantiate(obj));
                break;
        }
    }
}
