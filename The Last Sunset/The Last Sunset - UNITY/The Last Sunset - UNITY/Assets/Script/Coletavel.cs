using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletavel : MonoBehaviour
{
    [SerializeField] AudioClip[] musicas;



    CarroMafia car;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SoundManager.instance.RandomPlay(musicas);
            Destroy(gameObject);       

        }
    }

   
}

