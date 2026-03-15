using System.Collections;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.Events;

public class ShootingAction : MonoBehaviour
{
    public UnityEvent action;
    private int maxHP = 200;
    private int currentHP;
    private int damage;
    private SpriteRenderer sr;
    Material mat;

    void Start()
    {
        damage = GameManager.Instance.playerDamage;
        currentHP = maxHP;
        sr = GetComponent<SpriteRenderer>();
        mat = sr.material;

    }
    IEnumerator Flash()
    {
        mat.SetFloat("_FlashAmount", 1f);
        yield return new WaitForSeconds(0.2f);
        mat.SetFloat("_FlashAmount", 0f);
    }
    public void Action()
    {
        currentHP -= damage;
        StartCoroutine(Flash());
        if (currentHP <= 0)
        {
            action?.Invoke();
        }
    }
}
