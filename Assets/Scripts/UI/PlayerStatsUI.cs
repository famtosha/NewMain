using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour
{
    [SerializeField] private Text HealthText = null;
    [SerializeField] private Text WaterText = null;
    [SerializeField] private Text FoodText = null;
    [SerializeField] private Text TemperatureText = null;
    [SerializeField] private Text LiverText = null;

    private Stats playerStats;

    private void UpdatePlayerStats(PlayerStats x)
    {

        HealthText.text = Mathf.RoundToInt(x.Health).ToString();
        WaterText.text = Mathf.RoundToInt(x.Thirst).ToString();
        FoodText.text = Mathf.RoundToInt(x.Hunger).ToString();
        LiverText.text = Mathf.RoundToInt(x.Liver).ToString();
        TemperatureText.text = decimal.Round((decimal)x.Temperature, 2).ToString();
    }

    private void Start()
    {
        playerStats = GameMan.instance.Player.GetComponent<Stats>();
        playerStats.UpdateStats += UpdatePlayerStats;
    }
}
