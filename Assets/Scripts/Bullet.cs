using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float headshotDamage = 100f;  // Dano se acertar a cabeça
    public float torsoDamage = 50f;      // Dano se acertar o torso
    public float legDamage = 25f;        // Dano se acertar as pernas

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica qual parte do corpo foi atingida e aplica o dano adequado
        if (collision.CompareTag("Head"))
        {
            ApplyDamage(collision, headshotDamage);
        }
        else if (collision.CompareTag("Torso"))
        {
            ApplyDamage(collision, torsoDamage);
        }
        else if (collision.CompareTag("Legs"))
        {
            ApplyDamage(collision, legDamage);
        }

        // Destroi a bala após o impacto
        Destroy(gameObject);
    }

    void ApplyDamage(Collider2D collision, float damage)
    {
        // Verifica se colidiu com o Player
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponentInParent<PlayerController>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }
        }

        // Verifica se colidiu com o Enemy
        else if (collision.CompareTag("Enemy"))
        {
            EnemyController enemy = collision.GetComponentInParent<EnemyController>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}