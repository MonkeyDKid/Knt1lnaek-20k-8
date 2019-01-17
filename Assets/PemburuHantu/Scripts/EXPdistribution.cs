using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System.Collections;

public class EXPdistribution : MonoBehaviour {
	public int MonsterLevel,MonsterEXP,MonsterGrade;
	public float monstercurrentexp,tempmonsterexp;
	public float CurrentbankExp;
	public float Targetnextlevel,Targetlusalevel;
	public string idhantuplayer,type;
	public bool choose=false;
	public Image EXPBar;
	public GameObject effect,positionspawn,validationerror;
	public Text bankEXP,Level,Mexp;
	public string att, def, stam;
	public Storage gethantuuser;
	public StorageItem gethantunextlevel;
	//ini baru
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

            var jsonString = JSON.Parse(www.text);
            Debug.Log(jsonString);
            PlayerPrefs.SetString(Link.FOR_CONVERTING, jsonString["code"]);
            if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == "0")
            {
                CurrentbankExp = float.Parse(jsonString["data"]["xpm"]);
                bankEXP.text = CurrentbankExp.ToString();
            }
          

        
        //Debug.Log (www.text);
        //	bankEXP.text = jsonString ["data"] ["xpm"];
       
              else if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == "33")
            {
                validationerror.SetActive(true);
            }
        } 

	}

	// Use this for initialization
	void Start () {
		//MonsterLevel = 1;
		StartCoroutine (updateData());

		gethantuuser = GameObject.Find ("Storage").GetComponent<Storage>();
	//	gethantunextlevel = GameObject.Find ("StorageItem(Clone)").GetComponent<StorageItem> ();
		EXPBar.fillAmount=0;
		MonsterEXP = 0;
		//CurrentbankExp = 5000;
		//Targetnextlevel = 1300;
		//monstercurrentexp = 1000;
		Level.text = "";
	}

	void buttonactivate(){
		transform.Find ("1000").GetComponent<Button> ().interactable = true;
		transform.Find ("100").GetComponent<Button> ().interactable = true;
		transform.Find ("10").GetComponent<Button> ().interactable = true;
	}
	void buttondeactivate(){
		transform.Find ("1000").GetComponent<Button> ().interactable = false;
		transform.Find ("100").GetComponent<Button> ().interactable = false;
		transform.Find ("10").GetComponent<Button> ().interactable = false;
	}
	// Update is called once per frame
	void Update () {


	

		if (choose) {


			float fExp = MonsterEXP / Targetnextlevel;
			//Debug.Log (fExp);
			EXPBar.fillAmount = fExp;
			bankEXP.text = CurrentbankExp.ToString ();
			Level.text = MonsterLevel.ToString ();
			Mexp.text = MonsterEXP + "/" + Targetnextlevel.ToString ();

			if (MonsterEXP >= Targetnextlevel) {
			
				tempmonsterexp = monstercurrentexp - Targetnextlevel;

				MonsterEXP = (int)tempmonsterexp;
				monstercurrentexp = tempmonsterexp;

				MonsterLevel += 1;
				MonsterEXP = (int)Mathf.MoveTowards (0, monstercurrentexp, 10);
			}
	
			MonsterEXP = (int)Mathf.MoveTowards (MonsterEXP, monstercurrentexp, 10);
			//Debug.Log (MonsterEXP);
			// untuk effect level up
			if (EXPBar.fillAmount >= 1f) {
				Debug.Log ("levelup");
				GameObject blam = Instantiate (effect, positionspawn.transform);
				gethantuuser.attack.text = att;
				gethantuuser.defense.text = def;
				gethantuuser.hp.text = stam;
				//gethantunextlevel.OnClick ();
				gethantuuser.Reload ();
				Targetnextlevel = PlayerPrefs.GetFloat("target");
			
			} else {
			
				
			}
			switch (MonsterGrade) {
			case 1:
				if (MonsterLevel == 15) {
					Level.text = "Max";
					Mexp.text = "Max";

					EXPBar.fillAmount = 1;
					buttondeactivate ();
				} else {
					buttonactivate ();
				}
				break;
			case 2:
				if (MonsterLevel == 20) {
					Level.text = "Max";
					Mexp.text = "Max";
					EXPBar.fillAmount = 1;
					buttondeactivate ();
				} else {
					buttonactivate ();
				}
				break;
			case 3:
				if (MonsterLevel == 25) {
					Level.text = "Max";
					Mexp.text = "Max";
					EXPBar.fillAmount = 1;
					buttondeactivate ();
				} else {
					buttonactivate ();
				}
				break;
			case 4:
				if (MonsterLevel == 30) {
					Level.text = "Max";
					Mexp.text = "Max";
					EXPBar.fillAmount = 1;
					buttondeactivate ();
				} else {
					buttonactivate ();
				}
				break;
			case 5:
				if (MonsterLevel == 35) {
					Level.text = "Max";
					Mexp.text = "Max";
					EXPBar.fillAmount = 1;
					buttondeactivate ();
				} else {
					buttonactivate ();
				}
				break;
			case 6:
				if (MonsterLevel == 40) {
					Level.text = "Max";
					Mexp.text = "Max";
					EXPBar.fillAmount = 1;
					buttondeactivate ();
				} else {
					buttonactivate ();
				}
				break;
			}
			if (CurrentbankExp < 1000) {
			
				transform.Find ("1000").GetComponent<Button> ().interactable = false;
		
				if (CurrentbankExp < 100) {
					transform.Find ("100").GetComponent<Button> ().interactable = false;
					if (CurrentbankExp < 10) {

						transform.Find ("10").GetComponent<Button> ().interactable = false;
					}
				}
			} else {
				buttonactivate ();
			}
		}
	}



	public void OnClick1000 () {
		
		if (CurrentbankExp != 0) {
			
			CurrentbankExp -= 1000;
			StartCoroutine (sendEXP (idhantuplayer, 1000));
			//StartCoroutine (testexp (idhantuplayer,0));
		} else {
			buttondeactivate ();
		}

	}

	public void OnClick100 () {
		if (CurrentbankExp !=0) {
			//monstercurrentexp += 100;
			CurrentbankExp -= 100;
			StartCoroutine (sendEXP (idhantuplayer, 100));

		} else {
			buttondeactivate ();
		}
	}

	public void OnClick10 () {
		if (CurrentbankExp != 0) {
			
			//monstercurrentexp += 10;
			CurrentbankExp -= 10;
			StartCoroutine (sendEXP (idhantuplayer, 10));
		} else {
			buttondeactivate ();
		}
	}
	private IEnumerator sendEXP(string hantuplayerid, int Exp)
	{

		Debug.Log ("TES");
		string url = Link.url + "send_xp";
		WWWForm form = new WWWForm ();
		form.AddField ("MY_ID", PlayerPrefs.GetString(Link.ID));
		form.AddField ("PlayerHantuID", hantuplayerid);
		form.AddField ("EXPERIENCE", Exp);
		//form.AddField ("CURRENTEXPB", Latestexpbank);

		WWW www = new WWW(url,form);
		yield return www;

		if (www.error == null) {
			Debug.Log (www.text);
			var jsonString = JSON.Parse (www.text);
			PlayerPrefs.SetFloat("target", float.Parse(jsonString ["code"] ["Targetnextlevel"]));

			monstercurrentexp += Exp;
			StartCoroutine (updateData ());
			gethantuuser.Reload ();

		} else {
			Debug.Log ("Failed kirim data");
			yield return new WaitForSeconds (5);
			StartCoroutine (updateData());

		}

	}

}
