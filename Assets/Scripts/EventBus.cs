using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;

public static class EventBus
{
    public static Action OnWaveGenerate;
    public static Action OnPlayerDestroyed;
    //for HealthBar
    public static Action<float> OnPlayerTackesDamage;
    public static Action<GameObject> OnPowerupGenerated;
    //for PowerupHadler
    public static Action<float, bool, GameObject> OnPowerupTaked;
    //for increasing player xp
    public static Action<float> OnEnemyKilled;
    public static Action OnPowerupEffectEnded;
    public static Action OnPlayerAtack;
    //for taking player power
    public static Action<float> OnEnemyGenerated;
    public static Action OnWaveEnd;
    public static Action OnWaveStart;

}
