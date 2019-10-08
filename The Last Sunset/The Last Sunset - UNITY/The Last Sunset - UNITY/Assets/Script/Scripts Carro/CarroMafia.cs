using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarroMafia : MonoBehaviour
{
    Rigidbody rgb;


    public GameObject player;

    float offset;
    float trans;
    [SerializeField] private float velo;
    public bool colide;

    // Start is called before the first frame update
    void Start()
    {

        rgb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rgb.velocity = transform.forward * velo;

        
        /*
         * transform.position = new Vector3 (transform.position.x, transform.position.y, offset + player.transform.position.z);
        
        offset += velo* Time.deltaTime;

         trans += trans + Mathf.Sin(Time.deltaTime) * 8;
         */
    }
}
