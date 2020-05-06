using System;
using UnityEngine;

class PlayerStats : MonoBehaviour, ITarget
{
    public event Action<PlayerStats> UpdateStats;

    private void OnDataChanged()
    {
        UpdateStats?.Invoke(this);
    }

    [SerializeField] private UIManager uiManager;
    [SerializeField] private float _hunger;
    [SerializeField] private float _thirst;
    [SerializeField] private float _health;
    [SerializeField] private float _temperature;

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
        uiManager.EnableDeathMenu();
        gameObject.SetActive(false);
    }

    private void Update()
    {
        Hunger -= 0.001f;
    }
    public void DealDamage(float Damage)
    {
        Health -= Damage;
    }
}
