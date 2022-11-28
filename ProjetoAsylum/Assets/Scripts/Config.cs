using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    public GameObject Menu;
    public GameObject SettingsMenu;
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
        SettingsMenu.SetActive(true);    
    }

   

   

    public void voltarSettings() 
    {
        Menu.SetActive(true);
        SettingsMenu.SetActive(false);

    }

   

    
}
