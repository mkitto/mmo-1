using Common.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapTools
{

    [MenuItem("MapTools/Export Teleporters")]
    public static void ExportTeleporters()
    {
        DataManager.Instance.Load();

        Scene current = EditorSceneManager.GetActiveScene();
        string currentScene = current.name;
        if (current.isDirty)
        {
            EditorUtility.DisplayDialog("提示", "请先保存当前场景", "确定");
            return;
        }

        List<TelepoterObject> allTeleporters = new List<TelepoterObject>();

        foreach (var map in DataManager.Instance.Maps)
        {
            string sceneFile = "Assets/Levels/" + map.Value.Resource + ".unity";
            EditorUtility.DisplayDialog("提示", "111111111111111", "确定");
            if (!System.IO.File.Exists(sceneFile))
            {
                EditorUtility.DisplayDialog("提示", "3333333333333", "确定");
                Debug.LogWarningFormat("Scene {0} not existed!", sceneFile);
                continue;
            }
            EditorUtility.DisplayDialog("提示", "22222222222222", "确定");
            EditorSceneManager.OpenScene(sceneFile, OpenSceneMode.Single);

            TelepoterObject[] telepoters = GameObject.FindObjectsOfType<TelepoterObject>();
            EditorUtility.DisplayDialog("提示", telepoters.Length.ToString(), "确定");
            foreach (var teleporter in telepoters)
            {
                if (!DataManager.Instance.Teleporters.ContainsKey(teleporter.ID))
                {
                    EditorUtility.DisplayDialog("错误", string.Format("地图: {0} 中配置的Teleporter: [{1}] 中不存在", map.Value.Resource, teleporter.ID), "确定");
                    return;
                }

                TeleporterDefine def = DataManager.Instance.Teleporters[teleporter.ID];
                if (def.MapID != map.Value.ID)
                {
                    EditorUtility.DisplayDialog("错误", string.Format("地图: {0} 中配置的Teleporter:[{1}] MapID: {2} 错误", map.Value.Resource, teleporter.ID, def.MapID), "确定");
                    return;
                }
                def.Position = GameObjectTool.WorldToLogicN(teleporter.transform.position);
                def.Direction = GameObjectTool.WorldToLogicN(teleporter.transform.forward);
                EditorUtility.DisplayDialog("提示", string.Format("x: {0}, y: {1}, z: {2}", def.Position.X, def.Position.Y, def.Position.Z), "确定");
            }
        }
        DataManager.Instance.SaveTeleporters();
        EditorSceneManager.OpenScene("Assets/Levels/" + currentScene + ".unity");
        EditorUtility.DisplayDialog("提示", "传送点导出完成", "确定");
    }
}
