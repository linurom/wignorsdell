using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    public WorldGenerate WG;
    public GameObject generateNewWaveButton;
    public TMP_Text waveCount;
    public TMP_Text enemysCount;

    private void Start()
    {
        UpdateValues();
    }

    private void Update()
    {
        enemysCount.text = "Enemys: " + (GenerateEnemys.enemysCount).ToString();
    }

    private void OnEnable()
    {
        EventBus.OnWaveEnd += OnWaveEnded;
        EventBus.OnWaveStart += UpdateValues;
    }

    private void OnDisable()
    {
        EventBus.OnWaveEnd -= OnWaveEnded;
        EventBus.OnWaveStart -= UpdateValues;
    }

    private void OnWaveEnded()
    {
        generateNewWaveButton.SetActive(true);
    }

    public void StartNewWave()
    {
        EventBus.OnWaveStart?.Invoke();
        SwitchActive(generateNewWaveButton);
    }

    private void SwitchActive(GameObject obj)
    {
        if(obj.activeInHierarchy == false)
        {
            obj.SetActive(true);
        }
        else
        {
            obj.SetActive(false);
        }
    }

    private void UpdateValues()
    {
        waveCount.text = "Wave: " + WG.enemysGenerator.waveCount.ToString();
    }

}
