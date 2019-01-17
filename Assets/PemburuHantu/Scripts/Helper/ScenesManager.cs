using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour {
	bool escape;
	// Use this for initialization
	void Start () {
		//escape = false;

	   // PlayerPrefs.DeleteAll ();
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetString ("PLAY_TUTORIAL") == "FALSE") {
			if (Input.GetKey (KeyCode.Escape) && escape == false) {
				escape = true;
				if (Application.loadedLevelName == "Arena" && escape == true) {
					SceneManagerHelper.LoadScene ("Map");

					escape = false;
				} else if (Application.loadedLevelName == "Searching" && escape == true) {
					SceneManagerHelper.LoadScene ("Arena");
					escape = false;
				} else if (Application.loadedLevelName == "Game" && escape == true && PlayerPrefs.GetString (Link.JENIS) == "SINGLE") {
					SceneManagerHelper.LoadScene ("Map");
					escape = false;
				} else if (Application.loadedLevelName == "Game" && escape == true && PlayerPrefs.GetString (Link.JENIS) == "MULTIPLE") {
					SceneManagerHelper.LoadScene ("Arena");
					escape = false;
				} else {
			
					if (GameObject.Find ("LoadingScreen")!=null) {
						GameObject.Find ("LoadingScreen").GetComponent<SceneLoader> ().LoadingScreeen ();
					} else {
						SceneManagerHelper.LoadScene ("Home");
						escape = false;
					}
				}

		
			}
		}
}
	public void Onclick(string index){
		SceneManagerHelper.LoadScene (index);
	}
	public void LoadOffline(string index){
		PlayerPrefs.SetString (Link.SEARCH_BATTLE, "SINGLE");
		SceneManagerHelper.LoadScene (index);
		PlayerPrefs.SetInt ("change", 1);
	}
}
