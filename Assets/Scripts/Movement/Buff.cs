using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff
{
    public event Action<float> OnDurationChange;
    public string Name = "";
    private float _durationLeft;

    public Buff(string name, float Duration)
    {
        Name = name;
        DurationLeft = Duration;
    }

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

    private void updateDuration()
    {
        OnDurationChange?.Invoke(DurationLeft);
    }
}
