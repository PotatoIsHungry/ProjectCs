using System.Data.Common;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Shooting : MonoBehaviour
{
    public GameObject shootingItem;
    public Transform shootingPoint;
    public bool canShoot = true;

    public float shootCooldown = 0.5f;
    private float cooldownTimer = 0f;
    private void Update()
    {
        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
        }

        if (Keyboard.current.qKey.wasPressedThisFrame && cooldownTimer <= 0f)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (!canShoot) return;

        float dir = transform.localScale.x;
        
         GameObject bullet = Instantiate(shootingItem, shootingPoint.position, shootingPoint.rotation);
         bullet.GetComponent<playerShooting>().SetDirection(dir);

         cooldownTimer = shootCooldown;
    }
}
