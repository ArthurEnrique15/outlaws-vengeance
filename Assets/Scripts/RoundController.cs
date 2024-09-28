using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundController : MonoBehaviour
{
    public GameObject startCircle;  // O círculo abaixo do jogador
    public PlayerController playerController;
    public EnemyController enemyController;
    public float hoverTime = 3f;    // Tempo necessário para iniciar o round

    private bool isRoundStarted = false;
    private float hoverTimer = 0f;
    private Collider2D circleCollider;

    void Start()
    {
        circleCollider = startCircle.GetComponent<Collider2D>();
        playerController.canShoot = false;
        enemyController.canShoot = false;
    }

    void Update()
    {
        if (isRoundStarted) return; // Se o round já começou, não faça nada

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Ajuste do eixo Z para 2D

        if (circleCollider.OverlapPoint(mousePosition))
        {
            hoverTimer += Time.deltaTime;

            if (hoverTimer >= hoverTime)
            {
                StartRound();
            }
        }
        else
        {
            hoverTimer = 0f; // Resetar o timer se o mouse sair do círculo
        }
    }

    void StartRound()
    {
        isRoundStarted = true;
        playerController.canShoot = true; // Permite o player atirar
        enemyController.canShoot = true;  // Permite o inimigo atirar
        Debug.Log("Round começou!");
    }
}