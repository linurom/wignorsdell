using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KillAllEnemysPowerup : BasePowerups
{
    public override void Effect()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = targets.Length; i <= 0; i--)
        {
            Destroy(targets[i]);
        }
    }

}
