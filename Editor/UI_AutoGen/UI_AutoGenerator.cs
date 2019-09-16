using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class UI_AutoGenerator : EditorWindow
{
    [MenuItem("Anty/Open Window -> UI GEN")]
    private static void OpenWindow_UIGenerator()
    {
        UI_AutoGenerator window = EditorWindow.GetWindow<UI_AutoGenerator>();
    }


    private void ShowSelectionInfo()
    {
        Object obj = Selection.activeObject;
        GUILayout.Label("当前选择" + obj.name);
    }

    private void OnGUI()
    {
        GUILayout.Label("卧槽，GUILayout.Label");
        if (GUILayout.Button("开始生成",GUILayout.Width(200)))
        {
            ShowSelectionInfo();
        }
    }

    private void OnSelectionChange()
    {
        ShowSelectionInfo();
        Repaint();
    }
}