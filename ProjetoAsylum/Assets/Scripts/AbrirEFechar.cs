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
    public GameObject botao;
    public AudioSource Audio;
    public AudioClip Som;
    
    
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
            botao.SetActive(true);
            EstaTrigado = true;

        }

    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Player" && EstaTrigado && other.gameObject.GetComponent<Player>().View.IsMine)
        {
            Debug.Log("NãoTrigado");
            botao.SetActive(false);
            EstaTrigado = false;

        }
    }
    [PunRPC]
    public void abrirPorta() 
    {
        
        if (!IsOpen)
        {
           
            porta.SetInteger("state", 1);
            Audio.PlayOneShot(Som);
            IsOpen = true;
        }
        else
        {
            
            porta.SetInteger("state", 0);
            Audio.PlayOneShot(Som);
            IsOpen = false;
        }
       
        
    }

    

}
































