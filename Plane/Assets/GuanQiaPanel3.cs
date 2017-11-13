using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GuanQiaPanel3 : MonoBehaviour
{
    public GameObject guanQiaPanel3;
    public GameObject GamePanel;
    public Button Btn_level3;


    public Button Btn_left3;
    public Button Btn_right3;
    public GameObject Level2Panel;
    public GameObject LevelPanel;


    public GameObject MyPanel;
    //修改星星数量
    public Image starImage;
    public Image starImage2;
    public Image starImage3;

    // Use this for initialization
    void Start()
    {
        Btn_level3.onClick.AddListener(Onclick_Btn_level3);
        Btn_left3.onClick.AddListener(Onclick_Btn_left3);
        Btn_right3.onClick.AddListener(Onclick_Btn_right3);
        //Ico.sprite = Resources.Load<Sprite>("123");
        showDifferNumberStar();
    }
    //根据玩家的评分显示对应数量的星星
    private void showDifferNumberStar()
    {
        //获取玩家的难度选择
        int playerLevel = PlayerPrefs.GetInt("playChangeDifficuty", 0);
        int starNumber = 0;
        switch (playerLevel)
        {
            case 0:  //简单
                //获得玩家当前关卡的星星数
                starNumber = PlayerPrefs.GetInt("starsNum3_2", 0);
                break;
            case 1:  //正常
                //获得玩家当前关卡的星星数
                starNumber = PlayerPrefs.GetInt("starsNum3_4", 0);
                break;
            case 2:  //困难
                //获得玩家当前关卡的星星数
                starNumber = PlayerPrefs.GetInt("starsNum3_6", 0);
                break;
        }
        //控制显示
        this.controlStarNumber(starNumber);
    }
    //控制星星的显示
    private void controlStarNumber(int num)
    {
        Sprite sp = Resources.Load("Background/关卡/任务达成", typeof(Sprite)) as Sprite;
        switch (num)
        {
            case 0:  //0星
                //不显示任何东西
                break;
            case 1:  //1星
                starImage = transform.Find("Img_point1").GetComponent<Image>();
                starImage.sprite = sp;
                break;
            case 2:  //2星
                starImage = transform.Find("Img_point1").GetComponent<Image>();
                starImage.sprite = sp;

                starImage2 = transform.Find("Img_point2").GetComponent<Image>();
                starImage2.sprite = sp;
                break;
            case 3:  //3星
                starImage = transform.Find("Img_point1").GetComponent<Image>();
                starImage.sprite = sp;

                starImage2 = transform.Find("Img_point2").GetComponent<Image>();
                starImage2.sprite = sp;

                starImage3 = transform.Find("Img_point3").GetComponent<Image>();
                starImage3.sprite = sp;
                break;
        }
    }
    public void Onclick_Btn_level3()
    {
        Debug.Log("this is level3");
        PlayerPrefs.SetInt("playerLevelChange", 2);//玩家关卡
        SceneManager.LoadScene("02");
    }

    public void Onclick_Btn_left3()
    {
        Debug.Log("left3");
        Level2Panel.SetActive(true);
    }

    public void Onclick_Btn_right3()
    {
        Debug.Log("right3");
        LevelPanel.SetActive(true);
    }



}

