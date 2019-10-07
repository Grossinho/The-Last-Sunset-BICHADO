using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarroMafia : MonoBehaviour
{



    public GameObject player;

    float offset;
    float trans;


    // Start is called before the first frame update
    void Start()
    {
        trans = transform.position.x;
        offset = transform.position.z - player.transform.position.z;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, offset + player.transform.position.z);



        trans += trans + Mathf.Sin(Time.deltaTime) * 8;


    }
}
