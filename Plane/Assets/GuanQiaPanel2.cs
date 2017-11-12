using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GuanQiaPanel2 : MonoBehaviour
{

    public GameObject GamePanel;
    public Button Btn_level2;
    public Button Btn_back2;


    public Button Btn_left2;
    public Button Btn_right2;
    public GameObject BeginPanel;
    public GameObject LevelPanel;
    public GameObject Level2Panel;
    public GameObject Level3Panel;


    public GameObject MyPanel;

    // Use this for initialization
    void Start()
    {
        Btn_level2.onClick.AddListener(Onclick_Btn_level2);
        Btn_left2.onClick.AddListener(Onclick_Btn_left2);
        Btn_right2.onClick.AddListener(Onclick_Btn_right2);
        Btn_back2.onClick.AddListener(Onclick_Btn_back2);
        //Ico.sprite = Resources.Load<Sprite>("123");
    }

    public void Onclick_Btn_level2()
    {

        Debug.Log("this is level2");
        SceneManager.LoadScene("02");
    }

    public void Onclick_Btn_left2()
    {
        Debug.Log("left2");
     
        LevelPanel.SetActive(true);
    }

    public void Onclick_Btn_right2()
    {
        Debug.Log("right2");
        Level3Panel.SetActive(true);
    }

    public void Onclick_Btn_back2()
    {
        Level2Panel.SetActive(true);
        BeginPanel.SetActive(true);
    }



}

