using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text nowScoreText;
    public Text highScoreText;

    // Use this for initialization
    void Start()
    {
        showScore();
    }

    public void showScore()
    {
        int nowScore = GameMananger._instance.score;
        int historyScore = PlayerPrefs.GetInt("historyHighScore", 0);
        if (nowScore > historyScore)
        {
            PlayerPrefs.SetInt("historyHighScore", nowScore);
        }
        highScoreText.text = historyScore.ToString();
        this.nowScoreText.text = nowScore.ToString();
    }
}
