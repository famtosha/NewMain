using System;
using System.Collections.Generic;
using UnityEngine;

class Stats : MonoBehaviour, ITarget
{
    public event Action<PlayerStats> UpdateStats;
    public List<Buff> PlayerBuffs = new List<Buff>();
    public PPController pPController;
    public bool IsInRoom = false;

    public PlayerStats playerStats = new PlayerStats();

    private void Start()
    {
        playerStats.OnPlayerDeath += PlayerDeath;
        playerStats.OnStatsUpdate += (x) => UpdateStats(x);
    }

    public void AddBuff(Buff buff)
    { 
        if(PlayerBuffs.IndexOf(buff) == -1)
        {
            PlayerBuffs.Add(buff);
            OnDataChanged();
        }
        else
        {
            RemoveBuff(buff);
            AddBuff(buff);
        }
        print($"add buff: {buff.buffType}");
    }

    public void RemoveBuff(Buff buff)
    {
        PlayerBuffs.Remove(buff);
        print($"remove buff: {buff.buffType}");
        OnDataChanged();
    }

    private void OnDataChanged()
    {
        UpdateStats?.Invoke(playerStats);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O)) AddBuff(BuffDB.CreateRandomBuff(10));
        UpdateBuffs();
        UpdateStat();
    }

    private void UpdateStat()
    {
        playerStats.Hunger -= 0.01f;

        if (IsInRoom)
        {
            playerStats.Temperature -= 0.0001f;
        }
        else
        {
            playerStats.Temperature -= 0.01f;
        }
    }

    private void UpdateBuffs()
    {
        foreach (Buff buff in PlayerBuffs)
        {
            buff.Duration -= Time.deltaTime;
            if (buff.Duration <= 0)
            {
                RemoveBuff(buff);
                break;
            }
            else
            {
                Buff.AddAffect(playerStats,buff);
                OnDataChanged();
            }
        }
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
