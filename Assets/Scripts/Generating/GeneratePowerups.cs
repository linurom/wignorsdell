using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePowerups : MonoBehaviour
{
    //Random is always at the end!!!
    public GameObject[] powerups;

    public static int powerupsCount;
    public float minTimeBTWPowerupSpawn;
    public float maxTimeBTWPowerupSpawn;

    private void OnEnable()
    {
        StartCoroutine(StartGeneratingPowerups());
    }

    private void OnDisable()
    {
        StopCoroutine(StartGeneratingPowerups());
    }

    public IEnumerator StartGeneratingPowerups()
    {
        powerupsCount = powerups.Length;
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTimeBTWPowerupSpawn, maxTimeBTWPowerupSpawn));
            EventBus.OnPowerupGenerated?.Invoke(powerups[Random.Range(0, powerups.Length)]);
        }
    }
}
