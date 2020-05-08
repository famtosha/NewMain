using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform PlayerPos;
    [SerializeField] private Transform CameraPos;
    public bool IsInRoom = false;
    private bool IsMoving = false;
    private float CameraZ;
    private float _time = 0f;

    void Update()
    {
        if (IsMoving)
        {
            _time += Time.deltaTime;
            if (_time >= 1)
            {
                IsMoving = false;
                _time = 0f;
            }
        }       
   
        if (IsInRoom)
        {
            CameraZ = -0.6f;
        }
        else
        {
            CameraZ = -1f;
        }

        float z = Mathf.Lerp(CameraPos.position.z,CameraZ,_time/3);
        Vector3 NewPos = new Vector3(PlayerPos.position.x, PlayerPos.position.y, z);
        CameraPos.position = NewPos;
    }

    public void MoveDown()
    {
        IsInRoom = true;
        IsMoving = true;
    }

    public void LeaveRoom()
    {
        IsInRoom = false;
        IsMoving = true;
    }
}
