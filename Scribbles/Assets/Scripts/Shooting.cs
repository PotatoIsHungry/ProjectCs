using System.Data.Common;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Shooting : MonoBehaviour
{
    public GameObject shootingItem;
    public Transform shootingPoint;
    public bool canShoot = true;

    private void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
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
    }
}
