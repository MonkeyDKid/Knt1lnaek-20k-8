using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class eventParentitem : MonoBehaviour {
	public Image Image;
	public GameObject EventInformationGO;
	public Button MyButton;
	// Use this for initialization
	void Start () {
		MyButton.onClick.AddListener (GotClicked);
	}

	void GotClicked(){

		EventInformationGO.SetActive (true);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
