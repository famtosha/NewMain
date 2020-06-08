using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCont : MonoBehaviour
{
    private Text itemInfo;
    public GameObject TargetNow = null;
    public bool IsEnable = false;

    private void Start()
    {
        itemInfo = gameObject.GetComponent<Text>();
    }

    public void UpdateInfo(string Name, string ItemDis)
    {
        itemInfo.text = Name + "\n" + ItemDis;
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
            transform.position = Input.mousePosition + new Vector3(65, -60, 0);
            if (TargetNow != null)
            {
                var TargetInfo = TargetNow.GetComponent<Item>();
                UpdateInfo(TargetInfo.Name, TargetInfo.GetInfo());
            }
        }
    }
}
