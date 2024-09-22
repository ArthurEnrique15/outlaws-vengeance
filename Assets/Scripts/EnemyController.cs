using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Weapon weapon;
    public Transform armBone; // O braço do inimigo que será rotacionado
    public Transform player;  // Referência ao transform do jogador
    public Animator animator;
    public float health = 100f;

    public float minRandomOffset = -50f; // Mínimo de desvio aleatório (em graus)
    public float maxRandomOffset = 50f;  // Máximo de desvio aleatório (em graus)
    public float fireRate = 0.1f;  // Tempo entre tiros, em segundos (uma vez por segundo)
    private float fireCooldown = 0f; // Contador de cooldown para controlar quando o inimigo pode atirar novamente

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
        currentAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + Random.Range(minRandomOffset, maxRandomOffset);
        //   currentAngle = Random.Range(160f, 220f);

        armBone.rotation = Quaternion.Euler(new Vector3(0, 0, currentAngle));

        // weapon.Fire(currentAngle);
    }

    public void TakeDamage(float damage, string hitLocation = "")
    {
        health -= damage;
        Debug.Log("Enemy tomou dano: " + damage + " | Vida restante: " + health);
        Debug.Log(hitLocation);

        if (health <= 0)
        {
            Die();
            return;
        }

        if (hitLocation == "lowerTorso")
        {
            animator.SetTrigger("LowerTorsoHitTrigger");
        }
        else if (hitLocation == "leg" || hitLocation == "foot")
        {
            animator.SetTrigger("LegHitTrigger");
        }
    }

    void Die()
    {
        // Implementar a lógica de morte do Enemy (destruição, animação, etc.)
        Debug.Log("Enemy morreu!");
        // animationsController.TriggerDeathAnimation();
        Destroy(gameObject);
    }
}