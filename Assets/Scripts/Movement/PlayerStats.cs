using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PlayerStats : Target
{
    private float _health;
    private float _hunger;
    private float _thirst;

    public float Temperature { get; set; }
    public float Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health += value;
            if(_health < 0)
            {
                PlayerDeath("eat some shit");
            }
        }
    }
    public float Hunger
    {
        get
        {
            return _hunger;
        }
        set
        {
            _hunger += value;
            if (_hunger < 0)
            {
                _hunger = 0;
            }
        }
    }
    public float Thirst
    {
        get
        {
            return _thirst;
        }
        set
        {
            _thirst += value;
            if (_thirst < 0)
            {
                _thirst = 0;
            }
        }
    }

    private void PlayerDeath(string Reason)
    {
        gameObject.GetComponent<InvenotryUI>().UIManager.EnableDeathMenu();
        Destroy(gameObject);
    }
}
