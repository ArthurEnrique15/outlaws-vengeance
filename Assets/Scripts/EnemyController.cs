using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Weapon weapon;
    public Transform armBone; // O braço do inimigo que será rotacionado
    public Transform player;  // Referência ao transform do jogador

    public float minRandomOffset = -10f; // Mínimo de desvio aleatório (em graus)
    public float maxRandomOffset = 10f;  // Máximo de desvio aleatório (em graus)
    public float fireRate = 0.1f;  // Tempo entre tiros, em segundos (uma vez por segundo)
    private float fireCooldown = 0f; // Contador de cooldown para controlar quando o inimigo pode atirar novamente

    public float health = 100f;

    float currentAngle;

    void Update()
    {
        // Atualiza o temporizador para o disparo
        fireCooldown -= Time.deltaTime; // Diminui o cooldown a cada frame

        // Verifica se o inimigo pode atirar
        if (fireCooldown <= 0f)
        {
            AimAndShoot();
            fireCooldown = fireRate; // Reinicia o cooldown
        }
    }

    void AimAndShoot()
    {
      Vector3 direction = player.position - armBone.position;

      // Calcula o ângulo em radianos e converte para graus
      // currentAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + Random.Range(minRandomOffset, maxRandomOffset);
      currentAngle = Random.Range(160f, 220f);

      // Aplica a rotação ao braço do inimigo
      armBone.rotation = Quaternion.Euler(new Vector3(0, 0, currentAngle));

      Debug.Log(currentAngle);

      weapon.Fire(currentAngle);
    }

     public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Enemy tomou dano: " + damage + " | Vida restante: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Implementar a lógica de morte do Enemy (destruição, animação, etc.)
        Debug.Log("Enemy morreu!");
        Destroy(gameObject);
    }
}