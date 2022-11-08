using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaves : MonoBehaviour
{
    public InventarioChaves auxChaves;
    public int idChaves;
    bool Trigger;
    // Start is called before the first frame update
    void Start()
    {
       auxChaves = GetComponent<InventarioChaves>();
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
            Trigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Trigger = false;
    }
}
