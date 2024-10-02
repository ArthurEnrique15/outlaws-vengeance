using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Importa o namespace para trabalhar com UI

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 100f;
    public float currentAmmo = 6;
    public AudioSource audioSource;
    public AudioClip shootSound;
    public AudioClip emptySound;

    // Referências para UI
    public Image ammoIndicatorImage; // O componente Image na UI
    public Sprite[] revolverSprites; // Array com os sprites do tambor do revólver

    private void Start()
    {
        UpdateAmmoIndicator(); // Atualiza a imagem do tambor no início
    }

    public void Fire(float rotation)
    {
        PlayShootSound();

        if (currentAmmo > 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

            bulletRb.AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
            bulletRb.SetRotation(rotation);

            currentAmmo--;
            UpdateAmmoIndicator(); // Atualiza a imagem do tambor
        }
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

    private void UpdateAmmoIndicator()
    {
        if (ammoIndicatorImage != null && revolverSprites.Length > 0)
        {
            // Atualiza a imagem do tambor com base na munição restante
            int spriteIndex = Mathf.Clamp((int)currentAmmo, 0, revolverSprites.Length - 1);
            ammoIndicatorImage.sprite = revolverSprites[spriteIndex];
        }
    }
}