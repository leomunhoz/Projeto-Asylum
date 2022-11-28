using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    public GameObject Menu;
    public GameObject SettingsMenu;
    public GameObject Connetion;
     
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

   public void Connect() 
    {
        Menu.SetActive(false);
        Connetion.SetActive(true);
    }

    public void voltarCone() 
    {
        Connetion.SetActive(false);
        Menu.SetActive(true);
    }
   

    public void voltarSettings() 
    {
        Menu.SetActive(true);
        SettingsMenu.SetActive(false);

    }

   

    
}
