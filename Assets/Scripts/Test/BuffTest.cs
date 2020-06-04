using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffTest : MonoBehaviour
{
    List<Buff> buffs = new List<Buff>() {
        new Buff("GANAREYA",99),
        new Buff("PAK",82),
        new Buff("SPID",31),
        new Buff("MINECRAFT",66),
        new Buff("GANAREYA",9)
    };
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            GameMan.instance.Player.GetComponent<PlayerStats>().AddBuff(buffs[Random.Range(0, buffs.Count)]);
        }
    }
}
