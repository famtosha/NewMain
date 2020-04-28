using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCont : MonoBehaviour
{
    public Text ItemName;
    public Text ItemDiscr;

    public void Upadate(string Name, string ItemDis)
    {
        ItemName.text = Name;
        ItemDiscr.text = ItemDis;
    }
}
