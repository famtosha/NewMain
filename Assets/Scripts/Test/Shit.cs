using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shit : MonoBehaviour
{
    [SerializeField] private int StartPos;
    [SerializeField] private int EndPos;
    [SerializeField] private GameObject Item;

    private void Start()
    {
        Generate();
    }

    private void Generate()
    {
        for (int x = 0; x < EndPos - StartPos; x++)
        {
            for (int y = 0; y < EndPos - StartPos; y++)
            {
                var num = Random.Range(0, 10);
                if (num > 8)
                {
                    Instantiate(Item, new Vector3(StartPos + x, StartPos + y), new Quaternion());
                }
            }
        }
    }
}
