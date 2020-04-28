using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    [SerializeField]MeshRenderer Mesh;
    public Transform CameraTransform;

    Color GetPixelColor(Vector3 Pos)
    {
        if (Physics.Raycast(Pos, Vector3.forward, out RaycastHit Hit, Mathf.Infinity))
        {
            var Thing = Hit.transform.gameObject;
            var textCord = Hit.textureCoord;
            var Color = Thing.GetComponent<Renderer>().material.color;
            Debug.Log(Color.r);
            Debug.Log(Color.g);
            Debug.Log(Color.b);
            return Color;
            
        }
        Debug.Log("nothing");
        return Color.black;
    }

    Texture2D MakeTexture(int width,int hiegh)
    {
        Texture2D MyTexture = new Texture2D(width, hiegh);
        for (int i = 0; i < width; i++)
        {
            for (int u = 0; u < hiegh; u++)
            {
                MyTexture.SetPixel(i, u, GetPixelColor(new Vector3(i, u)));
            }
        }
        return MyTexture;
    }

    private void Start()
    {
        Mesh.material.mainTexture = MakeTexture(100, 100);
    }

}
