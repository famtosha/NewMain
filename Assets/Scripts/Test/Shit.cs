using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;

public class Shit : MonoBehaviour
{
    [SerializeField] private TilemapRenderer Thins;
    [SerializeField] public GameObject Player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == Player.name)
        {
            Thins.enabled = false;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == Player.name)
        {
            Thins.enabled = true;
        }         
    }
}
