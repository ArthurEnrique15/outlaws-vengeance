using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float headDamage = 80f;
    public float upperTorsoDamage = 70f;
    public float lowerTorsoDamage = 60f;
    public float legDamage = 50f;
    public float footDamage = 40f;

    public AudioSource audioSource;  // Referência ao AudioSource da bala

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.name);

        Destroy(gameObject);

        // if (collision.collider.name.Contains("Ground"))
        // {
        //     PlayRicochetSound();
        // }

        // Destroy(gameObject, destroyDelay);

        if (collision.collider.name.Contains("head"))
        {
            ApplyDamage(collision.collider, headDamage);
        }
        else if (collision.collider.name.Contains("upper_torso"))
        {
            ApplyDamage(collision.collider, upperTorsoDamage);
        }
        else if (collision.collider.name.Contains("lower_torso"))
        {
            ApplyDamage(collision.collider, lowerTorsoDamage, "lowerTorso");
        }
        else if (collision.collider.name.Contains("leg") || collision.collider.name.Contains("calf"))
        {
            ApplyDamage(collision.collider, legDamage, "leg");
        }
        else if (collision.collider.name.Contains("foot"))
        {
            ApplyDamage(collision.collider, footDamage, "foot");
        }
    }

    void ApplyDamage(Collider2D collider, float damage, string hitLocation = "")
    {
        PlayerController player = collider.GetComponentInParent<PlayerController>();
        if (player != null)
        {
            player.TakeDamage(damage, hitLocation);
        }

        EnemyController enemy = collider.GetComponentInParent<EnemyController>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage, hitLocation);
        }
    }

    private void PlayRicochetSound()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}