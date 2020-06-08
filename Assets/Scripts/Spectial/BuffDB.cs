using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffDB : MonoBehaviour
{
    private static Dictionary<BuffType, BuffAffect> buffDict = new Dictionary<BuffType, BuffAffect>()
    {
        { BuffType.Poison,new BuffAffect(0f,3f,5f,1f,0) },
        { BuffType.Cold,new BuffAffect(0f,2f,0,0,0) },
        { BuffType.Hunger,new BuffAffect(0f,3f,0,0,5f) },
        { BuffType.Flu,new BuffAffect(0f,3f,5f,10f,0) },
        { BuffType.Vodka,new BuffAffect(0,3,0,0,0) }

    };

    public static Buff CreateBuff(BuffType buffType, float duration, bool isRemoveByTime)
    {
        return new Buff(buffType, buffDict[buffType], duration, isRemoveByTime);
    }
}