﻿using System.Collections;
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

	public GameObject resetPanel;
	public Button Btn_reset;

	public GameObject nanduPanel;
	public Button Btn_1;

	public Button Btn_set;
	public GameObject setPanel;

    public GameObject difficlutyPanel;
    public Button Btn_difficulty;



    public GameObject MyPanel;
	public bool ifShow;
    public bool ifDifShow;
    // Use this for initialization
    void Start () 
	{
		Mytranform = this.GetComponent<RectTransform> ();
		Btn_Begin = Mytranform.Find ("Button").GetComponent<Button> ();
		Btn_Begin.onClick.AddListener (Onclick_Begin);
		ifShow = true;
        ifDifShow = true;
        //Btn_reset = Mytranform.Find ("Btn_reset").GetComponent<Button> ();
        Btn_reset.onClick.AddListener (Onclick_Btn_reset);

		Btn_1.onClick.AddListener (Onclick_Btn_1);
		Btn_set.onClick.AddListener (Onclick_ShowSetPanel);
        Btn_difficulty.onClick.AddListener(Onclick_ShowDifficultyPanel);
    }
	
	public void Onclick_Begin()
	{
		Gameobject.SetActive (true);
		MyPanel.SetActive (false);
	}

	public void Onclick_Btn_reset()
	{
		resetPanel.SetActive (true);
	}

	public void Onclick_Btn_1()
	{
		nanduPanel.SetActive (true);
		MyPanel.SetActive (false);
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
