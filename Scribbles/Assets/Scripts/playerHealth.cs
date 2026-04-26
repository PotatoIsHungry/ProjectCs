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

        if (Keyboard.current.jKey.wasPressedThisFrame)
        {
            health -= 10;
        }
        if (Keyboard.current.kKey.wasPressedThisFrame)
        {
            health += 10;
        }

        Console.Write(health);
        healthBar.SetHealth(health);
        if (health <= 0)
        {
            if(died) return;
            gameOver.SetUp();
            Debug.Log("Died");
            died = true;
        }
    }
}
