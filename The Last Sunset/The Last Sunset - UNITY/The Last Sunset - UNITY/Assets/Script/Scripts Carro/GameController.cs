using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] Text textoDistancia;
    [SerializeField] Transform carroPos;
    float distancia;
    Vector3 posInicial;

    private void Start()
    {
        posInicial = carroPos.position;
    }
    private void Update()
    {
        Debug.Log(distancia);
        distancia = Mathf.Round(Vector3.Distance(posInicial, carroPos.position) * 0.005f) ;
        textoDistancia.text = distancia.ToString();
    }


}



