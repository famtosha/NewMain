using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractebleItem
{   
    [SerializeField] private GameObject InteractbleZone;
    [SerializeField] private AudioClip DoorSound;
    private AudioSource audioSource;
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
            if (DoorSound != null)
            {
                audioSource.PlayOneShot(DoorSound);
            }
        }
    }

    protected override void Start()
    {
        base.Start();
        animator = transform.parent.gameObject.GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void ChangeDoorState()
    {
        IsOpen = !IsOpen;
    }

    public override void UseObj(GameObject interacter)
    {
        ChangeDoorState();
    }

    public override void TouchObj(bool thing)
    {
        if (thing)
        {
            textMesh.text = "B";
        }
        else
        {
            textMesh.text = "";
        }
    }
}
