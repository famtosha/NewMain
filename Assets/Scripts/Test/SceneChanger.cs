using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            print("Load Scene Change");
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(instance);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            SceneLoader.instance.LoadScene(1);
            print("change Scene to: " + 1);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneLoader.instance.LoadScene(0);
            print("change Scene to: " + 0);
        }
    }
}
