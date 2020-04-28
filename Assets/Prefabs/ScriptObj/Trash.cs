using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : Item
{
    private void Start()
    {
        ItemDataCurrend = Instantiate(ItemDataOrigin);
    }
}
