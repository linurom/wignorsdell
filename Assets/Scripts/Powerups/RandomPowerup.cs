using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPowerup : BasePowerups
{
    private int value;

    public override void Effect()
    {
        value = Random.Range(0, GeneratePowerups.powerupsCount - 1);

        switch (value)
        {
            case 1:
                break;
            case 0:
                break;
        }
    }
}
