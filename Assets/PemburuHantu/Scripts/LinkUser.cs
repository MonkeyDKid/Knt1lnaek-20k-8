using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
public class LinkUser : MonoBehaviour {
	public InputField EmailText, PasswordText;
	public GameObject Error,Succeed;
	public FBholder FacebookGo;
	public GoogleSignInController2 GoogleGo;
	public Text UsernameA,UsernameB,Email;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void LUser(int which){
		
			StartCoroutine (LinkEmail (which));

	}
	private IEnumerator LinkEmail(int which)
	{
		string url = Link.url + "LinkEmail";
		WWWForm form = new WWWForm();
		form.AddField ("ID", PlayerPrefs.GetString (Link.ID));
		form.AddField ("fbstats", which);
		if (which == 1) {
			form.AddField ("Email", EmailText.text);
			form.AddField ("Password", PasswordText.text);
		}
		else if (which==2) 
		{
			form.AddField ("Email", GoogleGo.Email);
			form.AddField ("Password",  GoogleGo.Id + "GooglePemburuhantu");
			form.AddField ("Username",  GoogleGo.Username);
			
		}
		else {
			form.AddField ("Email", FacebookGo.id + "@fb.com");
			form.AddField ("Password",  FacebookGo.id + "Fb");
			form.AddField ("Username",  FacebookGo.name);

		}
		WWW www = new WWW(url, form);
		yield return www;
		if (www.error == null)
		{
			var jsonString = JSON.Parse(www.text);
			Debug.Log(jsonString);
			PlayerPrefs.SetString(Link.FOR_CONVERTING, jsonString["code"]);
			if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == "1")
			{
				PlayerPrefs.SetString ("GMode","0");
				if (which == 1) {
					PlayerPrefs.SetString (Link.EMAIL, EmailText.text);
					PlayerPrefs.SetString (Link.PASSWORD, PasswordText.text);
					Email.text = EmailText.text;
				}
				else if (which == 2) {
					Email.text = EmailText.text;
					UsernameA.text = GoogleGo.Username;
					UsernameB.text = GoogleGo.Username;
					PlayerPrefs.SetString (Link.EMAIL, GoogleGo.Email);
					PlayerPrefs.SetString (Link.PASSWORD,  GoogleGo.Id + "GooglePemburuhantu");
					
					PlayerPrefs.SetString (Link.LOGIN_BY, "Google");
				} 
				else {
					Email.text = EmailText.text;
					UsernameA.text = FacebookGo.name;
					UsernameB.text = FacebookGo.name;
					PlayerPrefs.SetString (Link.EMAIL,FacebookGo.id + "@fb.com");
					PlayerPrefs.SetString(Link.PASSWORD, FacebookGo.id + "Fb");
					PlayerPrefs.SetString("Base64PictureProfile", PlayerPrefs.GetString("Base64PictureProfileFB"));

					PlayerPrefs.SetString (Link.LOGIN_BY, "FB");
				}
				Debug.Log (www.text);
				Succeed.SetActive (true);
			}
			else if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == "4")
			{
				Error.SetActive(true);
				Error.transform.Find("ErrorText").GetComponent<Text>().text="Email Already Used";
			}
			else if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == "5")
			{
				Error.SetActive(true);
				Error.transform.Find("ErrorText").GetComponent<Text>().text="Insert Your Email Correctly";
			}
		}
		else {
			Error.SetActive(true);
			Error.transform.Find("ErrorText").GetComponent<Text>().text="Submit Failed";
			Debug.Log (www.text);
		}

	}
}
