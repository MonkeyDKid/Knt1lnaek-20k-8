using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;
using SimpleJSON;
public class ShopItem : MonoBehaviour {
	public bool beli;
	public Text namaItem,hargaItem,TnCItem,AttackItem,DefenseItem,StaminaItem,ItemName,ItemPrice,itemQuantity;
	public string idItem,fileItem,shoptype,iapname,itemnamenya, itemquantitynya;
	public Image gambaritem, currencyItem;
	public GameObject Shop, zoomItem,purchase,mybutton;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnClickBuy () {
		purchase.SetActive (true);

	}
	public void OnzoomItem () {
		if(shoptype=="epic"){
			
			zoomItem.GetComponent<ShopItem>().mybutton.GetComponent<IAPButton> ().productId = iapname;
		}
		zoomItem.GetComponent<ShopItem> ().AttackItem.text = AttackItem.text;
		zoomItem.GetComponent<ShopItem> ().gambaritem.GetComponent<Image> ().sprite = gambaritem.GetComponent<Image> ().sprite;
		zoomItem.GetComponent<ShopItem> ().shoptype = shoptype;
		zoomItem.GetComponent<ShopItem> ().idItem = idItem;
		zoomItem.GetComponent<ShopItem> ().namaItem.text = namaItem.text;
		zoomItem.GetComponent<ShopItem> ().fileItem = fileItem;
		zoomItem.GetComponent<ShopItem> ().iapname = iapname;
		zoomItem.GetComponent<ShopItem> ().hargaItem.text = hargaItem.text;
		zoomItem.GetComponent<ShopItem> ().DefenseItem.text = DefenseItem.text;
		zoomItem.GetComponent<ShopItem> ().StaminaItem.text =StaminaItem.text;
		zoomItem.GetComponent<ShopItem> ().TnCItem.text 	  =TnCItem.text;
		zoomItem.GetComponent<ShopItem> ().ItemName.text = namaItem.text + " "+itemquantitynya;
		zoomItem.GetComponent<ShopItem> ().ItemPrice.text = hargaItem.text;
		zoomItem.GetComponent<ShopItem> ().beli = beli;
        zoomItem.GetComponent<ShopItem>().itemQuantity.text = itemquantitynya;

        zoomItem.SetActive (true);
	}
	public void purchase_yes(){
		if (gameObject.name == "Backko" && gameObject.activeInHierarchy == true) {
			if (beli == false) {
				StartCoroutine (BuyItem (idItem));

				beli = true;
			}
			else {
				Shop.GetComponent<Shop> ().TransactionFailed2.SetActive (true);
			}
		}
		if (gameObject.name == "Backko2" && gameObject.activeInHierarchy == true) {
			if (beli == false) {
				StartCoroutine (BuyItem (idItem));

				beli = true;
			}
			else {
				Shop.GetComponent<Shop> ().TransactionFailed2.SetActive (true);
			}
		}
		if (gameObject.name == "Backko3IAP" && gameObject.activeInHierarchy == true) {
			if (beli == false) {
				StartCoroutine (BuyItem (idItem));

				//beli = true;
			}
			else {
				Shop.GetComponent<Shop> ().TransactionFailed2.SetActive (true);
			}
		}
	}
	public void purchase_no(){
		purchase.SetActive (false);
		zoomItem.SetActive (false);
	}
	private IEnumerator BuyItem(string file)
	{
		string url = Link.url + "purchase_shop_"+shoptype;
		WWWForm form = new WWWForm ();
		form.AddField ("ID", PlayerPrefs.GetString(Link.ID));
		form.AddField ("ID_SHOP_SPECIAL", file);

		//form.AddField ("JENIS", jenis);

		WWW www = new WWW(url,form);
		yield return www;
		Debug.Log (www.text);
		if (www.error == null) {
			var jsonString = JSON.Parse (www.text);
			var energy = int.Parse (jsonString ["data"] ["energy"]) + int.Parse (PlayerPrefs.GetString ("BonusEnergy"));
			Debug.Log (www.text);
			//info.text = file;
			PlayerPrefs.SetString(Link.COMMON, jsonString["data"]["common"]);
            PlayerPrefs.SetString(Link.RARE, jsonString["data"]["rare"]);
            PlayerPrefs.SetString(Link.LEGENDARY, jsonString["data"]["legendary"]);
			PlayerPrefs.SetString (Link.GOLD, jsonString ["data"] ["coin"]);
			PlayerPrefs.SetString (Link.ENERGY, energy.ToString ());
			PlayerPrefs.SetString ("Crystal", jsonString ["data"] ["crystal"]);
			if (int.Parse(jsonString ["status"]) == 1) {
                PlayerPrefs.SetString("BOUGHTCRYSTAL", "TRUE");
				Shop.GetComponent<Shop> ().TransactionSucceed.SetActive (true);

			}
		//	StartCoroutine (updateData ());

		 else {
				
					Shop.GetComponent<Shop> ().TransactionFailed.SetActive (true);

					//failed
			}
			beli = false;
		}
		else{
			Shop.GetComponent<Shop> ().TransactionFailed3.SetActive (true);
		}

	}

	private IEnumerator updateData()
	{

        string url = Link.url + "getDataUser";
        WWWForm form = new WWWForm();
        form.AddField(Link.ID, PlayerPrefs.GetString(Link.ID));
        form.AddField("DID", PlayerPrefs.GetString(Link.DEVICE_ID));
        WWW www = new WWW(url, form);
        yield return www;
        if (www.error == null)
        {
            //StartCoroutine (getDataBatu());

            Debug.Log ("UPDATE SUCCESS");

			var jsonString = JSON.Parse (www.text);
			Debug.Log (www.text);
            if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == "0")
            {
                PlayerPrefs.SetString(Link.GOLD, jsonString["data"]["coin"]);
                PlayerPrefs.SetString(Link.COMMON, jsonString["data"]["common"]);
                PlayerPrefs.SetString(Link.RARE, jsonString["data"]["rare"]);
                PlayerPrefs.SetString(Link.LEGENDARY, jsonString["data"]["legendary"]);
                beli = false;
            }
            else if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == "33")
            {
               // validationerror.SetActive(true);
            }
        } 

	}

}
