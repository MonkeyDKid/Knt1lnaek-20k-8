using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using SimpleJSON;
public class SceneLoader : MonoBehaviour {

    private bool loadScene = false;
	public string device_id = "";
	[SerializeField]
    private string scene;
	[SerializeField]
	private string version;
    [SerializeField]
	private GameObject loadingText;
	public Image GambarLoad;
	AsyncOperation async;
	public string[] katahint;
	public Text katahintText;
    int timeOut = 10;
    // Updates once per frame



	private string progress = "";    // Name of scene to load.
	private bool isLoading = false;
	private bool doneLoading = false;
	private bool allowLoading = false;
//	private void OnGUI() {
//		GUILayout.BeginVertical("box");
//		if (!isLoading) {
//			if (GUILayout.Button ("Begin Load")) {
//				
//				isLoading = true;
//				StartCoroutine(LoadNewScene());
//			}
//		} else {
//			if (doneLoading) {
//				allowLoading = true;
//				StartCoroutine(LoadNewScene());
//				if (GUILayout.Button ("Actually Load")) {
//					allowLoading = true;
//
//				}
//			}
//			GUILayout.Label(progress);
//		}
//
//		GUILayout.EndVertical();
//	}
	void Start(){
		int choice = Random.Range (0, 6);
		katahintText.text = katahint [choice];
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

	}
	void Update() {

			if(Input.GetKeyDown(KeyCode.Space))
            {
                PlayerPrefs.DeleteAll();
            }
			
        // If the player has pressed the space bar and a new scene is not loading yet...
		if (loadScene == false && PlayerPrefs.GetInt ("Loadscreen") == 1) {

			// ...set the loadScene boolean to true to prevent loading a new scene more than once...
			loadScene = true;

			// ...change the instruction text to read "Loading..."
			//loadingText.text = "Loading...";
			GambarLoad.gameObject.SetActive (true);
			isLoading = true;
			StartCoroutine (LoadNewScene ());
			// ...and start a coroutine that will load the desired scene.
			//   StartCoroutine(LoadNewScene());

		} else {
			if (doneLoading) {
				allowLoading = true;
				StartCoroutine (LoadNewScene ());
				allowLoading = true;

			}
		}

        // If the new scene has started loading...
        if (loadScene == true) {
			//Debug.Log (async.progress);
            // ...then pulse the transparency of the loading text to let the player know that the computer is still working.
			loadingText.GetComponent<Image>().color = new Color(loadingText.GetComponent<Image>().color.r, loadingText.GetComponent<Image>().color.g, loadingText.GetComponent<Image>().color.b, Mathf.PingPong(Time.time, 1));
			PlayerPrefs.SetInt ("Loadscreen", 0);

        }

	}
    private IEnumerator loginIEnumerator(string email, string pass, string login_by)
    {
        string url = Link.url + "login";
        WWWForm form = new WWWForm();
        form.AddField(Link.DEVICE_ID, device_id);
        form.AddField(Link.EMAIL, email);
        form.AddField(Link.PASSWORD, pass);
		form.AddField("Version", version);
          if(login_by=="Google")
        {
        form.AddField("Google", "1");
        }

        WWW www = new WWW(url, form);
        yield return www;
         float timer = 0; 
         bool failed = false;
                    
         while (!www.isDone)
                     {
                         if (timer > timeOut) { failed = true; break; }
                         timer += Time.deltaTime;
                         yield return null;
                     }
                     if (failed || !string.IsNullOrEmpty(www.error))
                     {
                         www.Dispose();
                         yield break;
                     }
        if (www.error == null)
        {
            var jsonString = JSON.Parse(www.text);
            Debug.Log(jsonString);
            PlayerPrefs.SetInt("informasiServer", int.Parse(jsonString["code"]));

            switch (PlayerPrefs.GetInt("informasiServer"))
            {
                case 1:
				async = Application.LoadLevelAsync ("Home");
                SceneManagerHelper.LoadMusic("Home");
                    if (int.Parse(jsonString["data"]["tfinish"]) == 0)
                    {
                        PlayerPrefs.SetString("PLAY_TUTORIAL", "TRUE");
                    }
                    else {
                        //PlayerPrefs.DeleteKey ("Tutorialman");
                        PlayerPrefs.SetString("PLAY_TUTORIAL", "FALSE");
                    }

                    PlayerPrefs.SetString(Link.ID, jsonString["data"]["id"]);
                    PlayerPrefs.SetString(Link.LOGIN_BY, login_by);
                    PlayerPrefs.SetString(Link.STATUS_LOGIN, "true");
                    PlayerPrefs.SetString(Link.EMAIL, jsonString["data"]["email"]);
                    PlayerPrefs.SetString(Link.USER_NAME, jsonString["data"]["user_name"]);
                    PlayerPrefs.SetString(Link.FULL_NAME, jsonString["data"]["full_name"]);
                    PlayerPrefs.SetString(Link.AP, jsonString["data"]["ap"]);
                    PlayerPrefs.SetString(Link.AR, jsonString["data"]["ar"]);
                    PlayerPrefs.SetString(Link.PASSWORD, pass);
                    PlayerPrefs.SetString(Link.DEVICE_ID, device_id);
                    PlayerPrefs.SetString(Link.Stage, jsonString["data"]["Stage"]);
                    PlayerPrefs.SetString(Link.IBURU, jsonString["data"]["iklan_buru"]);
                    PlayerPrefs.SetString(Link.IGOLD, jsonString["data"]["iklan_gold"]);
                    PlayerPrefs.SetString(Link.IENERGY, jsonString["data"]["iklan_energy"]);
                    //
                    PlayerPrefs.SetString("BonusEnergy", jsonString["data"]["BonusEnergy"]);
                    //	
                    var energy = int.Parse(jsonString["data"]["energy"]) + int.Parse(jsonString["data"]["BonusEnergy"]);
                    PlayerPrefs.SetString("EnergyCombo", energy.ToString());
                    PlayerPrefs.SetString("curexp", jsonString["data"]["xpp"]);
                    PlayerPrefs.SetString("tarexp", jsonString["data"]["targetexplevel"]);
                    PlayerPrefs.SetString(Link.ENERGY, jsonString["data"]["energy"]);
                    PlayerPrefs.SetString("MaxE", jsonString["data"]["MaxEnergy"]);
                    PlayerPrefs.SetString("PlayerLevel", jsonString["data"]["PlayerLevel"]);
                    PlayerPrefs.SetString(Link.GOLD, jsonString["data"]["coin"]);
                    PlayerPrefs.SetString(Link.SOUL_STONE, jsonString["data"]["soulstone"]);

                    PlayerPrefs.SetString(Link.COMMON, jsonString["data"]["common"]);
                    PlayerPrefs.SetString(Link.RARE, jsonString["data"]["rare"]);
                    PlayerPrefs.SetString(Link.LEGENDARY, jsonString["data"]["legendary"]);
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
                    StartCoroutine(DQItemList());
                 //   StartCoroutine(AchievementList());
                  
                    break;
                case 2:
           //         StartCoroutine(AnimasiInformasiServer("Wrong Password"));
                    break;
                case 3:
            //        StartCoroutine(AnimasiInformasiServer("Email Not Registered Yet. Please Register"));
                    break;
                case 4:
             //       StartCoroutine(AnimasiInformasiServer("This User Already Login On Another Device"));
                    break;
                case 5:
              //      StartCoroutine(AnimasiInformasiServer("Invalid Email Format"));
                    break;
                case 6:
              //      StartCoroutine(AnimasiInformasiServer("Check Your Email for Verification"));
                    break;
			case 71 :
				async = Application.LoadLevelAsync (scene);
               
			//	StartCoroutine (AnimasiInformasiServer("Please Update to the newest version"));
				//				PlayerPrefs.DeleteKey(Link.LOGIN_BY);
				//				PlayerPrefs.DeleteKey(Link.STATUS_LOGIN);
				//Application.OpenURL(jsonString ["Url"]);
				break;
                default:
				async = Application.LoadLevelAsync (scene);
                
               //     StartCoroutine(AnimasiInformasiServer("Something Wrong. Try Again Later"));
                    break;
            }

        }
        else {
     //       StartCoroutine(AnimasiInformasiServer("Something Wrong. Try Again Later"));
        }
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
            yield return new WaitForSeconds(1f);
            Application.LoadLevel(Link.Home);
            SceneManagerHelper.LoadMusic("Home");
        }
        else {
            Debug.Log(www.text);
            Debug.Log("NoMission");

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


    public void LoadingScreeen(){
		PlayerPrefs.SetInt ("Loadscreen", 1);
	}

    // The coroutine runs on its own at the same time as Update() and takes an integer indicating which scene to load.
	IEnumerator LoadNewScene() {

		// This line waits for 3 seconds before executing the next line in the coroutine.
		// This line is only necessary for this demo. The scenes are so simple that they load too fast to read the "Loading..." text.
		yield return new WaitForSeconds (2);

		// Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
		if (Application.loadedLevelName == "Opening") {
			if (PlayerPrefs.GetString (Link.STATUS_LOGIN) == "true") {
				if (PlayerPrefs.GetString (Link.LOGIN_BY) == "EMAIL") {
					StartCoroutine (loginIEnumerator (PlayerPrefs.GetString (Link.EMAIL), PlayerPrefs.GetString (Link.PASSWORD), "EMAIL"));
				} else if (PlayerPrefs.GetString (Link.LOGIN_BY) == "FB") {
					StartCoroutine (loginIEnumerator (PlayerPrefs.GetString (Link.EMAIL), PlayerPrefs.GetString (Link.PASSWORD), "FB"));
				} else if (PlayerPrefs.GetString (Link.LOGIN_BY) == "Google") {
					StartCoroutine (loginIEnumerator (PlayerPrefs.GetString (Link.EMAIL), PlayerPrefs.GetString (Link.PASSWORD), "Google"));
				}
				yield return new WaitForSeconds (2);
			} else {
                SceneManagerHelper.LoadMusic(scene);
				async = Application.LoadLevelAsync (scene);
                
                 
			}
		} else {
            SceneManagerHelper.LoadMusic(scene);
			async = Application.LoadLevelAsync (scene);
            
		}
		//yield return async;

		// While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
		if (async != null) {
			async.allowSceneActivation = false;
			while (async.progress < 0.9f) {
				// Report progress etc.
				GambarLoad.gameObject.transform.Find ("Image").GetComponent<Image> ().fillAmount = async.progress;
				progress = "Progress: " + async.progress.ToString ();
				yield return null;
			}
			// Show the UI button to actually start loaded level
			doneLoading = true;
			while (!allowLoading) {
				// Wait for allow button to be pushed.
                
				progress = "Progress: " + async.progress.ToString ();
				GambarLoad.gameObject.transform.Find ("Image").GetComponent<Image> ().fillAmount = 1;
				yield return null;
			}
			// Allow the activation of the scene again.
			async.allowSceneActivation = true;
            
		}
	}
}
