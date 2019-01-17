using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System.Collections;


public class Summonmanual: MonoBehaviour
{
	public Text Gold;
	//public Text SoulStone;

	public ParticleSystem p;
	public GameObject soundBG, model,mycamera,FirstTimerSummon;
	public firstimersummon firstTimerSummonScript;
	//
	public Text Common, Rare, Legendary;
	public Sprite CommonIcon, RareIcon, LegendaryIcon;
	public Image icon;
	public string[] SummonedGhost;
	public GameObject statusAktif;
	private string jenis;
	int tutorHitung;
	public Text header;
	public Text info;
	//sementara
	public int uang,batuc,batur,batul;
	void Start () {
		StartCoroutine (updateData ());
		//PlayerPrefs.SetString ("PLAY_TUTORIAL", "TRUE");
		if (PlayerPrefs.GetString ("PLAY_TUTORIAL") == "TRUE") {
			firstTimerSummonScript.gameObject.SetActive (true);
		} else {
			firstTimerSummonScript.gameObject.SetActive (false);}
		//StartCoroutine ( GetDataUser ());
		uang=int.Parse(PlayerPrefs.GetString(Link.GOLD));
		batuc=int.Parse(PlayerPrefs.GetString(Link.COMMON));
		batur=int.Parse(PlayerPrefs.GetString(Link.RARE));
		batul=int.Parse(PlayerPrefs.GetString(Link.LEGENDARY));

		Gold.text = PlayerPrefs.GetString (Link.GOLD);
		Common.text = PlayerPrefs.GetString (Link.COMMON);
		Rare.text = PlayerPrefs.GetString (Link.RARE);
		Legendary.text = PlayerPrefs.GetString (Link.LEGENDARY);
		//SoulStone.text = PlayerPrefs.GetString (Link.SOUL_STONE);

		icon.sprite = CommonIcon;
		jenis = "COMMON";
		header.text = "SUMMON " + jenis;

		Debug.Log (PlayerPrefs.GetString (Link.GOLD) + "/" + PlayerPrefs.GetString (Link.COMMON) );


		if (int.Parse (PlayerPrefs.GetString (Link.GOLD)) >= 20 && int.Parse (PlayerPrefs.GetString (Link.COMMON)) >= 20) {
			
			statusAktif.SetActive (false);
		} else {
			statusAktif.SetActive (true);

		}

	}
	void Update(){
		if (uang < 20) {
			if (jenis == "COMMON" && batuc < 20) {
				statusAktif.SetActive (true);
			}
			else if (jenis == "RARE" && batuc < 20) {
				statusAktif.SetActive (true);
			}
			else if (jenis == "LEGENDARY" && batul < 20) {
				statusAktif.SetActive (true);
			} else {
				statusAktif.SetActive (false);
			}
		} else {
			statusAktif.SetActive (false);
		}

	}

	public void OnClickCommon () {
		jenis = "COMMON";
		header.text = "SUMMON " + jenis;
		icon.sprite = CommonIcon;
//		if (int.Parse (PlayerPrefs.GetString (Link.GOLD)) >= 20 && int.Parse (PlayerPrefs.GetString (Link.COMMON)) >= 20) {
//			
//			statusAktif.SetActive (false);
//		} else {
//			statusAktif.SetActive (true);
//		}
	}

	public void OnClickRare () {
		jenis = "RARE";
		header.text = "SUMMON " + jenis;
		icon.sprite = RareIcon;
//		if (int.Parse (PlayerPrefs.GetString (Link.GOLD)) >= 20 && int.Parse (PlayerPrefs.GetString (Link.RARE)) >= 20) {
//			statusAktif.SetActive (false);
//		} else {
//			
//			statusAktif.SetActive (true);
//		}
	}

	public void OnClickLegendary () {
		jenis = "LEGENDARY";
		header.text = "SUMMON " + jenis;
		icon.sprite = LegendaryIcon;
//		if (int.Parse (PlayerPrefs.GetString (Link.GOLD)) >= 20 && int.Parse (PlayerPrefs.GetString (Link.LEGENDARY)) >= 20) {
//			statusAktif.SetActive (false);
//		} else {
//			
//			statusAktif.SetActive (true);
//		}
	}

	public void OnClickSummon () {
		uang -= 20;
		if (jenis == "COMMON" && batuc > 20) {
			batuc -= 20;
			int choice = Random.Range (0, 6);
			Summoning (SummonedGhost [choice]);
		} else if (jenis == "RARE" && batur > 20) {
			batur -= 20;
			int choice = Random.Range (7, 12);
			Summoning (SummonedGhost [choice]);
		} else {
			if (batul > 20) {
				batul -= 20;
				int choice = Random.Range (13, 19);
				Summoning (SummonedGhost [choice]);
			}
		}
	}
		
	public void Summoning(string ghost){
		p.Play ();
		if (mycamera.transform.Find ("SummonPos").transform.childCount > 0) {
			Destroy (mycamera.transform.Find ("SummonPos").transform.Find ("ghost").gameObject);
		} else {
			//nothing to see here
		}

		model = Instantiate (Resources.Load ("PrefabsChar/" + ghost) as GameObject,  new Vector3(0f,0f,0f), Quaternion.identity);
		model.transform.SetParent (mycamera.transform);
		model.transform.localPosition =mycamera.transform.Find ("SummonPos").transform.localPosition;
		model.transform.localScale = mycamera.transform.Find ("SummonPos").transform.localScale;
		model.transform.localEulerAngles = mycamera.transform.Find ("SummonPos").transform.localEulerAngles;
		model.name = "ghost";
		model.transform.SetParent (mycamera.transform.Find ("SummonPos"));

		//ss.Summon (ghost);
		// ini terusin ke mana???

		StartCoroutine (sendSummon(ghost,jenis));
		tutorHitung += 1;
		if (tutorHitung == 3) {
			if(PlayerPrefs.GetString ("PLAY_TUTORIAL")== "TRUE"){
			//PlayerPrefs.SetString ("SummonTutor", "UDAH");
			//next.SetActive(true);
			firstTimerSummonScript.position = 3;

		}
		}
	
	}

	private IEnumerator sendSummon(string file, string jenis)
	{
		string url = Link.url + "send_summon";
		WWWForm form = new WWWForm ();
		form.AddField ("MY_ID", PlayerPrefs.GetString(Link.ID));
		form.AddField ("FILE", file);
		form.AddField ("JENIS", jenis);

		WWW www = new WWW(url,form);
		yield return www;
		if (www.error == null) {
			info.text = file;
			StartCoroutine (updateData());
		} 

	}

	private IEnumerator updateData()
	{

		string url = Link.url + "login";
		WWWForm form = new WWWForm ();
		form.AddField (Link.DEVICE_ID, PlayerPrefs.GetString(Link.DEVICE_ID));
		form.AddField (Link.EMAIL, PlayerPrefs.GetString(Link.EMAIL));
		form.AddField (Link.PASSWORD, PlayerPrefs.GetString(Link.PASSWORD));

		Debug.Log (PlayerPrefs.GetString(Link.ID));

		WWW www = new WWW(url,form);
		yield return www;
		if (www.error == null) {
			//StartCoroutine (getDataBatu());

			Debug.Log ("UPDATE SUCCESS");

			var jsonString = JSON.Parse (www.text);
			Debug.Log (www.text);

			PlayerPrefs.SetString (Link.GOLD, jsonString["data"]["coin"]);
			PlayerPrefs.SetString (Link.COMMON, jsonString["data"]["common"]);
			PlayerPrefs.SetString (Link.RARE, jsonString["data"]["rare"]);
			PlayerPrefs.SetString (Link.LEGENDARY, jsonString["data"]["legendary"]);

			Gold.text = PlayerPrefs.GetString (Link.GOLD);
			Common.text = PlayerPrefs.GetString (Link.COMMON);
			Rare.text = PlayerPrefs.GetString (Link.RARE);
			Legendary.text = PlayerPrefs.GetString (Link.LEGENDARY);

			if (jenis == "COMMON") {
				OnClickCommon ();
			} else if (jenis == "RARE") {
				OnClickRare ();
			} else {
				OnClickLegendary ();
			}

		} 

	}

		
	public void OnBack () {
		SceneManagerHelper.LoadScene ("Home");
	}


}

