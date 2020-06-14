using System;
using System.Collections;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;

    public UIPanel pauseMenu;
    public UIPanel backPackMenu;
    public UIPanel hotBar;
    public UIPanel itemContexMenu;
    public UIPanel anotherInventoryMenu;
    public UIPanel deathMenu;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        hotBar.GetComponent<Canvas>().enabled = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (backPackMenu.isPanelEnable)
            {
                backPackMenu.ChangePanelState();
            }
            else
            {
                if (!anotherInventoryMenu.isPanelEnable)
                {
                    if (pauseMenu.isPanelEnable)
                    {
                        UnPause();
                    }
                    else
                    {
                        Pause();
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.I)) backPackMenu.ChangePanelState();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void CloseEveryThing()
    {
        backPackMenu.DisablePanel();
        backPackMenu.DisablePanel();
    }
    public void EnableDeathMenu()
    {
        deathMenu.EnablePanel();

        StartCoroutine(Lose());
        IEnumerator Lose()
        {
            yield return new WaitForSeconds(1f);
            SceneLoader.instance.RestartScene();
        }
    }

    public void Pause()
    {
        pauseMenu.EnablePanel();
        Time.timeScale = 0f;
    }

    public void UnPause()
    { 
        pauseMenu.DisablePanel();
        Time.timeScale = 1f;
    }
}