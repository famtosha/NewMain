using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    public GameObject bulletPrefab;
    public int BulletSpeed;

    private int AmmoLeft;
    private float FiringRate;
    private float NextFire;

    new private void Start()
    {
        base.Start();
        WeaponData weaponData = (WeaponData)ItemDataCurrend;
        AmmoLeft = weaponData.MagazineCapacity;
        FiringRate = weaponData.FiringRate;
    }

    public override string GetInfo()
    {
        return AmmoLeft + " / " + ((WeaponData)ItemDataCurrend).MagazineCapacity;
    }

    public virtual void Reload()
    {
        AmmoLeft = ((WeaponData)ItemDataCurrend).MagazineCapacity;
    }

    public override void UseItem()
    {

        if (Time.time > NextFire)
        {
            NextFire = Time.time + FiringRate;
            if (AmmoLeft > 0)
            {
                Vector3 PointerPos = Input.mousePosition;
                PointerPos.z = 10;
                Vector3 Start = PlayerTransform.position;
                Vector3 Direct = (Camera.main.ScreenToWorldPoint(PointerPos) - Start);

                Vector2 x = new Vector2(Direct.x, Direct.y);
                var bullet = Instantiate(bulletPrefab, (Vector2)Start + x.normalized, new Quaternion());

                bullet.GetComponent<Rigidbody2D>().AddForce(Direct.normalized * BulletSpeed);
                AmmoLeft--;
            }
        }        
    }
}
