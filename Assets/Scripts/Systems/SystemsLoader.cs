using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemsLoader : MonoBehaviour
{
    public static SystemsLoader instance = null;
    public bool IsMain = false;
    private bool IsReady = false;

    public GameObject uiManager = null;
    public GameObject itemDB = null;
    public GameObject itemSpawner = null;
    public GameObject sceneLoader = null;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            var another = FindObjectOfType<SystemsLoader>();
            if (another != null)
            {
                if (another.IsMain)
                {
                    Destroy(gameObject);
                }
                else
                {
                    IsMain = true;
                }
            }
            else
            {
                IsMain = true;
            }
            PrepareSystem();
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void PrepareSystem()
    {
        if (!IsReady)
        {
            InitSystems();
            IsReady = true;
        }
    }

    private void InitSystems()
    {
        uiManager = Instantiate(uiManager);
        DontDestroyOnLoad(uiManager);

        itemDB = Instantiate(itemDB);
        DontDestroyOnLoad(itemDB);

        itemSpawner = Instantiate(itemSpawner);
        DontDestroyOnLoad(itemSpawner);

        sceneLoader = Instantiate(sceneLoader);
        DontDestroyOnLoad(sceneLoader);
    }
}
