using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class ButtonInput : MonoBehaviour {


	public string name = "";
	public string suit = "";
	public GameObject TheButton;
	public bool wait=true;
	public Sprite suitSprite;
	public string hantunyaGO="";
	public GameObject hantu2lawan;
	public Sprite gantiSprite;
	public Game GameScript;
	private int GetCritical;
	public bool tekan = true;

	public ButtonInput friend1;
	public ButtonInput friend2;

	IEnumerator jumlahwait(){
		yield return null;
		PlayerPrefs.SetInt ("Jumlah", 1);
		if (PlayerPrefs.GetInt ("Jumlah") == 1) {



			PlayerPrefs.SetString ("Suit1", suit);

		}
	}
	public void OnClick () {
		GameScript.GetCriticalValue();
		GetCritical = GameScript.GetCritical;
		
		Debug.Log ("clicked");
		if (tekan && friend1.tekan && friend2.tekan ) {
			tekan = false;
			GetComponent<Image> ().sprite = gantiSprite;
			StartCoroutine (jumlahwait ());
			if (PlayerPrefs.GetInt ("pos") == 1) {
				PlayerPrefs.SetString ("Urutan1m", name + "A");
				TentukanSelect (name + "A");
			} else {
				PlayerPrefs.SetString ("Urutan1", name + "B");
				TentukanSelect (name + "B");
			}
//			if (PlayerPrefs.GetInt ("Jumlah") == null || PlayerPrefs.GetInt ("Jumlah") == 0) {
//				Debug.Log ("masuk");
//
//			} else {
//				PlayerPrefs.SetInt ("Jumlah", PlayerPrefs.GetInt ("Jumlah") +1);
//				StartCoroutine (jumlahwait ());
//			}



//			} else if (PlayerPrefs.GetInt ("Jumlah") == 2) {
//
//				if (PlayerPrefs.GetInt ("pos") == 1) {
//					PlayerPrefs.SetString ("Urutan2", name + "A");
//					TentukanSelect (name+"A");
//				} else {
//					PlayerPrefs.SetString ("Urutan2", name + "B");
//					TentukanSelect (name+"B");
//				}
//
//				PlayerPrefs.SetString ("Suit2", suit);
//
//			} else if (PlayerPrefs.GetInt ("Jumlah") == 3) {
//
//				if (PlayerPrefs.GetInt ("pos") == 1) {
//					PlayerPrefs.SetString ("Urutan3", name + "A");
//					TentukanSelect (name+"A");
//				} else {
//					PlayerPrefs.SetString ("Urutan3", name + "B");
//					TentukanSelect (name+"B");
//				}
//
//				PlayerPrefs.SetString ("Suit3", suit);
//
			}

				Debug.Log (name);

			//TheButton.SetActive (false);
	//	}



	}
	public void OnPilih () {

		if (tekan && friend1.tekan && friend2.tekan) {
			//tekan = false;
			//GetComponent<Image> ().sprite = gantiSprite;
//
//			if (PlayerPrefs.GetInt ("Jumlah") == null || PlayerPrefs.GetInt ("Jumlah") == 0) {
//				PlayerPrefs.SetInt ("Jumlah", 1);
//			} else {
//			//	PlayerPrefs.SetInt ("Jumlah", PlayerPrefs.GetInt ("Jumlah") + 1);
//			}

			if (PlayerPrefs.GetInt ("Jumlah") == 0) {

				if (PlayerPrefs.GetInt ("pos") == 1) {
					PlayerPrefs.SetString ("Urutan1m", name + "A");
					pertama (name + "A");
				} else {
					PlayerPrefs.SetString ("Urutan1", name + "B");
					pertama (name + "B");
				}
			}
		}
	}

	public void pertama (string name) {
		GameObject hantu = GameObject.Find (name);

		hantu.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued("select",QueueMode.PlayNow);
		hantu.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle",QueueMode.CompleteOthers);
		//hantu.transform.FindChild ("Select").GetComponent<SpriteRenderer> ().sprite = suitSprite;
		tekan = true;
	}
	public void TentukanSelect (string name) {
		//while(wait){
			//if (PlayerPrefs.GetString ("hantumusuh") != "" || PlayerPrefs.GetString ("hantumusuh") != null) {
				StartCoroutine (karafight (name));
//			} 
//			else {
//				wait = true;
//			}
//			if (PlayerPrefs.GetString ("hantumusuh") == "" || PlayerPrefs.GetString ("hantumusuh") == null) {
//				wait = true;
//			} 
	//	}


		//Debug.Log (hantu2.name);
		//hantu.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle",QueueMode.CompleteOthers);
		//hantu.transform.FindChild ("Select").GetComponent<SpriteRenderer> ().sprite = suitSprite;
		tekan = true;
	}

	IEnumerator karafight(string hantunya){
	//	wait = false;
		//Debug.Log ("updated"+PlayerPrefs.GetString ("hantumusuh"));
		hantunyaGO = hantunya;
		GameObject hantu = GameObject.Find (hantunya);
		yield return null;
		if (PlayerPrefs.GetString ("hantumusuh") != "kosong"  ) {
			//StartCoroutine (karafight (hantunyaGO));
			wait = false;
			if (PlayerPrefs.GetString ("Critical") == "y") {
				
			
				GameObject hantu2lawan = GameObject.Find (PlayerPrefs.GetString ("hantumusuh"));
				yield return new WaitForSeconds (1f);
				hantu.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("attackbaru", QueueMode.PlayNow);
				hantu2lawan.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("attackbaru", QueueMode.PlayNow);

			} 
			else {
					if(GetCritical<=1f)
		{ 
				//wait = false;
				Debug.Log ("figting"+PlayerPrefs.GetString ("hantumusuh"));
				GameObject hantu2lawan = GameObject.Find (PlayerPrefs.GetString ("hantumusuh"));
				//yield return new WaitForSeconds (1f);
				hantu.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("attackbaru", QueueMode.PlayNow);
				hantu2lawan.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("attackbaru", QueueMode.PlayNow);
				Debug.Log ("figting"+ PlayerPrefs.GetString ("hantumusuh"));
			}
			else
			{
				Debug.Log ("figting"+PlayerPrefs.GetString ("hantumusuh"));
				GameObject hantu2lawan = GameObject.Find (PlayerPrefs.GetString ("hantumusuh"));
				//yield return new WaitForSeconds (1f);
				//hantu.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("attackbaru", QueueMode.PlayNow);
				//hantu2lawan.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("attackbaru", QueueMode.PlayNow);
				Debug.Log ("figting"+ PlayerPrefs.GetString ("hantumusuh"));
			}
			}
			
		}
		else {		
			Debug.Log ("else button input");
			wait = true;
		}
	
	}
	public void Update(){
		if (wait) {
			Debug.Log ("updated"+PlayerPrefs.GetString ("hantumusuh"));
			if (PlayerPrefs.GetString ("hantumusuh") != "kosong" ) 
			{
				Debug.Log ("inside");
				hantu2lawan=GameObject.Find (PlayerPrefs.GetString ("hantumusuh"));
				Debug.Log ("inside"+hantu2lawan.name);
				//hantu2lawan.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("attackbaru", QueueMode.PlayNow);
				StartCoroutine (karafight (hantunyaGO));

			} else {
				
				wait = true;
			}
		}
	}

}
