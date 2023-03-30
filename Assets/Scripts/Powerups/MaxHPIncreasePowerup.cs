using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHPIncreasePowerup : BasePowerups
{
    private float previousHealth;
    public override void Effect()
    {
        previousHealth = player.maxHealth;
        player.maxHealth *= 1.75f;
        player.health = player.maxHealth;
    }
    public override void AntiEffect()
    {
        player.maxHealth = previousHealth;
        player.health = previousHealth;
    }
}
