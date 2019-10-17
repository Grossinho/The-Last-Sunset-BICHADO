using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] Text textoDistancia, textoMusica;
    [SerializeField] RectTransform posTextoMusica;
    [SerializeField] Transform carroPos;
    [SerializeField] float aumentoDistancia, velocidadeTexto;
    [SerializeField] AudioSource aud;
    float distancia;
    Vector3 posInicial, textoPosInicial;
    [SerializeField] float tempo = 3;

   
    [SerializeField] MeshRenderer carroMafia1;
    [SerializeField] MeshRenderer carroMafia2;
    [SerializeField] MeshRenderer carroMafia3;
    [SerializeField] MeshRenderer carroMafia4;
    [SerializeField] MeshRenderer carroMafia5;
    [SerializeField] Collider coliderCarroMafia;
   
    private void Start()
    {
        textoMusica.text = "Colete fitas para ouvir alguma coisa!";
        posInicial = carroPos.position;

        textoPosInicial = textoMusica.transform.localPosition;
        
        carroMafia1.enabled = false;
        carroMafia2.enabled = false;
        carroMafia3.enabled = false;
        carroMafia4.enabled = false;
        carroMafia5.enabled = false;
        coliderCarroMafia.enabled = false;

    }
    private void Update()
    {
        distancia = Mathf.Round(Vector3.Distance(posInicial, carroPos.position) * aumentoDistancia);
        textoDistancia.text = distancia.ToString();

        textoMusica.text = aud.clip.ToString();
        textoMusica.transform.localPosition += new Vector3(-velocidadeTexto * Time.deltaTime, 0, 0);

        if (textoMusica.transform.localPosition.x < textoPosInicial.x - textoMusica.text.Length * 13)
        {
            textoMusica.transform.localPosition = textoPosInicial;
        }


        if (!carroMafia1.enabled && distancia >= tempo )
        {
            
            carroMafia1.enabled = true;
            carroMafia2.enabled = true;
            carroMafia3.enabled = true;
            carroMafia4.enabled = true;
            carroMafia5.enabled = true;
            coliderCarroMafia.enabled = true;
        }




    }


}



