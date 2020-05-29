using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCont : MonoBehaviour
{
    private Text ItemName;
    private Text ItemDiscr;
    public GameObject TargetNow = null;
    public bool IsEnable = false;

    private void Start()
    {
        ItemName = transform.GetChild(0).GetComponent<Text>();
        ItemDiscr = transform.GetChild(1).GetComponent<Text>();
    }

    public void UpdateInfo(string Name, string ItemDis)
    {
        ItemName.text = Name;
        ItemDiscr.text = ItemDis;
    }

    public void Enable(GameObject Target)
    {
        IsEnable = true;
        TargetNow = Target;
        UIManager.instance.EnableItemContexMenu();    
    }

    public void Disable()
    {
        IsEnable = false;
        TargetNow = null;
        UpdateInfo("", "");
        UIManager.instance.DisableItemContexMenu();
    }

    private void Update()
    {
        if (IsEnable)
        {
            transform.position = Input.mousePosition + new Vector3(140, -40, 0);
            if (TargetNow != null)
            {
                var TargetInfo = TargetNow.GetComponent<Item>();
                UpdateInfo(TargetInfo.Name, TargetInfo.GetInfo());
            }
        }
    }
}
