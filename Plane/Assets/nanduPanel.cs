using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine;

public class nanduPanel : MonoBehaviour 
{
	public RectTransform Mytranform;
	public BeginPanel MyScript;
	public Button Btn_Begin;
	 
	public GameObject BeginPanel;
	public GameObject MyPanel;



	// Use this for initialization
	void Start () 
	{
		Mytranform = this.GetComponent<RectTransform> ();
		Btn_Begin = Mytranform.Find ("Button").GetComponent<Button> ();
		Btn_Begin.onClick.AddListener (Onclick_Begin);
	}
	
	// Update is called once per frame
	public void Onclick_Begin()
	{
		BeginPanel.SetActive (true);
		MyPanel.SetActive (false);
	}
}
