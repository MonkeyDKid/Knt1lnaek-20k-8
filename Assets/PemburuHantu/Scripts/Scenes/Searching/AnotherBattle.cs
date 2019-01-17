using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System;
using OneSignalPush.MiniJSON;

public class AnotherBattle : MonoBehaviour {

	public Text Status;
	public Text confirming;
	public GameObject[] people;

	public GameObject warningInvitating,loading, ValidationError;
    public string id = "";
	int energyused=5;
	string namaajak;
	public string idajak;
	void Start () {
		

		#if !UNITY_EDITOR
			OneSignal.SetLogLevel(OneSignal.LOG_LEVEL.VERBOSE, OneSignal.LOG_LEVEL.NONE);
		OneSignal.StartInit("d1637280-1caa-4fbe-a688-a10c9bb36890")
				.HandleNotificationReceived(HandleNotificationReceived)
				.HandleNotificationOpened(HandleNotificationOpened)
				.InFocusDisplaying(OneSignal.OSInFocusDisplayOption.None)
				.EndInit();

			OneSignal.IdsAvailable((userId, pushToken) => {
			id = userId;
			StartCoroutine (onCoroutine());
			});
		#endif

		#if UNITY_EDITOR
			id = "123456789";
			StartCoroutine (onCoroutine());
		#endif




	}


	private void HandleNotificationReceived(OSNotification notification) {
		
		OSNotificationPayload payload = notification.payload; 
		string message = payload.body;
		Dictionary<string, object> additionalData = payload.additionalData;



		if (additionalData == null) {
			Debug.Log ("[HandleNotificationReceived] Additional Data == null");
		}
		else {
			var jsonString = JSON.Parse (Json.Serialize(additionalData) as string);
		
			PlayerPrefs.SetString ("MultiBattle", jsonString["from"]);

		
			if (int.Parse(jsonString["from"]) == 99) {
				PlayerPrefs.SetInt ("pos", 2);
				PlayerPrefs.SetString ("RoomName", jsonString ["room"]);
				PlayerPrefs.SetString (Link.USER_2, PlayerPrefs.GetString(Link.FULL_NAME));
				PlayerPrefs.SetString (Link.USER_1, jsonString ["full_name_people"]);
			
				StartCoroutine (kurangEnergy ());
			} 
			else {
				if (PlayerPrefs.GetString(Link.INVITE_CLICK) != "TRUE") {
					warningInvitating.SetActive (true);
					warningInvitating.GetComponent<Warning> ().from = PlayerPrefs.GetString ("MultiBattle");
					warningInvitating.GetComponent<Warning> ().idYangMengajak = jsonString["idYangMengajak"].ToString();
					warningInvitating.GetComponent<Warning> ().namaYangMengajak = jsonString["namaYangMengajak"].ToString();
					warningInvitating.transform.Find ("User").GetComponent<Text> ().text = warningInvitating.GetComponent<Warning> ().namaYangMengajak;
					idajak = jsonString ["idYangMengajak"];
					namaajak = jsonString ["namaYangMengajak"];
				}
			}

			//confirming.text ="addtional data : "+Json.Serialize(additionalData) as string+"from : "+jsonString["from"]+"from2 : "+jsonString["from"].ToString()+"klik"+PlayerPrefs.GetString(Link.INVITE_CLICK);
		}

			
	}

	public bool fromUnity = false;
	public string RoomNameString = "";
	public string name_2 = "";
	public string name_1 = "";

	void Update () {
		if (fromUnity) {
			fromUnity = false;
			PlayerPrefs.SetInt ("pos", 2);
			PlayerPrefs.SetString ("RoomName", RoomNameString);
			PlayerPrefs.SetString (Link.USER_2, name_2);
			PlayerPrefs.SetString (Link.USER_1, name_1);
			StartCoroutine (kurangEnergy ());

		}
	}



	public void HandleNotificationOpened(OSNotificationOpenedResult result) {
		OSNotificationPayload payload = result.notification.payload;
		string message = payload.body;
		string actionID = result.action.actionID;
		print("GameControllerExample:HandleNotificationOpened: " + message);
		//id = "Notification opened with text: " + message;
		Dictionary<string, object> additionalData = payload.additionalData;
//		if (actionID != null) {
//			OneSignal.IdsAvailable((userId, pushToken) => {
//				id  = "UserID:\n" + userId + "\n\nPushToken:\n" + pushToken;
//			});
//		}
	}


	IEnumerator Start2()
	{
		
		if (!Input.location.isEnabledByUser) {
			yield break;
			Status.text = "GPS Aktif";
		} else {
			Status.text = "";
		}
			
		Input.location.Start();

		// Wait until service initializes
		int maxWait = 20;
		while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
		{
			yield return new WaitForSeconds(1);
			maxWait--;
		}

		// Service didn't initialize in 20 seconds
		if (maxWait < 1)
		{
			Debug.Log("Timed out");
			yield break;
		}

		// Connection has failed
		if (Input.location.status == LocationServiceStatus.Failed)
		{
			Debug.Log("Unable to determine device location");
			yield break;

			Status.text = "Can't Get Location";
		}
		else
		{
			StopCoroutine (findPeople ());
			Status.text = "Location Detected";
			PlayerPrefs.SetString (Link.LAT,Input.location.lastData.latitude.ToString());
			PlayerPrefs.SetString (Link.LOT,Input.location.lastData.longitude.ToString ());

			StartCoroutine (findPeople ());
		}

		// Stop service if there is no need to query location updates continuously
		Input.location.Stop();
	}


	IEnumerator onCoroutine(){
		while(true) 
		{ 

			#if !UNITY_EDITOR
				StartCoroutine (Start2());
			#endif

			#if UNITY_EDITOR

				Debug.Log("FindPeople");

				PlayerPrefs.SetString (Link.LAT,Input.location.lastData.latitude.ToString());
				PlayerPrefs.SetString (Link.LOT,Input.location.lastData.longitude.ToString ());

				StartCoroutine (findPeople ());
			#endif
			yield return new WaitForSeconds(2f);
		}
	}

	public void OnAccept () {
		StartCoroutine (AcceptInvited ());
	}



	private IEnumerator AcceptInvited ()
	{
		long milisecond = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

		string room_invite = PlayerPrefs.GetString (Link.EMAIL) + "@" + milisecond.ToString ();


		warningInvitating.SetActive (false);
		string url = Link.url + "acceptBattle"; 
		WWWForm form = new WWWForm ();
		form.AddField ("MY_ID", PlayerPrefs.GetString(Link.ID));
		form.AddField ("PEOPLE_ID", idajak);
		//form.AddField ("ID_DEVICE", PlayerPrefs.GetString(Link.DEVICE_ID));
		form.AddField ("ROOM", room_invite);
		WWW www = new WWW(url,form);
		yield return www;
		if (www.error == null) {
			var jsonString = JSON.Parse (www.text);
			PlayerPrefs.SetInt ("pos", 1);
			PlayerPrefs.SetString ("RoomName", room_invite);
			PlayerPrefs.SetString (Link.USER_1, PlayerPrefs.GetString(Link.FULL_NAME));
			PlayerPrefs.SetString (Link.USER_2, namaajak);

			StartCoroutine (kurangEnergy ());
		} else {
			
			//lat.text = "gagal";
		}
	}


	private IEnumerator findPeople ()
	{



		string url = Link.url + "findPeopleArround"; 
		WWWForm form = new WWWForm ();
		form.AddField (Link.ID, PlayerPrefs.GetString(Link.ID));
		form.AddField (Link.LAT, PlayerPrefs.GetString(Link.LAT));
		form.AddField (Link.LOT, PlayerPrefs.GetString(Link.LOT));
		form.AddField (Link.FCM_ID, id);
        form.AddField("DID", PlayerPrefs.GetString(Link.DEVICE_ID));
        form.AddField ("FROM", PlayerPrefs.GetString (Link.SEARCH_BATTLE));

		WWW www = new WWW(url,form);
		yield return www;
		if (www.error == null) {
			var jsonString = JSON.Parse (www.text);
			people [0].SetActive (false);
			people [1].SetActive (false);
			people [2].SetActive (false);
			people [3].SetActive (false);
			people [4].SetActive (false);

            if (int.Parse(jsonString["code"]) != 33)
            {


                PlayerPrefs.SetInt(Link.COUNT_PLAYER_FOUND, int.Parse(jsonString["count"]));

                for (int i = 0; i < PlayerPrefs.GetInt(Link.COUNT_PLAYER_FOUND); i++)
                {
                    people[i].SetActive(true);
                    people[i].transform.Find("Button").GetComponent<ButtonInvite>().clickcable = true;

                    people[i].GetComponentInChildren<Text>().text = (i + 1).ToString() + ". " + jsonString["data"][i]["PeopleFullName"];

                    people[i].transform.Find("Button").GetComponent<ButtonInvite>().PeopleId = jsonString["data"][i]["PeopleId"];
                    people[i].transform.Find("Button").GetComponent<ButtonInvite>().PeopleFullName = jsonString["data"][i]["PeopleFullName"];
                    people[i].transform.Find("Button").GetComponent<ButtonInvite>().sp = true;
                    //	people [i].transform.FindChild ("Button").GetComponentInChildren<Text> ().text 			= "Battle";
                    loading.SetActive(false);
                }
                loading.SetActive(false);
            }
            else {
                ValidationError.SetActive(true);
                Time.timeScale = 0;
            }
		} else {
			Debug.Log ("GAGAL");
		}
	}




	private IEnumerator kurangEnergy ()
	{
		string url = Link.url + "energy";
		WWWForm form = new WWWForm ();
		form.AddField (Link.ID, PlayerPrefs.GetString(Link.ID));
        form.AddField("DID", PlayerPrefs.GetString(Link.DEVICE_ID));
        form.AddField ("EUsed", energyused);
		WWW www = new WWW(url,form);
		yield return www;
		if (www.error == null) {
			var jsonString = JSON.Parse (www.text);
			Debug.Log (www.text);
			PlayerPrefs.SetString ("kodekurang", jsonString["code"]);
			if (int.Parse(PlayerPrefs.GetString("kodekurang"))==1) 
			{
				//lf.lostLife (energyused,int.Parse(jsonString["data"]["energy"]));
				PlayerPrefs.SetString (Link.ENERGY,jsonString["data"]["energy"]);
				//yield return new WaitForSeconds (1);
				Application.LoadLevel (Link.PilihCharacter);
//			if (PlayerPrefs.GetString("kodekurang")=="0") {
//				Application.LoadLevel (Link.PilihCharacter);
		}
		} else {
			Debug.Log ("GAGAL");
		}
	}






}
