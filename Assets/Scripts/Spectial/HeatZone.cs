using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatZone : MonoBehaviour
{

    private GameObject Player;
    private Stats playerStats;

    private void Start()
    {
        Player = GameMan.instance.Player;
        playerStats = Player.GetComponent<Stats>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == Player.name)
        {
            playerStats.IsInRoom = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == Player.name)
        {
            playerStats.IsInRoom = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == Player.name)
        {
            playerStats.IsInRoom = true;
        }
    }
}
