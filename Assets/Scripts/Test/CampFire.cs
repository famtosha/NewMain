using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour
{
    [SerializeField] float tempPower;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject == GameMan.instance.Player)
        {
            float dist = Vector3.Distance(collision.gameObject.transform.position, gameObject.transform.position);
            collision.GetComponent<PlayerStats>().Temperature += tempPower / dist;
        }
    }
}
