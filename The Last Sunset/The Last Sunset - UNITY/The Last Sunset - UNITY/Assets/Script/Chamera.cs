﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chamera : MonoBehaviour
{


    public Vector3 offset;

    public GameObject camer;


    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - camer.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = offset + camer.transform.position;
    }
}
