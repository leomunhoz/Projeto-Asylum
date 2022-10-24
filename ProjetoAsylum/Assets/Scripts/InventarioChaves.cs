using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarioChaves : MonoBehaviour
{
    public Boolean[]chaves;
    // Start is called before the first frame update
    void Start()
    {
        chaves = new Boolean[4];
        chaves[0] = false;
        chaves[1] = false;
        chaves[2] = false;
        chaves[3] = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
