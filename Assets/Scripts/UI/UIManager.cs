using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    public GameObject PauseMenu;
    public GameObject BackPackMenu;
    public GameObject HotBar;
    public GameObject ItemContexMenu;
    public GameObject AnotherInventoryMenu;

    public event Action OnPauseMenuOpen;
    public event Action OnPauseMenuClose;

    public event Action OnBackPackMenuOpen;
    public event Action OnBackPackMenuClose;

    public event Action OnHotBarOpen;
    public event Action OnHotBarClose;

    public event Action OnItemContexMenuOpen;
    public event Action OnItemContexMenuClose;

    public event Action OnAnotherInventoryMenuOpen;
    public event Action OnAnotherInventoryMenuClose;

    public bool IsBackPackOpen => BackPackMenu.GetComponent<Canvas>().enabled;
    public bool IsPauseMenuOpen => PauseMenu.GetComponent<Canvas>().enabled;
    public bool IsAnotherInventoryMenuOpen => AnotherInventoryMenu.GetComponent<Canvas>().enabled;

    private void Start()
    {
        HotBar.GetComponent<Canvas>().enabled = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) ChangePausemenuState();
        if (Input.GetKeyDown(KeyCode.I)) ChangeBackPackMenu();
    }

    public void DisablePauseMenu()
    {
        PauseMenu.GetComponent<Canvas>().enabled = false;
        //PauseMenu.SetActive(false);
    }

    public void EnablePauseMenu()
    {
        PauseMenu.GetComponent<Canvas>().enabled = true;
        //PauseMenu.SetActive(true);
    }

    public void ChangePausemenuState()
    {
        if (IsPauseMenuOpen)
        {
            DisablePauseMenu();
        }
        else
        {
            EnablePauseMenu();
        }
    }

    public void DisableAnotherInventoryMenu()
    {
        AnotherInventoryMenu.GetComponent<Canvas>().enabled = false;
    }

    public void EnableAnotherInventoryMenu()
    {
        AnotherInventoryMenu.GetComponent<Canvas>().enabled = true;
    }

    public void DisableBackPackMenu()
    {
        BackPackMenu.GetComponent<Canvas>().enabled = false;
    }

    public void EnableBackPackMenu()
    {
        BackPackMenu.GetComponent<Canvas>().enabled = true;
    }

    public void ChangeBackPackMenu()
    {
        if (IsBackPackOpen)
        {
            DisableBackPackMenu();
        }
        else
        {
            EnableBackPackMenu();
        }
    }

    public void DisableItemContexMenu()
    {
        ItemContexMenu.GetComponent<Canvas>().enabled = false;
    }

    public void EnableItemContexMenu()
    {
        ItemContexMenu.GetComponent<Canvas>().enabled = true;
    }

    public void ChangeItemContexMenu()
    {
        if (IsBackPackOpen)
        {
            DisableItemContexMenu();
        }
        else
        {
            EnableItemContexMenu();
        }
    }
}
