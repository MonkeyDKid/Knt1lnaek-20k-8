using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using ImageVideoContactPicker;
using System.Runtime.Serialization.Formatters.Binary;
using SimpleJSON;
using System;

public class IVCPickerExample : MonoBehaviour {

	Texture2D texture;
	public Image avatar,avatar2;
	public GameObject popup,anotherpopup;
	public Text userName;
	public Text Wait, Debugging,errorhappen,imagebase64;
    public Button PP;
	void OnEnable()
	{
		PickerEventListener.onImageLoad += OnImageLoad;
		PickerEventListener.onError += OnError;
		PickerEventListener.onCancel += OnCancel;
	}
	
	void OnDisable()
	{
		PickerEventListener.onImageLoad -= OnImageLoad;
		PickerEventListener.onError -= OnError;
		PickerEventListener.onCancel -= OnCancel;
	}
		

	void OnImageLoad(string imgPath, Texture2D tex)
	{
		
		texture = tex;
	//	var rect = new Rect (0, 0, tex.width, tex.height);
		if (tex.height != 8) {
			string s = System.Convert.ToBase64String (texture.EncodeToJPG(50));
		
			PlayerPrefs.SetString ("Base64PictureProfile", s);

			//	PopUpManager.Add<WaitingPopUp> ();
		//	imagebase64.text=s;
			StartCoroutine(sendAvatar(s));
		}
		else {
			anotherpopup.SetActive (true);
			popup.SetActive (false);
		}
	
	}

	void Start () {
		Debug.Log (PlayerPrefs.GetString ("Base64PictureProfile"));
        if(PlayerPrefs.GetString(Link.LOGIN_BY) != "EMAIL")
        {

            PP.interactable = false;
        }
//		
//		if (JackpotFishing.Player.profileTexture != null) {
//			var rect = new Rect (0, 0, JackpotFishing.Player.profileTexture.width, JackpotFishing.Player.profileTexture.height);
//			aatar.overrideSprite = Sprite.Create (JackpotFishing.Player.profileTexture, rect, Vector2.zero, 128.0f);
//		}
//		else if (PlayerPrefs.GetString("Base64PictureProfile") != "") {
//
//
//
//
//			byte[] b64_bytes = System.Convert.FromBase64String(PlayerPrefs.GetString("Base64PictureProfile"));
//			Texture2D tex = new Texture2D(1,1);
//			tex.LoadImage(b64_bytes);
//
//			var rect = new Rect (0, 0, tex.width, tex.height);
//
//			if (tex.height != 8) {
//				aatar.overrideSprite = Sprite.Create (tex, rect, Vector2.zero, 128.0f);
//			}
//
//
//
//		}
//
//		
		if (PlayerPrefs.GetString ("Base64PictureProfile") != "") {
			byte[] b64_bytes = System.Convert.FromBase64String (PlayerPrefs.GetString ("Base64PictureProfile"));
			Texture2D tex = new Texture2D (1, 1);
			tex.LoadImage (b64_bytes);
			
			var rect = new Rect (0, 0, tex.width, tex.height);
			
			if (tex.height != 8) {
				avatar.overrideSprite = Sprite.Create (tex, rect, Vector2.zero, 128.0f);
			}
			else {
				anotherpopup.SetActive (true);
			}
		}
			else{
		StartCoroutine(showAvatar());
	}
		}


	private IEnumerator showAvatar()
	{
		string url = Link.urlAvatar + "USER" +PlayerPrefs.GetString( Link.ID) + ".jpg";
	

		Debug.Log ("AVATAR : " + url);


		WWWForm form = new WWWForm();
		WWW www = new WWW (url);

		yield return www;
	//	Debug.Log (www.text);
		if (www.error == null) {
			


			Debug.Log (url);
			var rect = new Rect (0, 0, www.texture.width, www.texture.height);





			if (www.texture.height != 8) {
				Debug.Log (www.texture.height);
				avatar.overrideSprite = Sprite.Create (www.texture, rect, Vector2.zero, 128.0f);
                avatar2.overrideSprite = Sprite.Create(www.texture, rect, Vector2.zero, 128.0f);
            } else {
				anotherpopup.SetActive (true);
			}



			string s = System.Convert.ToBase64String (www.texture.EncodeToJPG(50));
			PlayerPrefs.SetString ("Base64PictureProfile", s);

//			User user = new User ();
//			user.PlayerId 		= JackpotFishing.Player.PlayerId;
//			user.Email 			= JackpotFishing.Player.Email;
//			user.Name		 	= JackpotFishing.Player.Name;
//			user.Gem 			= JackpotFishing.Player.Gem;;
//			user.Loyalty 		= JackpotFishing.Player.Loyalty;
//			user.Avatar			= JackpotFishing.Player.Avatar;
//			user.profileTexture = www.texture;
//			user.Token 			= JackpotFishing.Player.Token;
//
//			JackpotFishing.Player = user;


			Debug.Log ("Succes");
		} else {
			Debug.Log ("Faill");
		}
        popup.SetActive(false);
    }

	private IEnumerator sendAvatar(string image)
	{
		//Dictionary<string, string> postHeader = new Dictionary<string, string>();
		//postHeader.Add("Accept", "application/json");
		//postHeader.Add("Authorization", "Bearer " + JackpotFishing.Player.Token);


		string url = Link.url + "sendAvatar";
		WWWForm form = new WWWForm();
		form.AddField ("ID", PlayerPrefs.GetString( Link.ID));
		form.AddField ("IMAGE", image);

		//WWW www = new WWW (url,form.data,postHeader);
		WWW www = new WWW(url,form);
		yield return www;
		//Wait.text = www.text;
		if (www.error == null) {

			Debug.Log ("SUCCESS");
			//Debugging.text="Success";
		//	PopUpManager.Pop ();
			yield return new WaitForSeconds(.5f);
            //StartCoroutine(showAvatar());
            //			var rect = new Rect (0, 0, texture.width, texture.height);
            //

            //
            //
            //			if (texture.height != 8) {
            //				avatar.overrideSprite = Sprite.Create (www.texture, rect, Vector2.zero, 128.0f);
            //			}
            ////				

            //string s = System.Convert.ToBase64String(texture.EncodeToJPG(50));
            //PlayerPrefs.SetString("Base64PictureProfile", s);
            //byte[] b64_bytes = System.Convert.FromBase64String(PlayerPrefs.GetString("Base64PictureProfile"));
            //Texture2D tex = new Texture2D(1, 1);
            //tex.LoadImage(b64_bytes);

            //var rect = new Rect(0, 0, tex.width, tex.height);
            StartCoroutine(showAvatar());
            //		


        } else {
			Debug.Log ("FAIL");
		//	Debugging.text="Failed";
			popup.SetActive (false);
		}
        errorhappen.text = www.text;
	}

	public void getGalery () {
		
		#if UNITY_ANDROID
		AndroidPicker.BrowseImage(false);
		popup.SetActive (true);
		#elif UNITY_IPHONE
		IOSPicker.BrowseImage(false); // pick
		#endif
	}

	void OnError(string errorMsg)
	{
		Debug.Log ("Error : "+errorMsg);
	//	errorhappen.text = "Error" + errorMsg;
	}

	void OnCancel()
	{
		Debug.Log ("Cancel by user");
		popup.SetActive (false);
	}


}
