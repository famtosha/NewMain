using System;

public class Buff
{
    public event Action<float> OnDurationChange;
    public BuffType buffType;
    public BuffAffect affect;
    public bool isRemoveByTime = true;

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

    public Buff(BuffType buffType, BuffAffect affect, float duration, bool isRemoveByTime)
    {
        this.affect = affect;
        this.duration = duration;
        this.buffType = buffType;
        this.isRemoveByTime = isRemoveByTime;
    }

    public static void AddAffect(PlayerStats playerStats, Buff buffAffect)
    {
        playerStats.MovementSpeed -= buffAffect.affect.speed;
        playerStats.Hunger -= buffAffect.affect.hunger;
        playerStats.Thirst -= buffAffect.affect.water;
        playerStats.Health -= buffAffect.affect.health;
        playerStats.Temperature -= buffAffect.affect.temperature;
    }
}