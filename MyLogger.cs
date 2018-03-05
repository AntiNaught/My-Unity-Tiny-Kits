using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

namespace Demo_0
{
        public class ALogger : MonoBehaviour
        {
                static string logPath = Application.dataPath.Replace("/Assets", "") + "/LogFile/";
                const string defaultFile = "MyLog.txt";
                public static void LogToFile(string logHead, string logBody, string fileName = defaultFile)
                {
                        StreamWriter sw;
                        StreamReader sr;
                        FileStream fs = null;
                        string path = logPath + defaultFile;
                        if (!File.Exists(path))
                        {
                                sw = File.CreateText(path);
                        }
                        else
                        {
                                fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
                                sw = new StreamWriter(fs, Encoding.UTF8);
                        }
                        sr = new StreamReader(fs);
                        string origin = sr.ReadToEnd();
                        sw.WriteLine(/*origin+*/"\n" + "Head :: " + logHead + "------ >" + " Body :: " + logBody);
                        sw.Close();
                        if (fs != null)
                                fs.Close();
                }
        }
}