using System;
using System.Collections.Generic;
using UnityEngine;

class PlayerStats : MonoBehaviour, ITarget
{
    public event Action<PlayerStats> UpdateStats;
    public List<Buff> PlayerBuffs = new List<Buff>();
    [SerializeField] private float _hunger = 100;
    [SerializeField] private float _thirst = 100;
    [SerializeField] private float _health = 100;
    [SerializeField] private float _temperature = 36.6f;

    public bool IsInRoom = false;

    private void OnDataChanged()
    {
        UpdateStats?.Invoke(this);
    }

    private void Update()
    {
        Hunger -= 0.001f;       
        foreach (Buff buff in PlayerBuffs)
        {
            buff.DurationLeft -= 0.01f;
        }

        if (IsInRoom)
        {
            Temperature -= 0.0001f;
        }
        else
        {
            Temperature -= 0.01f;
        }
    }

    public float Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
            if(_health <= 0)
            {
                PlayerDeath();
            }
            else
            {
                _health = Mathf.Clamp(_health, 0, 100);
            }
            OnDataChanged();
        }
    }

    public float Temperature
    {
        get
        {
            return _temperature;
        }
        set
        {
            _temperature = value;
            if(_temperature > 42 || _temperature < 34)
            {
                PlayerDeath();
            }
            OnDataChanged();
        }
    }

    public float Hunger
    {
        get
        {
            return _hunger;
        }
        set
        {
            _hunger = value;
            if (_hunger < 0)
            {
                _hunger = 0;
            }
            else
            {
                _hunger = Mathf.Clamp(_hunger, 0, 100);
            }
            OnDataChanged();
        }
    }

    public float Thirst
    {
        get
        {
            return _thirst;
        }
        set
        {
            _thirst = value;
            if (_thirst < 0)
            {
                _thirst = 0;
            }
            else
            {
                _thirst = Mathf.Clamp(_thirst, 0, 100);
            }
            OnDataChanged();
        }
    }

    private void PlayerDeath()
    {
        UIManager.instance.EnableDeathMenu();
        gameObject.SetActive(false);
    }

    public void DealDamage(float Damage)
    {
        Health -= Damage;
    }
}
