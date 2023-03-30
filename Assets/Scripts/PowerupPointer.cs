using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class PowerupPointer : MonoBehaviour
{

    private static GameObject target;

    private void OnEnable()
    {
        EventBus.OnPowerupGenerated += FindTarget;
    }

    private void OnDisable()
    {
        EventBus.OnPowerupGenerated -= FindTarget;
    }

    public void FindTarget(GameObject obj)
    {
        target = obj;
        PointOnPowerup(target);
    }

    public void PointOnPowerup(GameObject Target)
    {
        gameObject.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x) * Mathf.Rad2Deg - 90);
    }
}
