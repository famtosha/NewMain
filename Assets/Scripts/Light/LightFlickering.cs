﻿using UnityEngine;
using System.Collections.Generic;

public class LightFlickering : MonoBehaviour
{
    public new UnityEngine.Experimental.Rendering.LWRP.Light2D light;
    public float minIntensity = 0f;
    public float maxIntensity = 1f;
    [Range(1, 50)]
    public int smoothing = 5;
    Queue<float> smoothQueue;
    float lastSum = 0;



    public void Reset()
    {
        smoothQueue.Clear();
        lastSum = 0;
    }

    void Start()
    {
        smoothQueue = new Queue<float>(smoothing);
        
        if (light == null)
        {
            light = GetComponent<UnityEngine.Experimental.Rendering.LWRP.Light2D>();
        }
    }

    void Update()
    {
        if (light == null)
            return;

        while (smoothQueue.Count >= smoothing)
        {
            lastSum -= smoothQueue.Dequeue();
        }

        float newVal = Random.Range(minIntensity, maxIntensity);
        smoothQueue.Enqueue(newVal);
        lastSum += newVal;
              
        light.intensity = lastSum / (float)smoothQueue.Count;
    }

}