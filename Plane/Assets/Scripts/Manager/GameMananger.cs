using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public enum GameState
{
    Running,
    Pause,
}
public class GameMananger : MonoBehaviour
{
    public bool isWin = false;
    public Text scoreText;  //获取显示分数的组件

    public Sprite[] GameStateSprite;  //精灵数组，存放游戏继续和游戏暂停两个图标

    public Button GameStateButton; //游戏继续暂停按钮
    public GameObject GameContinueButton; //游戏继续按钮
    public GameObject GameQuitButton; //游戏退出按钮

    public static GameMananger _instance; //实例化一个对象
    public int score;  //分数

    public GameState gs = GameState.Running;

    void Start()
    {
        _instance = this;  //实例化一个对象
    }

    public void switchGameState()
    {
        if (gs == GameState.Running)
        {
            pauseGame();
        }
        else if (gs == GameState.Pause)
        {
            continueGame();
        }

    }

    public void pauseGame()
    {
        Time.timeScale = 0;
        GameStateButton.GetComponent<Image>().sprite = GameStateSprite[1];
        gs = GameState.Pause;
        GameContinueButton.SetActive(true);
        GameQuitButton.SetActive(true);
    }

    public void continueGame()
    {
        Time.timeScale = 1;
        GameStateButton.GetComponent<Image>().sprite = GameStateSprite[0];
        gs = GameState.Running;
        GameContinueButton.SetActive(false);
        GameQuitButton.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit(); //如果点击的是退出游戏按钮，则关闭游戏
    }

    public void addScore(int sc)  //增加分数方法
    {
        this.score = score + sc;
        scoreText.text = "Score:" + score;//显示分数
    }
}
