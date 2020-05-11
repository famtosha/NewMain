using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    public GameObject Barriel;

    private int AmmoLeft;
    private float FiringRate;
    private float NextFire;
    private bool IsReloading = false;
    public AudioSource audioSource;
    public ParticleSystem ParticleSystem;
    public LayerMask Ignore;
    public float MaxRazbros = 300;

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
        audioSource.PlayOneShot(((WeaponData)ItemDataCurrend).ReloadSound);
        yield return new WaitForSeconds(((WeaponData)ItemDataCurrend).ReloadTime);
        AmmoLeft = ((WeaponData)ItemDataCurrend).MagazineCapacity;      
        IsReloading = false;
    }

    public override void UseItem(out bool IsUsed)
    {

        if (Time.time > NextFire && !IsReloading)
        {
            NextFire = Time.time + FiringRate;
            if (AmmoLeft > 0)
            {
                
                Vector3 Start = Barriel.transform.position;

                Vector2 TrueStart = Start;
                Vector2 TrueDirect = Barriel.transform.right;

                RaycastHit2D hit = Physics2D.Raycast(TrueStart, TrueDirect, 30,~Ignore);

                Vector2 HitPoint;
                if (hit)
                {
                    HitPoint = hit.point;
                    var target = hit.transform.gameObject.GetComponent<ITarget>();
                    if(target != null)
                    {
                        target.DealDamage(((WeaponData)ItemDataCurrend).Damage);
                    }

                    var targetRB = hit.transform.gameObject.GetComponent<Rigidbody2D>();
                    if (targetRB)
                    {
                        targetRB.AddForce(TrueDirect.normalized * 100);
                    }
                }
                else
                {
                    HitPoint = TrueStart  + (((Vector2)Barriel.transform.right) * 3);
                }

                ParticleSystem.Play();
                Debug.DrawLine(TrueStart, HitPoint, Color.red, 0.2f);

                var shotlist = ((WeaponData)ItemDataCurrend).ShootSoundList;
                audioSource.PlayOneShot(shotlist[Random.Range(0, shotlist.Count)]);
                AmmoLeft--;
            }
            else
            {
                audioSource.PlayOneShot(((WeaponData)ItemDataCurrend).EmptySound);
            }
        }
        IsUsed = false;
    }
}
