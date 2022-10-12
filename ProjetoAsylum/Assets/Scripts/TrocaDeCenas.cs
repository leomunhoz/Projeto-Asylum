using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;


public class TrocaDeCenas : MonoBehaviourPunCallbacks
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
