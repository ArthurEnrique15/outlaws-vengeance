using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryController : MonoBehaviour
{
    // Referência para o componente de Texto
    public Text storyText;
    public Button continueButton;

    // Array que contém os trechos da história
    private string[] storyChunks = new string[]
    {
        "Outlaws' Vengeance é um jogo de duelo em uma terra sem lei...",
        "Você é um pistoleiro em busca de vingança pela morte de sua esposa...",
        "Em cada esquina, há um novo inimigo pronto para te enfrentar.",
        "Seu objetivo é derrotar cada inimigo e descobrir o mandante por trás do crime."
    };

    private int currentChunk = 0;

    void Start()
    {
        // Exibir o primeiro trecho da história
        storyText.text = storyChunks[currentChunk];
        // Adiciona a função de avanço ao botão "Continue"
        continueButton.onClick.AddListener(AdvanceStory);
    }

    void AdvanceStory()
    {
        // Avança para o próximo trecho, se disponível
        if (currentChunk < storyChunks.Length - 1)
        {
            currentChunk++;
            storyText.text = storyChunks[currentChunk];
        }
        else
        {
            // Aqui você pode adicionar o que fazer quando a história terminar
            continueButton.gameObject.SetActive(false); // Desativar o botão no fim da história
        }
    }
}
