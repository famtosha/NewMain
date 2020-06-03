using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    public GameObject Barriel;
    public GameObject BulletPrefab;
    public LayerMask Ignore;

    private float CoolDown = 0;
    private bool IsReloading = false;
    private AudioSource audioSource;


    new private void Start()
    {
        base.Start();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public override string GetInfo()
    {
        return ((WeaponData)ItemData).AmmoInMagazine + " / " + ((WeaponData)ItemData).MagazineCapacity;
    }

    public override void EquipItem()
    {
        base.EquipItem();
        IsReloading = false;
    }

    public virtual void Reload()
    {
        if (!IsReloading)
        {
            StartCoroutine(StartReload());
        }
    }

    private IEnumerator StartReload()
    {
        IsReloading = true;
        audioSource.PlayOneShot(((WeaponData)ItemData).ReloadSound);
        yield return new WaitForSeconds(((WeaponData)ItemData).ReloadTime);
        ((WeaponData)ItemData).AmmoInMagazine = ((WeaponData)ItemData).MagazineCapacity;
        IsReloading = false;
    }

    public override void UseItem(out bool IsUsed)
    {
        if (Time.time > CoolDown && !IsReloading)
        {
            CoolDown = Time.time + ((WeaponData)ItemData).FiringRate;
            if (((WeaponData)ItemData).AmmoInMagazine > 0)
            {
                Vector2 Start = Barriel.transform.position;
                Vector2 Direct = Barriel.transform.right;
                float dispersion = ((WeaponData)ItemData).Dispersion;


                for (int i = 0; i < ((WeaponData)(ItemData)).BulletPerShot; i++)
                {
                    Vector2 Dispersion = new Vector2(Random.Range(-dispersion, dispersion), Random.Range(-dispersion, dispersion));
                    Direct += Dispersion;

                    RaycastHit2D Hit = Physics2D.Raycast(Start, Direct, 20, ~Ignore);
                    var Bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);

                    if (Hit)
                    {
                        Bullet.GetComponent<Bullet>().StartBullet(Start, Hit.point, 10);
                        var s = Hit.collider.gameObject.GetComponent<Rigidbody2D>();
                        if (s)
                        {
                            s.AddForce(Direct.normalized * 10);
                        }
                    }
                    else
                    {
                        Bullet.GetComponent<Bullet>().StartBullet(Start, Start + Direct.normalized * 100);
                    }
                }
                ((WeaponData)ItemData).AmmoInMagazine--;
                var shotlist = ((WeaponData)ItemData).ShootSoundList;
                audioSource.PlayOneShot(shotlist[Random.Range(0, shotlist.Count)]);
            }
            else
            {
                audioSource.PlayOneShot(((WeaponData)ItemData).EmptySound);
            }
        }
        IsUsed = false;
    }
}



//Vector2 Start = Barriel.transform.position;
//Vector2 Direct = Barriel.transform.right;
//float dispersion = ((WeaponData)ItemData).Dispersion;


//for (int i = 0; i < ((WeaponData)(ItemData)).BulletPerShot; i++)
//{
//    Vector2 Dispersion = new Vector2(Random.Range(-dispersion, dispersion), Random.Range(-dispersion, dispersion));
//    Direct += Dispersion;

//    GameObject BulletClone = Instantiate(BulletPrefab, transform.position, transform.rotation);
//    BulletClone.GetComponent<Rigidbody2D>().AddForce(Direct * ((WeaponData)ItemData).BulletSpeed);
//    BulletClone.GetComponent<BulletController>().Ignore = gameObject.layer;
//    Debug.DrawRay(transform.position, Direct * 5, Color.red, 0.2f);
//}
//((WeaponData)ItemData).AmmoInMagazine--;
//var shotlist = ((WeaponData)ItemData).ShootSoundList;
//audioSource.PlayOneShot(shotlist[Random.Range(0, shotlist.Count)]);