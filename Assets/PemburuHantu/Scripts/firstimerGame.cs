using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstimerGame : MonoBehaviour {

	public GameObject[] story;
	public GameObject next, give;
	public int position;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetString ("PLAY_TUTORIAL") == "TRUE") {
			give.SetActive (false);
			switch (position) {

			case 0:
				story [0].SetActive (true);
				story [1].SetActive (false);
				break;
			case 1:
				//gambar1.SetActive (false);
				//gambar2.SetActive (true);
				story [0].SetActive (false);
				story [1].SetActive (true);
				next.SetActive (false);
				break;
			case 2:
				// kosong
				//gambar1.SetActive (false);
				//gambar2.SetActive (true);
				story [0].SetActive (false);
				story [1].SetActive (false);
				next.SetActive (false);
				break;
			case 3:
				//gambar1.SetActive (false);
				//gambar2.SetActive (true);
				story [0].SetActive (false);
				story [1].SetActive (false);
				story [2].SetActive (true);
				story [3].SetActive (false);
				next.SetActive (true);
				break;
			case 4:
				//gambar1.SetActive (false);
				//gambar2.SetActive (true);
				story [0].SetActive (false);
				story [1].SetActive (false);
				story [2].SetActive (false);
				story [3].SetActive (true);
				next.SetActive (false);
				break;
			}

		} else {
			next.SetActive (false);
		}
	}
	public void Next(){
		if (position < 5) {
			position += 1;



		}
	} 
	public void End(){
		Time.timeScale = 1;
		//PlayerPrefs.SetString ("PLAY_TUTORIAL", "FALSE");
		//this.gameObject.SetActive (false);
		position=2;
		//story [1].SetActive (false);

	}
	public void lastPosition(){
		position = 3;
}
}	