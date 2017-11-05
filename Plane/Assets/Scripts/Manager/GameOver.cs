using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text tieText;
    public Text scoreText;
    public Button nextLevelText;

    // Use this for initialization
    void Start()
    {
        showScore();
    }

    public void showScore()
    {
        if (GameMananger._instance.isWin)
        {
            tieText.text = "取 得 胜 利";

            if (PlayerPrefs.GetInt("playerLevelChange", 0) < 2)
            {
                nextLevelText.gameObject.SetActive(true);
            }
        }
        else
        {
            tieText.text = "通 关 失 败";
            nextLevelText.gameObject.SetActive(false);
        }

        int nowScore = GameMananger._instance.score;
        this.scoreText.text = nowScore.ToString();
    }
}
