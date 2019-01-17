using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using SimpleJSON;
using System.Collections;


public class StorageItem : MonoBehaviour {

	public Image icon;
	public Text Level;
	public string PlayerHantuId;
	public string hantuId;
	public string hantuGrade;
	public string file;
	public string name;
	public string type;
	public string exp;
    public Text newhantu;
	public GameObject bintang1,bintang2,bintang3,bintang4,bintang5;

	public int attack;
	public int defense;
	public int stamina;

	public Storage cc;
	public EXPdistribution exps;
	public GameObject shadow;

	//INI baru
	public string Targetnextlevel;
	public string monstercurrentexp;

	public string Targetlusalevel;




	void Start () {
		cc = GameObject.Find ("Storage").GetComponent<Storage>();
		shadow = GameObject.Find ("Shadow");
		if (SceneManager.GetActiveScene().name=="EXPDis") {
			exps=GameObject.Find ("ExpDistribution").GetComponent<EXPdistribution>();
		}
	}


	public void Update() {

		var angka = int.Parse (hantuGrade);
		switch (angka) {

		case 1:
			bintang1.SetActive (true);
			bintang2.SetActive (false);
			bintang3.SetActive (false);
			bintang4.SetActive (false);
			bintang5.SetActive (false);
			break;
		case 2:
			bintang2.SetActive (true);
			bintang1.SetActive (false);
			bintang3.SetActive (false);
			bintang4.SetActive (false);
			bintang5.SetActive (false);
			break;
		case 3:
			bintang3.SetActive (true);
			bintang1.SetActive (false);
			bintang2.SetActive (false);
			bintang4.SetActive (false);
			bintang5.SetActive (false);
			break;
		case 4:
			bintang4.SetActive (true);
			bintang1.SetActive (false);
			bintang2.SetActive (false);
			bintang3.SetActive (false);
			bintang5.SetActive (false);
			break;
		case 5:
			bintang5.SetActive (true);
			bintang1.SetActive (false);
			bintang2.SetActive (false);
			bintang3.SetActive (false);
			bintang4.SetActive (false);
			break;

		}

	}
    IEnumerator NotNew()
    {
        string url = Link.url + "notnew";
        WWWForm form = new WWWForm();
        form.AddField("PlayerHantuID", PlayerHantuId);
        WWW www = new WWW(url, form);
        yield return www;
        Debug.Log(www.text);
        if (www.error == null)
        {
            var jsonString = JSON.Parse(www.text);
           int angka= int.Parse(jsonString["code"]);
            if (angka == 1)
            {
                newhantu.gameObject.SetActive(false);
                Debug.Log("gak baru lagi");
            }
        }
    }

	public void OnClick () {
        //StartCoroutine (cc.GetHantuUser ());
        if (newhantu.IsActive()) {
            StartCoroutine(NotNew());
        }
		if (SceneManager.GetActiveScene().name=="EXPDis") {
			if (PlayerHantuId == exps.idhantuplayer) {
				exps.Targetnextlevel = float.Parse (Targetnextlevel);
				if (float.Parse (Targetnextlevel) == 0) {
					exps.Targetnextlevel = 999999999f;
				}
			}
			exps.MonsterEXP = 0;
			exps.MonsterGrade = int.Parse(hantuGrade);
			exps.MonsterLevel =int.Parse( Level.text);
			exps.idhantuplayer = PlayerHantuId;
			exps.monstercurrentexp = float.Parse(exp);
			exps.Targetnextlevel = float.Parse(Targetnextlevel);
			exps.Targetlusalevel = float.Parse (Targetlusalevel);

			if (float.Parse (Targetnextlevel) == 0) {
				exps.Targetnextlevel = 999999999f;
			}

			//exps.monstercurrentexp = float.Parse(exp);
		//	exps.Level_simpan = Level;

			exps.choose = true;


		}
		else 
		{
			cc.LoreScript.GetHantuLore(name);
		}
		Debug.Log ("Hantu Id : " + hantuId);
		shadow.GetComponent<Image>().enabled=true;
		cc.hantuPlayerId = PlayerHantuId;
		cc.hantuGrade = hantuGrade;
		cc.file = file;
		cc.level.text = Level.text;
		cc.hantuName.text = name;
		cc.attack.text = attack.ToString();
		cc.defense.text = defense.ToString();
		cc.hp.text = stamina.ToString();
		cc.type.text = type;
		cc.equipmentButton.SetActive (true);
		
		if (type == "Fire") {
			GameObject.Find ("Storage").transform.Find ("MiddlePanel").transform.Find ("BackgroundInfoHantu").transform.Find ("backname").Find ("Fire").gameObject.SetActive (true);
			GameObject.Find ("Storage").transform.Find ("MiddlePanel").transform.Find  ("BackgroundInfoHantu").transform.Find ("backname").Find ("Water").gameObject.SetActive (false);
			GameObject.Find ("Storage").transform.Find ("MiddlePanel").transform.Find  ("BackgroundInfoHantu").transform.Find ("backname").Find ("Wind").gameObject.SetActive (false);
		} else if (type == "Water") {
			GameObject.Find ("Storage").transform.Find ("MiddlePanel").transform.Find  ("BackgroundInfoHantu").transform.Find  ("backname").Find ("Fire").gameObject.SetActive (false);
			GameObject.Find ("Storage").transform.Find ("MiddlePanel").transform.Find  ("BackgroundInfoHantu").transform.Find ("backname").Find ("Water").gameObject.SetActive (true);
			GameObject.Find ("Storage").transform.Find ("MiddlePanel").transform.Find  ("BackgroundInfoHantu").transform.Find  ("backname").Find ("Wind").gameObject.SetActive (false);
		} else {
			GameObject.Find ("Storage").transform.Find ("MiddlePanel").transform.Find  ("BackgroundInfoHantu").transform.Find ("backname").Find  ("Fire").gameObject.SetActive (false);
			GameObject.Find ("Storage").transform.Find ("MiddlePanel").transform.Find  ("BackgroundInfoHantu").transform.Find ("backname").Find  ("Water").gameObject.SetActive (false);
			GameObject.Find ("Storage").transform.Find ("MiddlePanel").transform.Find  ("BackgroundInfoHantu").transform.Find ("backname").Find  ("Wind").gameObject.SetActive (true);
		}
		PlayerPrefs.SetString ("monster", file);
		PlayerPrefs.SetString ("hantuplayerid", PlayerHantuId);

		foreach (Transform child in cc.show.transform) {
			GameObject.Destroy(child.gameObject);
		}

		GameObject model = Instantiate (Resources.Load ("PrefabsChar/" + file) as GameObject,  new Vector3(0f,0f,0f), Quaternion.identity);
		model.transform.SetParent (cc.show.transform);
		cc.show.transform.localEulerAngles = new Vector3 (0,200.2f,0);
		model.transform.localPosition = new Vector3 (0,0,0);
		model.transform.localScale = new Vector3 (1,1,1);
		model.transform.localEulerAngles = new Vector3 (0,0,0);
		model.GetComponent<Animation> ().PlayQueued ("idle");
		if (SceneManager.GetActiveScene().name=="EXPDis") {
			model.GetComponent<Animation> ().PlayQueued ("idle",QueueMode.PlayNow);
		}
	}

}
