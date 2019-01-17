using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
public class Leaderboard : MonoBehaviour {
	public GameObject datashop, dataRank,validationerror;
	public Transform ShopParent,RankParent;
	public Text APText,myrank,mylevel,myAR;
    public Image Profile;
    public ScrollRect scrollbar;
    // Use this for initialization
    void Start () {
        if (PlayerPrefs.GetString("Base64PictureProfile") != "")
        {
            byte[] b64_bytes = System.Convert.FromBase64String(PlayerPrefs.GetString("Base64PictureProfile"));
            Texture2D tex = new Texture2D(1, 1);
            tex.LoadImage(b64_bytes);

            var rect = new Rect(0, 0, tex.width, tex.height);

            if (tex.height != 8)
            {
                Profile.overrideSprite = Sprite.Create(tex, rect, Vector2.zero, 128.0f);
            }
            else {
                //anotherpopup.SetActive (true);
            }
        }
        //StartCoroutine (GetShopByClass ());
        //StartCoroutine (updateData ());
        StartCoroutine (GetRanking ());
		myAR.text=PlayerPrefs.GetString (Link.AR);
		myrank.text="Hunter";
		mylevel.text=PlayerPrefs.GetString ("PlayerLevel");
	}
	
	// Update is called once per frame
	void Update () {
		print(scrollbar.normalizedPosition);
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
                PlayerPrefs.SetString(Link.AP, jsonString["data"]["ap"]);
                PlayerPrefs.SetString(Link.AR, jsonString["data"]["ar"]);
                APText.text = "Arena Point : " + jsonString["data"]["ap"];
            }
            else if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == "33")
            {
                validationerror.SetActive(true);
            }
        } 

	}
	private IEnumerator GetShopByClass ()
	{
		string url = Link.url + "getItemShop";
		WWWForm form = new WWWForm ();
		form.AddField ("AR", PlayerPrefs.GetString(Link.AR));
		form.AddField (Link.ID, PlayerPrefs.GetString(Link.ID));
		WWW www = new WWW(url,form);
		yield return www;
		if (www.error == null) {
			Debug.Log (www.text);
		
			var jsonString = JSON.Parse (www.text);
			PlayerPrefs.SetString (Link.FOR_CONVERTING, jsonString["code"]);
			if (PlayerPrefs.GetString(Link.FOR_CONVERTING)=="0") {

				GameObject[] entry;
				entry = new GameObject[int.Parse(jsonString["count"])];

				for (int x = 0; x < int.Parse(jsonString["count"]); x++) {
					entry [x] = Instantiate (datashop);

					entry [x].GetComponent<EquipmentItem> ().icon_item.transform.gameObject.SetActive (true);
					entry[x].GetComponent<EquipmentItem>().icon_item.sprite =  Resources.Load<Sprite>("icon_item/" + jsonString["data"][x]["ItemFile"]);


					entry[x].GetComponent<EquipmentItem>().ItemId  	  = jsonString["data"][x]["ItemId"];
					entry[x].GetComponent<EquipmentItem>().ItemName 	  = jsonString["data"][x]["ItemNama"];
					entry[x].GetComponent<EquipmentItem>().ItemFile 	  = jsonString["data"][x]["ItemFile"];
					entry[x].GetComponent<EquipmentItem>().name.text 	  = jsonString["data"][x]["ItemNama"];

					entry[x].GetComponent<EquipmentItem>().type.text 	  = jsonString["data"][x]["ItemType"];
					//entry[x].GetComponent<EquipmentItem>().ItemLevel   = jsonString["data"][x]["ItemLevel"];

					entry[x].GetComponent<EquipmentItem>().price.text  = jsonString["data"][x]["ItemAttack"];
					entry[x].GetComponent<EquipmentItem>().stats.text = "Attack "+jsonString["data"][x]["ItemAttack"]+", Defense "+jsonString["data"][x]["ItemDefense"]+", Stamina "+ jsonString["data"][x]["ItemStamina"];
					//entry[x].GetComponent<EquipmentItem>().ItemStamina = jsonString["data"][x]["ItemStamina"];

					PlayerPrefs.SetString (Link.FOR_CONVERTING, jsonString["data"][x]["ItemType"]);


					entry [x].transform.SetParent (ShopParent, false);
				
				}

			}
		} else {
			Debug.Log ("GAGAL");
		}
	}

	private IEnumerator GetRanking ()
	{
		string url = Link.url + "leaderboard";
		WWWForm form = new WWWForm ();
		form.AddField (Link.ID, PlayerPrefs.GetString(Link.ID));
        form.AddField("DID", PlayerPrefs.GetString(Link.DEVICE_ID));
        WWW www = new WWW(url,form);
		yield return www;
        Debug.Log(www.text);
        if (www.error == null) {
			Debug.Log (www.text);

			var jsonString = JSON.Parse (www.text);
			PlayerPrefs.SetString (Link.FOR_CONVERTING, jsonString["code"]);
            if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == "33")
            {
                validationerror.SetActive(true);
            }
         
			//Debug.Log (www.text);
           
            else {
                //	if (PlayerPrefs.GetString (Link.FOR_CONVERTING) == "0") {
                var angka = int.Parse(jsonString["count"]) - 1;
                GameObject[] entry;
                entry = new GameObject[angka];
                for (int x = 0; x < angka; x++)
                {
                    entry[x] = Instantiate(dataRank);
                    entry[x].GetComponent<UserRankItem>().Name.text = jsonString["data"][x]["full_name"];
                    entry[x].GetComponent<UserRankItem>().Rank.text = (1 + x).ToString();
                    entry[x].GetComponent<UserRankItem>().Record.text = jsonString["data"][x]["ar"];
                    //PlayerPrefs.SetString (Link.FOR_CONVERTING, jsonString["data"][x]["ItemType"]);
                    entry[x].transform.SetParent(RankParent, false);

                    //				if (jsonString ["data"] [x] ["id"] == PlayerPrefs.GetString (Link.ID)) {
                    //					myAR.text=jsonString ["data"] [x] ["ar"];
                    //
                    //				}
                }
            }

//			} else {
//				Debug.Log ("GAGAL");
//			}
		} else {
			Debug.Log ("GAGAL");
		}
	}
}
