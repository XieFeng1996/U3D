using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

public class BeginPanel : MonoBehaviour 
{
	public RectTransform Mytranform;
	public BeginPanel MyScript;
	public Button Btn_Begin;
	public GameObject Gameobject;



	//public GameObject nanduPanel;
	//public Button Btn_1;

	public Button Btn_set;
	public GameObject setPanel;
    public GameObject teamPanel;
    public GameObject rulePanel;
    
    public Button Btn_team;
    public Button Btn_reset;
    public Button Btn_rule;
    
    public Button Btn_close;
    public Button Btn_close2;

    public GameObject difficlutyPanel;
    public Button Btn_difficulty;
    public Button Btn_easy;
    public Button Btn_normal;
    public Button Btn_difficult;



    public GameObject MyPanel;
	public bool ifShow;
    public bool ifDifShow;

    public Text test;
    //延时
    private float timer = 2.0f;

    // Use this for initialization
    void Start () 
	{
		Mytranform = this.GetComponent<RectTransform> ();
		//Btn_Begin = Mytranform.Find ("Button").GetComponent<Button> ();
		Btn_Begin.onClick.AddListener (Onclick_Begin);
		ifShow = true;
        ifDifShow = true;
        //Btn_reset = Mytranform.Find ("Btn_reset").GetComponent<Button> ();
        



		//Btn_1.onClick.AddListener (Onclick_Btn_1);
		Btn_set.onClick.AddListener (Onclick_ShowSetPanel);
        Btn_difficulty.onClick.AddListener(Onclick_ShowDifficultyPanel);

        Btn_team.onClick.AddListener(Onclick_Btn_team);
        Btn_reset.onClick.AddListener(Onclick_Btn_reset);
        Btn_rule.onClick.AddListener(Onclick_Btn_rule);

        Btn_close.onClick.AddListener(Onclick_Btn_close);
        Btn_close2.onClick.AddListener(Onclick_Btn_close2);
       
        Btn_easy.onClick.AddListener(Onclick_Btn_easy);
        Btn_normal.onClick.AddListener(Onclick_Btn_normal);
        Btn_difficult.onClick.AddListener(Onclick_Btn_difficult);

        //初始隐藏文字
        test.gameObject.SetActive(false);
    }
     void Update()
    {
        timer -= Time.deltaTime;
        if(timer<=0){
            test.gameObject.SetActive(false);
            timer = 2.0f;
        }
    }

    public void Onclick_Begin()
	{
		Gameobject.SetActive (true);
		MyPanel.SetActive (false);
	}

	public void Onclick_Btn_team()
	{
		teamPanel.SetActive (true);
	}

    public void Onclick_Btn_close()
    {
        teamPanel.SetActive(false);
    }

   

    public void Onclick_Btn_reset()
    {
        Debug.Log("reset");
        test.text = "数据重置成功";
        test.gameObject.SetActive(true);
        PlayerPrefs.DeleteAll();

        //重新调用数据加载
        GameObject reset = GameObject.Find("Main Camera");
        DataStorage other = (DataStorage)reset.GetComponent(typeof(DataStorage));
        other.returnInitData();

    }

    public void Onclick_Btn_easy()
    {
        Debug.Log("easy");
        test.text = "你选择了简单难度";
        test.gameObject.SetActive(true);
        PlayerPrefs.SetInt("playChangeDifficuty", 0);
    }
    public void Onclick_Btn_normal()
    {
        Debug.Log("normal");
        test.text = "你选择了正常难度";
        test.gameObject.SetActive(true);
        PlayerPrefs.SetInt("playChangeDifficuty", 1);
    }

    public void Onclick_Btn_difficult()
    {
        Debug.Log("difficult");
        test.text = "你选择了困难难度";
        test.gameObject.SetActive(true);
        PlayerPrefs.SetInt("playChangeDifficuty", 2);
    }
    public void Onclick_Btn_rule()
    {
        rulePanel.SetActive(true);
    }

    public void Onclick_Btn_close2()
    {
        rulePanel.SetActive(false);
    }

	public void Onclick_ShowSetPanel()
	{
		if (ifShow) 
		{
			setPanel.transform.DOLocalMove (new Vector3 (-187, -212, 0), 0.5f, false);
			ifShow = false;

           // difficultyPanel.transform.DOLocalMove(new Vector3(),0.5f,false);
		} 
		else 
		{
			setPanel.transform.DOLocalMove (new Vector3 (-187, -524, 0), 0.5f, false);
			ifShow = true;
		}
	}

    public void Onclick_ShowDifficultyPanel()
    {
        if (ifDifShow)
        {
            difficlutyPanel.transform.DOLocalMove(new Vector3(182, -197, 0), 0.5f, false);
            ifDifShow = false;

            // difficultyPanel.transform.DOLocalMove(new Vector3(),0.5f,false);
        }
        else
        {
            difficlutyPanel.transform.DOLocalMove(new Vector3(182, -524, 0), 0.5f, false);
            ifDifShow = true;
        }
    }
}
