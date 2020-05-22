using UnityEngine;
using System.Collections;
using UnityEngine.Experimental.Rendering.LWRP;
using System.Collections.Generic;
using System.Linq;

public class LightDisabling : MonoBehaviour
{


    public List<Light2D> Disabling = new List<Light2D>();
    public float minWaitTime;
    public float maxWaitTime;
    public bool IsSync;

    void Start()
    {
        gameObject.transform.GetChild
        gameObject.transform.GetComponentsInChildren<Light2D>().ToList();
        if (IsSync)
        {
            StartCoroutine(syncFlashing());
        }
        else
        {
            foreach (var CurLight in Disabling)
            {

                StartCoroutine(AsyncFlashing(CurLight));
            }

        }

    }
    IEnumerator syncFlashing()

    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
            foreach (var light in Disabling)
            {
                light.enabled = light.enabled;
            }

        }
    }

    IEnumerator AsyncFlashing(Light2D light)
    {

        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
            light.enabled = light.enabled;

        }
    }

}