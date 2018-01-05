using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Message;
using System;
using UnityEngine;

namespace Demo_0
{
    public class SaveByte : MonoBehaviour
    {
        byte[] bytearr = new byte[] { 255, 00, 11, 00, 10, 00, 10, 00, 10, 10, 10, 10, 10, 10, 10, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255 };

        const string appdatapath = @"C:/Users/EZEnjoy03/Desktop/work/qldj_master/Client/Assets/_Demo/ByteSaves/";
        public static void SaveBytesToTxt(string fileName, byte[] bytearr)
        {
            //string path = DemoConfig.BytesTxtSavePath + fileName + ".txt";  非主线程不可调用 application.datapath
            string path = appdatapath + fileName + ".txt";

            if (File.Exists(path))
            {
                File.Delete(path);
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bytearr.Length; i++)
            {
                sb.Append(bytearr[i].ToString("D4") + "|");
            }
            string save = sb.ToString().TrimEnd('|');
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            sw.Write(save);
            sw.Close();
            fs.Close();
        }

        public static byte[] ReadBytesToTxt(string fileName)
        {
            string path = appdatapath + fileName + ".txt";
            if (!File.Exists(path))
            {
                Debug.LogError("文件不存在");
                return null;
            }

            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);
            string[] strArr = sr.ReadToEnd().Split('|');
            sr.Close();
            fs.Close();
            byte[] bytes = new byte[strArr.Length];
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Byte.Parse(strArr[i]);
            }
            return bytes;
        }

        //public void Start()
        //{
        //    SaveBytesToTxt("test", bytearr);
        //}

        public void Start()
        {
            byte[] a = ReadBytesToTxt("BattlePrepareInit");
        }
    }
}