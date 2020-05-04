using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;

public class Shit : MonoBehaviour
{
    [SerializeField] private TilemapRenderer Thins;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Thins.enabled = false;  
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Thins.enabled = true;
    }
}
