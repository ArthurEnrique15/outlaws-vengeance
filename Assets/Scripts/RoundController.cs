using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoundController : MonoBehaviour
{
    public GameObject startCircle;  // O círculo abaixo do jogador
    public PlayerController playerController;
    public EnemyController enemyController;
    public float hoverTime = 3f;    // Tempo necessário para iniciar o round

    public TextMeshProUGUI roundMessage; // Referência ao texto de mensagem na tela
    public TextMeshProUGUI countdownText; // Referência ao texto do contador na tela
    public Button nextDuelButton;
    public Button defeatButton;

    private bool isRoundStarted = false;
    private float hoverTimer = 0f;
    private Collider2D circleCollider;

    void Start()
    {
        circleCollider = startCircle.GetComponent<Collider2D>();
        playerController.canShoot = false;
        enemyController.canShoot = false;

        // Configuração inicial da mensagem e do contador
        roundMessage.text = "Mantenha o mouse sobre o circulo para iniciar!";
        countdownText.text = "";

        nextDuelButton.gameObject.SetActive(false);
        defeatButton.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isRoundStarted)
        {
            CheckIfRoundEnded();
            return;
        }

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Ajuste do eixo Z para 2D

        if (circleCollider.OverlapPoint(mousePosition))
        {
            hoverTimer += Time.deltaTime;
            float timeLeft = hoverTime - hoverTimer;

            // Atualiza o texto do contador
            countdownText.text = "Iniciando em: " + timeLeft.ToString("F2") + "s";

            if (hoverTimer >= hoverTime)
            {
                StartRound();
            }
        }
        else
        {
            hoverTimer = 0f; // Resetar o timer se o mouse sair do círculo
            countdownText.text = ""; // Limpa o contador
        }
    }

    void CheckIfRoundEnded() {
        if (playerController.isDead) {
            roundMessage.text = "Derrota!";
            // countdownText.text = "Pressione R para reiniciar";
            playerController.canShoot = false;
            enemyController.canShoot = false;
            defeatButton.gameObject.SetActive(true);
        } else if (enemyController.isDead) {
            roundMessage.text = "Vitoria!";
            // countdownText.text = "Pressione R para reiniciar";
            playerController.canShoot = false;
            enemyController.canShoot = false;
            nextDuelButton.gameObject.SetActive(true);
        }
    }

    void StartRound()
    {
        isRoundStarted = true;
        playerController.canShoot = true; // Permite o player atirar
        enemyController.canShoot = true;  // Permite o inimigo atirar

        // Atualiza as mensagens
        roundMessage.text = "Round iniciado!";
        countdownText.text = "";
    }
}