using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timerCooldown = 0;
    public bool singleUse = false;
    public bool isComplete = false;
    public Action action;

    private float timerCurrentTime = 0;

    public void Update()
    {
        timerCurrentTime += Time.deltaTime;
        if (timerCurrentTime >= timerCooldown)
        {
            timerCurrentTime = 0;
            DoThing();
        }
    }

    private void DoThing()
    {
        action.Invoke();
    }

    public void StartTimer(float timerCooldown, Action action)
    {
        this.action = action;
        this.timerCooldown = timerCooldown;
    }

    public static GameObject CreateTimer(float timerCooldown, Action action)
    {
        var timer = new GameObject("Timer");
        var timersTimer = timer.AddComponent<Timer>();
        timersTimer.StartTimer(timerCooldown, action);
        return timer;
    }

    public void StopTimer()
    {
        Destroy(gameObject);
    }
}