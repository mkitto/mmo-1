using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Level))]
public class LevelEditor : Editor {

	Level level;

	Vector2 scrollPos;

    // 自定义对Inspector面板的绘制
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        level = target as Level;
        OnRulesGUI(level);
    }

    void OnRulesGUI(Level level)
    {
        GUILayout.Label("Rules: ");
        /*
         *  垂直的控件
         */
        GUILayout.BeginVertical();
        for(int i = 0; i < level.Rules.Count; i++)
        {
            EditorGUILayout.ObjectField(level.Rules[i].Monster, typeof(Unit));
        }
        GUILayout.EndVertical();
        /*
         *  添加按钮
         */
        if(GUILayout.Button("Add Rule"))
        {
            level.Rules.Add(new SpawnRule());
        }
    }
}
