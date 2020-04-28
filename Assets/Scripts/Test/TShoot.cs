using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TShoot : MonoBehaviour
{
    public GameObject Projectile;
    public float Force = 10;
    public float ShootRate = 0.1f;
    private float NextFire;

    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        if (Time.time > NextFire)
        {
            NextFire = Time.time + ShootRate;
            

            Vector2 MonitorCenter = new Vector2(Screen.width / 2, Screen.height / 2);
            Vector2 MousePos = Input.mousePosition;
            Vector2 direct = MousePos - MonitorCenter;
            direct = direct.normalized;


            var projectile = Instantiate(Projectile, gameObject.transform.position, gameObject.transform.rotation);
            projectile.transform.Translate(direct * 2);
            projectile.GetComponent<Rigidbody2D>().AddForce(direct * Force);
        }                   
    }
}
