using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StoryController : MonoBehaviour
{
    public Text storyText;
    public Button continueButton;

    private string[] storyChunks = new string[]
    {
        "Jake Blackwood era um pistoleiro do antigo velho oeste." + 
        " O mesmo era um dos pistoleiros mais temidos de sua epoca com uma vasta ficha criminal," + 
        " incluindo assaltos a bancos, assassinatos de aluguel e outros crimes." +
        " Um dia ele resolveu querer ter uma família, mas para isso ele teria que largar sua vida de crimes" +
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
        " Agora, QUE COMECEM OS DUELOS!!"
    };

    private int currentChunk = 0;
    private Coroutine typingCoroutine; // Armazena a corrotina atual
    private bool isTyping = false; // Flag para verificar se o texto está sendo digitado

    void Start()
    {
        // Exibir o primeiro trecho da história
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
            yield return new WaitForSeconds(0.005f); // Tempo entre cada caractere (ajuste conforme desejar)
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