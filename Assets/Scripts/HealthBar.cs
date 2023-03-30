using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider healthBar;
    private BasePlayer player;

    private void OnEnable()
    {
        EventBus.OnPlayerTackesDamage += SetHealth;
    }

    private void OnDisable()
    {
        EventBus.OnPlayerTackesDamage -= SetHealth;
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<BasePlayer>();
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = player.maxHealth;
        healthBar.value = player.maxHealth;
    }

    public void SetHealth(float hp)
    {
        healthBar.maxValue = player.maxHealth;
        healthBar.value = hp;
    }
}
