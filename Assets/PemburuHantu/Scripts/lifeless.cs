using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using SimpleJSON;
public class lifeless : MonoBehaviour {
	public Text darah,timercountdown;
	//public Image darahslide;
	public int MAX_LIVES ;
	bool kurang = false;
	bool pertama = false;
	bool isPaused =false;
	public int hours, minutes, seconds,energycombo;
		// 5 seconds for testing
	private static TimeSpan newLifeInterval ;
	private DateTime countdowninterval;

		private DateTime lostLifeTimeStamp;
	private DateTime leftlifetimestamp;
	public int sisawaktu;
	public int livesLeft ;
		private int amountOfIntervalsPassed;
	void Start()
	{
		
		//PlayerPrefs.DeleteKey ("darahsisa");
		//PlayerPrefs.DeleteKey ("pindah");
		MAX_LIVES=int.Parse(PlayerPrefs.GetString("MaxE"));
		livesLeft=int.Parse(PlayerPrefs.GetString (Link.ENERGY));
		//Debug.Log (livesLeft);
	//	Debug.Log(PlayerPrefs.GetString ("pindah"));
	//	Debug.Log(PlayerPrefs.GetString ("date"));
		PlayerPrefs.SetInt ("time", 0); 
		//amountOfIntervalsPassed = 0;

		//newLifeInterval = new TimeSpan (hours, minutes, seconds);
		//if (PlayerPrefs.HasKey ("darahsisa")) {
			//livesLeft = PlayerPrefs.GetInt("darahsisa");
			StartCoroutine (EnergyIncreasing (livesLeft));

		StartCoroutine (ambildata ());
	}
	public void updatedata(){
		StartCoroutine (ambildata ());
	}
	private IEnumerator ambildata(){
		yield return null;
		energycombo = livesLeft + int.Parse (PlayerPrefs.GetString ("BonusEnergy"));
	}
		// Update is called once per frame
		void Update () 
		{
		if (livesLeft < 0) {
			livesLeft = MAX_LIVES;
			PlayerPrefs.SetInt ("darahsisa", MAX_LIVES);
		}
		darah.text = energycombo.ToString ()+ "/"+ MAX_LIVES;
		if (livesLeft == MAX_LIVES) {
			PlayerPrefs.SetInt ("time", 0);
			amountOfIntervalsPassed = 0;
			leftlifetimestamp = DateTime.Now;
			PlayerPrefs.SetString ("pindah", "tidak");
			PlayerPrefs.SetInt ("darahsisa", MAX_LIVES);
			PlayerPrefs.DeleteKey ("darahsisa");
			kurang = false;
		}
		if(PlayerPrefs.GetString("pindah")=="ya"){
			leftlifetimestamp = DateTime.Parse(PlayerPrefs.GetString ("date"));
			sisawaktu = (int)((DateTime.Now - leftlifetimestamp).TotalSeconds);

		
			if (!kurang) {
				countdowninterval = DateTime.Now.AddSeconds (180-sisawaktu);
				newLifeInterval = new TimeSpan (0, 3, 0);
				kurang = true;
				if (pertama) {
					countdowninterval = DateTime.Now.AddSeconds (180);
				}
			}
			TimeSpan t = DateTime.Now - leftlifetimestamp;
			TimeSpan x =  countdowninterval-DateTime.Now ;
			timercountdown.text = string.Format ("{0:D2}:{1:D2}", x.Minutes, x.Seconds);
			try 
			{
				if (!pertama&&sisawaktu<180) {
					TimeSpan gg=TimeSpan.FromSeconds(180-sisawaktu);
					double intervalD = System.Math.Floor(t.TotalSeconds / gg.TotalSeconds);
					amountOfIntervalsPassed = Convert.ToInt32(intervalD);
					pertama=true;
				}
				else
				{
					pertama=true;
			double intervalD = System.Math.Floor(t.TotalSeconds / newLifeInterval.TotalSeconds);
			amountOfIntervalsPassed = Convert.ToInt32(intervalD);
				}
			//	Debug.Log(amountOfIntervalsPassed);
			}
			catch (OverflowException) 
			{
				// something has probably gone wrong. give full lives. normalize the situation
				livesLeft = MAX_LIVES;
				Debug.Log ("something smelly");
			}  
			if (PlayerPrefs.GetInt ("time") != amountOfIntervalsPassed) {
				Debug.Log ("wololo");
				PlayerPrefs.SetInt ("time", amountOfIntervalsPassed);
				countdowninterval = DateTime.Now.AddSeconds (180);
				livesLeft += 1;
				energycombo = livesLeft + int.Parse (PlayerPrefs.GetString ("BonusEnergy"));
				StartCoroutine (EnergyIncreasing (livesLeft));
			}
		
		}
			


		if (amountOfIntervalsPassed >= MAX_LIVES) {
			livesLeft = MAX_LIVES;
			Debug.Log ("something smelly2");
			timercountdown.text ="00:00";
			StartCoroutine (EnergyIncreasing (livesLeft));
		}
		if (PlayerPrefs.GetString ("pindah") != "ya") {
			if (livesLeft < MAX_LIVES) {
				newLifeInterval = new TimeSpan (0, 3, 0);
				if (!kurang) {
					countdowninterval =  DateTime.Now.AddSeconds (180);
					kurang = true;
				}
				TimeSpan t = DateTime.Now - lostLifeTimeStamp;
				TimeSpan x =  countdowninterval-DateTime.Now ;
				timercountdown.text = string.Format ("{0:D2}:{1:D2}", x.Minutes, x.Seconds);
			
					

				// in theory if you wait for many many years, amountOfIntervalsPassed might be bigger than fits in an int 

				try {
					// round down or we get a new life whenever over half of interval has passed
					double intervalD = System.Math.Floor (t.TotalSeconds / newLifeInterval.TotalSeconds);
					amountOfIntervalsPassed = Convert.ToInt32 (intervalD);
				} catch (OverflowException) {
					// something has probably gone wrong. give full lives. normalize the situation
					livesLeft = MAX_LIVES;
					Debug.Log ("something smelly3");
					timercountdown.text ="00:00";
				}   
				if (PlayerPrefs.GetInt ("time") != amountOfIntervalsPassed) {
					Debug.Log ("wololo");
					PlayerPrefs.SetInt ("time", amountOfIntervalsPassed);
					countdowninterval =  DateTime.Now.AddSeconds (180);
					livesLeft += 1;
					energycombo = livesLeft + int.Parse (PlayerPrefs.GetString ("BonusEnergy"));
					StartCoroutine (EnergyIncreasing (livesLeft));

				}
//				if (amountOfIntervalsPassed + livesLeft >= MAX_LIVES)
//				{
//					livesLeft = MAX_LIVES;
//				}
		
				//	Debug.Log("it's been " + t + " since lives dropped from full (now "+livesLeft+"). " + amountOfIntervalsPassed + " reloads passed. Lives Left: " + getAmountOfLives() );
			}
		}
	//	darahslide.fillAmount = (float)livesLeft / 10;
//		Debug.Log(amountOfIntervalsPassed);
		}

		[ContextMenu ("Lose Life")]
	public void lostLife(int lives,int left)
		{
		//livesLeft -= lives;
		StartCoroutine (EnergyIncreasing (left));
				// mark the timestamp only when lives drop from MAX to MAX -1
				lostLifeTimeStamp = DateTime.Now;
		pindah ();
				///////////////////////////////////////////////////////////////////////////////////
				// SAVE livesLeft AND lostLifeTimeStamp HERE AND RESTORE WHEN STARTING THE GAME ///
				///////////////////////////////////////////////////////////////////////////////////
			

		//leftlifetimestamp = new DateTime(2010, 6, 12, 22, 47, 0);
		}

	void OnApplicationFocus(bool hasFocus){ 
		//isPaused = !hasFocus;
	}

	void OnApplicationPause(bool pauseStatus){ 
		//isPaused = pauseStatus;
		pindah ();
	}
	void OnApplicationQuit(){
		pindah ();
	}
	public void pindah(){
		PlayerPrefs.SetString ("date", DateTime.Now.ToString ());
		PlayerPrefs.SetString ("pindah", "ya");
		PlayerPrefs.SetInt ("darahsisa", livesLeft);


	}
		int getAmountOfLives()
		{
			return Mathf.Min(livesLeft + amountOfIntervalsPassed, MAX_LIVES);
		}
	IEnumerator EnergyIncreasing(int energy){
		string url = Link.url + "energyincrease";
		WWWForm form = new WWWForm ();
		form.AddField (Link.ID, PlayerPrefs.GetString(Link.ID));
		form.AddField ("ENERGY", energy);
		WWW www = new WWW(url,form);
		yield return www;
		if (www.error == null) {
			var jsonString = JSON.Parse (www.text);
		//	Debug.Log (www.text);
			PlayerPrefs.SetString (Link.FOR_CONVERTING, jsonString["code"]);
			PlayerPrefs.SetString (Link.ENERGY, jsonString ["code"] ["energy"]);

		} else {
			//Debug.Log ("GAGAL");
		}
	}
	}

