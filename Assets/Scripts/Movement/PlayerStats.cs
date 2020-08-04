using System;

public class PlayerStats
{
    public event Action<PlayerStats> OnStatsUpdate;
    public event Action OnPlayerDeath;

    private float hunger = 100;
    private float thirst = 100;
    private float health = 100;
    private float temperature = 100f;
    private float movementSpeed = 2.5f;
    private float liver = 0f;


    private void UpdateStats()
    {
        OnStatsUpdate?.Invoke(this);
    }

    private void PlayerDead()
    {
        OnPlayerDeath?.Invoke();
    }

    public float MovementSpeed
    {
        get => movementSpeed;
        set
        {
            movementSpeed = value;
        }
    }

    public float Hunger
    {
        get => hunger;
        set
        {
            if (value <= 0)
            {
                PlayerDead();
            }
            else
            {
                if (value >= 100)
                {
                    hunger = 100;
                }
                else
                {
                    hunger = value;
                }
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
                if (value >= 100)
                {
                    thirst = 100;
                }
                else
                {
                    thirst = value;
                }
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
                if (value >= 100)
                {
                    health = 100;
                }
                else
                {
                    health = value;
                }
            }
            UpdateStats();
        }
    }

    public float Temperature
    {
        get => temperature;
        set
        {
            if (value <= 0)
            {
                PlayerDead();
            }
            if (value >= 100)
            {
                temperature = 100;
            }
            else
            {
                temperature = value;
            }
            UpdateStats();
        }
    }
    public float Liver
    {
        get => liver;
        set
        {
            if (value <= 0)
            {
                return;

            }
            if (value >= 100)
            {
                liver = 100;
            }
            else
            {
                liver = value;
            }
            UpdateStats();

        }
    }
}
