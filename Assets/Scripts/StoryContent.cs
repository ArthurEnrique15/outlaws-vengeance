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
        "Jake Blackwood era um pistoleiro do velho oeste. Conhecido como um dos mais temidos de sua epoca, sua ficha criminal era extensa," + 
        " recheada de assaltos a bancos, assassinatos de aluguel e outros crimes violentos. Sua vida era movida pela brutalidade e pela fama," +
        " ate que, em um momento de lucidez, ele percebeu que talvez houvesse algo mais esperando por ele fora daquela trilha sangrenta.",

        "Foi entao que Jake decidiu largar sua vida de crimes em busca de algo maior. Ele mudou-se para longe, onde seu nome nao fosse conhecido," +
        " e la encontrou Jane S. Blackwood. Jane era a pessoa que Jake nem sabia que precisava. O amor entre eles floresceu rapido, uma conexao que trouxe" +
        " uma paz que ele nunca imaginou ser possivel. Eles viveram juntos por alguns anos, em um lar simples, mas repleto de felicidade e esperanca.",

        "Porem, o passado de Jake estava longe de ser esquecido. Seus antigos inimigos, buscando vinganca incansavelmente, finalmente o encontraram" +
        " apos mais de 10 anos. Sabendo que a maior dor para um homem seria ver sua pessoa amada sofrer, eles atacaram em uma noite silenciosa," +
        " eliminando Jane sem piedade. Jake estava ausente, e talvez esse tenha sido o maior castigo: retornar e encontrar sua amada tomada pela morte.",

        "A vida tranquila e esperancosa de Jake virou poeira. Ele nunca mais seria o mesmo. A dor e o luto o transformaram em uma sombra do que um dia ele foi." +
        " A partir daquele momento, apenas uma coisa o movia: a vinganca. Jake descobriu, atraves de uma investigacao implacavel, os nomes daqueles" +
        " que tiraram sua unica razao de viver. O que era mais amargo e cruel: ele conhecia cada um deles.",

        "Mas Jake nao buscava uma vinganca covarde. Ele nao ia fazer com eles o que eles fizeram com ele. Ao inves disso, decidiu que enfrentaria cada um em um duelo," +
        " cara a cara, olhando nos olhos de seus inimigos. Seria um confronto justo, ou o mais proximo de justica que Jake conseguiria encontrar naquele mundo corrompido.",

        "O primeiro inimigo: Wild Bill Hiccup. Um pistoleiro cruel, com um historico impecavel de vitorias em duelos, e o responsavel direto pela morte de Jane." +
        " Bill acredita ser invencivel, mas hoje ele enfrentara um viuvo vingativo, um homem que nao tem mais nada a perder. Sera que ele conseguira manter seu placar perfeito," +
        " ou seu fim sera selado pelas maos de Jake Blackwood?"
    };

    private string[] level1VictoryStoryChunks = new string[]
    {
        "Jake Blackwood eliminou Wild Bill Hiccup em um duelo sangrento. Bill, conhecido como um dos pistoleiros mais mortais do oeste, " + 
        "agora jaz no chao, vitima da furia de um homem com nada a perder.",

        "Com o fim de Bill, a sombra do passado de Jake comeca a se dissipar. Mas a jornada de vinganca esta longe de acabar. " + 
        "O proximo alvo e Gerald Hiccup, o irmao gemeo de Wild Bill. Gerald sempre foi uma figura nas sombras, agindo como um fantasma silencioso, " +
        "revelando os segredos de Jake para os inimigos e guiando-os ate sua amada Jane.",

        "Gerald foi mais do que um simples informante; ele era o estrategista por tras de cada movimento. Com um odio silencioso, " +
        "ele cruzou todos os limites, infiltrando-se onde quer que fosse necessario, ate mesmo interagindo com quem Jake confiava. " +
        "Agora, Blackwood esta determinado a silenciar para sempre o irmao do homem que iniciou seu sofrimento. " +
        "Gerald Hiccup precisa pagar o preco por sua traicao e ser enviado ao mesmo tormento que ele mesmo ajudou a criar."
    };

    private string[] level2VictoryStoryChunks = new string[]
    {
        "O duelo com Gerald Hiccup foi intenso, mas Jake Blackwood saiu vitorioso. Agora, so resta um homem entre Jake e a conclusao de sua jornada de vinganca: Warren J. Buescher.",

        "Warren nao era apenas mais um algoz; ele foi um amigo, um aprendiz, quase como um irmao para Jake. " +
        "Jake o encontrou em uma epoca de pobreza e desespero e deu a ele uma nova vida, uma chance de ser alguem. " +
        "Porem, o poder e a ganancia subiram a mente de Warren, transformando-o em uma serpente venenosa que apunhalou seu mentor pelas costas.",

        "Este duelo nao e apenas o mais dificil pela habilidade de Warren com um revolver, mas tambem pelo peso emocional. " +
        "E como se Jake estivesse eliminando parte de si mesmo, uma sombra de sua historia. " +
        "Mas ele sabe que para seguir em frente, para honrar a memoria de Jane, Warren J. Buescher precisa ser removido da face da Terra."
    };

    private string[] level3VictoryStoryChunks = new string[]
    {
        "Jake Blackwood encarou o corpo caido de Warren J. Buescher, o ultimo dos tres algozes. O silencio tomou conta do ambiente, " +
        "e pela primeira vez em anos, Jake sentiu uma sensacao diferente... um alivio sombrio. Ele havia cumprido seu objetivo, " +
        "tinha feito justica pela memoria de sua amada Jane. Porem, essa justica veio com um preco: a perda de sua propria alma.",

        "O vento assobiou pelo deserto, carregando consigo a poeira e os restos de um passado cheio de violencia e traicao. " +
        "Jake sabia que sua jornada havia chegado ao fim, mas nao havia vitoria em seu coracao, apenas um vazio. A vinganca havia consumido " +
        "tudo o que ele era, deixando-o apenas como uma sombra do pistoleiro que um dia sonhou em ser um homem de paz.",

        "Com passos lentos, ele se aproximou de uma rocha e se sentou, sentindo o peso da solidao. Olhou para o horizonte, onde o sol se punha " +
        "e tingia o ceu com tons dourados e vermelhos. Este era o fim que ele tinha escolhido, o fim que a vida de um pistoleiro reservava: " +
        "estar sozinho em um mundo cruel, mesmo depois de realizar sua vinganca.",

        "Ele tirou o chapeu, abaixou a cabeca e fechou os olhos. Jane estava vingada, mas o que restava agora para Jake Blackwood? " +
        "A unica certeza era que o passado ficaria para sempre marcado em seu coracao. Ele respirou fundo e, pela ultima vez, sentiu o cheiro da terra seca, " +
        "o cheiro do oeste que havia moldado seu destino. O duelo final estava encerrado, e junto com ele, a lenda de Jake Blackwood."
    };

    private string[] storyChunks;

    private int currentChunk = 0;
    private Coroutine typingCoroutine; // Armazena a corrotina atual
    private bool isTyping = false; // Flag para verificar se o texto está sendo digitado
    private float typingSpeed = 0.01f;

    void Start()
    {
        typingSpeed = 0.01f;
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

        else if (sceneName == "Victory")
        {
            storyChunks = level3VictoryStoryChunks;
            typingSpeed = 0.05f;
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
            yield return new WaitForSeconds(typingSpeed); // Tempo entre cada caractere (ajuste conforme desejar)
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