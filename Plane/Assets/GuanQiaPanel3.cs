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

    // Use this for initialization
    void Start()
    {
        Btn_level3.onClick.AddListener(Onclick_Btn_level3);
        Btn_left3.onClick.AddListener(Onclick_Btn_left3);
        Btn_right3.onClick.AddListener(Onclick_Btn_right3);

        //Ico.sprite = Resources.Load<Sprite>("123");
    }

    public void Onclick_Btn_level3()
    {

        Debug.Log("this is level3");
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

