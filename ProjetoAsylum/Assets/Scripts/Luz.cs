using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luz : MonoBehaviour
{
    public Light luz;

    public float minTemp;
    public float maxTemp;
    public float temp;
   // public WrapMode wrap = WrapMode.PingPong;

    // Start is called before the first frame update
    void Start()
    {
        temp = Random.Range(minTemp,maxTemp);
        
    }

    // Update is called once per frame
    void Update()
    {

        Falhar();
       
    }

    void Falhar() 
    {
        if (temp > 0)
        {
            temp -= Time.deltaTime;
        }

        if (temp <= 0)
        {
            luz.enabled = !luz.enabled;
            temp = Random.Range(minTemp, maxTemp);

        }
    }
}
