using UnityEngine;


[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon", order = 51)]
public class WeaponData : ItemData
{
    public enum WeaponType { pistol, smg, heavy, rifle, melee, shotgun };
    [SerializeField] public WeaponType _weaponType;
    [SerializeField] private float _damage;
    [SerializeField] private float _recoil;
    [SerializeField] private int _magazineCapacity;
    [SerializeField] private float _firingRate;
    [SerializeField] private float _reloadTime;
    [SerializeField] private AudioClip _shotSound;
    [SerializeField] private AudioClip _reloadSound;

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
    public float Recoil
    {
        get
        {
            return _recoil;
        }
        set
        {
            _recoil = value;
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

