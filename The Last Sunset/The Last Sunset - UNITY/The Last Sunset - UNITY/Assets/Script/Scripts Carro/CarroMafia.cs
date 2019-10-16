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
        rgb.velocity = transform.forward * velo;
    }

    // Update is called once per frame
    void Update()
    {
        if (capotado)
            transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);
    }

    public void CapotaMafia()
    {
        rgb.velocity = transform.forward * 0;
        capotado = true;
    }
}
