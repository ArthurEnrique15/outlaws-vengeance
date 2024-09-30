using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryController : MonoBehaviour
{
    public Text storyText;
    public Button continueButton;
    private string[] loreStoryChunks = new string[]
    {
        "Jake Blackwood era um pistoleiro do antigo velho oeste." + 
        " O mesmo era um dos pistoleiros mais temidos de sua epoca com uma vasta ficha criminal," + 
        " incluindo assaltos a bancos, assassinatos de aluguel e outros crimes." +
        " Um dia ele resolveu querer ter uma familia, mas para isso ele teria que largar sua vida de crimes" +
        " para poder encontrar alguem que ame-o. Ele decidiu que era hora de procurar novos rumos e mudou-se para longe.",
        
        "Jane S. Blackwood foi a pessoa amada que Jake encontrou em seu caminho. Ela, por ter vivido sempre" +
        " muito longe das localidades onde seu amado cometia seus crimes, nao imaginava a historia real de seu homem amado." +
        " Os dois acabaram se casando, passando anos com uma linda familia e um casal de filhos. Jake nao imaginava que seu passado iria retornar!" +
        " Existe uma frase que diz o seguinte: a maior dor emocional de um ser humano e provocada pelo sofrimento de uma pessoa amada por ele.",
        
        "Seus algozes estavam por anos buscando vinganca de forma incansavel, o que acabou consumando no seu encontro depois de mais de 10 anos." +
        " Aplicando firmimente e covardemente a proposta de machucar quem o alvo ama, seus algozes numa noite como outra qualquer apareceram com suas armas e eliminaram Jane da face da terra" +
        ". Os filhos so nao seguiram o mesmo destino pois nao estavam na respectiva residencia no momento do ataque. Blackwood nunca mais foi a mesma pessoa.",

        "Vinganca pelo assassinato de Jane era o objetivo-mor da vida do pistoleiro Jake e ele estava decidido a encontrar um por um." +
        " Fazendo suas investigacoes, nosso protagonista descobriu quem eram cada um dos assassinos de sua esposa. Surpreendendo um total de 0 pessoas, ele as conhecia." +
        " Mais do que isso, ele nao queria uma vinganca covarde, eliminando membros da familia de seus algozes. Optou por um duelo X1 com cada uma dessas pessoas." +
        " Agora, QUE COMECEM OS DUELOS!!",

        "O primeiro inimigo: Wild Bill Hiccup. Pistoleiro cruel com um card impecavel de duelos que foi o responsavel por matar Jane." +
        " Sera que ele vai conseguir manter seu placar impecavel ou sera o fim de sua vida pelas maos de um viuvo vingativo?"
    };

    private string[] level1VictoryStoryChunks = new string[]
    {
        "Jake Blackwood conseguiu vingar a morte de sua amada Jane, eliminando Wild Bill Hiccup.",
        "Agora e hora do proximo algoz",
    };

    private string[] level2VictoryStoryChunks = new string[]
    {
        "Jake Blackwood conseguiu vingar a morte de sua amada Jane, eliminando o segundo algoz.",
        "Agora e hora do proximo algoz",
    };

    private string[] storyChunks;

    private int currentChunk = 0;
    private Coroutine typingCoroutine; // Armazena a corrotina atual
    private bool isTyping = false; // Flag para verificar se o texto está sendo digitado

    void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "Lore")
        {
            storyChunks = loreStoryChunks;
        }
        else if (sceneName == "Level 1 Victory")
        {
            storyChunks = level1VictoryStoryChunks;
        }
        else if (sceneName == "Level 2 Victory")
        {
            storyChunks = level2VictoryStoryChunks;
        }

        typingCoroutine = StartCoroutine(TypeText(storyChunks[currentChunk]));
    }

    public void AdvanceStory()
    {
        if (isTyping)
        {
            // Se estiver digitando, exibe o texto completo
            StopCoroutine(typingCoroutine);
            storyText.text = storyChunks[currentChunk];
            isTyping = false;
        }
        else
        {
            // Avança para o próximo trecho, se disponível
            if (currentChunk < storyChunks.Length - 1)
            {
                currentChunk++;
                typingCoroutine = StartCoroutine(TypeText(storyChunks[currentChunk]));
            }
        }

        CheckIfShouldRemoveContinueButton();
    }

    IEnumerator TypeText(string textToType)
    {
        storyText.text = ""; // Limpar o texto atual
        isTyping = true; // Define que o texto está sendo digitado

        foreach (char letter in textToType)
        {
            storyText.text += letter;
            yield return new WaitForSeconds(0.01f); // Tempo entre cada caractere (ajuste conforme desejar)
        }

        isTyping = false; // O texto terminou de ser digitado

        CheckIfShouldRemoveContinueButton();
    }

    private void CheckIfShouldRemoveContinueButton()
    {
        if (!isTyping && currentChunk == storyChunks.Length - 1)
        {
            continueButton.gameObject.SetActive(false); // Desativar o botão no fim da história
        }
    }
}