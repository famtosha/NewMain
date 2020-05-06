using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Supply", menuName = "Supply", order = 51)]

class SupplyData : ItemData
{
    [SerializeField] private float _foodGive;
    [SerializeField] private float _waterGive;
    [SerializeField] private float _temperatureGive;
    [SerializeField] private float _healthGive;

    public float FoodGive { get { return _foodGive; } }
    public float WaterGive { get { return _waterGive; } }
    public float TemperatureGive { get { return _temperatureGive; } }
    public float HealthGive { get { return _healthGive; } }

}
