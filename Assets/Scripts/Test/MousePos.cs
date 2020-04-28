using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePos : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            Vector3 x = Input.mousePosition;
            x.z = 10;
            print(Camera.main.ScreenToWorldPoint(x));
        }
    }
}
