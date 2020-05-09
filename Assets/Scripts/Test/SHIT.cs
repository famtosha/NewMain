using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHIT : MonoBehaviour
{
    public void DrawShit()
    {
        Vector2 Start = transform.position;
        Vector2 MainDirect = transform.up;

        for (int i = 0; i < 30; i++)
        {
            Vector2 Direct = MainDirect + new Vector2(i, i);
            Debug.DrawLine(Start, Direct, Color.red, 100);
        }
    }

    int x = -100;
    int y = -100;

    private void Update()
    {
        Vector2 Start = transform.position;
        Vector2 MainDirect = transform.up;

        Vector2 XDirect = MainDirect + new Vector2(x, 0);
        Debug.DrawLine(Start, Start + XDirect, Color.red, 100);

        Vector2 YDirect = MainDirect + new Vector2(0, y);
        Debug.DrawLine(Start, Start + YDirect, Color.blue, 100);

        Vector2 XYDirect = MainDirect + new Vector2(x, y);
        Debug.DrawLine(Start, Start +XYDirect, Color.green, 100);

        x++;
        y++;
    }
}
