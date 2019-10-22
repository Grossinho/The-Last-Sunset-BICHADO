using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriaCarros : MonoBehaviour
{

    [SerializeField] List <Transform> pos;  
    [SerializeField] List <GameObject> carros;
    [SerializeField] GameObject Fita;
    [SerializeField] Transform spawnFita;
    [SerializeField] float VelocidadeObstaculo;



    [HideInInspector] public CriaCarros instancia;

    float cronometro;
    float geraFita;

    
    private void Awake()
    {
        
        if(instancia = null)
        {
            instancia = this;
        }
        else if(instancia != null)
        {
            Destroy(this);
        }

    }



    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {

        cronometro += 1 * Time.deltaTime;
        geraFita += 1 * Time.deltaTime;

        if (cronometro > 2)
        {

            RetornaCarro();
            cronometro = 0;

        }
        

        if (geraFita > 10)
        {
            Instantiate(Fita, new Vector3 (spawnFita.position.x, spawnFita.position.y - 1.5f, spawnFita.position.z), Fita.transform.rotation);
            geraFita = 0;
        }

        
    }

    void RetornaCarro()
    {


        GameObject veiculos = (GameObject)Instantiate(carros[Random.Range(0,carros.Count)], pos[Random.Range(0, pos.Count)].position, pos[0].rotation);



        veiculos.GetComponent<Transform>().Rotate(new Vector3(0, 180, 0));
        //veiculos.GetComponent<Rigidbody>().velocity = transform.forward * 20f;
        //veiculos.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 150) * -50);



        Destroy(veiculos, 25f);
    }


    



}
