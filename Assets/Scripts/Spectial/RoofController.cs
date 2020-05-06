using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;
using System;

public class RoofController : MonoBehaviour
{
    [SerializeField] private Tilemap Roof;
    [SerializeField] public GameObject Player;
    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private CameraMove ultrashit;

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
            IsInRoom = true;
            ultrashit.MoveDown();
        }      
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == Player.name)
        {
            IsInRoom = false;
            ultrashit.MoveUp();
        }         
    }
}
