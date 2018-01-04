using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

namespace Anty
{
        public class ALoad : MonoBehaviour
        {
                public static Sprite LoadSprite(string path, float width = -1, float height = -1)
                {
                        if (File.Exists(path))
                        {
                                Texture2D texture = LoadTexture2D(path);
                                if (width < 0)
                                        width = texture.width;
                                if (height < 0)
                                        height = texture.height;
                                Sprite sprite = Sprite.Create(
                                        texture,
                                        new Rect(0, 0, width, height),
                                        Vector2.zero
                                        );
                                return sprite;
                        }
                        Debug.Log("SPRITE  LOAD FAILE  ==> Path  " + path);
                        return null;
                }

                public static Texture2D LoadTexture2D(string path)
                {
                        if (File.Exists(path))
                        {
                                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                                BinaryReader br = new BinaryReader(fs);
                                byte[] bytes = br.ReadBytes((int)fs.Length);
                                byte[] reverseWidthBytes = new byte[4];
                                byte[] reverseHeightBytes = new byte[4];
                                Array.Copy(bytes, 16, reverseWidthBytes, 0, 4);
                                Array.Copy(bytes, 20, reverseHeightBytes, 0, 4);
                                Array.Reverse(reverseWidthBytes);
                                Array.Reverse(reverseHeightBytes);
                                int width = BitConverter.ToInt32(reverseWidthBytes, 0);
                                int height = BitConverter.ToInt32(reverseHeightBytes, 0);
                                Debug.Log(string.Format("{0:x8}", width));
                                Texture2D texture = new Texture2D(width, height);
                                texture.LoadImage(bytes);
                                br.Close();
                                fs.Close();
                                return texture;
                        }
                        Debug.Log("TEXTURE2D  LOAD FAILE  ==> Path  " + path);
                        return null;
                }

                void Start()
                {
                        GetComponent<UnityEngine.UI.Image>().sprite = LoadSprite(Application.dataPath + "/image.png");
                        GetComponent<UnityEngine.UI.Image>().SetNativeSize();
                }
        }

        public class PictureInfo
        {
                
        }

        public enum PictureType
        {
                PNG,    //89 50 4E 47 0D 0A 1A 0A
                JPG,    //42 4D
                BMP
        }
}