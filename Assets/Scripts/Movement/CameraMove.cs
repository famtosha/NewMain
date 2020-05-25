using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform PlayerPos;
    [SerializeField] private Transform CameraPos;
    [SerializeField] private Camera Camera;
    [SerializeField] private float CameraMin;
    [SerializeField] private float CameraMax;
    public bool IsInRoom = false;
    private float _time = 0f;


    private void Start()
    {
        PlayerPos = GameMan.instance.Player.transform;
    }

    void Update()
    {
        if (IsInRoom)
        {
            _time += 0.03f;
        }
        else
        {
            _time -= 0.03f;
        }

        _time = Mathf.Clamp(_time, 0, 1);
        
        Vector3 NewPos = new Vector3(PlayerPos.position.x, PlayerPos.position.y, CameraPos.position.z);
        CameraPos.position = NewPos;
        Camera.orthographicSize = Mathf.Lerp(CameraMax, CameraMin, _time * _time);   
    }
}
