using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Velocimetro : MonoBehaviour
{
    public Image veloci;  
    float velocidadeAtual;

    Vector3 startEulerAngles;
    Rigidbody _rigidbody;
    float velocidade;

    void Start()
    {
        
        _rigidbody = GetComponent<Rigidbody>();


    }

    void Update()
    {
        velocidade = _rigidbody.velocity.magnitude * 3.6f;

        veloci.fillAmount = 2/velocidade ;
        
    }
}
