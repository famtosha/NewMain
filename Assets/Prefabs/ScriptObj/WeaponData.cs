using UnityEngine;


[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon", order = 51)]
public class WeaponData : ItemData
{
    public enum WeaponType { pistol, smg, heavy, rifle, melee, shotgun };
    [SerializeField] public WeaponType _weaponType;
    [SerializeField] private int _damage;
    [SerializeField] private int _recoil;
    [SerializeField] private int _magazineCapacity;
    [SerializeField] private int _firingRate;
    [SerializeField] private int _reloadTime;
    [SerializeField] private AudioClip _shotSound;
    [SerializeField] private AudioClip _reloadSound;


    public int Damage
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
    public int Recoil
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
    public int FiringRate
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
    public int ReloadTime
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

