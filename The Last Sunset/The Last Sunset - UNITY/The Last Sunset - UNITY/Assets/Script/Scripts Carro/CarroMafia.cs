using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarroMafia : MonoBehaviour
{



    float trocafaixa;
    
    Rigidbody rgb;
    [SerializeField] private float velo;
   

    // Start is called before the first frame update
    void Start()
    {
        trocafaixa = transform.position.x;
        rgb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
            rgb.velocity = transform.forward * velo;
       
    }

    public void CapotaMafia()
    {       
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Veiculo")) ;
           
           


    }
}
