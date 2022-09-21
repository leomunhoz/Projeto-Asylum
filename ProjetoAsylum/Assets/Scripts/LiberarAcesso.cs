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

     void Update()
    {
        if (EstaTrigado)
        {
            if (Input.GetKeyDown(KeyCode.E) && gameObject.tag == "Ligar")
            {
                count++;
                ligar.SetTrigger("Ligar");
                gameObject.tag = "Ligado";
            }
           
        }

        if (count == 4)
        {
            porta.SetTrigger("Abrir");
            Debug.Log("Aberto");
            
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EstaTrigado = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EstaTrigado = false;
        }
    }



}
