using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Supply", menuName = "Supply", order = 51)]

class SupplyData : ItemData
{
    [SerializeField] private float _foodGive = 0;
    [SerializeField] private float _waterGive = 0;
    [SerializeField] private float _temperatureGive = 0;
    [SerializeField] private float _healthGive = 0;

    public float FoodGive 
    { 
        get { return _foodGive; } 
    }
    public float WaterGive
    { 
        get { return _waterGive; } 
    }
    public float TemperatureGive
    { 
        get { return _temperatureGive; } 
    }
    public float HealthGive
    {
        get { return _healthGive; }
    }

}
