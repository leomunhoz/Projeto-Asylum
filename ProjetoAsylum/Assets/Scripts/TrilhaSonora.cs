using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrilhaSonora : MonoBehaviour
{
    public AudioSource audioTrilha;
    public AudioClip[] Trilha;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioTrilha.isPlaying)
        {
            audioTrilha.PlayOneShot(Trilha[Random.Range(0,Trilha.Length)]);
        }
    }

    

    
}
