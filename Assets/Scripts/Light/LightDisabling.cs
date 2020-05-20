using UnityEngine;
using System.Collections;
using UnityEngine.Experimental.Rendering.LWRP;

public class LightDisabling : MonoBehaviour
{


	public static Light2D Flickering;
	public float minWaitTime;
	public float maxWaitTime;

	void Start()
	{
		Flickering = GetComponent<Light2D>();
		StartCoroutine(Flashing());
	}

	IEnumerator Flashing()
	{
		while (true)
		{
			yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
			Flickering.enabled = !Flickering.enabled;

		}
	}
}