using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System.Collections;


public class PilihCharacterItem : MonoBehaviour {

	public Image icon;

	public string PlayerHantuId;

	public string Grade;
	public string LevelString,targetnextlevel,monstercurrentexp;
	public Text Level;
	public GameObject bintang1stats,bintang2stats,bintang3stats,bintang4stats,bintang5stats,selected;

	public string hantuId;
	public string file;
	public string name;
	public string type;
	public string typeS;

	public int attack;
	public int defense;
	public int stamina;


	public bool sudah = false;
	//public bool bgpos1, bgpos2, bgpos3=false;
	public PilihCharacter cc;

	void Start () {
		cc = GameObject.Find ("PilihCharacter").GetComponent<PilihCharacter>();
		}

	public void Update(){
		int test;
		var angka = int.TryParse( Grade,out test);
		if (test != null || test != 0) {
			switch (test) {

			case 1:
				bintang1stats.SetActive (true);
				bintang2stats.SetActive (false);
				bintang3stats.SetActive (false);
				bintang4stats.SetActive (false);
				bintang5stats.SetActive (false);
				break;
			case 2:
				bintang2stats.SetActive (true);
				bintang1stats.SetActive (false);
				bintang3stats.SetActive (false);
				bintang4stats.SetActive (false);
				bintang5stats.SetActive (false);
				break;
			case 3:
				bintang3stats.SetActive (true);
				bintang1stats.SetActive (false);
				bintang2stats.SetActive (false);
				bintang4stats.SetActive (false);
				bintang5stats.SetActive (false);
				break;
			case 4:
				bintang4stats.SetActive (true);
				bintang1stats.SetActive (false);
				bintang2stats.SetActive (false);
				bintang3stats.SetActive (false);
				bintang5stats.SetActive (false);
				break;
			case 5:
				bintang5stats.SetActive (true);
				bintang1stats.SetActive (false);
				bintang2stats.SetActive (false);
				bintang3stats.SetActive (false);
				bintang4stats.SetActive (false);
				break;

			}
		}
		if (cc.pil1 == 1 && cc.pil2 == 1 && cc.pil3 == 1 && sudah == false) {
			gameObject.GetComponent<Button> ().interactable = false;
		} else {
			gameObject.GetComponent<Button> ().interactable = true;
		}

	}
	public void OnClick () {

		if (!sudah) {
			sudah = true;
			//Debug.Log ("Hantu Id : " + hantuId);
			//Debug.Log ("player Hantu Id : " + PlayerHantuId);



			selected.SetActive (true);
			if (cc.pil1 == 0) {
				cc.select1 = selected;
				cc.pil1 = 1;
				PlayerPrefs.SetString ("Hantudef1", PlayerHantuId);
				StartCoroutine(GetItemSlotHantu (PlayerHantuId));

				PlayerPrefs.SetString (Link.CHAR_1_ID, PlayerHantuId);
				PlayerPrefs.SetString (Link.CHAR_1_GRADE, Grade);
				PlayerPrefs.SetString (Link.CHAR_1_LEVEL, LevelString);
				PlayerPrefs.SetString (Link.CHAR_1_ELEMENT, type);
				PlayerPrefs.SetString (Link.CHAR_1_MODE, typeS);
				PlayerPrefs.SetString (Link.CHAR_1_FILE, file);
				PlayerPrefs.SetString (Link.CHAR_1_ATTACK, attack.ToString ());
				PlayerPrefs.SetString (Link.CHAR_1_DEFENSE, defense.ToString ());
				PlayerPrefs.SetString (Link.CHAR_1_HP, stamina.ToString ());
				PlayerPrefs.SetString (Link.CHAR_1_TARGETNL, targetnextlevel);
				PlayerPrefs.SetString (Link.CHAR_1_MONSTEREXP, monstercurrentexp);

				cc.LineUp.transform.Find ("Pos1").GetComponent<Image> ().sprite = icon.sprite;
				cc.LineUp.transform.Find ("Api1").GetComponent<Image> ().sprite = cc.Api;
				cc.selection1 = this.gameObject;
				cc.Selection1.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("icon_charLama/" + file);
				cc.Selection1.transform.Find ("backname").transform.Find ("Namegreen").transform.Find ("Name").GetComponent<Text> ().text = name;
				cc.Selection1.transform.Find ("Level").GetComponent<Text> ().text = Level.text;
				if (type == "Fire") {
					cc.Selection1.transform.Find ("backname").transform.Find ("Fire").gameObject.SetActive (true);
					cc.Selection1.transform.Find ("backname").transform.Find("Water").gameObject.SetActive (false);
					cc.Selection1.transform.Find ("backname").transform.Find ("Wind").gameObject.SetActive (false);
				} else if (type == "Water") {
					cc.Selection1.transform.Find ("backname").transform.Find ("Fire").gameObject.SetActive (false);
					cc.Selection1.transform.Find ("backname").transform.Find ("Water").gameObject.SetActive (true);
					cc.Selection1.transform.Find ("backname").transform.Find ("Wind").gameObject.SetActive (false);
				} else {
					cc.Selection1.transform.Find ("backname").transform.Find ("Fire").gameObject.SetActive (false);
					cc.Selection1.transform.Find ("backname").transform.Find("Water").gameObject.SetActive (false);
					cc.Selection1.transform.Find ("backname").transform.Find ("Wind").gameObject.SetActive (true);
				}

				int test;
				var angka = int.TryParse( Grade,out test);
				if (test != null || test != 0) {
					switch (test) {

					case 1:
						cc.Selection1.transform.Find ("BSpilih").transform.Find ("bintang1").gameObject.SetActive (true);
						cc.Selection1.transform.Find ("BSpilih").transform.Find ("bintang2").gameObject.SetActive (false);
						cc.Selection1.transform.Find ("BSpilih").transform.Find ("bintang3").gameObject.SetActive (false);
						cc.Selection1.transform.Find ("BSpilih").transform.Find ("bintang4").gameObject.SetActive (false);
						cc.Selection1.transform.Find ("BSpilih").transform.Find ("bintang5").gameObject.SetActive (false);
						break;
					case 2:
						cc.Selection1.transform.Find ("BSpilih").transform.Find ("bintang1").gameObject.SetActive (false);
						cc.Selection1.transform.Find ("BSpilih").transform.Find ("bintang2").gameObject.SetActive (true);
						cc.Selection1.transform.Find ("BSpilih").transform.Find ("bintang3").gameObject.SetActive (false);
						cc.Selection1.transform.Find ("BSpilih").transform.Find ("bintang4").gameObject.SetActive (false);
						cc.Selection1.transform.Find ("BSpilih").transform.Find ("bintang5").gameObject.SetActive (false);
						break;
					case 3:
						cc.Selection1.transform.Find ("BSpilih").transform.Find ("bintang1").gameObject.SetActive (false);
						cc.Selection1.transform.Find ("BSpilih").transform.Find ("bintang2").gameObject.SetActive (false);
						cc.Selection1.transform.Find ("BSpilih").transform.Find ("bintang3").gameObject.SetActive (true);
						cc.Selection1.transform.Find ("BSpilih").transform.Find ("bintang4").gameObject.SetActive (false);
						cc.Selection1.transform.Find ("BSpilih").transform.Find ("bintang5").gameObject.SetActive (false);
						break;
					case 4:
						cc.Selection1.transform.Find ("BSpilih").transform.Find ("bintang1").gameObject.SetActive (false);
						cc.Selection1.transform.Find ("BSpilih").transform.Find ("bintang2").gameObject.SetActive (false);
						cc.Selection1.transform.Find ("BSpilih").transform.Find ("bintang3").gameObject.SetActive (false);
						cc.Selection1.transform.Find ("BSpilih").transform.Find ("bintang4").gameObject.SetActive (true);
						cc.Selection1.transform.Find ("BSpilih").transform.Find ("bintang5").gameObject.SetActive (false);
						break;
					case 5:
						cc.Selection1.transform.Find ("BSpilih").transform.Find ("bintang1").gameObject.SetActive (false);
						cc.Selection1.transform.Find ("BSpilih").transform.Find ("bintang2").gameObject.SetActive (false);
						cc.Selection1.transform.Find ("BSpilih").transform.Find ("bintang3").gameObject.SetActive (false);
						cc.Selection1.transform.Find ("BSpilih").transform.Find ("bintang4").gameObject.SetActive (false);
						cc.Selection1.transform.Find ("BSpilih").transform.Find ("bintang5").gameObject.SetActive (true);
						break;

					}
				}
			} else if (cc.pil2 == 0) {
				cc.pil2 = 1;
				cc.select2 = selected;
				PlayerPrefs.SetString ("Hantudef2", PlayerHantuId);
				StartCoroutine(GetItemSlotHantu (PlayerHantuId));
				PlayerPrefs.SetString (Link.CHAR_2_ID, PlayerHantuId);
				PlayerPrefs.SetString (Link.CHAR_2_GRADE, Grade);
				PlayerPrefs.SetString (Link.CHAR_2_LEVEL, LevelString);
				PlayerPrefs.SetString (Link.CHAR_2_ELEMENT, type);
				PlayerPrefs.SetString (Link.CHAR_2_MODE, typeS);

				PlayerPrefs.SetString (Link.CHAR_2_FILE, file);
				PlayerPrefs.SetString (Link.CHAR_2_ATTACK, attack.ToString ());
				PlayerPrefs.SetString (Link.CHAR_2_DEFENSE, defense.ToString ());
				PlayerPrefs.SetString (Link.CHAR_2_HP, stamina.ToString ());
				PlayerPrefs.SetString (Link.CHAR_2_TARGETNL, targetnextlevel);
				PlayerPrefs.SetString (Link.CHAR_2_MONSTEREXP, monstercurrentexp);
				//PlayerPrefs.SetString (Link.CHAR_2_ID, PlayerHantuId);

				cc.LineUp.transform.Find ("Pos2").GetComponent<Image> ().sprite = icon.sprite;
				cc.LineUp.transform.Find ("Api2").GetComponent<Image> ().sprite = cc.Api;
				cc.selection2 = this.gameObject;
				cc.Selection2.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("icon_charLama/" + file);
				cc.Selection2.transform.Find ("backname").transform.Find ("Namegreen").transform.Find ("Name").GetComponent<Text> ().text = name;
				cc.Selection2.transform.Find ("Level").GetComponent<Text> ().text =Level.text;
				if (type == "Fire") {
					cc.Selection2.transform.Find ("backname").transform.Find ("Fire").gameObject.SetActive (true);
					cc.Selection2.transform.Find ("backname").transform.Find ("Water").gameObject.SetActive (false);
					cc.Selection2.transform.Find ("backname").transform.Find ("Wind").gameObject.SetActive (false);
				} else if (type == "Water") {
					cc.Selection2.transform.Find ("backname").transform.Find ("Fire").gameObject.SetActive (false);
					cc.Selection2.transform.Find ("backname").transform.Find ("Water").gameObject.SetActive (true);
					cc.Selection2.transform.Find ("backname").transform.Find ("Wind").gameObject.SetActive (false);
				} else {
					cc.Selection2.transform.Find ("backname").transform.Find ("Fire").gameObject.SetActive (false);
					cc.Selection2.transform.Find ("backname").transform.Find ("Water").gameObject.SetActive (false);
					cc.Selection2.transform.Find ("backname").transform.Find ("Wind").gameObject.SetActive (true);
				}
				int test;
				var angka = int.TryParse( Grade,out test);
				if (test != null || test != 0) {
					switch (test) {

					case 1:
						cc.Selection2.transform.Find ("BSpilih").transform.Find ("bintang1").gameObject.SetActive (true);
						cc.Selection2.transform.Find ("BSpilih").transform.Find ("bintang2").gameObject.SetActive (false);
						cc.Selection2.transform.Find ("BSpilih").transform.Find ("bintang3").gameObject.SetActive (false);
						cc.Selection2.transform.Find ("BSpilih").transform.Find ("bintang4").gameObject.SetActive (false);
						cc.Selection2.transform.Find ("BSpilih").transform.Find ("bintang5").gameObject.SetActive (false);
						break;
					case 2:
						cc.Selection2.transform.Find ("BSpilih").transform.Find ("bintang1").gameObject.SetActive (false);
						cc.Selection2.transform.Find ("BSpilih").transform.Find ("bintang2").gameObject.SetActive (true);
						cc.Selection2.transform.Find ("BSpilih").transform.Find ("bintang3").gameObject.SetActive (false);
						cc.Selection2.transform.Find ("BSpilih").transform.Find ("bintang4").gameObject.SetActive (false);
						cc.Selection2.transform.Find ("BSpilih").transform.Find ("bintang5").gameObject.SetActive (false);
						break;
					case 3:
						cc.Selection2.transform.Find ("BSpilih").transform.Find ("bintang1").gameObject.SetActive (false);
						cc.Selection2.transform.Find ("BSpilih").transform.Find ("bintang2").gameObject.SetActive (false);
						cc.Selection2.transform.Find ("BSpilih").transform.Find ("bintang3").gameObject.SetActive (true);
						cc.Selection2.transform.Find ("BSpilih").transform.Find ("bintang4").gameObject.SetActive (false);
						cc.Selection2.transform.Find ("BSpilih").transform.Find ("bintang5").gameObject.SetActive (false);
						break;
					case 4:
						cc.Selection2.transform.Find ("BSpilih").transform.Find ("bintang1").gameObject.SetActive (false);
						cc.Selection2.transform.Find ("BSpilih").transform.Find ("bintang2").gameObject.SetActive (false);
						cc.Selection2.transform.Find ("BSpilih").transform.Find ("bintang3").gameObject.SetActive (false);
						cc.Selection2.transform.Find ("BSpilih").transform.Find ("bintang4").gameObject.SetActive (true);
						cc.Selection2.transform.Find ("BSpilih").transform.Find ("bintang5").gameObject.SetActive (false);
						break;
					case 5:
						cc.Selection2.transform.Find ("BSpilih").transform.Find ("bintang1").gameObject.SetActive (false);
						cc.Selection2.transform.Find ("BSpilih").transform.Find ("bintang2").gameObject.SetActive (false);
						cc.Selection2.transform.Find ("BSpilih").transform.Find ("bintang3").gameObject.SetActive (false);
						cc.Selection2.transform.Find ("BSpilih").transform.Find ("bintang4").gameObject.SetActive (false);
						cc.Selection2.transform.Find ("BSpilih").transform.Find ("bintang5").gameObject.SetActive (true);
						break;

					}
				}
			} else if (cc.pil3 == 0) {
				cc.pil3 = 1;
				cc.select3 = selected;
				PlayerPrefs.SetString ("Hantudef3", PlayerHantuId);
				StartCoroutine(GetItemSlotHantu (PlayerHantuId));
				PlayerPrefs.SetString (Link.CHAR_3_ID, PlayerHantuId);
				PlayerPrefs.SetString (Link.CHAR_3_GRADE, Grade);
				PlayerPrefs.SetString (Link.CHAR_3_LEVEL, LevelString);
				PlayerPrefs.SetString (Link.CHAR_3_ELEMENT, type);
				PlayerPrefs.SetString (Link.CHAR_3_MODE, typeS);

				PlayerPrefs.SetString (Link.CHAR_3_FILE, file);
				PlayerPrefs.SetString (Link.CHAR_3_ATTACK, attack.ToString ());
				PlayerPrefs.SetString (Link.CHAR_3_DEFENSE, defense.ToString ());
				PlayerPrefs.SetString (Link.CHAR_3_HP, stamina.ToString ());
				PlayerPrefs.SetString (Link.CHAR_3_TARGETNL, targetnextlevel);
				PlayerPrefs.SetString (Link.CHAR_3_MONSTEREXP, monstercurrentexp);
			//	PlayerPrefs.SetString (Link.CHAR_3_ID, PlayerHantuId);

				cc.LineUp.transform.Find ("Pos3").GetComponent<Image> ().sprite = icon.sprite;
				cc.LineUp.transform.Find ("Api3").GetComponent<Image> ().sprite = cc.Api;
				cc.selection3 = this.gameObject;
				cc.Selection3.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("icon_charLama/" + file);
				cc.Selection3.transform.Find ("backname").transform.Find ("Namegreen").transform.Find ("Name").GetComponent<Text> ().text = name;
				cc.Selection3.transform.Find ("Level").GetComponent<Text> ().text = Level.text;
				if (type == "Fire") {
					cc.Selection3.transform.Find ("backname").transform.Find ("Fire").gameObject.SetActive (true);
					cc.Selection3.transform.Find ("backname").transform.Find ("Water").gameObject.SetActive (false);
					cc.Selection3.transform.Find ("backname").transform.Find ("Wind").gameObject.SetActive (false);
				} else if (type == "Water") {
					cc.Selection3.transform.Find ("backname").transform.Find ("Fire").gameObject.SetActive (false);
					cc.Selection3.transform.Find ("backname").transform.Find ("Water").gameObject.SetActive (true);
					cc.Selection3.transform.Find ("backname").transform.Find ("Wind").gameObject.SetActive (false);
				} else {
					cc.Selection3.transform.Find ("backname").transform.Find ("Fire").gameObject.SetActive (false);
					cc.Selection3.transform.Find ("backname").transform.Find ("Water").gameObject.SetActive (false);
					cc.Selection3.transform.Find ("backname").transform.Find ("Wind").gameObject.SetActive (true);
				}
				int test;
				var angka = int.TryParse( Grade,out test);
				if (test != null || test != 0) {
					switch (test) {

					case 1:
						cc.Selection3.transform.Find ("BSpilih").transform.Find ("bintang1").gameObject.SetActive (true);
						cc.Selection3.transform.Find ("BSpilih").transform.Find ("bintang2").gameObject.SetActive (false);
						cc.Selection3.transform.Find ("BSpilih").transform.Find ("bintang3").gameObject.SetActive (false);
						cc.Selection3.transform.Find ("BSpilih").transform.Find ("bintang4").gameObject.SetActive (false);
						cc.Selection3.transform.Find ("BSpilih").transform.Find ("bintang5").gameObject.SetActive (false);
						break;
					case 2:
						cc.Selection3.transform.Find ("BSpilih").transform.Find ("bintang1").gameObject.SetActive (false);
						cc.Selection3.transform.Find ("BSpilih").transform.Find ("bintang2").gameObject.SetActive (true);
						cc.Selection3.transform.Find ("BSpilih").transform.Find ("bintang3").gameObject.SetActive (false);
						cc.Selection3.transform.Find ("BSpilih").transform.Find ("bintang4").gameObject.SetActive (false);
						cc.Selection3.transform.Find ("BSpilih").transform.Find ("bintang5").gameObject.SetActive (false);
						break;
					case 3:
						cc.Selection3.transform.Find ("BSpilih").transform.Find ("bintang1").gameObject.SetActive (false);
						cc.Selection3.transform.Find ("BSpilih").transform.Find ("bintang2").gameObject.SetActive (false);
						cc.Selection3.transform.Find ("BSpilih").transform.Find ("bintang3").gameObject.SetActive (true);
						cc.Selection3.transform.Find ("BSpilih").transform.Find ("bintang4").gameObject.SetActive (false);
						cc.Selection3.transform.Find ("BSpilih").transform.Find ("bintang5").gameObject.SetActive (false);
						break;
					case 4:
						cc.Selection3.transform.Find ("BSpilih").transform.Find ("bintang1").gameObject.SetActive (false);
						cc.Selection3.transform.Find ("BSpilih").transform.Find ("bintang2").gameObject.SetActive (false);
						cc.Selection3.transform.Find ("BSpilih").transform.Find ("bintang3").gameObject.SetActive (false);
						cc.Selection3.transform.Find ("BSpilih").transform.Find ("bintang4").gameObject.SetActive (true);
						cc.Selection3.transform.Find ("BSpilih").transform.Find ("bintang5").gameObject.SetActive (false);
						break;
					case 5:
						cc.Selection3.transform.Find ("BSpilih").transform.Find ("bintang1").gameObject.SetActive (false);
						cc.Selection3.transform.Find ("BSpilih").transform.Find ("bintang2").gameObject.SetActive (false);
						cc.Selection3.transform.Find ("BSpilih").transform.Find ("bintang3").gameObject.SetActive (false);
						cc.Selection3.transform.Find ("BSpilih").transform.Find ("bintang4").gameObject.SetActive (false);
						cc.Selection3.transform.Find ("BSpilih").transform.Find ("bintang5").gameObject.SetActive (true);
						break;

					}
				}
			}
		}


	}
	public GameObject[] Slot;
	private IEnumerator GetItemSlotHantu (string playerhantuID)
	{
			//PlayerPrefs.SetString(Link.HANTU_PLAYER_ID,  PlayerPrefs.GetString ("hantuplayerid") );

			string url = Link.url + "getItemSlotHantu";
			WWWForm form = new WWWForm ();
		form.AddField ("HANTU_PLAYER_ID", playerhantuID);
			WWW www = new WWW(url,form);
			yield return www;
			Debug.Log (www.text);
			if (www.error == null) {
				//two = true;
				var jsonString = JSON.Parse (www.text);
				Debug.Log (www.text);
				hantuId 		= jsonString["data"][0]["HantuData"]["id"];
//				hantuName 		= jsonString["data"][0]["HantuData"]["name"];
//				hantuFile 		= jsonString["data"][0]["HantuData"]["name_file"];
//				hantuType    	= jsonString["data"][0]["HantuData"]["type"];

				//attack       	= jsonString["data"][0]["HantuLevel"]["attack"];
				//defense       	= jsonString["data"][0]["HantuLevel"]["defense"];
				//hp       		= jsonString["data"][0]["HantuLevel"]["stamina"];

				//attackText.text 	= attack;
				//defenseText.text	= defense;
				//staminaText.text 	= hp;



				PlayerPrefs.SetString (Link.FOR_CONVERTING, jsonString["data"][0]["Slot1"]);

				Debug.Log ("attack" + jsonString["data"][0]["Slot1"]);

				if (PlayerPrefs.GetString(Link.FOR_CONVERTING) != "0") {
//					Slot [0].GetComponent<Slot> ().ItemId 	 	= jsonString["data"][0]["Slot1"]["ItemId"];
//					Slot [0].GetComponent<Slot> ().ItemNama  	= jsonString["data"][0]["Slot1"]["ItemName"];
//					Slot [0].GetComponent<Slot> ().ItemType  	= jsonString["data"][0]["Slot1"]["ItemType"];
//					Slot [0].GetComponent<Slot> ().ItemLevel 	= jsonString["data"][0]["Slot1"]["ItemLevel"];
					
//					attack 	= jsonString["data"][0]["Slot1"]["ItemAttack"];
//					defense	= jsonString["data"][0]["Slot1"]["ItemDefense"];
//					stamina	= jsonString["data"][0]["Slot1"]["ItemStamina"];
//					Slot [0].transform.FindChild("ImageFile").GetComponent<Image>().sprite =  Resources.Load<Sprite>("icon_item/" + jsonString["data"][0]["Slot1"]["ItemFile"]);
//
					Debug.Log ("attack" +jsonString["data"][0]["Slot1"]["ItemAttack"]);


				attack =  attack + int.Parse (jsonString["data"][0]["Slot1"]["ItemAttack"]);
				defense = defense + int.Parse (jsonString["data"][0]["Slot1"]["ItemDefense"]);
				stamina =  stamina + int.Parse (jsonString["data"][0]["Slot1"]["ItemStamina"]);


				}

				PlayerPrefs.SetString (Link.FOR_CONVERTING, jsonString["data"][0]["Slot2"]);

				if (PlayerPrefs.GetString(Link.FOR_CONVERTING) != "0") {
//					Slot [1].GetComponent<Slot> ().ItemId 	 	= jsonString["data"][0]["Slot2"]["ItemId"];
//					Slot [1].GetComponent<Slot> ().ItemNama  	= jsonString["data"][0]["Slot2"]["ItemName"];
//					Slot [1].GetComponent<Slot> ().ItemType  	= jsonString["data"][0]["Slot2"]["ItemType"];
//					Slot [1].GetComponent<Slot> ().ItemLevel 	= jsonString["data"][0]["Slot2"]["ItemLevel"];
//					Slot [1].GetComponent<Slot> ().ItemAttack 	= jsonString["data"][0]["Slot2"]["ItemAttack"];
//					Slot [1].GetComponent<Slot> ().ItemDefense	= jsonString["data"][0]["Slot2"]["ItemDefense"];
//					Slot [1].GetComponent<Slot> ().ItemStamina	= jsonString["data"][0]["Slot2"]["ItemStamina"];
//					Slot [1].transform.FindChild("ImageFile").GetComponent<Image>().sprite =  Resources.Load<Sprite>("icon_item/" + jsonString["data"][0]["Slot2"]["ItemFile"]);
//
					attack = attack + int.Parse (jsonString["data"][0]["Slot2"]["ItemAttack"]);
					defense = defense + int.Parse (jsonString["data"][0]["Slot2"]["ItemDefense"]);
					stamina = stamina + int.Parse (jsonString["data"][0]["Slot2"]["ItemStamina"]);
				}

				PlayerPrefs.SetString (Link.FOR_CONVERTING, jsonString["data"][0]["Slot3"]);

				if (PlayerPrefs.GetString(Link.FOR_CONVERTING) != "0") {
//					Slot [2].GetComponent<Slot> ().ItemId 	 	= jsonString["data"][0]["Slot3"]["ItemId"];
//					Slot [2].GetComponent<Slot> ().ItemNama  	= jsonString["data"][0]["Slot3"]["ItemName"];
//					Slot [2].GetComponent<Slot> ().ItemType  	= jsonString["data"][0]["Slot3"]["ItemType"];
//					Slot [2].GetComponent<Slot> ().ItemLevel 	= jsonString["data"][0]["Slot3"]["ItemLevel"];
//					Slot [2].GetComponent<Slot> ().ItemAttack 	= jsonString["data"][0]["Slot3"]["ItemAttack"];
//					Slot [2].GetComponent<Slot> ().ItemDefense	= jsonString["data"][0]["Slot3"]["ItemDefense"];
//					Slot [2].GetComponent<Slot> ().ItemStamina	= jsonString["data"][0]["Slot3"]["ItemStamina"];
//					Slot [2].transform.FindChild("ImageFile").GetComponent<Image>().sprite =  Resources.Load<Sprite>("icon_item/" + jsonString["data"][0]["Slot3"]["ItemFile"]);
//
					attack = attack + int.Parse (jsonString["data"][0]["Slot3"]["ItemAttack"]);
					defense = defense + int.Parse (jsonString["data"][0]["Slot3"]["ItemDefense"]);
					stamina = stamina + int.Parse (jsonString["data"][0]["Slot3"]["ItemStamina"]);
				}

				PlayerPrefs.SetString (Link.FOR_CONVERTING, jsonString["data"][0]["Slot4"]);

				if (PlayerPrefs.GetString(Link.FOR_CONVERTING) != "0") {
//					Slot [3].GetComponent<Slot> ().ItemId 	 	= jsonString["data"][0]["Slot4"]["ItemId"];
//					Slot [3].GetComponent<Slot> ().ItemNama  	= jsonString["data"][0]["Slot4"]["ItemName"];
//					Slot [3].GetComponent<Slot> ().ItemType  	= jsonString["data"][0]["Slot4"]["ItemType"];
//					Slot [3].GetComponent<Slot> ().ItemLevel 	= jsonString["data"][0]["Slot4"]["ItemLevel"];
//					Slot [3].GetComponent<Slot> ().ItemAttack 	= jsonString["data"][0]["Slot4"]["ItemAttack"];
//					Slot [3].GetComponent<Slot> ().ItemDefense	= jsonString["data"][0]["Slot4"]["ItemDefense"];
//					Slot [3].GetComponent<Slot> ().ItemStamina	= jsonString["data"][0]["Slot4"]["ItemStamina"];
//					Slot [3].transform.FindChild("ImageFile").GetComponent<Image>().sprite =  Resources.Load<Sprite>("icon_item/" + jsonString["data"][0]["Slot4"]["ItemFile"]);
//
					attack = attack + int.Parse (jsonString["data"][0]["Slot4"]["ItemAttack"]);
					defense = defense + int.Parse (jsonString["data"][0]["Slot4"]["ItemDefense"]);
					stamina = stamina + int.Parse (jsonString["data"][0]["Slot4"]["ItemStamina"]);
				}

			attack = attack;
			defense = defense;
			stamina = stamina;
			} else {
				Debug.Log ("GAGAL");
			}
		}
}
