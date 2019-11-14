using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletavel : MonoBehaviour
{
    [SerializeField] AudioClip[] musicas;
    [SerializeField] AudioSource mudaMusica;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            StartCoroutine(toca());

        }
    }

    IEnumerator toca()
    {
        mudaMusica.Play();
        yield return new WaitForSeconds(3f);
        SoundManager.instance.RandomPlay(musicas);
        Destroy(gameObject);
    }

   
}

