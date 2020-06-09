using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter
{
    public float time = 0;

    public void UpdateTimer()
    {
        time += Time.deltaTime;
    }
}
