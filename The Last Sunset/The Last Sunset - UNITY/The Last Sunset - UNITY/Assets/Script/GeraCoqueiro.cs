using System.Collections;

using System.Collections.Generic;
using UnityEngine;



public class GeraCoqueiro : MonoBehaviour
{
    public GameObject plane;
   

    float tempo;
    int KMAnterior;
    int KMAtual;

    Vector3 startPos;

    [SerializeField]float cronometro = 1;



    // Start is called before the first frame update
    void Start()
    {
        KMAnterior = 0;
        KMAtual = 0;


    }

    // Update is called once per frame
    void Update()
    {
        tempo += cronometro * Time.deltaTime;
        KMAtual = (int)GameController.instancia.distancia;

        if (KMAtual != KMAnterior)
        {
            RetornaCarro();
            KMAnterior = KMAtual;
        }

        if (tempo > 5)
        {

            RetornaCarro();
            tempo = 0;

        }
    }


    void RetornaCarro()
    {


        GameObject Coco = (GameObject)Instantiate(plane, transform.position, transform.rotation);


        Destroy(Coco, 15f);
    }
}

