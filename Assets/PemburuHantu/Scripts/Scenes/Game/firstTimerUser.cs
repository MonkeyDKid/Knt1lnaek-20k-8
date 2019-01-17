using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class firstTimerUser : MonoBehaviour {

	public int position;
	public Button next,previous;
	public GameObject gambarback,storyGO;
	public GameObject[] story;
	// Use this for initialization
	void Start () {
	
		position = 3;
if(PlayerPrefs.GetString ("SummonTutor")== "UDAH")
				{
					End();
				}
	}
	
	// Update is called once per frame
	void Update () {
//		if (position == 0) {
//			previous.gameObject.SetActive (false);
//
//		 if (position == 4) {
//			next.gameObject.SetActive (false);
//		} 

		//else {
//			previous.gameObject.SetActive (true);
//			next.gameObject.SetActive (true);
//		}
		switch (position) {
		case 0:
			
			break;
		case 1:
			
			break;
		case 2:

			break;
		case 3:
			story [0].SetActive (true);
			story [1].SetActive (false);
			next.gameObject.SetActive (false);
		//	storyGO.SetActive (false);
			break;
		case 4:
			story[0].SetActive(false);
			story[2].SetActive(true);
			story[3].SetActive(false);
			break;
		case 5:
			gambarback.SetActive (false);
			story[3].SetActive(false);
			story[0].SetActive(false);
			story[1].SetActive(true);

			break;
//	
		}


	}
	public void Next(){
		if (position <= 3) {
			position += 1;

		}
		if (PlayerPrefs.HasKey ("SummonTutor")) {
			if (PlayerPrefs.GetString ("SummonTutor") == "UDAH") {
				//storyGO.SetActive (false);
				position = 5;
				next.gameObject.SetActive (false);
			}
		} 
	}
		public void End()
		{
			position = 5;
		
		} 
	}

