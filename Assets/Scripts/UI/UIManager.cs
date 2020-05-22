using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            print("Load SceneLoader");
        }
        else
        {
            Destroy(gameObject);
        }

        //DontDestroyOnLoad(gameObject);
    }


    public CanvasGroup canvasGroup;

    public GameObject PauseMenu;
    public GameObject BackPackMenu;
    public GameObject HotBar;
    public GameObject ItemContexMenu;
    public GameObject AnotherInventoryMenu;
    public GameObject DeathMenu;

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

    public void MakeEvent(Action action)
    {
        action?.Invoke();
    }

    private void Start()
    {
        HotBar.GetComponent<Canvas>().enabled = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsBackPackOpen)
            {
                ChangeBackPackMenu();
            }
            else
            {
                if (!IsAnotherInventoryMenuOpen)
                {
                    ChangePausemenuState();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.I)) ChangeBackPackMenu();
    }

    public void CloseEveryThing()
    {
        DisableBackPackMenu();
        DisableAnotherInventoryMenu();
    }

    public void DisableDeathMenu()
    {
        DeathMenu.GetComponent<Canvas>().enabled = false;
    }

    public void EnableDeathMenu()
    {
        DeathMenu.GetComponent<Canvas>().enabled = true;
    }

    public void DisablePauseMenu()
    {
        PauseMenu.GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1;
    }

    public void EnablePauseMenu()
    {
        PauseMenu.GetComponent<Canvas>().enabled = true;
        Time.timeScale = 0f;
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
