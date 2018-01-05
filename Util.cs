using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour {

    /// <summary>
    /// 将opbtn的string 转换为可被unityInput识别的string[] ,
    /// true 表示有至少一个 validKey
    /// </summary>
    /// <param name="keyStr"></param>
    /// <param name="validKeys"></param>
    /// <returns></returns>
    public static bool StringToCorrectKeyStrs(string keyStr,out string[] validKeys)
    {
        if (string.IsNullOrEmpty(keyStr))
        {
            validKeys = null;
            return false;
        }
        else
        {
            validKeys = keyStr.ToLower().Replace("enter", "return").Split(',');
            if (validKeys.Length > 0)
                return true;
            else
                return true;
        }
    }

    /// <summary>
    /// 等待按下按键或时间到达后跳出
    /// </summary>
    /// <param name="keyStr">按键列表的string，用','分割</param>
    /// <param name="duration">持续时间</param>
    /// <param name="callback">回调</param>
    /// <returns></returns>
    public static IEnumerator WaitKeyDownOrTimeOut(string keyStr, float duration, System.Action<string> callback = null)
    {
        //跳过一帧，防止跳过前边屏的按键操作导致马上出现的该屏也跳过
        yield return null;

        string[] keys;
        StringToCorrectKeyStrs(keyStr, out keys);
        bool jumpOut = false;
        float endTime = Time.time + duration;

        while (true)
        {
            for (int i = 0; i < keys.Length; i++)
            {
                if (Input.GetKeyDown(keys[i]))
                {
                    if (callback != null)
                        callback(keys[i]);
                    jumpOut = true;
                    break;
                }
            }

            if (Time.time > endTime || jumpOut)
            {
                if (callback != null)
                    callback("");
                break;
            }
            yield return null;
        }
    }

    public static IEnumerator WaitKeyDownOrTimeOut(KeyCode[] keys, float duration, System.Action<KeyCode> callback = null)
    {
        yield return null;

        float endTime = Time.time + duration;

        bool loop = true;
        while (loop)
        {
            for (int i = 0; i < keys.Length; i++)
            {
                if (Input.GetKeyDown(keys[i]))
                {
                    if (callback != null)
                    {
                        callback(keys[i]);
                    }
                    loop = false;
                }
            }

            if (Time.time > endTime)
            {
                if (callback != null)
                {
                    callback(KeyCode.None);
                }
                loop = false;
            }

            yield return null;
        }
    }
}
