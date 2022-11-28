using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Photon.Pun;
using Photon.Realtime;

public class PortaChave : MonoBehaviour
{
    public InventarioChaves auxChaves;
    public int idChaves;
    public GameObject UI;
    public GameObject UI2;
    public PhotonView View;
    public bool Trigger;
    Animator porta;
    // Start is called before the first frame update
    void Awake()
    {
       porta = GetComponent<Animator>();
       
    }

    

    // Update is called once per frame
    void Update()
    {
        if (Trigger && Player.IsPhotonMine && Input.GetKeyDown(KeyCode.E))
        {

            View.RPC("abrirPorta", RpcTarget.AllBuffered);


        }
    }
    [PunRPC]
    void abrirPorta() 
    {
        Debug.Log("Destrancada");
        if (auxChaves.chaves[idChaves] == true)
        {
            porta.SetInteger("state", 1);
            UI.SetActive(true);
            UI2.SetActive(false);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Trigger = true;
            UI2.SetActive(true);
           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Trigger = false;
        UI2.SetActive(false);
    }
}
