using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UILevelSelecButton : MonoBehaviour
{
    [SerializeField] UIMainMenu uiMainMenu = null;
    [SerializeField] int levelToGoTo = 0;
    TextMeshProUGUI levelNumberDisplayed;

    private void Start()
    {
        levelNumberDisplayed = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        levelNumberDisplayed.text = levelToGoTo.ToString();
        if (GameManager.Get().levelsPassed + 1 < levelToGoTo)
        {
            GetComponent<Button>().interactable = false;
        }
    }

    public void LoadLevel()
    {
        uiMainMenu.StartLevelLoad(levelToGoTo);
    }
}
