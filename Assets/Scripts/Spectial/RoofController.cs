using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;

public class RoofController : MonoBehaviour
{
    [SerializeField] private TilemapRenderer RoofRenderer;
    [SerializeField] public GameObject Player;
    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private CameraMove ultrashit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == Player.name)
        {
            RoofRenderer.enabled = false;
            ultrashit.MoveDown();
        }      
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == Player.name)
        {
            RoofRenderer.enabled = true;
            ultrashit.MoveUp();
        }         
    }
}
