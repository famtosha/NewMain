using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    public string Name;
    public float Duration = 20;
    private float _durationLeft;

    public float DurationLeft
    {
        get
        {
            return _durationLeft;
        }
        set
        {
            _durationLeft = value;
            updateDuration();
        }
    }

    public event Action<float> OnDurationChange; 

    private void updateDuration()
    {
        OnDurationChange?.Invoke(DurationLeft);
    }

    private void Start()
    {
        DurationLeft = Duration;
    }

    private void Update()
    {
        Duration -= Time.deltaTime;
    }
}
