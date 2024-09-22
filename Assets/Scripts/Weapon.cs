using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 100f;
    // public float currentAmmo = 6;

    public void Fire(float rotation)
    {
        // if (currentAmmo == 0) return;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        bulletRb.AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
        bulletRb.SetRotation(rotation);

        // currentAmmo--;
    }
}
