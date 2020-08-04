using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR

[CanEditMultipleObjects]
[CustomEditor(typeof(MattersTile))]

public class MattersTileEditor : Editor
{
    private MattersTile tile
    {
        get { return (target as MattersTile); }
    }

    public override Texture2D RenderStaticPreview(string assetPath, Object[] subAssets, int width, int height)
    {
        if(tile.sprite != null)
        {
            Sprite sprite = tile.sprite;
            Texture2D result = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);

            int startX = (int)sprite.rect.x;
            int startY = (int)sprite.rect.y;
            int endX = (int)sprite.rect.width;
            int endY = (int)sprite.rect.height;
            Color[] shit = tile.sprite.texture.GetPixels(startX, startY, endX, endY);
            result.SetPixels(shit);
            result.Apply();
            return result;
        }
        return new Texture2D(100,100);
    }
}

#endif