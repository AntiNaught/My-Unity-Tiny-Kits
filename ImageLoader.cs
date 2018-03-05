using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageLoader : MonoBehaviour
{
    private static Dictionary<string,Sprite> spritesLoaded=new Dictionary<string, Sprite>();

    /// <summary>
    /// 加载图片后会将图片缓存以来，直到被清
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static Sprite LoadSprite(string path)
    {
        if (spritesLoaded.ContainsKey(path))
            return spritesLoaded[path];

        Sprite res = Resources.Load<Sprite>(path);
        spritesLoaded.Add(path,res);
        if (res == null)
            Demo_0.ALogger.LogToFile("LackImage", path);

        return res;
    }

    public static void RemoveCacheSprite(string path)
    {
        if(spritesLoaded.ContainsKey(path))
            spritesLoaded.Remove(path);
    }

    public static void ClearSpriteCache()
    {
        spritesLoaded.Clear();
    }
}
