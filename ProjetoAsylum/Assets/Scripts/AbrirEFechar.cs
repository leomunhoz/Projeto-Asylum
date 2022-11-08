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
        if (EstaTrigado)
        {
            if (Input.GetKeyDown(KeyCode.E) && !IsOpen)
            {
                porta.SetInteger("state", 1);
                IsOpen = true;
            }
            else if (Input.GetKeyDown(KeyCode.E) && IsOpen)
            {
                porta.SetInteger("state", 0);
                IsOpen = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
       

        if (other.gameObject.tag == "Player" && !EstaTrigado)
        {
            
            EstaTrigado = true;

        }

    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Player" && EstaTrigado)
        {

            EstaTrigado = false;

        }
    }





}
































