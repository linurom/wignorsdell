using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageIncreasePowerup : BasePowerups
{
    private float[] previousDamage;
    public override void Effect()
    {
        for (int i = 0; i < player.weapons.Length; i++)
        {
            previousDamage[i] = player.weapons[i].damage;
            player.weapons[i].damage *= 2;
        }
    }
    public override void AntiEffect()
    {
        for (int i = 0; i < player.weapons.Length; i++)
        {
            player.weapons[i].damage = previousDamage[i];
        }
    }
}
