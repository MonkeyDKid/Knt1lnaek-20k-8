using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System.Collections;


public class Fusion : MonoBehaviour
{
	public ContentController gui;
	public GameObject data, hantuList,sampah;
	public GameObject[] Slot;
	public GameObject before, after,after2,loading,button,button2,nohantu,firsttimer,displayenhance,errorcode, validationError;
	public Text Goldbar;
	public int selected;
	public bool carilevelkecil,carilevelkecil2,carilevelbesar,fusion,levelup;
	public int MonsterEXP1;
	public int monsterlevel;
	float currentexp=1000;
	public float fExp1;
	public float nexttarget;
	public int hantudefenseid1, hantudefenseid2, hantudefenseid3 = 0;


	private void Start () {
		levelup = false;
		fusion = false;
		PlayerPrefs.SetString("enchance","n");
		firsttimer.SetActive (false);
		if (PlayerPrefs.GetString ("Tutorgame") == "FALSE") {
			firsttimer.SetActive (true);
			PlayerPrefs.SetString ("Tutorgame", "FALSED");
		}

		StartCoroutine (GetHantuUser ());
		//Yang dikirim ke server gak boleh null
		if (PlayerPrefs.HasKey ("HD1")) {
			Debug.Log (PlayerPrefs.GetString ("HD1"));
		} else if (PlayerPrefs.HasKey ("HD2")) {
			Debug.Log ("HD2");
		} else if (PlayerPrefs.HasKey ("HD3")) {
			Debug.Log ("HD3");
		} else {
			PlayerPrefs.SetString ("HD1", "0");
			PlayerPrefs.SetString ("HD2", "0");
			PlayerPrefs.SetString ("HD3", "0");
		}
		PlayerPrefs.SetString ("hantukorban1ID","0");
		PlayerPrefs.SetString ("hantukorban2ID","0");
		PlayerPrefs.SetString ("hantukorban3ID","0");
		PlayerPrefs.SetString ("hantukorban4ID","0");
		PlayerPrefs.SetString ("hantukorban5ID","0");
		Goldbar.text = PlayerPrefs.GetString (Link.GOLD);
	}
	private void Update(){
		


		if (int.Parse (Goldbar.text) < 300) {
			button.SetActive (true);
			button.transform.Find ("Gold").gameObject.SetActive (true);
			button.transform.Find ("Fusion").gameObject.SetActive (false);
			//	button2.SetActive (true);
		} else {
			button.transform.Find ("Fusion").gameObject.SetActive (true);
			button.transform.Find ("Gold").gameObject.SetActive (false);
			if (selected == 0) {
				button.SetActive (true);
			} 
			if (before.activeSelf == true) {
				if (int.Parse (before.GetComponent<FusionItem> ().Grade) == 1 && int.Parse (before.GetComponent<FusionItem> ().Level.text) < 15 || int.Parse (before.GetComponent<FusionItem> ().Grade) == 2 && int.Parse (before.GetComponent<FusionItem> ().Level.text) < 20 || int.Parse (before.GetComponent<FusionItem> ().Grade) == 3 && int.Parse (before.GetComponent<FusionItem> ().Level.text) < 25 || int.Parse (before.GetComponent<FusionItem> ().Grade) == 4 && int.Parse (before.GetComponent<FusionItem> ().Level.text) < 30 || int.Parse (before.GetComponent<FusionItem> ().Grade) == 5 && int.Parse (before.GetComponent<FusionItem> ().Level.text) < 35) {
					PlayerPrefs.SetString ("enchance", "y");
					//displayenhance.SetActive (true);
					if(Slot[0].activeInHierarchy==true){
					button2.SetActive (true);
					button.SetActive (false);
					}
				} else {
					//displayenhance.SetActive (false);
					button.SetActive (false);
					button2.SetActive (false);
				}
			}
				if (before.activeInHierarchy == false) {
				//displayenhance.SetActive (false);
					//	button.SetActive (true);
					Slot [0].SetActive (false);
					Slot [1].SetActive (false);
					Slot [2].SetActive (false);
					Slot [3].SetActive (false);
					Slot [4].SetActive (false);
					if (carilevelbesar == true) {
						StartCoroutine (GetHantuUser ());
					}

				} else {
					//	button.SetActive (false);
//			Debug.Log ("test");
					if (carilevelkecil == true) {
						StartCoroutine (GetHantuUserLevelKecil (int.Parse (before.GetComponent<FusionItem> ().Grade)));
						Debug.Log ("hantukecil");
					}
					if (carilevelkecil2 == true) {
						StartCoroutine (GetHantuUserLevelKecil2 (int.Parse (before.GetComponent<FusionItem> ().Grade)));
						Debug.Log ("hantukecil2");
					}
				}

		}
		if (levelup&&after2.activeInHierarchy==true) {
			
//			fExp1 = float.Parse(before.GetComponent<FusionItem>().currentexp) / nexttarget ;
			//Debug.Log (fExp);
			//				Level.text = MonsterLevel.ToString ();
			Debug.Log ("update");
			if ( currentexp >= nexttarget) {
				Debug.Log ("lebih");
				var tempmonsterexp1 = currentexp - nexttarget;

				MonsterEXP1 = (int)tempmonsterexp1;
				currentexp = tempmonsterexp1;

				monsterlevel = int.Parse(before.GetComponent<FusionItem>().Level.text) + 1;
				MonsterEXP1 = (int)Mathf.MoveTowards (0,  currentexp, 10*monsterlevel);
			}


			after2.transform.Find("Monster1").transform.Find ("EXPBar1").transform.Find ("Expbar").GetComponent<Image> ().fillAmount = fExp1;
		
			MonsterEXP1 = (int)Mathf.MoveTowards (MonsterEXP1,  currentexp, 10*monsterlevel);
			fExp1 = MonsterEXP1 / nexttarget;
			//Debug.Log (MonsterEXP);
			// untuk effect level up
			if (after2.transform.Find("Monster1").transform.Find ("EXPBar1").transform.Find ("Expbar").GetComponent<Image> ().fillAmount >= 1f) {
				Debug.Log ("levelup");
				after2.transform.Find("Monster1").transform.Find ("leveluptext").gameObject.SetActive (true);
				after2.transform.Find("Monster1").transform.Find ("Level").GetComponent<Text> ().text = monsterlevel.ToString();
				//	GameObject blam = Instantiate (effect, m1);
				//gethantunextlevel.OnClick ();
				//gethantuuser.Reload ();
				nexttarget = PlayerPrefs.GetFloat ("target1");

			} else {


			}
			if (MonsterEXP1 == currentexp) {
				//levelup = false;
			}
		}
	}

	public void OnClick () {
		if (PlayerPrefs.GetString ("hantukorban3ID") == null || PlayerPrefs.GetString ("hantukorban3ID") == "") {
			Debug.Log("gak boleh kosong");
		}

		//	gameObject.GetComponent<FusionItem> ().interactable = false;
		if (before.activeInHierarchy) {
			//after.SetActive (true);
			//after.transform.FindChild ("Icon_Char").GetComponent<Image> ().sprite = before.transform.FindChild ("Icon_Char").GetComponent<Image>().sprite;
			//after.transform.FindChild ("Level").GetComponent<Text> ().text = "1";
			StartCoroutine( Hapuspengorbanan ());
		}
		Debug.Log( "Hantu Player ID : " + PlayerPrefs.GetString ("HantuNaikGrade"));
		Debug.Log( PlayerPrefs.GetString ("hantukorban1ID"));
		Debug.Log( PlayerPrefs.GetString ("hantukorban2ID"));
		Debug.Log( PlayerPrefs.GetString ("hantukorban3ID"));
		Debug.Log( PlayerPrefs.GetString ("hantukorban4ID"));
		Debug.Log( PlayerPrefs.GetString ("hantukorban5ID"));
	
	}

	public void OnClick2 () {
		if (PlayerPrefs.GetString ("hantukorban3ID") == null || PlayerPrefs.GetString ("hantukorban3ID") == "") {
			Debug.Log("gak boleh kosong");
		}
		Debug.Log (PlayerPrefs.GetString ("currentxp"));
		Debug.Log (PlayerPrefs.GetString ("nextlevel"));
		//	gameObject.GetComponent<FusionItem> ().interactable = false;
		if (before.activeInHierarchy) {
			//after.SetActive (true);
			//after.transform.FindChild ("Icon_Char").GetComponent<Image> ().sprite = before.transform.FindChild ("Icon_Char").GetComponent<Image>().sprite;
			//after.transform.FindChild ("Level").GetComponent<Text> ().text = "1";
			StartCoroutine( Hapuspengorbananlevelup ());
		}
		Debug.Log( "Hantu Player ID : " + PlayerPrefs.GetString ("HantuNaikGrade"));
		Debug.Log( PlayerPrefs.GetString ("hantukorban1ID"));
		Debug.Log( PlayerPrefs.GetString ("hantukorban2ID"));
		Debug.Log( PlayerPrefs.GetString ("hantukorban3ID"));
		Debug.Log( PlayerPrefs.GetString ("hantukorban4ID"));
		Debug.Log( PlayerPrefs.GetString ("hantukorban5ID"));

	}
	private IEnumerator Hapuspengorbanan ()
	{    string url = Link.url + "fusion";
		WWWForm form = new WWWForm ();
		form.AddField (Link.ID, PlayerPrefs.GetString (Link.ID));
		form.AddField ("HantuNaikGrade", PlayerPrefs.GetString("HantuNaikGrade"));
		form.AddField ("Hantukorban1ID", PlayerPrefs.GetString("hantukorban1ID"));
		form.AddField ("Hantukorban2ID", PlayerPrefs.GetString("hantukorban2ID"));
		form.AddField ("Hantukorban3ID", PlayerPrefs.GetString("hantukorban3ID"));
		form.AddField ("Hantukorban4ID", PlayerPrefs.GetString("hantukorban4ID"));
		form.AddField ("Hantukorban5ID", PlayerPrefs.GetString("hantukorban5ID"));
		//form.AddField (Link.ID, PlayerPrefs.GetString(Link.ID));
		WWW www = new WWW(url,form);
		yield return www;
		var jsonString = JSON.Parse (www.text);
		Debug.Log (www.text);
		if (www.error == null) {
		//	Debug.Log (www.text);
			switch(selected){
			case 1:
				Slot [5].SetActive (true);
				Slot [5].GetComponent<Animator> ().Play (0);
			
				break;
			case 2:
				Slot [5].SetActive (true);
				Slot [6].SetActive (true);
				Slot [5].GetComponent<Animator> ().Play (0);
				Slot [6].GetComponent<Animator> ().Play (0);
	
				break;
			case 3:
				Slot [5].SetActive (true);
				Slot [6].SetActive (true);
				Slot [7].SetActive (true);
				Slot [5].GetComponent<Animator> ().Play (0);
				Slot [6].GetComponent<Animator> ().Play (0);
				Slot [7].GetComponent<Animator> ().Play (0);
			
				break;
			case 4:
				Slot [5].SetActive (true);
				Slot [6].SetActive (true);
				Slot [7].SetActive (true);
				Slot [8].SetActive (true);
				Slot [5].GetComponent<Animator> ().Play (0);
				Slot [6].GetComponent<Animator> ().Play (0);
				Slot [7].GetComponent<Animator> ().Play (0);
				Slot [8].GetComponent<Animator> ().Play (0);

				break;
			case 5:
				Slot [5].SetActive (true);
				Slot [6].SetActive (true);
				Slot [7].SetActive (true);
				Slot [8].SetActive (true);
				Slot [9].SetActive (true);
				Slot [5].GetComponent<Animator> ().Play (0);
				Slot [6].GetComponent<Animator> ().Play (0);
				Slot [7].GetComponent<Animator> ().Play (0);
				Slot [8].GetComponent<Animator> ().Play (0);
				Slot [9].GetComponent<Animator> ().Play (0);
				break;


			}
			Slot [10].SetActive (true);
			yield return new WaitForSeconds (.5f);
			before.SetActive (false);
			Slot [0].SetActive (false);
			Slot [1].SetActive (false);
			Slot [2].SetActive (false);
			Slot [3].SetActive (false);
			Slot [4].SetActive (false);
			StartCoroutine (GetHantuUser ());



			StartCoroutine (starUPInfo (PlayerPrefs.GetString("HantuNaikGrade"),0));
			fusion = true;
			PlayerPrefs.SetString ("hantukorban1ID","0");
			PlayerPrefs.SetString ("hantukorban2ID","0");
			PlayerPrefs.SetString ("hantukorban3ID","0");
			PlayerPrefs.SetString ("hantukorban4ID","0");
			PlayerPrefs.SetString ("hantukorban5ID","0");
			Goldbar.text = jsonString ["Player"] ["coin"];
		//	PlayerPrefs.GetString (Link.GOLD);
		} 
		else {
			Debug.Log (www.error);
			Debug.Log ("gagal");}
	}

	private IEnumerator Hapuspengorbananlevelup ()
	{    string url = Link.url + "enchance";
		WWWForm form = new WWWForm ();
		form.AddField (Link.ID, PlayerPrefs.GetString (Link.ID));
		form.AddField ("HantuNaikGrade", PlayerPrefs.GetString("HantuNaikGrade"));
		form.AddField ("Hantukorban1ID", PlayerPrefs.GetString("hantukorban1ID"));
		form.AddField ("Hantukorban2ID", PlayerPrefs.GetString("hantukorban2ID"));
		form.AddField ("Hantukorban3ID", PlayerPrefs.GetString("hantukorban3ID"));
		form.AddField ("Hantukorban4ID", PlayerPrefs.GetString("hantukorban4ID"));
		form.AddField ("Hantukorban5ID", PlayerPrefs.GetString("hantukorban5ID"));
		//form.AddField (Link.ID, PlayerPrefs.GetString(Link.ID));
		WWW www = new WWW(url,form);
		yield return www;
		var jsonString = JSON.Parse (www.text);
		Debug.Log (www.text);
		if (www.error == null) {
			//	Debug.Log (www.text);
			switch(selected){
			case 1:
				Slot [5].SetActive (true);
				Slot [5].GetComponent<Animator> ().Play (0);
				break;
			case 2:
				Slot [5].SetActive (true);
				Slot [6].SetActive (true);
				Slot [5].GetComponent<Animator> ().Play (0);
				Slot [6].GetComponent<Animator> ().Play (0);
				break;
			case 3:
				Slot [5].SetActive (true);
				Slot [6].SetActive (true);
				Slot [7].SetActive (true);
				Slot [5].GetComponent<Animator> ().Play (0);
				Slot [6].GetComponent<Animator> ().Play (0);
				Slot [7].GetComponent<Animator> ().Play (0);
				break;
			case 4:
				Slot [5].SetActive (true);
				Slot [6].SetActive (true);
				Slot [7].SetActive (true);
				Slot [8].SetActive (true);
				Slot [5].GetComponent<Animator> ().Play (0);
				Slot [6].GetComponent<Animator> ().Play (0);
				Slot [7].GetComponent<Animator> ().Play (0);
				Slot [8].GetComponent<Animator> ().Play (0);
			
				break;
			case 5:
				Slot [5].SetActive (true);
				Slot [6].SetActive (true);
				Slot [7].SetActive (true);
				Slot [8].SetActive (true);
				Slot [9].SetActive (true);
				Slot [5].GetComponent<Animator> ().Play (0);
				Slot [6].GetComponent<Animator> ().Play (0);
				Slot [7].GetComponent<Animator> ().Play (0);
				Slot [8].GetComponent<Animator> ().Play (0);
				Slot [9].GetComponent<Animator> ().Play (0);

				break;


			}
			Slot [10].SetActive (true);
			yield return new WaitForSeconds (.5f);
			before.SetActive (false);
			Slot [0].SetActive (false);
			Slot [1].SetActive (false);
			Slot [2].SetActive (false);
			Slot [3].SetActive (false);
			Slot [4].SetActive (false);
			StartCoroutine (GetHantuUser ());



			StartCoroutine (starUPInfo (PlayerPrefs.GetString("HantuNaikGrade"),0));
			PlayerPrefs.SetString("enchance","n");
			PlayerPrefs.SetString ("hantukorban1ID","0");
			PlayerPrefs.SetString ("hantukorban2ID","0");
			PlayerPrefs.SetString ("hantukorban3ID","0");
			PlayerPrefs.SetString ("hantukorban4ID","0");
			PlayerPrefs.SetString ("hantukorban5ID","0");
			Goldbar.text = jsonString ["Player"] ["coin"];
		} 
		else {
			Debug.Log (www.text);
			Debug.Log ("gagal");}
	}

	private IEnumerator starUPInfo(string hantuplayerid, int Exp){
			Debug.Log ("TES");
			string url = Link.url + "send_xp";
			WWWForm form = new WWWForm ();
			form.AddField ("MY_ID", PlayerPrefs.GetString(Link.ID));
			form.AddField ("PlayerHantuID", hantuplayerid);
			form.AddField ("EXPERIENCE", Exp);
			//form.AddField ("CURRENTEXPB", Latestexpbank);

			WWW www = new WWW(url,form);
			yield return www;

			if (www.error == null) {

				var jsonString = JSON.Parse (www.text);
			Debug.Log (www.text);
			Debug.Log (jsonString ["code"] ["HantuGrade"]);
			PlayerPrefs.SetFloat("target1", float.Parse(jsonString ["code"] ["Targetnextlevel"]));
			currentexp = float.Parse(jsonString["code"]["monstercurrentexp"]);
			Debug.Log(currentexp);
				//PlayerPrefs.SetFloat("target", float.Parse(jsonString ["code"] ["Targetnextlevel"]));.
			if (fusion) {
				after.SetActive (true);
				after.transform.Find ("FusionItem").GetComponent<FusionItem> ().Grade = jsonString ["code"] ["HantuGrade"];
				after.transform.Find ("FusionItem").GetComponent<FusionItem> ().Level.text = jsonString ["code"] ["HantuLevel"];
				after.transform.Find ("FusionItem").GetComponent<FusionItem> ().icon.sprite = before.GetComponent<FusionItem> ().icon.sprite;

			} else {
				levelup = true;
//				if (float.Parse (before.GetComponent<FusionItem> ().currentexp) == 0) {
//					fExp1 = 1 / float.Parse (before.GetComponent<FusionItem> ().nextlevelexp);
//				} else {
//					fExp1 =float.Parse (before.GetComponent<FusionItem> ().currentexp) / float.Parse (before.GetComponent<FusionItem> ().nextlevelexp);
//				}


				after2.transform.Find("Monster1").transform.Find ("EXPBar1").transform.Find ("Expbar").GetComponent<Image> ().fillAmount = fExp1;

				nexttarget = float.Parse(PlayerPrefs.GetString("nextlevel"));
				after2.SetActive (true);
				after2.transform.Find("Monster1").transform.Find ("Icon_Char").GetComponent<Image> ().sprite = before.GetComponent<FusionItem> ().icon.sprite;
				after2.transform.Find("Monster1").transform.Find ("Level").GetComponent<Text> ().text = jsonString ["code"] ["HantuLevel"];
			
			}

			Slot [5].SetActive (false);
			Slot [6].SetActive (false);
			Slot [7].SetActive (false);
			Slot [8].SetActive (false);
			Slot [9].SetActive (false);
			Slot [10].SetActive (false);
			//	monstercurrentexp += Exp;
			//	StartCoroutine (updateData ());
			//	gethantuuser.Reload ();

			} else {
				Debug.Log ("Failed kirim data");
			//	yield return new WaitForSeconds (5);
			//	StartCoroutine (updateData());

			}
	}
	public void OnBack () {
		SceneManagerHelper.LoadScene (Link.Home);
	}

	private IEnumerator GetHantuUser ()
	{
		string url = Link.url + "getDataHantuUser";
		WWWForm form = new WWWForm ();
		form.AddField (Link.ID, PlayerPrefs.GetString(Link.ID));
        form.AddField("DID", PlayerPrefs.GetString(Link.DEVICE_ID));
        WWW www = new WWW(url,form);
		yield return www;
		if (www.error == null) {
			var jsonString = JSON.Parse (www.text);
			//Debug.Log (www.text);
			PlayerPrefs.SetString (Link.FOR_CONVERTING, jsonString["code"]);
            if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == "0") {
                for (int x = gui.Content.childCount - 1; x >= 0; x--) {
                    Destroy(gui.Content.GetChild(x).gameObject);
                }
                GameObject[] entry;
                entry = new GameObject[int.Parse(jsonString["count"])];

                for (int x = 0; x < int.Parse(jsonString["count"]); x++) {


                    //					if(int.Parse(jsonString ["data"] [x] ["HantuGrade"]) == 1 &&  int.Parse (jsonString ["data"] [x] ["HantuLevel"]) >= 15 || int.Parse(jsonString ["data"] [x] ["HantuGrade"]) == 2 &&  int.Parse (jsonString ["data"] [x] ["HantuLevel"]) >= 20 ||int.Parse(jsonString ["data"] [x] ["HantuGrade"]) == 3 &&  int.Parse (jsonString ["data"] [x] ["HantuLevel"]) >= 25 ||int.Parse(jsonString ["data"] [x] ["HantuGrade"]) == 4 &&  int.Parse (jsonString ["data"] [x] ["HantuLevel"]) >= 30   ) {

                    entry[x] = Instantiate(data);
                    //		Debug.Log (jsonString ["data"] [x] ["HantuGrade"]);
                    entry[x].GetComponent<FusionItem>().icon.sprite = Resources.Load<Sprite>("icon_char_Maps/" + jsonString["data"][x]["HantuFile"]);
                    entry[x].GetComponent<FusionItem>().PlayerHantuId = jsonString["data"][x]["HantuPlayerID"];
                    entry[x].GetComponent<FusionItem>().hantuId = jsonString["data"][x]["HantuId"];
                    entry[x].GetComponent<FusionItem>().name = jsonString["data"][x]["HantuNama"];
                    entry[x].GetComponent<FusionItem>().file = jsonString["data"][x]["HantuFile"];
                    entry[x].GetComponent<FusionItem>().Grade = jsonString["data"][x]["HantuGrade"];
                    entry[x].GetComponent<FusionItem>().currentexp = jsonString["data"][x]["monstercurrentexp"];
                    entry[x].GetComponent<FusionItem>().nextlevelexp = jsonString["data"][x]["Targetnextlevel"];
                    entry[x].GetComponent<FusionItem>().Level.text = jsonString["data"][x]["HantuLevel"];
                    entry[x].GetComponent<FusionItem>().type = jsonString["data"][x]["HantuType"];
                    entry[x].GetComponent<FusionItem>().attack = int.Parse(jsonString["data"][x]["HantuAttack"]);
                    entry[x].GetComponent<FusionItem>().defense = int.Parse(jsonString["data"][x]["HantuDefense"]);
                    entry[x].GetComponent<FusionItem>().stamina = int.Parse(jsonString["data"][x]["HantuStamina"]);
                    entry[x].transform.SetParent(gui.Content, false);


                    //					} 
                    //					else {
                    //						//nohantu.SetActive (true);
                    //						//entry [x].transform.SetParent (sampah.transform);
                    //					}


                }
                carilevelbesar = false;
                //				for (int x =sampah.transform.childCount - 1; x >= 0; x--) {
                //					Destroy (sampah.transform.GetChild (x).gameObject);
            }
            else if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == "33")
            {
                validationError.SetActive(true);
                loading.SetActive(false);
            }
            else {

                Debug.Log("GAGAL");
                errorcode.transform.Find("Dialog").gameObject.SetActive(true);
                errorcode.SetActive(true);

            }
			yield return new WaitForSeconds (1);
			errorcode.SetActive (false);
			loading.SetActive (false);

		} else {
			errorcode.transform.Find ("Dialog").gameObject.SetActive (true);
			errorcode.SetActive (true);
		}
	}


	private IEnumerator GetHantuUserLevelKecil (int grade)
	{
		carilevelkecil = false;
		string url = Link.url + "getDataHantuUser";
		WWWForm form = new WWWForm ();
		form.AddField (Link.ID, PlayerPrefs.GetString(Link.ID));
        form.AddField("DID", PlayerPrefs.GetString(Link.DEVICE_ID));
        WWW www = new WWW(url,form);
		yield return www;
		if (www.error == null) {
			var jsonString = JSON.Parse (www.text);
			PlayerPrefs.SetString (Link.FOR_CONVERTING, jsonString["code"]);
			if (PlayerPrefs.GetString(Link.FOR_CONVERTING)=="0") {
				for (int x = gui.Content.childCount - 1; x >= 0; x--) {
					Destroy (gui.Content.GetChild (x).gameObject);
				}
				GameObject[] entry;
				entry = new GameObject[int.Parse(jsonString["count"])];

				for (int x = 0; x < int.Parse (jsonString ["count"]); x++) {
					switch (grade) {
					case 1:
						
						if (int.Parse(PlayerPrefs.GetString("HD1"))!=int.Parse(jsonString ["data"] [x] ["HantuPlayerID"])&&int.Parse(PlayerPrefs.GetString("HD2"))!=int.Parse(jsonString ["data"] [x] ["HantuPlayerID"])&&int.Parse(PlayerPrefs.GetString("HD3"))!=int.Parse(jsonString ["data"] [x] ["HantuPlayerID"])&&int.Parse(before.GetComponent<FusionItem> ().PlayerHantuId)!=int.Parse(jsonString ["data"] [x] ["HantuPlayerID"])&&int.Parse (jsonString ["data"] [x] ["HantuGrade"]) == grade && int.Parse (jsonString ["data"] [x] ["HantuLevel"]) < 15) {
							entry [x] = Instantiate (data);
							entry [x].GetComponent<FusionItem> ().icon.sprite = Resources.Load<Sprite> ("icon_char_Maps/" + jsonString ["data"] [x] ["HantuFile"]);
							entry [x].GetComponent<FusionItem> ().PlayerHantuId = jsonString ["data"] [x] ["HantuPlayerID"];
							entry [x].GetComponent<FusionItem> ().hantuId = jsonString ["data"] [x] ["HantuId"];
							entry [x].GetComponent<FusionItem> ().name = jsonString ["data"] [x] ["HantuNama"];
							entry [x].GetComponent<FusionItem> ().file = jsonString ["data"] [x] ["HantuFile"];
							entry [x].GetComponent<FusionItem> ().Grade = jsonString ["data"] [x] ["HantuGrade"];
							entry [x].GetComponent<FusionItem> ().Level.text = jsonString ["data"] [x] ["HantuLevel"];
							entry [x].GetComponent<FusionItem> ().type = jsonString ["data"] [x] ["HantuType"];
							entry [x].GetComponent<FusionItem> ().attack = int.Parse (jsonString ["data"] [x] ["HantuAttack"]);
							entry [x].GetComponent<FusionItem> ().defense = int.Parse (jsonString ["data"] [x] ["HantuDefense"]);
							entry [x].GetComponent<FusionItem> ().stamina = int.Parse (jsonString ["data"] [x] ["HantuStamina"]);
							entry [x].transform.SetParent (gui.Content, false);
						} else {
							//nohantu.SetActive (true);
						}
						break;
					case 2:

						if (int.Parse(PlayerPrefs.GetString("HD1"))!=int.Parse(jsonString ["data"] [x] ["HantuPlayerID"])&&int.Parse(PlayerPrefs.GetString("HD2"))!=int.Parse(jsonString ["data"] [x] ["HantuPlayerID"])&&int.Parse(PlayerPrefs.GetString("HD3"))!=int.Parse(jsonString ["data"] [x] ["HantuPlayerID"])&&int.Parse(before.GetComponent<FusionItem> ().PlayerHantuId)!=int.Parse(jsonString ["data"] [x] ["HantuPlayerID"])&&int.Parse (jsonString ["data"] [x] ["HantuGrade"]) <= grade && int.Parse(jsonString ["data"] [x] ["HantuLevel"])<20) {
							entry [x] = Instantiate (data);
							entry [x].GetComponent<FusionItem> ().icon.sprite = Resources.Load<Sprite> ("icon_char_Maps/" + jsonString ["data"] [x] ["HantuFile"]);
							entry [x].GetComponent<FusionItem> ().PlayerHantuId = jsonString ["data"] [x] ["HantuPlayerID"];
							entry [x].GetComponent<FusionItem> ().hantuId = jsonString ["data"] [x] ["HantuId"];
							entry [x].GetComponent<FusionItem> ().name = jsonString ["data"] [x] ["HantuNama"];
							entry [x].GetComponent<FusionItem> ().file = jsonString ["data"] [x] ["HantuFile"];
							entry [x].GetComponent<FusionItem> ().Grade = jsonString ["data"] [x] ["HantuGrade"];
							entry [x].GetComponent<FusionItem> ().Level.text = jsonString ["data"] [x] ["HantuLevel"];
							entry [x].GetComponent<FusionItem> ().type = jsonString ["data"] [x] ["HantuType"];
							entry [x].GetComponent<FusionItem> ().attack = int.Parse (jsonString ["data"] [x] ["HantuAttack"]);
							entry [x].GetComponent<FusionItem> ().defense = int.Parse (jsonString ["data"] [x] ["HantuDefense"]);
							entry [x].GetComponent<FusionItem> ().stamina = int.Parse (jsonString ["data"] [x] ["HantuStamina"]);
							entry [x].transform.SetParent (gui.Content, false);
						}
						else {
							//nohantu.SetActive (true);
						}
						break;
					case 3:
					//	entry [x] = Instantiate (data);
						if (int.Parse(PlayerPrefs.GetString("HD1"))!=int.Parse(jsonString ["data"] [x] ["HantuPlayerID"])&&int.Parse(PlayerPrefs.GetString("HD2"))!=int.Parse(jsonString ["data"] [x] ["HantuPlayerID"])&&int.Parse(PlayerPrefs.GetString("HD3"))!=int.Parse(jsonString ["data"] [x] ["HantuPlayerID"])&&int.Parse(before.GetComponent<FusionItem> ().PlayerHantuId)!=int.Parse(jsonString ["data"] [x] ["HantuPlayerID"])&&int.Parse (jsonString ["data"] [x] ["HantuGrade"]) <= grade && int.Parse(jsonString ["data"] [x] ["HantuLevel"])<25) {
							entry [x] = Instantiate (data);
							entry [x].GetComponent<FusionItem> ().icon.sprite = Resources.Load<Sprite> ("icon_char_Maps/" + jsonString ["data"] [x] ["HantuFile"]);
							entry [x].GetComponent<FusionItem> ().PlayerHantuId = jsonString ["data"] [x] ["HantuPlayerID"];
							entry [x].GetComponent<FusionItem> ().hantuId = jsonString ["data"] [x] ["HantuId"];
							entry [x].GetComponent<FusionItem> ().name = jsonString ["data"] [x] ["HantuNama"];
							entry [x].GetComponent<FusionItem> ().file = jsonString ["data"] [x] ["HantuFile"];
							entry [x].GetComponent<FusionItem> ().Grade = jsonString ["data"] [x] ["HantuGrade"];
							entry [x].GetComponent<FusionItem> ().Level.text = jsonString ["data"] [x] ["HantuLevel"];
							entry [x].GetComponent<FusionItem> ().type = jsonString ["data"] [x] ["HantuType"];
							entry [x].GetComponent<FusionItem> ().attack = int.Parse (jsonString ["data"] [x] ["HantuAttack"]);
							entry [x].GetComponent<FusionItem> ().defense = int.Parse (jsonString ["data"] [x] ["HantuDefense"]);
							entry [x].GetComponent<FusionItem> ().stamina = int.Parse (jsonString ["data"] [x] ["HantuStamina"]);
							entry [x].transform.SetParent (gui.Content, false);
						}
						else {
							//nohantu.SetActive (true);
						}
						break;
					case 4:
						//entry [x] = Instantiate (data);
						if (int.Parse(PlayerPrefs.GetString("HD1"))!=int.Parse(jsonString ["data"] [x] ["HantuPlayerID"])&&int.Parse(PlayerPrefs.GetString("HD2"))!=int.Parse(jsonString ["data"] [x] ["HantuPlayerID"])&&int.Parse(PlayerPrefs.GetString("HD3"))!=int.Parse(jsonString ["data"] [x] ["HantuPlayerID"])&&int.Parse(before.GetComponent<FusionItem> ().PlayerHantuId)!=int.Parse(jsonString ["data"] [x] ["HantuPlayerID"])&&int.Parse (jsonString ["data"] [x] ["HantuGrade"]) <= grade && int.Parse(jsonString ["data"] [x] ["HantuLevel"])<30) {
							entry [x] = Instantiate (data);
							entry [x].GetComponent<FusionItem> ().icon.sprite = Resources.Load<Sprite> ("icon_char_Maps/" + jsonString ["data"] [x] ["HantuFile"]);
							entry [x].GetComponent<FusionItem> ().PlayerHantuId = jsonString ["data"] [x] ["HantuPlayerID"];
							entry [x].GetComponent<FusionItem> ().hantuId = jsonString ["data"] [x] ["HantuId"];
							entry [x].GetComponent<FusionItem> ().name = jsonString ["data"] [x] ["HantuNama"];
							entry [x].GetComponent<FusionItem> ().file = jsonString ["data"] [x] ["HantuFile"];
							entry [x].GetComponent<FusionItem> ().Grade = jsonString ["data"] [x] ["HantuGrade"];
							entry [x].GetComponent<FusionItem> ().Level.text = jsonString ["data"] [x] ["HantuLevel"];
							entry [x].GetComponent<FusionItem> ().type = jsonString ["data"] [x] ["HantuType"];
							entry [x].GetComponent<FusionItem> ().attack = int.Parse (jsonString ["data"] [x] ["HantuAttack"]);
							entry [x].GetComponent<FusionItem> ().defense = int.Parse (jsonString ["data"] [x] ["HantuDefense"]);
							entry [x].GetComponent<FusionItem> ().stamina = int.Parse (jsonString ["data"] [x] ["HantuStamina"]);
							entry [x].transform.SetParent (gui.Content, false);
						}
						else {
							//nohantu.SetActive (true);
						}
						break;
					case 5:
						//entry [x] = Instantiate (data);
						if (int.Parse(PlayerPrefs.GetString("HD1"))!=int.Parse(jsonString ["data"] [x] ["HantuPlayerID"])&&int.Parse(PlayerPrefs.GetString("HD2"))!=int.Parse(jsonString ["data"] [x] ["HantuPlayerID"])&&int.Parse(PlayerPrefs.GetString("HD3"))!=int.Parse(jsonString ["data"] [x] ["HantuPlayerID"])&&int.Parse(before.GetComponent<FusionItem> ().PlayerHantuId)!=int.Parse(jsonString ["data"] [x] ["HantuPlayerID"])&&int.Parse (jsonString ["data"] [x] ["HantuGrade"]) <= grade && int.Parse(jsonString ["data"] [x] ["HantuLevel"])<35) {
							entry [x] = Instantiate (data);
							entry [x].GetComponent<FusionItem> ().icon.sprite = Resources.Load<Sprite> ("icon_char_Maps/" + jsonString ["data"] [x] ["HantuFile"]);
							entry [x].GetComponent<FusionItem> ().PlayerHantuId = jsonString ["data"] [x] ["HantuPlayerID"];
							entry [x].GetComponent<FusionItem> ().hantuId = jsonString ["data"] [x] ["HantuId"];
							entry [x].GetComponent<FusionItem> ().name = jsonString ["data"] [x] ["HantuNama"];
							entry [x].GetComponent<FusionItem> ().file = jsonString ["data"] [x] ["HantuFile"];
							entry [x].GetComponent<FusionItem> ().Grade = jsonString ["data"] [x] ["HantuGrade"];
							entry [x].GetComponent<FusionItem> ().Level.text = jsonString ["data"] [x] ["HantuLevel"];
							entry [x].GetComponent<FusionItem> ().type = jsonString ["data"] [x] ["HantuType"];
							entry [x].GetComponent<FusionItem> ().attack = int.Parse (jsonString ["data"] [x] ["HantuAttack"]);
							entry [x].GetComponent<FusionItem> ().defense = int.Parse (jsonString ["data"] [x] ["HantuDefense"]);
							entry [x].GetComponent<FusionItem> ().stamina = int.Parse (jsonString ["data"] [x] ["HantuStamina"]);
							entry [x].transform.SetParent (gui.Content, false);
						}
						else {
							//nohantu.SetActive (true);
						}
						break;
					
					}

				}
				yield return new WaitForSeconds (1);
				loading.SetActive (false);
			}
            else if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == "33")
            {
                validationError.SetActive(true);
                loading.SetActive(false);
            }

        }  else {
			Debug.Log ("GAGAL");
		}
	}

	private IEnumerator GetHantuUserLevelKecil2 (int grade)
	{
		carilevelkecil2 = false;
		string url = Link.url + "getDataHantuUser";
		WWWForm form = new WWWForm ();
		form.AddField (Link.ID, PlayerPrefs.GetString(Link.ID));
        form.AddField("DID", PlayerPrefs.GetString(Link.DEVICE_ID));
        WWW www = new WWW(url,form);
		yield return www;
		if (www.error == null) {
			var jsonString = JSON.Parse (www.text);
			PlayerPrefs.SetString (Link.FOR_CONVERTING, jsonString["code"]);
			if (PlayerPrefs.GetString(Link.FOR_CONVERTING)=="0") {
				for (int x = gui.Content.childCount - 1; x >= 0; x--) {
					Destroy (gui.Content.GetChild (x).gameObject);
				}
				GameObject[] entry;
				entry = new GameObject[int.Parse(jsonString["count"])];

				for (int x = 0; x < int.Parse (jsonString ["count"]); x++) {
					switch (grade) {
					case 1:

						if (int.Parse(PlayerPrefs.GetString("HD1"))!=int.Parse(jsonString ["data"] [x] ["HantuPlayerID"])&&int.Parse(PlayerPrefs.GetString("HD2"))!=int.Parse(jsonString ["data"] [x] ["HantuPlayerID"])&&int.Parse(PlayerPrefs.GetString("HD3"))!=int.Parse(jsonString ["data"] [x] ["HantuPlayerID"])&&int.Parse(before.GetComponent<FusionItem> ().PlayerHantuId)!=int.Parse(jsonString ["data"] [x] ["HantuPlayerID"])&&int.Parse (jsonString ["data"] [x] ["HantuGrade"]) == grade && int.Parse (jsonString ["data"] [x] ["HantuLevel"]) < 15) {
							entry [x] = Instantiate (data);
							entry [x].GetComponent<FusionItem> ().icon.sprite = Resources.Load<Sprite> ("icon_char_Maps/" + jsonString ["data"] [x] ["HantuFile"]);
							entry [x].GetComponent<FusionItem> ().PlayerHantuId = jsonString ["data"] [x] ["HantuPlayerID"];
							entry [x].GetComponent<FusionItem> ().hantuId = jsonString ["data"] [x] ["HantuId"];
							entry [x].GetComponent<FusionItem> ().name = jsonString ["data"] [x] ["HantuNama"];
							entry [x].GetComponent<FusionItem> ().file = jsonString ["data"] [x] ["HantuFile"];
							entry [x].GetComponent<FusionItem> ().Grade = jsonString ["data"] [x] ["HantuGrade"];
							entry [x].GetComponent<FusionItem> ().Level.text = jsonString ["data"] [x] ["HantuLevel"];
							entry [x].GetComponent<FusionItem> ().type = jsonString ["data"] [x] ["HantuType"];
							entry [x].GetComponent<FusionItem> ().attack = int.Parse (jsonString ["data"] [x] ["HantuAttack"]);
							entry [x].GetComponent<FusionItem> ().defense = int.Parse (jsonString ["data"] [x] ["HantuDefense"]);
							entry [x].GetComponent<FusionItem> ().stamina = int.Parse (jsonString ["data"] [x] ["HantuStamina"]);
							entry [x].transform.SetParent (gui.Content, false);
						} else {
							//nohantu.SetActive (true);
						}
						break;
					case 2:

						if (int.Parse(PlayerPrefs.GetString("HD1"))!=int.Parse(jsonString ["data"] [x] ["HantuPlayerID"])&&int.Parse(PlayerPrefs.GetString("HD2"))!=int.Parse(jsonString ["data"] [x] ["HantuPlayerID"])&&int.Parse(PlayerPrefs.GetString("HD3"))!=int.Parse(jsonString ["data"] [x] ["HantuPlayerID"])&&int.Parse(before.GetComponent<FusionItem> ().PlayerHantuId)!=int.Parse(jsonString ["data"] [x] ["HantuPlayerID"])&&int.Parse (jsonString ["data"] [x] ["HantuGrade"]) <= grade && int.Parse(jsonString ["data"] [x] ["HantuLevel"])<20) {
							entry [x] = Instantiate (data);
							entry [x].GetComponent<FusionItem> ().icon.sprite = Resources.Load<Sprite> ("icon_char_Maps/" + jsonString ["data"] [x] ["HantuFile"]);
							entry [x].GetComponent<FusionItem> ().PlayerHantuId = jsonString ["data"] [x] ["HantuPlayerID"];
							entry [x].GetComponent<FusionItem> ().hantuId = jsonString ["data"] [x] ["HantuId"];
							entry [x].GetComponent<FusionItem> ().name = jsonString ["data"] [x] ["HantuNama"];
							entry [x].GetComponent<FusionItem> ().file = jsonString ["data"] [x] ["HantuFile"];
							entry [x].GetComponent<FusionItem> ().Grade = jsonString ["data"] [x] ["HantuGrade"];
							entry [x].GetComponent<FusionItem> ().Level.text = jsonString ["data"] [x] ["HantuLevel"];
							entry [x].GetComponent<FusionItem> ().type = jsonString ["data"] [x] ["HantuType"];
							entry [x].GetComponent<FusionItem> ().attack = int.Parse (jsonString ["data"] [x] ["HantuAttack"]);
							entry [x].GetComponent<FusionItem> ().defense = int.Parse (jsonString ["data"] [x] ["HantuDefense"]);
							entry [x].GetComponent<FusionItem> ().stamina = int.Parse (jsonString ["data"] [x] ["HantuStamina"]);
							entry [x].transform.SetParent (gui.Content, false);
						}
						else {
							//nohantu.SetActive (true);
						}
						break;
					case 3:
						//	entry [x] = Instantiate (data);
						if (int.Parse(PlayerPrefs.GetString("HD1"))!=int.Parse(jsonString ["data"] [x] ["HantuPlayerID"])&&int.Parse(PlayerPrefs.GetString("HD2"))!=int.Parse(jsonString ["data"] [x] ["HantuPlayerID"])&&int.Parse(PlayerPrefs.GetString("HD3"))!=int.Parse(jsonString ["data"] [x] ["HantuPlayerID"])&&int.Parse(before.GetComponent<FusionItem> ().PlayerHantuId)!=int.Parse(jsonString ["data"] [x] ["HantuPlayerID"])&&int.Parse (jsonString ["data"] [x] ["HantuGrade"]) <= grade && int.Parse(jsonString ["data"] [x] ["HantuLevel"])<25) {
							entry [x] = Instantiate (data);
							entry [x].GetComponent<FusionItem> ().icon.sprite = Resources.Load<Sprite> ("icon_char_Maps/" + jsonString ["data"] [x] ["HantuFile"]);
							entry [x].GetComponent<FusionItem> ().PlayerHantuId = jsonString ["data"] [x] ["HantuPlayerID"];
							entry [x].GetComponent<FusionItem> ().hantuId = jsonString ["data"] [x] ["HantuId"];
							entry [x].GetComponent<FusionItem> ().name = jsonString ["data"] [x] ["HantuNama"];
							entry [x].GetComponent<FusionItem> ().file = jsonString ["data"] [x] ["HantuFile"];
							entry [x].GetComponent<FusionItem> ().Grade = jsonString ["data"] [x] ["HantuGrade"];
							entry [x].GetComponent<FusionItem> ().Level.text = jsonString ["data"] [x] ["HantuLevel"];
							entry [x].GetComponent<FusionItem> ().type = jsonString ["data"] [x] ["HantuType"];
							entry [x].GetComponent<FusionItem> ().attack = int.Parse (jsonString ["data"] [x] ["HantuAttack"]);
							entry [x].GetComponent<FusionItem> ().defense = int.Parse (jsonString ["data"] [x] ["HantuDefense"]);
							entry [x].GetComponent<FusionItem> ().stamina = int.Parse (jsonString ["data"] [x] ["HantuStamina"]);
							entry [x].transform.SetParent (gui.Content, false);
						}
						else {
							//nohantu.SetActive (true);
						}
						break;
					case 4:
						//entry [x] = Instantiate (data);
						if (int.Parse(PlayerPrefs.GetString("HD1"))!=int.Parse(jsonString ["data"] [x] ["HantuPlayerID"])&&int.Parse(PlayerPrefs.GetString("HD2"))!=int.Parse(jsonString ["data"] [x] ["HantuPlayerID"])&&int.Parse(PlayerPrefs.GetString("HD3"))!=int.Parse(jsonString ["data"] [x] ["HantuPlayerID"])&&int.Parse(before.GetComponent<FusionItem> ().PlayerHantuId)!=int.Parse(jsonString ["data"] [x] ["HantuPlayerID"])&&int.Parse (jsonString ["data"] [x] ["HantuGrade"]) <= grade && int.Parse(jsonString ["data"] [x] ["HantuLevel"])<30) {
							entry [x] = Instantiate (data);
							entry [x].GetComponent<FusionItem> ().icon.sprite = Resources.Load<Sprite> ("icon_char_Maps/" + jsonString ["data"] [x] ["HantuFile"]);
							entry [x].GetComponent<FusionItem> ().PlayerHantuId = jsonString ["data"] [x] ["HantuPlayerID"];
							entry [x].GetComponent<FusionItem> ().hantuId = jsonString ["data"] [x] ["HantuId"];
							entry [x].GetComponent<FusionItem> ().name = jsonString ["data"] [x] ["HantuNama"];
							entry [x].GetComponent<FusionItem> ().file = jsonString ["data"] [x] ["HantuFile"];
							entry [x].GetComponent<FusionItem> ().Grade = jsonString ["data"] [x] ["HantuGrade"];
							entry [x].GetComponent<FusionItem> ().Level.text = jsonString ["data"] [x] ["HantuLevel"];
							entry [x].GetComponent<FusionItem> ().type = jsonString ["data"] [x] ["HantuType"];
							entry [x].GetComponent<FusionItem> ().attack = int.Parse (jsonString ["data"] [x] ["HantuAttack"]);
							entry [x].GetComponent<FusionItem> ().defense = int.Parse (jsonString ["data"] [x] ["HantuDefense"]);
							entry [x].GetComponent<FusionItem> ().stamina = int.Parse (jsonString ["data"] [x] ["HantuStamina"]);
							entry [x].transform.SetParent (gui.Content, false);
						}
						else {
							//nohantu.SetActive (true);
						}
						break;
					}

				}
				yield return new WaitForSeconds (1);
				loading.SetActive (false);
			}
            else if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == "33")
            {
                validationError.SetActive(true);
                loading.SetActive(false);
            }


        }
        else {
			Debug.Log ("GAGAL");
		}
	}

	public void carilevelBesartrue(){
		StartCoroutine(	GetHantuUser ());
	}

}


