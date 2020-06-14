using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightFlickering : MonoBehaviour
{
    public List<Light2D> LightList = new List<Light2D>();
    public float minIntensity = 0f;
    public float maxIntensity = 1f;
    [Range(1, 50)] public int smoothing = 5;

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
    }

    void Update()
    {
        if (LightList == null) return;

        while (smoothQueue.Count >= smoothing)
        {
            lastSum -= smoothQueue.Dequeue();
        }

        float newVal = Random.Range(minIntensity, maxIntensity);
        smoothQueue.Enqueue(newVal);
        lastSum += newVal;
        foreach (var CurLight in LightList)
        {
            CurLight.intensity = lastSum / (float)smoothQueue.Count;
        }
    }
}