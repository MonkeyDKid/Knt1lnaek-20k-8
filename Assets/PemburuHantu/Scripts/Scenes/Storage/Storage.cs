using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using SimpleJSON;
using System.Collections;


public class Storage : MonoBehaviour
{

	public ContentController contentController;
	public GameObject Item, hantuList, equipmentButton,ErrorCode, ValidationError;
    public GameObject bintang1stats,bintang2stats,bintang3stats,bintang4stats,bintang5stats,loading;
	public Text hantuName, attack, defense, hp,level,type ;
	private bool toHome = true;
	public GameObject show;
	public string hantuPlayerId, hantuGrade;
	public string file;
	//test
	public EXPdistribution exps;
	public HantuLore LoreScript;


	public void OnEquipmentClick () {
		PlayerPrefs.SetString (Link.FOR_CONVERTING, hantuPlayerId);
		PlayerPrefs.SetString (Link.FOR_CONVERTING_2, file);
		SceneManagerHelper.LoadScene ("Equipment");
	}

	public void OnBack () {
		SceneManagerHelper.LoadScene ("Home");
	}


	private void Start () {
		//StartCoroutine (GetHantuUserLocal ());
		StartCoroutine (GetHantuUser ());
		if (SceneManager.GetActiveScene().name=="EXPDis") {
			exps=GameObject.Find ("ExpDistribution").GetComponent<EXPdistribution>();
		}
	}

	public void Reload () {
		StartCoroutine (GetHantuUser ());
	}

	public IEnumerator GetHantuNextLevel ()
	{
		string url = Link.url + "getDataHantuUser";
		WWWForm form = new WWWForm ();
		form.AddField (Link.ID, PlayerPrefs.GetString(Link.ID));
		WWW www = new WWW(url,form);
		yield return www;
		Debug.Log (www.text);
		if (www.error == null) {
			var jsonString = JSON.Parse (www.text);
			PlayerPrefs.SetString (Link.FOR_CONVERTING, jsonString["code"]);
			if (PlayerPrefs.GetString (Link.FOR_CONVERTING) == "0") {
			
			}
            else if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == "33")
            {
                ValidationError.SetActive(true);
            }
        } else {
			Debug.Log ("Gagal le");
		}
	}
	public IEnumerator GetHantuUser ()
	{
		

		string url = Link.url + "getDataHantuUser";
		WWWForm form = new WWWForm ();
		form.AddField (Link.ID, PlayerPrefs.GetString(Link.ID));
        form.AddField("DID", PlayerPrefs.GetString(Link.DEVICE_ID));
        WWW www = new WWW(url,form);
		yield return www;
		Debug.Log (www.text);
		if (www.error == null) {
			var jsonString = JSON.Parse (www.text);
			PlayerPrefs.SetString (Link.FOR_CONVERTING, jsonString ["code"]);
			if (PlayerPrefs.GetString (Link.FOR_CONVERTING) == "0") {
			
				for (int x = contentController.Content.childCount - 1; x >= 0; x--) {
					Destroy (contentController.Content.GetChild (x).gameObject);
				}
				GameObject[] entry;
				entry = new GameObject[int.Parse (jsonString ["count"])];

				for (int x = 0; x < int.Parse (jsonString ["count"]); x++) {

					entry [x] = Instantiate (Item);
					entry [x].GetComponent<StorageItem> ().icon.sprite = Resources.Load<Sprite> ("icon_char/" + jsonString ["data"] [x] ["HantuFile"]);

					entry [x].GetComponent<StorageItem> ().PlayerHantuId = jsonString ["data"] [x] ["HantuPlayerID"];
					entry [x].GetComponent<StorageItem> ().hantuId = jsonString ["data"] [x] ["HantuId"];
					entry [x].GetComponent<StorageItem> ().hantuGrade = jsonString ["data"] [x] ["HantuGrade"];
					entry [x].GetComponent<StorageItem> ().name = jsonString ["data"] [x] ["HantuNama"];
					entry [x].GetComponent<StorageItem> ().file = jsonString ["data"] [x] ["HantuFile"];
					entry [x].GetComponent<StorageItem> ().Level.text = jsonString ["data"] [x] ["HantuLevel"];
					entry [x].GetComponent<StorageItem> ().type = jsonString ["data"] [x] ["HantuType"];

					entry [x].GetComponent<StorageItem> ().attack = int.Parse (jsonString ["data"] [x] ["HantuAttack"]);
					entry [x].GetComponent<StorageItem> ().defense = int.Parse (jsonString ["data"] [x] ["HantuDefense"]);
					entry [x].GetComponent<StorageItem> ().stamina = int.Parse (jsonString ["data"] [x] ["HantuStamina"]);

					//misal posisi monster saat ini level 1
					entry [x].GetComponent<StorageItem> ().Targetnextlevel = jsonString ["data"] [x] ["Targetnextlevel"];   //misal ini 450 adalah level 2
					entry [x].GetComponent<StorageItem> ().Targetlusalevel = jsonString ["data"] [x] ["Targetlusalevel"];   //yg ini 960 adalah level 3 (baru sy buatkan di API)
                                                                                                                            //nah, animasinya kalo udh mentok 450, 
                                                                                                                            //barnya ulang dari 0 kan ya. akhirnya jangan 450 lg, 
                                                                                                                            //tp ambil yg 960, kan udah naik level.
                    if (int.Parse(jsonString["data"][x]["HantuStat"]) == 1)
                    {
                        entry[x].transform.Find("NewStat").gameObject.SetActive(true);
                    }
                    else {
                        entry[x].transform.Find("NewStat").gameObject.SetActive(false);
                    }


                    entry [x].GetComponent<StorageItem> ().exp = jsonString ["data"] [x] ["monstercurrentexp"];


					entry [x].transform.SetParent (contentController.Content, false);
					if (SceneManager.GetActiveScene ().name == "EXPDis") {

						if (int.Parse (jsonString ["data"] [x] ["HantuPlayerID"]) == int.Parse (exps.idhantuplayer)) {
							Debug.Log ("getin");
							exps.att = jsonString ["data"] [x] ["HantuAttack"];
							exps.def = jsonString ["data"] [x] ["HantuDefense"];
							exps.stam = jsonString ["data"] [x] ["HantuStamina"];

							//exps.Targetnextlevel=float.Parse(jsonString["data"][x]["Targetnextlevel"]); 
							//exps.att.text  = jsonString["data"][x]["HantuAttack"];
							//exps.def.text  = jsonString["data"][x]["HantuDefense"];
//exps.stam.text = jsonString["data"][x]["HantuStamina"];
						}
					}
					var nilai = int.Parse (jsonString ["count"]) - 1;

				

				}
			}
            else if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == "33")
            {
                ValidationError.SetActive(true);
                loading.SetActive(false);
            }
            else {
                Debug.Log("GAGAL");
                //ErrorCode.transform.FindChild ("Dialog").gameObject.SetActive (true);
                //ErrorCode.SetActive (true);
                ValidationError.SetActive(true);
            }
			yield return new WaitForSeconds (.5f);
			ErrorCode.SetActive (false);
			loading.SetActive (false);
		} else {
			ErrorCode.transform.Find ("Dialog").gameObject.SetActive (true);
			ErrorCode.SetActive (true);
		}
	}


	private IEnumerator GetHantuUserLocal ()
	{
		GameObject[] entry;
		entry = new GameObject[6];

		//for (int x = 0; x < 6; x++) {
			entry [0] = Instantiate (Item);
			entry [1] = Instantiate (Item);
			entry [2] = Instantiate (Item);
			entry [3] = Instantiate (Item);
			entry [4] = Instantiate (Item);
		entry [5] = Instantiate (Item);

			entry[0].GetComponent<StorageItem>().icon.sprite = Resources.Load<Sprite>("icon_char/" + "Kunti_Fire");
			entry[1].GetComponent<StorageItem>().icon.sprite = Resources.Load<Sprite>("icon_char/" + "Genderuwo_Fire");
			entry[0].GetComponent<StorageItem>().PlayerHantuId = "PemburuHantu";
			entry[0].GetComponent<StorageItem>().hantuId = "H001";
			entry[0].GetComponent<StorageItem>().name 	  = "Kuntilanak";
			entry[0].GetComponent<StorageItem>().file 	  = "Kunti_Fire";
			entry[0].GetComponent<StorageItem>().Level.text   = "40";
			entry[0].GetComponent<StorageItem>().type 	  = "Fire";

			entry[0].GetComponent<StorageItem>().attack  = 400;
		entry[0].GetComponent<StorageItem>().defense = 400;
		entry[0].GetComponent<StorageItem>().stamina = 400;

			entry[0].transform.SetParent (contentController.Content, false);


			entry[1].GetComponent<StorageItem>().PlayerHantuId = "PemburuHantu";
			entry[1].GetComponent<StorageItem>().hantuId = "H002";
			entry[1].GetComponent<StorageItem>().name 	  = "Genderuwo";
			entry[1].GetComponent<StorageItem>().file 	  = "Genderuwo_Fire";
			entry[1].GetComponent<StorageItem>().Level.text   = "40";
			entry[1].GetComponent<StorageItem>().type 	  = "Fire";

		entry[1].GetComponent<StorageItem>().attack  = 400;
		entry[1].GetComponent<StorageItem>().defense = 400;
		entry[1].GetComponent<StorageItem>().stamina = 400;

			entry[1].transform.SetParent (contentController.Content, false);
			entry[2].GetComponent<StorageItem>().icon.sprite = Resources.Load<Sprite>("icon_char/" + "Pocong_Fire");

			entry[2].GetComponent<StorageItem>().PlayerHantuId = "PemburuHantu";
			entry[2].GetComponent<StorageItem>().hantuId = "H003";
			entry[2].GetComponent<StorageItem>().name 	  = "Pocong";
			entry[2].GetComponent<StorageItem>().file 	  = "Pocong_Fire";
			entry[2].GetComponent<StorageItem>().Level.text   = "40";
			entry[2].GetComponent<StorageItem>().type 	  = "Fire";

		entry[2].GetComponent<StorageItem>().attack  = 400;
		entry[2].GetComponent<StorageItem>().defense = 400;
		entry[2].GetComponent<StorageItem>().stamina = 400;

			entry[2].transform.SetParent (contentController.Content, false);
			entry[3].GetComponent<StorageItem>().icon.sprite = Resources.Load<Sprite>("icon_char/" + "SusterNgesot_Fire");

			entry[3].GetComponent<StorageItem>().PlayerHantuId = "PemburuHantu";
			entry[3].GetComponent<StorageItem>().hantuId = "H004";
			entry[3].GetComponent<StorageItem>().name 	  = "Suster Ngesot";
			entry[3].GetComponent<StorageItem>().file 	  = "SusterNgesot_Fire";
			entry[3].GetComponent<StorageItem>().Level.text   = "40";
			entry[3].GetComponent<StorageItem>().type 	  = "Fire";

		entry[3].GetComponent<StorageItem>().attack  = 400;
		entry[3].GetComponent<StorageItem>().defense = 400;
		entry[3].GetComponent<StorageItem>().stamina = 400;

			entry[3].transform.SetParent (contentController.Content, false);
			entry[4].GetComponent<StorageItem>().icon.sprite = Resources.Load<Sprite>("icon_char/" + "Babingepet_Fire");

			entry[4].GetComponent<StorageItem>().PlayerHantuId = "PemburuHantu";
			entry[4].GetComponent<StorageItem>().hantuId = "H005";
			entry[4].GetComponent<StorageItem>().name 	  = "Babi Ngepet";
			entry[4].GetComponent<StorageItem>().file 	  = "Babingepet_Fire";
			entry[4].GetComponent<StorageItem>().Level.text   = "40";
			entry[4].GetComponent<StorageItem>().type 	  = "Fire";

		entry[4].GetComponent<StorageItem>().attack  = 400;
		entry[4].GetComponent<StorageItem>().defense = 400;
		entry[4].GetComponent<StorageItem>().stamina = 400;

			entry[4].transform.SetParent (contentController.Content, false);
			entry[5].GetComponent<StorageItem>().icon.sprite = Resources.Load<Sprite>("icon_char/" + "Kolorijo_Fire");

			entry[5].GetComponent<StorageItem>().PlayerHantuId = "PemburuHantu";
			entry[5].GetComponent<StorageItem>().hantuId = "H006";
			entry[5].GetComponent<StorageItem>().name 	  = "Kolor Ijo";
			entry[5].GetComponent<StorageItem>().file 	  = "Kolorijo_Fire";
			entry[5].GetComponent<StorageItem>().Level.text   = "40";
			entry[5].GetComponent<StorageItem>().type 	  = "Fire";

		entry[5].GetComponent<StorageItem>().attack  = 400;
		entry[5].GetComponent<StorageItem>().defense = 400;
		entry[5].GetComponent<StorageItem>().stamina = 400;

			entry[5].transform.SetParent (contentController.Content, false);
			yield return null;
	//	}

	}
	public void Update(){
		int test;
		var angka = int.TryParse( hantuGrade,out test);
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
	}


}

