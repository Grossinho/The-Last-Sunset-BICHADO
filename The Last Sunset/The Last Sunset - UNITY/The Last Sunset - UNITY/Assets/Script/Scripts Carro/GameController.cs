using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] Text textoDistancia, textoMusica, textoMusica2;
    [SerializeField] Transform carroPos;
    [SerializeField] float aumentoDistancia, velocidadeTexto;
    [SerializeField] AudioSource aud;
    float distancia;
    Vector3 posInicial, textoPosInicial, textoPosInicial2;

    private void Start()
    {
        posInicial = carroPos.position;
        textoPosInicial = textoMusica.transform.localPosition;
        textoPosInicial2 = new Vector3(textoMusica.transform.localPosition.x + textoMusica.text.Length * 8, textoMusica.transform.localPosition.y, textoMusica.transform.position.z);
        textoMusica2.transform.localPosition = textoPosInicial2;
  
    }
    private void Update()
    {
        distancia = Mathf.Round(Vector3.Distance(posInicial, carroPos.position) * aumentoDistancia) ;
        textoDistancia.text = distancia.ToString();

        textoMusica.text = aud.clip.ToString();
        textoMusica.transform.localPosition += new Vector3(-velocidadeTexto * Time.deltaTime, 0, 0);
        
        if (textoMusica.transform.localPosition.x < textoPosInicial.x - textoMusica.text.Length * 13)
        {
            textoMusica.transform.localPosition = textoPosInicial;
        }

    }


}



