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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

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
            ApplyDamage(collision.collider, lowerTorsoDamage);
        }
        else if (collision.collider.name.Contains("leg") || collision.collider.name.Contains("calf"))
        {
            ApplyDamage(collision.collider, legDamage);
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
            enemy.TakeDamage(damage);
        }
    }
}