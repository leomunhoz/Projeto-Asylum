using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class AbrirEFechar : MonoBehaviour
{
    public Animator porta;
    public PhotonView view;
    
    
    bool IsOpen = true;
   
    public bool EstaTrigado;
    

    void Start()
    {

    }

    private void OnValidate()
    {
        if (porta == null) { porta = GetComponent<Animator>(); }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (EstaTrigado && Player.IsPhotonMine && Input.GetKeyDown(KeyCode.E) && !Player.playerDawn)
        {
            Debug.Log("Abir");
            view.RPC("abrirPorta", RpcTarget.All);
            
        }

    }
    private void OnTriggerEnter(Collider other)
    {
       

        if (other.gameObject.tag == "Player" && !EstaTrigado && other.gameObject.GetComponent<Player>().View.IsMine)
        {
            Debug.Log("Trigado");
            EstaTrigado = true;

        }

    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Player" && EstaTrigado && other.gameObject.GetComponent<Player>().View.IsMine)
        {
            Debug.Log("NãoTrigado");
            EstaTrigado = false;

        }
    }
    [PunRPC]
    public void abrirPorta() 
    {
        
        if (!IsOpen)
        {
            IsOpen = true;
            porta.SetInteger("state", 1);
        }
        else
        {
            IsOpen = false;
            porta.SetInteger("state", 0);
        }
       
        
    }



}
































