using UnityEngine;
using UnityEngine.UI;

public class ItemCont : MonoBehaviour
{
    public GameObject TargetNow = null;
    public bool IsEnable = false;

    private Text itemInfo;

    private void Start()
    {
        itemInfo = gameObject.GetComponent<Text>();
    }

    public void UpdateInfo(string name, string itemDiscription)
    {
        itemInfo.text = name + "\n" + itemDiscription;
    }

    public void Enable(GameObject target)
    {
        IsEnable = true;
        TargetNow = target;
        UIManager.instance.itemContexMenu.EnablePanel();
    }

    public void Disable()
    {
        IsEnable = false;
        TargetNow = null;
        UpdateInfo("", "");
        UIManager.instance.itemContexMenu.DisablePanel();
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
