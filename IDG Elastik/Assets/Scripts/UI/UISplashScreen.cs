using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UISplashScreen : MonoBehaviour
{
    [SerializeField] Image splashScreen = null;
    int timeInSplash = 2;

    private void Start()
    {
        StartCoroutine(FadeOut());
    }
    IEnumerator FadeOut()
    {
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime / timeInSplash;
            splashScreen.color = Color.Lerp(Color.white, new Color(1, 1, 1, 0), t);
            yield return null;
        }
        SceneManager.LoadScene("MainMenu");
    }
}
