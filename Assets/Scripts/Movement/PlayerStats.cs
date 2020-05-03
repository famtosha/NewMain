using System;
using UnityEngine;

class PlayerStats : Target
{
    [SerializeField] private UIManager uiManager;
    private float _hunger;
    private float _thirst;

    public float Temperature { get; set; }
    public float Hunger
    {
        get
        {
            return _hunger;
        }
        set
        {
            _hunger += value;
            if (_hunger < 0)
            {
                _hunger = 0;
            }
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
            _thirst += value;
            if (_thirst < 0)
            {
                _thirst = 0;
            }
        }
    }

    private void Start()
    {
        Dead += PlayerDeath;
    }

    private void PlayerDeath()
    {
        uiManager.EnableDeathMenu();
        gameObject.SetActive(false);
    }
}
