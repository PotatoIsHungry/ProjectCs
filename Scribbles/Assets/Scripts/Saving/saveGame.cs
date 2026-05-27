using System.IO;
using UnityEngine;

public static class SaveSystem
{
    private static string path = Application.persistentDataPath + "/save.json";

    public static void SaveGame()
    {
        SaveData data = new SaveData();

        data.playerDamage = GameManager.playerDamage;

        data.lastSceneExited = GameManager.lastSceneExited;
        data.lastSceneEntered = GameManager.lastSceneEntered;

        data.completedScene = GameManager.completedScene;

        data.positionX = GameManager.position.x;
        data.positionY = GameManager.position.y;

        string json = JsonUtility.ToJson(data, true);

        File.WriteAllText(path, json);

        Debug.Log("Game Saved");
    }

    public static void LoadGame()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            GameManager.playerDamage = data.playerDamage;

            GameManager.lastSceneExited = data.lastSceneExited;
            GameManager.lastSceneEntered = data.lastSceneEntered;

            GameManager.completedScene = data.completedScene;

            GameManager.position = new Vector2(data.positionX, data.positionY);

            Debug.Log("Game Loaded");
        }
        else
        {
            Debug.Log("No save file found");
        }
    }
}