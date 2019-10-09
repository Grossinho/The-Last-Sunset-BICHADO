using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarroMafia : MonoBehaviour
{
    Rigidbody rgb;
    

    //public GameObject player;

    
    [SerializeField] private float velo;
   

    // Start is called before the first frame update
    void Start()
    {
       
        rgb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rgb.velocity = transform.forward * velo;

        
        
         
    }
}
