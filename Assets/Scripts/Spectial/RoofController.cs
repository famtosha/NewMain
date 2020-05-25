using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;
using System;

public class RoofController : MonoBehaviour
{
    [SerializeField] private Tilemap Roof;
    [SerializeField] private CameraMove ultrashit;
    private GameObject Player;

    private void Start()
    {
        Player = GameMan.instance.Player;
    }

    private bool IsInRoom = false;

    void Update()
    {
        float Change = 0f;
        if (IsInRoom)
        {
            Change = -0.1f;
        }
        else
        {
            Change = +0.1f;
        }

        Color NewColor = Roof.color;
        NewColor.a = Mathf.Clamp(NewColor.a + Change, 0, 1);

        Roof.color = NewColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == Player.name)
        {
            ultrashit.IsInRoom = true;
        }      
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name == Player.name)
        {
            IsInRoom = true;
            ultrashit.IsInRoom = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == Player.name)
        {
            IsInRoom = false;
            ultrashit.IsInRoom = false;
        }         
    }
}
