using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Image ItemSprite;
    public InventoryUI BackPackUI;
    public Text Text;
    public Image BackGround;

    public int ID;

    public void UpdateData(ItemData trashData)
    {
        if(trashData == null)
        {
            ItemSprite.sprite = null;
            Text.text = "";
        }
        else
        {
            if (trashData.SpriteInWorld != null) ItemSprite.sprite = trashData.SpriteInWorld;
            if (trashData.Count > 1)
            {
                Text.text = trashData.Count.ToString();
            }
            else
            {
                Text.text = "";
            }
        }
    }  

    public void Drop()
    {
        BackPackUI.DropItem(ID);
    }

    public void ChangeColor(Color color)
    {
        BackGround.color = color;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        BackPackUI.LeftClick(ID);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (UIManager.instance == null) return;

        UIManager.instance.EnableItemContexMenu();
        UIManager.instance.ItemContexMenu.transform.position = Input.mousePosition + new Vector3(120,-40,0);
        var item = BackPackUI.inventory.GetSlotInfo(ID);
        if(item != null)
        {
            var x = item.GetComponent<Item>();
            UIManager.instance.ItemContexMenu.GetComponent<ItemCont>().Upadate(x.Name, x.GetInfo());
        }
        else
        {
            UIManager.instance.ItemContexMenu.GetComponent<ItemCont>().Upadate("", "");
        }     
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (UIManager.instance == null) return;
        UIManager.instance.DisableItemContexMenu();
    }
}
