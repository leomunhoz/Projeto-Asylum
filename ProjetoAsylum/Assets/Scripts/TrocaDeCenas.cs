using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TrocaDeCenas : MonoBehaviour
{

    public string nomeDaCena;

    public void JogarEtrocarCena()
    {
        SceneManager.LoadScene(nomeDaCena);
    }

    public void Sair()
    {
        Application.Quit();
    }
}
