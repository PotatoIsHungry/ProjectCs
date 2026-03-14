using UnityEngine;
using UnityEngine.Events;

public class ShootingAction : MonoBehaviour
{
    public UnityEvent action;
    public int maxHP = 100;
    private int currentHP;
    private int damage;

    void Start()
    {
        damage = GameManager.Instance.playerDamage;
        currentHP = maxHP;
    }
    public void Action()
    {
        currentHP -= damage;

        if (currentHP <= 0)
        {
            action?.Invoke();
        }
    }
}
