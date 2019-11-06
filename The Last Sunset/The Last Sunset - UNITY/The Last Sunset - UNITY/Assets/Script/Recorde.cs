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
    string[] nomes = new string[4]; 
    float RecordAtual;
    string nomeAtual;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("AtualizaRecorde", 1, 1);
    }


    void CarregaRecorde(int i, float v, string nome)
    {
        PlayerPrefs.SetFloat("Record" + i.ToString(), v);
        PlayerPrefs.SetString("Nome" + i.ToString(), nome);
    }

    void AtualizaRecorde()
    {
        RecordAtual = PlayerPrefs.GetFloat("Record");
        nomeAtual = PlayerPrefs.GetString("Nome");

        for (int i = 1; i < 4; i++)
        {
            recordes[i] = PlayerPrefs.GetFloat("Record" + i.ToString(), 0);
            nomes[i] = PlayerPrefs.GetString("Nome" + i.ToString(), "AAA");
        }

        if (RecordAtual > recordes[3])
        {
            if (RecordAtual > recordes[2])
            {
                if (RecordAtual > recordes[1])
                {
                    CarregaRecorde(3, PlayerPrefs.GetFloat("Record2"), nomes[2]);
                    CarregaRecorde(2, PlayerPrefs.GetFloat("Record1"), nomes[1]);
                    CarregaRecorde(1, RecordAtual, nomeAtual);
                }
                else
                {
                    CarregaRecorde(3, PlayerPrefs.GetFloat("Record2"), nomes[2]);
                    CarregaRecorde(2, RecordAtual, nomeAtual);
                }

            }
            else CarregaRecorde(3, RecordAtual, nomeAtual);
        }
        PlayerPrefs.SetFloat("Record", 0);
        PlayerPrefs.SetString("Nome", "AAA");

        textoRecorde.text = null;
        for (int i = 1; i < 4; i++)
        {
            textoRecorde.text += nomes[i] + ":" + " " + recordes[i].ToString() + Environment.NewLine;
            Debug.Log(nomes[i]);
        }
    }
}
