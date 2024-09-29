using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoundController : MonoBehaviour
{
    public RectTransform playerAmmoIndicator;  // O círculo da UI
    public PlayerController playerController;
    public EnemyController enemyController;
    public float hoverTime = 3f;    // Tempo necessário para iniciar o round

    public TextMeshProUGUI roundMessage; // Referência ao texto de mensagem na tela
    public TextMeshProUGUI countdownText; // Referência ao texto do contador na tela
    public Button nextDuelButton;
    public Button goBackToStartButton;
    public Button retryButton;

    private bool isRoundStarted = false;
    private float hoverTimer = 0f;

    void Start()
    {
        playerController.canShoot = false;
        enemyController.canShoot = false;

        // Configuração inicial da mensagem e do contador
        roundMessage.text = "Mantenha o mouse sobre o circulo para iniciar!";
        countdownText.text = "";

        nextDuelButton.gameObject.SetActive(false);
        goBackToStartButton.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isRoundStarted)
        {
            CheckIfRoundEnded();
            return;
        }

        // Verifica se o mouse está sobre a imagem do círculo
        if (IsMouseOverPlayerAmmoIndicator())
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

    bool IsMouseOverPlayerAmmoIndicator()
    {
        Vector2 mousePosition = Input.mousePosition;
        return RectTransformUtility.RectangleContainsScreenPoint(playerAmmoIndicator, mousePosition, Camera.main);
    }

    void CheckIfRoundEnded()
    {
        if (playerController.isDead)
        {
            roundMessage.text = "Derrota!";
            playerController.canShoot = false;
            enemyController.canShoot = false;
            goBackToStartButton.gameObject.SetActive(true);
            retryButton.gameObject.SetActive(true);
        }
        else if (enemyController.isDead)
        {
            roundMessage.text = "Vitoria!";
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