using System;
using UnityEngine;

public class Target : MonoBehaviour, ITarget
{
    public event Action OnDeath;
    [SerializeField] protected float _health = 100;

    private void Start()
    {
        OnDeath += Death;
    }

    public float Health
    {
        get => _health;
        set
        {
            _health = value;
            if (_health <= 0)
            {
                OnDeath?.Invoke();
            }
        }
    }

    virtual protected void Death()
    {
        Destroy(gameObject);
    }

    public void DealDamage(float damage)
    {
        if (damage > 0) Health -= damage;
    }
}
