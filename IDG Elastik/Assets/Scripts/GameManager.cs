using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public int levelsPassed = 0;
    public int allLevels = 10;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public static GameManager Get()
    {
        return instance;
    }
    public int nextSceneToLoad;
    public void LoadSpecificScene(int nextSceneNum)
    {
        nextSceneToLoad = nextSceneNum;
        SceneManager.LoadScene("LoadingScene");
    }
    public int GetCurrentLvl()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
    public void UpdateLevelsWon(int levelWon)
    {
        if (levelWon > levelsPassed)
            levelsPassed++;
    }
}
