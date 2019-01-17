using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System;
public class ButtonInvite : MonoBehaviour {


	public string PeopleId = "";
	public string PeopleFullName = "";
	public string PeopleLeader = "";
	public string YourLeader = "";
	public string status = "";
	public bool clickcable = true;


	public Sprite battle;
	public Sprite sending;

	public bool sp;

	void Update () {
//		if (sp) {
//			transform.GetComponent<Image> ().sprite = battle;
//		} else {
//			transform.GetComponent<Image> ().sprite = sending;
//		}
	}


	public void OnClick () {
		sp = false;
		PlayerPrefs.GetString (Link.INVITE_CLICK,"TRUE");

		//var image = GetComponent<Image> ().color;
		//image.a = 0f;
		//GetComponent<Image>().color = image;

		if (clickcable) {
			clickcable = false;

			PlayerPrefs.SetString ("MultiBattle", status);

			if (PlayerPrefs.GetString("MultiBattle") == "Invite") {
				StartCoroutine (Invite("0"));
			} else {
				StartCoroutine (Invite("1"));
			}


		}
	}

	private IEnumerator Invite(string from)
	{
		
		//GetComponentInChildren<Text> ().text = "Sending ...";

		string url = Link.url + "invite";
		WWWForm form = new WWWForm ();
		form.AddField ("MY_ID", PlayerPrefs.GetString(Link.ID));
		form.AddField ("PEOPLE_ID", PeopleId);
		form.AddField ("FROM", from);
		WWW www = new WWW(url,form);
		yield return www;
		if (www.error == null) {
			
			//transform.gameObject.SetActive (false);
		} 
		else {
			//var image = GetComponent<Image> ().color;
			//image.a = 255f;
			//GetComponent<Image>().color = image;
		}


	}


}
