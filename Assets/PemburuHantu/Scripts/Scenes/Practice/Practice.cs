using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System;
using OneSignalPush.MiniJSON;

public class Practice : MonoBehaviour {


	public GameObject[] people;
	public GameObject[] progress;


	public GameObject warningInvitating,loading, validationError;
	public string id = "";

	public GameObject prosesPractice,firstimer;
	public Text status;
	public Text XPM;


	void Start () {
		firstimer.SetActive (false);
		if (PlayerPrefs.GetString ("lewat")=="tidak")
		{
			firstimer.SetActive (true);
			PlayerPrefs.SetString ("lewat","Lain");
		}
		loading.SetActive (true);
	
		#if !UNITY_EDITOR
		OneSignal.SetLogLevel(OneSignal.LOG_LEVEL.VERBOSE, OneSignal.LOG_LEVEL.NONE);
		OneSignal.StartInit("30b6cca5-db55-40a5-8541-0187696d22a7")
			.HandleNotificationReceived(HandleNotificationReceived)
			.HandleNotificationOpened(HandleNotificationOpened)
			.InFocusDisplaying(OneSignal.OSInFocusDisplayOption.None)
			.EndInit();
		#endif

		#if UNITY_EDITOR
			id = "123456789";
		#endif


		long milisecond = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

		//room_invite = PlayerPrefs.GetString (Link.EMAIL) + "@" + milisecond.ToString ();


		Debug.Log (milisecond);


		StartCoroutine (onCoroutineCekInviting());

		OneSignal.IdsAvailable((userId, pushToken) => {
			id = userId;
			StartCoroutine (onCoroutine());
			StartCoroutine (onCoroutineCekInviting());
		});

	}




	private void HandleNotificationReceived(OSNotification notification) {
		
		OSNotificationPayload payload = notification.payload; 
		string message = payload.body;
		Dictionary<string, object> additionalData = payload.additionalData;
		warningInvitating.SetActive (true);


		if (additionalData == null)
			Debug.Log ("[HandleNotificationReceived] Additional Data == null");
		else {
			var jsonString = JSON.Parse (Json.Serialize(additionalData) as string);
		
			//PlayerPrefs.SetString (Link.INVITE_ROOM, jsonString["invite_room"]);


			PlayerPrefs.SetString(Link.FOR_CONVERTING, jsonString["from"]);
			warningInvitating.SetActive (true);
			warningInvitating.GetComponent<Warning> ().from = PlayerPrefs.GetString (Link.FOR_CONVERTING);
			warningInvitating.GetComponent<Warning> ().idYangMengajak = jsonString["idYangMengajak"];
			warningInvitating.GetComponent<Warning> ().namaYangMengajak = jsonString["namaYangMengajak"];

			if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == "2") {
				warningInvitating.transform.Find ("name").GetComponent<Text> ().text = warningInvitating.GetComponent<Warning> ().namaYangMengajak;
			} 
			else if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == "3") {
				warningInvitating.transform.Find ("name").GetComponent<Text> ().text = warningInvitating.GetComponent<Warning> ().namaYangMengajak + " Request To Join";
			}

		}

			
	}


	public void HandleNotificationOpened(OSNotificationOpenedResult result) {
		OSNotificationPayload payload = result.notification.payload;
		string message = payload.body;
		string actionID = result.action.actionID;

		print("GameControllerExample:HandleNotificationOpened: " + message);
		id = "Notification opened with text: " + message;

		Dictionary<string, object> additionalData = payload.additionalData;
		if (additionalData == null) 
			Debug.Log ("[HandleNotificationOpened] Additional Data == null");
		else
			Debug.Log("[HandleNotificationOpened] message "+ message +", additionalData: "+ Json.Serialize(additionalData) as string);

		if (actionID != null) {
			// actionSelected equals the id on the button the user pressed.
			// actionSelected will equal "__DEFAULT__" when the notification itself was tapped when buttons were present.
			//id  = "Pressed ButtonId: " + actionID;
			OneSignal.IdsAvailable((userId, pushToken) => {
				id  = "UserID:\n" + userId + "\n\nPushToken:\n" + pushToken;
			});
		}
	}



	public void Back () {
		SceneManagerHelper.LoadScene ("Home");
	}

	public void EXPDISTRIBUTION () {
		SceneManagerHelper.LoadScene ("EXPDis");
	}


	IEnumerator Start2()
	{
		
		if (!Input.location.isEnabledByUser) {
			yield break;

		}
			

		// Start service before querying location
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


		}
		else
		{
			StopCoroutine (findPeople ());
			// Access granted and location value could be retrieved
			//Debug.Log("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
			//lat.text = Input.location.lastData.latitude.ToString();


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
			StartCoroutine (Start2());
			yield return new WaitForSeconds(2f);
		}
	}

	IEnumerator onCoroutineCekInviting(){
		while(true) 
		{ 
			StartCoroutine (CekInviting());
			yield return new WaitForSeconds(2f);
		}
	}



	private IEnumerator CekInviting ()
	{

		string url = Link.url + "cekinviting"; 
		WWWForm form = new WWWForm ();
		form.AddField (Link.ID, PlayerPrefs.GetString(Link.ID));
        form.AddField("DID", PlayerPrefs.GetString(Link.DEVICE_ID));
        WWW www = new WWW(url,form);
		yield return www;
       
		if (www.error == null) {
			var jsonString = JSON.Parse (www.text);
            if (int.Parse(jsonString["code"]) == 1)
            {
                //////////////////////////////
                progress[0].SetActive(false);
                progress[1].SetActive(false);
                progress[2].SetActive(false);
                progress[3].SetActive(false);
                progress[4].SetActive(false);

                PlayerPrefs.SetInt(Link.COUNT_INVITING_FOUND, int.Parse(jsonString["count"]));
                PlayerPrefs.SetString(Link.FOR_CONVERTING, jsonString["leader"]);

                if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == PlayerPrefs.GetString(Link.ID))
                {
                    status.text = "Your Are Leader";
                }
                else {
                    status.text = "";
                }


                for (int i = 0; i < PlayerPrefs.GetInt(Link.COUNT_INVITING_FOUND); i++)
                {
                    progress[i].SetActive(true);
                }

                if (PlayerPrefs.GetInt(Link.COUNT_INVITING_FOUND) >= 2)
                {

                    if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == PlayerPrefs.GetString(Link.ID))
                    {
                        prosesPractice.SetActive(true);
                    }


                }
            }
            
            else if (int.Parse(jsonString["code"]) == 33) { 
                validationError.SetActive(true);
            }
            Debug.Log(int.Parse(jsonString["code"]));

        } else {
			Debug.Log ("GAGAL");
		}
       
    }
		

	private IEnumerator AcceptInvited ()
	{
		
		warningInvitating.SetActive (false);  
		string url = Link.url + "acceptinvite"; 
		WWWForm form = new WWWForm ();
		form.AddField ("MY_ID", PlayerPrefs.GetString(Link.ID));
		form.AddField ("PEOPLE_ID", warningInvitating.GetComponent<Warning> ().idYangMengajak);
		WWW www = new WWW(url,form);
		yield return www;
		if (www.error == null) {
			var jsonString = JSON.Parse (www.text);

			//PlayerPrefs.SetString (Link.INVITE_ROOM, invite_room);
			warningInvitating.SetActive (false);


		} else {
			
		}
	}

	private IEnumerator Proses ()
	{

		warningInvitating.SetActive (false);  
		string url = Link.url + "prosesPractice"; 
		WWWForm form = new WWWForm ();
		form.AddField ("MY_ID", PlayerPrefs.GetString(Link.ID));
		WWW www = new WWW(url,form);
		yield return www;
		if (www.error == null) {
            PlayerPrefs.SetString("Trained", "TRUE");
		} else {
			
		}
	}
		
	public void OnProses() {
		prosesPractice.SetActive (false);
		StartCoroutine (Proses());
	}

	public void OnAcceptInvited() {
		StartCoroutine (AcceptInvited());
	}

	public void OnDeclineInvited() {
		//StartCoroutine (onCoroutineCekInvitingByFriend());
		warningInvitating.SetActive (false);
	}

	private IEnumerator findPeople ()
	{

		string url = Link.url + "findPeopleArround"; 
		WWWForm form = new WWWForm ();
		form.AddField (Link.ID, PlayerPrefs.GetString(Link.ID));
		form.AddField (Link.LAT, PlayerPrefs.GetString(Link.LAT));
		form.AddField (Link.LOT, PlayerPrefs.GetString(Link.LOT));
        form.AddField("DID", PlayerPrefs.GetString(Link.DEVICE_ID));
        form.AddField (Link.FCM_ID, id);

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

                XPM.text = jsonString["XPM"];


                for (int i = 0; i < PlayerPrefs.GetInt(Link.COUNT_PLAYER_FOUND); i++)
                {
                    people[i].SetActive(true);
                    people[i].transform.Find("Button").GetComponent<ButtonInvite>().clickcable = true;
                    people[i].transform.Find("Button (1)").gameObject.SetActive(false);
                    people[i].transform.Find("Button (2)").gameObject.SetActive(false);
                    people[i].transform.Find("Button (3)").gameObject.SetActive(false);
                    people[i].GetComponentInChildren<Text>().text = (i + 1).ToString() + ". " + jsonString["data"][i]["PeopleFullName"];

                    people[i].transform.Find("Button").GetComponent<ButtonInvite>().PeopleId = jsonString["data"][i]["PeopleId"];
                    people[i].transform.Find("Button").GetComponent<ButtonInvite>().PeopleFullName = jsonString["data"][i]["PeopleFullName"];
                    people[i].transform.Find("Button").GetComponent<ButtonInvite>().PeopleLeader = jsonString["data"][i]["PeopleLeader"];
                    people[i].transform.Find("Button").GetComponent<ButtonInvite>().YourLeader = jsonString["data"][i]["YourLeader"];
                    people[i].transform.Find("Button").GetComponent<ButtonInvite>().status = jsonString["data"][i]["msg"];
                    //people [i].transform.FindChild ("Button").GetComponentInChildren<Text> ().text 			= jsonString ["data"] [i] ["msg"];

                    PlayerPrefs.SetString(Link.FOR_CONVERTING, jsonString["data"][i]["msg"]);

                    if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == "Joined")
                    {
                        people[i].transform.Find("Button").gameObject.SetActive(false);
                        people[i].transform.Find("Button (4)").GetComponent<ButtonInvite>().clickcable = false;
                        people[i].transform.Find("Button (4)").gameObject.SetActive(true);

                    }
                    else if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == "Request To Join")
                    {
                        people[i].transform.Find("Button").gameObject.SetActive(false);
                        people[i].transform.Find("Button (2)").GetComponent<ButtonInvite>().clickcable = false;
                        people[i].transform.Find("Button (2)").gameObject.SetActive(true);

                    }
                    else if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == "Avalaible Tomorrow")
                    {
                        //people [i].transform.FindChild ("Button").GetComponent<ButtonInvite> ().clickcable = false;
                        people[i].transform.Find("Button").gameObject.SetActive(false);
                        people[i].transform.Find("Button (1)").GetComponent<ButtonInvite>().clickcable = false;
                        people[i].transform.Find("Button (1)").gameObject.SetActive(true);

                    }
                    else if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == "Already Joined Another Room")
                    {
                        //people [i].transform.FindChild ("Button").GetComponent<ButtonInvite> ().clickcable = false;
                        people[i].transform.Find("Button").gameObject.SetActive(false);
                        people[i].transform.Find("Button (3)").GetComponent<ButtonInvite>().clickcable = false;
                        people[i].transform.Find("Button (3)").gameObject.SetActive(true);

                    }
                    else {
                        people[i].transform.Find("Button").GetComponent<ButtonInvite>().clickcable = true;
                    }


                }
                loading.SetActive(false);
            }
            else {
                validationError.SetActive(true);
            }

        } else {
			Debug.Log ("GAGAL");
		}
	}












}
