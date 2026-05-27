using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{

    public int health;
    private int maxHealth;
    [SerializeField]
    public healthBar healthBar;
    public gameOver gameOver;
    private bool died = false;
    void Start()
    {
        maxHealth = health;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
  
        if (Keyboard.current.kKey.wasPressedThisFrame)
        {
            health = 0;
        }

        Console.Write(health);
        healthBar.SetHealth(health);
        if (health <= 0)
        {
            if(died) return;
            gameOver.SetUp();
            died = true;
            Time.timeScale = 0;
        }
    }
}
