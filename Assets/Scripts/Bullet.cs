using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float headDamage = 60f;
    public float upperTorsoDamage = 30f;
    public float lowerTorsoDamage = 20f;
    public float legDamage = 15f;
    public float footDamage = 10f;

    public AudioSource audioSource;  // Referência ao AudioSource da bala
    private float destroyDelay = 0.5f;
    private bool hasCollided = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasCollided) return;

        hasCollided = true;

        if (collision.collider.name.Contains("Ground"))
        {
            PlayRicochetSound();
        }
        else if (collision.collider.name.Contains("head"))
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

        Destroy(gameObject, destroyDelay);
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