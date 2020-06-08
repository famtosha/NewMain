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
        var x = BackPackUI.inventory.GetSlotInfo(ID);
        UIManager.instance.ItemContexMenu.GetComponent<ItemCont>().Enable(x);     
    }

    public void OnPointerExit(PointerEventData eventData)
    {

        UIManager.instance.ItemContexMenu.GetComponent<ItemCont>().Disable();
    }
}
