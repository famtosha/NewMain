using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMan : MonoBehaviour
{
    public static GameMan instance = null;
    public GameObject Player;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //print("Load Scene Change");
        }
        else
        {
            Destroy(gameObject);
        }
        Player = gameObject;
    }

}
