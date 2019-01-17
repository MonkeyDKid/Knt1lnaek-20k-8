
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using SimpleJSON;
using Facebook.Unity;

public class FBholder : MonoBehaviour {
		
	private Dictionary<string, string> profile = null;
	public string name = "";
	string image = "";
	public string id = "0";
    public string stats = "0";
    private bool logoutYa = false;
	public GameObject rg;

	public void KlikInit () {
		logoutYa = false;
		if (FB.IsInitialized) {
			if (FB.IsLoggedIn) {
				//FBLogin ();
				FB.API ("/me?fields=id,first_name,last_name", HttpMethod.GET, DealName);
				Debug.Log ("something");
			} 
			else 
			{
				FBLogin ();
			}
		} 
		else
		{
			FB.Init (SetInit, OnHideUnity);
		}



	}
			

	void SetInit () {

		if (logoutYa) {
			if (FB.IsLoggedIn) {
				FB.LogOut ();
			}
		} else {
			if (FB.IsLoggedIn) {
				//FBLogin ();
				FB.API ("/me?fields=id,first_name,last_name", HttpMethod.GET, DealName);
				Debug.Log ("log in");
			} else {
				FBLogin ();
			}
		}
	}

		

	void OnHideUnity (bool isGameShown) {
	}

	void FBLogin () {
		//FB.Login ("email", AuthCallBack);
		List<string> permissions = new List<string> ();
		permissions.Add ("public_profile");
		FB.LogInWithReadPermissions(permissions, AuthCallBack);
	}

	void AuthCallBack (IResult result) {

		if (result.Error != null) {
			
		} else {
			if (FB.IsLoggedIn) {
				DealFBMenu (true);
			} else {
				
			}
		}
	}

	void DealFBMenu (bool isLoggin) {
		if (isLoggin) {
			FB.API ("/me?fields=id,first_name,last_name", HttpMethod.GET, DealName);
		}
	}


		
	void DealName (IResult result) {
		if (result.Error != null) {
			FB.API ("/me?fields=id,first_name,last_name", HttpMethod.GET, DealName);
			Debug.Log (result.Error);
			return;
		} else {
			FB.API (Util.GetPictureURL("me", 128, 128), HttpMethod.GET, DealPhoto);
			name = result.ResultDictionary["first_name"].ToString() + " " + result.ResultDictionary["last_name"].ToString();
			id	= result.ResultDictionary["id"].ToString();
            stats = "1";
			if (Application.loadedLevelName == "Register") {
				rg.GetComponent<Register> ().CekLoginFromFB ();
			} else {
				rg.GetComponent<LinkUser> ().LUser (0);
			}
		}
	}

		
		
	void DealPhoto (IGraphResult result) {
		if (result.Error != null) {
			FB.API (Util.GetPictureURL ("me", 128, 128), HttpMethod.GET, DealPhoto);
			return;
		} else {
			image = System.Convert.ToBase64String (result.Texture.EncodeToPNG());
           
			if (Application.loadedLevelName == "Register") {
				PlayerPrefs.SetString("Base64PictureProfile", image);
			} else {
				PlayerPrefs.SetString("Base64PictureProfileFB", image);
			}
            GetDeviceID ();
		}	
	}

	public void Logout () {

		if (FB.IsInitialized) {
			FB.LogOut ();
		} else {
			logoutYa = true;
			FB.Init (SetInit, OnHideUnity);
		}
	}

	string android_id;


	void GetDeviceID () {
		#if !UNITY_EDITOR
		AndroidJavaClass up = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
		AndroidJavaObject currentActivity = up.GetStatic<AndroidJavaObject> ("currentActivity");
		AndroidJavaObject contentResolver = currentActivity.Call<AndroidJavaObject> ("getContentResolver");  
		AndroidJavaClass secure = new AndroidJavaClass ("android.provider.Settings$Secure");
		android_id = secure.CallStatic<string> ("getString", contentResolver, "android_id");
		#endif

		#if UNITY_EDITOR
		android_id = "200";
		#endif
	}




	}

