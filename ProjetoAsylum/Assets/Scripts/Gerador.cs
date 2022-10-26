using System.Collections;
using System.Collections.Generic;
using UnityEditor.Localization.Plugins.XLIFF.V12;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Gerador : MonoBehaviour
{
    public Light[] Luz;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && gameObject.tag == "ligar")
        {
            Luz[Luz.Length].enabled = true;
            gameObject.tag = "liagdo";
            count++;
            StartCoroutine(Desligar());

        }
        if (count == 4)
        {
            Debug.Log("VITORIA");
        }
    }

    private IEnumerator Desligar() 
    {
        yield return new WaitForSeconds(120);
        Luz[Luz.Length].enabled = false;
        gameObject.tag = "ligar";
        count--;
    } 
}
