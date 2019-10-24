using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Recorde : MonoBehaviour
{
    [SerializeField] Text textoRecorde;
    string penis;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("CUCCUCUCCUCU");
        CarregaRecorde();
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    void CarregaRecorde()
    {
        textoRecorde.text = PlayerPrefs.GetFloat(penis, 0).ToString();       
    }
}
