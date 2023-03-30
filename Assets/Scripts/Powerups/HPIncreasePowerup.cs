using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPIncreasePowerup : BasePowerups
{
    public override void Effect()
    {
        player.maxHealth = Mathf.Clamp(player.health += player.maxHealth * 0.25f, 0, player.maxHealth);
    }
}
