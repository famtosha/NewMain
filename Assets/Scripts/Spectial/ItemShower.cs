using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShower : MonoBehaviour
{
    public GameObject ItemToShow;
    public GameObject ArmPos;

    public void ShowItem(GameObject Item)
    {
        if (ItemToShow != null) HideItem();
        if (Item)
        {
            ItemToShow = Item;
            ItemToShow.gameObject.SetActive(true);
            ItemToShow.transform.position = ArmPos.transform.position;
            ItemToShow.gameObject.transform.rotation = ArmPos.transform.rotation;
            ItemToShow.GetComponent<BoxCollider2D>().enabled = false;
            ItemToShow.gameObject.transform.Rotate(0, 0, 90);
            ItemToShow.GetComponent<Item>().EquipItem();
        }       
    }

    public void HideItem()
    {
        if (ItemToShow != null)
        {
            ItemToShow.gameObject.SetActive(false);
            ItemToShow.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
