using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff
{
    public event Action<float> OnDurationChange;

    public BuffType buffType;
    public BuffAffect affect;
    private float duration;

    public float Duration
    {
        get => duration;
        set
        {
            duration = value;
            OnDurationChange?.Invoke(duration);
        }
    }

    public Buff(BuffType buffType, BuffAffect affect, float duration)
    {
        this.affect = affect;
        this.duration = duration;
        this.buffType = buffType;
    }

    public static void AddAffect(PlayerStats playerStats, Buff buffAffect)
    {
        playerStats.Hunger -= buffAffect.affect.hunger;
        playerStats.Thirst -= buffAffect.affect.water;
        playerStats.Health -= buffAffect.affect.health;
        playerStats.Temperature -= buffAffect.affect.temperature;
    }
}
