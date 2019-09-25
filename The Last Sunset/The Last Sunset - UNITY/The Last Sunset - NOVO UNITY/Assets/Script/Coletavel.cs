using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletavel : MonoBehaviour
{
    [SerializeField] AudioClip[] musicas;

    private void Start()
    {
       // Destroy(gameObject, 30);
    }

    private void OnTriggerEnter(Collider other)
    {
        SoundManager.instance.RandomPlay(musicas);
        Destroy(gameObject);       
    }

   
}

