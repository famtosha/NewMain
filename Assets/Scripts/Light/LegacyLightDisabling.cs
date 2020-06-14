using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LegacyLightDisabling : MonoBehaviour
{
    public float minWaitTime;
    public float maxWaitTime;

    private Light2D testLight;

    void Start()
    {
        testLight = GetComponent<Light2D>();
        StartCoroutine(Flashing());
    }

    IEnumerator Flashing()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
            testLight.enabled = !testLight.enabled;
        }
    }
}