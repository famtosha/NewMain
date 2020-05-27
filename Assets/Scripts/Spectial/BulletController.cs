using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int Ignore = 0;
    public float Damage = 10;
    public float BulletForce = 100;

    private void Start()
    {
        StartCoroutine(Thing());
    }

    IEnumerator Thing()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer != Ignore)
        {
            var target = collision.gameObject.GetComponent<ITarget>();
            if (target != null)
            {
                target.DealDamage(Damage);
            }
            var targetRB = collision.gameObject.GetComponent<Rigidbody2D>();
            if (targetRB != null)
            {
                targetRB.AddForce(gameObject.GetComponent<Rigidbody2D>().velocity);
            }
            Destroy(gameObject);
        }
    }
}
