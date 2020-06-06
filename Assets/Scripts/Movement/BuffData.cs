using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffAffect
{
    public float speed = 0;
    public float health = 0;
    public float hunger = 0;
    public float water = 0;
    public float temperature = 0;

    public BuffAffect(float speed, float health, float hunger, float water, float temperature)
    {
        this.speed = speed;
        this.health = health;
        this.hunger = hunger;
        this.water = water;
        this.temperature = temperature;
    }
}
