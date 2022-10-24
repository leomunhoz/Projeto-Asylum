using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaChave : MonoBehaviour
{
    public InventarioChaves auxChaves;
    public int idChaves;
    public bool Trigger;
     Animator porta;
    // Start is called before the first frame update
    void Start()
    {
       porta = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Trigger)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Ola");
                if(auxChaves.chaves[idChaves] == true) 
                {
                    porta.SetBool("Abrir", true);
                   
                }
               
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Trigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Trigger = false;
    }
}
