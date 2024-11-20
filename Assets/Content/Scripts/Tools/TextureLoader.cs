using UnityEngine;
using System.IO;

public static class SpriteLoader
{
    public static Sprite LoadSprite(string path)
    {
        string fullpath = $"{Application.streamingAssetsPath}/{path}";
        Texture2D texture = new Texture2D(2, 2);
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

        if (File.Exists(fullpath))
        {
            byte[] fileData = File.ReadAllBytes(fullpath);

            if (texture.LoadImage(fileData))
            {
                sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            }
            else
            {
                Debug.LogError("Error loading sprite");
            }
        }
        else
        {
            Debug.LogError("Sprite path not found " + fullpath);
        }

        return sprite;
    }
}
