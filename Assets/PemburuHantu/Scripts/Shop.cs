using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;
using SimpleJSON;
using System.Collections;

public class Shop : MonoBehaviour {
	public GameObject GS,ShopItemG,ShopItemC,ShopItemR,TransactionSucceed,TransactionFailed,TransactionFailed2,TransactionFailed3,zoomItem,zoomitem2,zoomitem3,purchase_ask,iaptest;
	public Transform GShop,CShop,RShop;
	ConfigurationBuilder builder;
	// Use this for initialization
	void Start () {
		//StartCoroutine (ShopInformationG ());
//		var module = StandardPurchasingModule.Instance ();
//		builder = ConfigurationBuilder.Instance (module);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void AStart () {
		StartCoroutine (ShopInformationG ());
		GS.SetActive(true);
//		var module = StandardPurchasingModule.Instance ();
//		builder = ConfigurationBuilder.Instance (module);
	}
	private IEnumerator ShopInformationG ()
	{
		string url = Link.url + "get_list_shop";
		WWWForm form = new WWWForm ();
		form.AddField (Link.ID, PlayerPrefs.GetString(Link.ID));
		form.AddField ("SHOP_JENIS", "SPECIAL");
		WWW www = new WWW(url,form);
		yield return www;
		if (www.error == null) {
			Debug.Log (www.text);
			var jsonString = JSON.Parse (www.text);
			PlayerPrefs.SetString (Link.FOR_CONVERTING, jsonString["ID_SHOP_SPECIAL"]);
		//	if (PlayerPrefs.GetString(Link.FOR_CONVERTING)=="1") {

				GameObject[] entry;
			entry = new GameObject[int.Parse(jsonString["count"])];

			for (int x = GShop.childCount - 1; x >= 0; x--) {
				Destroy (GShop.GetChild (x).gameObject);
			}
			for (int x = 0; x < int.Parse(jsonString["count"]); x++) {
					entry [x] = Instantiate (ShopItemG);

					//entry [x].GetComponent<ShopItem> ().icon_item.transform.gameObject.SetActive (true);
				entry[x].GetComponent<ShopItem>().gambaritem.GetComponent<Image>().sprite =  Resources.Load<Sprite>("icon_item/" + jsonString["data"][x]["ItemFile"]);
				entry [x].GetComponent<ShopItem> ().shoptype=jsonString["data"][x]["shoptype"];
				entry [x].GetComponent<ShopItem> ().Shop = this.gameObject;
				entry [x].GetComponent<ShopItem> ().zoomItem = zoomItem;
				entry[x].GetComponent<ShopItem>().idItem  	  = jsonString["data"][x]["ID_SHOP_SPECIAL"];
                entry[x].GetComponent<ShopItem>().namaItem.text = jsonString["data"][x]["ItemNama"];
					entry[x].GetComponent<ShopItem>().fileItem 	  = jsonString["data"][x]["ItemFile"];
					entry[x].GetComponent<ShopItem>().hargaItem.text 	  = jsonString["data"][x]["GoldPrice"];
				entry [x].GetComponent<ShopItem> ().ItemName = zoomItem.GetComponent<ShopItem>().ItemName;
				entry [x].GetComponent<ShopItem> ().ItemPrice = zoomItem.GetComponent<ShopItem>().ItemPrice;
				entry [x].GetComponent<ShopItem> ().beli = bool.Parse(jsonString["data"][x]["CanBuy"]);
					//entry[x].GetComponent<ShopItem>().ItemType 	  = jsonString["data"][x]["ItemType"];
					//entry[x].GetComponent<ShopItem>().ItemLevel   = jsonString["data"][x]["ItemLevel"];

				entry [x].GetComponent<ShopItem> ().AttackItem.text = jsonString ["data"] [x] ["ItemAttack"];
				entry [x].GetComponent<ShopItem> ().DefenseItem.text = jsonString ["data"] [x] ["ItemDefense"];
				entry [x].GetComponent<ShopItem> ().StaminaItem.text = jsonString ["data"] [x] ["ItemStamina"];
				entry[x].GetComponent<ShopItem>().TnCItem.text 	  = jsonString["data"][x]["TnC"];
				//	entry[x].GetComponent<ShopItem>().ItemDefense = jsonString["data"][x]["ItemDefense"];
				//	entry[x].GetComponent<ShopItem>().ItemStamina = jsonString["data"][x]["ItemStamina"];

					PlayerPrefs.SetString (Link.FOR_CONVERTING, jsonString["data"][x]["ItemType"]);
					entry [x].transform.SetParent (GShop, false);
//					if (PlayerPrefs.GetString (Link.FOR_CONVERTING) == "Gold") {
//						entry [x].transform.SetParent (GShop, false);
//					} 
//					else if (PlayerPrefs.GetString (Link.FOR_CONVERTING) == "Crystal") {
//						entry [x].transform.SetParent (CShop, false);
//					} 
//					else {
//						entry [x].transform.SetParent (RShop, false);
//					}

			}
		} 
			else {
			Debug.Log ("GAGAL");
		}
	//}
	
}
	private IEnumerator ShopInformationC ()
	{
		string url = Link.url + "get_list_shop_crystal";
		WWWForm form = new WWWForm ();
		form.AddField (Link.ID, PlayerPrefs.GetString(Link.ID));
		form.AddField ("SHOP_JENIS", "");
		form.AddField ("All", "Y");
		WWW www = new WWW(url,form);
		yield return www;
        Debug.Log(www.text);
		if (www.error == null) {
			Debug.Log (www.text);
			var jsonString = JSON.Parse (www.text);
			PlayerPrefs.SetString (Link.FOR_CONVERTING, jsonString["ID_SHOP_SPECIAL"]);
			//	if (PlayerPrefs.GetString(Link.FOR_CONVERTING)=="1") {

			GameObject[] entry;
			entry = new GameObject[int.Parse(jsonString["count"])];
			for (int x = CShop.childCount - 1; x >= 0; x--) {
				Destroy (CShop.GetChild (x).gameObject);
			}
			for (int x = 0; x < int.Parse(jsonString["count"]); x++) {
				entry [x] = Instantiate (ShopItemC);

				//entry [x].GetComponent<ShopItem> ().icon_item.transform.gameObject.SetActive (true);
				entry[x].GetComponent<ShopItem>().gambaritem.GetComponent<Image>().sprite =  Resources.Load<Sprite>("icon_item/" + jsonString["data"][x]["Type"]);
				entry [x].GetComponent<ShopItem> ().shoptype=jsonString["data"][x]["shoptype"];
				entry [x].GetComponent<ShopItem> ().Shop = this.gameObject;
				entry[x].GetComponent<ShopItem>().idItem  	  = jsonString["data"][x]["ID"];
				entry[x].GetComponent<ShopItem>().namaItem.text 	  = jsonString["data"][x]["Type"];
                entry[x].GetComponent<ShopItem>().itemnamenya = jsonString["data"][x]["Type"];
                entry[x].GetComponent<ShopItem>().itemquantitynya = jsonString["data"][x]["Count"];
                entry[x].GetComponent<ShopItem>().itemQuantity.text = jsonString["data"][x]["Count"];
                entry[x].GetComponent<ShopItem>().fileItem 	  = jsonString["data"][x]["ItemFile"];
				entry[x].GetComponent<ShopItem>().hargaItem.text 	  = jsonString["data"][x]["CrystalPrice"];
				entry [x].GetComponent<ShopItem> ().zoomItem = zoomitem2;
				entry [x].GetComponent<ShopItem> ().ItemName = zoomitem2.GetComponent<ShopItem>().ItemName;
				entry [x].GetComponent<ShopItem> ().ItemPrice = zoomitem2.GetComponent<ShopItem>().ItemPrice;
				//entry[x].GetComponent<ShopItem>().ItemType 	  = jsonString["data"][x]["ItemType"];
				//entry[x].GetComponent<ShopItem>().ItemLevel   = jsonString["data"][x]["ItemLevel"];

				entry [x].GetComponent<ShopItem> ().AttackItem.text = jsonString ["data"] [x] ["ItemAttack"];
				entry [x].GetComponent<ShopItem> ().DefenseItem.text = jsonString ["data"] [x] ["ItemDefense"];
				entry [x].GetComponent<ShopItem> ().StaminaItem.text = jsonString ["data"] [x] ["ItemStamina"];
				entry[x].GetComponent<ShopItem>().TnCItem.text 	  = jsonString["data"][x]["TnC"];
				//	entry[x].GetComponent<ShopItem>().ItemDefense = jsonString["data"][x]["ItemDefense"];
				//	entry[x].GetComponent<ShopItem>().ItemStamina = jsonString["data"][x]["ItemStamina"];

				PlayerPrefs.SetString (Link.FOR_CONVERTING, jsonString["data"][x]["ItemType"]);
				entry [x].transform.SetParent (CShop, false);
				//					if (PlayerPrefs.GetString (Link.FOR_CONVERTING) == "Gold") {
				//						entry [x].transform.SetParent (GShop, false);
				//					} 
				//					else if (PlayerPrefs.GetString (Link.FOR_CONVERTING) == "Crystal") {
				//						entry [x].transform.SetParent (CShop, false);
				//					} 
				//					else {
				//						entry [x].transform.SetParent (RShop, false);
				//					}

			}
		} 
		else {
			Debug.Log ("GAGAL");
		}
		//}

	}
	private IEnumerator ShopInformationE ()
	{
		string url = Link.url + "get_list_shop_epic";
		WWWForm form = new WWWForm ();
		form.AddField (Link.ID, PlayerPrefs.GetString(Link.ID));
		form.AddField ("SHOP_JENIS", "");
		WWW www = new WWW(url,form);
		yield return www;
		if (www.error == null) {
			Debug.Log (www.text);
			var jsonString = JSON.Parse (www.text);
			PlayerPrefs.SetString (Link.FOR_CONVERTING, jsonString["ID_SHOP_SPECIAL"]);
			//	if (PlayerPrefs.GetString(Link.FOR_CONVERTING)=="1") {

			GameObject[] entry;
			entry = new GameObject[int.Parse(jsonString["count"])];
			for (int x = RShop.childCount - 1; x >= 0; x--) {
				Destroy (RShop.GetChild (x).gameObject);
			}
			for (int x = 0; x < int.Parse(jsonString["count"]); x++) {
		
				//builder.AddProduct (jsonString ["data"] [x] ["ProductID"], ProductType.Consumable);
			
				entry [x] = Instantiate (ShopItemR);
				entry [x].GetComponent<ShopItem> ().shoptype=jsonString["data"][x]["shoptype"];
				entry [x].GetComponent<ShopItem> ().iapname=jsonString ["data"] [x] ["ProductID"];
				//entry [x].GetComponent<ShopItem> ().icon_item.transform.gameObject.SetActive (true);
				entry[x].GetComponent<ShopItem>().gambaritem.GetComponent<Image>().sprite =  Resources.Load<Sprite>("icon_item/" + jsonString["data"][x]["Type"]);
				entry [x].GetComponent<ShopItem> ().Shop = this.gameObject;

				entry[x].GetComponent<ShopItem>().idItem  	  = jsonString["data"][x]["ID"];
				entry[x].GetComponent<ShopItem>().namaItem.text 	  = jsonString["data"][x]["Type"]+"\n"+jsonString["data"][x]["Quantity"];
				entry[x].GetComponent<ShopItem>().fileItem 	  = jsonString["data"][x]["ItemFile"];
				entry[x].GetComponent<ShopItem>().hargaItem.text 	  = jsonString["data"][x]["Price"];
				entry [x].GetComponent<ShopItem> ().zoomItem = zoomitem3;
				entry [x].GetComponent<ShopItem> ().ItemName = zoomitem3.GetComponent<ShopItem>().ItemName;
				entry [x].GetComponent<ShopItem> ().ItemPrice = zoomitem3.GetComponent<ShopItem>().ItemPrice;
				//entry[x].GetComponent<ShopItem>().ItemType 	  = jsonString["data"][x]["ItemType"];
				//entry[x].GetComponent<ShopItem>().ItemLevel   = jsonString["data"][x]["ItemLevel"];

				entry [x].GetComponent<ShopItem> ().AttackItem.text = jsonString ["data"] [x] ["ItemAttack"];
				entry [x].GetComponent<ShopItem> ().DefenseItem.text = jsonString ["data"] [x] ["ItemDefense"];
				entry [x].GetComponent<ShopItem> ().StaminaItem.text = jsonString ["data"] [x] ["ItemStamina"];
				entry[x].GetComponent<ShopItem>().TnCItem.text 	  = jsonString["data"][x]["TnC"];
				//	entry[x].GetComponent<ShopItem>().ItemDefense = jsonString["data"][x]["ItemDefense"];
				//	entry[x].GetComponent<ShopItem>().ItemStamina = jsonString["data"][x]["ItemStamina"];

				PlayerPrefs.SetString (Link.FOR_CONVERTING, jsonString["data"][x]["ItemType"]);
				entry [x].transform.SetParent (RShop, false);
				//					if (PlayerPrefs.GetString (Link.FOR_CONVERTING) == "Gold") {
				//						entry [x].transform.SetParent (GShop, false);
				//					} 
				//					else if (PlayerPrefs.GetString (Link.FOR_CONVERTING) == "Crystal") {
				//						entry [x].transform.SetParent (CShop, false);
				//					} 
				//					else {
				//						entry [x].transform.SetParent (RShop, false);
				//					}

			}
		} 
		else {
			Debug.Log ("GAGAL");
		}
		//}

	}
	public void CrystalShopCek(){
		StartCoroutine (ShopInformationC ());
	}
	public void SpecialShopCek(){
		StartCoroutine (ShopInformationG ());
	}
	public void EpicShopCek(){
		
		StartCoroutine (ShopInformationE ());
	}
	public void NaturalShopCek(){
		StartCoroutine (ShopInformationC ());
	}
	public void SomeShopCek(){
		StartCoroutine (ShopInformationC ());
	}
}
