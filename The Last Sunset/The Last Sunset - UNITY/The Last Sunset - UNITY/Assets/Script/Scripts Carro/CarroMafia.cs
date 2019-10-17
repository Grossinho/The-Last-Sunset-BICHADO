using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarroMafia : MonoBehaviour
{
    Rigidbody rgb;
    private bool capotado;

    //public GameObject player;

    
    [SerializeField] private float velo;
   

    // Start is called before the first frame update
    void Start()
    {
        capotado = false;
        rgb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!capotado)
            rgb.velocity = transform.forward * velo;
        else
            rgb.velocity -= Vector3.zero;
    }

    public void CapotaMafia()
    {       
        capotado = true;
    }
}
