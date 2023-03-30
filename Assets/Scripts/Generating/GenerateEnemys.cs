using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemys : MonoBehaviour
{
    public BasePlayer player;
    public GameObject[] spawnPoints;
    public BaseEnemy[] enemysType;
    public bool isStopped;
    public float minSpawnTime;
    public float maxSpawnTime;
    public int wavesBeforeBoss;
    public int waveCount = 1;
    public static int enemysCount;

    public void Start()
    {
        OnGenerationStarted();
    }

    private void OnEnable()
    {
        EventBus.OnWaveStart += OnGenerationStarted;
    }

    private void OnDisable()
    {
        EventBus.OnWaveStart -= OnGenerationStarted;
    }



    public IEnumerator SpawnEnemys()
    {

        while (true)
        {
            EventBus.OnWaveGenerate?.Invoke();
            if (wavesBeforeBoss != 0)
            {
                if (waveCount % wavesBeforeBoss == 0)
                {
                    BossFight();
                    isStopped = true;
                    StopCoroutine(SpawnEnemys());
                }
            }
 
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                if(player.power <= 0)
                {
                    OnGenerationEnded();
                }
                var enemy = Instantiate(enemysType[UnityEngine.Random.Range(0, enemysType.Length)], spawnPoints[i].transform.position, Quaternion.identity);
                enemysCount++;
                EventBus.OnEnemyGenerated?.Invoke(enemy.power);
                spawnPoints[i].gameObject.transform.DetachChildren();
                yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnTime, maxSpawnTime));
            }
        }
    }

    public void OnGenerationStarted()
    {
        player.ResetPlayerPower();
        waveCount++;
        StartCoroutine("SpawnEnemys");
    }


    public void OnGenerationEnded()
    {
        EventBus.OnWaveEnd?.Invoke();
        StopCoroutine("SpawnEnemys");
    }

    public void StartGeneratingEnemys()
    {
        if (isStopped)
        {
            isStopped = false;
            StartCoroutine(SpawnEnemys());
        }
    }

    public void BossFight()
    {

    }

}
