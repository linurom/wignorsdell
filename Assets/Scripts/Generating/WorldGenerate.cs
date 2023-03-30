using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldGenerate : MonoBehaviour
{
    public GeneratePowerups powerupsGenerator;
    [SerializeField] private GameObject staticObjects;
    public GenerateEnemys enemysGenerator;
    [SerializeField] private GameObject[] grass;
    [SerializeField] private GameObject[] decorations;
    [SerializeField] private GameObject[] store;
    [SerializeField] private GameObject wall;
    [SerializeField] private int minX;
    [SerializeField] private int maxX;
    [SerializeField] private int minY;
    [SerializeField] private int maxY;
    [SerializeField] private int indentX;
    [SerializeField] private int indentY;
    [SerializeField] private int minDecorationsIndent;
    [SerializeField] private int maxDecorationsIndent;

    private void Start()
    {
        StartGenerate();
    }

    public void OnEnable()
    {
        EventBus.OnPowerupGenerated += GeneratePowerup;
        EventBus.OnPlayerDestroyed += OnPlayerDestroyed;
    }

    public void OnDisable()
    {
        EventBus.OnPowerupGenerated -= GeneratePowerup;
        EventBus.OnPlayerDestroyed -= OnPlayerDestroyed;
    }

    private void OnPlayerDestroyed()
    {
        DataHolder.wave = enemysGenerator.waveCount;
        SceneManager.LoadScene("GameOverScene");
    }

    public void GeneratePowerup(GameObject obj)
    {
            Instantiate(obj, 
                new Vector2(Random.Range(minX + 10, maxX - 10), 
                Random.Range(minY + 10, maxY - 10)), Quaternion.identity);
    }

    public void StartGenerate()
    {
        enemysGenerator.gameObject.transform.localScale = new Vector3(maxX, maxY, 0);
        GenerateGrass();
        GenerateDecorations();
        GenerateWall();
    }

    public void GenerateStore()
    {
        Instantiate(store[0], new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)), Quaternion.identity);
    }

    public void GenerateWall()
    {
        //vertical wall
        for(int x = minX; x < maxX;)
        {
            x += 1;
            var obj = Instantiate(wall, new Vector2(x, maxY + 1), Quaternion.identity);
            var obj1 = Instantiate(wall, new Vector2(x, minY), Quaternion.identity);
            obj.transform.parent = staticObjects.transform;
            obj1.transform.parent = staticObjects.transform;
        }
        //horizontal wall
        for(float y = minY; y < maxY; y++)
        {
            y += 0.5f;
            var obj = Instantiate(wall, new Vector2(minX, y), Quaternion.identity);
            var obj1 = Instantiate(wall, new Vector2(maxX + 1, y), Quaternion.identity);
            obj.transform.parent = staticObjects.transform;
            obj1.transform.parent = staticObjects.transform; 
        }
    }

    public void GenerateGrass()
    {
        for(int x = minX + 1; x < maxX;)
        {
            for (int y = minY; y < maxY;)
            {
                y += Random.Range(1, indentY);
                var obj = Instantiate(grass[0], new Vector2(Random.Range(x, x + indentX), y), Quaternion.identity);
                obj.transform.parent = staticObjects.transform;
            }
            x += Random.Range(1, indentX);
        }
    }

    public void GenerateDecorations()
    {
        for (int x = minX + 20; x < maxX - 20;)
        {
            x += Random.Range(minDecorationsIndent, maxDecorationsIndent);
            for (int y = minY + 20; y < maxY - 30;)
            {
                x += Random.Range(-5, 6);
                y += Random.Range(minDecorationsIndent, maxDecorationsIndent - 3);
                var obj = Instantiate(decorations[Random.Range(0, decorations.Length)], new Vector2(Random.Range(x, x + indentX), y), Quaternion.identity);
                obj.transform.parent = staticObjects.transform;
            }
        }
    }
}
