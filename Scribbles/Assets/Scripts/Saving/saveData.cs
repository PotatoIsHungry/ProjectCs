using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int playerDamage;

    public string lastSceneExited;
    public string lastSceneEntered;

    public bool completedScene;

    public float positionX;
    public float positionY;
}