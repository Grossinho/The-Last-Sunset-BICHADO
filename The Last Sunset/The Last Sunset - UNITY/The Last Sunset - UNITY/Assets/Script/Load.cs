using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    public GameObject loadingObj;
    public Slider slider;

    AsyncOperation async;

    public void LoadScene()
    {
        StartCoroutine(loading());
    }

    IEnumerator loading()
    {
        loadingObj.SetActive(true);
        async = SceneManager.LoadSceneAsync(0);
        async.allowSceneActivation = false;

        while (async.isDone == false)
        {
            slider.value = async.progress;
            if (async.progress == 0.9f)
            {
                slider.value = 1f;
                async.allowSceneActivation = true;
            }

            yield return null;
        }
    }


}
