using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class Geradores : MonoBehaviour
{
    public static int countGeradores = 0;
    bool EstaTrigado;
    
    [SerializeField]
    PhotonView View;
    public int Lock = 0;
    // Start is called before the first frame update
    void Start()
    {
        countGeradores = 0;
    }
    private void OnValidate()
    {
        if (View == null) GetComponent<PhotonView>();
        
    }
    // Update is called once per frame
    void Update()
    {
        if (EstaTrigado && Player.IsPhotonMine && Input.GetKeyDown(KeyCode.E) && Lock == 0 && !Player.playerDawn)
        {
            
                Lock = 1;
                View.RPC("Ligar", RpcTarget.All);
              
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<Player>().View.IsMine)
        {
            EstaTrigado = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<Player>().View.IsMine)
        {
            EstaTrigado = false;
        }
    }
    [PunRPC]
    public void Ligar()
    {

        countGeradores++;
       
        Debug.Log(countGeradores);

       
        if (countGeradores < 4)
        {
            StartCoroutine(Desligar());
        }
        else
        {
            StopCoroutine(Desligar());
           
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            PhotonNetwork.Disconnect();
            SceneManager.LoadScene(2);
           

        }
       
           
        
    }
    
       IEnumerator Desligar() 
    {
        yield return new WaitForSeconds(120);
        Lock = 0;
        countGeradores--;
    }
}

