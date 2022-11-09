using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class InventarioChaves : MonoBehaviour
{
    public bool[]chaves;
    public PhotonView view;
    // Start is called before the first frame update
    void Start()
    {
        if (view.IsMine)
        {
            chaves[] aux = FindObjectsOfType<chaves>();
            foreach (chaves item in aux)
            {
                item.auxChaves = this;
            }

            PortaChave[] portas = FindObjectsOfType<PortaChave>();
            foreach (PortaChave item in portas)
            {
                item.auxChaves = this;
            }
        }
       
        chaves = new bool[4];
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
