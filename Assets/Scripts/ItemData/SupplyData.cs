using UnityEngine;

[CreateAssetMenu(fileName = "New Supply", menuName = "Supply", order = 51)]

class SupplyData : ItemData
{
    [SerializeField] private float _foodGive = 0;
    [SerializeField] private float _waterGive = 0;
    [SerializeField] private float vodkaGive = 0;
    [SerializeField] private float _temperatureGive = 0;
    [SerializeField] private float _healthGive = 0;

    public float FoodGive
    {
        get => _foodGive;
    }
    public float WaterGive
    {
        get => _waterGive;
    }
    public float TemperatureGive
    {
        get => _temperatureGive;
    }
    public float HealthGive
    {
        get => _healthGive;
    }
    public float VodkaGive
    {
        get => vodkaGive;
    }
}