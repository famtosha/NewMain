using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour
{
    [SerializeField] private Text HealthText;
    [SerializeField] private Text WaterText;
    [SerializeField] private Text FoodText;
    [SerializeField] private Text TemperatureText;

    private PlayerStats playerStats;

    private void UpdatePlayerStats(PlayerStats x)
    {
        
        HealthText.text = Mathf.RoundToInt(x.Health).ToString();
        WaterText.text = Mathf.RoundToInt(x.Thirst).ToString();
        FoodText.text = Mathf.RoundToInt(x.Hunger).ToString();
        TemperatureText.text = decimal.Round((decimal)x.Temperature, 2).ToString();
    }

    private void Start()
    {
        playerStats = GameMan.instance.Player.GetComponent<PlayerStats>();
        playerStats.UpdateStats += UpdatePlayerStats;
    }
}
