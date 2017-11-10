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
    public Image Ico;
    // Use this for initialization
    void Start()
    {
        Button_guanqiaStar.onClick.AddListener(Onclick_Begin);
        //Ico.sprite = Resources.Load<Sprite>("123");
    }

    public void Onclick_Begin()
    {

        SceneManager.LoadScene("02");
    }


}
