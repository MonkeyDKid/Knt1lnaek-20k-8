 using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using SimpleJSON;
using System.Collections;


public class Equipment : MonoBehaviour
{
	public GameObject zoomItem,pressed,savestates,saving,contentT,contentS,validationError;
	public ContentController contentController;
	public GameObject[] Slot;
	public string hantuId, hantuName, hantuFile, hantuType, attack, defense, hp;
	public bool trans,pilih;
	public GameObject selection1,selection2,selection3,selection4;
	public Text attackText, defenseText, staminaText,Goldbar;
	public GameObject data;
	public int attackInt, defenseInt, hpInt = 0;
	int azz;
	public bool lepas=false;
	public GameObject talismanOn, sigilOn;
	public GameObject main, loading;
	public GameObject show;

	private bool one = false;
	private bool two = false;
	private bool done = false;

	public void OnTalismanOnClick() {

		Debug.Log ("RES");

		sigilOn.GetComponent<Image> ().color = new Color (1f,1f,1f,0f);


		contentController.ContentSigil.transform.parent.gameObject.SetActive (false);

		talismanOn.GetComponent<Image> ().color = new Color (1f,1f,1f,1f);
		contentController.ContentTalisman.transform.parent.gameObject.SetActive (true);
	}

	public void OnSigilOnClick () {
		Debug.Log ("sigil");
		sigilOn.GetComponent<Image> ().color = new Color (1f,1f,1f,1f);
		contentController.ContentSigil.transform.parent.gameObject.SetActive (true);

		talismanOn.GetComponent<Image> ().color = new Color (1f,1f,1f,0f);
		contentController.ContentTalisman.transform.parent.gameObject.SetActive (false);
	}




	private void Start () {
		lepas = false;
		PlayerPrefs.SetInt("tukar1",0);
		PlayerPrefs.SetInt("tukar2",0);
		PlayerPrefs.SetInt("tukar3",0);
		PlayerPrefs.SetInt("tukar4",0);
		PlayerPrefs.SetString("SLOTITEM1","0");
		PlayerPrefs.SetString("SLOTITEM2","0");
		PlayerPrefs.SetString("SLOTITEM3","0");
		PlayerPrefs.SetString("SLOTITEM4","0");
		Goldbar.text = PlayerPrefs.GetString (Link.GOLD);
		talismanOn.GetComponent<Image> ().color = new Color (1f,1f,1f,0f);
		StartCoroutine( getdataHantu (PlayerPrefs.GetString ("hantuplayerid"), 0));
		foreach (Transform child in show.transform) {
			GameObject.Destroy(child.gameObject);
		}

		GameObject model = Instantiate (Resources.Load ("PrefabsChar/" + PlayerPrefs.GetString(Link.FOR_CONVERTING_2)) as GameObject,  new Vector3(0f,0f,0f), Quaternion.identity);
		model.transform.SetParent (show.transform);
        if (PlayerPrefs.GetString(Link.FOR_CONVERTING_2) == "NagaBesukih_Fire" || PlayerPrefs.GetString(Link.FOR_CONVERTING_2) == "NagaBesukih_Wind" || PlayerPrefs.GetString(Link.FOR_CONVERTING_2) == "NagaBesukih_Water")
        {
            model.transform.localPosition = new Vector3(0, 0, 0);
            model.transform.localScale = new Vector3(.9f, .9f, .9f);
            model.transform.localEulerAngles = new Vector3(0, 0, 0);
            model.GetComponent<Animation>().PlayQueued("idle", QueueMode.PlayNow);

        }
        else
        {
            model.transform.localPosition = new Vector3(0, 0, 0);
            model.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            model.transform.localEulerAngles = new Vector3(0, 0, 0);
            model.GetComponent<Animation>().PlayQueued("idle", QueueMode.PlayNow);

        }

	}

	public void OnBack () {
		if (savestates.GetComponent<Button>().interactable==true) {
			saving.SetActive (true);
		} else {
			SceneManagerHelper.LoadScene ("Storage");
		}
	}
	public void OnBack2 () {
		   SceneManagerHelper.LoadScene ("Storage");

	}

	void Update () {
		if (one && two && done == false) {
			done = true;
			main.SetActive (true);
			loading.SetActive (false);
		}
	}

	private IEnumerator GetItemUser ()
	{
		string url = Link.url + "getItemUser";
		WWWForm form = new WWWForm ();
		form.AddField (Link.ID, PlayerPrefs.GetString(Link.ID));
        form.AddField("DID", PlayerPrefs.GetString(Link.DEVICE_ID));
        WWW www = new WWW(url,form);
		yield return www;
		if (www.error == null) {
			Debug.Log (www.text);
			Debug.Log ("RES");


			one = true;

			var jsonString = JSON.Parse (www.text);
			PlayerPrefs.SetString (Link.FOR_CONVERTING, jsonString["code"]);
			if (PlayerPrefs.GetString(Link.FOR_CONVERTING)=="0") {

				GameObject[] entry;
				entry = new GameObject[int.Parse(jsonString["count"])];

				for (int x = contentController.ContentSigil.childCount - 1; x >= 0; x--) {
					Destroy (contentController.ContentSigil.GetChild (x).gameObject);
				}
				for (int x = contentController.ContentTalisman.childCount - 1; x >= 0; x--) {
					Destroy (contentController.ContentTalisman.GetChild (x).gameObject);
				}
				for (int x = 0; x < int.Parse(jsonString["count"]); x++) {
					entry [x] = Instantiate (data);

					entry [x].GetComponent<EquipmentItem> ().icon_item.transform.gameObject.SetActive (true);
					entry[x].GetComponent<EquipmentItem>().icon_item.sprite =  Resources.Load<Sprite>("icon_item/" + jsonString["data"][x]["ItemFile"]);
				
					entry[x].GetComponent<EquipmentItem>().ItemId  	  = jsonString["data"][x]["ItemId"];
					entry[x].GetComponent<EquipmentItem>().ItemName 	  = jsonString["data"][x]["ItemNama"];
					entry[x].GetComponent<EquipmentItem>().ItemFile 	  = jsonString["data"][x]["ItemFile"];
					entry[x].GetComponent<EquipmentItem>().ItemPlayerID 	  = jsonString["data"][x]["ItemPlayerID"];
					entry [x].name = jsonString ["data"] [x] ["ItemPlayerID"];
					if (SceneManager.GetActiveScene ().name == "Equipment") {
						entry [x].GetComponent<EquipmentItem> ().pasangitem = this.gameObject.transform.Find ("MiddlePanel").transform.Find ("PasangItemGUi").gameObject;
						entry [x].GetComponent<EquipmentItem> ().cc = this.gameObject.GetComponent<Equipment> ();
						entry [x].GetComponent<EquipmentItem> ().zoomItem = zoomItem;
						entry [x].GetComponent<EquipmentItem> ().zoomitempressed = pressed;
					}
					entry[x].GetComponent<EquipmentItem>().ItemType 	  = jsonString["data"][x]["ItemType"];
					entry[x].GetComponent<EquipmentItem>().ItemLevel   = jsonString["data"][x]["ItemLevel"];

					entry[x].GetComponent<EquipmentItem>().ItemAttack  = jsonString["data"][x]["ItemAttack"];
					entry[x].GetComponent<EquipmentItem>().ItemDefense = jsonString["data"][x]["ItemDefense"];
					entry[x].GetComponent<EquipmentItem>().ItemStamina = jsonString["data"][x]["ItemStamina"];
					entry[x].GetComponent<EquipmentItem>().ItemStatus = jsonString["data"][x]["ItemStatus"];
					PlayerPrefs.SetString (Link.FOR_CONVERTING, jsonString["data"][x]["ItemType"]);

					if (PlayerPrefs.GetString (Link.FOR_CONVERTING) == "sigil") {
						entry [x].transform.SetParent (contentController.ContentSigil, false);
					} else {
						entry [x].transform.SetParent (contentController.ContentTalisman, false);
					}

					//ANJAR INI YANG BARU. TOLONG DI KONDISIKAN
					PlayerPrefs.SetString (Link.FOR_CONVERTING_2, jsonString ["data"] [x] ["ItemStatus"]);
					if (PlayerPrefs.GetString (Link.FOR_CONVERTING_2) == "1") {
						//int azz;
					//	azz++;
					//	entry [x].GetComponent<EquipmentItem> ().slot = azz;
					//	Debug.Log ("bawah");
						entry [x].gameObject.GetComponent<Button> ().interactable = false;

						//selection2= entry [x].gameObject;
//						if (entry [x].GetComponent<EquipmentItem> ().slot == 1) {
									Debug.Log ("atas");
						Debug.Log (Slot [0].GetComponent<Slot> ().ItemPlayerId	);
//						}
						if( entry [x].GetComponent<EquipmentItem> ().ItemPlayerID == Slot [0].GetComponent<Slot> ().ItemPlayerId){
							Debug.Log ("select 1");
							selection1 = entry [x].gameObject;
						}
						if( entry [x].GetComponent<EquipmentItem> ().ItemPlayerID == Slot [1].GetComponent<Slot> ().ItemPlayerId){
							Debug.Log ("select 2");
							selection2 = entry [x].gameObject;
						}
						if( entry [x].GetComponent<EquipmentItem> ().ItemPlayerID == Slot [2].GetComponent<Slot> ().ItemPlayerId){
							Debug.Log ("select 3");
							selection3 = entry [x].gameObject;
						}
						if( entry [x].GetComponent<EquipmentItem> ().ItemPlayerID == Slot [3].GetComponent<Slot> ().ItemPlayerId){
							Debug.Log ("select 4");
							selection4 = entry [x].gameObject;
						}
//						if(Slot [1].GetComponent<Slot> ().ItemPlayerId==entry [x].GetComponent<EquipmentItem> ().ItemPlayerID){
//							Debug.Log ("select 2");
//							selection2 = entry [x].gameObject;
//						}
						//selection2 = entry [2].gameObject;
						//selection3 = entry [3].gameObject;
						//selection4= entry [4].gameObject;
						//NON AKTIFKAN ITEM
						//MAKSUDNYA ITEM SUDAH DI GUNAKAN,
						//BISA SUDAH DI GUNAKAN DI MONSTER LAIN..
					} else {
						entry [x].GetComponent<EquipmentItem> ().slot = 9;
					//	Debug.Log ("atas");
						entry [x].gameObject.GetComponent<Button> ().interactable = true;
						//AKTIFKAN
					}


				}
				StartCoroutine (GetItemSlotHantu ());
			}
            else if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == "33")
            {
                validationError.SetActive(true);
            }
        } else {
			Debug.Log ("GAGAL");
		}
	}



	private IEnumerator GetItemSlotHantu ()
	{
		yield return new WaitForSeconds (.5f);
			//PlayerPrefs.SetString(Link.HANTU_PLAYER_ID,  PlayerPrefs.GetString ("hantuplayerid") );

			string url = Link.url + "getItemSlotHantu";
			WWWForm form = new WWWForm ();
			form.AddField ("HANTU_PLAYER_ID", PlayerPrefs.GetString ("hantuplayerid"));
			WWW www = new WWW(url,form);
			yield return www;
			Debug.Log (www.text);
			if (www.error == null) {
				two = true;
				var jsonString = JSON.Parse (www.text);
				Debug.Log (www.text);
				hantuId 		= jsonString["data"][0]["HantuData"]["id"];
				hantuName 		= jsonString["data"][0]["HantuData"]["name"];
				hantuFile 		= jsonString["data"][0]["HantuData"]["name_file"];
				hantuType    	= jsonString["data"][0]["HantuData"]["type"];

				//attack       	= jsonString["data"][0]["HantuLevel"]["attack"];
				//defense       	= jsonString["data"][0]["HantuLevel"]["defense"];
				//hp       		= jsonString["data"][0]["HantuLevel"]["stamina"];

				//attackText.text 	= attack;
				//defenseText.text	= defense;
				//staminaText.text 	= hp;



				PlayerPrefs.SetString (Link.FOR_CONVERTING, jsonString["data"][0]["Slot1"]);

				Debug.Log ("attack" + jsonString["data"][0]["Slot1"]);
				string type = jsonString ["data"] [0] ["Slot1"] ["ItemType"];
				if (PlayerPrefs.GetString(Link.FOR_CONVERTING) != "0") {
					Slot [0].GetComponent<Slot> ().ItemId 	 	= jsonString["data"][0]["Slot1"]["ItemId"];
					Slot [0].GetComponent<Slot> ().ItemNama  	= jsonString["data"][0]["Slot1"]["ItemName"];
					Slot [0].GetComponent<Slot> ().ItemType  	= jsonString["data"][0]["Slot1"]["ItemType"];
					Slot [0].GetComponent<Slot> ().ItemLevel 	= jsonString["data"][0]["Slot1"]["ItemLevel"];
					Slot [0].GetComponent<Slot> ().ItemAttack 	= jsonString["data"][0]["Slot1"]["ItemAttack"];
					Slot [0].GetComponent<Slot> ().ItemDefense	= jsonString["data"][0]["Slot1"]["ItemDefense"];
					Slot [0].GetComponent<Slot> ().ItemStamina	= jsonString["data"][0]["Slot1"]["ItemStamina"];
					Slot [0].GetComponent<Slot> ().ItemPlayerId	= jsonString["data"][0]["Slot1"]["ItemPlayerID"];
					Slot [0].GetComponent<Slot> ().isi = true;	
				if (type == "sigil"|| type=="Sigil") 
				{
					Slot [0].GetComponent<Slot> ().selected = contentS.transform.Find (jsonString ["data"] [0] ["Slot1"] ["ItemPlayerID"]).gameObject;
				} else 
				{
					Slot [0].GetComponent<Slot> ().selected = contentT.transform.Find (jsonString ["data"] [0] ["Slot1"] ["ItemPlayerID"]).gameObject;
				}
					Slot [0].transform.Find("ImageFile").GetComponent<Image>().sprite =  Resources.Load<Sprite>("icon_item/" + jsonString["data"][0]["Slot1"]["ItemFile"]);

					Debug.Log ("attack" +jsonString["data"][0]["Slot1"]["ItemAttack"]);


					attackInt = attackInt + int.Parse (jsonString["data"][0]["Slot1"]["ItemAttack"]);
					defenseInt = defenseInt + int.Parse (jsonString["data"][0]["Slot1"]["ItemDefense"]);
					hpInt = hpInt + int.Parse (jsonString["data"][0]["Slot1"]["ItemStamina"]);


				}

				PlayerPrefs.SetString (Link.FOR_CONVERTING, jsonString["data"][0]["Slot2"]);

				if (PlayerPrefs.GetString(Link.FOR_CONVERTING) != "0") {
					Slot [1].GetComponent<Slot> ().ItemId 	 	= jsonString["data"][0]["Slot2"]["ItemId"];
					Slot [1].GetComponent<Slot> ().ItemNama  	= jsonString["data"][0]["Slot2"]["ItemName"];
					Slot [1].GetComponent<Slot> ().ItemType  	= jsonString["data"][0]["Slot2"]["ItemType"];
					Slot [1].GetComponent<Slot> ().ItemLevel 	= jsonString["data"][0]["Slot2"]["ItemLevel"];
					Slot [1].GetComponent<Slot> ().ItemAttack 	= jsonString["data"][0]["Slot2"]["ItemAttack"];
					Slot [1].GetComponent<Slot> ().ItemDefense	= jsonString["data"][0]["Slot2"]["ItemDefense"];
					Slot [1].GetComponent<Slot> ().ItemStamina	= jsonString["data"][0]["Slot2"]["ItemStamina"];
				Slot [1].GetComponent<Slot> ().ItemPlayerId	= jsonString["data"][0]["Slot2"]["ItemPlayerID"];
				Slot [1].GetComponent<Slot> ().isi = true;	
				if (jsonString ["data"] [0] ["Slot2"] ["ItemType"] == "sigil") {
					Slot [1].GetComponent<Slot> ().selected = contentS.transform.Find (jsonString ["data"] [0] ["Slot2"] ["ItemPlayerID"]).gameObject;

				} else {
					Slot [1].GetComponent<Slot> ().selected = contentT.transform.Find (jsonString ["data"] [0] ["Slot2"] ["ItemPlayerID"]).gameObject;
				}
					Slot [1].transform.Find("ImageFile").GetComponent<Image>().sprite =  Resources.Load<Sprite>("icon_item/" + jsonString["data"][0]["Slot2"]["ItemFile"]);

					attackInt = attackInt + int.Parse (jsonString["data"][0]["Slot2"]["ItemAttack"]);
					defenseInt = defenseInt + int.Parse (jsonString["data"][0]["Slot2"]["ItemDefense"]);
					hpInt = hpInt + int.Parse (jsonString["data"][0]["Slot2"]["ItemStamina"]);
				}

				PlayerPrefs.SetString (Link.FOR_CONVERTING, jsonString["data"][0]["Slot3"]);

				if (PlayerPrefs.GetString(Link.FOR_CONVERTING) != "0") {
					Slot [2].GetComponent<Slot> ().ItemId 	 	= jsonString["data"][0]["Slot3"]["ItemId"];
					Slot [2].GetComponent<Slot> ().ItemNama  	= jsonString["data"][0]["Slot3"]["ItemName"];
					Slot [2].GetComponent<Slot> ().ItemType  	= jsonString["data"][0]["Slot3"]["ItemType"];
					Slot [2].GetComponent<Slot> ().ItemLevel 	= jsonString["data"][0]["Slot3"]["ItemLevel"];
					Slot [2].GetComponent<Slot> ().ItemAttack 	= jsonString["data"][0]["Slot3"]["ItemAttack"];
					Slot [2].GetComponent<Slot> ().ItemDefense	= jsonString["data"][0]["Slot3"]["ItemDefense"];
					Slot [2].GetComponent<Slot> ().ItemStamina	= jsonString["data"][0]["Slot3"]["ItemStamina"];
				Slot [2].GetComponent<Slot> ().ItemPlayerId	= jsonString["data"][0]["Slot3"]["ItemPlayerID"];
				Slot [2].GetComponent<Slot> ().isi = true;	
				if (jsonString ["data"] [0] ["Slot3"] ["ItemType"] == "sigil") {
					Slot [2].GetComponent<Slot> ().selected = contentS.transform.Find (jsonString ["data"] [0] ["Slot3"] ["ItemPlayerID"]).gameObject;

				} else {
					Slot [2].GetComponent<Slot> ().selected = contentT.transform.Find (jsonString ["data"] [0] ["Slot3"] ["ItemPlayerID"]).gameObject;
				}
					Slot [2].transform.Find("ImageFile").GetComponent<Image>().sprite =  Resources.Load<Sprite>("icon_item/" + jsonString["data"][0]["Slot3"]["ItemFile"]);

					attackInt = attackInt + int.Parse (jsonString["data"][0]["Slot3"]["ItemAttack"]);
					defenseInt = defenseInt + int.Parse (jsonString["data"][0]["Slot3"]["ItemDefense"]);
					hpInt = hpInt + int.Parse (jsonString["data"][0]["Slot3"]["ItemStamina"]);
				}

				PlayerPrefs.SetString (Link.FOR_CONVERTING, jsonString["data"][0]["Slot4"]);

				if (PlayerPrefs.GetString(Link.FOR_CONVERTING) != "0") {
					Slot [3].GetComponent<Slot> ().ItemId 	 	= jsonString["data"][0]["Slot4"]["ItemId"];
					Slot [3].GetComponent<Slot> ().ItemNama  	= jsonString["data"][0]["Slot4"]["ItemName"];
					Slot [3].GetComponent<Slot> ().ItemType  	= jsonString["data"][0]["Slot4"]["ItemType"];
					Slot [3].GetComponent<Slot> ().ItemLevel 	= jsonString["data"][0]["Slot4"]["ItemLevel"];
					Slot [3].GetComponent<Slot> ().ItemAttack 	= jsonString["data"][0]["Slot4"]["ItemAttack"];
					Slot [3].GetComponent<Slot> ().ItemDefense	= jsonString["data"][0]["Slot4"]["ItemDefense"];
					Slot [3].GetComponent<Slot> ().ItemStamina	= jsonString["data"][0]["Slot4"]["ItemStamina"];
				Slot [3].GetComponent<Slot> ().ItemPlayerId	= jsonString["data"][0]["Slot4"]["ItemPlayerID"];
				Slot [3].GetComponent<Slot> ().isi = true;	
				if (jsonString ["data"] [0] ["Slot1"] ["ItemType"] == "sigil") {
					Slot [3].GetComponent<Slot> ().selected = contentS.transform.Find (jsonString ["data"] [0] ["Slot4"] ["ItemPlayerID"]).gameObject;

				} else {
					Slot [3].GetComponent<Slot> ().selected = contentT.transform.Find (jsonString ["data"] [0] ["Slot4"] ["ItemPlayerID"]).gameObject;
				}
					Slot [3].transform.Find("ImageFile").GetComponent<Image>().sprite =  Resources.Load<Sprite>("icon_item/" + jsonString["data"][0]["Slot4"]["ItemFile"]);

					attackInt = attackInt + int.Parse (jsonString["data"][0]["Slot4"]["ItemAttack"]);
					defenseInt = defenseInt + int.Parse (jsonString["data"][0]["Slot4"]["ItemDefense"]);
					hpInt = hpInt + int.Parse (jsonString["data"][0]["Slot4"]["ItemStamina"]);
				}
				attackText.text 	= attack + " + <color=green>" + attackInt.ToString()+"</color>";
			defenseText.text	= defense + " + <color=green>" + defenseInt.ToString()+"</color>";
			staminaText.text 	= hp + " + <color=green>" + hpInt.ToString()+"</color>";


			} else {
				Debug.Log ("GAGAL");
			}
		}

	public void GIU(){
		StartCoroutine (GetItemUser ());
	}
	private IEnumerator getdataHantu(string hantuplayerid, int Exp)
	{

		Debug.Log ("TES");
		string url = Link.url + "send_xp";
		WWWForm form = new WWWForm ();
		form.AddField ("MY_ID", PlayerPrefs.GetString(Link.ID));
        form.AddField("DID", PlayerPrefs.GetString(Link.DEVICE_ID));
        form.AddField ("PlayerHantuID", hantuplayerid);
		form.AddField ("EXPERIENCE", 0);
		//form.AddField ("CURRENTEXPB", Latestexpbank);

		WWW www = new WWW(url,form);
		yield return www;

		if (www.error == null) {

			var jsonString = JSON.Parse (www.text);
			//=jsonString ["code"] ["Targetnextlevel"]
			hantuId 		= jsonString["code"]["HantuId"];
			hantuName 		= jsonString["code"]["HantuNama"];
			hantuFile 		= jsonString["code"]["HantuFile"];
			hantuType    	= jsonString["code"]["HantuType"];

			attack       	= jsonString["code"]["HantuAttack"];
			defense       	= jsonString["code"]["HantuDefense"];
			hp       		= jsonString["code"]["HantuStamina"];

			attackText.text 	= " + <color=green>"  + attack+"</color>";
			defenseText.text	=  " + <color=green>" + defense+"</color>";
			staminaText.text 	=  " + <color=green>" +hp+"</color>";
 			Debug.Log(www.text);

			PlayerPrefs.SetString (Link.HANTU_PLAYER_ID, jsonString["code"]["HantuPlayerID"]);


			StartCoroutine (GetItemUser ());

		} else {
			Debug.Log ("Failed ambil data");
		

		}

	}

	public void SaveItem () {
		
		StartCoroutine (SaveItemSlotHantu ());
	

	}


	private IEnumerator SaveItemSlotHantu ()
	{

		Debug.Log ("HANTU_PLAYER_ID : " + PlayerPrefs.GetString(Link.HANTU_PLAYER_ID) );
		Debug.Log ("SLOTITEM1 : " + PlayerPrefs.GetString("SLOTITEM1") );
		Debug.Log (PlayerPrefs.GetInt ("tukar1"));
		string url = Link.url + "saveItemHantuSlot";
		WWWForm form = new WWWForm ();
		form.AddField (Link.HANTU_PLAYER_ID, PlayerPrefs.GetString(Link.HANTU_PLAYER_ID));
		form.AddField ("SLOTITEM1",PlayerPrefs.GetString("SLOTITEM1"));
		form.AddField ("SLOTITEM2",PlayerPrefs.GetString("SLOTITEM2"));
		form.AddField ("SLOTITEM3",PlayerPrefs.GetString("SLOTITEM3"));
		form.AddField ("SLOTITEM4",PlayerPrefs.GetString("SLOTITEM4"));
		form.AddField ("tukar1",PlayerPrefs.GetInt("tukar1"));
		form.AddField ("tukar2",PlayerPrefs.GetInt("tukar2"));
		form.AddField ("tukar3",PlayerPrefs.GetInt("tukar3"));
		form.AddField ("tukar4",PlayerPrefs.GetInt("tukar4"));
		WWW www = new WWW(url,form);
		yield return www;
		Debug.Log (www.text);
		if (www.error == null) {
			StartCoroutine (GetItemUser ());
			transform.Find ("Save").GetComponent<Button> ().interactable = false;
			//PlayerPrefs.SetString("SLOTITEM1")
		}
	}
	public void yes(){
		trans = true;
	}
	public void yes2(){
		pilih = true;
		StartCoroutine (wait ());

	}             
	IEnumerator wait(){
		yield return new WaitForSeconds (.25f);
		zoomItem.SetActive (false);
		zoomItem.GetComponent<EquipmentItem> ().selected.SetActive (false);
	}
	public void no(){
		pilih = false;
	}
}

