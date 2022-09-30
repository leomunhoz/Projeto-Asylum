using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Grafico;
    public GameObject resolucao;
    public GameObject config;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void settings() 
    {
        Menu.SetActive(false);
        config.SetActive(true);    
    }

   public void grafico() 
    {
        config.SetActive(false);
        Grafico.SetActive(true);
    
    }

   public void Resolucao() 
    {
        config.SetActive(false);
        resolucao.SetActive(true);  

    }

    public void voltarSettings() 
    {
        Menu.SetActive(true);
        config.SetActive(false);

    }

    public void voltarGrafico() 
    {
        config.SetActive(true);
        Grafico.SetActive(false);

    }

    public void voltarResolucao() 
    {
        config.SetActive(true);
        resolucao.SetActive(false);

    }
}
