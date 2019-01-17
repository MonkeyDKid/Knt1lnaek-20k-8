using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class profile : MonoBehaviour {
	public GameObject LinkBUtton,LinkFBButton;
	// Use this for initialization
	void Start () {
		Debug.Log(PlayerPrefs.GetString ("GMode"));
		if (PlayerPrefs.GetString ("GMode") == "1") {
			LinkBUtton.SetActive (true);
			LinkFBButton.SetActive (true);
		} else {
			LinkBUtton.SetActive (false);
			LinkFBButton.SetActive (false);
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
