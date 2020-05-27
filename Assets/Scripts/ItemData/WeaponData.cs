using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon", order = 51)]
public class WeaponData : ItemData
{
    public enum WeaponType { pistol, smg, heavy, rifle, melee, shotgun };
    [SerializeField] public WeaponType _weaponType;
    [SerializeField] private float _damage;
    [SerializeField] private int _ammoInMagazine;
    [SerializeField] private int _magazineCapacity;
    [SerializeField] private float _firingRate;
    [SerializeField] private float _reloadTime;
    [SerializeField] public List<AudioClip> ShootSoundList;
    [SerializeField] public AudioClip ReloadSound;
    [SerializeField] public AudioClip EmptySound;
    [SerializeField] public int BulletPerShot = 1;
    [SerializeField] public int BulletSpeed = 4000;
    [SerializeField] public float Dispersion = 0.1f;

    public float Damage
    {
        get
        {
            return _damage;
        }
        set
        {
            _damage = value;
        }
    }
    public int MagazineCapacity
    {
        get
        {
            return _magazineCapacity;
        }
        set
        {
            _magazineCapacity = value;
        }
    }
    public int AmmoInMagazine
    {
        get
        {
            return _ammoInMagazine;
        }
        set
        {
            _ammoInMagazine = value;
        }
    }
    public float FiringRate
    {
        get
        {
            return _firingRate;
        }
        set
        {
            _firingRate = value;
        }
    }
    public float ReloadTime
    {
        get
        {
            return _reloadTime;
        }
        set
        {
            _reloadTime = value;
        }
    }
}

