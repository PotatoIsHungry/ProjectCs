using UnityEngine;

public class playerHealth : MonoBehaviour
{
    
    public int health;
    private int maxHealth;
    void Start()
    {
        maxHealth = health;
    }

    void Update()
    {
        if(health <= 0)
        {
            Debug.Log("Died");
        }
    }
}
