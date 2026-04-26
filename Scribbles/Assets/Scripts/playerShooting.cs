using System.Data.Common;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Shooting : MonoBehaviour
{
    public GameObject shootingItem;
    public Transform shootingPoint;
    public bool canShoot = true;
    public AudioSource m_AudioSource;


    public float shootCooldown = 0.5f;
    private float cooldownTimer = 0f;
    private void Update()
    {
        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
        }

        if (Keyboard.current.hKey.wasPressedThisFrame && cooldownTimer <= 0f)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (!canShoot) return;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        float dir = sr.flipX ? -1f : 1f;

        GameObject bullet = Instantiate(shootingItem, shootingPoint.position, shootingPoint.rotation);

        bullet.GetComponent<playerShooting>().SetDirection(dir);

        m_AudioSource.PlayOneShot(m_AudioSource.clip);

        cooldownTimer = shootCooldown;
    }
}
