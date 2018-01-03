using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Anty
{
        public class LoadImage : MonoBehaviour
        {
                public static Sprite LoadSprite(string path, float width, float height)
                {
                        if (File.Exists(path))
                        {
                                Sprite sprite = Sprite.Create(LoadTexture2D(path), new Rect(0, 0, width, height), Vector2.zero);
                                return sprite;
                        }
                        Debug.Log("Texture2D LOAD FAILE  ==> Path  " + path);
                        return null;
                }

                public static Texture2D LoadTexture2D(string path)
                {
                        if (File.Exists(path))
                        {
                                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                                BinaryReader br = new BinaryReader(fs);
                                byte[] bytes = br.ReadBytes((int)fs.Length);
                                Texture2D texture = new Texture2D(960, 640);
                                texture.LoadImage(bytes);
                                br.Close();
                                fs.Close();
                                return texture;
                        }
                        Debug.Log("Texture2D LOAD FAILE  ==> Path  " + path);
                        return null;
                }

                void Start()
                {
                        GetComponent<UnityEngine.UI.Image>().sprite = LoadSprite(Application.dataPath + "/image.png", 200, 200);
                }
        }
}