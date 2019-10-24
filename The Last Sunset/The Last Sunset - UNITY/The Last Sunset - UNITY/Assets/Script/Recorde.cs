using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Recorde : MonoBehaviour
{
    [SerializeField] Text textoRecorde;
    float[] recordes = new float[4];
    float RecordAtual;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < 4; i++)
        {
            recordes[i] = PlayerPrefs.GetFloat("Records", 0);
           
        }
            
        if (RecordAtual > recordes[3])
        {
            if (RecordAtual > recordes[2])
            {
                if (RecordAtual > recordes[1])
                {
                    recordes[1] = RecordAtual;
                }
                else recordes[2] = RecordAtual;
            }
            else recordes[3] = RecordAtual;            
        }

        for (int i = 1; i < 4; i++)
        {
            textoRecorde.text += recordes[i].ToString() + Environment.NewLine;

        }

        RecordAtual = PlayerPrefs.GetFloat("Record");
    }

    // Update is called once per frame
    void Update()
    {
    }

    void CarregaRecorde()
    {
        textoRecorde.text = PlayerPrefs.GetFloat("Record", 0).ToString();       
    }
}
