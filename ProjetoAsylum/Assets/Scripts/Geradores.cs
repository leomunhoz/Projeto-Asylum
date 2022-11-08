using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Geradores : MonoBehaviour
{
    public int countGeradores = 0;
    bool EstaTrigado;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Liberar();
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
   
    public void Liberar()
    {

        if (EstaTrigado)
        {
            if (Input.GetKeyDown(KeyCode.E) && this.gameObject.tag == "ligar")
            {
                countGeradores++;
               
                gameObject.tag = "ligado";
            }

        }

        if (countGeradores == 2)
        {
            SceneManager.LoadScene(2);
            

        }
    }
}
