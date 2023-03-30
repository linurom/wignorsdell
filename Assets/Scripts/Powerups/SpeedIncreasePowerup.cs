using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedIncreasePowerup : BasePowerups
{
    private float previousSpeed;
    public override void Effect()
    {
        previousSpeed = player.speed;
        player.speed *= 1.5f;
    }
    public override void AntiEffect()
    {
        player.speed = previousSpeed;
    }
}
