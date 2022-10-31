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
        Luz[0].enabled = false;
        Luz[1].enabled = false;
        Luz[2].enabled = false;
        Luz[3].enabled = false;
        Luz[4].enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && gameObject.tag == "ligar")
        {
            Luz[0].enabled = true;
            Luz[1].enabled = true;
            Luz[2].enabled = true;
            Luz[3].enabled = true;
            Luz[4].enabled = true;
            gameObject.tag = "ligado";
            count++;
            StartCoroutine(Desligar());

        }
        if (count == 2)
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
