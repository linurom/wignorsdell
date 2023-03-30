using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BasePowerups : MonoBehaviour
{
    protected BasePlayer player;
    public float time;
    public bool hasTimer;

    private void OnEnable()
    {
        EventBus.OnPowerupEffectEnded += AntiEffect;
    }

    private void OnDisable()
    {
        EventBus.OnPowerupEffectEnded -= AntiEffect;
    }

    private void Start()
    {
        try
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<BasePlayer>();
        }
        catch { }
    }

    public virtual void Effect() { }
    public virtual void AntiEffect() { }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Effect();
            EventBus.OnPowerupTaked?.Invoke(time, hasTimer, gameObject);
        }
    }
}
