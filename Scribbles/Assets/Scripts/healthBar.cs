using System;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    private int health, maxHealth;
    private float width = 1455;
    private float height = 250;

    [SerializeField]
    public RectTransform bar;

    public void SetMaxHealth(int maxHp)
    {
        maxHealth = maxHp;
    }

    public void SetHealth(int hp)
    {
        health = hp;
        float newWidth = ((float)health/maxHealth)*width;
        Console.Write(newWidth);
        bar.sizeDelta = new Vector2(newWidth, height);
    }
}
