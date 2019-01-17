using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System.Collections;


public class Slot : MonoBehaviour {

	public string ItemId;
	public string ItemPlayerId;
	public string ItemNama;
	public string ItemType;
	public string ItemLevel;
	public string ItemAttack;
	public string ItemDefense;
	public string ItemStamina;
	public int slot,yslot;
	public bool isi;
	public Sprite defaultSprite;
	public GameObject equipments,selected;
	public Equipment eq;
	public GameObject RemoveItem,zoomselected;

	void Start () {
		
	}

	public void OnClick () {
		if (ItemId != null || ItemId != "" || ItemId != "null") {
			PlayerPrefs.SetInt ("xslot", slot);
			RemoveItem.SetActive (true);
			PlayerPrefs.SetString ("ItemID", ItemId);

			//StartCoroutine (lepasequipment ());
			//if (eq.trans) {
			//	clean_stats ();
			//	eq.trans = false;
			//}
		} else {
			
			GetComponent<Button> ().interactable = false;
		}


	}
//	public IEnumerator lepasequipment(){
//		Debug.Log (PlayerPrefs.GetString ("ItemID"));
//			string url = Link.url + "remove_item";
//			WWWForm form = new WWWForm ();
//			form.AddField ("MY_ID", PlayerPrefs.GetString(Link.ID));
//		form.AddField ("ITEMID", PlayerPrefs.GetString ("ItemID"));
//			form.AddField ("PlayerHantuID", PlayerPrefs.GetString ("hantuplayerid"));
//
//			WWW www = new WWW(url,form);
//			yield return www;
//			if (www.error == null) {
//				Debug.Log (www.text);
//			//	info.text = file;
//			//	StartCoroutine (updateData ());
//			clean_stats();
//			} else {
//				//failed
//			}
//
//		}
	public void Update(){
		if (equipments.GetComponent<Equipment> ().trans) {
			if (slot == PlayerPrefs.GetInt ("xslot")) {
				
				if (slot == 1) {
					PlayerPrefs.SetString ("SLOTITEM1", ItemPlayerId);
					PlayerPrefs.SetInt("tukar1",1);
					eq.lepas=true;
					eq.selection1.GetComponent<EquipmentItem> ().slot = 0;
					//selected.SetActive (false);
					isi = false;
				}

				if (slot == 2) {
					PlayerPrefs.SetString ("SLOTITEM2", ItemPlayerId);
					PlayerPrefs.SetInt("tukar2",1);
					eq.lepas=true;
					isi = false;
				//	selected.SetActive (false);
					eq.selection2.GetComponent<EquipmentItem> ().slot = 0;
				}
				if (slot == 3) {
					PlayerPrefs.SetString ("SLOTITEM3", ItemPlayerId);
					PlayerPrefs.SetInt("tukar3",1);
					eq.lepas=true;
					//selected.SetActive (false);
					isi = false;
					eq.selection3.GetComponent<EquipmentItem> ().slot = 0;
				}
					if (slot == 4) {
					PlayerPrefs.SetInt("tukar4",1);
					PlayerPrefs.SetString ("SLOTITEM4", ItemPlayerId);
					eq.lepas=true;
				//	selected.SetActive (false);
					isi = false;
					eq.selection4.GetComponent<EquipmentItem> ().slot = 0;
				}
				clean_stats ();
			}

		}
		if (isi == false) {
			GetComponent<Button> ().interactable = false;
		}
		else{
			GetComponent<Button> ().interactable = true;
		}
	}
	void clean_stats(){

		eq.attackInt 		= eq.attackInt - int.Parse (ItemAttack);
		eq.defenseInt 		= eq.defenseInt - int.Parse (ItemDefense);
		eq.hpInt 	    	= eq.hpInt - int.Parse (ItemStamina);

		eq.attackText.text 	= eq.attack + " + <color=green>" + eq.attackInt.ToString()+"</color>";
		eq.defenseText.text	= eq.defense +  " + <color=green>" + eq.defenseInt.ToString()+"</color>";
		eq.staminaText.text = eq.hp + " + <color=green>" + eq.hpInt.ToString()+"</color>";

		ItemId = "";
		ItemNama = "";
		ItemType = "";
		ItemLevel = "";
		ItemAttack = "";
		ItemDefense = "";
		ItemStamina = "";
		ItemPlayerId = "";
		//selected.SetActive (false);
		selected.GetComponent<EquipmentItem>().ItemStatus = "0";
		transform.Find ("ImageFile").GetComponent<Image> ().sprite = defaultSprite;
		equipments.GetComponent<Equipment> ().trans = false;
	}
}
