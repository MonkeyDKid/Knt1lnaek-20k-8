using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
public class OnLocation : MonoBehaviour {
	public GameObject Hantu,ADA,map,abisjatah;
	public Texture[] SkinHantu;
	public Text nomap;
	bool join;
	public berburu berburu;
	// Use this for initialization
	public void Start () {
		join = true;
		StartCoroutine (onCoroutine ());
		nomap.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator Start2()
	{

//		if (!Input.location.isEnabledByUser) {
//			yield break;
//
//		}
	

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
			nomap.text = "Unable to determine device location";
			Debug.Log("Unable to determine device location");
			Hantu.SetActive (false);
			ADA.SetActive (false);
			yield break;


		}
		else
		{
			nomap.text = "";
			StopCoroutine (findPeople ());
			// Access granted and location value could be retrieved
			//Debug.Log("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
			//lat.text = Input.location.lastData.latitude.ToString();
			 if (PlayerPrefs.GetString("PLAY_TUTORIAL") == "TRUE")
            {
				PlayerPrefs.SetString (Link.LAT,"-6.244553565979");
				PlayerPrefs.SetString (Link.LOT,"106.892440795898");
			}
			else
			{
				PlayerPrefs.SetString (Link.LAT,map.GetComponent<LocationManager>().lat.ToString());
				PlayerPrefs.SetString (Link.LOT,map.GetComponent<LocationManager>().lon.ToString());
			}
		
			
//			PlayerPrefs.SetString (Link.LAT,Input.location.lastData.latitude.ToString());
//			PlayerPrefs.SetString (Link.LOT,Input.location.lastData.longitude.ToString());

			StartCoroutine (findPeople ());

		}


		// Stop service if there is no need to query location updates continuously
		Input.location.Stop();
	}
	public void cari(){
		StartCoroutine (onCoroutine ());
		join = true;
	}

	IEnumerator onCoroutine(){
		while(join) 
		{ 
			Debug.Log ("GG");
			StartCoroutine (Start2());
			yield return new WaitForSeconds(2f);
		}
	}
	private IEnumerator findPeople ()
	{
		//yield return new WaitForSeconds(2f);
		string url = Link.url + "findmylocation"; 
		WWWForm form = new WWWForm ();
		form.AddField (Link.ID, PlayerPrefs.GetString (Link.ID));
		form.AddField (Link.LAT, PlayerPrefs.GetString (Link.LAT));
		form.AddField (Link.LOT, PlayerPrefs.GetString (Link.LOT));
      //  form.AddField("DID", PlayerPrefs.GetString(Link.DEVICE_ID));
        form.AddField ("FROM", "REAL_TIME");
	//	form.AddField (Link.FCM_ID, id);

		WWW www = new WWW (url, form);
		yield return www;
		if (www.error == null) {

			var jsonString = JSON.Parse (www.text);
			if (int.Parse (jsonString ["code"]) > 0) {
				PlayerPrefs.SetString ("kodetempat", jsonString ["data"] ["kodetempat"]);
				PlayerPrefs.SetString ("kodehantu", jsonString ["data"] ["kodehantu"]);
				PlayerPrefs.SetString ("ID_bermain",jsonString["data"]["ID"]);

				PlayerPrefs.SetString (Link.BURU_FILE, jsonString ["kodehantus"] ["name_file"]);
				PlayerPrefs.SetString (Link.BURU_ATTACK, jsonString ["kodehantus"] ["ATTACK"]);
				PlayerPrefs.SetString (Link.BURU_DEFENSE, jsonString ["kodehantus"] ["DEFEND"]);
				PlayerPrefs.SetString (Link.BURU_HP, jsonString ["kodehantus"] ["HP"]);
				PlayerPrefs.SetString (Link.BURU_MODE, jsonString ["kodehantus"] ["type"]);
				int grade = int.Parse(jsonString ["kodehantus"] ["grade"]);
				var skinHantu = Hantu.transform.Find("GhostModel").gameObject.GetComponent<SkinnedMeshRenderer>();
				if( grade == 5)
				{	
					Hantu.GetComponent<WanderAI>().jumping=true;
					skinHantu.material.mainTexture = SkinHantu[2];
					berburu.TimeShiftDecrease = 2;
				}
				else if (grade >= 3 && grade < 5  )
				{
					skinHantu.material.mainTexture = SkinHantu[1];
					berburu.TimeShiftDecrease = 1.5f;
				}
				else
				{
					Hantu.GetComponent<WanderAI>().jumping=false;
					skinHantu.material.mainTexture = SkinHantu[0];
					berburu.TimeShiftDecrease = 1f;
				}
				Hantu.SetActive (true);
				ADA.SetActive (true);
				StopCoroutine (onCoroutine ());
				StopCoroutine (findPeople ());
				StopCoroutine (Start2 ());
				join = false;
			} 
			else {
				Debug.Log ("Udah Abis Jatah tempat ini");
                if (int.Parse(PlayerPrefs.GetString(Link.IBURU)) >= 2)
                {
                    abisjatah.transform.Find("Background").transform.Find("panel").transform.Find("Text").GetComponent<Text>().text="Your Quota for Hunting was reached for today, try again tommorrow";
                    abisjatah.transform.Find("Background").transform.Find("panel").transform.Find("PlayButton").gameObject.SetActive(false);
                    abisjatah.transform.Find("Background").transform.Find("panel").transform.Find("NoButton").transform.Find("Text").GetComponent<Text>().text = "Back";
                    abisjatah.SetActive(true);
                    Hantu.SetActive(false);
                    ADA.SetActive(false);
                }
                else {
                    ADA.SetActive(true);
                    abisjatah.SetActive(true);
                }
               
			
			}
		}
		Debug.Log (PlayerPrefs.GetString (Link.ID));
		Debug.Log (PlayerPrefs.GetString (Link.LAT));
		Debug.Log (PlayerPrefs.GetString (Link.LOT));
		Debug.Log (www.text);
	}
	IEnumerator checkhantu(string kodetempat){
		string url = Link.url + "checkhunter"; 
		WWWForm form = new WWWForm ();
		form.AddField (Link.ID, PlayerPrefs.GetString (Link.ID));
		form.AddField ("kodetempat", kodetempat);
		WWW www = new WWW (url, form);
		yield return www;
		if (www.error == null) {
			var jsonString = JSON.Parse (www.text);
			if(int.Parse(jsonString["code"])==0){
			
		
		} 
			else {


		

		}
	
	}
}

}

