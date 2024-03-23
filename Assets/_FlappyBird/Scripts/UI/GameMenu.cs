using System;
using GameTool;
using TMPro;

public class GameMenu : SingletonUI<GameMenu>
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highestScoreText;

    public void UpdateScore(int amount)
    {
        GameData.Instance.score += amount;
        scoreText.text = "Score:" + GameData.Instance.score;
        if (GameData.Instance.score > GameData.Instance.HighestScore)
        {
            GameData.Instance.HighestScore = GameData.Instance.score;
            highestScoreText.text = "Highest Score:" + GameData.Instance.score;
        }
    }

    private void Start()
    {
        scoreText.text = "Score: 0";
        highestScoreText.text = "Highest Score:" + GameData.Instance.HighestScore;
    }
}