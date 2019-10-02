using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] Text textoDistancia, textoMusica;
    [SerializeField] RectTransform posTextoMusica;
    [SerializeField] Transform carroPos;
    [SerializeField] float aumentoDistancia;
    [SerializeField] AudioSource aud;
    float distancia;
    Vector3 posInicial;

    private void Start()
    {
        textoMusica.text = "Colete fitas para ouvir alguma coisa!";
        posInicial = carroPos.position;
  
    }
    private void Update()
    {
        distancia = Mathf.Round(Vector3.Distance(posInicial, carroPos.position) * aumentoDistancia) ;
        textoDistancia.text = distancia.ToString();

        textoMusica.text = aud.clip.ToString();
        Vector3 oi = new Vector3(posTextoMusica.position.x + Time.fixedDeltaTime, posTextoMusica.position.y, posTextoMusica.position.z);
        posTextoMusica.position = oi;
        
    }


}



