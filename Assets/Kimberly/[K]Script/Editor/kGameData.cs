using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class kGameData : EditorWindow
{
    public GameData gameData;

    private string gameDataProjectFilePath = "/Data/Game.gd";
    [MenuItem("Window/Game Data Editor")]
    static void Init()
    {
        kGameData window = (kGameData)EditorWindow.GetWindow(typeof(kGameData));
        window.Show();
        //EditorWindow.GetWindow(typeof(kGameData)).Show();
    }

    private void OnGUI()
    {
        if (gameData != null)
        {
            SerializedObject so = new SerializedObject(this);
            SerializedProperty sp = so.FindProperty("GameData");

            EditorGUILayout.PropertyField(sp, true);

            so.ApplyModifiedProperties();

            if (GUILayout.Button("Save"))
            {
                Save();
            }
        }
        if(GUILayout.Button("Load"))
        {
            Load();
        }
    }

    private void Load()
    {
        string filePath = Application.dataPath + gameDataProjectFilePath;
        if( File.Exists(filePath))
        {
            string data = File.ReadAllText(filePath);
            gameData = JsonUtility.FromJson<GameData>(data);
        }
        else
        {
            gameData = new GameData();
        }
    }

    private void Save()
    {
        string save = JsonUtility.ToJson(gameData);
        string filePath = Application.dataPath + gameDataProjectFilePath;
        File.WriteAllText(filePath, save);
    }
  
}
