using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NomeRecorde : MonoBehaviour
{
    InputField caixaNome;
    [SerializeField]Text texto;

    private void Start()
    {
        caixaNome = GetComponent<InputField>();
    }

    public void AtualizaNome()
    {
        PlayerPrefs.SetString("Nome", texto.text);
    }
}
