using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System.Collections;

public class Searching : MonoBehaviour {
	public Text time;
	public bool stoped = false;
	public bool done = false;
	string android_id = "";

	public GameObject online,another,jousting;
	public GameObject Load1;

	public GameObject contentController;
	public GameObject Item;

	void Start () {

	

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

		if (PlayerPrefs.GetString (Link.SEARCH_BATTLE) == "ONLINE") {
			online.SetActive (true);
			StartCoroutine (GetOpponentOnlineBattle());
		}
		if (PlayerPrefs.GetString (Link.SEARCH_BATTLE) == "REAL_TIME") {
			another.SetActive (true);
			Load1.SetActive (false);

		} 
		if (PlayerPrefs.GetString (Link.SEARCH_BATTLE) == "JOUSTING") {
			jousting.SetActive (true);
			Load1.SetActive (false);

		}
	}


	private IEnumerator GetOpponentOnlineBattle()
	{
		string url = Link.url + "getOpponentOnlineBattle";
		WWWForm form = new WWWForm ();
		form.AddField (Link.ID, PlayerPrefs.GetString(Link.ID));
		Debug.Log(PlayerPrefs.GetString (Link.ID));
		WWW www = new WWW(url,form);
		yield return www;
		Debug.Log (www.text);
		if (www.error == null) {
			
			var jsonString = JSON.Parse (www.text);
			print (www.text.Length);

			PlayerPrefs.SetString (Link.FOR_CONVERTING, jsonString["code"]);
			if (PlayerPrefs.GetString(Link.FOR_CONVERTING)=="0") {

				GameObject[] entry;
				entry = new GameObject[int.Parse(jsonString["count"])];
				for (int x = 0; x < int.Parse(jsonString["count"]); x++) {
					entry [x] = Instantiate (Item);


					entry[x].GetComponent<SearchingItem>().NamaText.text = jsonString["data"][x]["PlayerData"]["full_name"];


					////
					entry[x].GetComponent<SearchingItem>().defense1_image.sprite = 
						Resources.Load<Sprite>("icon_char/" + jsonString["data"][x]["HantuDefense1"][0]["HantuFile"]);
					
					entry[x].GetComponent<SearchingItem>().file1 			= jsonString["data"][x]["HantuDefense1"][0]["HantuFile"];
					entry[x].GetComponent<SearchingItem>().defense1_attack 	= jsonString["data"][x]["HantuDefense1"][0]["HantuAttack"];
					entry[x].GetComponent<SearchingItem>().defense1_defense = jsonString["data"][x]["HantuDefense1"][0]["HantuDefense"];
					entry[x].GetComponent<SearchingItem>().defense1_hp 		= jsonString["data"][x]["HantuDefense1"][0]["HantuStamina"];

					entry[x].GetComponent<SearchingItem>().defense_id1 		= jsonString["data"][x]["HantuDefense1"][0]["HantuPlayerID"];
					entry[x].GetComponent<SearchingItem>().defense_grade1 	= jsonString["data"][x]["HantuDefense1"][0]["HantuGrade"];
					entry[x].GetComponent<SearchingItem>().defense_level1 	= jsonString["data"][x]["HantuDefense1"][0]["HantuLevel"];

					////
					entry[x].GetComponent<SearchingItem>().defense2_image.sprite = 
						Resources.Load<Sprite>("icon_char/" + jsonString["data"][x]["HantuDefense2"][0]["HantuFile"]);

					entry[x].GetComponent<SearchingItem>().file2 			= jsonString["data"][x]["HantuDefense2"][0]["HantuFile"];
					entry[x].GetComponent<SearchingItem>().defense2_attack 	= jsonString["data"][x]["HantuDefense2"][0]["HantuAttack"];
					entry[x].GetComponent<SearchingItem>().defense2_defense = jsonString["data"][x]["HantuDefense2"][0]["HantuDefense"];
					entry[x].GetComponent<SearchingItem>().defense2_hp 		= jsonString["data"][x]["HantuDefense2"][0]["HantuStamina"];


					entry[x].GetComponent<SearchingItem>().defense_id2 		= jsonString["data"][x]["HantuDefense2"][0]["HantuPlayerID"];
					entry[x].GetComponent<SearchingItem>().defense_grade2 	= jsonString["data"][x]["HantuDefense2"][0]["HantuGrade"];
					entry[x].GetComponent<SearchingItem>().defense_level2 	= jsonString["data"][x]["HantuDefense2"][0]["HantuLevel"];


					////
					entry[x].GetComponent<SearchingItem>().defense3_image.sprite = 
						Resources.Load<Sprite>("icon_char/" + jsonString["data"][x]["HantuDefense3"][0]["HantuFile"]);
					
					entry[x].GetComponent<SearchingItem>().file3 			= jsonString["data"][x]["HantuDefense3"][0]["HantuFile"];
					entry[x].GetComponent<SearchingItem>().defense3_attack 	= jsonString["data"][x]["HantuDefense3"][0]["HantuAttack"];
					entry[x].GetComponent<SearchingItem>().defense3_defense = jsonString["data"][x]["HantuDefense3"][0]["HantuDefense"];
					entry[x].GetComponent<SearchingItem>().defense3_hp 		= jsonString["data"][x]["HantuDefense3"][0]["HantuStamina"];


					entry[x].GetComponent<SearchingItem>().defense_id3 		= jsonString["data"][x]["HantuDefense3"][0]["HantuPlayerID"];
					entry[x].GetComponent<SearchingItem>().defense_grade3 	= jsonString["data"][x]["HantuDefense3"][0]["HantuGrade"];
					entry[x].GetComponent<SearchingItem>().defense_level3 	= jsonString["data"][x]["HantuDefense3"][0]["HantuLevel"];

					entry[x].GetComponent<SearchingItem>().AGP 				= jsonString["data"][x]["AGP"];

					//entry[x].GetComponent<SearchingItem>().icon.sprite = Resources.Load<Sprite>("icon_char/" + jsonString["data"][x]["HantuFile"]);
					/*
					entry[x].GetComponent<SearchingItem>().PlayerHantuId = jsonString["data"][x]["HantuPlayerID"];
					entry[x].GetComponent<SearchingItem>().hantuId = jsonString["data"][x]["HantuId"];
					entry[x].GetComponent<SearchingItem>().name 	  = jsonString["data"][x]["HantuNama"];
					entry[x].GetComponent<SearchingItem>().file 	  = jsonString["data"][x]["HantuFile"];
					entry[x].GetComponent<SearchingItem>().Level.text = jsonString["data"][x]["HantuLevel"];
					entry[x].GetComponent<SearchingItem>().type 	  = jsonString["data"][x]["HantuType"];

					entry[x].GetComponent<SearchingItem>().attack  	  = int.Parse(jsonString["data"][x]["HantuAttack"]);
					entry[x].GetComponent<SearchingItem>().defense 	  = int.Parse(jsonString["data"][x]["HantuDefense"]);
					entry[x].GetComponent<SearchingItem>().stamina 	  = int.Parse(jsonString["data"][x]["HantuStamina"]);
					*/
					entry[x].transform.SetParent (contentController.transform, false);
				}
				if (int.Parse (jsonString ["count"]) > 0) {
					Load1.SetActive (false);
				}
			}
		} 
		else {
			Debug.Log (www.text);
			Debug.Log ("GAGAL");
			//Load1.SetActive (false);
		}
	}


	public void OnCancel () {
		SceneManagerHelper.LoadScene ("Arena");
	}

	private IEnumerator findMatch()
	{
		PlayerPrefs.SetInt ("GoRestart",0);
		string url = Link.url + "create_match";
		WWWForm form = new WWWForm ();
		form.AddField ("id_device", android_id);
		WWW www = new WWW(url,form);
		yield return www;
		if (www.error == null) {
			var jsonString = JSON.Parse (www.text);
			PlayerPrefs.SetString ("RoomName", jsonString ["code"]);
			StartCoroutine (onCoroutine());

		} else {
			//errorYA.SetActive (true);
		}
	}

	IEnumerator onCoroutine(){
		while(true) 
		{ 

			StartCoroutine (findMatch2());
			if (done) {
				time.text = (int.Parse (time.text) - 1).ToString() ;
				if (int.Parse(time.text) == 0 || int.Parse(time.text) <= 0 || int.Parse(time.text) < 0) {
					PlayerPrefs.SetInt ("GoRestart",1);
					SceneManagerHelper.LoadScene ("Home");
				}
			}



			yield return new WaitForSeconds(1f);
		}
	}

	private IEnumerator findMatch2()
	{
		string url = Link.url + "cek_match";
		WWWForm form = new WWWForm ();
		form.AddField ("id_device", android_id);
		form.AddField ("room_name", PlayerPrefs.GetString ("RoomName"));
		WWW www = new WWW(url,form);
		yield return www;
		if (www.error == null) {
			done = true;
			var jsonString = JSON.Parse (www.text);

			PlayerPrefs.SetInt("value", int.Parse (jsonString ["code"][0]["value"]));

			if (PlayerPrefs.GetInt ("value") == 2) {
				Debug.Log ("SDH 2");

				PlayerPrefs.SetString("id_device_make", jsonString ["code"][0]["id_device_make"]);
				PlayerPrefs.SetString("TheStatus",jsonString ["code"][0]["status"]);

				if (PlayerPrefs.GetString ("id_device_make") == android_id) {
					PlayerPrefs.SetInt ("pos", 1);
			
					if (PlayerPrefs.GetString ("TheStatus") == "1") {


						if (stoped == false) {
							stoped = true;
							StartCoroutine (GotoUpdate());
						}

					} else {
						PlayerPrefs.SetString ("id_device", android_id);
						StartCoroutine (kurangEnergy ());
					//	Application.LoadLevel ("Pilih Character");
					}


				} 
				else {
					PlayerPrefs.SetInt ("pos", 0);

					if (PlayerPrefs.GetString ("TheStatus") == "1") {




					} else {
						PlayerPrefs.SetString ("id_device", android_id);
						SceneManagerHelper.LoadScene("Pilih Character");

					}

				}


			} else {
				Debug.Log ("belum 2");
			}



		} else {
			Debug.Log ("fail");
		}
	}

	private IEnumerator GotoUpdate()
	{
		string url = Link.url + "update_status";
		WWWForm form = new WWWForm ();
		form.AddField ("room_name", PlayerPrefs.GetString ("RoomName"));
		WWW www = new WWW(url,form);
		yield return www;
		if (www.error == null) {

		}
	}
	private IEnumerator kurangEnergy ()
	{
		string url = Link.url + "energy";
		WWWForm form = new WWWForm ();
		form.AddField (Link.ID, PlayerPrefs.GetString(Link.ID));
		WWW www = new WWW(url,form);
		yield return www;
		if (www.error == null) {
			var jsonString = JSON.Parse (www.text);
			Debug.Log (www.text);
			PlayerPrefs.SetString (Link.FOR_CONVERTING, jsonString["code"]);
			if (PlayerPrefs.GetString(Link.FOR_CONVERTING)=="0") {
				SceneManagerHelper.LoadScene (Link.PilihCharacter);
			}
		} else {
			Debug.Log ("GAGAL");
		}
	}

}
