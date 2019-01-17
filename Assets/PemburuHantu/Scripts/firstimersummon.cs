using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class firstimersummon : MonoBehaviour {
	public GameObject[] story;
	public GameObject next;
	public int position;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetString ("PLAY_TUTORIAL") == "TRUE") {
			switch (position) {

			case 0:
				story [4].SetActive (true);
				story [0].SetActive (true);
				story [1].SetActive (false);
				story [2].SetActive (false);
				break;
			case 1:
			//gambar1.SetActive (false);
			//gambar2.SetActive (true);
				story [0].SetActive (false);
				story [1].SetActive (true);
				story [2].SetActive (false);
				break;

			case 2:

				story [0].SetActive (false);
				story [1].SetActive (false);
				story [2].SetActive (false);
				story [4].SetActive (true);
				next.SetActive (false);
			//PlayerPrefs.SetString ("SummonTutor", "UDAH");
				break;
			case 3:

				story [0].SetActive (false);
				story [1].SetActive (false);
				story [2].SetActive (true);
				story [4].SetActive (false);
				next.SetActive (false);
				PlayerPrefs.SetString ("SummonTutor", "UDAH");
				break;
			}
		} else {
			next.SetActive (false);
		}
}
	public void Next(){
		if (position < 3) {
			position += 1;

		

		}
	} 
}