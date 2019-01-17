using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System.Collections;
using System;

public class Arena : MonoBehaviour {


	public Text AR,notes;
	public Text Gold;

	public GameObject[] defenseSpawn;
	public Text[] HantuName;
	public Text[] Level;
	public int grade1,grade2,grade3;
	public string type1,type2,type3;
	public GameObject Searching,validationerror;
	void Start () {
		AR.text = PlayerPrefs.GetString (Link.AR);
		Gold.text = PlayerPrefs.GetString (Link.GOLD);

//		if (!PlayerPrefs.HasKey ("change")) {
//			PlayerPrefs.SetInt ("change", 1);
//		}
		/*
		for (int i=0; i < 3; i++) {
			if (PlayerPrefs.GetString(Link.HANTU_DEFENSE_FILE+i.ToString()) != "" || PlayerPrefs.GetString(Link.HANTU_DEFENSE_FILE+i.ToString()) != null) {
				
				
				try {
					GameObject model = Instantiate (Resources.Load ("PrefabsChar/" + PlayerPrefs.GetString(Link.HANTU_DEFENSE_FILE+i.ToString())) 
						as GameObject,  new Vector3(0f,0f,0f), Quaternion.identity);

					model.transform.SetParent (defenseSpawn[i].transform);
					model.transform.localPosition = new Vector3 (-.3f,0,0);
					model.transform.localScale = new Vector3 (1,1,1);
					model.transform.localEulerAngles = new Vector3 (0,0,0);

					HantuName[i].text = PlayerPrefs.GetString(Link.HANTU_DEFENSE_NAME+i.ToString());
			    }
			    catch (Exception e) {
			       
			    }
				
				

			}
		}
		*/
		//Loadtest ();
		if (PlayerPrefs.HasKey ("change")) {

			if (PlayerPrefs.GetInt ("change") == 1) {
				StartCoroutine (GetHantuUserDefense ());
			} else {
				Loadtest ();
			}
		}
	}
	void Loadtest(){
		GameObject model = Instantiate (Resources.Load ("PrefabsChar/" + PlayerPrefs.GetString(Link.HANTU_DEFENSE_FILE+"1") ) 
			as GameObject,  new Vector3(0f,0f,0f), Quaternion.identity);

		model.transform.SetParent (defenseSpawn[0].transform);
		model.transform.localPosition = new Vector3 (-.3f,0,0);
		model.transform.localScale = new Vector3 (1,1,1);
		model.transform.localEulerAngles = new Vector3 (0,0,0);
		model.GetComponent<Animation> ().Play ("idle");

		GameObject model2 = Instantiate (Resources.Load ("PrefabsChar/" +  PlayerPrefs.GetString(Link.HANTU_DEFENSE_FILE+"2") ) 
			as GameObject,  new Vector3(0f,0f,0f), Quaternion.identity);

		model2.transform.SetParent (defenseSpawn[1].transform);
		model2.transform.localPosition = new Vector3 (-.3f,0,0);
		model2.transform.localScale = new Vector3 (1,1,1);
		model2.transform.localEulerAngles = new Vector3 (0,0,0);
		model2.GetComponent<Animation> ().Play ("idle");
		GameObject model3 = Instantiate (Resources.Load ("PrefabsChar/" +  PlayerPrefs.GetString(Link.HANTU_DEFENSE_FILE+"3") ) 
			as GameObject,  new Vector3(0f,0f,0f), Quaternion.identity);

		model3.transform.SetParent (defenseSpawn[2].transform);
		model3.transform.localPosition = new Vector3 (-.3f,0,0);
		model3.transform.localScale = new Vector3 (1,1,1);
		model3.transform.localEulerAngles = new Vector3 (0,0,0);
		model3.GetComponent<Animation> ().Play ("idle");
		HantuName[0].text = PlayerPrefs.GetString(Link.HANTU_DEFENSE_NAME+"1");
		HantuName[1].text = PlayerPrefs.GetString(Link.HANTU_DEFENSE_NAME+"2");
		HantuName[2].text = PlayerPrefs.GetString(Link.HANTU_DEFENSE_NAME+"3");
		notes.gameObject.SetActive (false);


		switch (PlayerPrefs.GetInt("grade1d")) {
		case 1:
			defenseSpawn [3].transform.Find ("bintangsusunstats").transform.Find("bintang1").gameObject.SetActive (true);
			break;
		case 2:
			defenseSpawn [3].transform.Find ("bintangsusunstats").transform.Find("bintang2").gameObject.SetActive (true);
			break;
		case 3:
			defenseSpawn [3].transform.Find ("bintangsusunstats").transform.Find("bintang3").gameObject.SetActive (true);
			break;
		case 4:
			defenseSpawn [3].transform.Find ("bintangsusunstats").transform.Find("bintang4").gameObject.SetActive (true);
			break;
		case 5:
			defenseSpawn [3].transform.Find ("bintangsusunstats").transform.Find("bintang5").gameObject.SetActive (true);
			break;

		}
		switch (PlayerPrefs.GetInt("grade2d")) {
		case 1:
			defenseSpawn [4].transform.Find ("bintangsusunstats").transform.Find("bintang1").gameObject.SetActive (true);
			break;
		case 2:
			defenseSpawn [4].transform.Find ("bintangsusunstats").transform.Find("bintang2").gameObject.SetActive (true);
			break;
		case 3:
			defenseSpawn [4].transform.Find ("bintangsusunstats").transform.Find("bintang3").gameObject.SetActive (true);
			break;
		case 4:
			defenseSpawn [4].transform.Find ("bintangsusunstats").transform.Find("bintang4").gameObject.SetActive (true);
			break;
		case 5:
			defenseSpawn [4].transform.Find ("bintangsusunstats").transform.Find("bintang5").gameObject.SetActive (true);
			break;

		}
		switch (PlayerPrefs.GetInt("grade3d")) {
		case 1:
			defenseSpawn [5].transform.Find ("bintangsusunstats").transform.Find("bintang1").gameObject.SetActive (true);
			break;
		case 2:
			defenseSpawn [5].transform.Find ("bintangsusunstats").transform.Find("bintang2").gameObject.SetActive (true);
			break;
		case 3:
			defenseSpawn [5].transform.Find ("bintangsusunstats").transform.Find("bintang3").gameObject.SetActive (true);
			break;
		case 4:
			defenseSpawn [5].transform.Find ("bintangsusunstats").transform.Find("bintang4").gameObject.SetActive (true);
			break;
		case 5:
			defenseSpawn [5].transform.Find ("bintangsusunstats").transform.Find("bintang5").gameObject.SetActive (true);
			break;

		}
		Level[0].text = PlayerPrefs.GetString ("level1d");
		Level[1].text = PlayerPrefs.GetString ("level2d");
		Level[2].text = PlayerPrefs.GetString ("level3d");
		HantuName[0].text = PlayerPrefs.GetString(Link.HANTU_DEFENSE_NAME+"1");
		HantuName[1].text = PlayerPrefs.GetString(Link.HANTU_DEFENSE_NAME+"2");
		HantuName[2].text = PlayerPrefs.GetString(Link.HANTU_DEFENSE_NAME+"3");
		type1 = PlayerPrefs.GetString ("type1d");
		type2 = PlayerPrefs.GetString ("type2d");
		type3 = PlayerPrefs.GetString ("type3d");
		if (type1 == "Fire") {
			defenseSpawn [3].transform.Find ("Fire").gameObject.SetActive (true);
		}
		if (type1 == "Water") {
			defenseSpawn [3].transform.Find ("Water").gameObject.SetActive (true);
		} if (type1 == "Wind") {
			defenseSpawn [3].transform.Find ("Wind").gameObject.SetActive (true);
		}


		if (type2 == "Fire") {
			defenseSpawn [4].transform.Find ("Fire").gameObject.SetActive (true);
		}
		if (type2 == "Water") {
			defenseSpawn [4].transform.Find ("Water").gameObject.SetActive (true);
		} if (type2 == "Wind") {
			defenseSpawn [4].transform.Find ("Wind").gameObject.SetActive (true);
		}


		if (type3 == "Fire") {
			defenseSpawn [5].transform.Find ("Fire").gameObject.SetActive (true);
		}
		if (type3 == "Water") {
			defenseSpawn [5].transform.Find ("Water").gameObject.SetActive (true);
		} if (type3 == "Wind") {
			defenseSpawn [5].transform.Find ("Wind").gameObject.SetActive (true);
		}
	}
	private IEnumerator GetHantuUserDefense ()
	{
		string url = Link.url + "get_hantu_defense";
		WWWForm form = new WWWForm ();
		form.AddField ("PLAYER_ID", PlayerPrefs.GetString(Link.ID));
        form.AddField("DID", PlayerPrefs.GetString(Link.DEVICE_ID));
        WWW www = new WWW(url,form);
		yield return www;
		if (www.error == null) {

			Debug.Log (www.text);
			var jsonString = JSON.Parse (www.text);
			PlayerPrefs.SetString (Link.FOR_CONVERTING, jsonString["code"]);
            if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == "0")
            {

                for (int i = 0; i < 3; i++)
                {
                    foreach (Transform child in defenseSpawn[i].transform)
                    {
                        GameObject.Destroy(child.gameObject);
                    }
                }
				var level1 = jsonString["data"]["HantuDefense1"]["HantuLevel"];
				var level2 = jsonString["data"]["HantuDefense2"]["HantuLevel"];
				var level3 = jsonString["data"]["HantuDefense3"]["HantuLevel"];
				PlayerPrefs.SetString("level1d", level1);
                PlayerPrefs.SetString("level2d", level2);
                PlayerPrefs.SetString("level3d", level3);
                grade1 = int.Parse(jsonString["data"]["HantuDefense1"]["HantuGrade"]);
                grade2 = int.Parse(jsonString["data"]["HantuDefense2"]["HantuGrade"]);
                grade3 = int.Parse(jsonString["data"]["HantuDefense3"]["HantuGrade"]);
                PlayerPrefs.SetInt("grade1d", grade1);
                PlayerPrefs.SetInt("grade2d", grade2);
                PlayerPrefs.SetInt("grade3d", grade3);
                switch (grade1)
                {
                    case 1:
                        defenseSpawn[3].transform.Find("bintangsusunstats").transform.Find("bintang1").gameObject.SetActive(true);
                        break;
                    case 2:
                        defenseSpawn[3].transform.Find("bintangsusunstats").transform.Find("bintang2").gameObject.SetActive(true);
                        break;
                    case 3:
                        defenseSpawn[3].transform.Find("bintangsusunstats").transform.Find("bintang3").gameObject.SetActive(true);
                        break;
                    case 4:
                        defenseSpawn[3].transform.Find("bintangsusunstats").transform.Find("bintang4").gameObject.SetActive(true);
                        break;
                    case 5:
                        defenseSpawn[3].transform.Find("bintangsusunstats").transform.Find("bintang5").gameObject.SetActive(true);
                        break;

                }
                switch (grade2)
                {
                    case 1:
                        defenseSpawn[4].transform.Find("bintangsusunstats").transform.Find("bintang1").gameObject.SetActive(true);
                        break;
                    case 2:
                        defenseSpawn[4].transform.Find("bintangsusunstats").transform.Find("bintang2").gameObject.SetActive(true);
                        break;
                    case 3:
                        defenseSpawn[4].transform.Find("bintangsusunstats").transform.Find("bintang3").gameObject.SetActive(true);
                        break;
                    case 4:
                        defenseSpawn[4].transform.Find("bintangsusunstats").transform.Find("bintang4").gameObject.SetActive(true);
                        break;
                    case 5:
                        defenseSpawn[4].transform.Find("bintangsusunstats").transform.Find("bintang5").gameObject.SetActive(true);
                        break;

                }
                switch (grade3)
                {
                    case 1:
                        defenseSpawn[5].transform.Find("bintangsusunstats").transform.Find("bintang1").gameObject.SetActive(true);
                        break;
                    case 2:
                        defenseSpawn[5].transform.Find("bintangsusunstats").transform.Find("bintang2").gameObject.SetActive(true);
                        break;
                    case 3:
                        defenseSpawn[5].transform.Find("bintangsusunstats").transform.Find("bintang3").gameObject.SetActive(true);
                        break;
                    case 4:
                        defenseSpawn[5].transform.Find("bintangsusunstats").transform.Find("bintang4").gameObject.SetActive(true);
                        break;
                    case 5:
                        defenseSpawn[5].transform.Find("bintangsusunstats").transform.Find("bintang5").gameObject.SetActive(true);
                        break;

                }




                type1 = jsonString["data"]["HantuDefense1"]["HantuType"];
                type2 = jsonString["data"]["HantuDefense2"]["HantuType"];
                type3 = jsonString["data"]["HantuDefense3"]["HantuType"];
                PlayerPrefs.SetString("type1d", type1);
                PlayerPrefs.SetString("type2d", type2);
                PlayerPrefs.SetString("type3d", type3);
                if (type1 == "Fire")
                {
                    defenseSpawn[3].transform.Find("Fire").gameObject.SetActive(true);
                }
                if (type1 == "Water")
                {
                    defenseSpawn[3].transform.Find("Water").gameObject.SetActive(true);
                }
                if (type1 == "Wind")
                {
                    defenseSpawn[3].transform.Find("Wind").gameObject.SetActive(true);
                }


                if (type2 == "Fire")
                {
                    defenseSpawn[4].transform.Find("Fire").gameObject.SetActive(true);
                }
                if (type2 == "Water")
                {
                    defenseSpawn[4].transform.Find("Water").gameObject.SetActive(true);
                }
                if (type2 == "Wind")
                {
                    defenseSpawn[4].transform.Find("Wind").gameObject.SetActive(true);
                }


                if (type3 == "Fire")
                {
                    defenseSpawn[5].transform.Find("Fire").gameObject.SetActive(true);
                }
                if (type3 == "Water")
                {
                    defenseSpawn[5].transform.Find("Water").gameObject.SetActive(true);
                }
                if (type3 == "Wind")
                {
                    defenseSpawn[5].transform.Find("Wind").gameObject.SetActive(true);
                }


                PlayerPrefs.SetString("def1", "PrefabsChar/" + jsonString["data"]["HantuDefense1"]["HantuFile"]);
                PlayerPrefs.SetString("def2", "PrefabsChar/" + jsonString["data"]["HantuDefense2"]["HantuFile"]);
                PlayerPrefs.SetString("def3", "PrefabsChar/" + jsonString["data"]["HantuDefense3"]["HantuFile"]);

                GameObject model = Instantiate(Resources.Load("PrefabsChar/" + jsonString["data"]["HantuDefense1"]["HantuFile"])
                    as GameObject, new Vector3(0f, 0f, 0f), Quaternion.identity);

                model.transform.SetParent(defenseSpawn[0].transform);
                model.transform.localPosition = new Vector3(-.3f, 0, 0);
                model.transform.localScale = new Vector3(1, 1, 1);
                model.transform.localEulerAngles = new Vector3(0, 0, 0);
                model.GetComponent<Animation>().PlayQueued("idle", QueueMode.PlayNow);

                GameObject model2 = Instantiate(Resources.Load("PrefabsChar/" + jsonString["data"]["HantuDefense2"]["HantuFile"])
                    as GameObject, new Vector3(0f, 0f, 0f), Quaternion.identity);

                model2.transform.SetParent(defenseSpawn[1].transform);
                model2.transform.localPosition = new Vector3(-.3f, 0, 0);
                model2.transform.localScale = new Vector3(1, 1, 1);
                model2.transform.localEulerAngles = new Vector3(0, 0, 0);
                model2.GetComponent<Animation>().PlayQueued("idle", QueueMode.PlayNow);
                GameObject model3 = Instantiate(Resources.Load("PrefabsChar/" + jsonString["data"]["HantuDefense3"]["HantuFile"])
                    as GameObject, new Vector3(0f, 0f, 0f), Quaternion.identity);

                model3.transform.SetParent(defenseSpawn[2].transform);
                model3.transform.localPosition = new Vector3(-.3f, 0, 0);
                model3.transform.localScale = new Vector3(1, 1, 1);
                model3.transform.localEulerAngles = new Vector3(0, 0, 0);
                model3.GetComponent<Animation>().PlayQueued("idle", QueueMode.PlayNow);

                PlayerPrefs.SetString(Link.HANTU_DEFENSE_FILE + "1", jsonString["data"]["HantuDefense1"]["HantuFile"]);
                PlayerPrefs.SetString(Link.HANTU_DEFENSE_FILE + "2", jsonString["data"]["HantuDefense2"]["HantuFile"]);
                PlayerPrefs.SetString(Link.HANTU_DEFENSE_FILE + "3", jsonString["data"]["HantuDefense3"]["HantuFile"]);


                PlayerPrefs.SetString(Link.HANTU_DEFENSE_NAME + "1", jsonString["data"]["HantuDefense1"]["HantuNama"]);
                PlayerPrefs.SetString(Link.HANTU_DEFENSE_NAME + "2", jsonString["data"]["HantuDefense2"]["HantuNama"]);
                PlayerPrefs.SetString(Link.HANTU_DEFENSE_NAME + "3", jsonString["data"]["HantuDefense3"]["HantuNama"]);

                HantuName[0].text = PlayerPrefs.GetString(Link.HANTU_DEFENSE_NAME + "1");
                HantuName[1].text = PlayerPrefs.GetString(Link.HANTU_DEFENSE_NAME + "2");
                HantuName[2].text = PlayerPrefs.GetString(Link.HANTU_DEFENSE_NAME + "3");
                Level[0].text = level1;
                Level[1].text = level2;
                Level[2].text = level3;
               
                notes.gameObject.SetActive(false);
            }
            else {
                validationerror.SetActive(true);
            }
            } else {
			Debug.Log ("GAGAL");
			notes.gameObject.SetActive (true);
		}
		PlayerPrefs.SetInt ("change", 0);
	}

	public void OnOnlineBattle () {
		PlayerPrefs.SetString (Link.SEARCH_BATTLE, "ONLINE");
		PlayerPrefs.SetString (Link.ArenaGetPoint, "50");
		PlayerPrefs.SetString (Link.JENIS, "SINGLE");
	//	Application.LoadLevel ("Searching");
	}


	public void OnRealtime () {
		PlayerPrefs.SetString (Link.SEARCH_BATTLE, "REAL_TIME");
		PlayerPrefs.SetString (Link.JENIS, "MULTIPLE");
        PlayerPrefs.SetString(Link.LOKASI, "ArenaDuel");
		//Application.LoadLevel ("Searching");
	}

	public void OnJousting () {
		PlayerPrefs.SetString (Link.SEARCH_BATTLE, "JOUSTING");
		PlayerPrefs.SetString (Link.JENIS, "MULTIPLE");
        PlayerPrefs.SetString(Link.LOKASI, "ArenaDuelAR");
        //	Application.LoadLevel ("Searching");
    }


	public void OnBack () {
		SceneManagerHelper.LoadScene ("Home");
	}


}
