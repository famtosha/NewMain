using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffDB : MonoBehaviour
{
    private static Dictionary<BuffType, BuffAffect> buffDict = new Dictionary<BuffType, BuffAffect>()
    {
        { BuffType.Poison,new BuffAffect(0.04f,0.03f,0.05f,0.010f,0) },
        { BuffType.Cold,new BuffAffect(0.06f,0.010f,0,0,0) },
        { BuffType.Hunger,new BuffAffect(0.02f,0.03f,0,0,0.05f) },
        { BuffType.Hot,new BuffAffect(0.02f,0.03f,0.05f,0.010f,0) }
    };

    public static Buff CreateBuff(BuffType buffType, float duration)
    {
        return new Buff(buffType, buffDict[buffType], duration);
    }

    public static Buff CreateRandomBuff(float duration)
    {
        var t = (BuffType)Random.Range(0, buffDict.Count);
        return new Buff(t, buffDict[t], duration);
    }
}