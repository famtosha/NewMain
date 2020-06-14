using UnityEngine;

public class Door : InteractebleItem
{
    [SerializeField] private GameObject InteractbleZone = null;
    private Animator animator;

    private bool _isOpen = false;

    public bool IsOpen
    {
        get
        {
            return _isOpen;
        }
        set
        {
            _isOpen = value;
            animator.SetBool("IsOpen", value);
        }
    }

    protected override void Start()
    {
        base.Start();
        animator = transform.parent.gameObject.GetComponent<Animator>();
    }

    private void ChangeDoorState()
    {
        IsOpen = !IsOpen;
    }

    public override void UseObj(GameObject interacter)
    {
        base.UseObj(interacter);
        ChangeDoorState();
    }

    public override void TouchObj(bool thing)
    {
        if (thing)
        {
            textMesh.text = "E";
        }
        else
        {
            textMesh.text = "";
        }
    }
}
