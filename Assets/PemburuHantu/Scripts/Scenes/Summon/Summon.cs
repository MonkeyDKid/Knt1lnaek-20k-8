using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System.Collections;
using System.Text;
using UnityEngine.SceneManagement;


public class Summon : MonoBehaviour
{
	public Text Gold, Crystal;
	public SummoningItem SummonItem;
	//public Text SoulStone;
	public Button OKCatch;
	public GameObject Summonsd, Summonings,Summoned, validationerror;
	public GameObject[] SummonedGhosts;
	public ParticleSystem[] p;
	public GameObject soundBG, model,mycamera,FirstTimerSummon,summoneffect,sei;
	public firstimersummon firstTimerSummonScript;
	public GameObject SummonParticlePrefab;
	public Text Common, Rare, Legendary;
	public Sprite CommonIcon, RareIcon, LegendaryIcon;
	public Image icon;
	public string[] SummonedGhost;
	public GameObject statusAktif;
	private string jenis;
	public int tutorHitung;
	public Text header;
	public Text info;
	public bool Summons,berburu;

	[Header("Data Monster Summon")]
	public string Grade, Level, Name, Type, Element;
	void Start () 
	{
        PlayerPrefs.SetString("SummonStats", "Idling");
        //PlayerPrefs.SetString ("PLAY_TUTORIAL", "TRUE");
        Debug.Log(PlayerPrefs.GetString ("PLAY_TUTORIAL"));
		tutorHitung = PlayerPrefs.GetInt ("tutorhitung");
		if(PlayerPrefs.GetInt ("Catched") == 0 || !PlayerPrefs.HasKey("Catched") )
		{
			Summonsd.SetActive(true);
		
	
		if (PlayerPrefs.GetString ("PLAY_TUTORIAL") == "TRUE") {
			if (PlayerPrefs.HasKey ("tutorhitung")) {
				tutorHitung = PlayerPrefs.GetInt ("tutorhitung");
				if (tutorHitung > 3) {
					tutorHitung = 3;
						PlayerPrefs.SetString ("SummonTutor", "UDAH");
						SceneManagerHelper.StopTutorial ();
						//next.SetActive(true);
						firstTimerSummonScript.position = 3;
				}

			}
			SceneManagerHelper.LoadTutorial ("Summon");
			//firstTimerSummonScript.gameObject.SetActive (true);
		} 
		else {
			
			firstTimerSummonScript.gameObject.SetActive (false);
		}

		StartCoroutine (updateData ());
		//OnClickCommon ();
		Gold.text = PlayerPrefs.GetString (Link.GOLD);
		Crystal.text = PlayerPrefs.GetString ("Crystal");
		Common.text = PlayerPrefs.GetString (Link.COMMONGem);
		Rare.text = PlayerPrefs.GetString (Link.RAREGem);
		Legendary.text = PlayerPrefs.GetString (Link.LEGENDARYGem);
		//SoulStone.text = PlayerPrefs.GetString (Link.SOUL_STONE);

		icon.sprite = CommonIcon;
		jenis = "COMMON";
		header.text = "SUMMON " + jenis;
	
		Debug.Log (PlayerPrefs.GetString (Link.GOLD) + "/" + PlayerPrefs.GetString (Link.COMMONGem) );


		if (int.Parse (PlayerPrefs.GetString (Link.GOLD)) >= 20 && int.Parse (PlayerPrefs.GetString (Link.COMMONGem)) >= 1) {
			
			statusAktif.SetActive (false);
		} else {
			statusAktif.SetActive (true);

		}
			}
			else
			{
				OKCatch.onClick.AddListener(Unload);
				if(PlayerPrefs.GetInt("Rarity")==0)
				{
					jenis = "COMMON";
				}
				else if(PlayerPrefs.GetInt("Rarity")==1)
				{
					jenis = "RARE";
				}
				else
				{
					jenis = "LEGENDARY";
				}

				OnClickSummoned();

			}

	}
	public void OnClickSummoned () {

		summontutorialhitung();
		
		if(Summons==false)
		{
		if (jenis == "COMMON") {
			var winning = Random.value;
				int choice = 0 ;

				if (winning > .4f) 
				{
					choice = Random.Range (0, 5);


				} 
				else if (winning < .4f && winning > .1f) 
				{
					choice = Random.Range (6, 9);
				} 
				else if (winning > 0 && winning < .1f)
				{
					choice = Random.Range (10, 11);
				}
			
				StartCoroutine (WaitSummon());
				StartCoroutine(SendXpp(100));
		} 
			else if (jenis == "RARE") {
				
				var winning = Random.value;
				int choice = 0 ;
				if (winning > .4f) 
				{
					choice = Random.Range (12, 29);


				} 
				else if (winning < .4f && winning > .1f) 
				{
					choice = Random.Range (30, 39);


				} 
				else if (winning > 0 && winning < .1f)
				{

					choice = Random.Range (40, 43);

				}
				StartCoroutine (WaitSummon());
				StartCoroutine(SendXpp(150));
				}
			else {
				var winning = Random.value;
				int choice = 0 ;
				if (winning > .4f) 
				{
					choice = Random.Range (30, 45);


				} 
				else if (winning < .4f && winning > .1f) 
				{
					choice = Random.Range (46, 53);


				} 
				else if (winning > 0 && winning < .1f)
				{

					choice = Random.Range (54, 56);

				}
				StartCoroutine (WaitSummon());
				StartCoroutine(SendXpp(200));
		}
		Summons = true;
	}
	}

public void dummyButton()
{
	PlayerPrefs.SetString ("PLAY_TUTORIAL","TRUE");
	tutorHitung = 0;
	string fakeJson = "{Hantu:[{hantufile:Pocong_Fire}{hantufile:Pocong_Water}{hantufile:Pocong_Wind}]}";
	Summoning(fakeJson);
}

	public void Summoning(string ghost){
		

	
		if (PlayerPrefs.GetString ("PLAY_TUTORIAL") == "TRUE") 
		{
				var jsonString = JSON.Parse (ghost);
			for(int i = 0; i<3; i++)
			{
				var models = Instantiate (Resources.Load ("PrefabsChar/" + jsonString["Hantu"][i]["hantufile"]) as GameObject,  new Vector3(0f,0f,0f), Quaternion.identity);
				models.transform.SetParent (mycamera.transform);
				models.transform.localPosition =mycamera.transform.Find ("SummonPos").transform.localPosition;
				models.transform.localScale = mycamera.transform.Find ("SummonPos").transform.localScale;
				models.transform.localEulerAngles = mycamera.transform.Find ("SummonPos").transform.localEulerAngles;
				models.name = "ghost";
				models.transform.SetParent (mycamera.transform.Find ("SummonPos"));
				SummonedGhosts[i] = models;
				switch(i)
				{
					case 0 :
					models.transform.localPosition = new Vector3(0.62f,0,0);
					models.transform.localEulerAngles = new Vector3(0,-30,0);

					break;
					case 1 :
					models.transform.localPosition = new Vector3(0, 0, 0);
					break;
					case 2 :
					models.transform.localPosition = new Vector3(-0.62f,0,0);
					models.transform.localEulerAngles = new Vector3(0,30,0);

					break; 
					default :
					break;

				}
				//models.SetActive (false);
				summontutorialhitung();
				

				//StartCoroutine (sendSummon(jsonString["Hantu"][i],jenis,model));
			}

			SummonEffect();

		}
		else
		{
			model = Instantiate (Resources.Load ("PrefabsChar/" + ghost) as GameObject,  new Vector3(0f,0f,0f), Quaternion.identity);
			model.transform.SetParent (mycamera.transform);
			model.transform.localPosition =mycamera.transform.Find ("SummonPos").transform.localPosition;
			model.transform.localScale = mycamera.transform.Find ("SummonPos").transform.localScale;
			model.transform.localEulerAngles = mycamera.transform.Find ("SummonPos").transform.localEulerAngles;
			model.name = "ghost";
			model.transform.SetParent (mycamera.transform.Find ("SummonPos"));
			model.SetActive (false);

			StartCoroutine (sendSummon(ghost,jenis,model));
		}	
	}

	public void SummonEffect()
	{
		p[0].Play();
		p[1].Play();
		p[2].Play();	
		for(int i=0;i<3;i++)
		{
			SummonedGhosts[i].SetActive(true);
			SummonedGhosts[i].GetComponent<Animation> ().PlayQueued ("select", QueueMode.PlayNow);
			SummonedGhosts[i].GetComponent<Animation> ().PlayQueued ("idle");
		}
		
	}

	public void summontutorialhitung(){
		tutorHitung += 1;
		PlayerPrefs.SetInt ("tutorhitung", tutorHitung);
		if (PlayerPrefs.GetInt ("tutorhitung") >= 3 || tutorHitung >=3) {
			if(PlayerPrefs.GetString ("PLAY_TUTORIAL")== "TRUE")
			{
				PlayerPrefs.SetString ("SummonTutor", "UDAH");
				//next.SetActive(true);
				firstTimerSummonScript.position = 3;

			}
		}
	}
	public void Cleaner(){
		
		if (mycamera.transform.Find ("SummonPos").transform.childCount > 0) {
			Destroy (mycamera.transform.Find ("SummonPos").transform.Find ("ghost").gameObject);
		} else {
			//nothing to see here
		}
		if (mycamera.transform.Find ("SummonedPos").transform.childCount > 0) {
			Destroy (mycamera.transform.Find ("SummonedPos").transform.Find ("ghost").gameObject);
		} else 
		{
			//nothing to see here
		}
		Name = "";
		Summoned.transform.Find ("backname").transform.Find ("Namegreen").transform.Find ("Name").GetComponent<Text> ().text = Name;
		Summonings.transform.Find ("backname").transform.Find ("Namegreen").transform.Find ("Name").GetComponent<Text> ().text = Name;
		Summonings.transform.Find ("bintangsusunstats").transform.Find ("bintang1").gameObject.SetActive (false);
		Summoned.transform.Find ("bintangsusunstats").transform.Find ("bintang1").gameObject.SetActive (false);
		Summonings.transform.Find ("bintangsusunstats").transform.Find ("bintang2").gameObject.SetActive (false);
		Summoned.transform.Find ("bintangsusunstats").transform.Find ("bintang2").gameObject.SetActive (false);
		Summonings.transform.Find ("bintangsusunstats").transform.Find ("bintang3").gameObject.SetActive (false);
		Summoned.transform.Find ("bintangsusunstats").transform.Find ("bintang3").gameObject.SetActive (false);
		Summonings.transform.Find ("bintangsusunstats").transform.Find ("bintang4").gameObject.SetActive (false);
		Summoned.transform.Find ("bintangsusunstats").transform.Find ("bintang4").gameObject.SetActive (false);
		Summonings.transform.Find ("bintangsusunstats").transform.Find ("bintang5").gameObject.SetActive (false);
		Summoned.transform.Find ("bintangsusunstats").transform.Find ("bintang5").gameObject.SetActive (false);

		Summonings.transform.Find ("backname").transform.Find ("Fire").gameObject.SetActive (false);
		Summoned.transform.Find ("backname").transform.Find ("Fire").gameObject.SetActive (false);
		Summonings.transform.Find ("backname").transform.Find ("Wind").gameObject.SetActive (false);
		Summoned.transform.Find ("backname").transform.Find ("Wind").gameObject.SetActive (false);
		Summonings.transform.Find ("backname").transform.Find ("Water").gameObject.SetActive (false);
		Summoned.transform.Find ("backname").transform.Find ("Water").gameObject.SetActive (false);
	
	}
	IEnumerator Wait(){
		yield return new WaitForSeconds (1);

	}
	public void Summoned_function(){
		
		//model.transform.SetParent (mycamera.transform);
		//model.transform.localPosition=mycamera.transform.FindChild ("SummonedPos").transform.localPosition;
		//model.transform.localScale=mycamera.transform.FindChild ("SummonedPos").transform.localPosition;
		//model.transform.localEulerAngles=mycamera.transform.FindChild ("SummonedPos").transform.localPosition;
		model.transform.SetParent (mycamera.transform.Find ("SummonedPos"));
		model.transform.localPosition = new Vector3 (0, 0, 0);
		model.transform.localRotation = Quaternion.Euler (0, 0, 0);
	}

	private IEnumerator sendSummon(string file, string jenis,GameObject model)
	{
		string url = Link.url + "tangkap_hantu";
		WWWForm form = new WWWForm ();
		form.AddField ("MY_ID", PlayerPrefs.GetString(Link.ID));
		form.AddField ("FILE", file);
		form.AddField ("JENIS", jenis);

		WWW www = new WWW(url,form);
		yield return www;
		if (www.error == null) {
            PlayerPrefs.SetString("SummonStats", "Summoned");
			//testsummonings
			model.SetActive(true);
			model.GetComponent<Animation> ().PlayQueued ("select", QueueMode.PlayNow);
			model.GetComponent<Animation> ().PlayQueued ("idle");
			p[1].Play ();
		//	StartCoroutine(Waitforsec());
			var jsonString = JSON.Parse (www.text);
			Debug.Log(jsonString ["data"] ["id"] );
			StartCoroutine(sendEXP(jsonString ["data"] ["id"] ,0));
			Debug.Log (www.text);
			file = file.Replace ("_Fire", "");
			file = file.Replace ("_Water", "");
			file = file.Replace ("_Wind", "");
			file = file.Replace ("_fire", "");
			file = file.Replace ("_water", "");
			file = file.Replace ("_wind", "");
			Debug.Log (file);
			if (file == "Kunti ") {
				file = "Kuntilanak";
			}
			if (file == "Babingepet ") {
				file = "Babi Ngepet";
			}
			if (file == "Hantutanpakepala ") {
				file = "Hantu tanpa kepala";
			}
			if (file == "SusterNgesot ") {
				file = "Suster Ngesot";
			}
			if (file == "nagabesukih ") {
				file = "Naga Besukih";
			}
			if (file == "Nyiroro ") {
				file = "Ratu Pantai";
			}
			if (file == "SundelBolong") {
				file = "Sundel Bolong";
			}
			if (file == "Kolorijo ") {
				file = "Kolor Ijo";
			}
			info.text = file;
			StartCoroutine (updateData ());
           // yield return new WaitForSeconds(.5f);
           Summonings.GetComponent<Button> ().enabled = true;

        } else {
		//failed
		}

	}

	IEnumerator Waitforsec(int choice){
		GameObject effect= Instantiate(summoneffect,sei.transform.position, Quaternion.identity) as GameObject;
		Summonings.SetActive (true);
		yield return new WaitForSeconds (3);
		
		Summonings.transform.Find ("Image").gameObject.SetActive (true);
		Summoning (SummonedGhost [choice]);
		PlayerPrefs.GetString (Link.BURU_FILE);

	}

		IEnumerator WaitSummon(){
		GameObject effect= Instantiate(summoneffect,sei.transform.position, Quaternion.identity) as GameObject;
		Summonings.SetActive (true);
		yield return new WaitForSeconds (3);
		
		Summonings.transform.Find ("Image").gameObject.SetActive (true);
		Summoning (PlayerPrefs.GetString (Link.BURU_FILE));
		//PlayerPrefs.GetString (Link.BURU_FILE);

	}
	IEnumerator SendXpp(int exp){

		WWWForm formkirimreward= new WWWForm();
		//var expsingle = PlayerPrefs.GetInt ("MAPSEXP") * 3;
		//	Debug.Log (expsingle);
		string url = Link.url + "send_xpp";
		//WWWForm form = new WWWForm ();
		//formkirimreward.AddField ("JumlahXpTransfer", (expsingle));
		formkirimreward.AddField ("MY_ID", PlayerPrefs.GetString(Link.ID));
		formkirimreward.AddField ("xpp", exp);
		//formkirimreward.AddField ("ITEM", equipmentreward[0]);
		WWW www = new WWW(url,formkirimreward);
		yield return www;
		if (www.error == null) {

		} 
		Debug.Log (www.text);
		//	var jsonString = JSON.Parse (www.text);
		//PlayerPrefs.SetString ("BATU", jsonString ["data"]);



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
			var jsonString = JSON.Parse (www.text);
			Debug.Log (jsonString);
			//PlayerPrefs.SetFloat("target", float.Parse(jsonString ["code"] ["Targetnextlevel"]));

			PlayerPrefs.SetString ("HantuSummonName", jsonString ["code"] ["HantuNama"]);
			PlayerPrefs.SetString ("HantuSummonLevel", jsonString ["code"] ["HantuLevel"]);
			PlayerPrefs.SetString ("HantuSummonGrade", jsonString ["code"] ["HantuGrade"]);
			PlayerPrefs.SetString ("HantuSummonType", jsonString ["code"] ["HantuType"]);
			PlayerPrefs.SetString ("HantuSummonElement", jsonString ["code"] ["HantuElement"]);
			PlayerPrefs.SetString ("HantuSummonHP", jsonString ["code"] ["HantuStamina"]);
			PlayerPrefs.SetString ("HantuSummonATT", jsonString ["code"] ["HantuAttack"]);
			PlayerPrefs.SetString ("HantuSummonDEF", jsonString ["code"] ["HantuDefense"]);
			Name = PlayerPrefs.GetString ("HantuSummonName");
			Level = PlayerPrefs.GetString ("HantuSummonLevel");
			Grade = PlayerPrefs.GetString ("HantuSummonGrade");
			Type = PlayerPrefs.GetString ("HantuSummonType");
			Element = PlayerPrefs.GetString ("HantuSummonElement");
			Summoned.transform.Find ("Info").transform.Find ("HP").GetComponent<Text> ().text = PlayerPrefs.GetString ("HantuSummonHP");
			Summoned.transform.Find ("Info").transform.Find ("Att").GetComponent<Text> ().text = PlayerPrefs.GetString ("HantuSummonATT");
			Summoned.transform.Find ("Info").transform.Find ("Def").GetComponent<Text> ().text = PlayerPrefs.GetString ("HantuSummonDEF");
			Summoned.transform.Find ("Info").transform.Find ("Type").GetComponent<Text> ().text = Type;
			Summoned.transform.Find ("backname").transform.Find ("Namegreen").transform.Find ("Name").GetComponent<Text> ().text = Name;
			Summoned.transform.Find ("Info").transform.Find ("Name").GetComponent<Text> ().text = Name;
			Summonings.transform.Find ("backname").transform.Find ("Namegreen").transform.Find ("Name").GetComponent<Text> ().text = Name;
			switch (int.Parse(Grade)) {
			case 1:
				Summonings.transform.Find ("bintangsusunstats").transform.Find ("bintang1").gameObject.SetActive (true);
				Summoned.transform.Find ("bintangsusunstats").transform.Find ("bintang1").gameObject.SetActive (true);
				break;
			case 2:
				Summonings.transform.Find ("bintangsusunstats").transform.Find ("bintang2").gameObject.SetActive (true);
				Summoned.transform.Find ("bintangsusunstats").transform.Find ("bintang2").gameObject.SetActive (true);
				break;
			case 3:
				Summonings.transform.Find ("bintangsusunstats").transform.Find ("bintang3").gameObject.SetActive (true);
				Summoned.transform.Find ("bintangsusunstats").transform.Find ("bintang3").gameObject.SetActive (true);
				break;
			case 4:
				Summonings.transform.Find ("bintangsusunstats").transform.Find ("bintang4").gameObject.SetActive (true);
				Summoned.transform.Find ("bintangsusunstats").transform.Find ("bintang4").gameObject.SetActive (true);
				break;
			case 5:
				Summonings.transform.Find ("bintangsusunstats").transform.Find ("bintang5").gameObject.SetActive (true);
				Summoned.transform.Find ("bintangsusunstats").transform.Find ("bintang5").gameObject.SetActive (true);
				break;
		

			}
			if (Type == "Fire") {
				Summonings.transform.Find ("backname").transform.Find ("Fire").gameObject.SetActive (true);
				Summoned.transform.Find ("backname").transform.Find ("Fire").gameObject.SetActive (true);
			}
			if (Type == "Water") {
				Summonings.transform.Find ("backname").transform.Find ("Water").gameObject.SetActive (true);
				Summoned.transform.Find ("backname").transform.Find ("Water").gameObject.SetActive (true);
			}
			if (Type == "Wind") {
				Summonings.transform.Find ("backname").transform.Find ("Wind").gameObject.SetActive (true);
				Summoned.transform.Find ("backname").transform.Find ("Wind").gameObject.SetActive (true);
			}


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
            PlayerPrefs.SetString("SummonStats", "Idling");
            var jsonString = JSON.Parse(www.text);
            Debug.Log(jsonString);
            PlayerPrefs.SetString(Link.FOR_CONVERTING, jsonString["code"]);
            if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == "0")
            {

                PlayerPrefs.SetString(Link.ENERGY, jsonString["data"]["energy"]);
                PlayerPrefs.SetString(Link.GOLD, jsonString["data"]["coin"]);
                PlayerPrefs.SetString("Crystal", jsonString["data"]["crystal"]);
                PlayerPrefs.SetString(Link.COMMONGem, jsonString["data"]["CommonGem"]);
                PlayerPrefs.SetString(Link.RAREGem, jsonString["data"]["RareGem"]);
                PlayerPrefs.SetString(Link.LEGENDARYGem, jsonString["data"]["LegendaryGem"]);


                Gold.text = PlayerPrefs.GetString(Link.GOLD);
                Common.text = PlayerPrefs.GetString(Link.COMMONGem);
                Rare.text = PlayerPrefs.GetString(Link.RAREGem);
                Legendary.text = PlayerPrefs.GetString(Link.LEGENDARYGem);
                Summons = false;
            }
            else if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == "33")
            {
                validationerror.SetActive(true);
            }
        } 

	}

		
	public void OnBack () {
		SceneManagerHelper.LoadScene ("Home");
		
	}

private void Unload () {
		PlayerPrefs.SetInt ("Catched",0);
		SceneManager.UnloadSceneAsync("Summon");
	}



}

