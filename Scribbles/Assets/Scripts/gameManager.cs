using UnityEditor;
using UnityEngine;

public static class GameManager
{
    public static int playerDamage = 50;

    public static string lastSceneExited = "menuScene";
    public static string lastSceneEntered = "menuScene";
    public static bool completedScene = true;

    public static Vector2 position = new Vector2(78f, -1.7f);

    public static float musicVolume = 0.35f;
    public static float SFXVolume = 0.5f;
}

