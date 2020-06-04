using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmibientController : MonoBehaviour
{
    public AudioSource AudioSource;
    public CameraMove CameraMove;
    private void Update()
    {
        if (CameraMove.IsInRoom)
        {
            AudioSource.enabled = false;
        }
        else
        {
            AudioSource.enabled = true;
        }
    }
}
