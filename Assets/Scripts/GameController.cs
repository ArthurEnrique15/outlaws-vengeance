using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Sair do jogo"); // Apenas para teste no Editor do Unity
        Application.Quit();
    }
}
