using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float _health = 100;

    private float Health
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
                Death();
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
