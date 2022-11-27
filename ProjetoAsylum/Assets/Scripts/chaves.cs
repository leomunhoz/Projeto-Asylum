using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaves : MonoBehaviour
{
    public InventarioChaves auxChaves;
    public int idChaves;
    public GameObject UIChaves;
    bool Trigger;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Trigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                auxChaves.chaves[idChaves] = true;
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UIChaves.SetActive(true);
            Trigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        UIChaves.SetActive(false);
        Trigger = false;
    }
}
