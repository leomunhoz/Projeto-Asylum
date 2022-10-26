using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiberarAcesso : MonoBehaviour
{
    
    private static int count = 0;
    public Animator porta;
    
    public Animator ligar;
    bool EstaTrigado;

    void Start()
    {
        
    }
    private void OnValidate()
    {
        if (porta == null) porta = GetComponent<Animator>();
       
    }
    void Update()
    {
        if (EstaTrigado)
        {
            if (Input.GetKeyDown(KeyCode.E) && gameObject.tag == "Ligar")
            {
                count++;
                ligar.SetInteger("state", 1);
                gameObject.tag = "Ligado";
            }
           
        }

        if (count == 4)
        {
            porta.SetInteger("state", 1);
            Debug.Log("Aberto");
            
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            EstaTrigado = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            EstaTrigado = false;
        }
    }



}
