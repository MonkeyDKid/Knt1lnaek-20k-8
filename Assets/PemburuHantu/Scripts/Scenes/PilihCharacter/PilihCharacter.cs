using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using SimpleJSON;
using System.Collections;
using System;
using System.Linq;

public class PilihCharacter : MonoBehaviour {
	[Serializable]
	public class HantuData
	{
		public string hantuname;
		public int attack;
		public int defense;
		public string hp;
		public string typeS;
	}
	[Serializable]
	public class Golongan
	{
		public HantuData[] Hantunya;
	}
	public Golongan[] Golongannya;
	//public int i = 0;
	public string[] hantu;
	public int pil1 = 0;
	public int pil2 = 0;
	public int pil3 = 0;

	string android_id = "";
	string pos = "";
	public WWWForm formKirimPilihanCharacter,formsimpancharacter;
	bool sudah3 = false;
	bool wait;

	public  GameObject enemylineup, loading,win,firstTimerPilih,loading2,loading3, ValidationError;
	public float waitTime;

	public Sprite Api;
	public Sprite kosong;
	public GameObject Selection1,Selection2,Selection3;
	public GameObject LineUp;
	//public GameObject PleaseWait;

	public GameObject Loadingscreen;
	public GameObject LineUp1;
	public GameObject LineUp2;
	public GameObject LineUp3;
	public GameObject select1,select2,select3;

	public GameObject Musuh1, Musuh2, Musuh3;
	public Image LineUpApi1;
	public Image LineUpApi2;
	public Image LineUpApi3;

	public ContentController gui;
	public GameObject data;

	public GameObject selection1;
	public GameObject selection2;
	public GameObject selection3;

	public GameObject vsParent;
	public GameObject StartNya;

	void Start () {


		if (PlayerPrefs.GetString ("berburu") == "ya") {
		//	loading3.SetActive (true);
			PlayerPrefs.SetInt ("MapPlayerXP", 0);
			GetHantuList();
			//manualrandomburu ();
			StartCoroutine (locationplayed ());
			PlayerPrefs.SetString (Link.SEARCH_BATTLE, "SINGLE");
			PlayerPrefs.SetString (Link.LOKASI, "graveyard");
			PlayerPrefs.SetString (Link.JENIS, "SINGLE");
            Musuh1.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon_charLama/" + PlayerPrefs.GetString(Link.POS_1_CHAR_1_FILE));
            vsParent.transform.Find ("pos1_car1").gameObject.SetActive (false);
			vsParent.transform.Find ("pos1_car3").gameObject.SetActive (false);
			//cek last used monster ada atau tidak
			//apabila ada, ambil data baru setiap monster kemudian langsung menuju vs dan jika tidak ada, pilih character.
		//	StartCoroutine( Checkntake());
		}
		//test
	
		//^^ test
		//Script ini error di ganti character defense ..
		Debug.Log( "mapexpnya"+PlayerPrefs.GetInt ("MAPSEXP"));
		if (PlayerPrefs.GetString ("PLAY_TUTORIAL") == "TRUE") 
		{
			firstTimerPilih.gameObject.SetActive (true);
			//SceneManagerHelper.LoadTutorial("PilihCharacter");
		} else {
			firstTimerPilih.gameObject.SetActive (false);
		}
	

		wait = false;
		if (PlayerPrefs.GetString (Link.JENIS) == "SINGLE") {
			if(Application.loadedLevelName=="PilihCharacter")
			{
				enemylineup.SetActive(true);
				if (PlayerPrefs.GetString ("PLAY_TUTORIAL") == "TRUE") 
				{
					Musuh1.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + PlayerPrefs.GetString (Link.POS_1_CHAR_1_FILE));
				}
				else
				{
				
				Musuh1.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + PlayerPrefs.GetString (Link.POS_1_CHAR_1_FILE));
				Musuh2.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + PlayerPrefs.GetString (Link.POS_1_CHAR_2_FILE));
				Musuh3.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + PlayerPrefs.GetString (Link.POS_1_CHAR_3_FILE));
			}
			}
			
			PlayerPrefs.SetString ("id_device","2");
			PlayerPrefs.SetString ("pos","2");
			PlayerPrefs.SetString ("RoomName", "SINGLE");

			
		} 
		else {


		}

			if (PlayerPrefs.GetString (Link.SEARCH_BATTLE) == "ONLINE") {
			Musuh1.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("icon_charLama/" + PlayerPrefs.GetString (Link.POS_1_CHAR_1_FILE));
			Musuh2.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("icon_charLama/" + PlayerPrefs.GetString (Link.POS_1_CHAR_2_FILE));
			Musuh3.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("icon_charLama/" + PlayerPrefs.GetString (Link.POS_1_CHAR_3_FILE));
			Musuh1.transform.Find("Level").GetComponent<Text>().text = PlayerPrefs.GetString (Link.POS_1_CHAR_1_LEVEL);
			var hantuburuname = PlayerPrefs.GetString(Link.POS_1_CHAR_1_FILE);
			var hantuburuname2 = PlayerPrefs.GetString(Link.POS_1_CHAR_2_FILE);
			var hantuburuname3 = PlayerPrefs.GetString(Link.POS_1_CHAR_3_FILE);
			if (hantuburuname.Contains('_'))
			{
				int index = hantuburuname.IndexOf('_');
				string result = hantuburuname.Substring(0, index);
				Musuh1.transform.Find("backname").transform.Find("Namegreen").transform.Find("Name").GetComponent<Text>().text = result;
			}
			if (hantuburuname2.Contains('_'))
			{
				int index = hantuburuname2.IndexOf('_');
				string result = hantuburuname2.Substring(0, index);
				Musuh2.transform.Find("backname").transform.Find("Namegreen").transform.Find("Name").GetComponent<Text>().text = result;
			}
			if (hantuburuname3.Contains('_'))
			{
				int index = hantuburuname3.IndexOf('_');
				string result = hantuburuname3.Substring(0, index);
				Musuh3.transform.Find("backname").transform.Find("Namegreen").transform.Find("Name").GetComponent<Text>().text = result;
			}
			
			}

		android_id = PlayerPrefs.GetString ("id_device");
		pos = PlayerPrefs.GetInt ("pos").ToString();
		formKirimPilihanCharacter = new WWWForm ();
		formsimpancharacter= new WWWForm ();
		formKirimPilihanCharacter.AddField ("id_device",android_id);
		formKirimPilihanCharacter.AddField ("pos",pos);
		formKirimPilihanCharacter.AddField ("room_name", PlayerPrefs.GetString ("RoomName"));


		PlayerPrefs.SetString ("CarPil1", "kosong");
		PlayerPrefs.SetString ("CarPil2", "kosong");
		PlayerPrefs.SetString ("CarPil3", "kosong");


		StartCoroutine (GetHantuUser ());

	}
	private IEnumerator Checkntake()
	{
		if (PlayerPrefs.HasKey (Link.CHAR_1_ID) && PlayerPrefs.HasKey (Link.CHAR_3_ID) && PlayerPrefs.HasKey (Link.CHAR_2_ID)) {
			string url = Link.url + "check_n_take";
			WWWForm form = new WWWForm ();
			form.AddField (Link.ID, PlayerPrefs.GetString (Link.ID));
			form.AddField ("G1", PlayerPrefs.GetString (Link.CHAR_1_ID));
			form.AddField ("G2", PlayerPrefs.GetString (Link.CHAR_2_ID));
			form.AddField ("G3", PlayerPrefs.GetString (Link.CHAR_3_ID));
			WWW www = new WWW (url, form);
			yield return www;
			if (www.error == null) {
				var jsonString = JSON.Parse (www.text);
				Debug.Log (www.text);
				PlayerPrefs.SetString (Link.FOR_CONVERTING, jsonString ["code"]);
				if (int.Parse(PlayerPrefs.GetString (Link.FOR_CONVERTING)) == 1) {
					

					PlayerPrefs.SetString (Link.POS_2_CHAR_1_FILE, jsonString ["data"] ["Hantu1"] ["HantuFile"]);
					PlayerPrefs.SetString (Link.POS_2_CHAR_1_ATTACK,  jsonString ["data"] ["Hantu1"] ["HantuAttack"]);
					PlayerPrefs.SetString (Link.POS_2_CHAR_1_DEFENSE, jsonString ["data"] ["Hantu1"] ["HantuDefense"]);
					PlayerPrefs.SetString (Link.POS_2_CHAR_1_HP,jsonString ["data"] ["Hantu1"] ["HantuStamina"]);
					PlayerPrefs.SetString (Link.POS_2_CHAR_1_ELEMENT, jsonString ["data"] ["Hantu1"] ["HantuType"]);

					PlayerPrefs.SetString (Link.POS_2_CHAR_2_FILE, jsonString ["data"] ["Hantu2"] ["HantuFile"]);
					PlayerPrefs.SetString (Link.POS_2_CHAR_2_ATTACK, jsonString ["data"] ["Hantu2"] ["HantuAttack"]);
					PlayerPrefs.SetString (Link.POS_2_CHAR_2_DEFENSE, jsonString ["data"] ["Hantu2"] ["HantuDefense"]);
					PlayerPrefs.SetString (Link.POS_2_CHAR_2_HP, jsonString ["data"] ["Hantu2"] ["HantuStamina"]);
					PlayerPrefs.SetString (Link.POS_2_CHAR_2_ELEMENT, jsonString ["data"] ["Hantu2"] ["HantuType"]);

					PlayerPrefs.SetString (Link.POS_2_CHAR_3_FILE, jsonString ["data"] ["Hantu3"] ["HantuFile"]);
					PlayerPrefs.SetString (Link.POS_2_CHAR_3_ATTACK, jsonString ["data"] ["Hantu3"] ["HantuAttack"]);
					PlayerPrefs.SetString (Link.POS_2_CHAR_3_DEFENSE, jsonString ["data"] ["Hantu3"] ["HantuDefense"]);
					PlayerPrefs.SetString (Link.POS_2_CHAR_3_HP, jsonString ["data"] ["Hantu3"] ["HantuStamina"]);
					PlayerPrefs.SetString (Link.POS_2_CHAR_3_ELEMENT, jsonString ["data"] ["Hantu3"] ["HantuType"]);


					PlayerPrefs.SetString (Link.POS_2_CHAR_1_ID, PlayerPrefs.GetString(Link.CHAR_1_ID));
					PlayerPrefs.SetString (Link.POS_2_CHAR_2_ID, PlayerPrefs.GetString(Link.CHAR_2_ID));
					PlayerPrefs.SetString (Link.POS_2_CHAR_3_ID, PlayerPrefs.GetString(Link.CHAR_3_ID));

					PlayerPrefs.SetString (Link.POS_2_CHAR_1_GRADE, jsonString ["data"] ["Hantu1"] ["HantuGrade"]);
					PlayerPrefs.SetString (Link.POS_2_CHAR_2_GRADE, jsonString ["data"] ["Hantu2"] ["HantuGrade"]);
					PlayerPrefs.SetString (Link.POS_2_CHAR_3_GRADE, jsonString ["data"] ["Hantu3"] ["HantuGrade"]);

					PlayerPrefs.SetString (Link.POS_2_CHAR_1_LEVEL, jsonString ["data"] ["Hantu1"] ["HantuLevel"]);
					PlayerPrefs.SetString (Link.POS_2_CHAR_2_LEVEL, jsonString ["data"] ["Hantu2"] ["HantuLevel"]);
					PlayerPrefs.SetString (Link.POS_2_CHAR_3_LEVEL, jsonString ["data"] ["Hantu3"] ["HantuLevel"]);
					yield return new WaitForSeconds (.5f);
					loading2.SetActive(false);
					loading3.SetActive (false);
					StartCoroutine (vs ());

				} else {
					loading3.SetActive (false);
				}
	
			}
		} else {
			loading3.SetActive (false);
		}
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
			Debug.Log (www.text);
			PlayerPrefs.SetString (Link.FOR_CONVERTING, jsonString["code"]);
			if (PlayerPrefs.GetString(Link.FOR_CONVERTING)=="0") {

				GameObject[] entry;
				entry = new GameObject[int.Parse(jsonString["count"])];

				for (int x = 0; x < int.Parse(jsonString["count"]); x++) {
					entry [x] = Instantiate (data);
					entry[x].GetComponent<PilihCharacterItem>().icon.sprite = Resources.Load<Sprite>("icon_char_Maps/" + jsonString["data"][x]["HantuFile"]);
					entry [x].GetComponent<PilihCharacterItem> ().GetComponent<Image> ().rectTransform.sizeDelta = new Vector2 (111f, 139f);
					entry[x].GetComponent<PilihCharacterItem>().GetComponent<Image>().sprite=Resources.Load<Sprite>("icon_char_Maps/" + jsonString["data"][x]["HantuFile"]);
					entry[x].GetComponent<PilihCharacterItem>().PlayerHantuId = jsonString["data"][x]["HantuPlayerID"];

					entry[x].GetComponent<PilihCharacterItem>().Grade = jsonString["data"][x]["HantuGrade"];
					entry[x].GetComponent<PilihCharacterItem>().LevelString = jsonString["data"][x]["HantuLevel"];

					entry[x].GetComponent<PilihCharacterItem>().hantuId = jsonString["data"][x]["HantuId"];
					entry[x].GetComponent<PilihCharacterItem>().name 	  = jsonString["data"][x]["HantuNama"];
					entry[x].GetComponent<PilihCharacterItem>().file 	  = jsonString["data"][x]["HantuFile"];
					entry[x].GetComponent<PilihCharacterItem>().Level.text   = jsonString["data"][x]["HantuLevel"];
					entry[x].GetComponent<PilihCharacterItem>().type 	  = jsonString["data"][x]["HantuType"];
					entry[x].GetComponent<PilihCharacterItem>().typeS 	  = jsonString["data"][x]["HantuTypeS"];
					entry[x].GetComponent<PilihCharacterItem>().attack  = int.Parse(jsonString["data"][x]["HantuAttack"]);
					entry[x].GetComponent<PilihCharacterItem>().defense = int.Parse(jsonString["data"][x]["HantuDefense"]);
					entry[x].GetComponent<PilihCharacterItem>().stamina = int.Parse(jsonString["data"][x]["HantuStamina"]);

					entry[x].GetComponent<PilihCharacterItem>().targetnextlevel = jsonString["data"][x]["Targetnextlevel"];
					entry[x].GetComponent<PilihCharacterItem>().monstercurrentexp = jsonString["data"][x]["monstercurrentexp"];
					entry[x].transform.SetParent (gui.Content, false);
				}
				yield return new WaitForSeconds (1);
				loading2.SetActive (false);
			}
            else if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == "33")
            {
                ValidationError.SetActive(true);
            }
        } else {
			Debug.Log ("GAGAL");
		}
	}

	public void LineUpButton1Click () {

		if (pil1 == 0) {
			
		} else {
			pil1 = 0;
			LineUp1.GetComponent<Image> ().sprite = kosong;
			LineUpApi1.sprite =  kosong;
			select1.SetActive (false);
			Selection1.GetComponent<Image> ().sprite = kosong;
			Selection1.transform.Find ("backname").transform.Find ("Namegreen").transform.Find ("Name").GetComponent<Text> ().text = "";
			Selection1.transform.Find ("Level").GetComponent<Text> ().text = "";

			Selection1.transform.Find ("BSpilih").transform.Find ("bintang1").gameObject.SetActive (false);
			Selection1.transform.Find ("BSpilih").transform.Find ("bintang2").gameObject.SetActive (false);
			Selection1.transform.Find ("BSpilih").transform.Find ("bintang3").gameObject.SetActive (false);
			Selection1.transform.Find ("BSpilih").transform.Find ("bintang4").gameObject.SetActive (false);
			Selection1.transform.Find ("BSpilih").transform.Find ("bintang5").gameObject.SetActive (false);
			//CarInformation ci = GameObject.Find (PlayerPrefs.GetString ("CarPil1")).GetComponent<CarInformation> ();

			//ci.sudah = false;
			//ci.SelectionBox.SetActive (false);
			sudah3 = false;

			selection1.GetComponent<PilihCharacterItem> ().sudah = false;

			PlayerPrefs.SetString ("CarPil1", "kosong");
			StartNya.SetActive (false);
		}


	}

	void GetHantuList()
	{
			PlayerPrefs.SetString (Link.POS_1_CHAR_1_FILE, PlayerPrefs.GetString(Link.BURU_FILE));
			PlayerPrefs.SetString (Link.POS_1_CHAR_1_ATTACK, PlayerPrefs.GetString(Link.BURU_ATTACK));
			PlayerPrefs.SetString (Link.POS_1_CHAR_1_DEFENSE, PlayerPrefs.GetString(Link.BURU_DEFENSE));
			PlayerPrefs.SetString (Link.POS_1_CHAR_1_HP, PlayerPrefs.GetString(Link.BURU_HP));
			PlayerPrefs.SetString (Link.POS_1_CHAR_1_MODE, PlayerPrefs.GetString(Link.BURU_MODE));
			PlayerPrefs.SetString (Link.POS_1_CHAR_1_ELEMENT, PlayerPrefs.GetString(Link.BURU_MODE));
			   var hantuburuname = PlayerPrefs.GetString(Link.POS_1_CHAR_1_FILE);
            if (hantuburuname.Contains('_'))
            {
                int index = hantuburuname.IndexOf('_');
                string result = hantuburuname.Substring(0, index);
                Musuh1.transform.Find("backname").transform.Find("Namegreen").transform.Find("Name").GetComponent<Text>().text = result;
            }
           
            Musuh1.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon_charLama/" + PlayerPrefs.GetString(Link.POS_1_CHAR_1_FILE));
          
            Musuh1.transform.Find("Level").GetComponent<Text>().text = "1";
            var type = PlayerPrefs.GetString(Link.POS_1_CHAR_1_ELEMENT);
            if (type == "Fire")
            {
                Musuh1.transform.Find("backname").transform.Find("Fire").gameObject.SetActive(true);
                Musuh1.transform.Find("backname").transform.Find("Water").gameObject.SetActive(false);
                Musuh1.transform.Find("backname").transform.Find("Wind").gameObject.SetActive(false);
            }
            else if (type == "Water")
            {
                Musuh1.transform.Find("backname").transform.Find("Fire").gameObject.SetActive(false);
                Musuh1.transform.Find("backname").transform.Find("Water").gameObject.SetActive(true);
                Musuh1.transform.Find("backname").transform.Find("Wind").gameObject.SetActive(false);
            }
            else {
                Musuh1.transform.Find("backname").transform.Find("Fire").gameObject.SetActive(false);
                Musuh1.transform.Find("backname").transform.Find("Water").gameObject.SetActive(false);
                Musuh1.transform.Find("backname").transform.Find("Wind").gameObject.SetActive(true);
            }

	}
	void manualrandomburu(){
		if (int.Parse(PlayerPrefs.GetString ("kodehantu")) == 1) 
		{
			int randomgolongan = UnityEngine.Random.Range (0, 4);
			if (randomgolongan == 0) {
				var monsterrarity = UnityEngine.Random.value;
				if (monsterrarity > 0.25f) {
					int randomhantunya = UnityEngine.Random.Range (0, 2);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_FILE, Golongannya [0].Hantunya [randomhantunya].hantuname);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_ATTACK, Golongannya [0].Hantunya [randomhantunya].attack.ToString());
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_DEFENSE, Golongannya [0].Hantunya [randomhantunya].defense.ToString());
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_HP, Golongannya [0].Hantunya [randomhantunya].hp);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_MODE, Golongannya [0].Hantunya [randomhantunya].typeS);
				} else if (monsterrarity < 0.25f && monsterrarity > 0.1f) {
					int randomhantunya = UnityEngine.Random.Range (1, 3);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_FILE, Golongannya [0].Hantunya [randomhantunya].hantuname);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_ATTACK, Golongannya [0].Hantunya [randomhantunya].attack.ToString());
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_DEFENSE, Golongannya [0].Hantunya [randomhantunya].defense.ToString());
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_HP, Golongannya [0].Hantunya [randomhantunya].hp);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_MODE, Golongannya [0].Hantunya [randomhantunya].typeS);
				
				} else if (monsterrarity < 0.05f) {
					int randomhantunya = 4;
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_FILE, Golongannya [0].Hantunya [randomhantunya].hantuname);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_ATTACK, Golongannya [0].Hantunya [randomhantunya].attack.ToString());
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_DEFENSE, Golongannya [0].Hantunya [randomhantunya].defense.ToString());
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_HP, Golongannya [0].Hantunya [randomhantunya].hp);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_MODE, Golongannya [0].Hantunya [randomhantunya].typeS);
				}
			}
			if (randomgolongan == 1) {
				var monsterrarity = UnityEngine.Random.value;
				if (monsterrarity > 0.25f) {
					int randomhantunya = UnityEngine.Random.Range (0, 2);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_FILE, Golongannya [1].Hantunya [randomhantunya].hantuname);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_ATTACK, Golongannya [1].Hantunya [randomhantunya].attack.ToString());
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_DEFENSE, Golongannya [1].Hantunya [randomhantunya].defense.ToString());
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_HP, Golongannya [1].Hantunya [randomhantunya].hp);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_MODE, Golongannya [1].Hantunya [randomhantunya].typeS);
				} else if (monsterrarity < 0.25f && monsterrarity > 0.1f) {
					int randomhantunya = UnityEngine.Random.Range (1, 3);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_FILE, Golongannya [1].Hantunya [randomhantunya].hantuname);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_ATTACK, Golongannya [1].Hantunya [randomhantunya].attack.ToString());
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_DEFENSE, Golongannya [1].Hantunya [randomhantunya].defense.ToString());
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_HP, Golongannya [1].Hantunya [randomhantunya].hp);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_MODE, Golongannya [1].Hantunya [randomhantunya].typeS);

				} else if (monsterrarity < 0.05f) {
					int randomhantunya = 4;
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_FILE, Golongannya [1].Hantunya [randomhantunya].hantuname);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_ATTACK, Golongannya [1].Hantunya [randomhantunya].attack.ToString());
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_DEFENSE, Golongannya [1].Hantunya [randomhantunya].defense.ToString());
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_HP, Golongannya [1].Hantunya [randomhantunya].hp);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_MODE, Golongannya [1].Hantunya [randomhantunya].typeS);
				}
			}
			if (randomgolongan == 2) {
				var monsterrarity = UnityEngine.Random.value;
				if (monsterrarity > 0.25f) {
					int randomhantunya = UnityEngine.Random.Range (0, 2);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_FILE, Golongannya [2].Hantunya [randomhantunya].hantuname);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_ATTACK, Golongannya [2].Hantunya [randomhantunya].attack.ToString());
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_DEFENSE, Golongannya [2].Hantunya [randomhantunya].defense.ToString());
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_HP, Golongannya [2].Hantunya [randomhantunya].hp);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_MODE, Golongannya [2].Hantunya [randomhantunya].typeS);
				} else if (monsterrarity < 0.25f && monsterrarity > 0.1f) {
					int randomhantunya = UnityEngine.Random.Range (1, 3);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_FILE, Golongannya [2].Hantunya [randomhantunya].hantuname);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_ATTACK, Golongannya [2].Hantunya [randomhantunya].attack.ToString());
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_DEFENSE, Golongannya [2].Hantunya [randomhantunya].defense.ToString());
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_HP, Golongannya [2].Hantunya [randomhantunya].hp);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_MODE, Golongannya [2].Hantunya [randomhantunya].typeS);

				} else if (monsterrarity < 0.05f) {
					int randomhantunya = 4;
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_FILE, Golongannya [2].Hantunya [randomhantunya].hantuname);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_ATTACK, Golongannya [2].Hantunya [randomhantunya].attack.ToString());
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_DEFENSE, Golongannya [2].Hantunya [randomhantunya].defense.ToString());
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_HP, Golongannya [2].Hantunya [randomhantunya].hp);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_MODE, Golongannya [2].Hantunya [randomhantunya].typeS);
				}
			}
			if (randomgolongan == 3) {
				var monsterrarity = UnityEngine.Random.value;
				if (monsterrarity > 0.25f) {
					int randomhantunya = UnityEngine.Random.Range (0, 2);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_FILE, Golongannya [3].Hantunya [randomhantunya].hantuname);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_ATTACK, Golongannya [3].Hantunya [randomhantunya].attack.ToString());
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_DEFENSE, Golongannya [3].Hantunya [randomhantunya].defense.ToString());
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_HP, Golongannya [3].Hantunya [randomhantunya].hp);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_MODE, Golongannya [3].Hantunya [randomhantunya].typeS);
				} else if (monsterrarity < 0.25f && monsterrarity > 0.1f) {
					int randomhantunya = UnityEngine.Random.Range (1, 3);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_FILE, Golongannya [3].Hantunya [randomhantunya].hantuname);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_ATTACK, Golongannya [3].Hantunya [randomhantunya].attack.ToString());
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_DEFENSE, Golongannya [3].Hantunya [randomhantunya].defense.ToString());
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_HP, Golongannya [3].Hantunya [randomhantunya].hp);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_MODE, Golongannya [3].Hantunya [randomhantunya].typeS);

				} else if (monsterrarity < 0.05f) {
					int randomhantunya = 4;
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_FILE, Golongannya [3].Hantunya [randomhantunya].hantuname);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_ATTACK, Golongannya [3].Hantunya [randomhantunya].attack.ToString());
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_DEFENSE, Golongannya [3].Hantunya [randomhantunya].defense.ToString());
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_HP, Golongannya [3].Hantunya [randomhantunya].hp);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_MODE, Golongannya [3].Hantunya [randomhantunya].typeS);
				}
			}
			if (randomgolongan == 4) {
				var monsterrarity = UnityEngine.Random.value;
				if (monsterrarity > 0.25f) {
					int randomhantunya = UnityEngine.Random.Range (0, 2);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_FILE, Golongannya [4].Hantunya [randomhantunya].hantuname);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_ATTACK, Golongannya [4].Hantunya [randomhantunya].attack.ToString());
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_DEFENSE, Golongannya [4].Hantunya [randomhantunya].defense.ToString());
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_HP, Golongannya [4].Hantunya [randomhantunya].hp);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_MODE, Golongannya [4].Hantunya [randomhantunya].typeS);
				} else if (monsterrarity < 0.25f && monsterrarity > 0.1f) {
					int randomhantunya = UnityEngine.Random.Range (1, 3);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_FILE, Golongannya [4].Hantunya [randomhantunya].hantuname);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_ATTACK, Golongannya [4].Hantunya [randomhantunya].attack.ToString());
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_DEFENSE, Golongannya [4].Hantunya [randomhantunya].defense.ToString());
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_HP, Golongannya [4].Hantunya [randomhantunya].hp);

				} else if (monsterrarity < 0.05f) {
					int randomhantunya = 4;
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_FILE, Golongannya [4].Hantunya [randomhantunya].hantuname);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_ATTACK, Golongannya [4].Hantunya [randomhantunya].attack.ToString());
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_DEFENSE, Golongannya [4].Hantunya [randomhantunya].defense.ToString());
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_HP, Golongannya [4].Hantunya [randomhantunya].hp);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_MODE, Golongannya [4].Hantunya [randomhantunya].typeS);
				}
			}
			if (PlayerPrefs.GetString (Link.POS_1_CHAR_1_FILE).Contains ("Fire")) {
				PlayerPrefs.SetString (Link.POS_1_CHAR_1_ELEMENT, "Fire");
			}
			if (PlayerPrefs.GetString (Link.POS_1_CHAR_1_FILE).Contains ("Water")) {
				PlayerPrefs.SetString (Link.POS_1_CHAR_1_ELEMENT, "Water");
			}
			if (PlayerPrefs.GetString (Link.POS_1_CHAR_1_FILE).Contains ("Wind")) {
				PlayerPrefs.SetString (Link.POS_1_CHAR_1_ELEMENT, "Wind");
			}
            //darah monsterburu
            //			PlayerPrefs.SetString (Link.POS_1_CHAR_1_ATTACK, "500");//401 //483 //1248
            //			PlayerPrefs.SetString (Link.POS_1_CHAR_1_DEFENSE, "100");
            //			PlayerPrefs.SetString (Link.POS_1_CHAR_1_HP, "300");
            var hantuburuname = PlayerPrefs.GetString(Link.POS_1_CHAR_1_FILE);
            if (hantuburuname.Contains('_'))
            {
                int index = hantuburuname.IndexOf('_');
                string result = hantuburuname.Substring(0, index);
                Musuh1.transform.Find("backname").transform.Find("Namegreen").transform.Find("Name").GetComponent<Text>().text = result;
            }
           
            Musuh1.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon_charLama/" + PlayerPrefs.GetString(Link.POS_1_CHAR_1_FILE));
          
            Musuh1.transform.Find("Level").GetComponent<Text>().text = "1";
            var type = PlayerPrefs.GetString(Link.POS_1_CHAR_1_ELEMENT);
            if (type == "Fire")
            {
                Musuh1.transform.Find("backname").transform.Find("Fire").gameObject.SetActive(true);
                Musuh1.transform.Find("backname").transform.Find("Water").gameObject.SetActive(false);
                Musuh1.transform.Find("backname").transform.Find("Wind").gameObject.SetActive(false);
            }
            else if (type == "Water")
            {
                Musuh1.transform.Find("backname").transform.Find("Fire").gameObject.SetActive(false);
                Musuh1.transform.Find("backname").transform.Find("Water").gameObject.SetActive(true);
                Musuh1.transform.Find("backname").transform.Find("Wind").gameObject.SetActive(false);
            }
            else {
                Musuh1.transform.Find("backname").transform.Find("Fire").gameObject.SetActive(false);
                Musuh1.transform.Find("backname").transform.Find("Water").gameObject.SetActive(false);
                Musuh1.transform.Find("backname").transform.Find("Wind").gameObject.SetActive(true);
            }

           
			Debug.Log (PlayerPrefs.GetString (Link.POS_1_CHAR_1_FILE));

		
	}
	}
	public void LineUpButton2Click () {
		if (pil2 == 0) {

		} 
		else 
		{
			pil2 = 0;
			select2.SetActive (false);
			LineUp2.GetComponent<Image> ().sprite = kosong;
			LineUpApi2.sprite =  kosong;
			Selection2.GetComponent<Image> ().sprite = kosong;
			Selection2.transform.Find ("backname").transform.Find ("Namegreen").transform.Find ("Name").GetComponent<Text> ().text = "";
			Selection2.transform.Find ("Level").GetComponent<Text> ().text = "";
			//CarInformation ci = GameObject.Find (PlayerPrefs.GetString ("CarPil2")).GetComponent<CarInformation> ();
			Selection2.transform.Find ("BSpilih").transform.Find ("bintang1").gameObject.SetActive (false);
			Selection2.transform.Find ("BSpilih").transform.Find ("bintang2").gameObject.SetActive (false);
			Selection2.transform.Find ("BSpilih").transform.Find ("bintang3").gameObject.SetActive (false);
			Selection2.transform.Find ("BSpilih").transform.Find ("bintang4").gameObject.SetActive (false);
			Selection2.transform.Find ("BSpilih").transform.Find ("bintang5").gameObject.SetActive (false);
			//ci.sudah = false;
			//ci.SelectionBox.SetActive (false);
			sudah3 = false;
			selection2.GetComponent<PilihCharacterItem> ().sudah = false;

			PlayerPrefs.SetString ("CarPil2", "kosong");
			StartNya.SetActive (false);
		}

	}

	public void LineUpButton3Click () {
		if (pil3 == 0) {

		} else {
			pil3 = 0;
			select3.SetActive (false);
			LineUp3.GetComponent<Image> ().sprite =  kosong;
			Selection3.GetComponent<Image> ().sprite = kosong;
			Selection3.transform.Find ("backname").transform.Find ("Namegreen").transform.Find ("Name").GetComponent<Text> ().text = "";
			Selection3.transform.Find ("Level").GetComponent<Text> ().text = "";
			//CarInformation ci = GameObject.Find (PlayerPrefs.GetString ("CarPil3")).GetComponent<CarInformation> ();

			//ci.sudah = false;
			//ci.SelectionBox.SetActive (false);
			Selection3.transform.Find ("BSpilih").transform.Find ("bintang1").gameObject.SetActive (false);
			Selection3.transform.Find ("BSpilih").transform.Find ("bintang2").gameObject.SetActive (false);
			Selection3.transform.Find ("BSpilih").transform.Find ("bintang3").gameObject.SetActive (false);
			Selection3.transform.Find ("BSpilih").transform.Find ("bintang4").gameObject.SetActive (false);
			Selection3.transform.Find ("BSpilih").transform.Find ("bintang5").gameObject.SetActive (false);
			selection3.GetComponent<PilihCharacterItem> ().sudah = false;

			sudah3 = false;
			LineUpApi3.sprite =  kosong;
			PlayerPrefs.SetString ("CarPil3", "kosong");
			StartNya.SetActive (false);
		}

	}

	void Update () {
		
		
		if (pil1 == 1 && pil2 == 1 && pil3 == 1 && sudah3 == false) {
			
			StartNya.gameObject.SetActive (true);

		} 
		//waiting time findmatch
			if ((PlayerPrefs.GetString (Link.JENIS) != "SINGLE") && wait==true && Application.loadedLevelName!="PilihCharacterDefense") {
				waitTime += Time.fixedDeltaTime;
				if (waitTime > 180f) {
				
					 win.SetActive (true);
				loading.SetActive (false);
				}
			}

		}

	//application force close or quit
	void OnApplicationPause(){
		if ((PlayerPrefs.GetString (Link.JENIS) != "SINGLE")) {
		//	SceneManager.LoadScene ("Arena");
		}
		//decrease AP
	}
	void OnApplicationQuit(){

	}
	public void Canceling(){
		SceneManager.LoadScene ("Arena");
	}

	public void OnStartClick () {
		//testing
//		PlayerPrefs.SetString (Link.POS_1_CHAR_1_FILE, "Lembuswana_Water");
//		PlayerPrefs.SetString (Link.POS_1_CHAR_2_FILE, "Mukarata_Fire");
//		PlayerPrefs.SetString (Link.POS_1_CHAR_3_FILE, "SundelBolong_Wind");
//		PlayerPrefs.SetString (Link.POS_1_CHAR_1_ELEMENT, "Water");
//		PlayerPrefs.SetString (Link.POS_1_CHAR_2_ELEMENT, "Fire");
//		PlayerPrefs.SetString (Link.POS_1_CHAR_3_ELEMENT, "Wind");
		// testing

		wait = true;

		StartNya.SetActive (false);

		formKirimPilihanCharacter.AddField (Link.ID, PlayerPrefs.GetString(Link.ID));


		formKirimPilihanCharacter.AddField ("car1", PlayerPrefs.GetString(Link.CHAR_1_FILE));
		formKirimPilihanCharacter.AddField ("car2", PlayerPrefs.GetString(Link.CHAR_2_FILE));
		formKirimPilihanCharacter.AddField ("car3", PlayerPrefs.GetString(Link.CHAR_3_FILE));

		formKirimPilihanCharacter.AddField ("car1ID", PlayerPrefs.GetString(Link.CHAR_1_ID));
		formKirimPilihanCharacter.AddField ("car2ID", PlayerPrefs.GetString(Link.CHAR_2_ID));
		formKirimPilihanCharacter.AddField ("car3ID", PlayerPrefs.GetString(Link.CHAR_3_ID));


		sudah3 = true;



		if (PlayerPrefs.GetString (Link.JENIS) == "SINGLE") {


			PlayerPrefs.SetString (Link.POS_2_CHAR_1_FILE, PlayerPrefs.GetString(Link.CHAR_1_FILE));
			PlayerPrefs.SetString (Link.POS_2_CHAR_1_ATTACK, PlayerPrefs.GetString(Link.CHAR_1_ATTACK));
			PlayerPrefs.SetString (Link.POS_2_CHAR_1_DEFENSE, PlayerPrefs.GetString(Link.CHAR_1_DEFENSE));
			PlayerPrefs.SetString (Link.POS_2_CHAR_1_HP, PlayerPrefs.GetString(Link.CHAR_1_HP));
			PlayerPrefs.SetString (Link.POS_2_CHAR_1_ELEMENT, PlayerPrefs.GetString(Link.CHAR_1_ELEMENT));

			PlayerPrefs.SetString (Link.POS_2_CHAR_2_FILE, PlayerPrefs.GetString(Link.CHAR_2_FILE));
			PlayerPrefs.SetString (Link.POS_2_CHAR_2_ATTACK, PlayerPrefs.GetString(Link.CHAR_2_ATTACK));
			PlayerPrefs.SetString (Link.POS_2_CHAR_2_DEFENSE, PlayerPrefs.GetString(Link.CHAR_2_DEFENSE));
			PlayerPrefs.SetString (Link.POS_2_CHAR_2_HP, PlayerPrefs.GetString(Link.CHAR_2_HP));
			PlayerPrefs.SetString (Link.POS_2_CHAR_2_ELEMENT, PlayerPrefs.GetString(Link.CHAR_2_ELEMENT));

			PlayerPrefs.SetString (Link.POS_2_CHAR_3_FILE, PlayerPrefs.GetString(Link.CHAR_3_FILE));
			PlayerPrefs.SetString (Link.POS_2_CHAR_3_ATTACK, PlayerPrefs.GetString(Link.CHAR_3_ATTACK));
			PlayerPrefs.SetString (Link.POS_2_CHAR_3_DEFENSE, PlayerPrefs.GetString(Link.CHAR_3_DEFENSE));
			PlayerPrefs.SetString (Link.POS_2_CHAR_3_HP, PlayerPrefs.GetString(Link.CHAR_3_HP));
			PlayerPrefs.SetString (Link.POS_2_CHAR_3_ELEMENT, PlayerPrefs.GetString(Link.CHAR_3_ELEMENT));


			PlayerPrefs.SetString (Link.POS_2_CHAR_1_ID, PlayerPrefs.GetString(Link.CHAR_1_ID));
			PlayerPrefs.SetString (Link.POS_2_CHAR_2_ID, PlayerPrefs.GetString(Link.CHAR_2_ID));
			PlayerPrefs.SetString (Link.POS_2_CHAR_3_ID, PlayerPrefs.GetString(Link.CHAR_3_ID));

			PlayerPrefs.SetString (Link.POS_2_CHAR_1_GRADE, PlayerPrefs.GetString(Link.CHAR_1_GRADE));
			PlayerPrefs.SetString (Link.POS_2_CHAR_2_GRADE, PlayerPrefs.GetString(Link.CHAR_2_GRADE));
			PlayerPrefs.SetString (Link.POS_2_CHAR_3_GRADE, PlayerPrefs.GetString(Link.CHAR_3_GRADE));

			PlayerPrefs.SetString (Link.POS_2_CHAR_1_LEVEL, PlayerPrefs.GetString(Link.CHAR_1_LEVEL));
			PlayerPrefs.SetString (Link.POS_2_CHAR_2_LEVEL, PlayerPrefs.GetString(Link.CHAR_2_LEVEL));
			PlayerPrefs.SetString (Link.POS_2_CHAR_3_LEVEL, PlayerPrefs.GetString(Link.CHAR_3_LEVEL));

			StartCoroutine (vs ());
		} 

		else {
			StartCoroutine (pilihanCharacter());
		}

	}

	public void OnSaveClick () {
//		Debug.Log (PlayerPrefs.GetString (Link.ID)+ PlayerPrefs.GetString("Hantudef1")+ PlayerPrefs.GetString("Hantudef2")+ PlayerPrefs.GetString("Hantudef3"));
		StartNya.SetActive (false);
		formsimpancharacter.AddField ("PLAYER_ID", PlayerPrefs.GetString(Link.ID));
		formsimpancharacter.AddField ("CHAR_1", PlayerPrefs.GetString("Hantudef1"));
		formsimpancharacter.AddField ("CHAR_2", PlayerPrefs.GetString("Hantudef2"));
		formsimpancharacter.AddField ("CHAR_3", PlayerPrefs.GetString("Hantudef3"));
		sudah3 = true;




		StartCoroutine (SimpanCharacter());


	}
	private IEnumerator startClick() {
		yield return new WaitForSeconds (1);

	}
	private IEnumerator SimpanCharacter()
	{
		yield return new WaitForSeconds (1f);

		string url = Link.url + "update_hantu_defense";
		WWW www = new WWW(url,formsimpancharacter);
		yield return www;
		var jsonString = JSON.Parse (www.text);
		if (www.error == null) {
			Debug.Log (www.text);
			PlayerPrefs.SetString ("HD1", jsonString ["hantudef1"]);
			PlayerPrefs.SetString ("HD2", jsonString ["hantudef2"]);
			PlayerPrefs.SetString ("HD3", jsonString ["hantudef3"]);

			yield return new WaitForSeconds (1f);
			SceneManagerHelper.LoadScene ("Arena");
//			var jsonString = JSON.Parse (www.text);
//			int a = 0;
//
//			for (int i = 0; i < int.Parse (jsonString ["code"]); i++) {
//				a++;
			}

//			if (a == 1) {
//				loading.SetActive (true);
//				Debug.Log ("TES");
//				//StartCoroutine (onCoroutine());
//			}
//			else {
//				Debug.Log ("fail");
//			}
//
//		} 
		else {
			Debug.Log ("fail");
		}
	}

	private IEnumerator locationplayed()
	{
		

		string url = Link.url + "locationplayed";
		WWWForm form = new WWWForm ();
		form.AddField (Link.ID, PlayerPrefs.GetString(Link.ID));
		form.AddField ("IDHunterData", PlayerPrefs.GetString ("ID_bermain"));
		WWW www = new WWW(url,form);
		yield return www;
		var jsonString = JSON.Parse (www.text);
		if (www.error == null) {
			Debug.Log (www.text);
			if (int.Parse (jsonString ["code"]) == 1) {
				Debug.Log ("Success");
			} else {
				Debug.Log ("Failed");
			}
	
		}
		else {
			Debug.Log ("no connection");
		}
	}

	private IEnumerator pilihanCharacter()
	{
		
		string url = Link.url + "create_pilihan_character";
		WWW www = new WWW(url,formKirimPilihanCharacter);
		yield return www;
		if (www.error == null) {
			Debug.Log (www.text);
			var jsonString = JSON.Parse (www.text);
			int a = 0;

			for (int i = 0; i < int.Parse (jsonString ["code"]); i++) {
				a++;
			}

			if (a == 1) {
				loading.SetActive (true);
				Debug.Log ("TES");
				StartCoroutine (onCoroutine());
			} else {
				Debug.Log ("fail");
			}

		} 
		else {
			Debug.Log ("fail");
		}
	}
		


	private IEnumerator findMatch2()
	{
		string url = Link.url + "cek_pilih_character";
		WWWForm form = new WWWForm ();
		form.AddField ("id_device", android_id);
		form.AddField ("room_name", PlayerPrefs.GetString ("RoomName"));
		WWW www = new WWW(url,form);
		yield return www;
		if (www.error == null) {

			var jsonString = JSON.Parse (www.text);
			int a = 0;

			PlayerPrefs.SetString ("SIMPAN", jsonString ["data"]);

			Debug.Log (PlayerPrefs.GetString("SIMPAN"));

			if (PlayerPrefs.GetString("SIMPAN") != "1") {

				Debug.Log ("TES");

				if (PlayerPrefs.GetString ("SIMPAN") != "0") {
					Debug.Log ("TES 2");
				
					//POSITION 1
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_FILE, jsonString ["data"] [0] ["Hantu1"] ["HantuFile"]);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_ATTACK, jsonString ["data"] [0] ["Hantu1"] ["HantuAttack"]);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_DEFENSE, jsonString ["data"] [0] ["Hantu1"] ["HantuDefense"]);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_HP, jsonString ["data"] [0] ["Hantu1"] ["HantuStamina"]);
					PlayerPrefs.SetString (Link.POS_1_CHAR_1_ELEMENT,jsonString ["data"] [0] ["Hantu1"] ["HantuType"]);

					PlayerPrefs.SetString (Link.POS_1_CHAR_2_FILE, jsonString ["data"] [0] ["Hantu2"] ["HantuFile"]);
					PlayerPrefs.SetString (Link.POS_1_CHAR_2_ATTACK, jsonString ["data"] [0] ["Hantu2"] ["HantuAttack"]);
					PlayerPrefs.SetString (Link.POS_1_CHAR_2_DEFENSE, jsonString ["data"] [0] ["Hantu2"] ["HantuDefense"]);
					PlayerPrefs.SetString (Link.POS_1_CHAR_2_HP, jsonString ["data"] [0] ["Hantu2"] ["HantuStamina"]);
					PlayerPrefs.SetString (Link.POS_1_CHAR_2_ELEMENT, jsonString ["data"] [0] ["Hantu2"] ["HantuType"]);

					PlayerPrefs.SetString (Link.POS_1_CHAR_3_FILE, jsonString ["data"] [0] ["Hantu3"] ["HantuFile"]);
					PlayerPrefs.SetString (Link.POS_1_CHAR_3_ATTACK, jsonString ["data"] [0] ["Hantu3"] ["HantuAttack"]);
					PlayerPrefs.SetString (Link.POS_1_CHAR_3_DEFENSE, jsonString ["data"] [0] ["Hantu3"] ["HantuDefense"]);
					PlayerPrefs.SetString (Link.POS_1_CHAR_3_HP, jsonString ["data"] [0] ["Hantu3"] ["HantuStamina"]);
					PlayerPrefs.SetString (Link.POS_1_CHAR_3_ELEMENT, jsonString ["data"] [0] ["Hantu3"] ["HantuType"]);



					PlayerPrefs.SetString (Link.POS_1_CHAR_1_ID, jsonString ["data"] [0] ["Hantu1"] ["HantuPlayerID"]);
					PlayerPrefs.SetString (Link.POS_1_CHAR_2_ID, jsonString ["data"] [0] ["Hantu2"] ["HantuPlayerID"]);
					PlayerPrefs.SetString (Link.POS_1_CHAR_3_ID, jsonString ["data"] [0] ["Hantu3"] ["HantuPlayerID"]);

					PlayerPrefs.SetString (Link.POS_1_CHAR_1_GRADE, jsonString ["data"] [0] ["Hantu1"] ["HantuGrade"]);
					PlayerPrefs.SetString (Link.POS_1_CHAR_2_GRADE, jsonString ["data"] [0] ["Hantu2"] ["HantuGrade"]);
					PlayerPrefs.SetString (Link.POS_1_CHAR_3_GRADE, jsonString ["data"] [0] ["Hantu3"] ["HantuGrade"]);

					PlayerPrefs.SetString (Link.POS_1_CHAR_1_LEVEL, jsonString ["data"] [0] ["Hantu1"] ["HantuLevel"]);
					PlayerPrefs.SetString (Link.POS_1_CHAR_2_LEVEL, jsonString ["data"] [0] ["Hantu2"] ["HantuLevel"]);
					PlayerPrefs.SetString (Link.POS_1_CHAR_3_LEVEL, jsonString ["data"] [0] ["Hantu3"] ["HantuLevel"]);



					//POSITION 2
					PlayerPrefs.SetString (Link.POS_2_CHAR_1_FILE, jsonString ["data"] [1] ["Hantu1"] ["HantuFile"]);
					PlayerPrefs.SetString (Link.POS_2_CHAR_1_ATTACK, jsonString ["data"] [1] ["Hantu1"] ["HantuAttack"]);
					PlayerPrefs.SetString (Link.POS_2_CHAR_1_DEFENSE, jsonString ["data"] [1] ["Hantu1"] ["HantuDefense"]);
					PlayerPrefs.SetString (Link.POS_2_CHAR_1_HP, jsonString ["data"] [1] ["Hantu1"] ["HantuStamina"]);
					PlayerPrefs.SetString (Link.POS_2_CHAR_1_ELEMENT, jsonString ["data"] [1] ["Hantu1"] ["HantuType"]);


					PlayerPrefs.SetString (Link.POS_2_CHAR_2_FILE, jsonString ["data"] [1] ["Hantu2"] ["HantuFile"]);
					PlayerPrefs.SetString (Link.POS_2_CHAR_2_ATTACK, jsonString ["data"] [1] ["Hantu2"] ["HantuAttack"]);
					PlayerPrefs.SetString (Link.POS_2_CHAR_2_DEFENSE, jsonString ["data"] [1] ["Hantu2"] ["HantuDefense"]);
					PlayerPrefs.SetString (Link.POS_2_CHAR_2_HP, jsonString ["data"] [1] ["Hantu2"] ["HantuStamina"]);
					PlayerPrefs.SetString (Link.POS_2_CHAR_2_ELEMENT,  jsonString ["data"] [1] ["Hantu2"] ["HantuType"]);



					PlayerPrefs.SetString (Link.POS_2_CHAR_3_FILE, jsonString ["data"] [1] ["Hantu3"] ["HantuFile"]);
					PlayerPrefs.SetString (Link.POS_2_CHAR_3_ATTACK, jsonString ["data"] [1] ["Hantu3"] ["HantuAttack"]);
					PlayerPrefs.SetString (Link.POS_2_CHAR_3_DEFENSE, jsonString ["data"] [1] ["Hantu3"] ["HantuDefense"]);
					PlayerPrefs.SetString (Link.POS_2_CHAR_3_HP, jsonString ["data"] [1] ["Hantu3"] ["HantuStamina"]);
					PlayerPrefs.SetString (Link.POS_2_CHAR_3_ELEMENT, jsonString ["data"] [1] ["Hantu3"] ["HantuType"]);



					PlayerPrefs.SetString (Link.POS_2_CHAR_1_ID, jsonString ["data"] [1] ["Hantu1"] ["HantuPlayerID"]);
					PlayerPrefs.SetString (Link.POS_2_CHAR_2_ID, jsonString ["data"] [1] ["Hantu2"] ["HantuPlayerID"]);
					PlayerPrefs.SetString (Link.POS_2_CHAR_3_ID, jsonString ["data"] [1] ["Hantu3"] ["HantuPlayerID"]);

					PlayerPrefs.SetString (Link.POS_2_CHAR_1_GRADE, jsonString ["data"] [1] ["Hantu1"] ["HantuGrade"]);
					PlayerPrefs.SetString (Link.POS_2_CHAR_2_GRADE, jsonString ["data"] [1] ["Hantu2"] ["HantuGrade"]);
					PlayerPrefs.SetString (Link.POS_2_CHAR_3_GRADE, jsonString ["data"] [1] ["Hantu3"] ["HantuGrade"]);

					PlayerPrefs.SetString (Link.POS_2_CHAR_1_LEVEL, jsonString ["data"] [1] ["Hantu1"] ["HantuLevel"]);
					PlayerPrefs.SetString (Link.POS_2_CHAR_2_LEVEL, jsonString ["data"] [1] ["Hantu2"] ["HantuLevel"]);
					PlayerPrefs.SetString (Link.POS_2_CHAR_3_LEVEL, jsonString ["data"] [1] ["Hantu3"] ["HantuLevel"]);




					StartCoroutine (vs ());
				}
			} 
			else {
				
				Debug.Log (a.ToString());
			}

		} else {
			Debug.Log ("fail");
		}
	}
		
	     
	IEnumerator onCoroutine(){
		while(true) 
		{ 
			StartCoroutine (findMatch2());
			yield return new WaitForSeconds(5f);
		}
	}



	IEnumerator vs () {
		vsParent.SetActive (true);

		vsParent.transform.Find ("pos1_car1").GetComponent<Image> ().sprite = Resources.Load<Sprite>("icon_char_Maps/" + PlayerPrefs.GetString(Link.POS_1_CHAR_1_FILE));
		vsParent.transform.Find ("pos1_car2").GetComponent<Image> ().sprite = Resources.Load<Sprite>("icon_char_Maps/" + PlayerPrefs.GetString(Link.POS_1_CHAR_2_FILE));
		vsParent.transform.Find ("pos1_car3").GetComponent<Image> ().sprite = Resources.Load<Sprite>("icon_char_Maps/" + PlayerPrefs.GetString(Link.POS_1_CHAR_3_FILE));
		vsParent.transform.Find ("pos2_car1").GetComponent<Image> ().sprite = Resources.Load<Sprite>("icon_char_Maps/" + PlayerPrefs.GetString(Link.POS_2_CHAR_1_FILE));
		vsParent.transform.Find ("pos2_car2").GetComponent<Image> ().sprite = Resources.Load<Sprite>("icon_char_Maps/" + PlayerPrefs.GetString(Link.POS_2_CHAR_2_FILE));
		vsParent.transform.Find ("pos2_car3").GetComponent<Image> ().sprite = Resources.Load<Sprite>("icon_char_Maps/" + PlayerPrefs.GetString(Link.POS_2_CHAR_3_FILE));
		if (PlayerPrefs.GetString ("berburu") == "ya") {
			vsParent.transform.Find ("pos1_car2").GetComponent<Image> ().sprite = Resources.Load<Sprite>("icon_char_Maps/" + PlayerPrefs.GetString (Link.POS_1_CHAR_1_FILE));
		}
		else if (PlayerPrefs.GetString ("PLAY_TUTORIAL") == "TRUE") {
//			Musuh1.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon_charLama/" + PlayerPrefs.GetString(Link.POS_1_CHAR_1_FILE));
            vsParent.transform.Find ("pos1_car1").gameObject.SetActive (false);
			vsParent.transform.Find ("pos1_car3").gameObject.SetActive (false);
			vsParent.transform.Find ("pos1_car2").GetComponent<Image> ().sprite = Resources.Load<Sprite>("icon_char_Maps/" + PlayerPrefs.GetString (Link.POS_1_CHAR_1_FILE));
		}


		yield return new WaitForSeconds (3);
		vsParent.SetActive (false);
		Loadingscreen.GetComponent<SceneLoader> ().LoadingScreeen ();
		//Application.LoadLevel (Link.Game);



	}




}
