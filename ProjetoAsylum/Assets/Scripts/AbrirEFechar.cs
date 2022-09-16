using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AbrirEFechar : MonoBehaviour
{
    public Animator porta;
    
    bool abrir = true;
    bool fechar = false;
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
            if (Input.GetKeyDown(KeyCode.E) && abrir == true && fechar == false)
            {
                porta.SetTrigger("Abrir");
                fechar = true;
                abrir = false;
            }
            else if (Input.GetKeyDown(KeyCode.E) && abrir == false && fechar == true)
            {
                porta.SetTrigger("Fechar");
                fechar = false;
                abrir = true;
            }
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
































