using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

class Stats : MonoBehaviour, ITarget
{
    public event Action<PlayerStats> UpdateStats;
    public PPController pPController;
    public bool IsInRoom = false;
    private Timer buffTimer;
    private Timer statsTimer;

    private BuffList buffList = new BuffList();

    public PlayerStats playerStats = new PlayerStats();

    private void Start()
    {
        playerStats.OnPlayerDeath += PlayerDeath;
        playerStats.OnStatsUpdate += (x) => OnDataChanged();
        buffTimer = Timer.CreateTimer(1, UpdateBuffs).GetComponent<Timer>();
        statsTimer = Timer.CreateTimer(1, UpdateStat).GetComponent<Timer>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.O)) buffList.AddToList(BuffDB.CreateBuff(BuffType.Cold, 10, true));
    }

    private void OnDataChanged()
    {
        UpdateStats?.Invoke(playerStats);
        if (playerStats.Liver == 100)
        {
            buffList.AddToList(BuffDB.CreateBuff(BuffType.Vodka, 0, false));
        }
        else
        {
            buffList.RemoveFromList(BuffType.Vodka);
        }
    }

    private void UpdateStat()
    {
        playerStats.Hunger -= 1f;

        if (IsInRoom)
        {
            playerStats.Temperature -= 0.1f;
        }
        else
        {
            playerStats.Temperature -= 1f;
        }
    }

    private void UpdateBuffs()
    {
        foreach (Buff buff in buffList.buffList)
        {
            if (buff.isRemoveByTime)
            {
                buff.Duration -= 1;
                if (buff.Duration <= 0)
                {
                    buffList.RemoveFromList(buff);
                    break;
                }
                else
                {
                    Buff.AddAffect(playerStats, buff);
                    OnDataChanged();
                }
            }
            else
            {
                Buff.AddAffect(playerStats, buff);
                OnDataChanged();
            }
        }
        string debug = "Buffs: ";
        buffList.buffList.ForEach(x => debug += $" {x.buffType} | {x.Duration} | {x.isRemoveByTime} ");
        print(debug);
    }

    private void PlayerDeath()
    {
        UIManager.instance.EnableDeathMenu();
        gameObject.SetActive(false);
    }

    public void DealDamage(float Damage)
    {
        playerStats.Health -= Damage;
    }
}
