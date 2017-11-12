using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GuanQiaPanel : MonoBehaviour
{
    public GameObject guanQiaPanel;
    public GameObject GamePanel;
    public Button Button_guanqiaStar;
 

    public Button Btn_left1;
    public Button Btn_right1;
    public GameObject BeginPanel;
    public GameObject LevelPanel;
    public GameObject Level3Panel;
    public GameObject Level2Panel;

    public Button Btn_back;


    public GameObject MyPanel;
    
    // Use this for initialization
    void Start()
    {
        Button_guanqiaStar.onClick.AddListener(Onclick_Begin);
        Btn_left1.onClick.AddListener(Onclick_Btn_left1);
        Btn_right1.onClick.AddListener(Onclick_Btn_right1);

        Btn_back.onClick.AddListener(Onclick_Btn_back);
        //Ico.sprite = Resources.Load<Sprite>("123");
    }

    public void Onclick_Begin()
    {

        Debug.Log("this is level1");
        SceneManager.LoadScene("02");
    }

    public void Onclick_Btn_back()
    {

        BeginPanel.SetActive(true);
        LevelPanel.SetActive(false);
    }

    public void Onclick_Btn_left1()
    {
        Debug.Log("left1");
        Level3Panel.SetActive(true);
    }

    public void Onclick_Btn_right1()
    {
        Debug.Log("right");
        Level2Panel.SetActive(true);
    }

  

}
