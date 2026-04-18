using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerHealth : MonoBehaviour
{
    
    public int health;
    private int maxHealth;
    [SerializeField]
    private healthBar healthBar;
    void Start()
    {
        maxHealth = health;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {

        if (Keyboard.current.jKey.wasPressedThisFrame)
        {
            health-=10;
        }
        if (Keyboard.current.kKey.wasPressedThisFrame)
        {
            health+=10;
        }

        Console.Write(health);
        healthBar.SetHealth(health);
        if(health <= 0)
        {
            Debug.Log("Died");
        }
    }
}
