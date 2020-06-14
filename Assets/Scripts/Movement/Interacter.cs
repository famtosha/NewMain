using UnityEngine;

public class Interacter : MonoBehaviour
{
    [SerializeField] private GameObject ItemNowTouch = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var x = collision.gameObject.GetComponent<InteractebleItem>();
        if (x)
        {
            ItemNowTouch = x.gameObject;
            x.TouchObj(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (ItemNowTouch != null)
        {
            if (collision.gameObject == ItemNowTouch)
            {
                ItemNowTouch.GetComponent<InteractebleItem>().TouchObj(false);
                ItemNowTouch = null;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (ItemNowTouch != null)
            {
                ItemNowTouch.GetComponent<InteractebleItem>().UseObj(gameObject.transform.parent.gameObject);
            }
        }
    }
}