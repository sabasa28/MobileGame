using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    [SerializeField] int scoreNeededToWin = 100;
    [SerializeField] int currentScore = 0;
    [SerializeField] int startingBalls = 3;
    [SerializeField] Player player = null;
    int ballsUsed = 0;
    UIGameplay uiGameplay;
    int lvlNumber;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    private void Start()
    {
        uiGameplay = FindObjectOfType<UIGameplay>();
        uiGameplay.UpdateScore(currentScore,scoreNeededToWin);
        uiGameplay.UpdateBallsLeft(startingBalls);
        lvlNumber = GameManager.Get().GetCurrentLvl();
        Cup[] cups = FindObjectsOfType<Cup>();
        for (int i = 0; i < cups.Length; i++)
        {
            cups[i].AddToScore = AddToScore;
        }
    }

    private void OnDestroy()
    {
        if (instance == this)
            instance = null;
    }

    public static LevelManager Get()
    {
        return instance;
    }

    public void AddToScore(int toAdd)
    {
        currentScore += toAdd;
        uiGameplay.UpdateScore(currentScore, scoreNeededToWin);
        player.ResetRotation();
        if (currentScore >= scoreNeededToWin)
        {
            GameManager.Get().UpdateLevelsWon(lvlNumber);
            uiGameplay.OnLevelFinished(true);
        }
    }

    public bool CheckOnOutOfBalls()
    {
        ballsUsed++;
        uiGameplay.UpdateBallsLeft(startingBalls - ballsUsed);
        if (ballsUsed < startingBalls)
            return false;
        else
        {
            uiGameplay.OnLevelFinished(false);
            return true;
        }
    }

    public bool IsNextLVLUnlocked()
    {
        return (lvlNumber <= GameManager.Get().levelsPassed);
    }

    public int GetLvlNum()
    {
        return lvlNumber;
    }
}
