using System.Collections;
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

    public override void UseItem(out bool isUsed)
    {
        if (Time.time > CoolDown && !IsReloading)
        {
            CoolDown = Time.time + ((WeaponData)ItemData).FiringRate;
            if (((WeaponData)ItemData).AmmoInMagazine > 0)
            {
                Vector2 start = Barriel.transform.position;
                Vector2 direction = Barriel.transform.right;
                float dispersion = ((WeaponData)ItemData).Dispersion;

                for (int i = 0; i < ((WeaponData)(ItemData)).BulletPerShot; i++)
                {
                    RaycastHit2D hit = Physics2D.Raycast(start, direction + GetDispertion(dispersion), 20, ~Ignore);
                    Vector2 hitPoint = start + direction * 5;
                    if (hit)
                    {
                        GameObject target = hit.collider.gameObject;
                        DealDamage(target, 10);
                        PushTarget(target, direction, 10);
                        hitPoint = hit.point;
                    }
                    PlayerBulletAnimation(start, hitPoint, 50);
                }
                PlayShootSound();
                ((WeaponData)ItemData).AmmoInMagazine--;
            }
            else
            {
                PlayEmptySound();
            }
        }
        isUsed = false;
    }

    private Vector2 GetDispertion(float dispersion)
    {
        return new Vector2(Random.Range(-dispersion, dispersion), Random.Range(-dispersion, dispersion));
    }

    private void DealDamage(GameObject target, float damage)
    {
        var hitTarget = target.GetComponentInParent<ITarget>();
        if (hitTarget != null)
        {
            hitTarget.DealDamage(damage);
        }
    }

    private void PushTarget(GameObject target, Vector2 direction, float force)
    {
        var hitRB = target.GetComponentInParent<Rigidbody2D>();
        if (hitRB)
        {
            hitRB.AddForce(direction.normalized * force);
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