using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIGameplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText = null;
    [SerializeField] TextMeshProUGUI ballsLeftText = null;
    [SerializeField] TextMeshProUGUI resultText = null;
    [SerializeField] GameObject resultPanel = null;
    [SerializeField] Button pauseButton = null;
    [SerializeField] Button nextLevelButton = null;
    [SerializeField] Player player = null;
    string lvlCompletedText = "Level Completed";
    string lvlFailedText = "Level Failed";

    public void OnLevelFinished(bool win)
    {
        if (win)
            resultText.text = lvlCompletedText;
        else
            resultText.text = lvlFailedText;
        ActivateResultPanel();
    }
    public void OnPauseButtonClick()
    {
        ActivateResultPanel();
    }
    void ActivateResultPanel()
    {
        if (resultPanel.activeInHierarchy)
        {
            resultPanel.SetActive(false);
            Time.timeScale = 1.0f;
        }
        else
        {
            nextLevelButton.interactable = LevelManager.Get().IsNextLVLUnlocked();
            resultPanel.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void OnButtonRightDown()
    {
        player.RotatePlatform(-1.0f);
    }
    public void OnButtonMovementUp()
    {
        player.RotatePlatform(0.0f);
    }
    public void OnButtonLeftDown()
    {
        player.RotatePlatform(1.0f);
    }

    public void UpdateScore(int currentScore, int neededScore)
    {
        scoreText.text = "Score: " + currentScore + " / " + neededScore;
    }
    public void UpdateBallsLeft(int ballsLeft)
    {
        ballsLeftText.text = "Balls: " + ballsLeft;
    }

    public void OnNextButtonClick()
    {
        GameManager.Get().LoadNextLevel();
    }

    public void OnMenuButtonClick()
    {
        GameManager.Get().LoadSpecificScene(0);
    }
    public void OnRestartButtonClick()
    {
        GameManager.Get().LoadSpecificScene(LevelManager.Get().GetLvlNum());
    }
}
