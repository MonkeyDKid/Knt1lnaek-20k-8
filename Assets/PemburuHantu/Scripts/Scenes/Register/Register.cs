using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SimpleJSON;


public class Register : MonoBehaviour {

	private bool isInfromasiServerPlay = false;

	[Header("Diperlukan Untuk Register")]
	public string device_id = "";
	public InputField userName;
	public InputField fullName;
	public InputField email;
	public InputField password;
	public Text header;

	[Header("Diperlukan Untuk Login")]
	public InputField emailLogin;
	public InputField passwordLogin;
	[SerializeField]
	private string version;
	[Header("Diperlukan Untuk Forgot")]
	public InputField emailForgot;

	[Header("Lainnya")]
	public GameObject informasiServer,quitter,quitter2;//loading;
	public FBholder holder;
    public GoogleSignInController2 holder2;
    bool FB = false;

	void Start () {
        Time.timeScale = 1;

       // PlayerPrefs.DeleteAll ();
    //   PlayerPrefs.SetString("Tutorialman", "TRUE");
      //  PlayerPrefs.SetString ("PLAY_TUTORIAL", "TRUE");
#if !UNITY_EDITOR
		AndroidJavaClass up = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
		AndroidJavaObject currentActivity = up.GetStatic<AndroidJavaObject> ("currentActivity");
		AndroidJavaObject contentResolver = currentActivity.Call<AndroidJavaObject> ("getContentResolver");  
		AndroidJavaClass secure = new AndroidJavaClass ("android.provider.Settings$Secure");
		device_id = secure.CallStatic<string> ("getString", contentResolver, "android_id");
#endif

#if UNITY_EDITOR
        device_id = "200";
#endif
        Debug.Log(PlayerPrefs.GetString(Link.STATUS_LOGIN));
	//PlayerPrefs.DeleteKey (Link.STATUS_LOGIN);
		if (PlayerPrefs.GetString (Link.STATUS_LOGIN) == "true") 
        {
			if (PlayerPrefs.GetString (Link.LOGIN_BY) == "EMAIL") {
				StartCoroutine (loginIEnumerator (PlayerPrefs.GetString (Link.EMAIL), PlayerPrefs.GetString (Link.PASSWORD), "EMAIL"));
			}
            else if(PlayerPrefs.GetString(Link.LOGIN_BY) == "FB") {
                StartCoroutine (loginIEnumerator (PlayerPrefs.GetString (Link.EMAIL), PlayerPrefs.GetString (Link.PASSWORD), "FB"));
			} 
            else if(PlayerPrefs.GetString(Link.LOGIN_BY) == "Google") {
               StartCoroutine(loginIEnumerator(PlayerPrefs.GetString(Link.EMAIL), PlayerPrefs.GetString(Link.PASSWORD), "Google"));
            }
        }
	}

    private IEnumerator showAvatar()
    {
        string url = Link.urlAvatar + "USER" + PlayerPrefs.GetString(Link.ID) + ".jpg";


        Debug.Log("AVATAR : " + url);


        WWWForm form = new WWWForm();
        WWW www = new WWW(url);

        yield return www;
        //	Debug.Log (www.text);
        if (www.error == null)
        {



            Debug.Log(url);
            var rect = new Rect(0, 0, www.texture.width, www.texture.height);





            if (www.texture.height != 8)
            {
                Debug.Log(www.texture.height);
                //	avatar.overrideSprite = Sprite.Create (www.texture, rect, Vector2.zero, 128.0f);
            }
            else {
                //	anotherpopup.SetActive (true);
            }



            string s = System.Convert.ToBase64String(www.texture.EncodeToJPG(50));
            PlayerPrefs.SetString("Base64PictureProfile", s);
            Debug.Log("Succes");
        }
        else {
            Debug.Log("Faill");
        }
    }

    public void OnRegister () {

		if (isInfromasiServerPlay == false) {
			/*
			if (userName.text == "") {
				StartCoroutine (AnimasiInformasiServer("Please Input Your User Name"));
			} 
			else if (userName.text.Length < 4) {
				StartCoroutine (AnimasiInformasiServer("User Name Min. 4 Characters"));
			} 
			else if (fullName.text == "") {
				StartCoroutine (AnimasiInformasiServer("Please Input Your Full Name"));
			} 
			else if (fullName.text.Length < 8) {
				StartCoroutine (AnimasiInformasiServer("Full Name Min. 8 Characters"));
			} 
			else if (email.text == "") {
				StartCoroutine (AnimasiInformasiServer("Please Input Your Email"));
			} 
			else if (password.text == "") {
				StartCoroutine (AnimasiInformasiServer("Please Input Your Password"));
			} else {
				StartCoroutine (registerIEnumerator());
			}
			*/
			if (userName.text == "") {
				StartCoroutine (AnimasiInformasiServer("Please Input Your User Name"));
			} 
			else if (password.text == "") {
				StartCoroutine (AnimasiInformasiServer("Please Input Your Password"));
			} else {

				if (!FB) {
					//fullName.text = userName.text;
				//	email.text = userName.text + "@email.com";
					//password.text = "Pemburu1234";


					if (fullName.text.Length <= 4) {
						fullName.text = fullName.text + " " + fullName.text;
					}
				}


				StartCoroutine (registerIEnumerator());
			}
		}
	}
    public void OnGuestMode() {
        StartCoroutine(OnGM());
    }

	public void OnLogin () {

		if (isInfromasiServerPlay == false) {
			if (emailLogin.text == "") {
				StartCoroutine (AnimasiInformasiServer("Please Input Your Email"));
			} 
			else if (passwordLogin.text == "") {
				StartCoroutine (AnimasiInformasiServer("Please Input Your Password"));
			} else {
				StartCoroutine (loginIEnumerator(emailLogin.text,passwordLogin.text,"EMAIL"));
			}
		}
	}

	public void OnForgot () {

		if (isInfromasiServerPlay == false) {
			if (emailForgot.text == "") {
				StartCoroutine (AnimasiInformasiServer("Please Input Your Email"));
			} 
			 else {
				Debug.Log (emailForgot.text);
				StartCoroutine (ForgotIEnumerator(emailForgot.text));
			}
		}
	}

	public void RegisterAnimasi (int fb) {
		if (isInfromasiServerPlay == false) {

            if (fb == 1) {
                FB = true;
                header.text = "Just Input Your User Name, And Continue Register";
                userName.text = "";
                fullName.text = holder.name;
                email.text = holder.id + "@fb.com";
                password.text = holder.id + "Fb";

                fullName.interactable = false;
                email.interactable = false;
                password.interactable = false;
            }
            else if (fb == 2) {
                header.text = "Just Input Your User Name, And Continue Register";
                userName.text = "";
                fullName.text = holder2.Username;
                email.text = holder2.Email;
                password.text = holder2.Id + "GooglePemburuhantu";

                fullName.interactable = false;
                email.interactable = false;
                password.interactable = false;
            }
            else {
				//header.text = "Register";
				userName.text = "";
				fullName.text = "";
				email.text = "";
				password.text = "";

				//fullName.interactable = true;
				//email.interactable = true;
				password.interactable = true;

			//	fullName.interactable = false;
			//	email.interactable = false;
				//password.interactable = false;
			}

		
			this.GetComponent<Animator> ().Play ("register");
		}

	}

	public void LoginAnimasi() {
		if (isInfromasiServerPlay == false) {
			emailLogin.text = "";
			passwordLogin.text = "";
			this.GetComponent<Animator> ().Play ("login");
		}
	}

	public void ForgotAnimasi() {
		if (isInfromasiServerPlay == false) {
			emailForgot.text = "";
			this.GetComponent<Animator> ().Play ("forgot");
		}
	}public void ForgotBackAnimasi() {
		if (isInfromasiServerPlay == false) {
			emailLogin.text = "";
			passwordLogin.text = "";
			this.GetComponent<Animator> ().Play ("forgotback");
		}
	}

	public IEnumerator  AnimasiInformasiServer (string info) {
		isInfromasiServerPlay = true;
		informasiServer.SetActive (true);
		informasiServer.GetComponentInChildren<Text> ().text = info;
		informasiServer.GetComponent<Animator> ().Play ("informasiServer");
		yield return new WaitForSeconds (2);
		informasiServer.SetActive (false);
		isInfromasiServerPlay = false;
		informasiServer.GetComponentInChildren<Text> ().text = "";
		StopCoroutine (AnimasiInformasiServer(""));


		if (info == "Register Complete") {
			this.GetComponent<Animator> ().Play ("login");
		} 

	}

	public void CekLoginFromFB () {
		StartCoroutine (cekLoginByFB());
	}

    public void CekLoginFromGoogle()
    {
        StartCoroutine(cekLoginByGoogle());
    }

    private IEnumerator cekLoginByFB()
	{
        
		Debug.Log ("CEK FB");
		string url = Link.url + "login";
		WWWForm form = new WWWForm ();
		form.AddField (Link.DEVICE_ID, device_id);
		form.AddField (Link.EMAIL, holder.id + "@fb.com");
		form.AddField (Link.PASSWORD, holder.id + "Fb");
		form.AddField("Version", version);
        PlayerPrefs.SetString(Link.PASSWORD, holder.id + "Fb");
        WWW www = new WWW(url,form);
		yield return www;
		Debug.Log (www.text);
		if (www.error == null) {
			var jsonString = JSON.Parse (www.text);
			//Debug.Log (www.text);
			PlayerPrefs.SetInt("informasiServer", int.Parse (jsonString ["code"]));
			Debug.Log ( int.Parse (jsonString ["code"]));
			switch (PlayerPrefs.GetInt("informasiServer")) {
			case 1:

                    if (int.Parse(jsonString["data"]["tfinish"]) == 0)
                    {
                        PlayerPrefs.SetString("PLAY_TUTORIAL", "TRUE");
                    }
                    else {
                        //PlayerPrefs.DeleteKey ("Tutorialman");
                        PlayerPrefs.SetString("PLAY_TUTORIAL", "FALSE");
                    }

                    // PlayerPrefs.SetString("PLAY_TUTORIAL", "FALSE");

                    PlayerPrefs.SetString (Link.ID, jsonString ["data"] ["id"]);
				PlayerPrefs.SetString (Link.LOGIN_BY, "FB");
				PlayerPrefs.SetString (Link.STATUS_LOGIN,"true");
				PlayerPrefs.SetString (Link.EMAIL, jsonString ["data"] ["email"]);
				PlayerPrefs.SetString (Link.USER_NAME, jsonString ["data"] ["user_name"]);
				PlayerPrefs.SetString (Link.FULL_NAME, jsonString ["data"] ["full_name"]);
				PlayerPrefs.SetString (Link.AP, jsonString["data"]["ap"]);
				PlayerPrefs.SetString (Link.AR, jsonString["data"]["ar"]);
				PlayerPrefs.SetString (Link.PASSWORD, holder.id + "Fb");
				PlayerPrefs.SetString (Link.DEVICE_ID, device_id);
                PlayerPrefs.SetString(Link.Stage,jsonString["data"]["Stage"]);
                    PlayerPrefs.SetString(Link.IBURU, jsonString["data"]["iklan_buru"]);
                    PlayerPrefs.SetString(Link.IGOLD, jsonString["data"]["iklan_gold"]);
                    PlayerPrefs.SetString(Link.IENERGY, jsonString["data"]["iklan_energy"]);
                    //
                    PlayerPrefs.SetString ("BonusEnergy",jsonString ["data"] ["BonusEnergy"]);
				var energy = int.Parse (jsonString ["data"] ["energy"]) + int.Parse (jsonString ["data"] ["BonusEnergy"]);
				PlayerPrefs.SetString ("EnergyCombo", energy.ToString());
				PlayerPrefs.SetString ("curexp", jsonString["data"]["xpp"]);
				PlayerPrefs.SetString ("tarexp", jsonString["data"]["targetexplevel"]);
				PlayerPrefs.SetString ("MaxE", jsonString["data"]["MaxEnergy"]);
				PlayerPrefs.SetString ("PlayerLevel", jsonString["data"]["PlayerLevel"]);
				PlayerPrefs.SetString (Link.ENERGY, jsonString["data"]["energy"]);
				PlayerPrefs.SetString (Link.GOLD, jsonString["data"]["coin"]);
				PlayerPrefs.SetString (Link.SOUL_STONE, jsonString["data"]["soulstone"]);

				PlayerPrefs.SetString (Link.COMMON, jsonString["data"]["common"]);
				PlayerPrefs.SetString (Link.RARE, jsonString["data"]["rare"]);
				PlayerPrefs.SetString (Link.LEGENDARY, jsonString["data"]["legendary"]);
                    //
                    //int hasil;
                    //var hasilnya = int.TryParse(jsonString["data"]["image"], out hasil);
                    //if (hasilnya)
                    //{
                    //    PlayerPrefs.DeleteKey("Base64PictureProfile");
                    //}
                    //else {
                    //    StartCoroutine(showAvatar());
                    //}
                   // StartCoroutine(DQItemList());
                    StartCoroutine(AchievementList());
                  //  yield return new WaitForSeconds(1f);
                   
				break;
			case 2 :
				StartCoroutine (AnimasiInformasiServer("Wrong Password"));
				break;
			case 3 :
				RegisterAnimasi (1);
				PlayerPrefs.SetString (Link.LOGIN_BY, "FB");
				//PlayerPrefs.SetString ("Tutorialman", "TRUE");
				break;
			case 4 :
				StartCoroutine (AnimasiInformasiServer("This User Already Login On Another Device"));
				break;
			case 5 :
				StartCoroutine (AnimasiInformasiServer("Invalid Email Format"));
				break;
			case 71 :
				StartCoroutine (AnimasiInformasiServer("Please Update to the newest version"));
				//				PlayerPrefs.DeleteKey(Link.LOGIN_BY);
				//				PlayerPrefs.DeleteKey(Link.STATUS_LOGIN);
				Application.OpenURL(jsonString ["Url"]);
				break;
			default :
				StartCoroutine (AnimasiInformasiServer("Something Wrong. Try Again Later"));
				break;
			}

		} else {
			StartCoroutine (AnimasiInformasiServer("Something Wrong. Try Again Later"));
		}
	}

    private IEnumerator cekLoginByGoogle()
    {
        Debug.Log("CEK google");
        string url = Link.url + "login";
        WWWForm form = new WWWForm();
        form.AddField(Link.DEVICE_ID, device_id);
        form.AddField(Link.EMAIL, holder2.Email);
        form.AddField(Link.PASSWORD, holder2.Id + "GooglePemburuhantu");
        form.AddField("Version", version);
        form.AddField("Google", "1");
        PlayerPrefs.SetString(Link.PASSWORD, holder2.Id + "GooglePemburuhantu");
        WWW www = new WWW(url, form);
        yield return www;
        Debug.Log(www.text);
        if (www.error == null)
        {
            var jsonString = JSON.Parse(www.text);
            //Debug.Log (www.text);
            PlayerPrefs.SetInt("informasiServer", int.Parse(jsonString["code"]));
            Debug.Log(int.Parse(jsonString["code"]));
            switch (PlayerPrefs.GetInt("informasiServer"))
            {
                case 1:

                    if (int.Parse(jsonString["data"]["tfinish"]) == 0)
                    {
                        PlayerPrefs.SetString("PLAY_TUTORIAL", "TRUE");
                    }
                    else
                    {
                        //PlayerPrefs.DeleteKey ("Tutorialman");
                        PlayerPrefs.SetString("PLAY_TUTORIAL", "FALSE");
                    }

                    // PlayerPrefs.SetString("PLAY_TUTORIAL", "FALSE");

                    PlayerPrefs.SetString(Link.ID, jsonString["data"]["id"]);
                    PlayerPrefs.SetString(Link.LOGIN_BY, "Google");
                    PlayerPrefs.SetString(Link.STATUS_LOGIN, "true");
                    PlayerPrefs.SetString(Link.EMAIL, jsonString["data"]["email"]);
                    PlayerPrefs.SetString(Link.USER_NAME, jsonString["data"]["user_name"]);
                    PlayerPrefs.SetString(Link.FULL_NAME, jsonString["data"]["full_name"]);
                    PlayerPrefs.SetString(Link.AP, jsonString["data"]["ap"]);
                    PlayerPrefs.SetString(Link.AR, jsonString["data"]["ar"]);
                    PlayerPrefs.SetString(Link.PASSWORD, holder2.Id + "GooglePemburuhantu");
                    PlayerPrefs.SetString(Link.DEVICE_ID, device_id);
                    PlayerPrefs.SetString(Link.Stage, jsonString["data"]["Stage"]);
                    PlayerPrefs.SetString(Link.IBURU, jsonString["data"]["iklan_buru"]);
                    PlayerPrefs.SetString(Link.IGOLD, jsonString["data"]["iklan_gold"]);
                    PlayerPrefs.SetString(Link.IENERGY, jsonString["data"]["iklan_energy"]);
                    //
                    PlayerPrefs.SetString("BonusEnergy", jsonString["data"]["BonusEnergy"]);
                    var energy = int.Parse(jsonString["data"]["energy"]) + int.Parse(jsonString["data"]["BonusEnergy"]);
                    PlayerPrefs.SetString("EnergyCombo", energy.ToString());
                    PlayerPrefs.SetString("curexp", jsonString["data"]["xpp"]);
                    PlayerPrefs.SetString("tarexp", jsonString["data"]["targetexplevel"]);
                    PlayerPrefs.SetString("MaxE", jsonString["data"]["MaxEnergy"]);
                    PlayerPrefs.SetString("PlayerLevel", jsonString["data"]["PlayerLevel"]);
                    PlayerPrefs.SetString(Link.ENERGY, jsonString["data"]["energy"]);
                    PlayerPrefs.SetString(Link.GOLD, jsonString["data"]["coin"]);
                    PlayerPrefs.SetString(Link.SOUL_STONE, jsonString["data"]["soulstone"]);

                    PlayerPrefs.SetString(Link.COMMON, jsonString["data"]["common"]);
                    PlayerPrefs.SetString(Link.RARE, jsonString["data"]["rare"]);
                    PlayerPrefs.SetString(Link.LEGENDARY, jsonString["data"]["legendary"]);
                    //
                    //int hasil;
                    //var hasilnya = int.TryParse(jsonString["data"]["image"], out hasil);
                    //if (hasilnya)
                    //{
                    //    PlayerPrefs.DeleteKey("Base64PictureProfile");
                    //}
                    //else {
                    //    StartCoroutine(showAvatar());
                    //}
                    // StartCoroutine(DQItemList());
                    StartCoroutine(AchievementList());
                    //  yield return new WaitForSeconds(1f);

                    break;
                case 2:
                    StartCoroutine(AnimasiInformasiServer("Wrong Password"));
                    break;
                case 3:
                    RegisterAnimasi(2);
                    PlayerPrefs.SetString(Link.LOGIN_BY, "Google");
                    //PlayerPrefs.SetString ("Tutorialman", "TRUE");
                    break;
                case 4:
                    StartCoroutine(AnimasiInformasiServer("This User Already Login On Another Device"));
                    break;
                case 5:
                    StartCoroutine(AnimasiInformasiServer("Invalid Email Format"));
                    break;
                case 71:
                    StartCoroutine(AnimasiInformasiServer("Please Update to the newest version"));
                    //				PlayerPrefs.DeleteKey(Link.LOGIN_BY);
                    //				PlayerPrefs.DeleteKey(Link.STATUS_LOGIN);
                   // Application.OpenURL(jsonString["Url"]);
                    break;
                default:
                    StartCoroutine(AnimasiInformasiServer("Something Wrong. Try Again Later"));
                    break;
            }

        }
        else
        {
            StartCoroutine(AnimasiInformasiServer("Something Wrong. Try Again Later"));
        }
    }


    private IEnumerator OnGM()
    {

        string url = Link.url + "registerGM";
        WWWForm form = new WWWForm();
        form.AddField(Link.DEVICE_ID, device_id);
        form.AddField("fbstats", holder.stats);
        WWW www = new WWW(url, form);
        yield return www;
        Debug.Log(www.text);
        if (www.error == null)
        {
            var jsonString = JSON.Parse(www.text);
            Debug.Log(www.text);
            PlayerPrefs.SetInt("informasiServer", int.Parse(jsonString["code"]));
            PlayerPrefs.SetString(Link.EMAIL, jsonString["email"]);
            PlayerPrefs.SetString(Link.PASSWORD, jsonString["pass"]);
            PlayerPrefs.SetString("GMode", jsonString["gm"]);
            switch (PlayerPrefs.GetInt("informasiServer"))
            {
                case 1:
                    //	StartCoroutine (loginIEnumerator(email.text,password.text,"EMAIL", "TRUE"));
                    if (PlayerPrefs.GetString(Link.LOGIN_BY) == "FB")
                    {
                        //PlayerPrefs.SetString ("Tutorialman", "TRUE");
                        StartCoroutine(cekLoginByFB());

                    }
                    else {
                        StartCoroutine(loginIEnumerator(PlayerPrefs.GetString(Link.EMAIL), PlayerPrefs.GetString(Link.PASSWORD), "EMAIL"));
						PlayerPrefs.SetString ("GMode","1");
                    }



                    //    PlayerPrefs.SetString ("Tutorialman", "TRUE");
                    break;
                case 2:
                    StartCoroutine(AnimasiInformasiServer("This Email Already Registered"));
                    break;
                case 3:
                    StartCoroutine(AnimasiInformasiServer("This User Name Already Taken"));
                    break;
                case 5:
                    StartCoroutine(AnimasiInformasiServer("Invalid Email Format"));
                    break;
                case 6:
                    StartCoroutine(AnimasiInformasiServer("Invalid Password Format"));
                    break;
                case 7:
                    StartCoroutine(AnimasiInformasiServer("Check Your Email for Verification"));
                    break;
                default:
                    StartCoroutine(AnimasiInformasiServer("Something Wrong. Try Again Later"));
                    break;
            }

        }
        else {
            StartCoroutine(AnimasiInformasiServer("Something Wrong. Try Again Later"));
        }
    }
    public void loadasync()
    {
    	 SceneManager.LoadScene("Main", LoadSceneMode.Additive);
    }

    private IEnumerator registerIEnumerator()
	{
		
		string url = Link.url + "register";
		WWWForm form = new WWWForm ();
		form.AddField (Link.DEVICE_ID, device_id);
		form.AddField (Link.USER_NAME, userName.text);
		form.AddField (Link.FULL_NAME, fullName.text);
		form.AddField (Link.EMAIL, email.text);
		form.AddField (Link.PASSWORD, password.text);
        form.AddField("fbstats", 1);
		WWW www = new WWW(url,form);
		yield return www;
      
        if (www.error == null) {
			var jsonString = JSON.Parse (www.text);
       		PlayerPrefs.SetInt("informasiServer", int.Parse (jsonString ["code"]));

			switch (PlayerPrefs.GetInt("informasiServer")) {
			case 1:
			//	StartCoroutine (loginIEnumerator(email.text,password.text,"EMAIL", "TRUE"));
				if (PlayerPrefs.GetString (Link.LOGIN_BY) == "FB") {
                        //PlayerPrefs.SetString ("Tutorialman", "TRUE");
                       // yield return new WaitForSeconds(5);
                        StartCoroutine (cekLoginByFB());
                        print("Login After Register");

				}
                   else if (PlayerPrefs.GetString(Link.LOGIN_BY) == "Google")
                    {
                        //PlayerPrefs.SetString ("Tutorialman", "TRUE");
                        // yield return new WaitForSeconds(5);
                        StartCoroutine(cekLoginByGoogle());
                        print("Login After Register");

                    }
                    else {
					StartCoroutine (AnimasiInformasiServer ("Check Your Email for Verification"));
                        this.GetComponent<Animator>().Play("login");
                    }

                  

            //    PlayerPrefs.SetString ("Tutorialman", "TRUE");
				break;
			case 2 :
				StartCoroutine (AnimasiInformasiServer("This Email Already Registered"));
				break;
			case 3 :
				StartCoroutine (AnimasiInformasiServer("This User Name Already Taken"));
				break;
			case 5 :
				StartCoroutine (AnimasiInformasiServer("Invalid Email Format"));
				break;
			case 6 :
				StartCoroutine (AnimasiInformasiServer("Invalid Password Format"));
				break;
			case 7 :
				StartCoroutine (AnimasiInformasiServer("Check Your Email for Verification"));
				break;
			default :
				StartCoroutine (AnimasiInformasiServer("Something Wrong. Try Again Later"));
				break;
			}

		} else {
			StartCoroutine (AnimasiInformasiServer("Something Wrong. Try Again Later"));
		}
	}

	private IEnumerator loginIEnumerator(string email,string pass,string login_by)
	{
		string url = Link.url + "login";
		WWWForm form = new WWWForm ();
		form.AddField (Link.DEVICE_ID, device_id);
		form.AddField (Link.EMAIL, email);
		form.AddField (Link.PASSWORD, pass);
		form.AddField("Version", version);

		WWW www = new WWW(url,form);
		yield return www;
        Debug.Log(www.text);
        if (www.error == null) {
			var jsonString = JSON.Parse (www.text);
		
			PlayerPrefs.SetInt("informasiServer", int.Parse (jsonString ["code"]));
	
			switch (PlayerPrefs.GetInt("informasiServer")) {
			case 1:

				if (int.Parse(jsonString["data"]["tfinish"])==0) {
                        PlayerPrefs.SetString("PLAY_TUTORIAL", "TRUE");
                    } 
				else {
					//PlayerPrefs.DeleteKey ("Tutorialman");
					PlayerPrefs.SetString ("PLAY_TUTORIAL", "FALSE");
				}

				PlayerPrefs.SetString (Link.ID, jsonString ["data"] ["id"]);
				PlayerPrefs.SetString (Link.LOGIN_BY, login_by);
				PlayerPrefs.SetString (Link.STATUS_LOGIN, "true");
				PlayerPrefs.SetString (Link.EMAIL, jsonString ["data"] ["email"]);
				PlayerPrefs.SetString (Link.USER_NAME, jsonString ["data"] ["user_name"]);
				PlayerPrefs.SetString (Link.FULL_NAME, jsonString ["data"] ["full_name"]);
				PlayerPrefs.SetString (Link.AP, jsonString ["data"] ["ap"]);
				PlayerPrefs.SetString (Link.AR, jsonString ["data"] ["ar"]);
				PlayerPrefs.SetString (Link.PASSWORD, pass);
				PlayerPrefs.SetString (Link.DEVICE_ID, device_id);
                PlayerPrefs.SetString(Link.Stage, jsonString["data"]["Stage"]);
                    PlayerPrefs.SetString(Link.IBURU, jsonString["data"]["iklan_buru"]);
                    PlayerPrefs.SetString(Link.IGOLD, jsonString["data"]["iklan_gold"]);
                    PlayerPrefs.SetString(Link.IENERGY, jsonString["data"]["iklan_energy"]);
                    //
                    PlayerPrefs.SetString ("BonusEnergy", jsonString ["data"] ["BonusEnergy"]);
				//	
				var energy = int.Parse (jsonString ["data"] ["energy"]) + int.Parse (jsonString ["data"] ["BonusEnergy"]);
				PlayerPrefs.SetString ("EnergyCombo", energy.ToString());
				PlayerPrefs.SetString ("curexp", jsonString["data"]["xpp"]);
				PlayerPrefs.SetString ("tarexp", jsonString["data"]["targetexplevel"]);
				PlayerPrefs.SetString (Link.ENERGY, jsonString["data"]["energy"]);
				PlayerPrefs.SetString ("MaxE", jsonString["data"]["MaxEnergy"]);
				PlayerPrefs.SetString ("PlayerLevel", jsonString["data"]["PlayerLevel"]);
				PlayerPrefs.SetString (Link.GOLD, jsonString["data"]["coin"]);
				PlayerPrefs.SetString (Link.SOUL_STONE, jsonString["data"]["soulstone"]);

				PlayerPrefs.SetString (Link.COMMON, jsonString["data"]["common"]);
				PlayerPrefs.SetString (Link.RARE, jsonString["data"]["rare"]);
				PlayerPrefs.SetString (Link.LEGENDARY, jsonString["data"]["legendary"]);
                    if (login_by != "FB")
                    {
                        int hasil;
                        var hasilnya = int.TryParse(jsonString["data"]["image"], out hasil);
                        if (hasilnya)
                        {

                            PlayerPrefs.DeleteKey("Base64PictureProfile");

                        }
                        else {
                            StartCoroutine(showAvatar());
                        }
                    }
                    
                    StartCoroutine(AchievementList());
                  //  yield return new WaitForSeconds(.5f);
					break;
			case 2 :
				StartCoroutine (AnimasiInformasiServer("Wrong Password"));
                    PlayerPrefs.DeleteKey(Link.LOGIN_BY);
                    PlayerPrefs.DeleteKey(Link.STATUS_LOGIN);
                    break;
			case 3 :
				StartCoroutine (AnimasiInformasiServer("Email Not Registered Yet. Please Register"));
                    PlayerPrefs.DeleteKey(Link.LOGIN_BY);
                    PlayerPrefs.DeleteKey(Link.STATUS_LOGIN);
                    break;
			case 4 :
				StartCoroutine (AnimasiInformasiServer("This User Already Login On Another Device"));
                    PlayerPrefs.DeleteKey(Link.LOGIN_BY);
                    PlayerPrefs.DeleteKey(Link.STATUS_LOGIN);
                    break;
			case 5 :
				StartCoroutine (AnimasiInformasiServer("Invalid Email Format"));
                    PlayerPrefs.DeleteKey(Link.LOGIN_BY);
                    PlayerPrefs.DeleteKey(Link.STATUS_LOGIN);
                    break;
			case 6 :
				StartCoroutine (AnimasiInformasiServer("Check Your Email for Verification"));
                    PlayerPrefs.DeleteKey(Link.LOGIN_BY);
                    PlayerPrefs.DeleteKey(Link.STATUS_LOGIN);
                    break;
			case 71 :
				StartCoroutine (AnimasiInformasiServer("Please Update to the newest version"));
//				PlayerPrefs.DeleteKey(Link.LOGIN_BY);
//				PlayerPrefs.DeleteKey(Link.STATUS_LOGIN);
				Application.OpenURL(jsonString ["Url"]);
				break;
			default :
				StartCoroutine (AnimasiInformasiServer("Something Wrong. Try Again Later"));
                    PlayerPrefs.DeleteKey(Link.LOGIN_BY);
                    PlayerPrefs.DeleteKey(Link.STATUS_LOGIN);
                    break;
			}

		} else {
			StartCoroutine (AnimasiInformasiServer("Something Wrong. Try Again Later"));
		}
	}


	private IEnumerator ForgotIEnumerator(string email)
	{

		string url = Link.url + "reset_password";
		WWWForm form = new WWWForm ();
		form.AddField ("email", email);

		WWW www = new WWW(url,form);
		yield return www;
		if (www.error == null) {
			var jsonString = JSON.Parse (www.text);
			Debug.Log (jsonString);
			PlayerPrefs.SetInt("informasiServer", int.Parse (jsonString ["code"]));

			switch (PlayerPrefs.GetInt("informasiServer")) {
			case 1:
				StartCoroutine (AnimasiInformasiServer ("Email Registered with FB. Use Login With Facebook"));
				emailForgot.text = "";
				break;
			case 2 :
				StartCoroutine (AnimasiInformasiServer("Check your email to reset password"));
				emailForgot.text = "";
				break;
			case 3 :
				StartCoroutine (AnimasiInformasiServer("Check your email, your account not verified yet"));
				emailForgot.text = "";
				break;
			case 4 :
				StartCoroutine (AnimasiInformasiServer("Email not registered"));
				emailForgot.text = "";
				break;
			default :
				StartCoroutine (AnimasiInformasiServer("Something Wrong. Try Again Later"));
				emailForgot.text = "";
				break;
			}

		} else {
			StartCoroutine (AnimasiInformasiServer("Something Wrong. Try Again Later"));
			emailForgot.text = "";
		}
	}

	

	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			quitter.SetActive (true);
			quitter2.SetActive (true);
		}
	}
	public void quit () {
		Application.Quit ();
	}
    private IEnumerator DQItemList()
    {
        string url = Link.url + "DQuest";
        WWWForm form = new WWWForm();
        form.AddField("MY_ID", PlayerPrefs.GetString(Link.ID));
        //form.AddField ("SHOP_JENIS", "SPECIAL");
        WWW www = new WWW(url, form);
        yield return www;
        if (www.error == null)
        {
            Debug.Log(www.text);
            var jsonString = JSON.Parse(www.text);
            //PlayerPrefs.SetString (Link.FOR_CONVERTING, jsonString["ID_SHOP_SPECIAL"]);
            if (int.Parse(jsonString["code"]) == 1)
            {

               
              for (int x = 0; x < int.Parse(jsonString["count"]); x++)
                {
                    int lol = 0;
                    var number = int.TryParse(jsonString["data"][x]["Quest_Done"], out lol);

                    if (number)
                    {

                        if (lol == 1)
                        {
                          string String = jsonString["data"][x]["Type"];
                            if (String == "Summon")
                            {
                                PlayerPrefs.SetString("SummonMissionStats", "FALSE");

                            }
                            if (String == "SingleMode")
                            {
                                PlayerPrefs.SetString("SoloMissionStats", "FALSE");

                            }
                            if (String == "Catch")
                            {
                                PlayerPrefs.SetString("CatchMissionStats", "FALSE");

                            }
                        }
                        else
                        {
                            string String = jsonString["data"][x]["Type"];
                            if (String == "Summon")
                            {
                                PlayerPrefs.SetString("SummonMissionStats", "TRUE");
                                PlayerPrefs.SetString("SummonMissionQD", jsonString["data"][x]["ID"]);
                            }
                            if (String == "SingleMode")
                            {
                                PlayerPrefs.SetString("SoloMissionStats", "TRUE");
                                PlayerPrefs.SetString("SoloMissionQD", jsonString["data"][x]["ID"]);
                            }
                            if (String == "Catch")
                            {
                                PlayerPrefs.SetString("CatchMissionStats", "TRUE");
                                PlayerPrefs.SetString("CatchMissionQD", jsonString["data"][x]["ID"]);
                            }
                        }
                        //     Debug.Log(PlayerPrefs.GetString("SoloMissionQD"));
                    }
                    else
                    {

                       
                    }
                                

                 

                  
                  

                }
            }
            else {
              Debug.Log("NoMission");
            }
            yield return new WaitForSeconds(1);
            SceneManagerHelper.LoadScene(Link.Home);
        }
        else {
            Debug.Log(www.text);
            Debug.Log("NoMission");

        }
    }

    private IEnumerator AchievementList()
    {
        string url = Link.url + "Achievement";
        WWWForm form = new WWWForm();
        form.AddField("MY_ID", PlayerPrefs.GetString(Link.ID));
        WWW www = new WWW(url, form);
        yield return www;
        if (www.error == null)
        {
            Debug.Log(www.text);
            var jsonString = JSON.Parse(www.text);
            //PlayerPrefs.SetString (Link.FOR_CONVERTING, jsonString["ID_SHOP_SPECIAL"]);
            if (int.Parse(jsonString["code"]) == 1)
            {


                for (int x = 0; x < int.Parse(jsonString["count"]); x++)
                {
                    string String = jsonString["data"][x]["Type"];
                    if (String == "Tutorial")
                    {
                        PlayerPrefs.SetString("TutorialMission", "TRUE");
                        PlayerPrefs.SetString("TMQD", jsonString["data"][x]["ID"]);
                    }
                    if (String == "Catch")
                    {
                        PlayerPrefs.SetString(String, "TRUE");
                        PlayerPrefs.SetString("CQD", jsonString["data"][x]["ID"]);
                    }
                    if (String == "B_Arena")
                    {
                        PlayerPrefs.SetString(String, "TRUE");
                        PlayerPrefs.SetString("BAQD", jsonString["data"][x]["ID"]);
                    }
                    if (String == "AR_Arena")
                    {
                        PlayerPrefs.SetString(String, "TRUE");
                        PlayerPrefs.SetString("ARAQD", jsonString["data"][x]["ID"]);
                    }
                    if (String == "B_Crystal")
                    {
                        PlayerPrefs.SetString(String, "TRUE");
                        PlayerPrefs.SetString("BCQD", jsonString["data"][x]["ID"]);
                    }
                    if (String == "EXP_Share")
                    {
                        PlayerPrefs.SetString(String, "TRUE");
                        PlayerPrefs.SetString("EXPSQD", jsonString["data"][x]["ID"]);
                    }
                }
            }
            StartCoroutine(DQItemList());
        }
    }



                    }
