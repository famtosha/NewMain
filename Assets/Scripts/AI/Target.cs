using System;
using System.Collections;
using System.Collections.Generic;
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
        get
        {
            return _health;
        }
        set
        {
            _health = value;
            if(_health <= 0)
            {
                if(OnDeath != null)
                {
                    OnDeath();
                }
            }
        }
    }

    virtual protected void Death()
    {
        Destroy(gameObject);
    }

    public void DealDamage(float Damage)
    {
        if (Damage > 0) Health -= Damage;
    }
}
