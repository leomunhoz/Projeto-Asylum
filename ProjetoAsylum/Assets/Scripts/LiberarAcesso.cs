using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LiberarAcesso : MonoBehaviour
{
    
    private static int count = 0;
    public Animator porta;
    public PhotonView view;
    
    public Animator ligar;
    bool EstaTrigado;
    int Lock = 0;
    bool isOpen;

    void Start()
    {
        
    }
    private void OnValidate()
    {
        if (porta == null) porta = GetComponent<Animator>();
       
    }
    void Update()
    {
        if (EstaTrigado && Player.IsPhotonMine && Input.GetKeyDown(KeyCode.E) && Lock == 0 && !Player.playerDawn )
        {
           
                
                Lock = 1;
                view.RPC("Liberar", RpcTarget.All);
            

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<Player>().View.IsMine)
        {
            EstaTrigado = true;
        }

    }
    private void OnTriggerExit(Collider other )
    {
        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<Player>().View.IsMine)
        {
            EstaTrigado = false;
        }
    }
    [PunRPC]
    public void Liberar() 
    {
        count++;
        ligar.SetInteger("state", 1);
        if (count >= 4 && !isOpen) 
        {
            isOpen = true;
            porta.SetInteger("state", 1);
            Debug.Log("Aberto");

        }
      



    }

}
