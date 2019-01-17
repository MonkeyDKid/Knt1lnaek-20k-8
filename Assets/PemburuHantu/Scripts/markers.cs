using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SimpleJSON;
public class markers : MonoBehaviour {
	public GoogleMapLocation[] monsterLL;
	public string abc;
	// Use this for initialization
	void Awake () {
	}
	void Start () {
		StartCoroutine ( GetMarkers());
		//GetComponent<GoogleMap> ().markers [0].locations = monsterLL;
	}

		
	IEnumerator test(){
		int count = 5;
		Array.Resize (ref monsterLL, count);
		if (monsterLL.Length == count) {
			yield return new WaitForSeconds (1);
			for (int x = 0; x < count; x++) {
				monsterLL [x].latitude = -6.24455356598f;
				monsterLL [x].longitude = 106.892440795898f;
			}
		}
		GetComponent<GoogleMap> ().markers [0].locations = monsterLL;
	}
	// Update is called once per frame
	void Update () {
		
	}
	public void GO(){
		


	}
	IEnumerator GetMarkers(){
		string url = "http://139.59.100.192/PH/" + "all";
		WWWForm form = new WWWForm ();
		form.AddField ("ID", PlayerPrefs.GetString ("ID"));
		WWW www = new WWW (url, form);
		yield return www;
		Debug.Log (www.text);
		if (www.error == null) {
			var jsonString = JSON.Parse (www.text);
			int count = int.Parse (jsonString ["count"]);
			PlayerPrefs.SetString ("FOR_CONVERTING", jsonString ["code"]);
			if (PlayerPrefs.GetString ("FOR_CONVERTING") == "0") {
				//Array.Resize (ref GetComponent<GoogleMap> ().markers [0].locations ,count);
				if (GetComponent<GoogleMap> ().markers [0].locations.Length == count) {
					//yield return new WaitForSeconds (1f);
				for (int x = 0; x < int.Parse (jsonString ["count"]); x++) {
						//GetComponent<GoogleMap> ().markers [0].locations [x].address = jsonString["data"][x]["namatempat"];
					//	GetComponent<GoogleMap> ().markers [0].locations [x].latitude = double.Parse(jsonString["data"][x]["latitude"]);
					//	GetComponent<GoogleMap> ().markers [0].locations [x].longitude = double.Parse(jsonString["data"][x]["longitude"]);
						abc+="|"+jsonString["data"][x]["latitude"]+","+jsonString["data"][x]["longitude"];
					}

					yield return new WaitForSeconds (.5f);
					//GetComponent<GoogleMap> ().markers [0].locations = monsterLL;
					//GetComponent<GoogleMap> ().Refresh ();
					GetComponent<GoogleMap> ().qs += abc;
					GetComponent<GoogleMap> ().Refresh ();
			}

			}


	}
	
}
}
