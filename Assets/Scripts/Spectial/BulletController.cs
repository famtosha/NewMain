using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Thing());
    }

    IEnumerator Thing()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var target = collision.gameObject.GetComponent<Target>();
        if (target != null)
        {
            target.DealDamage(10);
        }
        Destroy(gameObject);
    }
}
