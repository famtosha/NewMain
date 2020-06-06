using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "PlayerStats", order = 51)]

public class PlayerStats
{
    public event Action<PlayerStats> OnStatsUpdate;
    public event Action OnPlayerDeath;

    private float hunger = 100;
    private float thirst = 100;
    private float health = 100;
    private float temperature = 36.6f;

    private void UpdateStats() 
    {       
        OnStatsUpdate?.Invoke(this);
    }

    private void PlayerDead()
    {
        OnPlayerDeath?.Invoke();
    }

    public float Hunger
    {
        get => hunger;
        set
        {
            if(value <= 0)
            {
                PlayerDead();
            }
            else
            {
                hunger = value;
            }
            UpdateStats();
        }
    }

    public float Thirst
    {
        get => thirst;
        set
        {
            if (value <= 0)
            {
                PlayerDead();
            }
            else
            {
                thirst = value;
            }
            UpdateStats();
        }
    }

    public float Health
    {
        get => health;
        set
        {
            if (value <= 0)
            {
                PlayerDead();
            }
            else
            {
                health = value;
            }
            UpdateStats();
        }
    }

    public float Temperature
    {
        get => temperature;
        set
        {
            if (value <= 30 || value >= 45)
            {
                PlayerDead();
            }
            else
            {
                temperature = value;
            }
            UpdateStats();
        }
    }
}