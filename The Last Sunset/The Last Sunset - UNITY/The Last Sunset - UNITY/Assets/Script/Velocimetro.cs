using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocimetro : MonoBehaviour
{

    public Transform ponteiroEixoZ;
    public float angleFactor = -5f;
    float velocidadeAtual;

    Vector3 startEulerAngles;
    Rigidbody _rigidbody;
    float velocidade;

    void Start()
    {
        startEulerAngles = ponteiroEixoZ.transform.localEulerAngles;
        _rigidbody = GetComponent<Rigidbody>();

        velocidadeAtual = _rigidbody.velocity.magnitude;

    }

    void Update()
    {
       // velocidade = _rigidbody.velocity.magnitude * 3.6f;
        ponteiroEixoZ.transform.localEulerAngles = new Vector3(startEulerAngles.x, startEulerAngles.y, startEulerAngles.z + velocidade * angleFactor);

        if(velocidade < velocidadeAtual)
        {
            ponteiroEixoZ.transform.localEulerAngles = new Vector3(startEulerAngles.x, startEulerAngles.y, startEulerAngles.z + velocidade * angleFactor * Time.deltaTime);
        }
    }
}
