using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, ITarget
{
    [SerializeField] private float _health = 100;
    public event Action Dead;

    private void Start()
    {
        Dead += Death;
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
                if(Dead != null)
                {
                    Dead();
                }
            }
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }

    public void DealDamage(float Damage)
    {
        if (Damage > 0) Health -= Damage;
    }
}
