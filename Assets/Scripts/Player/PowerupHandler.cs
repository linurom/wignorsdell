using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupHandler : MonoBehaviour
{
    private void OnEnable()
    {
        EventBus.OnPowerupTaked += HandlePowerup;
    }

    private void OnDisable()
    {
        EventBus.OnPowerupTaked -= HandlePowerup;
    }

    private void HandlePowerup(float time, bool hasTimer, GameObject gObj)
    {
        if (hasTimer) 
        {
            StartCoroutine(Timer(time, gObj));
        }
        else
        {
            Destroy(gObj);
        }
    }

    public IEnumerator Timer(float time, GameObject gObj)
    {
        gObj.SetActive(false);
        for (float i = time; i > 0; i--)
        {
            yield return new WaitForSeconds(1);
        }
        gObj.SetActive(true);
        EventBus.OnPowerupEffectEnded?.Invoke();
        Destroy(gObj);
    }
}
