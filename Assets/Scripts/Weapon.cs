using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 100f;
    public float currentAmmo = 6;
    public AudioSource audioSource; // Referência ao AudioSource
    public AudioClip shootSound;    // Referência ao som do tiro
    public AudioClip emptySound;    // Referência ao som de munição vazia

    public void Fire(float rotation)
    {
        if (currentAmmo > 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

            bulletRb.AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
            bulletRb.SetRotation(rotation);

            currentAmmo--;
        }

        Debug.Log("Current Ammo: " + currentAmmo);

        PlayShootSound();
    }

    private void PlayShootSound()
    {
        if (audioSource != null)
        {
            if (currentAmmo > 0 && shootSound != null)
            {
                audioSource.PlayOneShot(shootSound);
            }
            else if (currentAmmo == 0 && emptySound != null)
            {
                audioSource.PlayOneShot(emptySound);
            }
        }
    }
}
