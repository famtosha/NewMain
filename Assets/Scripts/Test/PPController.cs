﻿using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PPController : MonoBehaviour
{
    public PostProcessVolume HungerPP;
    public PostProcessVolume ColdPP;
    public PostProcessVolume LowHealthPP;

    [SerializeField] private float LowHealthActive = 50;
    [SerializeField] private float ColdActive = 35;
    [SerializeField] private float HungerActive = 50;

    private Stats _playerStats;

    private void Start()
    {
        _playerStats = GameMan.instance.Player.GetComponent<Stats>();
        _playerStats.playerStats.OnStatsUpdate += PlayerStatsChangeHandler;
    }

    private void PlayerStatsChangeHandler(PlayerStats playerStats)
    {
        if (playerStats.Health <= LowHealthActive)
        {
            LowHealthPP.enabled = true;
        }
        else
        {
            LowHealthPP.enabled = false;
        }

        if (playerStats.Temperature <= ColdActive)
        {
            ColdPP.enabled = true;
        }
        else
        {
            ColdPP.enabled = false;
        }

        if (playerStats.Hunger <= HungerActive)
        {
            HungerPP.enabled = true;
        }
        else
        {
            HungerPP.enabled = false;
        }
    }
}
