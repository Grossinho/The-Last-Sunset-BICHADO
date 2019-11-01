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
        Invoke("AtualizaRecorde", 2);

    }


    void CarregaRecorde(int i, float v)
    {
        PlayerPrefs.SetFloat("Record" + i.ToString(), v);       
    }

    void AtualizaRecorde()
    {
        RecordAtual = PlayerPrefs.GetFloat("Record");


        for (int i = 1; i < 4; i++)
        {
            recordes[i] = PlayerPrefs.GetFloat("Record" + i.ToString(), 0);
        }

        if (RecordAtual > recordes[3])
        {
            if (RecordAtual > recordes[2])
            {
                if (RecordAtual > recordes[1])
                {
                    CarregaRecorde(3, PlayerPrefs.GetFloat("Record2"));
                    CarregaRecorde(2, PlayerPrefs.GetFloat("Record1"));
                    CarregaRecorde(1, RecordAtual);
                }
                else
                {
                    CarregaRecorde(3, PlayerPrefs.GetFloat("Record2"));
                    CarregaRecorde(2, RecordAtual);
                }

            }
            else CarregaRecorde(3, RecordAtual);
        }
        PlayerPrefs.SetFloat("Record", 0);

        for (int i = 1; i < 4; i++)
        {
            textoRecorde.text += recordes[i].ToString() + Environment.NewLine;
        }
    }
}
