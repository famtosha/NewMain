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
                Vector2 Direction = Barriel.transform.right;
                float dispersion = ((WeaponData)ItemData).Dispersion;

                for (int i = 0; i < ((WeaponData)(ItemData)).BulletPerShot; i++)
                {
                    RaycastHit2D Hit = Physics2D.Raycast(Start, Direction + GetDispertion(dispersion), 20, ~Ignore);                   
                    Vector2 HitPoint = Start + Direction * 5;
                    if (Hit)
                    {
                        GameObject Target = Hit.collider.gameObject;
                        DealDamage(Target, 10);
                        PushTarget(Target, Direction, 10);
                        HitPoint = Hit.point;
                    }
                    PlayerBulletAnimation(Start, HitPoint, 10);
                }
                PlayShootSound();
                ((WeaponData)ItemData).AmmoInMagazine--;
            }
            else
            {
                PlayEmptySound();
            }
        }
        IsUsed = false;
    }

    private Vector2 GetDispertion(float disp)
    {
        return new Vector2(Random.Range(-disp, disp), Random.Range(-disp, disp));
    }

    private void DealDamage(GameObject target, float damage)
    {
        var HitTarget = target.GetComponent<ITarget>();
        if (HitTarget != null)
        {
            HitTarget.DealDamage(damage);
        }
    }

    private void PushTarget(GameObject target, Vector2 direction, float force)
    {
        var HitRB = target.GetComponent<Rigidbody2D>();
        if (HitRB)
        {
            HitRB.AddForce(direction.normalized * force);
        }
    }

    private void PlayerBulletAnimation(Vector2 start, Vector2 end, float speed)
    {
        var bulletClone = Instantiate(BulletPrefab, transform.position, transform.rotation);
        bulletClone.GetComponent<Bullet>().StartBullet(start, end, speed);
    }

    private void PlayShootSound()
    {
        var shotlist = ((WeaponData)ItemData).ShootSoundList;
        audioSource.PlayOneShot(shotlist[Random.Range(0, shotlist.Count)]);
    }

    private void PlayEmptySound()
    {
        audioSource.PlayOneShot(((WeaponData)ItemData).EmptySound);
    }
}