using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UILoadScreen : MonoBehaviour
{
    [SerializeField] float minTimeToLoad = 2.0f;
    public int sceneToLoad;
    [SerializeField] Slider loadingBar = null;

    private void Start()
    {
        StartLoad(GameManager.Get().nextSceneToLoad);   
    }
    void StartLoad(int scene)
    {
        sceneToLoad = scene;
        StartCoroutine(PreloadScene());
    }
    IEnumerator PreloadScene()
    {
        Time.timeScale = 1.0f;
        float loadingProgress;
        float timeLoading = 0;
        if (!SceneManager.GetSceneByBuildIndex(sceneToLoad).isLoaded)
        {
            AsyncOperation ao = SceneManager.LoadSceneAsync(sceneToLoad);
            ao.allowSceneActivation = false;

            while (!ao.isDone)
            {
                timeLoading += Time.deltaTime;
                loadingProgress = ao.progress + 0.1f;
                loadingProgress = loadingProgress * timeLoading / minTimeToLoad;
                loadingBar.value = loadingProgress;
                
                if (loadingProgress >= 1) // Loading completed
                {
                    ao.allowSceneActivation = true;

                }
                yield return null;
            }
        }
    }
}
