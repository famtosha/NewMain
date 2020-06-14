using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LegacyLightFlickering : MonoBehaviour
{
    [Range(1, 50)] public int smoothing = 5;
    public Light2D Light;
    public float minIntensity = 0f;
    public float maxIntensity = 1f;

    private Queue<float> smoothQueue;
    private float lastSum = 0;

    public void Reset()
    {
        smoothQueue.Clear();
        lastSum = 0;
    }

    void Start()
    {
        smoothQueue = new Queue<float>(smoothing);
        if (Light == null)
        {
            Light = GetComponent<Light2D>();
        }
    }

    void Update()
    {
        if (Light == null) return;

        while (smoothQueue.Count >= smoothing)
        {
            lastSum -= smoothQueue.Dequeue();
        }

        float newVal = Random.Range(minIntensity, maxIntensity);
        smoothQueue.Enqueue(newVal);
        lastSum += newVal;

        Light.intensity = lastSum / (float)smoothQueue.Count;
    }
}