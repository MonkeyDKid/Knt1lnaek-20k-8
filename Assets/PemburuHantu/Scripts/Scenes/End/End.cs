using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using SimpleJSON;
public class End : MonoBehaviour {



	public Sprite win;
	public Sprite lose;
	public Image status; 
	public Text informasi;
	public Text AR;
	public Text AP;


	void Start () {


		if (PlayerPrefs.GetInt ("win") == 1) {
			status.sprite = lose;
			StartCoroutine (LOGOUT("0"));
		} else {
			status.sprite = win;
			StartCoroutine (LOGOUT("1"));
		}

	}
	
	public void OnClickEnd () {
		if (informasi.text == "Loading ..........") {
			
		} else {
			Application.LoadLevel ("Home");
		}

	}

	private IEnumerator LOGOUT (string status_battle)
	{
		informasi.text = "Loading ..........";
		string url = Link.url + "reward";
		WWWForm form = new WWWForm ();
		form.AddField (Link.EMAIL, PlayerPrefs.GetString(Link.EMAIL));
		form.AddField (Link.PASSWORD, PlayerPrefs.GetString(Link.PASSWORD));
		form.AddField (Link.DEVICE_ID, PlayerPrefs.GetString(Link.DEVICE_ID));
		form.AddField (Link.STATUS_BATTLE, status_battle);
		WWW www = new WWW(url,form);
		yield return www;
		if (www.error == null) {
			informasi.text = "Your Reward For This Battle";
			var jsonString = JSON.Parse (www.text);

			PlayerPrefs.SetInt("informasiServer", int.Parse (jsonString ["code"]));

			switch (PlayerPrefs.GetInt ("informasiServer")) {
			case 1:

				if (status_battle == "1") {
					AR.text = "Arena Rating : " + jsonString ["data"] ["ar"] + "(100)";
					AP.text = "Arena Point : " + jsonString ["data"] ["ap"] + "(100)";
				} else {
					AR.text = "Arena Rating : " + jsonString ["data"] ["ar"] + "(50)";
					AP.text = "Arena Point : " + jsonString ["data"] ["ap"] + "(0)";
				}
					
				PlayerPrefs.SetString (Link.EMAIL, jsonString ["data"] ["email"]);
				PlayerPrefs.SetString (Link.USER_NAME, jsonString ["data"] ["user_name"]);
				PlayerPrefs.SetString (Link.FULL_NAME, jsonString ["data"] ["full_name"]);
				PlayerPrefs.SetString (Link.AP, jsonString ["data"] ["ap"]);
				PlayerPrefs.SetString (Link.AR, jsonString ["data"] ["ar"]);

				break;
			case 2:
				
				break;
			}
		} else {
			informasi.text = "Server Down ..........";
		}
	}

}
