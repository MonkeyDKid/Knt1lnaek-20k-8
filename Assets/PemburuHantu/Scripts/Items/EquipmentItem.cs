using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System.Collections;
using UnityEngine.SceneManagement;

public class EquipmentItem : MonoBehaviour {

	public string ItemPlayerID, ItemId, ItemName, ItemFile, ItemType, ItemLevel, ItemAttack, ItemDefense, ItemStamina,ItemStatus;
	public Image icon_item;
	public GameObject pasangitem,zoomItem,selected,zoomitempressed,selected2,Zoomboss,mybutton;
	public Equipment cc;
	public Text name, type, price, stats;
	public int slot;
	public bool pilih;
	void Start () {
		
//		if (SceneManager.GetActiveScene ().name == "Equipment") {
//		cc = GameObject.Find ("Equipment").GetComponent<Equipment> ();
//		pasangitem = GameObject.Find ("Equipment").transform.FindChild("MiddlePanel").transform.FindChild("PasangItemGUi").gameObject;
//		} else {
//		
//		}
	}
	public void Update(){
		
		if (!pasangitem.activeInHierarchy) {
			if (cc.pilih == false) {
				pilih = false;
			}
		}
		if (slot != 0 || cc.Slot [0].GetComponent<Slot> ().isi==true&&cc.Slot [1].GetComponent<Slot> ().isi==true&&cc.Slot [2].GetComponent<Slot> ().isi==true&&cc.Slot [3].GetComponent<Slot> ().isi==true) {
			mybutton.GetComponent<Button>().interactable=false;

		} else {
			//gameObject.GetComponent<Button>().interactable=true;
		}
		if (int.Parse(ItemStatus) == 1) {
			mybutton.GetComponent<Button> ().interactable = false;
			selected2.SetActive (true);
		}
		else{
			mybutton.GetComponent<Button> ().interactable = true;
			selected2.SetActive (false);

		}
			if (pilih) {
			if (cc.pilih) {
				if (cc.Slot [0].GetComponent<Slot> ().ItemId == "") {

					if (cc.Slot [1].GetComponent<Slot> ().ItemPlayerId != ItemPlayerID && cc.Slot [2].GetComponent<Slot> ().ItemPlayerId != ItemPlayerID && cc.Slot [3].GetComponent<Slot> ().ItemPlayerId != ItemPlayerID) {
						cc.Slot [0].GetComponent<Slot> ().ItemId = ItemId;
						cc.Slot [0].GetComponent<Slot> ().ItemNama = ItemName;
						cc.Slot [0].GetComponent<Slot> ().ItemType = ItemType;
						cc.Slot [0].GetComponent<Slot> ().ItemLevel = ItemLevel;
						cc.Slot [0].GetComponent<Slot> ().ItemAttack = ItemAttack;
						cc.Slot [0].GetComponent<Slot> ().ItemPlayerId = ItemPlayerID;
						cc.Slot [0].GetComponent<Slot> ().ItemDefense	= ItemDefense;
						cc.Slot [0].GetComponent<Slot> ().ItemStamina	= ItemStamina;
						cc.Slot [0].GetComponent<Slot> ().selected = Zoomboss;
						cc.Slot [0].transform.Find ("ImageFile").GetComponent<Image> ().sprite = Resources.Load<Sprite> ("icon_item/" + ItemFile);
						cc.Slot [0].GetComponent<Slot> ().yslot = 1;
						cc.Slot [0].GetComponent<Slot> ().isi = true;
						cc.attackInt = cc.attackInt + int.Parse (ItemAttack);
						cc.defenseInt = cc.defenseInt + int.Parse (ItemDefense);
						cc.hpInt = cc.hpInt + int.Parse (ItemStamina);
						PlayerPrefs.SetString ("SLOTITEM1", ItemPlayerID);
						PlayerPrefs.SetInt ("tukar1", 0);
						Zoomboss.GetComponent<EquipmentItem>(). ItemStatus = "1";
						Debug.Log ("ItemPlayerID 1 : " + ItemPlayerID);

						slot = 1;
						cc.selection1 = this.gameObject;
					}
					//	transform.FindChild ("Select").gameObject.SetActive (true);

				} 
				if (cc.Slot [1].GetComponent<Slot> ().ItemId == "") {

					if (cc.Slot [0].GetComponent<Slot> ().ItemPlayerId != ItemPlayerID && cc.Slot [2].GetComponent<Slot> ().ItemPlayerId != ItemPlayerID && cc.Slot [3].GetComponent<Slot> ().ItemPlayerId != ItemPlayerID) {
						cc.Slot [1].GetComponent<Slot> ().ItemId = ItemId;
						cc.Slot [1].GetComponent<Slot> ().ItemNama = ItemName;
						cc.Slot [1].GetComponent<Slot> ().ItemType = ItemType;
						cc.Slot [1].GetComponent<Slot> ().ItemPlayerId = ItemPlayerID;
						cc.Slot [1].GetComponent<Slot> ().ItemLevel = ItemLevel;
						cc.Slot [1].GetComponent<Slot> ().ItemAttack = ItemAttack;
						cc.Slot [1].GetComponent<Slot> ().ItemDefense	= ItemDefense;
						cc.Slot [1].GetComponent<Slot> ().ItemStamina	= ItemStamina;
						cc.Slot [1].GetComponent<Slot> ().selected = Zoomboss;
						cc.Slot [1].transform.Find ("ImageFile").GetComponent<Image> ().sprite = Resources.Load<Sprite> ("icon_item/" + ItemFile);
						cc.Slot [1].GetComponent<Slot> ().yslot = 2;
						cc.Slot [1].GetComponent<Slot> ().isi = true;
						cc.attackInt = cc.attackInt + int.Parse (ItemAttack);
						cc.defenseInt = cc.defenseInt + int.Parse (ItemDefense);
						cc.hpInt = cc.hpInt + int.Parse (ItemStamina);
						PlayerPrefs.SetString ("SLOTITEM2", ItemPlayerID);
						PlayerPrefs.SetInt("tukar2",0);
						Zoomboss.GetComponent<EquipmentItem>().	ItemStatus = "1";
						slot = 2;
						cc.selection2 = this.gameObject;
					}

					//transform.FindChild ("Select").gameObject.SetActive (true);
				}

				 if (cc.Slot [2].GetComponent<Slot> ().ItemId == "") {

					if (cc.Slot [0].GetComponent<Slot> ().ItemPlayerId != ItemPlayerID && cc.Slot [1].GetComponent<Slot> ().ItemPlayerId != ItemPlayerID && cc.Slot [3].GetComponent<Slot> ().ItemPlayerId != ItemPlayerID) {
						cc.Slot [2].GetComponent<Slot> ().ItemId = ItemId;
						cc.Slot [2].GetComponent<Slot> ().ItemNama = ItemName;
						cc.Slot [2].GetComponent<Slot> ().ItemType = ItemType;
						cc.Slot [2].GetComponent<Slot> ().ItemPlayerId = ItemPlayerID;
						cc.Slot [2].GetComponent<Slot> ().ItemLevel = ItemLevel;
						cc.Slot [2].GetComponent<Slot> ().ItemAttack = ItemAttack;
						cc.Slot [2].GetComponent<Slot> ().ItemDefense	= ItemDefense;
						cc.Slot [2].GetComponent<Slot> ().ItemStamina	= ItemStamina;
						cc.Slot [2].GetComponent<Slot> ().selected = Zoomboss;
						cc.Slot [2].transform.Find ("ImageFile").GetComponent<Image> ().sprite = Resources.Load<Sprite> ("icon_item/" + ItemFile);
						cc.Slot [2].GetComponent<Slot> ().yslot = 3;
						cc.Slot [2].GetComponent<Slot> ().isi = true;
						cc.attackInt = cc.attackInt + int.Parse (ItemAttack);
						cc.defenseInt = cc.defenseInt + int.Parse (ItemDefense);
						cc.hpInt = cc.hpInt + int.Parse (ItemStamina);
						PlayerPrefs.SetString ("SLOTITEM3", ItemPlayerID);
						PlayerPrefs.SetInt("tukar3",0);
						Zoomboss.GetComponent<EquipmentItem>().ItemStatus = "1";
						slot = 3;
						cc.selection3 = this.gameObject;
					}

					//	transform.FindChild ("Select").gameObject.SetActive (true);
				}  

				 if (cc.Slot [3].GetComponent<Slot> ().ItemId == "") {

					if (cc.Slot [0].GetComponent<Slot> ().ItemPlayerId != ItemPlayerID && cc.Slot [1].GetComponent<Slot> ().ItemPlayerId != ItemPlayerID && cc.Slot [2].GetComponent<Slot> ().ItemPlayerId != ItemPlayerID) {
						cc.Slot [3].GetComponent<Slot> ().ItemId = ItemId;
						cc.Slot [3].GetComponent<Slot> ().ItemNama = ItemName;
						cc.Slot [3].GetComponent<Slot> ().ItemPlayerId = ItemPlayerID;
						cc.Slot [3].GetComponent<Slot> ().ItemType = ItemType;
						cc.Slot [3].GetComponent<Slot> ().ItemLevel = ItemLevel;
						cc.Slot [3].GetComponent<Slot> ().ItemAttack = ItemAttack;
						cc.Slot [3].GetComponent<Slot> ().ItemDefense	= ItemDefense;
						cc.Slot [3].GetComponent<Slot> ().ItemStamina	= ItemStamina;
						cc.Slot [3].GetComponent<Slot> ().yslot = 4;
						cc.Slot [3].GetComponent<Slot> ().isi = true;
						cc.Slot [3].GetComponent<Slot> ().selected = Zoomboss;
						cc.Slot [3].transform.Find ("ImageFile").GetComponent<Image> ().sprite = Resources.Load<Sprite> ("icon_item/" + ItemFile);

						cc.attackInt = cc.attackInt + int.Parse (ItemAttack);
						cc.defenseInt = cc.defenseInt + int.Parse (ItemDefense);
						cc.hpInt = cc.hpInt + int.Parse (ItemStamina);
						PlayerPrefs.SetString ("SLOTITEM4", ItemPlayerID);
						PlayerPrefs.SetInt("tukar4",0);
						Zoomboss.GetComponent<EquipmentItem>().ItemStatus = "1";
						slot = 4;
						cc.selection4 = this.gameObject;
					}

					//	transform.FindChild ("Select").gameObject.SetActive (true);
				}


				cc.attackText.text = cc.attack +" + <color=green>" + cc.attackInt.ToString ()+"</color>";
				cc.defenseText.text	= cc.defense + " + <color=green>" + cc.defenseInt.ToString ()+"</color>";
				cc.staminaText.text = cc.hp + " + <color=green>" + cc.hpInt.ToString ()+"</color>";
				StartCoroutine (tunggu());
		
			}
//			cc.pilih = false;
//			pilih = false;

		}
	}
	IEnumerator tunggu(){
		yield return new WaitForSeconds (.1f);
		cc.pilih = false;
	//	pilih = false;
	//	GetComponent<Button> ().interactable = false;


	}

	public void OnClick () {
		
		if (!pilih) {
			pilih = true;
		}

		pasangitem.SetActive (true);
		Debug.Log ("tes");
	

	}
	public void OnZoom () {
		
		selected.SetActive (true);
		zoomItem.SetActive (true);
		zoomItem.GetComponent<EquipmentItem> ().selected = selected;
		zoomItem.GetComponent<EquipmentItem> ().selected2 = selected2;
		zoomItem.GetComponent<EquipmentItem>().icon_item.sprite =  icon_item.sprite;
		zoomItem.GetComponent<EquipmentItem> ().ItemId = ItemId;
		zoomItem.GetComponent<EquipmentItem>().ItemName 	  =ItemName;
		zoomItem.GetComponent<EquipmentItem>().ItemStatus 	  =ItemStatus;
		zoomItem.GetComponent<EquipmentItem>().ItemFile 	  = ItemFile;
		zoomItem.GetComponent<EquipmentItem>().ItemPlayerID 	  =ItemPlayerID;
		zoomItem.GetComponent<EquipmentItem> ().zoomItem = zoomItem;
		zoomItem.GetComponent<EquipmentItem> ().ItemType = ItemType;
		zoomItem.GetComponent<EquipmentItem> ().Zoomboss=this.gameObject;
			zoomItem.GetComponent<EquipmentItem>().ItemLevel   = ItemLevel;
			zoomItem.GetComponent<EquipmentItem>().ItemAttack  = ItemAttack;
			zoomItem.GetComponent<EquipmentItem>().ItemDefense =ItemDefense;
			zoomItem.GetComponent<EquipmentItem>().ItemStamina = ItemStamina;
			zoomItem.GetComponent<EquipmentItem>().ItemStatus = ItemStatus;
		zoomitempressed.SetActive (false);
		zoomItem.GetComponent<EquipmentItem>().selected2.SetActive (true);

	}
	public void ZoomOut(){
		zoomItem.GetComponent<EquipmentItem>().selected.SetActive (false);
		zoomItem.GetComponent<EquipmentItem>().selected2.SetActive (false);
	}

	public void pasang_selected(){
		
	//	zoomItem.GetComponent<EquipmentItem>().selected2.SetActive (true);
	
		selected.SetActive (true);
	}
}
