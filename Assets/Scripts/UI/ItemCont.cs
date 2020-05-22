using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCont : MonoBehaviour
{
    private Text ItemName;
    private Text ItemDiscr;

    private void Start()
    {
        ItemName = transform.GetChild(0).GetComponent<Text>();
        ItemDiscr = transform.GetChild(1).GetComponent<Text>();
    }

    public void Upadate(string Name, string ItemDis)
    {
        ItemName.text = Name;
        ItemDiscr.text = ItemDis;
    }
}
