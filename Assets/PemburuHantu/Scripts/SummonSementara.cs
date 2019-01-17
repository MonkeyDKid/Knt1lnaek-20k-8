using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;

public class SummonSementara : MonoBehaviour {

	public Text batu;


	void Start () {
		StartCoroutine (getDataBatu());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private IEnumerator getDataBatu()
	{

		string url = Link.url + "info";
		WWWForm form = new WWWForm ();
		form.AddField ("MY_ID", PlayerPrefs.GetString(Link.ID));
		WWW www = new WWW(url,form);
		yield return www;
		if (www.error == null) {
			var jsonString = JSON.Parse (www.text);
			PlayerPrefs.SetString ("BATU", jsonString ["data"]);
			batu.text = jsonString ["data"];
			Debug.Log (www.text);
		} 

	}


	private IEnumerator sendSummon(string file, string jenis)
	{

		Debug.Log ("TES");
		string url = Link.url + "send_summon";
		WWWForm form = new WWWForm ();
		form.AddField ("MY_ID", PlayerPrefs.GetString(Link.ID));
		form.AddField ("FILE", file);
		form.AddField ("JENIS", jenis);

		WWW www = new WWW(url,form);
		yield return www;
		if (www.error == null) {
			StartCoroutine (getDataBatu());
		} 

	}

	public void Summon (string file) {
		//StartCoroutine (sendSummon(file));
	}
}
