using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Load : MonoBehaviour
{
    public GameObject LoadJogo;
    public Slider slider;
    public Text progressoTexto;
    
    public void Loadjogo (int index)
    {
        StartCoroutine(LoadAsynchronosly(index));
    }

    IEnumerator LoadAsynchronosly (int sceneIndex)
    {
        LoadJogo.SetActive(true);


        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            float progresso = Mathf.Clamp(operation.progress / 0.9f, 0, 1);
            slider.value = progresso;
            Debug.Log(progresso);
            progressoTexto.text = progresso * 100 + "%";
            yield return null;
        }
    }
}
