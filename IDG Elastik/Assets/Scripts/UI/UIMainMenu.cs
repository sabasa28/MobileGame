using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] GameObject lvlSelec = null;
    [SerializeField] GameObject credits = null;
    [SerializeField] GameObject instructions = null;


    public void OpenLevelSelector()
    {
        lvlSelec.SetActive(true);
    }

    public void CloseLvlSelector()
    {
        lvlSelec.SetActive(false);
    }

    public void ShowCredits()
    {
        credits.SetActive(true);
    }

    public void HideCredits()
    {
        credits.SetActive(false);
    }
    public void ShowInstructions()
    {
        instructions.SetActive(true);
    }

    public void HideInstructions()
    {
        instructions.SetActive(false);
    }

    public void CloseApplication()
    {
        Application.Quit();
    }

    public void StartLevelLoad(int levelNum)
    {
        GameManager.Get().LoadSpecificScene(levelNum);
    }
}
