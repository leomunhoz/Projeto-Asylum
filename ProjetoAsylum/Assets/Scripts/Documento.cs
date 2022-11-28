using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Documento : MonoBehaviour
{
    public GameObject UI;
    public GameObject Texto;
    bool trigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger && Player.IsPhotonMine && Input.GetKeyDown(KeyCode.E))
        {
            Texto.SetActive(true);
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            trigger = true;
            UI.SetActive(true);
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            trigger = false;
            Texto.SetActive(false); 
            UI.SetActive(false);
        }
         
    }
}
