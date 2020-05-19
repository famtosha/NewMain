using UnityEngine;
using System.Collections;

public class LightDisabling : MonoBehaviour
{


	public static UnityEngine.Experimental.Rendering.LWRP.Light2D Flickering;
	public float minWaitTime;
	public float maxWaitTime;

	void Start()
	{
		Flickering = GetComponent<UnityEngine.Experimental.Rendering.LWRP.Light2D>();
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