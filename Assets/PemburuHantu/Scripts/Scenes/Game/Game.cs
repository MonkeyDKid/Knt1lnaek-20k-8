using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class Game : MonoBehaviour {

	[Header("Droprate")]
	public int[] ItemRate;
	public string[] ItemQuantity;
	public string[] ItemType;
	public string[] ItemName;
	public string[] ItemFileName;
	public int weightTotal;
 
    
	public int MonsterLevel1,MonsterEXP1,MonsterGrade1,MonsterLevel2,MonsterEXP2,MonsterGrade2,MonsterLevel3,MonsterEXP3,MonsterGrade3,attacking,mapexpsimpan;
	public float monstercurrentexp1,tempmonsterexp1,monstercurrentexp2,tempmonsterexp2,monstercurrentexp3,tempmonsterexp3,PlayerHPCurrent,PlayerHPMax,EnemiesHPCurrent,EnemiesHPMax;
	public float Targetnextlevel1, Targetnextlevel2, Targetnextlevel3;
	public int GetCritical;
	public int Strike_Ele=0;
	public string playerhantuid1,playerhantuid2,playerhantuid3,PlayerID,StageChoose;
    public GameObject bintang1, bintang2, bintang3, bintang4, bintang5,validationError;
   // public bool replay;
	public Image[] Rewards, DropRewardsImage;
	bool pressed=true;
	lifeless lf;
	public float times = 60;
	bool critical=false;
	public bool tanding=false;
	public bool level1 = false;
	bool data_belum_ada = true;
	bool panggil_url = false;
	bool repeat = true;
	bool ulang=false;
	bool auto = false;
	bool Ab = false;
	bool Bb = false;
	public GameObject waiting,CameraEnd,CameraEndA,EndOptionButton,ClaimUI,sh1,sh2,sh3,sh1a,sh2a,sh3a,bukuBB,trouble1, hasilburu;
	public LayerMask everything, monster;
	public GameObject[] EndOption;
	public TextMesh damageA, damageB;
	public float damage,damage2;
	public bool levelingmate;
	public WWWForm formkirimreward;
	public GameObject[] urutan1;
	public GameObject[] urutan2;
	public GameObject[] urutan3;
	public GameObject Aobject, Bobject, karaA, karaB;
	private Animation karaBanimation,model11a,model21a,model12a,model22a,model13a,model23a;
	private SkinnedMeshRenderer karaBskin,karaBbukuskin;
	public GameObject canvas1,canvas2,canvas3,canvas4,canvas5,canvas6;
	public GameObject Monster1GO, Monster2GO, Monster3GO,hantuchoose1, hantuchoose2, hantuchoose3,hantugo1,hantugo2,hantugo3,hantugom1,hantugom2,hantugom3;
	public Transform m1, m2, m3;
	public GameObject effect;
	public string[] suit1;
	public string[] suit2;
	public string[] suit3;

	public float[] health1;
	public float[] health2;
	public float[] health3;

	public GameObject[] healthBar1;
	public GameObject[] healthBar2;
	public GameObject[] healthBar3;

	public GameObject scrollBar,vs,speedOption;
	public string[] equipmentreward;
	public string[] itemsreward;

	public Sprite Charge;
	public Sprite Block;
	public Sprite Focus;

	public Image icon1;
	public Image icon2;
	public Image icon3;


	public float timer  =  3f;
	public bool timeUps = false;
	bool multitime=false;
	int nilai;

	public GameObject plihan1;
	public GameObject plihan2;
	public GameObject plihan3;


	public GameObject[] pilihanInputSuit;
	private List<string> alpha = new List<string>{"0","1","2"};

	public GameObject getReady;
	public bool getReadyStatus = false;

	public Sprite aIcon;
	public Sprite bIcon;
	public AudioClip[] Sfx;
	public AudioSource hitYa;

	//	int pos1_car1_int = 0;
	//	int pos1_car2_int = 0;
	//	int pos1_car3_int = 0;
	//
	//	int pos2_car1_int = 0;
	//	int pos2_car2_int = 0;
	//	int pos2_car3_int = 0;


	public GameObject healthA1, healthA2, healthA3,healthB1, healthB2, healthB3, firstTimerGame, CB, PlayerHP, EnemiesHP;




	public Text User1, debug,ClaimText,EXPValueText, joustingnameA,joustingnameB, joustingnameA1, joustingnameB1, joustingnameA2, joustingnameB2;
	public Text User2;
    public Vector3 joustingpostition;
	GameObject model1_1;
	GameObject model2_1;

	GameObject model1_2;
	GameObject model2_2;

	GameObject model1_3;
	GameObject model2_3;
	GameObject effect1_1;
	GameObject effect2_1;

	GameObject effect1_2;
	GameObject effect2_2;

	GameObject effect1_3;
	GameObject effect2_3;


	public ParticleSystem A;
	public ParticleSystem B;

	public ParticleSystem Charge_A;
	public ParticleSystem Charge_B;

	public ParticleSystem Seri_A;
	public ParticleSystem Seri_Adef;
	public ParticleSystem Seri_B;
	public ParticleSystem Seri_Bdef;

	public GameObject Nyala;
	bool presentDone;

	[Header("Diperlukan Untuk SELAIN JOUSTING")]
	public GameObject cameraA;
	public GameObject cameraB;
	public GameObject hospital, school, warehouse,oldhouse,bridge,graveyard,ArenaDuel,ArenaDuelAR;

	//Tambah New Variabel untuk JOUSTING
	[Header("Diperlukan Untuk JOUSTING")]
	public GameObject envi;
	public GameObject CameraAR,CameraAR2;
    public GameObject CameraTarget, FightingTarget;
	public GameObject hospitalAR;
    public GameObject h1cubea, h2cubea, h3cubea, h1cubeb, h2cubeb, h3cubeb;
	private bool ApakahCameraA = false;

	public Text dg;

void Awake()
{
	SetReward();
	SetLocation();
}

void SetLocation()
{
	var lokasi = PlayerPrefs.GetString (Link.LOKASI);
if (lokasi == "Warehouse") 
{
	warehouse.SetActive (true);
} 
else if (lokasi == "School") 
{
	school.SetActive (true);
} 
else if (lokasi == "Hospital") 
{
	hospital.SetActive (true);
} 
else if (lokasi == "Bridge") 
{
	bridge.SetActive (true);
} 
else if (lokasi == "Graveyard") 
{
	graveyard.SetActive (true);
}
else if (lokasi == "Old House") 
{
	oldhouse.SetActive (true);
}
else if (lokasi == "ArenaDuel") 
{
	ArenaDuel.SetActive (true);
}
else if (lokasi == "ArenaDuelAR")
{
    ArenaDuelAR.SetActive(true);
}

}
public void nextornot()
{
	int stage =  int.Parse(PlayerPrefs.GetString(Link.StageChoose));
	EndOption[2].SetActive (false);
	if(stage==5||stage==11||stage==17||stage==23||stage==29||stage==35)
	{
		EndOption[4].transform.position = EndOption[3].transform.position;
		EndOption[3].SetActive (false);
		
	}
		
}

	public void Dialogue(bool start)
{
	int stage =  int.Parse(PlayerPrefs.GetString(Link.Stage));
	int stageChoose =  int.Parse(PlayerPrefs.GetString(Link.StageChoose));
	print("Gaben {0}"+ stageChoose);
	if(!PlayerPrefs.HasKey("StageDialogueEnd"+stage.ToString()))
	{
		PlayerPrefs.SetString("StageDialogueEnd"+stage.ToString(),"False");
	}
	if(!PlayerPrefs.HasKey("StageDialogueStart"+stage.ToString()))
	{
		PlayerPrefs.SetString("StageDialogueStart"+stage.ToString(),"False");
	}
	bool test =  bool.Parse(PlayerPrefs.GetString("StageDialogueEnd"+stage.ToString()));
	bool cek =  bool.Parse(PlayerPrefs.GetString("StageDialogueStart"+stage.ToString()));
	
	switch(stage)
	{
		case 6:
			if(!test&&!start)
			{
				PlayerPrefs.SetString("StageDialogueEnd"+stage.ToString(),"True");
				SceneManagerHelper.LoadTutorial("OldHouseEnd");
			}
			else if(!cek&&start&&stageChoose==6)
			{
				print("here0");
				PlayerPrefs.SetString("StageDialogueStart"+stage.ToString(),"True");
				SceneManagerHelper.LoadTutorial("SchoolStart");
			}
			break;
		case 12:
			if(!test&&!start)
			{
				PlayerPrefs.SetString("StageDialogueEnd"+stage.ToString(),"True");
				SceneManagerHelper.LoadTutorial("SchoolEnd");
			}
			else if(!cek&&start&&stageChoose==12)
			{
				PlayerPrefs.SetString("StageDialogueStart"+stage.ToString(),"True");
				SceneManagerHelper.LoadTutorial("HospitalStart");
			}
			break;
		case 18:
			if(!test&&!start)
			{
				PlayerPrefs.SetString("StageDialogueEnd"+stage.ToString(),"True");
				SceneManagerHelper.LoadTutorial("HospitalEnd");
			}
			else if(!cek&&start&&stageChoose==18)
			{
				PlayerPrefs.SetString("StageDialogueStart"+stage.ToString(),"True");
				SceneManagerHelper.LoadTutorial("BridgeStart");
			}
			break;
		case 24:
			if(!test&&!start)
			{
				PlayerPrefs.SetString("StageDialogueEnd"+stage.ToString(),"True");
				SceneManagerHelper.LoadTutorial("BridgeEnd");
			}
			else if(!cek&&start&&stageChoose==24)
			{
				PlayerPrefs.SetString("StageDialogueStart"+stage.ToString(),"True");
				SceneManagerHelper.LoadTutorial("GraveyardStart");
			}
			break;
		case 30:
			if(!test&&!start)
			{
				PlayerPrefs.SetString("StageDialogueEnd"+stage.ToString(),"True");
				SceneManagerHelper.LoadTutorial("GraveyardEnd");
			}
			else if(!cek&&start&&stageChoose==30)
			{
				PlayerPrefs.SetString("StageDialogueStart"+stage.ToString(),"True");
				SceneManagerHelper.LoadTutorial("WarehouseStart");
			}
			break;
		case 36:
			if(!test&&!start)
			{
				PlayerPrefs.SetString("StageDialogueEnd"+stage.ToString(),"True");
				SceneManagerHelper.LoadTutorial("WarehouseEnd");
			}
			break;
	}
	
    
}
	private void TutorBuru()
	{
			hantugom1.transform.localPosition = new Vector3 (0,0.011f,-.523f);
			sh1a.transform.localPosition=new Vector3 (0,-0.033f,-.523f);
			Nyala.transform.Find ("HolyEffect2 (3)").gameObject.SetActive (false);
			Nyala.transform.Find ("HolyEffect2 (5)").gameObject.SetActive (false);
			PlayerPrefs.SetString (Link.POS_1_CHAR_2_FILE, "");
			PlayerPrefs.SetString (Link.POS_1_CHAR_3_FILE, "");
	}
	private void playoneshot(int whichSound)
	{
		hitYa.PlayOneShot(Sfx[whichSound]);
	}

	IEnumerator Played(){
		string url = Link.url + "statusberburu";
	
		formkirimreward.AddField ("MY_ID", PlayerID);
		formkirimreward.AddField ("ID_Bermain", PlayerPrefs.GetString ("ID_bermain"));
		WWW www = new WWW(url,formkirimreward);
		yield return www;
		if (www.error == null) {


		} 
		Debug.Log (www.text);
	}

    IEnumerator Stage()
    {
        string url = Link.url + "Stage";
        WWWForm form = new WWWForm();
        form.AddField("MY_ID", PlayerID);
        form.AddField("STAGE", StageChoose);
        WWW www = new WWW(url, form);
        yield return www;
        if (www.error == null)
        {
            var jsonString = JSON.Parse(www.text);
            int kode = int.Parse(jsonString["code"]);
            if (kode == 1)
            {
                PlayerPrefs.SetString(Link.Stage, jsonString["data"]["Stage"]);
             //   PlayerPrefs.SetString(Link.Replay, "TRUE");
            }
            else
            {
                Debug.Log("BackSound Jangkrink");
            }

        }
        Debug.Log(www.text);
    }
	
	private void NotGetCriticalAttack()
	{
		
		//cameraA.SetActive (true);
		cameraB.SetActive (true);
		cameraB.GetComponent<Camera> ().cullingMask = -139265;
		cameraB.transform.Find ("PlaneP").gameObject.SetActive (false);
		cameraA.transform.Find ("PlaneP").gameObject.SetActive (false);
		karaBbukuskin.enabled = false;
		karaA.transform.Find ("book001").GetComponent<SkinnedMeshRenderer> ().enabled = false;
		karaA.GetComponent<SkinnedMeshRenderer> ().enabled = false;
		karaBskin.enabled = false;
		//pilihanInputSuit [9].SetActive (true);
		//pilihanInputSuit [9].transform.FindChild ("VS").GetComponent<Animator> ().PlayInFixedTime ("versus animation", 0, 0);

		if (PlayerPrefs.GetString ("Urutan1m") == "Hantu1A") {
			hidegameobject(hantugom3,hantugom2);
			hantugom1.transform.localPosition = new Vector3 (0, 0.011f, -.523f);
			if (urutan1 [0].GetComponent<PlayAnimation> ().element == "Fire") {
		//		cameraA.transform.FindChild ("Plane").gameObject.SetActive (true);
			}
			if (urutan1 [0].GetComponent<PlayAnimation> ().element == "Water") {

		
		//		cameraA.transform.FindChild ("Plane2").gameObject.SetActive (true);
			}
			if (urutan1 [0].GetComponent<PlayAnimation> ().element == "Wind") {


		//		cameraA.transform.FindChild ("Plane3").gameObject.SetActive (true);
			}
		}
		if (PlayerPrefs.GetString ("Urutan1m") == "Hantu2A") {
			if (urutan1 [0].GetComponent<PlayAnimation> ().element == "Fire") {

		
		//		cameraA.transform.FindChild ("Plane").gameObject.SetActive (true);
			}
			if (urutan1 [0].GetComponent<PlayAnimation> ().element == "Water") {


		//		cameraA.transform.FindChild ("Plane2").gameObject.SetActive (true);
			}
			if (urutan1 [0].GetComponent<PlayAnimation> ().element == "Wind") {

		
		//		cameraA.transform.FindChild ("Plane3").gameObject.SetActive (true);
			}
			hidegameobject(hantugom1,hantugom3);
			hantugom2.transform.localPosition = new Vector3 (0, 0.011f, -.523f);
		}
		if (PlayerPrefs.GetString ("Urutan1m") == "Hantu3A") {
			if (urutan1 [0].GetComponent<PlayAnimation> ().element == "Fire") {


		//		cameraA.transform.FindChild ("Plane").gameObject.SetActive (true);
			}
			if (urutan1 [0].GetComponent<PlayAnimation> ().element == "Water") {


		//		cameraA.transform.FindChild ("Plane2").gameObject.SetActive (true);
			}
			if (urutan1 [0].GetComponent<PlayAnimation> ().element == "Wind") {


		//		cameraA.transform.FindChild ("Plane3").gameObject.SetActive (true);
			}
			hidegameobject(hantugom1,hantugom2);
			hantugom3.transform.localPosition = new Vector3 (0, 0.011f, -.523f);
		}
		if (PlayerPrefs.GetString ("Urutan1") == "Hantu1B") {
			
			hantugo1.transform.localPosition = new Vector3 (0f, 0.011f, 0.444f);
			//	hantugo1.SetActive (true);
			// if (urutan1 [1].GetComponent<PlayAnimation> ().element == "Fire") {

			// 	cameraB.transform.FindChild ("Plane").gameObject.SetActive (true);

			// }
			// if (urutan1 [1].GetComponent<PlayAnimation> ().element == "Water") {

			// 	cameraB.transform.FindChild ("Plane2").gameObject.SetActive (true);

			// }
			// if (urutan1 [1].GetComponent<PlayAnimation> ().element == "Wind") {

			// 	cameraB.transform.FindChild ("Plane3").gameObject.SetActive (true);

			// }
			Debug.Log (PlayerPrefs.GetString ("Suit1"));
			if (PlayerPrefs.GetString ("Suit1") != "Kosong") {
				hidegameobject(hantugo3,hantugo2);
			}
			//				hantugo2.transform.localPosition = new Vector3 (0f, 0.011f, 0.444f);
			//				hantugo3.transform.localPosition = new Vector3 (0f, 0.011f, 0.444f);
			//			

		} else if (PlayerPrefs.GetString ("Urutan1") == "Hantu2B") {
			hantugo2.transform.localPosition = new Vector3 (0f, 0.011f, 0.444f);
			if (urutan1 [1].GetComponent<PlayAnimation> ().element == "Fire") {

		//		cameraB.transform.FindChild ("Plane").gameObject.SetActive (true);

			}
			if (urutan1 [1].GetComponent<PlayAnimation> ().element == "Water") {

		//		cameraB.transform.FindChild ("Plane2").gameObject.SetActive (true);
			
			}
			if (urutan1 [1].GetComponent<PlayAnimation> ().element == "Wind") {

		//		cameraB.transform.FindChild ("Plane3").gameObject.SetActive (true);
			
			}
			//				hantugo1.transform.localPosition = new Vector3 (0f, 0.011f, 0.444f);


			if (PlayerPrefs.GetString ("Suit1") != "Kosong") {
				//hantugo1.SetActive (false);
				hidegameobject(hantugo1,hantugo3);
			}
			//				hantugo3.transform.localPosition = new Vector3 (0f, 0.011f, 0.444f);

		} else if (PlayerPrefs.GetString ("Urutan1") == "Hantu3B") {
			hantugo3.transform.localPosition = new Vector3 (0f, 0.011f, 0.444f);
			if (urutan1 [1].GetComponent<PlayAnimation> ().element == "Fire") {

		//		cameraB.transform.FindChild ("Plane").gameObject.SetActive (true);

			}
			if (urutan1 [1].GetComponent<PlayAnimation> ().element == "Water") {

		//		cameraB.transform.FindChild ("Plane2").gameObject.SetActive (true);

			}
			if (urutan1 [1].GetComponent<PlayAnimation> ().element == "Wind") {

		//		cameraB.transform.FindChild ("Plane3").gameObject.SetActive (true);
			
			}
		
			//				hantugo1.transform.localPosition = new Vector3 (0f, 0.011f, 0.444f);
			//
			//				hantugo2.transform.localPosition = new Vector3 (0f, 0.011f, 0.444f);

			if (PlayerPrefs.GetString ("Suit1") != "Kosong") {
				
				hidegameobject(hantugo1,hantugo2);
			}
		}
	//}
		 
	
		if (PlayerPrefs.GetInt ("pos") == 1) {
			cameraA.SetActive (true);
		} 
		else {
			cameraB.SetActive (true);
		}
		cameraB.transform.position = new Vector3 (8.75f, 9.98f, 12.7f);
		cameraB.transform.rotation = Quaternion.Euler (0, 295.4f, 0);

		scrollBar.SetActive (false);
		speedOption.SetActive (false);

		pilihanInputSuit [0].SetActive (false);
		pilihanInputSuit [1].SetActive (false);
		pilihanInputSuit [2].SetActive (false);
		//single player
		if(level1){
			effect1_1.SetActive (false);
			effect2_1.SetActive (false);
			effect1_2.SetActive (false);
			effect2_2.SetActive (false);
			effect1_3.SetActive (false);
			effect2_3.SetActive (false);
		}
	}
	private void GetCriticalAttack()
	{
		cameraA.SetActive (true);
		cameraB.SetActive (true);
		cameraB.GetComponent<Camera> ().cullingMask = -139265;
		cameraB.transform.Find ("PlaneP").gameObject.SetActive (false);
		cameraA.transform.Find ("PlaneP").gameObject.SetActive (false);
		karaBbukuskin.enabled = false;
		karaA.transform.Find ("book001").GetComponent<SkinnedMeshRenderer> ().enabled = false;
		karaA.GetComponent<SkinnedMeshRenderer> ().enabled = false;
		karaBskin.enabled = false;
		pilihanInputSuit [9].SetActive (true);
		pilihanInputSuit [9].transform.Find ("VS").GetComponent<Animator> ().PlayInFixedTime ("versus animation", 0, 0);

		if (PlayerPrefs.GetString ("Urutan1m") == "Hantu1A") {
			hidegameobject(hantugom3,hantugom2);
			hantugom1.transform.localPosition = new Vector3 (0, 0.011f, -.523f);
			if (urutan1 [0].GetComponent<PlayAnimation> ().element == "Fire") {

			
				cameraA.transform.Find ("Plane").gameObject.SetActive (true);
			}
			if (urutan1 [0].GetComponent<PlayAnimation> ().element == "Water") {

		
				cameraA.transform.Find ("Plane2").gameObject.SetActive (true);
			}
			if (urutan1 [0].GetComponent<PlayAnimation> ().element == "Wind") {


				cameraA.transform.Find ("Plane3").gameObject.SetActive (true);
			}
		}
		if (PlayerPrefs.GetString ("Urutan1m") == "Hantu2A") {
			if (urutan1 [0].GetComponent<PlayAnimation> ().element == "Fire") {

		
				cameraA.transform.Find ("Plane").gameObject.SetActive (true);
			}
			if (urutan1 [0].GetComponent<PlayAnimation> ().element == "Water") {


				cameraA.transform.Find ("Plane2").gameObject.SetActive (true);
			}
			if (urutan1 [0].GetComponent<PlayAnimation> ().element == "Wind") {

		
				cameraA.transform.Find ("Plane3").gameObject.SetActive (true);
			}
			hidegameobject(hantugom1,hantugom3);
			hantugom2.transform.localPosition = new Vector3 (0, 0.011f, -.523f);
		}
		if (PlayerPrefs.GetString ("Urutan1m") == "Hantu3A") {
			if (urutan1 [0].GetComponent<PlayAnimation> ().element == "Fire") {


				cameraA.transform.Find ("Plane").gameObject.SetActive (true);
			}
			if (urutan1 [0].GetComponent<PlayAnimation> ().element == "Water") {


				cameraA.transform.Find ("Plane2").gameObject.SetActive (true);
			}
			if (urutan1 [0].GetComponent<PlayAnimation> ().element == "Wind") {


				cameraA.transform.Find ("Plane3").gameObject.SetActive (true);
			}
			hidegameobject(hantugom1,hantugom2);
			hantugom3.transform.localPosition = new Vector3 (0, 0.011f, -.523f);
		}
		if (PlayerPrefs.GetString ("Urutan1") == "Hantu1B") {
			
			hantugo1.transform.localPosition = new Vector3 (0f, 0.011f, 0.444f);
			//	hantugo1.SetActive (true);
			if (urutan1 [1].GetComponent<PlayAnimation> ().element == "Fire") {

				cameraB.transform.Find ("Plane").gameObject.SetActive (true);

			}
			if (urutan1 [1].GetComponent<PlayAnimation> ().element == "Water") {

				cameraB.transform.Find ("Plane2").gameObject.SetActive (true);

			}
			if (urutan1 [1].GetComponent<PlayAnimation> ().element == "Wind") {

				cameraB.transform.Find ("Plane3").gameObject.SetActive (true);

			}
			Debug.Log (PlayerPrefs.GetString ("Suit1"));
			if (PlayerPrefs.GetString ("Suit1") != "Kosong") {
				hidegameobject(hantugo3,hantugo2);
			}
			//				hantugo2.transform.localPosition = new Vector3 (0f, 0.011f, 0.444f);
			//				hantugo3.transform.localPosition = new Vector3 (0f, 0.011f, 0.444f);
			//			

		} else if (PlayerPrefs.GetString ("Urutan1") == "Hantu2B") {
			hantugo2.transform.localPosition = new Vector3 (0f, 0.011f, 0.444f);
			if (urutan1 [1].GetComponent<PlayAnimation> ().element == "Fire") {

				cameraB.transform.Find ("Plane").gameObject.SetActive (true);

			}
			if (urutan1 [1].GetComponent<PlayAnimation> ().element == "Water") {

				cameraB.transform.Find ("Plane2").gameObject.SetActive (true);
			
			}
			if (urutan1 [1].GetComponent<PlayAnimation> ().element == "Wind") {

				cameraB.transform.Find ("Plane3").gameObject.SetActive (true);
			
			}
			//				hantugo1.transform.localPosition = new Vector3 (0f, 0.011f, 0.444f);


			if (PlayerPrefs.GetString ("Suit1") != "Kosong") {				
				hidegameobject(hantugo1,hantugo3);
			}
			//				hantugo3.transform.localPosition = new Vector3 (0f, 0.011f, 0.444f);

		} else if (PlayerPrefs.GetString ("Urutan1") == "Hantu3B") {
			hantugo3.transform.localPosition = new Vector3 (0f, 0.011f, 0.444f);
			if (urutan1 [1].GetComponent<PlayAnimation> ().element == "Fire") {

				cameraB.transform.Find ("Plane").gameObject.SetActive (true);

			}
			if (urutan1 [1].GetComponent<PlayAnimation> ().element == "Water") {

				cameraB.transform.Find ("Plane2").gameObject.SetActive (true);

			}
			if (urutan1 [1].GetComponent<PlayAnimation> ().element == "Wind") {

				cameraB.transform.Find ("Plane3").gameObject.SetActive (true);
			
			}
		
			//				hantugo1.transform.localPosition = new Vector3 (0f, 0.011f, 0.444f);
			//
			//				hantugo2.transform.localPosition = new Vector3 (0f, 0.011f, 0.444f);

			if (PlayerPrefs.GetString ("Suit1") != "Kosong") {
				hidegameobject(hantugo1,hantugo2);
			}
		}
	//}
		 
		if (suit1 [1] == "Charge") {
			hantuchoose1.SetActive (true);
            hantuchoose1.GetComponent<Animator>().Play("GuntingtestB", -1,0f);
        }
		if (suit1 [1] == "Focus") {
			hantuchoose2.SetActive (true);
            hantuchoose2.GetComponent<Animator>().Play("GuntingtestB", -1, 0f);
        }
		if (suit1 [1] == "Block") {
			hantuchoose3.SetActive (true);
            hantuchoose3.GetComponent<Animator>().Play("GuntingtestB", -1, 0f);
        }
		if (suit1 [0] == "Charge") {
			pilihanInputSuit[6].SetActive (true);
            pilihanInputSuit[6].GetComponent<Animator>().Play("Gunting2", -1, 0f);

        }
		if (suit1 [0] == "Focus") {
			pilihanInputSuit[7].SetActive (true);
            pilihanInputSuit[7].GetComponent<Animator>().Play("Gunting2", -1, 0f);
        }
		if (suit1 [0] == "Block") {
			pilihanInputSuit[8].SetActive (true);
            pilihanInputSuit[8].GetComponent<Animator>().Play("Gunting2", -1, 0f);
        }
		if (PlayerPrefs.GetInt ("pos") == 1) {
			cameraA.SetActive (true);
		} 
		else {
			cameraB.SetActive (true);
		}
		cameraA.GetComponent<Animator> ().SetBool ("idling", true);
		cameraB.GetComponent<Animator> ().SetBool ("idling", true);
		cameraB.transform.position = new Vector3 (8.75f, 9.98f, 12.7f);
		cameraB.transform.rotation = Quaternion.Euler (0, 295.4f, 0);

		scrollBar.SetActive (false);
		speedOption.SetActive (false);

		pilihanInputSuit [0].SetActive (false);
		pilihanInputSuit [1].SetActive (false);
		pilihanInputSuit [2].SetActive (false);
		//single player
		if(level1){
			effect1_1.SetActive (false);
			effect2_1.SetActive (false);
			effect1_2.SetActive (false);
			effect2_2.SetActive (false);
			effect1_3.SetActive (false);
			effect2_3.SetActive (false);
		}
	}
    void sebelumwar(int getCritical){
        if (PlayerPrefs.GetString(Link.SEARCH_BATTLE) == "JOUSTING") {
            CameraAR2.SetActive(false);
            joustingpostition = envi.transform.position;
            envi.transform.SetParent(FightingTarget.transform);
            envi.transform.localPosition = new Vector3(0, -0.001098633f, -6.103516e-05f);
            envi.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
		
		print(getCritical);
		if(getCritical<=1f)
		{ 
			GetCriticalAttack();
		}
		else
		{
		if (critical && attacking>=3 && PlayerPrefs.GetString(Link.JENIS) == "SINGLE") 
			{
				GetCriticalAttack();
			}
			else
			{
				NotGetCriticalAttack();
		}
		}
	}
	void sebelumwar2(){
        if (PlayerPrefs.GetString(Link.SEARCH_BATTLE) == "JOUSTING") {
            CameraAR2.SetActive(true);
            envi.transform.SetParent(CameraTarget.transform);
            envi.transform.localPosition = new Vector3(0, -0.001098633f, -6.103516e-05f);
            envi.transform.localRotation = Quaternion.Euler(0, 0, 0);
            //  envi.transform.position = joustingpostition;

        }
		if (PlayerPrefs.GetInt ("speedscale") == 1) {
			Time.timeScale = .6f;
		}
		pilihanInputSuit [9].SetActive (false);
		if (PlayerPrefs.GetInt ("pos") == 1) {
			cameraA.GetComponent<Animator> ().Play("New State");
			cameraB.SetActive(false);
		} 
		else {
			cameraB.GetComponent<Animator> ().Play("New State");
			cameraA.SetActive(false);
		}

		hantuchoose1.SetActive (false);
		hantuchoose2.SetActive (false);
		hantuchoose3.SetActive (false);
		pilihanInputSuit [6].SetActive (false);
		pilihanInputSuit [7].SetActive (false);
		pilihanInputSuit [8].SetActive (false);
		cameraB.GetComponent<Animator> ().SetBool ("Fighting", true);
		cameraA.GetComponent<Animator> ().SetBool ("Fighting", true);
//		hantugo1.transform.localPosition = new Vector3 (0f, 0.011f, 0.444f);
//		hantugo2.transform.localPosition = new Vector3 (0f, 0.011f, 0.444f);
//		hantugo3.transform.localPosition = new Vector3 (0f, 0.011f, 0.444f);

		pilihanInputSuit [0].SetActive (false);
		pilihanInputSuit [1].SetActive (false);
		pilihanInputSuit [2].SetActive (false);
		cameraB.transform.Find ("Plane").gameObject.SetActive (false);
		cameraB.transform.Find ("Plane2").gameObject.SetActive (false);
		cameraB.transform.Find ("Plane3").gameObject.SetActive (false);
		cameraA.transform.Find ("Plane").gameObject.SetActive (false);
		cameraA.transform.Find ("Plane2").gameObject.SetActive (false);
		cameraA.transform.Find ("Plane3").gameObject.SetActive (false);
//		hantuchoose1.SetActive (false);
//		hantuchoose2.SetActive (false);
//		hantuchoose3.SetActive (false);
		//Time.timeScale = 1f;

		cameraB.transform.position = new Vector3 (35, 9, 7);
		cameraB.transform.rotation = Quaternion.Euler (0, -100.8f, 0);
		
    }

	void Start () {
		//PlayerPrefs.SetString ("PLAY_TUTORIAL","TRUE");
		
		
		winner3.transform.Find("KartuHantu").GetComponent<Image>().overrideSprite=Resources.Load<Sprite>("icon_charLama/" + PlayerPrefs.GetString (Link.POS_1_CHAR_1_FILE));
        // PlayerPrefs.SetString(Link.Replay, "true");
        StageChoose = PlayerPrefs.GetString(Link.StageChoose);
        PlayerPrefs.SetString ("hantumusuh", "kosong");
		PlayerID = PlayerPrefs.GetString (Link.ID);
		mapexpsimpan = PlayerPrefs.GetInt ("MAPSEXP");
		Debug.Log (PlayerPrefs.GetInt ("MAPSEXP"));
		lf = GetComponent<lifeless> ();
		karaBbukuskin=karaB.transform.Find ("book001").GetComponent<SkinnedMeshRenderer> ();
		bukuBB=karaB.transform.Find ("book001").gameObject;

		karaBskin=karaB.GetComponent<SkinnedMeshRenderer> ();
		karaBanimation=karaB.GetComponent<Animation> ();
		PlayerPrefs.DeleteKey ("win");
		Debug.Log(	PlayerPrefs.HasKey("win"));
		PlayerPrefs.SetString ("Critical", "n");
		attacking = 0;

		//PlayerPrefs.DeleteAll ();
		//PlayerPrefs.SetString("PLAY_TUTORIAL","TRUE");
	
		if(PlayerPrefs.GetString ("berburu")=="ya")
		{
			PlayerPrefs.SetInt ("speedscale", 1);
			karaA.SetActive (false);

			karaBanimation.PlayQueued ("run", QueueMode.PlayNow);
			karaBanimation.PlayQueued ("idlegame", QueueMode.CompleteOthers);
			//PlayerPrefs.SetString (Link.POS_1_CHAR_1_FILE, "MukaraBta_Fire");
		
			TutorBuru();
            //var hantuburuname = PlayerPrefs.GetString(Link.POS_1_CHAR_1_FILE);
            //if (hantuburuname.Contains('_'))
            //{
            //    int index = hantuburuname.IndexOf('_');
            //    string result = hantuburuname.Substring(0, index);
            //    hasilburu.transform.FindChild("backname").FindChild("Namegreen").FindChild("Name").GetComponent<Text>().text = result;
            //}

        }
//		PlayerPrefs.SetString (Link.POS_1_CHAR_1_FILE, "MukaraBta_Fire");
//		PlayerPrefs.SetString (Link.POS_1_CHAR_2_FILE, "Kunti_fire");
//		PlayerPrefs.SetString (Link.POS_1_CHAR_3_FILE, "Genderuwo_Fire");
		//else
		PlayerPrefs.SetString("1player","selesai");
		PlayerPrefs.SetString("2player","selesai");
		PlayerPrefs.SetString("3player","selesai");
		PlayerPrefs.SetString("musuh1","selesai");
		PlayerPrefs.SetString("musuh2","selesai");
		PlayerPrefs.SetString("musuh3","selesai");

//untuk testing
		if (PlayerPrefs.GetString (Link.JENIS) == "SINGLE" && PlayerPrefs.GetString ("berburu") != "ya") {
			Dialogue(true);
          //  replay = bool.TryParse(PlayerPrefs.GetString(Link.Replay),out replay);
            PlayerPrefs.SetInt ("speedscale", 1);
			karaA.SetActive (false);
			karaB.SetActive (true);

			//karaB.transform.FindChild ("Buku").GetComponent<SkinnedMeshRenderer> ().updateWhenOffscreen = false;
			karaBanimation.PlayQueued ("run", QueueMode.PlayNow);
			karaBanimation.PlayQueued ("idlegame", QueueMode.CompleteOthers);

			//test
//			PlayerPrefs.SetString (Link.POS_1_CHAR_1_ATTACK, "500");//401 //483 //1248
//			PlayerPrefs.SetString (Link.POS_1_CHAR_1_DEFENSE, "100");
//			PlayerPrefs.SetString (Link.POS_1_CHAR_1_HP, "500");
//
//
//			PlayerPrefs.SetString (Link.POS_1_CHAR_2_ATTACK, "500");//	322	300	1734
//			PlayerPrefs.SetString (Link.POS_1_CHAR_2_DEFENSE, "100");
//			PlayerPrefs.SetString (Link.POS_1_CHAR_2_HP, "500");
//
//			PlayerPrefs.SetString (Link.POS_1_CHAR_3_ATTACK, "500");//552 450 1044
//			PlayerPrefs.SetString (Link.POS_1_CHAR_3_DEFENSE, "100");
//			PlayerPrefs.SetString (Link.POS_1_CHAR_3_HP, "500");

		} else {
			karaA.SetActive (false);
			//karaB.transform.FindChild ("Buku").GetComponent<SkinnedMeshRenderer> ().updateWhenOffscreen = false;
			karaBanimation.PlayQueued ("run", QueueMode.PlayNow);
			karaBanimation.PlayQueued ("idlegame", QueueMode.CompleteOthers);
		}
//	
//
//
//
//		PlayerPrefs.SetString (Link.POS_1_CHAR_1_ELEMENT, "Water");
//		PlayerPrefs.SetString (Link.POS_1_CHAR_2_ELEMENT, "Fire");
//		PlayerPrefs.SetString (Link.POS_1_CHAR_3_ELEMENT, "Wind");


		hantuchoose1.SetActive (false);
		hantuchoose2.SetActive (false);
		hantuchoose3.SetActive (false);
		PlayerPrefs.SetString ("Suit1", "Kosong");
		PlayerPrefs.SetString ("Urutan1","Kosong");
		PlayerPrefs.SetString ("Urutan1m", "Kosong");
		CB.SetActive(false);
		#if UNITY_EDITOR
		CB.SetActive(true);
		#endif
		Debug.Log (PlayerPrefs.GetString ("PLAY_TUTORIAL"));
		//PlayerPrefs.SetString (Link.SEARCH_BATTLE, "JOUSTING");
		if (PlayerPrefs.GetString ("PLAY_TUTORIAL") == "TRUE") {
			TutorBuru();
			//firstTimerGame.gameObject.SetActive (true);
			SceneManagerHelper.LoadTutorial("Game_1");
			//Time.timeScale = 0;
		}
		else 
		{
			firstTimerGame.gameObject.SetActive (false);
		}
		formkirimreward= new WWWForm ();
	
		presentDone = false;

		//debug.text = PlayerPrefs.GetInt ("pos").ToString ();
		EndOption[5].SetActive (false);
		Debug.Log (PlayerPrefs.GetString (Link.POS_1_CHAR_1_ATTACK));
		Debug.Log ("posnow"+PlayerPrefs.GetInt ("pos"));
		damageA.gameObject.SetActive (false);
		damageB.gameObject.SetActive (false);
		PlayerPrefs.SetInt ("Jumlah",0);
		PlayerPrefs.SetString ("Main", "tidak");
		if (PlayerPrefs.GetString (Link.JENIS) == "SINGLE") 
		{
			if(PlayerPrefs.GetString (Link.SEARCH_BATTLE)== "ONLINE")
			{
				PlayerPrefs.SetString (Link.ArenaGetPoint, "50");
				monsterInfo ();
			SceneManagerHelper.LoadMusic("Game 1Multi");
			EndOption[0].SetActive (true);
			EndOption[2].SetActive (false);
			EndOption[4].SetActive (false);
			EndOption[3].SetActive (false);

			speedOption.SetActive (false);
			}
			else
			{
			SceneManagerHelper.LoadMusic("Normal");
			monsterInfo ();
			EndOption[3].SetActive (true);
			EndOption[4].SetActive (true);
			EndOption[0].SetActive (false);
			speedOption.SetActive (true);
			}
		
			
	} 

		else {

			SceneManagerHelper.LoadMusic("Game 1Multi");
			EndOption[0].SetActive (true);
			EndOption[2].SetActive (false);
			EndOption[4].SetActive (false);			
			EndOption[3].SetActive (false);
			
			speedOption.SetActive (false);
            // perlu di cek
            //urutan1[1].transform.Find("Canvas2").gameObject.SetActive(false);
            //urutan2[1].transform.Find("Canvas2").gameObject.SetActive(false);
            //urutan3[1].transform.Find("Canvas2").gameObject.SetActive(false);

        }
		
		if (PlayerPrefs.GetInt ("pos") == 1) {

			cameraA.SetActive (true);
			ApakahCameraA = true;
		}
		else 
		{

			Debug.Log ("single player");
			cameraB.SetActive (true);
			ApakahCameraA = false;
		}
		
		//TAMBAHAN DISINI
		if (PlayerPrefs.GetString (Link.SEARCH_BATTLE) == "SINGLE" && PlayerPrefs.GetString (Link.JENIS) == "SINGLE") {
			PlayerPrefs.SetString (Link.USER_1, "Enemy");
			PlayerPrefs.SetString (Link.USER_2, PlayerPrefs.GetString (Link.USER_NAME));

		} else {

			//BIARKAN NAMA DARI MASING MASING PEMAIN.
		}


		if (PlayerPrefs.GetString (Link.SEARCH_BATTLE) == "JOUSTING") {
           
            ArenaDuelAR.transform.Find("Object041").gameObject.SetActive(false);
            ArenaDuelAR.SetActive(true);
            this.gameObject.transform.SetParent (CameraTarget.transform);
			speedOption.SetActive (false);
			EndOption[0].SetActive (true);
			EndOption[2].SetActive (false);
			EndOption[4].SetActive (false);
			CameraAR.SetActive (true);
			//hospitalAR.SetActive (true);
			envi.transform.SetParent (CameraTarget.transform);
          //  cameraA.transform.SetParent(CameraTarget.transform);
         //   cameraB.transform.SetParent(CameraTarget.transform);
		} 
		if (PlayerPrefs.GetString (Link.SEARCH_BATTLE) == "REAL_TIME") {
			
			ArenaDuel.SetActive (true);
		}
       
        Destroy (GameObject.Find("SoundBG"));

		urutan1 = new GameObject[2];
		urutan2 = new GameObject[2];
		urutan3 = new GameObject[2];

		urutan1 [0] = GameObject.Find ("Hantu1A");
		urutan1 [1] = GameObject.Find ("Hantu1B");

		urutan2 [0] = GameObject.Find ("Hantu2A");
		urutan2 [1] = GameObject.Find ("Hantu2B");

		urutan3 [0] = GameObject.Find ("Hantu3A");
		urutan3 [1] = GameObject.Find ("Hantu3B");

		Debug.Log ("Info Hantu POS 1 : ");
		Debug.Log ("GRADE : " + PlayerPrefs.GetString(Link.POS_1_CHAR_1_GRADE));
		Debug.Log ("LEVEL : " + PlayerPrefs.GetString(Link.POS_1_CHAR_1_LEVEL));
		Debug.Log ("ATTACK : " + PlayerPrefs.GetString(Link.POS_1_CHAR_1_ATTACK));
		Debug.Log ("DEFENSE : " + PlayerPrefs.GetString(Link.POS_1_CHAR_1_DEFENSE));
		Debug.Log ("HP : " + PlayerPrefs.GetString(Link.POS_1_CHAR_1_HP));

		Debug.Log ("Info Hantu POS 2 : ");
		Debug.Log ("GRADE : " + PlayerPrefs.GetString(Link.POS_2_CHAR_1_GRADE));
		Debug.Log ("LEVEL : " + PlayerPrefs.GetString(Link.POS_2_CHAR_1_LEVEL));
		Debug.Log ("ATTACK : " + PlayerPrefs.GetString(Link.POS_2_CHAR_1_ATTACK));
		Debug.Log ("DEFENSE : " + PlayerPrefs.GetString(Link.POS_2_CHAR_1_DEFENSE));
		Debug.Log ("HP : " + PlayerPrefs.GetString(Link.POS_2_CHAR_1_HP));

		//PlayerPrefs.SetString ("berburu", "tidak");
		if (PlayerPrefs.GetString ("berburu") == "ya") {
			healthA2.SetActive (false);
			healthA3.SetActive (false);
			model1_1 = Instantiate (Resources.Load ("PrefabsChar/" + PlayerPrefs.GetString (Link.POS_1_CHAR_1_FILE)) as GameObject, new Vector3 (0f, 0f, 0f), Quaternion.identity);
			model1_1.transform.SetParent (urutan1 [0].transform);
			model1_1.transform.localPosition = urutan1 [0].transform.Find ("COPY_POSITION").transform.localPosition;
			model1_1.transform.localScale = urutan1 [0].transform.Find ("COPY_POSITION").transform.localScale;
			model1_1.transform.localEulerAngles = urutan1 [0].transform.Find ("COPY_POSITION").transform.localEulerAngles;
			model1_1.name = "Genderuwo_Fire";
			model1_1.transform.SetParent (urutan1 [0].transform.Find ("COPY_POSITION"));
			effect1_1 = Instantiate (Resources.Load ("Prefabs/" + PlayerPrefs.GetString (Link.POS_1_CHAR_1_ELEMENT)) as GameObject, new Vector3 (0f, 0f, 0f), Quaternion.identity);
			effect1_1.transform.SetParent (urutan1 [0].transform);
			effect1_1.transform.localPosition = urutan1 [0].transform.Find ("COPY_POSITIONE").transform.localPosition;
			effect1_1.transform.localScale = new Vector3(.26f,.26f,.26f);
			effect1_1.transform.localEulerAngles = urutan1 [0].transform.Find ("COPY_POSITIONE").transform.localEulerAngles;
			effect1_1.transform.SetParent (urutan1 [0].transform.Find ("COPY_POSITIONE"));
			effect1_1.name = "CriticalEffect";
			//LANGSUNG SY MASUKKAN ATT,HP,DEFENSE
			urutan1 [0].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage = float.Parse (PlayerPrefs.GetString (Link.POS_1_CHAR_1_ATTACK));
			urutan1 [0].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend = float.Parse (PlayerPrefs.GetString (Link.POS_1_CHAR_1_DEFENSE));
			urutan1 [0].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().maxhealth = float.Parse (PlayerPrefs.GetString (Link.POS_1_CHAR_1_HP));
			urutan1 [0].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().currenthealth = float.Parse (PlayerPrefs.GetString (Link.POS_1_CHAR_1_HP));
			urutan1 [0].GetComponent<PlayAnimation> ().element = PlayerPrefs.GetString (Link.POS_1_CHAR_1_ELEMENT);
			urutan1 [0].GetComponent<PlayAnimation> ().TypeS = PlayerPrefs.GetString (Link.POS_1_CHAR_1_MODE);

			model2_1 = Instantiate (Resources.Load ("PrefabsChar/" + PlayerPrefs.GetString (Link.POS_2_CHAR_1_FILE)) as GameObject, new Vector3 (0f, 0f, 0f), Quaternion.identity);
			model2_1.transform.SetParent (urutan1 [1].transform);
			model2_1.transform.localPosition = urutan1 [1].transform.Find ("COPY_POSITION").transform.localPosition;
			model2_1.transform.localScale = urutan1 [1].transform.Find ("COPY_POSITION").transform.localScale;
			model2_1.transform.localEulerAngles = urutan1 [1].transform.Find ("COPY_POSITION").transform.localEulerAngles;
			model2_1.name = "Genderuwo_Fire";
			model2_1.transform.SetParent (urutan1 [1].transform.Find ("COPY_POSITION"));
			effect2_1 = Instantiate (Resources.Load ("Prefabs/" + PlayerPrefs.GetString (Link.POS_2_CHAR_1_ELEMENT)) as GameObject, new Vector3 (0f, 0f, 0f), Quaternion.identity);
			effect2_1.transform.SetParent (urutan1 [1].transform);
			effect2_1.transform.localPosition =  new Vector3 (0, .15f, 0);
			effect2_1.transform.localScale = new Vector3(.26f,.26f,.26f);
			effect2_1.transform.localEulerAngles = urutan1 [1].transform.Find ("COPY_POSITIONE").transform.localEulerAngles;
			effect2_1.transform.SetParent (urutan1 [1].transform.Find ("COPY_POSITIONE"));
			effect2_1.name = "CriticalEffect";
			//LANGSUNG SY MASUKKAN ATT,HP,DEFENSE
			urutan1 [1].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage = float.Parse (PlayerPrefs.GetString (Link.POS_2_CHAR_1_ATTACK));
			urutan1 [1].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend = float.Parse (PlayerPrefs.GetString (Link.POS_2_CHAR_1_DEFENSE));
			urutan1 [1].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().maxhealth = float.Parse (PlayerPrefs.GetString (Link.POS_2_CHAR_1_HP));
			urutan1 [1].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().currenthealth = float.Parse (PlayerPrefs.GetString (Link.POS_2_CHAR_1_HP));
			urutan1 [1].GetComponent<PlayAnimation> ().element = PlayerPrefs.GetString (Link.POS_2_CHAR_1_ELEMENT);
			urutan1 [1].GetComponent<PlayAnimation> ().TypeS = PlayerPrefs.GetString (Link.POS_2_CHAR_1_MODE);

			model2_2 = Instantiate (Resources.Load ("PrefabsChar/" + PlayerPrefs.GetString (Link.POS_2_CHAR_2_FILE)) as GameObject, new Vector3 (0f, 0f, 0f), Quaternion.identity);
			model2_2.transform.SetParent (urutan2 [1].transform);
			model2_2.transform.localPosition = urutan2 [1].transform.Find ("COPY_POSITION").transform.localPosition;
			model2_2.transform.localScale = urutan2 [1].transform.Find ("COPY_POSITION").transform.localScale;
			model2_2.transform.localEulerAngles = urutan2 [1].transform.Find ("COPY_POSITION").transform.localEulerAngles;
			model2_2.name = "Genderuwo_Fire";
			model2_2.transform.SetParent (urutan2 [1].transform.Find ("COPY_POSITION"));
			effect2_2 = Instantiate (Resources.Load ("Prefabs/" + PlayerPrefs.GetString (Link.POS_2_CHAR_2_ELEMENT)) as GameObject, new Vector3 (0f, 0f, 0f), Quaternion.identity);
			effect2_2.transform.SetParent (urutan2 [1].transform);
			effect2_2.transform.localPosition =  new Vector3 (0, .15f, 0);
			effect2_2.transform.localScale = new Vector3(.26f,.26f,.26f);
			effect2_2.transform.localEulerAngles = urutan1 [1].transform.Find ("COPY_POSITIONE").transform.localEulerAngles;
			effect2_2.transform.SetParent (urutan2 [1].transform.Find ("COPY_POSITIONE"));
			effect2_2.name = "CriticalEffect";
			//LANGSUNG SY MASUKKAN ATT,HP,DEFENSE
			urutan2 [1].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage = float.Parse (PlayerPrefs.GetString (Link.POS_2_CHAR_2_ATTACK));
			urutan2 [1].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend = float.Parse (PlayerPrefs.GetString (Link.POS_2_CHAR_2_DEFENSE));
			urutan2 [1].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().maxhealth = float.Parse (PlayerPrefs.GetString (Link.POS_2_CHAR_2_HP));
			urutan2 [1].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().currenthealth = float.Parse (PlayerPrefs.GetString (Link.POS_2_CHAR_2_HP));
			urutan2 [1].GetComponent<PlayAnimation> ().element = PlayerPrefs.GetString (Link.POS_2_CHAR_2_ELEMENT);
			urutan2 [1].GetComponent<PlayAnimation> ().TypeS = PlayerPrefs.GetString (Link.POS_2_CHAR_2_MODE);

			model2_3 = Instantiate (Resources.Load ("PrefabsChar/" + PlayerPrefs.GetString (Link.POS_2_CHAR_3_FILE)) as GameObject, new Vector3 (0f, 0f, 0f), Quaternion.identity);
			model2_3.transform.SetParent (urutan3 [1].transform);
			model2_3.transform.localPosition = urutan3 [1].transform.Find ("COPY_POSITION").transform.localPosition;
			model2_3.transform.localScale = urutan3 [1].transform.Find ("COPY_POSITION").transform.localScale;
			model2_3.transform.localEulerAngles = urutan3 [1].transform.Find ("COPY_POSITION").transform.localEulerAngles;
			model2_3.name = "Genderuwo_Fire";
			model2_3.transform.SetParent (urutan3 [1].transform.Find ("COPY_POSITION"));
			effect2_3 = Instantiate (Resources.Load ("Prefabs/" + PlayerPrefs.GetString (Link.POS_2_CHAR_3_ELEMENT)) as GameObject, new Vector3 (0f, 0f, 0f), Quaternion.identity);
			effect2_3.transform.SetParent (urutan3 [1].transform);
			effect2_3.transform.localPosition =  new Vector3 (0, .15f, 0);
			effect2_3.transform.localScale = new Vector3(.26f,.26f,.26f);
			effect2_3.transform.localEulerAngles = urutan3 [1].transform.Find ("COPY_POSITIONE").transform.localEulerAngles;
			effect2_3.transform.SetParent (urutan3[1].transform.Find ("COPY_POSITIONE"));
			effect2_3.name = "CriticalEffect";
			//LANGSUNG SY MASUKKAN ATT,HP,DEFENSE
			urutan3 [1].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage = float.Parse (PlayerPrefs.GetString (Link.POS_2_CHAR_3_ATTACK));
			urutan3 [1].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend = float.Parse (PlayerPrefs.GetString (Link.POS_2_CHAR_3_DEFENSE));
			urutan3 [1].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().maxhealth = float.Parse (PlayerPrefs.GetString (Link.POS_2_CHAR_3_HP));
			urutan3 [1].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().currenthealth = float.Parse (PlayerPrefs.GetString (Link.POS_2_CHAR_3_HP));
			urutan3 [1].GetComponent<PlayAnimation> ().element = PlayerPrefs.GetString (Link.POS_2_CHAR_3_ELEMENT);
			urutan3 [1].GetComponent<PlayAnimation> ().TypeS = PlayerPrefs.GetString (Link.POS_2_CHAR_3_MODE);
		}
		else if (PlayerPrefs.GetString ("PLAY_TUTORIAL")=="TRUE") {
			healthA2.SetActive (false);
			healthA3.SetActive (false);
			model1_1 = Instantiate (Resources.Load ("PrefabsChar/" + PlayerPrefs.GetString (Link.POS_1_CHAR_1_FILE)) as GameObject, new Vector3 (0f, 0f, 0f), Quaternion.identity);
			model1_1.transform.SetParent (urutan1 [0].transform);
			model1_1.transform.localPosition = urutan1 [0].transform.Find ("COPY_POSITION").transform.localPosition;
			model1_1.transform.localScale = urutan1 [0].transform.Find ("COPY_POSITION").transform.localScale;
			model1_1.transform.localEulerAngles = urutan1 [0].transform.Find ("COPY_POSITION").transform.localEulerAngles;
			model1_1.name = "Genderuwo_Fire";
			model1_1.transform.SetParent (urutan1 [0].transform.Find ("COPY_POSITION"));
			effect1_1 = Instantiate (Resources.Load ("Prefabs/" + PlayerPrefs.GetString (Link.POS_1_CHAR_1_ELEMENT)) as GameObject, new Vector3 (0f, 0f, 0f), Quaternion.identity);
			effect1_1.transform.SetParent (urutan1 [0].transform);
			effect1_1.transform.localPosition = urutan1 [0].transform.Find ("COPY_POSITIONE").transform.localPosition;
			effect1_1.transform.localScale = new Vector3(.26f,.26f,.26f);
			effect1_1.transform.localEulerAngles = urutan1 [0].transform.Find ("COPY_POSITIONE").transform.localEulerAngles;
			effect1_1.transform.SetParent (urutan1 [0].transform.Find ("COPY_POSITIONE"));
			effect1_1.name = "CriticalEffect";
			//LANGSUNG SY MASUKKAN ATT,HP,DEFENSE
			urutan1 [0].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage = float.Parse (PlayerPrefs.GetString (Link.POS_1_CHAR_1_ATTACK));
			urutan1 [0].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend = float.Parse (PlayerPrefs.GetString (Link.POS_1_CHAR_1_DEFENSE));
			urutan1 [0].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().maxhealth = float.Parse (PlayerPrefs.GetString (Link.POS_1_CHAR_1_HP));
			urutan1 [0].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().currenthealth = float.Parse (PlayerPrefs.GetString (Link.POS_1_CHAR_1_HP));
			urutan1 [0].GetComponent<PlayAnimation> ().element = PlayerPrefs.GetString (Link.POS_1_CHAR_1_ELEMENT);
			urutan1 [0].GetComponent<PlayAnimation> ().TypeS = PlayerPrefs.GetString (Link.POS_1_CHAR_1_MODE);

			model2_1 = Instantiate (Resources.Load ("PrefabsChar/" + PlayerPrefs.GetString (Link.POS_2_CHAR_1_FILE)) as GameObject, new Vector3 (0f, 0f, 0f), Quaternion.identity);
			model2_1.transform.SetParent (urutan1 [1].transform);
			model2_1.transform.localPosition = urutan1 [1].transform.Find ("COPY_POSITION").transform.localPosition;
			model2_1.transform.localScale = urutan1 [1].transform.Find ("COPY_POSITION").transform.localScale;
			model2_1.transform.localEulerAngles = urutan1 [1].transform.Find ("COPY_POSITION").transform.localEulerAngles;
			model2_1.name = "Genderuwo_Fire";
			model2_1.transform.SetParent (urutan1 [1].transform.Find ("COPY_POSITION"));
			effect2_1 = Instantiate (Resources.Load ("Prefabs/" + PlayerPrefs.GetString (Link.POS_2_CHAR_1_ELEMENT)) as GameObject, new Vector3 (0f, 0f, 0f), Quaternion.identity);
			effect2_1.transform.SetParent (urutan1 [1].transform);
			effect2_1.transform.localPosition =  new Vector3 (0, .15f, 0);
			effect2_1.transform.localScale = new Vector3(.26f,.26f,.26f);
			effect2_1.transform.localEulerAngles = urutan1 [1].transform.Find ("COPY_POSITIONE").transform.localEulerAngles;
			effect2_1.transform.SetParent (urutan1 [1].transform.Find ("COPY_POSITIONE"));
			effect2_1.name = "CriticalEffect";
			//LANGSUNG SY MASUKKAN ATT,HP,DEFENSE
			urutan1 [1].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage = float.Parse (PlayerPrefs.GetString (Link.POS_2_CHAR_1_ATTACK));
			urutan1 [1].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend = float.Parse (PlayerPrefs.GetString (Link.POS_2_CHAR_1_DEFENSE));
			urutan1 [1].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().maxhealth = float.Parse (PlayerPrefs.GetString (Link.POS_2_CHAR_1_HP));
			urutan1 [1].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().currenthealth = float.Parse (PlayerPrefs.GetString (Link.POS_2_CHAR_1_HP));
			urutan1 [1].GetComponent<PlayAnimation> ().element = PlayerPrefs.GetString (Link.POS_2_CHAR_1_ELEMENT);
			urutan1 [1].GetComponent<PlayAnimation> ().TypeS = PlayerPrefs.GetString (Link.POS_2_CHAR_1_MODE);

			model2_2 = Instantiate (Resources.Load ("PrefabsChar/" + PlayerPrefs.GetString (Link.POS_2_CHAR_2_FILE)) as GameObject, new Vector3 (0f, 0f, 0f), Quaternion.identity);
			model2_2.transform.SetParent (urutan2 [1].transform);
			model2_2.transform.localPosition = urutan2 [1].transform.Find ("COPY_POSITION").transform.localPosition;
			model2_2.transform.localScale = urutan2 [1].transform.Find ("COPY_POSITION").transform.localScale;
			model2_2.transform.localEulerAngles = urutan2 [1].transform.Find ("COPY_POSITION").transform.localEulerAngles;
			model2_2.name = "Genderuwo_Fire";
			model2_2.transform.SetParent (urutan2 [1].transform.Find ("COPY_POSITION"));
			effect2_2 = Instantiate (Resources.Load ("Prefabs/" + PlayerPrefs.GetString (Link.POS_2_CHAR_2_ELEMENT)) as GameObject, new Vector3 (0f, 0f, 0f), Quaternion.identity);
			effect2_2.transform.SetParent (urutan2 [1].transform);
			effect2_2.transform.localPosition =  new Vector3 (0, .15f, 0);
			effect2_2.transform.localScale = new Vector3(.26f,.26f,.26f);
			effect2_2.transform.localEulerAngles = urutan1 [1].transform.Find ("COPY_POSITIONE").transform.localEulerAngles;
			effect2_2.transform.SetParent (urutan2 [1].transform.Find ("COPY_POSITIONE"));
			effect2_2.name = "CriticalEffect";
			//LANGSUNG SY MASUKKAN ATT,HP,DEFENSE
			urutan2 [1].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage = float.Parse (PlayerPrefs.GetString (Link.POS_2_CHAR_2_ATTACK));
			urutan2 [1].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend = float.Parse (PlayerPrefs.GetString (Link.POS_2_CHAR_2_DEFENSE));
			urutan2 [1].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().maxhealth = float.Parse (PlayerPrefs.GetString (Link.POS_2_CHAR_2_HP));
			urutan2 [1].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().currenthealth = float.Parse (PlayerPrefs.GetString (Link.POS_2_CHAR_2_HP));
			urutan2 [1].GetComponent<PlayAnimation> ().element = PlayerPrefs.GetString (Link.POS_2_CHAR_2_ELEMENT);
			urutan2 [1].GetComponent<PlayAnimation> ().TypeS = PlayerPrefs.GetString (Link.POS_2_CHAR_2_MODE);

			model2_3 = Instantiate (Resources.Load ("PrefabsChar/" + PlayerPrefs.GetString (Link.POS_2_CHAR_3_FILE)) as GameObject, new Vector3 (0f, 0f, 0f), Quaternion.identity);
			model2_3.transform.SetParent (urutan3 [1].transform);
			model2_3.transform.localPosition = urutan3 [1].transform.Find ("COPY_POSITION").transform.localPosition;
			model2_3.transform.localScale = urutan3 [1].transform.Find ("COPY_POSITION").transform.localScale;
			model2_3.transform.localEulerAngles = urutan3 [1].transform.Find ("COPY_POSITION").transform.localEulerAngles;
			model2_3.name = "Genderuwo_Fire";
			model2_3.transform.SetParent (urutan3 [1].transform.Find ("COPY_POSITION"));
			effect2_3 = Instantiate (Resources.Load ("Prefabs/" + PlayerPrefs.GetString (Link.POS_2_CHAR_3_ELEMENT)) as GameObject, new Vector3 (0f, 0f, 0f), Quaternion.identity);
			effect2_3.transform.SetParent (urutan3 [1].transform);
			effect2_3.transform.localPosition =  new Vector3 (0, .15f, 0);
			effect2_3.transform.localScale = new Vector3(.26f,.26f,.26f);
			effect2_3.transform.localEulerAngles = urutan3 [1].transform.Find ("COPY_POSITIONE").transform.localEulerAngles;
			effect2_3.transform.SetParent (urutan3[1].transform.Find ("COPY_POSITIONE"));
			effect2_3.name = "CriticalEffect";
			//LANGSUNG SY MASUKKAN ATT,HP,DEFENSE
			urutan3 [1].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage = float.Parse (PlayerPrefs.GetString (Link.POS_2_CHAR_3_ATTACK));
			urutan3 [1].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend = float.Parse (PlayerPrefs.GetString (Link.POS_2_CHAR_3_DEFENSE));
			urutan3 [1].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().maxhealth = float.Parse (PlayerPrefs.GetString (Link.POS_2_CHAR_3_HP));
			urutan3 [1].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().currenthealth = float.Parse (PlayerPrefs.GetString (Link.POS_2_CHAR_3_HP));
			urutan3 [1].GetComponent<PlayAnimation> ().element = PlayerPrefs.GetString (Link.POS_2_CHAR_3_ELEMENT);
			urutan3 [1].GetComponent<PlayAnimation> ().TypeS = PlayerPrefs.GetString (Link.POS_2_CHAR_3_MODE);
		}
		else {

			PlayerHPCurrent = float.Parse (PlayerPrefs.GetString (Link.POS_1_CHAR_1_HP))+ float.Parse (PlayerPrefs.GetString (Link.POS_1_CHAR_2_HP))+ float.Parse (PlayerPrefs.GetString (Link.POS_1_CHAR_3_HP));
			PlayerHPMax=PlayerHPCurrent;
			EnemiesHPCurrent = float.Parse (PlayerPrefs.GetString (Link.POS_2_CHAR_1_HP))+ float.Parse (PlayerPrefs.GetString (Link.POS_2_CHAR_2_HP))+ float.Parse (PlayerPrefs.GetString (Link.POS_2_CHAR_3_HP));
			EnemiesHPMax=EnemiesHPCurrent;

			model1_1 = Instantiate (Resources.Load ("PrefabsChar/" + PlayerPrefs.GetString (Link.POS_1_CHAR_1_FILE)) as GameObject, new Vector3 (0f, 0f, 0f), Quaternion.identity);
			model1_1.transform.SetParent (urutan1 [0].transform);
			model1_1.transform.localPosition = urutan1 [0].transform.Find ("COPY_POSITION").transform.localPosition;
			model1_1.transform.localScale = urutan1 [0].transform.Find ("COPY_POSITION").transform.localScale;
			model1_1.transform.localEulerAngles = urutan1 [0].transform.Find ("COPY_POSITION").transform.localEulerAngles;
			model1_1.name = "Genderuwo_Fire";
			model1_1.transform.SetParent (urutan1 [0].transform.Find ("COPY_POSITION"));
			effect1_1 = Instantiate (Resources.Load ("Prefabs/" + PlayerPrefs.GetString (Link.POS_1_CHAR_1_ELEMENT)) as GameObject, new Vector3 (0f, 0f, 0f), Quaternion.identity);
			effect1_1.transform.SetParent (urutan1 [0].transform);
			effect1_1.transform.localPosition =  new Vector3 (0, .15f, 0);
			effect1_1.transform.localScale = new Vector3(.26f,.26f,.26f);
			effect1_1.transform.localEulerAngles = urutan1 [0].transform.Find ("COPY_POSITIONE").transform.localEulerAngles;
			effect1_1.transform.SetParent (urutan1 [0].transform.Find ("COPY_POSITIONE"));
			effect1_1.name = "CriticalEffect";
			//LANGSUNG SY MASUKKAN ATT,HP,DEFENSE
			print(PlayerPrefs.GetString (Link.POS_1_CHAR_1_DEFENSE));
			urutan1 [0].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage = float.Parse (PlayerPrefs.GetString (Link.POS_1_CHAR_1_ATTACK));
			urutan1 [0].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend = float.Parse (PlayerPrefs.GetString (Link.POS_1_CHAR_1_DEFENSE));
			urutan1 [0].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().maxhealth = float.Parse (PlayerPrefs.GetString (Link.POS_1_CHAR_1_HP));
			urutan1 [0].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().currenthealth = float.Parse (PlayerPrefs.GetString (Link.POS_1_CHAR_1_HP));
			urutan1 [0].GetComponent<PlayAnimation> ().element = PlayerPrefs.GetString (Link.POS_1_CHAR_1_ELEMENT);
			urutan1 [0].GetComponent<PlayAnimation> ().TypeS = PlayerPrefs.GetString (Link.POS_1_CHAR_1_MODE);

			//SERTA DATA LAIN, MUNGKIN AKAN DIPERLUKAN NANTI
			//PlayerPrefs.GetString(Link.POS_1_CHAR_1_GRADE);
			//PlayerPrefs.GetString(Link.POS_1_CHAR_1_LEVEL);



			model2_1 = Instantiate (Resources.Load ("PrefabsChar/" + PlayerPrefs.GetString (Link.POS_2_CHAR_1_FILE)) as GameObject, new Vector3 (0f, 0f, 0f), Quaternion.identity);
			model2_1.transform.SetParent (urutan1 [1].transform);
			model2_1.transform.localPosition = urutan1 [1].transform.Find ("COPY_POSITION").transform.localPosition;
			model2_1.transform.localScale = urutan1 [1].transform.Find ("COPY_POSITION").transform.localScale;
			model2_1.transform.localEulerAngles = urutan1 [1].transform.Find ("COPY_POSITION").transform.localEulerAngles;
			model2_1.name = "Genderuwo_Fire";
			model2_1.transform.SetParent (urutan1 [1].transform.Find ("COPY_POSITION"));
			effect2_1 = Instantiate (Resources.Load ("Prefabs/" + PlayerPrefs.GetString (Link.POS_2_CHAR_1_ELEMENT)) as GameObject, new Vector3 (0f, 0f, 0f), Quaternion.identity);
			effect2_1.transform.SetParent (urutan1 [1].transform);
			effect2_1.transform.localPosition =  new Vector3 (0, .15f, 0);
			effect2_1.transform.localScale = new Vector3(.26f,.26f,.26f);
			effect2_1.transform.localEulerAngles = urutan1 [1].transform.Find ("COPY_POSITIONE").transform.localEulerAngles;
			effect2_1.transform.SetParent (urutan1 [1].transform.Find ("COPY_POSITIONE"));
						effect2_1.name = "CriticalEffect";
			//LANGSUNG SY MASUKKAN ATT,HP,DEFENSE
			urutan1 [1].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage = float.Parse (PlayerPrefs.GetString (Link.POS_2_CHAR_1_ATTACK));
			urutan1 [1].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend = float.Parse (PlayerPrefs.GetString (Link.POS_2_CHAR_1_DEFENSE));
			urutan1 [1].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().maxhealth = float.Parse (PlayerPrefs.GetString (Link.POS_2_CHAR_1_HP));
			urutan1 [1].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().currenthealth = float.Parse (PlayerPrefs.GetString (Link.POS_2_CHAR_1_HP));
			urutan1 [1].GetComponent<PlayAnimation> ().element = PlayerPrefs.GetString (Link.POS_2_CHAR_1_ELEMENT);
			urutan1 [1].GetComponent<PlayAnimation> ().TypeS = PlayerPrefs.GetString (Link.POS_2_CHAR_1_MODE);
		
			model1_2 = Instantiate (Resources.Load ("PrefabsChar/" + PlayerPrefs.GetString (Link.POS_1_CHAR_2_FILE)) as GameObject, new Vector3 (0f, 0f, 0f), Quaternion.identity);
			model1_2.transform.SetParent (urutan2 [0].transform);
			model1_2.transform.localPosition = urutan2 [0].transform.Find ("COPY_POSITION").transform.localPosition;
			model1_2.transform.localScale = urutan2 [0].transform.Find ("COPY_POSITION").transform.localScale;
			model1_2.transform.localEulerAngles = urutan2 [0].transform.Find ("COPY_POSITION").transform.localEulerAngles;
			model1_2.name = "Genderuwo_Fire";
			model1_2.transform.SetParent (urutan2 [0].transform.Find ("COPY_POSITION"));
			effect1_2 = Instantiate (Resources.Load ("Prefabs/" + PlayerPrefs.GetString (Link.POS_1_CHAR_2_ELEMENT)) as GameObject, new Vector3 (0f, 0f, 0f), Quaternion.identity);
			effect1_2.transform.SetParent (urutan2 [0].transform);
			effect1_2.transform.localPosition =  new Vector3 (0, .15f, 0);
			effect1_2.transform.localScale = new Vector3(.26f,.26f,.26f);
			effect1_2.transform.localEulerAngles = urutan2 [0].transform.Find ("COPY_POSITIONE").transform.localEulerAngles;
			effect1_2.transform.SetParent (urutan2 [0].transform.Find ("COPY_POSITIONE"));
			effect1_2.name = "CriticalEffect";
			//LANGSUNG SY MASUKKAN ATT,HP,DEFENSE
			urutan2 [0].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage = float.Parse (PlayerPrefs.GetString (Link.POS_1_CHAR_2_ATTACK));
			urutan2 [0].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend = float.Parse (PlayerPrefs.GetString (Link.POS_1_CHAR_2_DEFENSE));
			urutan2 [0].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().maxhealth = float.Parse (PlayerPrefs.GetString (Link.POS_1_CHAR_2_HP));
			urutan2 [0].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().currenthealth = float.Parse (PlayerPrefs.GetString (Link.POS_1_CHAR_2_HP));
			urutan2 [0].GetComponent<PlayAnimation> ().element = PlayerPrefs.GetString (Link.POS_1_CHAR_2_ELEMENT);
			urutan2 [0].GetComponent<PlayAnimation> ().TypeS = PlayerPrefs.GetString (Link.POS_1_CHAR_2_MODE);
			//SERTA DATA LAIN, MUNGKIN AKAN DIPERLUKAN NANTI
			//PlayerPrefs.GetString(Link.POS_1_CHAR_2_GRADE);
			//PlayerPrefs.GetString(Link.POS_1_CHAR_2_LEVEL);

			model2_2 = Instantiate (Resources.Load ("PrefabsChar/" + PlayerPrefs.GetString (Link.POS_2_CHAR_2_FILE)) as GameObject, new Vector3 (0f, 0f, 0f), Quaternion.identity);
			model2_2.transform.SetParent (urutan2 [1].transform);
			model2_2.transform.localPosition = urutan2 [1].transform.Find ("COPY_POSITION").transform.localPosition;
			model2_2.transform.localScale = urutan2 [1].transform.Find ("COPY_POSITION").transform.localScale;
			model2_2.transform.localEulerAngles = urutan2 [1].transform.Find ("COPY_POSITION").transform.localEulerAngles;
			model2_2.name = "Genderuwo_Fire";
			model2_2.transform.SetParent (urutan2 [1].transform.Find ("COPY_POSITION"));
			effect2_2 = Instantiate (Resources.Load ("Prefabs/" + PlayerPrefs.GetString (Link.POS_2_CHAR_2_ELEMENT)) as GameObject, new Vector3 (0f, 0f, 0f), Quaternion.identity);
			effect2_2.transform.SetParent (urutan2 [1].transform);
					
			effect2_2.transform.localScale = new Vector3(.26f,.26f,.26f);
			effect2_2.transform.localEulerAngles = urutan1 [1].transform.Find ("COPY_POSITIONE").transform.localEulerAngles;
			effect2_2.transform.SetParent (urutan2 [1].transform.Find ("COPY_POSITIONE"));
			effect2_2.transform.localPosition = new Vector3 (0, .15f, 0);
			effect2_2.name = "CriticalEffect";
			//LANGSUNG SY MASUKKAN ATT,HP,DEFENSE
			urutan2 [1].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage = float.Parse (PlayerPrefs.GetString (Link.POS_2_CHAR_2_ATTACK));
			urutan2 [1].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend = float.Parse (PlayerPrefs.GetString (Link.POS_2_CHAR_2_DEFENSE));
			urutan2 [1].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().maxhealth = float.Parse (PlayerPrefs.GetString (Link.POS_2_CHAR_2_HP));
			urutan2 [1].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().currenthealth = float.Parse (PlayerPrefs.GetString (Link.POS_2_CHAR_2_HP));
			urutan2 [1].GetComponent<PlayAnimation> ().element = PlayerPrefs.GetString (Link.POS_2_CHAR_2_ELEMENT);
			urutan2 [1].GetComponent<PlayAnimation> ().TypeS = PlayerPrefs.GetString (Link.POS_2_CHAR_2_MODE);
			//if (PlayerPrefs.GetString(Link.JENIS) == "SINGLE")
			//{
			//    urutan2[1].transform.Find("Canvas2").transform.FindChild("Image").GetComponent<filled>().damage = float.Parse(PlayerPrefs.GetString(Link.POS_2_CHAR_2_ATTACK));
			//    urutan2[1].transform.Find("Canvas2").transform.FindChild("Image").GetComponent<filled>().defend = float.Parse(PlayerPrefs.GetString(Link.POS_2_CHAR_2_DEFENSE));
			//    urutan2[1].transform.Find("Canvas2").transform.FindChild("Image").GetComponent<filled>().maxhealth = float.Parse(PlayerPrefs.GetString(Link.POS_2_CHAR_2_HP));
			//    urutan2[1].transform.Find("Canvas2").transform.FindChild("Image").GetComponent<filled>().currenthealth = float.Parse(PlayerPrefs.GetString(Link.POS_2_CHAR_2_HP));

			//}
			//SERTA DATA LAIN, MUNGKIN AKAN DIPERLUKAN NANTI
			//PlayerPrefs.GetString(Link.POS_2_CHAR_2_GRADE);
			//PlayerPrefs.GetString(Link.POS_2_CHAR_2_LEVEL);

			model1_3 = Instantiate (Resources.Load ("PrefabsChar/" + PlayerPrefs.GetString (Link.POS_1_CHAR_3_FILE)) as GameObject, new Vector3 (0f, 0f, 0f), Quaternion.identity);
			model1_3.transform.SetParent (urutan3 [0].transform);
			model1_3.transform.localPosition = urutan3 [0].transform.Find ("COPY_POSITION").transform.localPosition;
			model1_3.transform.localScale = urutan3 [0].transform.Find ("COPY_POSITION").transform.localScale;
			model1_3.transform.localEulerAngles = urutan3 [0].transform.Find ("COPY_POSITION").transform.localEulerAngles;
			model1_3.name = "Genderuwo_Fire";
			model1_3.transform.SetParent (urutan3 [0].transform.Find ("COPY_POSITION"));
						effect1_3 = Instantiate (Resources.Load ("Prefabs/" + PlayerPrefs.GetString (Link.POS_1_CHAR_3_ELEMENT)) as GameObject, new Vector3 (0f, 0f, 0f), Quaternion.identity);
						effect1_3.transform.SetParent (urutan3 [0].transform);
						effect1_3.transform.localPosition =  new Vector3 (0, .15f, 0);
						effect1_3.transform.localScale = new Vector3(.26f,.26f,.26f);
			effect1_3.transform.localEulerAngles = urutan3 [0].transform.Find ("COPY_POSITIONE").transform.localEulerAngles;
			effect1_3.transform.SetParent (urutan3 [0].transform.Find ("COPY_POSITIONE"));
						effect1_3.name = "CriticalEffect";
			//LANGSUNG SY MASUKKAN ATT,HP,DEFENSE
			urutan3 [0].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage = float.Parse (PlayerPrefs.GetString (Link.POS_1_CHAR_3_ATTACK));
			urutan3 [0].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend = float.Parse (PlayerPrefs.GetString (Link.POS_1_CHAR_3_DEFENSE));
			urutan3 [0].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().maxhealth = float.Parse (PlayerPrefs.GetString (Link.POS_1_CHAR_3_HP));
			urutan3 [0].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().currenthealth = float.Parse (PlayerPrefs.GetString (Link.POS_1_CHAR_3_HP));
			urutan3 [0].GetComponent<PlayAnimation> ().element = PlayerPrefs.GetString (Link.POS_1_CHAR_3_ELEMENT);
			urutan3 [0].GetComponent<PlayAnimation> ().TypeS = PlayerPrefs.GetString (Link.POS_1_CHAR_3_MODE);
			//SERTA DATA LAIN, MUNGKIN AKAN DIPERLUKAN NANTI
			//PlayerPrefs.GetString(Link.POS_1_CHAR_3_GRADE);
			//PlayerPrefs.GetString(Link.POS_1_CHAR_3_LEVEL);

			model2_3 = Instantiate (Resources.Load ("PrefabsChar/" + PlayerPrefs.GetString (Link.POS_2_CHAR_3_FILE)) as GameObject, new Vector3 (0f, 0f, 0f), Quaternion.identity);
			model2_3.transform.SetParent (urutan3 [1].transform);
			model2_3.transform.localPosition = urutan3 [1].transform.Find ("COPY_POSITION").transform.localPosition;
			model2_3.transform.localScale = urutan3 [1].transform.Find ("COPY_POSITION").transform.localScale;
			model2_3.transform.localEulerAngles = urutan3 [1].transform.Find ("COPY_POSITION").transform.localEulerAngles;
			model2_3.name = "Genderuwo_Fire";
			model2_3.transform.SetParent (urutan3 [1].transform.Find ("COPY_POSITION"));
						effect2_3 = Instantiate (Resources.Load ("Prefabs/" + PlayerPrefs.GetString (Link.POS_2_CHAR_3_ELEMENT)) as GameObject, new Vector3 (0f, 0f, 0f), Quaternion.identity);
						effect2_3.transform.SetParent (urutan3 [1].transform);
						effect2_3.transform.localPosition =  new Vector3 (0, .15f, 0);
						effect2_3.transform.localScale = new Vector3(.26f,.26f,.26f);
			effect2_3.transform.localEulerAngles = urutan3 [1].transform.Find ("COPY_POSITIONE").transform.localEulerAngles;
			effect2_3.transform.SetParent (urutan3[1].transform.Find ("COPY_POSITIONE"));
						effect2_3.name = "CriticalEffect";
			//LANGSUNG SY MASUKKAN ATT,HP,DEFENSE
			urutan3 [1].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage = float.Parse (PlayerPrefs.GetString (Link.POS_2_CHAR_3_ATTACK));
			urutan3 [1].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend = float.Parse (PlayerPrefs.GetString (Link.POS_2_CHAR_3_DEFENSE));
			urutan3 [1].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().maxhealth = float.Parse (PlayerPrefs.GetString (Link.POS_2_CHAR_3_HP));
			urutan3 [1].transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().currenthealth = float.Parse (PlayerPrefs.GetString (Link.POS_2_CHAR_3_HP));
			urutan3 [1].GetComponent<PlayAnimation> ().element = PlayerPrefs.GetString (Link.POS_2_CHAR_3_ELEMENT);
			urutan3 [1].GetComponent<PlayAnimation> ().TypeS = PlayerPrefs.GetString (Link.POS_2_CHAR_3_MODE);
		} 
		//if (PlayerPrefs.GetString(Link.JENIS) == "SINGLE")
        //{
        //    urutan3[1].transform.Find("Canvas2").transform.FindChild("Image").GetComponent<filled>().damage = float.Parse(PlayerPrefs.GetString(Link.POS_2_CHAR_2_ATTACK));
        //    urutan3[1].transform.Find("Canvas2").transform.FindChild("Image").GetComponent<filled>().defend = float.Parse(PlayerPrefs.GetString(Link.POS_2_CHAR_2_DEFENSE));
        //    urutan3[1].transform.Find("Canvas2").transform.FindChild("Image").GetComponent<filled>().maxhealth = float.Parse(PlayerPrefs.GetString(Link.POS_2_CHAR_2_HP));
        //    urutan3[1].transform.Find("Canvas2").transform.FindChild("Image").GetComponent<filled>().currenthealth = float.Parse(PlayerPrefs.GetString(Link.POS_2_CHAR_2_HP));

        //}
        //SERTA DATA LAIN, MUNGKIN AKAN DIPERLUKAN NANTI
        //PlayerPrefs.GetString(Link.POS_2_CHAR_3_GRADE);
        //PlayerPrefs.GetString(Link.POS_2_CHAR_3_LEVEL);
		if (PlayerPrefs.GetString ("berburu") != "ya") 
		{
			if (PlayerPrefs.GetString ("PLAY_TUTORIAL")=="TRUE") 
			{
			hantugom2.transform.Find ("Canvas").Find ("bg").gameObject.SetActive (false);
			hantugom3.transform.Find ("Canvas").Find ("bg").gameObject.SetActive (false);
			model11a = model1_1.GetComponent<Animation> ();
			model21a = model2_1.GetComponent<Animation> ();
			//model12a = model1_2.GetComponent<Animation> ();
			model22a = model2_2.GetComponent<Animation> ();
			//model13a = model1_3.GetComponent<Animation> ();
			model23a = model2_3.GetComponent<Animation> ();
			} 
			else
			{
			model11a = model1_1.GetComponent<Animation> ();
			model21a = model2_1.GetComponent<Animation> ();
			model12a = model1_2.GetComponent<Animation> ();
			model22a = model2_2.GetComponent<Animation> ();
			model13a = model1_3.GetComponent<Animation> ();
			model23a = model2_3.GetComponent<Animation> ();
			}
			
		}
		
		else {
			hantugom2.transform.Find ("Canvas").Find ("bg").gameObject.SetActive (false);
			hantugom3.transform.Find ("Canvas").Find ("bg").gameObject.SetActive (false);
			model11a = model1_1.GetComponent<Animation> ();
			model21a = model2_1.GetComponent<Animation> ();
			//model12a = model1_2.GetComponent<Animation> ();
			model22a = model2_2.GetComponent<Animation> ();
			//model13a = model1_3.GetComponent<Animation> ();
			model23a = model2_3.GetComponent<Animation> ();
		}

      //  ModelAllStatus (false);

        //PlayerPrefs.DeleteAll ();
        //ganti perbandingan nilai N apabila jumlah monster bertambah
        if (PlayerPrefs.GetInt ("pos") == 1) {
            if (PlayerPrefs.GetString(Link.SEARCH_BATTLE) == "JOUSTING")
            {
                
                joustingnameA.text = PlayerPrefs.GetString(Link.USER_2);
                joustingnameA1.text = PlayerPrefs.GetString(Link.USER_2);
                joustingnameA2.text = PlayerPrefs.GetString(Link.USER_2);
                joustingnameB.text = PlayerPrefs.GetString(Link.USER_1);
                joustingnameB1.text = PlayerPrefs.GetString(Link.USER_1);
                joustingnameB2.text = PlayerPrefs.GetString(Link.USER_1);
            }
            User2.text = PlayerPrefs.GetString (Link.USER_1);
			User1.text = PlayerPrefs.GetString (Link.USER_2);
           
            icon1.sprite = Resources.Load<Sprite>("icon_char/" + PlayerPrefs.GetString(Link.POS_1_CHAR_1_FILE));
			icon2.sprite = Resources.Load<Sprite>("icon_char/" + PlayerPrefs.GetString(Link.POS_1_CHAR_2_FILE));
			icon3.sprite = Resources.Load<Sprite>("icon_char/" + PlayerPrefs.GetString(Link.POS_1_CHAR_3_FILE));


		} else {
            if (PlayerPrefs.GetString(Link.SEARCH_BATTLE) == "JOUSTING")
            {
                joustingnameA.text = PlayerPrefs.GetString(Link.USER_1);
                joustingnameB.text = PlayerPrefs.GetString(Link.USER_2);
                joustingnameA1.text = PlayerPrefs.GetString(Link.USER_1);
                joustingnameB1.text = PlayerPrefs.GetString(Link.USER_2);
                joustingnameA2.text = PlayerPrefs.GetString(Link.USER_1);
                joustingnameB2.text = PlayerPrefs.GetString(Link.USER_2);
            }
            User1.text = PlayerPrefs.GetString (Link.USER_1);
			User2.text = PlayerPrefs.GetString (Link.USER_2);

			icon1.sprite = Resources.Load<Sprite>("icon_char/" + PlayerPrefs.GetString(Link.POS_2_CHAR_1_FILE));
			icon2.sprite = Resources.Load<Sprite>("icon_char/" + PlayerPrefs.GetString(Link.POS_2_CHAR_2_FILE));
			icon3.sprite = Resources.Load<Sprite>("icon_char/" + PlayerPrefs.GetString(Link.POS_2_CHAR_3_FILE));

		}


		urutan1 = new GameObject[2];
		urutan2 = new GameObject[2];
		urutan3 = new GameObject[2];

		healthBar1 = new GameObject[2];
		healthBar2 = new GameObject[2];
		healthBar3 = new GameObject[2];

		suit1 = new string[2];
		suit2 = new string[2];
		suit3 = new string[2];


		health1 = new float[2];
		health2 = new float[2];
		health3 = new float[2];

		if (PlayerPrefs.GetString ("berburu") != "ya") {

			if(PlayerPrefs.GetString("PLAY_TUTORIAL")=="TRUE")
			{
				health1 [0] = healthA1.GetComponent<filled> ().maxhealth;
				health1 [1] = healthB1.GetComponent<filled> ().maxhealth;

				health2 [1] = healthB2.GetComponent<filled> ().maxhealth;
				health3 [1] = healthB3.GetComponent<filled> ().maxhealth;
			}
			else
			{
				health1 [0] = healthA1.GetComponent<filled> ().maxhealth;
				health1 [1] = healthB1.GetComponent<filled> ().maxhealth;


				health2 [0] = healthA2.GetComponent<filled> ().maxhealth;
				health2 [1] = healthB2.GetComponent<filled> ().maxhealth;

				health3 [0] = healthA3.GetComponent<filled> ().maxhealth;
				health3 [1] = healthB3.GetComponent<filled> ().maxhealth;
			}
			

		} else {
			health1 [0] = healthA1.GetComponent<filled> ().maxhealth;
			health1 [1] = healthB1.GetComponent<filled> ().maxhealth;


			//health2 [0] = healthA2.GetComponent<filled> ().maxhealth;
			health2 [1] = healthB2.GetComponent<filled> ().maxhealth;

			//health3 [0] = healthA3.GetComponent<filled> ().maxhealth;
			health3 [1] = healthB3.GetComponent<filled> ().maxhealth;
		}


		StartCoroutine (areuReady());
		//SY TAMBAHIN JIKA SINGLE KE SINI
	
	}
	public void autooff(){
		auto = false;
	}
	public void automatic(){
		auto = true;
		if (PlayerPrefs.GetString ("1player") != "mati" && PlayerPrefs.GetString ("2player") != "mati" &&PlayerPrefs.GetString ("3player") != "mati") {
			int urut = Random.Range (0, 2);

			if (urut == 0) {
				pilihanInputSuit [0].transform.Find ("Batu").GetComponent<ButtonInput> ().OnPilih ();
				bermain ();
				pilihanInputSuit [4].SetActive (false);
				pilihanInputSuit [5].SetActive (false);
			}
			if (urut == 1) {
				pilihanInputSuit [1].transform.Find ("Batu (1)").GetComponent<ButtonInput> ().OnPilih ();
				bermain ();
				pilihanInputSuit [3].SetActive (false);
				pilihanInputSuit [5].SetActive (false);
			}
			if (urut == 2) {
				pilihanInputSuit [2].transform.Find ("Batu (2)").GetComponent<ButtonInput> ().OnPilih ();
				bermain ();
				pilihanInputSuit [4].SetActive (false);
				pilihanInputSuit [3].SetActive (false);
			}
		}
		if (PlayerPrefs.GetString ("1player") == "mati" && PlayerPrefs.GetString ("2player") != "mati") {
			int urut = Random.Range(0,1);
			pilihanInputSuit [3].SetActive (false);
			if (urut == 0) 
			{
				pilihanInputSuit [2].transform.Find("Batu (2)").GetComponent<ButtonInput> ().OnPilih ();
				bermain ();
				pilihanInputSuit [4].SetActive (false);
			}
			if (urut == 1) {
				pilihanInputSuit [1].transform.Find("Batu (1)").GetComponent<ButtonInput> ().OnPilih ();
				bermain ();
				pilihanInputSuit [5].SetActive (false);
			}
			if (PlayerPrefs.GetString ("3player") == "mati") {
				pilihanInputSuit [1].transform.Find("Batu (1)").GetComponent<ButtonInput> ().OnPilih ();
				bermain ();
				pilihanInputSuit [5].SetActive (false);
			}


		}
		if (PlayerPrefs.GetString ("1player") == "mati" && PlayerPrefs.GetString ("3player") != "mati") {
			int urut = Random.Range (0, 1);
			pilihanInputSuit [3].SetActive (false);
			if (urut == 0) 
			{
				pilihanInputSuit [2].transform.Find("Batu (2)").GetComponent<ButtonInput> ().OnPilih ();
				bermain ();
				pilihanInputSuit [4].SetActive (false);
			}
			if (urut == 1) {
				pilihanInputSuit [1].transform.Find("Batu (1)").GetComponent<ButtonInput> ().OnPilih ();
				bermain ();
				pilihanInputSuit [5].SetActive (false);
			}
			if (PlayerPrefs.GetString ("2player") == "mati") {
				pilihanInputSuit [2].transform.Find("Batu (2)").GetComponent<ButtonInput> ().OnPilih ();
				bermain ();
				pilihanInputSuit [4].SetActive (false);
		
			}
		}
		if (PlayerPrefs.GetString ("2player") == "mati" && PlayerPrefs.GetString ("1player") != "mati") {
			int urut = Random.Range (0, 1);
			pilihanInputSuit [4].SetActive (false);
			if (urut == 0) {
				pilihanInputSuit [0].transform.Find ("Batu").GetComponent<ButtonInput> ().OnPilih ();
				bermain ();
				pilihanInputSuit [5].SetActive (false);
			}
			if (urut == 1) {
				pilihanInputSuit [2].transform.Find ("Batu (2)").GetComponent<ButtonInput> ().OnPilih ();
				bermain ();
				pilihanInputSuit [3].SetActive (false);
			}
			if (PlayerPrefs.GetString ("3player") == "mati") {
				pilihanInputSuit [0].transform.Find ("Batu").GetComponent<ButtonInput> ().OnPilih ();
				bermain ();
				pilihanInputSuit [5].SetActive (false);
			}
		}

		if (PlayerPrefs.GetString ("2player") == "mati" && PlayerPrefs.GetString ("3player") != "mati") {
			int urut = Random.Range (0, 1);
			pilihanInputSuit [4].SetActive (false);
			if (urut == 0) {
				pilihanInputSuit [0].transform.Find ("Batu").GetComponent<ButtonInput> ().OnPilih ();
				bermain ();
				pilihanInputSuit [5].SetActive (false);
			}
			if (urut == 1) {
				pilihanInputSuit [2].transform.Find ("Batu (1)").GetComponent<ButtonInput> ().OnPilih ();
				bermain ();
				pilihanInputSuit [3].SetActive (false);
			}
			if (PlayerPrefs.GetString ("1player") == "mati") {
				pilihanInputSuit [2].transform.Find ("Batu (2)").GetComponent<ButtonInput> ().OnPilih ();
				bermain ();
				pilihanInputSuit [3].SetActive (false);
			}
		}
	}

	void multiplayer(){
//		if (PlayerPrefs.GetInt ("pos") == 1) {
//			if (PlayerPrefs.GetString ("Urutan1") == "Hantu1A") {
//				pilihanInputSuit [0].GetComponent<RandomClick> ().RandomPilih ();
//
//
//				//		if (hantuchoose2.activeSelf) {
//				//			hantuchoose2.GetComponent<RandomClick> ().RandomPilih ();
//				//			}
//				//			yield return new WaitForSeconds(1);
//				//
//				//		if (hantuchoose3.activeSelf) {
//				//			hantuchoose3.GetComponent<RandomClick> ().RandomPilih ();
//				//			}
//				//			if (PlayerPrefs.GetString ("PLAY_TUTORIAL") == "TRUE") {
//				//				firstTimerTanding ();
//				//				//StartCoroutine (urutanPlay());
//				//
//				//			} 
//			}
//
//			if (PlayerPrefs.GetString ("Urutan1") == "Hantu2A") {
//				pilihanInputSuit [1].GetComponent<RandomClick> ().RandomPilih ();
//			}
//
//			if (PlayerPrefs.GetString ("Urutan1") == "Hantu3A") {
//
//
//				pilihanInputSuit [2].GetComponent<RandomClick> ().RandomPilih ();
//			}
//		}
//	else {
//			if (PlayerPrefs.GetString ("Urutan1") == "Hantu1B") {
//				pilihanInputSuit [0].GetComponent<RandomClick> ().RandomPilih ();
//
//
//				//		if (hantuchoose2.activeSelf) {
//				//			hantuchoose2.GetComponent<RandomClick> ().RandomPilih ();
//				//			}
//				//			yield return new WaitForSeconds(1);
//				//
//				//		if (hantuchoose3.activeSelf) {
//				//			hantuchoose3.GetComponent<RandomClick> ().RandomPilih ();
//				//			}
//				//			if (PlayerPrefs.GetString ("PLAY_TUTORIAL") == "TRUE") {
//				//				firstTimerTanding ();
//				//				//StartCoroutine (urutanPlay());
//				//
//				//			} 
//			}
//
//			if (PlayerPrefs.GetString ("Urutan1") == "Hantu2B") {
//				pilihanInputSuit [1].GetComponent<RandomClick> ().RandomPilih ();
//			}
//
//			if (PlayerPrefs.GetString ("Urutan1") == "Hantu3B") {
//
//
//				pilihanInputSuit [2].GetComponent<RandomClick> ().RandomPilih ();
//			}
//		}
		if (PlayerPrefs.GetString ("1player") != "mati" && PlayerPrefs.GetString ("2player") != "mati" &&PlayerPrefs.GetString ("3player") != "mati") {
			int urut = Random.Range (0, 2);

			if (urut == 0) {
				pilihanInputSuit [0].transform.Find ("Batu").GetComponent<ButtonInput> ().OnPilih ();
				bermain ();
				pilihanInputSuit [4].SetActive (false);
				pilihanInputSuit [5].SetActive (false);
			}
			if (urut == 1) {
				pilihanInputSuit [1].transform.Find ("Batu (1)").GetComponent<ButtonInput> ().OnPilih ();
				bermain ();
				pilihanInputSuit [3].SetActive (false);
				pilihanInputSuit [5].SetActive (false);
			}
			if (urut == 2) {
				pilihanInputSuit [2].transform.Find ("Batu (2)").GetComponent<ButtonInput> ().OnPilih ();
				bermain ();
				pilihanInputSuit [4].SetActive (false);
				pilihanInputSuit [3].SetActive (false);
			}
		}
		if (PlayerPrefs.GetString ("1player") == "mati" && PlayerPrefs.GetString ("2player") != "mati") {
			int urut = Random.Range(0,1);
			pilihanInputSuit [3].SetActive (false);
			if (urut == 0) 
			{
				pilihanInputSuit [2].transform.Find("Batu (2)").GetComponent<ButtonInput> ().OnPilih ();
				bermain ();
				pilihanInputSuit [4].SetActive (false);
			}
			if (urut == 1) {
				pilihanInputSuit [1].transform.Find("Batu (1)").GetComponent<ButtonInput> ().OnPilih ();
				bermain ();
				pilihanInputSuit [5].SetActive (false);
			}
			if (PlayerPrefs.GetString ("3player") == "mati") {
				pilihanInputSuit [1].transform.Find("Batu (2)").GetComponent<ButtonInput> ().OnPilih ();
				bermain ();
				pilihanInputSuit [5].SetActive (false);
			}


		}
		if (PlayerPrefs.GetString ("1player") == "mati" && PlayerPrefs.GetString ("3player") != "mati") {
			int urut = Random.Range (0, 1);
			pilihanInputSuit [3].SetActive (false);
			if (urut == 0) 
			{
				pilihanInputSuit [2].transform.Find("Batu (2)").GetComponent<ButtonInput> ().OnPilih ();
				bermain ();
				pilihanInputSuit [4].SetActive (false);
			}
			if (urut == 1) {
				pilihanInputSuit [1].transform.Find("Batu (1)").GetComponent<ButtonInput> ().OnPilih ();
				bermain ();
				pilihanInputSuit [5].SetActive (false);
			}
			if (PlayerPrefs.GetString ("2player") == "mati") {
				pilihanInputSuit [2].transform.Find("Batu (2)").GetComponent<ButtonInput> ().OnPilih ();
				bermain ();
				pilihanInputSuit [4].SetActive (false);

			}
		}
		if (PlayerPrefs.GetString ("2player") == "mati" && PlayerPrefs.GetString ("1player") != "mati") {
			int urut = Random.Range (0, 1);
			pilihanInputSuit [4].SetActive (false);
			if (urut == 0) {
				pilihanInputSuit [0].transform.Find ("Batu").GetComponent<ButtonInput> ().OnPilih ();
				bermain ();
				pilihanInputSuit [5].SetActive (false);
			}
			if (urut == 1) {
				pilihanInputSuit [2].transform.Find ("Batu (2)").GetComponent<ButtonInput> ().OnPilih ();
				bermain ();
				pilihanInputSuit [3].SetActive (false);
			}
			if (PlayerPrefs.GetString ("3player") == "mati") {
				pilihanInputSuit [0].transform.Find ("Batu").GetComponent<ButtonInput> ().OnPilih ();
				bermain ();
				pilihanInputSuit [5].SetActive (false);
			}
		}

		if (PlayerPrefs.GetString ("2player") == "mati" && PlayerPrefs.GetString ("3player") != "mati") {
			int urut = Random.Range (0, 1);
			pilihanInputSuit [4].SetActive (false);
			if (urut == 0) {
				pilihanInputSuit [0].transform.Find ("Batu").GetComponent<ButtonInput> ().OnPilih ();
				bermain ();
				pilihanInputSuit [5].SetActive (false);
			}
			if (urut == 1) {
				pilihanInputSuit [2].transform.Find ("Batu (1)").GetComponent<ButtonInput> ().OnPilih ();
				bermain ();
				pilihanInputSuit [3].SetActive (false);
			}
			if (PlayerPrefs.GetString ("1player") == "mati") {
				pilihanInputSuit [2].transform.Find ("Batu (2)").GetComponent<ButtonInput> ().OnPilih ();
				bermain ();
				pilihanInputSuit [3].SetActive (false);
			}
		}
		timer = 3;
		multitime = true;
	}

	public void ModelAllStatus (bool status) {
		model1_1.SetActive (status);
		model2_1.SetActive (status);
		model1_2.SetActive (status);
		model2_2.SetActive (status);
		model1_3.SetActive (status);
		model2_3.SetActive (status);
	}

	public void gameObject_Scale(){
//		model1_1.gameObject.lo
//		model2_1.
//		model1_2.
//		model2_2.
//		model1_3.
//		model2_3.

	}

	public void canvasEnd(){
		canvas1.SetActive (false);
		canvas2.SetActive (false);
		canvas3.SetActive (false);
		canvas4.SetActive (false);
		canvas5.SetActive (false);
		canvas6.SetActive (false);
	}
	public void monsterInfo(){
	
		Debug.Log ("monsterinfo");
		playerhantuid1 = PlayerPrefs.GetString (Link.CHAR_1_ID);
		playerhantuid2 = PlayerPrefs.GetString (Link.CHAR_2_ID);
		playerhantuid3 = PlayerPrefs.GetString (Link.CHAR_3_ID);

		MonsterLevel1 = int.Parse(PlayerPrefs.GetString (Link.CHAR_1_LEVEL));
		MonsterLevel2 = int.Parse(PlayerPrefs.GetString (Link.CHAR_2_LEVEL));
		MonsterLevel3 = int.Parse(PlayerPrefs.GetString (Link.CHAR_3_LEVEL));
		MonsterGrade1 = int.Parse(PlayerPrefs.GetString (Link.CHAR_1_GRADE));
		MonsterGrade2 = int.Parse(PlayerPrefs.GetString (Link.CHAR_2_GRADE));
		MonsterGrade3 = int.Parse(PlayerPrefs.GetString (Link.CHAR_3_GRADE));

		Monster1GO.transform.Find ("Level").GetComponent<Text> ().text = MonsterLevel1.ToString();
		Monster2GO.transform.Find ("Level").GetComponent<Text> ().text = MonsterLevel2.ToString();
		Monster3GO.transform.Find ("Level").GetComponent<Text> ().text = MonsterLevel3.ToString();
		Monster1GO.transform.Find ("Icon_Char").GetComponent<Image> ().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + PlayerPrefs.GetString (Link.CHAR_1_FILE));
		Monster2GO.transform.Find ("Icon_Char").GetComponent<Image> ().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + PlayerPrefs.GetString (Link.CHAR_2_FILE));
		Monster3GO.transform.Find ("Icon_Char").GetComponent<Image> ().sprite = Resources.Load<Sprite> ("icon_char_Maps/" + PlayerPrefs.GetString (Link.CHAR_3_FILE));
		monstercurrentexp1= float.Parse( PlayerPrefs.GetString (Link.CHAR_1_MONSTEREXP));
		MonsterEXP1= int.Parse( PlayerPrefs.GetString (Link.CHAR_1_MONSTEREXP));
		Targetnextlevel1= float.Parse(PlayerPrefs.GetString (Link.CHAR_1_TARGETNL));

		monstercurrentexp2= float.Parse(PlayerPrefs.GetString (Link.CHAR_2_MONSTEREXP));
		MonsterEXP2= int.Parse( PlayerPrefs.GetString (Link.CHAR_2_MONSTEREXP));
		Targetnextlevel2= float.Parse(PlayerPrefs.GetString (Link.CHAR_2_TARGETNL));

		monstercurrentexp3= float.Parse(PlayerPrefs.GetString (Link.CHAR_3_MONSTEREXP));
		MonsterEXP3= int.Parse( PlayerPrefs.GetString (Link.CHAR_3_MONSTEREXP));
		Targetnextlevel3= float.Parse(PlayerPrefs.GetString (Link.CHAR_3_TARGETNL));

	}
	public IEnumerator areuReady () {
		yield return new WaitForSeconds (.5f);
		karaB.transform.localPosition = (karaB.transform.localPosition + new Vector3 (0, .0001f, 0));
		yield return new WaitForSeconds (.5f);
		getReady.SetActive (true);
		bukuBB.transform.localPosition = (bukuBB.transform.localPosition + new Vector3 (0, .0001f, 0));

		yield return new WaitForSeconds (1f);
		getReady.SetActive (false);
		Nyala.SetActive (true);
		yield return new WaitForSeconds (.2f);
		//ModelAllStatus (true);
		yield return new WaitForSeconds (.5f);
//		karaA.transform.FindChild ("Buku").GetComponent<SkinnedMeshRenderer> ().updateWhenOffscreen = false;
//		karaB.transform.FindChild ("Buku").GetComponent<SkinnedMeshRenderer> ().updateWhenOffscreen = false;
		if (PlayerPrefs.GetString ("berburu") != "ya") {
			 if (PlayerPrefs.GetString ("PLAY_TUTORIAL") == "TRUE") {
			model11a.Play ("select");
			model21a.Play ("select");
			model22a.Play ("select");
			model23a.Play ("select");
			model11a.PlayQueued ("idle");
			model21a.PlayQueued ("idle");
			model22a.PlayQueued ("idle");
			model23a.PlayQueued ("idle");
			}
			else
			{
			model11a.Play ("select");
			model21a.Play ("select");
			model12a.Play ("select");
			model22a.Play ("select");
			model13a.Play ("select");
			model23a.Play ("select");

			model11a.PlayQueued ("idle");
			model21a.PlayQueued ("idle");
			model12a.PlayQueued ("idle");
			model22a.PlayQueued ("idle");
			model13a.PlayQueued ("idle");
			model23a.PlayQueued ("idle");
			}
			

		} else {
			model11a.Play ("select");
			model21a.Play ("select");
			model22a.Play ("select");
			model23a.Play ("select");
			model11a.PlayQueued ("idle");
			model21a.PlayQueued ("idle");
			model22a.PlayQueued ("idle");
			model23a.PlayQueued ("idle");

		}

		//UI Pilih gerakan character
//		pilihanInputSuit [0].SetActive (true);
//		pilihanInputSuit [1].SetActive (true);
//		pilihanInputSuit [2].SetActive (true);
		if (PlayerPrefs.GetString (Link.JENIS) == "SINGLE") {

			if (PlayerPrefs.GetString ("PLAY_TUTORIAL") != "TRUE") {
				StartCoroutine (randomenemiesmovement ());
			} else {
				StartCoroutine (randomenemiesmovement ());
				//firstTimerTanding ();
			}
		}
		yield return new WaitForSeconds (2);
		if (PlayerPrefs.GetString (Link.JENIS) != "SINGLE") {
			getReadyStatus = true;
		}
		
	}
	void suitanimation(){


	}

	public void hidegameobject(GameObject one, GameObject two)
	{
		one.transform.Find("Canvas").GetComponent<Animator>().enabled=false;
		two.transform.Find("Canvas").GetComponent<Animator>().enabled=false;
		one.transform.Find("Canvas").gameObject.SetActive(false);
		two.transform.Find("Canvas").gameObject.SetActive(false);
		one.transform.Find("COPY_POSITION").GetComponentInChildren<SkinnedMeshRenderer>().enabled=false;
		two.transform.Find("COPY_POSITION").GetComponentInChildren<SkinnedMeshRenderer>().enabled=false;
		
	}

	void firstTimerTanding(){
		
		//	if (urutan1 [1].gameObject.name != "") {
			if (urutan1 [1].gameObject.name == "Hantu1B") {
				if (suit1 [1] == "Charge") {
					suit1 [0] = "Focus";
					//	urutan1[0].GetComponent<>
				}	
				if (suit1 [1] == "Focus") {
					suit1 [0] = "Block";
				}	
				if (suit1 [1] == "Block") {
					suit1 [0] = "Charge";
				}	
			}
			if (urutan1 [1].gameObject.name == "Hantu2B") {
				if (suit1 [1] == "Charge") {
					suit1 [0] = "Focus";
					//	urutan1[0].GetComponent<>
				}	
				if (suit1 [1] == "Focus") {
					suit1 [0] = "Block";
				}	
				if (suit1 [1] == "Block") {
					suit1 [0] = "Charge";
				}	
			}
			if (urutan1 [1].gameObject.name == "Hantu3B") {
				if (suit1 [1] == "Charge") {
					suit1 [0] = "Focus";
					//	urutan1[0].GetComponent<>
				}	
				if (suit1 [1] == "Focus") {
					suit1 [0] = "Block";
				}	
				if (suit1 [1] == "Block") {
					suit1 [0] = "Charge";
				}	
			}


			//kondisi 2
//			if (urutan2 [1].gameObject.name == "Hantu1B") {
//				if (suit1 [1] == "Charge") {
//					suit2 [0] = "Focus";
//					//	urutan1[0].GetComponent<>
//				}	
//				if (suit1 [1] == "Focus") {
//					suit2 [0] = "Block";
//				}	
//				if (suit1 [1] == "Block") {
//					suit2 [0] = "Charge";
//				}	
//			}
//			if (urutan2 [1].gameObject.name == "Hantu2B") {
//				if (suit2 [1] == "Charge") {
//					suit2 [0] = "Focus";
//					//	urutan1[0].GetComponent<>
//				}	
//				if (suit2 [1] == "Focus") {
//					suit2 [0] = "Block";
//				}	
//				if (suit2 [1] == "Block") {
//					suit2 [0] = "Charge";
//				}	
//			}
//			if (urutan2 [1].gameObject.name == "Hantu3B") {
//				if (suit3 [1] == "Charge") {
//					suit2 [0] = "Focus";
//					//	urutan1[0].GetComponent<>
//				}	
//				if (suit3 [1] == "Focus") {
//					suit2 [0] = "Block";
//				}	
//				if (suit3 [1] == "Block") {
//					suit2 [0] = "Charge";
//				}	
//			}
//
//			//kondisi 3
//
//			if (urutan3 [1].gameObject.name == "Hantu1B") {
//				if (suit1 [1] == "Charge") {
//					suit3 [0] = "Focus";
//					//	urutan1[0].GetComponent<>
//				}	
//				if (suit1 [1] == "Focus") {
//					suit3 [0] = "Block";
//				}	
//				if (suit1 [1] == "Block") {
//					suit3 [0] = "Charge";
//				}	
//			}
//			if (urutan3 [1].gameObject.name == "Hantu2B") {
//				if (suit2 [1] == "Charge") {
//					suit3 [0] = "Focus";
//					//	urutan1[0].GetComponent<>
//				}	
//				if (suit2 [1] == "Focus") {
//					suit3 [0] = "Block";
//				}	
//				if (suit2 [1] == "Block") {
//					suit3 [0] = "Charge";
//				}	
//			}
//			if (urutan3 [1].gameObject.name == "Hantu3B") {
//				if (suit3 [1] == "Charge") {
//					suit3 [0] = "Focus";
//					//	urutan1[0].GetComponent<>
//				}	
//				if (suit3 [1] == "Focus") {
//					suit3 [0] = "Block";
//				}	
//				if (suit3 [1] == "Block") {
//					suit3 [0] = "Charge";
//				}	
//			}
		//}
	
	}
	public void bermain(){
		PlayerPrefs.SetString ("Main", "ya");
	}
	void Update () {
		
        if (PlayerPrefs.GetString(Link.SEARCH_BATTLE) == "JOUSTING")
        {
            sh1a.transform.Find("Dark-MagicCircle").gameObject.SetActive(false);
            sh2a.transform.Find("Dark-MagicCircle").gameObject.SetActive(false);
            sh3a.transform.Find("Dark-MagicCircle").gameObject.SetActive(false);
            sh1.transform.Find("Dark-MagicCircle").gameObject.SetActive(false);
            sh2.transform.Find("Dark-MagicCircle").gameObject.SetActive(false);
            sh3.transform.Find("Dark-MagicCircle").gameObject.SetActive(false);
            pilihanInputSuit[3].SetActive(false);
            pilihanInputSuit[4].SetActive(false);
            pilihanInputSuit[5].SetActive(false);
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = CameraAR2.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (PlayerPrefs.GetInt("pos") == 1)
                {
                    h1cubeb.SetActive(false);
                    h2cubeb.SetActive(false);
                    h3cubeb.SetActive(false);
                    if (Physics.Raycast(ray, out hit, 1000.0F) && hit.transform.name == "Hantu1")
                    {

                        pilihanInputSuit[3].GetComponent<Button>().onClick.Invoke();
                        h2cubea.SetActive(false);
                        h3cubea.SetActive(false);

                    }
                    else if (Physics.Raycast(ray, out hit, 1000.0F) && hit.transform.tag == "Hantu2")
                    {
                        pilihanInputSuit[4].GetComponent<Button>().onClick.Invoke();
                        h1cubea.SetActive(false);
                        h3cubea.SetActive(false);

                    }
                    else if (Physics.Raycast(ray, out hit, 1000.0F) && hit.transform.tag == "Hantu3")
                    {
                        pilihanInputSuit[5].GetComponent<Button>().onClick.Invoke();
                        h2cubea.SetActive(false);
                        h1cubea.SetActive(false);

                    }
                    else {
                        Debug.Log("kay2pos1");
                        //  Debug.Log(hit.transform.name);
                    }
                }
                else {

                    h1cubea.SetActive(false);
                    h2cubea.SetActive(false);
                    h3cubea.SetActive(false);
                    if (Physics.Raycast(ray, out hit, 1000.0F) && hit.transform.tag == "Hantu1")
                    {
                        pilihanInputSuit[3].GetComponent<Button>().onClick.Invoke();
                        h2cubeb.SetActive(false);
                        h3cubeb.SetActive(false);

                    }
                    else if (Physics.Raycast(ray, out hit, 1000.0F) && hit.transform.tag == "Hantu2")
                    {
                        pilihanInputSuit[4].GetComponent<Button>().onClick.Invoke();
                        h1cubeb.SetActive(false);
                        h3cubeb.SetActive(false);

                    }
                    else if (Physics.Raycast(ray, out hit, 1000.0F) && hit.transform.tag == "Hantu3")
                    {
                        pilihanInputSuit[5].GetComponent<Button>().onClick.Invoke();
                        h2cubeb.SetActive(false);
                        h1cubeb.SetActive(false);

                    }
                    else {
                        Debug.Log("kay2pos2");
                        //   Debug.Log(hit.transform.name);
                    }

                }
            }

        }
        else {

            h1cubeb.SetActive(false);
            h2cubeb.SetActive(false);
            h3cubeb.SetActive(false);
            h1cubea.SetActive(false);
            h2cubea.SetActive(false);
            h3cubea.SetActive(false);
        }

		if (PlayerPrefs.GetInt ("win") == 1 && karaBanimation.isPlaying==false) {
			karaBanimation.PlayQueued ("menanggame", QueueMode.PlayNow);
		}
		if (level1 == false) {
			times -= Time.deltaTime;
		}
		if (times <= 0 && attacking >= 3&&tanding==false&& PlayerPrefs.GetString (Link.JENIS) == "SINGLE") {
			critical = true;
			PlayerPrefs.SetString ("Critical", "y");
		} 
			

		//Debug.Log(PlayerPrefs.GetString ("Urutan1"));
		//Debug.Log(PlayerPrefs.GetString ("Suit1"));
		//Debug.Log (Random.value);
		//Debug.Log(PlayerPrefs.GetInt ("Jumlah"));
		dg.text = PlayerPrefs.GetInt ("pos").ToString ();

		//Debug.Log (PlayerPrefs.GetString (Link.JENIS));
		//Debug.Log (PlayerPrefs.GetInt ("Jumlah"));
		//Debug.Log (panggil_url);
		//		Debug.Log (timeUps);

		if (PlayerPrefs.GetString ("Main") == "ya") {
//			pilihanInputSuit [0].SetActive (false);
//			pilihanInputSuit [1].SetActive (false);
//			pilihanInputSuit [2].SetActive (false);
			//urutan2 [1].SetActive (false);
			//urutan3 [1].SetActive (false);
				if (PlayerPrefs.GetInt ("pos") == 1) {
				if (PlayerPrefs.GetString ("Urutan1m") == "Hantu1A") {
						sh1a.SetActive (true);
                  
						//	hantuchoose1.SetActive (true);



						if (PlayerPrefs.GetInt ("Jumlah") == 0) {
							pilihanInputSuit [0].SetActive (true);
						}

				} else if (PlayerPrefs.GetString ("Urutan1m") == "Hantu2A") {

						sh2a.SetActive (true);

						//hantuchoose2.SetActive (true);


						if (PlayerPrefs.GetInt ("Jumlah") == 0) {
							pilihanInputSuit [1].SetActive (true);
						}
					} else {

						sh3a.SetActive (true);

						//hantuchoose3.SetActive (true);


						if (PlayerPrefs.GetInt ("Jumlah") == 0) {
							pilihanInputSuit [2].SetActive (true);
						}
					}
				} else {

					if (PlayerPrefs.GetString ("Urutan1") == "Hantu1B") {
						sh1.SetActive (true);
						//	hantuchoose1.SetActive (true);


			
						if (PlayerPrefs.GetInt ("Jumlah") == 0) {
							pilihanInputSuit [0].SetActive (true);
						}

					} else if (PlayerPrefs.GetString ("Urutan1") == "Hantu2B") {

						sh2.SetActive (true);

						//hantuchoose2.SetActive (true);

			
						if (PlayerPrefs.GetInt ("Jumlah") == 0) {
							pilihanInputSuit [1].SetActive (true);
						}
					} else {

						sh3.SetActive (true);

						//hantuchoose3.SetActive (true);

			
						if (PlayerPrefs.GetInt ("Jumlah") == 0) {
							pilihanInputSuit [2].SetActive (true);
						}
					}
				}
		
		
//			cameraB.transform.position = new Vector3 (8.75f, 9.98f, 12.7f);
//			cameraB.transform.rotation = Quaternion.Euler (0, 295.4f, 0);
//			cameraB.transform.FindChild ("Plane").gameObject.SetActive (true);

			//Time.timeScale = 0.3f;
			getReadyStatus = true;
		} 
		else {



		}
		if (PlayerPrefs.GetInt ("Jumlah") == 1) {

			sh1.SetActive (false);
			sh2.SetActive (false);
			sh3.SetActive (false);
			sh1a.SetActive (false);
			sh2a.SetActive (false);
			sh3a.SetActive (false);
			//if (PlayerPrefs.GetString ("Urutan1") == "Hantu1B") {

		
//
//				pilihanInputSuit [0].SetActive (true);
//				if (PlayerPrefs.GetString ("Suit1")!="Kosong") {
//					hantugo2.SetActive(false);
//					hantugo3.SetActive(false);
//				}
//
//			}
//			else if (PlayerPrefs.GetString ("Urutan1") == "Hantu2B") {
//				hantugo1.SetActive(false);
//				hantugo3.SetActive(false);
//				hantuchoose2.SetActive (true);
//				pilihanInputSuit [1].SetActive (true);
//				if (PlayerPrefs.GetString ("Suit1")!="Kosong") {
//					hantugo1.SetActive(false);
//					hantugo3.SetActive(false);
//				}
//			}
//			else{
//				hantugo1.SetActive(false);
//				hantugo2.SetActive(false);
//				hantuchoose3.SetActive (true);
//				pilihanInputSuit [2].SetActive (true);
//				if (PlayerPrefs.GetString ("Suit1")!="Kosong") {
//					hantugo1.SetActive(false);
//					hantugo2.SetActive(false);
//				}
//			}
//
//

//

		
			if (PlayerPrefs.GetString (Link.JENIS) == "SINGLE") {

				//INI SAYA TARUH DISINI.


			}


			timeUps = true;
			if (panggil_url == false) {
				panggil_url = true;


				if (PlayerPrefs.GetString (Link.JENIS) == "SINGLE") {
					


					//urutan1 [0] = GameObject.Find ("Hantu1A");
					urutan1 [1] = GameObject.Find (PlayerPrefs.GetString ("Urutan1"));


					healthBar1 [0] = urutan1 [0].transform.Find ("Canvas").transform.Find ("Image").gameObject;
					healthBar1 [1] = urutan1 [1].transform.Find ("Canvas").transform.Find ("Image").gameObject;
					

					//suit1 [0] = "Block";
					suit1 [1] = PlayerPrefs.GetString ("Suit1");


					urutan2 [0] = GameObject.Find ("Hantu2A");
					urutan2 [1] = GameObject.Find (PlayerPrefs.GetString ("Urutan2"));

					healthBar2 [0] = urutan2 [0].transform.Find ("Canvas").transform.Find ("Image").gameObject;
//					healthBar2 [1] = urutan2 [1].transform.FindChild ("Canvas").transform.FindChild ("Image").gameObject;



					//suit2 [0] = "Charge";
					suit2 [1] = PlayerPrefs.GetString ("Suit2");

					urutan3 [0] = GameObject.Find ("Hantu3A");
					urutan3 [1] = GameObject.Find (PlayerPrefs.GetString ("Urutan3"));


					healthBar3 [0] = urutan3 [0].transform.Find ("Canvas").transform.Find ("Image").gameObject;
					//healthBar3 [1] = urutan3 [1].transform.FindChild ("Canvas").transform.FindChild ("Image").gameObject;


					//suit3 [0] = "Focus";
					suit3 [1] = PlayerPrefs.GetString ("Suit3");




					waiting.SetActive (false);
					//information.SetActive (true);
					if (PlayerPrefs.GetString ("PLAY_TUTORIAL") == "TRUE") {
						//firstTimerTanding ();
						//StartCoroutine (randomenemiesmovement ());
						StartCoroutine (urutanPlay ());

					} else {
						StartCoroutine (urutanPlay ());
					}


				} 
				else {
					StartCoroutine (sendFormation ());
				}


			}

		} 
		else {
			//pilihanInputSuit [0].SetActive (true);
		}
	
		if (getReadyStatus) {
			timer -= Time.deltaTime;
			scrollBar.transform.Find("Scrollbar").GetComponent<Scrollbar>().size = timer / 3f;
		}




		if (timer  < 0 && timeUps == false) {
			timeUps = true;


//			for (int i = 0; i < alpha.Count; i++) {
//				string temp = alpha [0];
//				int randomIndex = Random.Range (i, alpha.Count);
//				alpha [i] = alpha [randomIndex];
//				alpha [randomIndex] = temp;
//			}

			if (PlayerPrefs.GetString (Link.JENIS) == "SINGLE") {
				StartCoroutine (randomPilihanInput ());
			} else {
			//	multiplayer ();
			}


		}
		if (timer  < 0 && multitime) {
			//StartCoroutine (randomPilihanInput ());
			multitime = false;
		}
		if (PlayerPrefs.GetString (Link.JENIS) == "SINGLE" && PlayerPrefs.GetInt ("win") == 1 && levelingmate) {
			float fExp1 = MonsterEXP1 / Targetnextlevel1;
			float fExp2 = MonsterEXP2 / Targetnextlevel2;
			float fExp3 = MonsterEXP3 / Targetnextlevel3;
			//Debug.Log (fExp);
			Monster1GO.transform.Find ("EXPBar1").transform.Find ("Expbar").GetComponent<Image> ().fillAmount = fExp1;
			Monster2GO.transform.Find ("EXPBar2").transform.Find ("Expbar").GetComponent<Image> ().fillAmount = fExp2;
			Monster3GO.transform.Find ("EXPBar3").transform.Find ("Expbar").GetComponent<Image> ().fillAmount = fExp3;
			//				Level.text = MonsterLevel.ToString ();

			if (Targetnextlevel1 != 0) {
				if (MonsterEXP1 >= Targetnextlevel1) {

					tempmonsterexp1 = monstercurrentexp1 - Targetnextlevel1;

					MonsterEXP1 = (int)tempmonsterexp1;
					monstercurrentexp1 = tempmonsterexp1;

					MonsterLevel1 += 1;
					MonsterEXP1 = (int)Mathf.MoveTowards (0, monstercurrentexp1, 10 * MonsterLevel1);
				}
			}
			if (Targetnextlevel2 != 0) {
				if (MonsterEXP2 >= Targetnextlevel2) {

					tempmonsterexp2 = monstercurrentexp2 - Targetnextlevel2;

					MonsterEXP2 = (int)tempmonsterexp2;
					monstercurrentexp2 = tempmonsterexp2;

					MonsterLevel2 += 1;
					MonsterEXP2 = (int)Mathf.MoveTowards (0, monstercurrentexp2, 10 * MonsterLevel1);
				}
			}
			if (Targetnextlevel3 != 0) {
				if (MonsterEXP3 >= Targetnextlevel3) {

					tempmonsterexp3 = monstercurrentexp3 - Targetnextlevel3;

					MonsterEXP3 = (int)tempmonsterexp3;
					monstercurrentexp3 = tempmonsterexp3;

					MonsterLevel3 += 1;
					MonsterEXP3 = (int)Mathf.MoveTowards (0, monstercurrentexp3, 10 * MonsterLevel1);
				}
			}

			MonsterEXP1 = (int)Mathf.MoveTowards (MonsterEXP1, monstercurrentexp1, 10*MonsterLevel1);
			MonsterEXP2 = (int)Mathf.MoveTowards (MonsterEXP2, monstercurrentexp2, 10*MonsterLevel1);
			MonsterEXP3 = (int)Mathf.MoveTowards (MonsterEXP3, monstercurrentexp3, 10*MonsterLevel1);
			//Debug.Log (MonsterEXP);
			// untuk effect level up
			if (Monster1GO.transform.Find ("EXPBar1").transform.Find ("Expbar").GetComponent<Image> ().fillAmount >= 1f) {
				Debug.Log ("levelup");
				Monster1GO.transform.Find ("leveluptext").gameObject.SetActive (true);
				Monster1GO.transform.Find ("Level").GetComponent<Text> ().text = MonsterLevel1.ToString();
				GameObject blam = Instantiate (effect, m1);
				//gethantunextlevel.OnClick ();
				//gethantuuser.Reload ();
				Targetnextlevel1 = PlayerPrefs.GetFloat ("target1");

			} else {


			}
			if (Monster2GO.transform.Find ("EXPBar2").transform.Find ("Expbar").GetComponent<Image> ().fillAmount >= 1f) {
				Debug.Log ("levelup");
				Monster2GO.transform.Find ("leveluptext").gameObject.SetActive (true);
				Monster2GO.transform.Find ("Level").GetComponent<Text> ().text = MonsterLevel2.ToString();
				GameObject blam = Instantiate (effect, m2);
				//gethantunextlevel.OnClick ();
				//gethantuuser.Reload ();
				Targetnextlevel2 = PlayerPrefs.GetFloat ("target2");

			}
			else {


			}
			if (Monster3GO.transform.Find ("EXPBar3").transform.Find ("Expbar").GetComponent<Image> ().fillAmount >= 1f) {
				Debug.Log ("levelup");
				Monster3GO.transform.Find ("leveluptext").gameObject.SetActive (true);
				Monster3GO.transform.Find ("Level").GetComponent<Text> ().text = MonsterLevel3.ToString();
				GameObject blam = Instantiate (effect, m3);
				//gethantunextlevel.OnClick ();
				//gethantuuser.Reload ();
				Targetnextlevel3 = PlayerPrefs.GetFloat ("target3");

			} else {


			}
			switch (MonsterGrade1) {
			case 1:
				Monster1GO.transform.Find ("bintangsusunstats").transform.Find ("bintang1").gameObject.SetActive (true);
				if (MonsterLevel1 == 15) {
					//	Level.text = "Max";
					//	Mexp.text = "Max";
					//	EXPBar.fillAmount = 1;
					//	buttondeactivate ();
				}
				else {
					//	buttonactivate ();
				}
				break;
			case 2:
				Monster1GO.transform.Find ("bintangsusunstats").transform.Find ("bintang2").gameObject.SetActive (true);
				if (MonsterLevel1 == 20) {
					//Level.text = "Max";
					//Mexp.text = "Max";
					//EXPBar.fillAmount = 1;
					//buttondeactivate ();
				} else {
					//	buttonactivate ();
				}
				break;
			case 3:
				Monster1GO.transform.Find ("bintangsusunstats").transform.Find ("bintang3").gameObject.SetActive (true);
				if (MonsterLevel1 == 25) {
					//Level.text = "Max";
					//						Mexp.text = "Max";
					//						EXPBar.fillAmount = 1;
					//						buttondeactivate ();
				} else {
					//buttonactivate ();
				}
				break;
			case 4:
				Monster1GO.transform.Find ("bintangsusunstats").transform.Find ("bintang4").gameObject.SetActive (true);
				if (MonsterLevel1 == 30) {
					//						Level.text = "Max";
					//						Mexp.text = "Max";
					//						EXPBar.fillAmount = 1;
					//						buttondeactivate ();
				} else {
					//buttonactivate ();
				}
				break;
			case 5:
				Monster1GO.transform.Find ("bintangsusunstats").transform.Find ("bintang5").gameObject.SetActive (true);
				if (MonsterLevel1 == 35) {
					//						Level.text = "Max";
					//						Mexp.text = "Max";
					//						EXPBar.fillAmount = 1;
					//buttondeactivate ();
				} else {
					//buttonactivate ();
				}
				break;
			case 6:
				Monster1GO.transform.Find ("bintangsusunstats").transform.Find ("bintang6").gameObject.SetActive (true);
				if (MonsterLevel1 == 40) {
					//						Level.text = "Max";
					//						Mexp.text = "Max";
					//						EXPBar.fillAmount = 1;
					//						buttondeactivate ();
				} else {
					//buttonactivate ();
				}
				break;
			}
			switch (MonsterGrade2) {
			case 1:
				Monster2GO.transform.Find ("bintangsusunstats").transform.Find ("bintang1").gameObject.SetActive (true);
				if (MonsterLevel1 == 15) {
					//	Level.text = "Max";
					//	Mexp.text = "Max";
					//	EXPBar.fillAmount = 1;
					//	buttondeactivate ();
				} else {
					//	buttonactivate ();
				}
				break;
			case 2:
				Monster2GO.transform.Find ("bintangsusunstats").transform.Find ("bintang2").gameObject.SetActive (true);
				if (MonsterLevel1 == 20) {
					//Level.text = "Max";
					//Mexp.text = "Max";
					//EXPBar.fillAmount = 1;
					//buttondeactivate ();
				} else {
					//	buttonactivate ();
				}
				break;
			case 3:
				Monster2GO.transform.Find ("bintangsusunstats").transform.Find ("bintang3").gameObject.SetActive (true);
				if (MonsterLevel1 == 25) {
					//Level.text = "Max";
					//						Mexp.text = "Max";
					//						EXPBar.fillAmount = 1;
					//						buttondeactivate ();
				} else {
					//buttonactivate ();
				}
				break;
			case 4:
				Monster2GO.transform.Find ("bintangsusunstats").transform.Find ("bintang4").gameObject.SetActive (true);
				if (MonsterLevel1 == 30) {
					//						Level.text = "Max";
					//						Mexp.text = "Max";
					//						EXPBar.fillAmount = 1;
					//						buttondeactivate ();
				} else {
					//buttonactivate ();
				}
				break;
			case 5:
				Monster2GO.transform.Find ("bintangsusunstats").transform.Find ("bintang5").gameObject.SetActive (true);
				if (MonsterLevel1 == 35) {
					//						Level.text = "Max";
					//						Mexp.text = "Max";
					//						EXPBar.fillAmount = 1;
					//buttondeactivate ();
				} else {
					//buttonactivate ();
				}
				break;
			case 6:
				Monster2GO.transform.Find ("bintangsusunstats").transform.Find ("bintang6").gameObject.SetActive (true);
				if (MonsterLevel1 == 40) {
					//						Level.text = "Max";
					//						Mexp.text = "Max";
					//						EXPBar.fillAmount = 1;
					//						buttondeactivate ();
				} else {
					//buttonactivate ();
				}
				break;
			}
			switch (MonsterGrade3) {
			case 1:
				Monster3GO.transform.Find ("bintangsusunstats").transform.Find ("bintang1").gameObject.SetActive (true);
				if (MonsterLevel1 == 15) {
					//	Level.text = "Max";
					//	Mexp.text = "Max";
					//	EXPBar.fillAmount = 1;
					//	buttondeactivate ();
				} else {
					//	buttonactivate ();
				}
				break;
			case 2:
				Monster3GO.transform.Find ("bintangsusunstats").transform.Find ("bintang2").gameObject.SetActive (true);
				if (MonsterLevel1 == 20) {
					//Level.text = "Max";
					//Mexp.text = "Max";
					//EXPBar.fillAmount = 1;
					//buttondeactivate ();
				} else {
					//	buttonactivate ();
				}
				break;
			case 3:
				Monster3GO.transform.Find ("bintangsusunstats").transform.Find ("bintang3").gameObject.SetActive (true);
				if (MonsterLevel1 == 25) {
					//Level.text = "Max";
					//						Mexp.text = "Max";
					//						EXPBar.fillAmount = 1;
					//						buttondeactivate ();
				} else {
					//buttonactivate ();
				}
				break;
			case 4:
				Monster3GO.transform.Find ("bintangsusunstats").transform.Find ("bintang4").gameObject.SetActive (true);
				if (MonsterLevel1 == 30) {
					//						Level.text = "Max";
					//						Mexp.text = "Max";
					//						EXPBar.fillAmount = 1;
					//						buttondeactivate ();
				} else {
					//buttonactivate ();
				}
				break;
			case 5:
				Monster3GO.transform.Find ("bintangsusunstats").transform.Find ("bintang5").gameObject.SetActive (true);
				if (MonsterLevel1 == 35) {
					//						Level.text = "Max";
					//						Mexp.text = "Max";
					//						EXPBar.fillAmount = 1;
					//buttondeactivate ();
				} else {
					//buttonactivate ();
				}
				break;
			case 6:
				Monster3GO.transform.Find ("bintangsusunstats").transform.Find ("bintang6").gameObject.SetActive (true);
				if (MonsterLevel1 == 40) {
					//						Level.text = "Max";
					//						Mexp.text = "Max";
					//						EXPBar.fillAmount = 1;
					//						buttondeactivate ();
				} else {
					//buttonactivate ();
				}
				break;
			}
		//	levelingmate = false;
		}
		//		healthA1.GetComponent<filled> ().currenthealth = health1 [0];
		//		healthA2.GetComponent<filled> ().currenthealth = health2 [0];
		//		healthA3.GetComponent<filled> ().currenthealth = health3 [0];
		//		healthB1.GetComponent<filled> ().currenthealth = health1 [1];
		//		healthB2.GetComponent<filled> ().currenthealth = health2 [1];
		//		healthB3.GetComponent<filled> ().currenthealth = health3 [1];

		if (PlayerPrefs.GetString (Link.JENIS) == "SINGLE" && presentDone == false) {

			if (PlayerPrefs.GetInt ("win") == 1) {
				if (PlayerPrefs.GetString ("berburu") == "ya") {
					StartCoroutine (sendSummon (PlayerPrefs.GetString (Link.POS_1_CHAR_1_FILE), "Kumon"));
					presentDone = true;
				} 
				else {
                  //  if (!replay) {
					  if(PlayerPrefs.GetString ("PLAY_TUTORIAL") == "TRUE") 
					  {

					  }
					  else
					  {
						
						nextornot();
 						StartCoroutine(Stage());
					  }
                    //      }
					WinnerPresent (PlayerPrefs.GetString(Link.SEARCH_BATTLE));
					// presentDone = true;
				}
				SceneManagerHelper.LoadSoundFX("Win");
//				if (CurrentbankExp1 < 1000) {
//
//					transform.FindChild ("1000").GetComponent<Button> ().interactable = false;
//
//					if (CurrentbankExp < 100) {
//						transform.FindChild ("100").GetComponent<Button> ().interactable = false;
//						if (CurrentbankExp < 10) {
//
//							transform.FindChild ("10").GetComponent<Button> ().interactable = false;
//						}
//					}
//				} else {
//					buttonactivate ();
//				}

			} else {
			
			}

		} 
		// Multiplayer
		if (PlayerPrefs.GetString (Link.JENIS) == "MULTIPLE" && presentDone == false) 
		{
			if (PlayerPrefs.GetInt ("win") == 1) {
				WinnerPresent (PlayerPrefs.GetString(Link.SEARCH_BATTLE));
				SceneManagerHelper.LoadSoundFX("Win");
				StartCoroutine (SendReward2 ());
				presentDone = true;
				
			} else {
			
			}
		
		}

		//done 

	}
	void hilangkanenvi(){
		if (PlayerPrefs.GetString (Link.LOKASI) == "Warehouse") {
			warehouse.SetActive (false);
		} else if (PlayerPrefs.GetString (Link.LOKASI) == "School") {
			school.SetActive (false);
		} else if (PlayerPrefs.GetString (Link.LOKASI) == "Hospital") {
			hospital.SetActive (false);
		} else if (PlayerPrefs.GetString (Link.LOKASI) == "Bridge") {
			bridge.SetActive (false);
		} else if (PlayerPrefs.GetString (Link.LOKASI) == "Graveyard") {
			graveyard.SetActive (false);
		}else if (PlayerPrefs.GetString (Link.LOKASI )== "ArenaDuel"){
				ArenaDuel.SetActive (false); 
		}
        else if (PlayerPrefs.GetString(Link.LOKASI) == "ArenaDuelAR")
        {
            ArenaDuelAR.SetActive(false);
        }
        else {
			oldhouse.SetActive (false);
		}
	}

	void EndingOption(int whichEnding)
	{
		switch(whichEnding)
		{
			case 1:
			EndOptionButton.transform.Find ("Arena").gameObject.SetActive (true);
			EndOptionButton.transform.Find ("Replay").gameObject.SetActive (false);
			EndOptionButton.transform.Find ("Home").gameObject.SetActive (false);
			EndOptionButton.transform.Find ("Next").gameObject.SetActive (false);
			break;
		}

	}
	void monsterleveling(){
		
		StartCoroutine(sendEXPtri(playerhantuid1,playerhantuid2,playerhantuid3,mapexpsimpan));
	

	}
	void monsterleveling2(){
		
		 if (MonsterGrade2 == 1) {
			if (MonsterLevel2 >= 15) {
				Targetnextlevel2=999999;
				//do nothing
			} else {
				StartCoroutine(sendEXP2(playerhantuid2,mapexpsimpan));
			}
		}
		if (MonsterGrade2 == 2) {
			if (MonsterLevel2 >= 20) {
				Targetnextlevel2=999999;
				//do nothing
			} else {
				StartCoroutine(sendEXP2(playerhantuid2,mapexpsimpan));
			}
		}
		 if (MonsterGrade2 == 3) {
			if (MonsterLevel2 >= 25) {
				Targetnextlevel2=999999;
				//do nothing
			} else {
				StartCoroutine(sendEXP2(playerhantuid2,mapexpsimpan));
			}
		}
		if (MonsterGrade2 == 4) {
			if (MonsterLevel2 >= 30) {
				Targetnextlevel2=999999;
				//do nothing
			} else {
				StartCoroutine(sendEXP2(playerhantuid2,mapexpsimpan));
			}
		}
		if (MonsterGrade2 == 5) {
			if (MonsterLevel2 >= 35) {
				Targetnextlevel2=999999;
				//do nothing
			} else {
				StartCoroutine(sendEXP2(playerhantuid2,mapexpsimpan));
			}
		}
		if (MonsterGrade2 == 6) {
			if (MonsterLevel2 >= 40) {
				Targetnextlevel2=999999;
				//do nothing
			} else {
				StartCoroutine(sendEXP2(playerhantuid2,mapexpsimpan));
			}
		}

	}
	void monsterleveling3(){
		
		if (MonsterGrade3 == 1) {
			if (MonsterLevel3 >= 15) {
				Targetnextlevel3=999999;
				//do nothing
			} else {
				StartCoroutine(sendEXP3(playerhantuid3,mapexpsimpan));
			}
		}
		if (MonsterGrade3 == 2) {
			if (MonsterLevel3 >= 20) {
				Targetnextlevel3=999999;
				//do nothing
			} else {
				StartCoroutine(sendEXP3(playerhantuid3,mapexpsimpan));
			}
		}
		if (MonsterGrade3 == 3) {
			if (MonsterLevel3 >= 25) {
				Targetnextlevel3=999999;
				//do nothing
			} else {
				StartCoroutine(sendEXP3(playerhantuid3,mapexpsimpan));
			}
		}
		if (MonsterGrade3 == 4) {
			if (MonsterLevel3 >= 30) {
				Targetnextlevel3=999999;
				//do nothing
			} else {
				StartCoroutine(sendEXP3(playerhantuid3,mapexpsimpan));
			}
		}
		if (MonsterGrade3 == 5) {
			if (MonsterLevel3 >= 35) {
				Targetnextlevel3=999999;
				//do nothing
			} else {
				StartCoroutine(sendEXP3(playerhantuid3,mapexpsimpan));
			}
		}
		if (MonsterGrade3 == 6) {
			if (MonsterLevel3 >= 40) {
				Targetnextlevel3=999999;
				//do nothing
			} else {
				StartCoroutine(sendEXP3(playerhantuid3,mapexpsimpan));
			}

		}
	}
	public void levelingbro(){
		levelingmate = true;
	}
	private IEnumerator sendSummon(string file, string jenis)
	{
		string url = Link.url + "huntGhost";
		WWWForm form = new WWWForm ();
		form.AddField ("MY_ID", PlayerID);
		form.AddField ("FILE", file);
		form.AddField ("JENIS", jenis);
		form.AddField ("LOCATION",PlayerPrefs.GetString ("kodetempat"));
		WWW www = new WWW(url,form);
		yield return www;
		if (www.error == null) {
			//testsummonings
			var jsonString = JSON.Parse (www.text);
			Debug.Log(jsonString ["data"] ["id"] );
            Debug.Log(jsonString);
            hasilburu.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon_charLama/" + PlayerPrefs.GetString(Link.POS_1_CHAR_1_FILE));
            hasilburu.transform.Find("backname").Find("Namegreen").Find("Name").GetComponent<Text>().text = jsonString["databuru"]["name"];
            hasilburu.transform.Find("Stats").Find("ElementText").GetComponent<Text>().text = jsonString["databuru"]["type"];
            hasilburu.transform.Find("Stats").Find("TypeText").GetComponent<Text>().text = jsonString["databuru"]["element"];
            hasilburu.transform.Find("Stats").Find("DefendText").GetComponent<Text>().text = jsonString["databuru"]["DEFEND"];
            hasilburu.transform.Find("Stats").Find("AttackText").GetComponent<Text>().text = jsonString["databuru"]["ATTACK"];
            hasilburu.transform.Find("Stats").Find("HPText").GetComponent<Text>().text = jsonString["databuru"]["HP"];
            int test;
            var angka = int.TryParse(jsonString["databuru"]["grade"], out test);
            if (test != null || test != 0)
            {
                switch (test)
                {

                    case 1:
                        bintang1.SetActive(true);
                        bintang2.SetActive(false);
                        bintang3.SetActive(false);
                        bintang4.SetActive(false);
                        bintang5.SetActive(false);
                        break;
                    case 2:
                        bintang2.SetActive(true);
                        bintang1.SetActive(false);
                        bintang3.SetActive(false);
                        bintang4.SetActive(false);
                        bintang5.SetActive(false);
                        break;
                    case 3:
                        bintang3.SetActive(true);
                        bintang1.SetActive(false);
                        bintang2.SetActive(false);
                        bintang4.SetActive(false);
                        bintang5.SetActive(false);
                        break;
                    case 4:
                        bintang4.SetActive(true);
                        bintang1.SetActive(false);
                        bintang2.SetActive(false);
                        bintang3.SetActive(false);
                        bintang5.SetActive(false);
                        break;
                    case 5:
                        bintang5.SetActive(true);
                        bintang1.SetActive(false);
                        bintang2.SetActive(false);
                        bintang3.SetActive(false);
                        bintang4.SetActive(false);
                        break;

                }
            }
            Debug.Log (www.text);

		} else {
			//failed
		}

	}
	public void WinnerPresent(string battletype){
		
		if(battletype=="ONLINE")
		{
			DropRewardsImage[0].sprite=Resources.Load<Sprite>("icon_item/" + "ArenaPoint");
			ClaimText.text = PlayerPrefs.GetString (Link.ArenaGetPoint, "50") ;
			StartCoroutine (SendReward2 ());
			//ClaimUI.SetActive (true);
			presentDone = true;
		}
		else
		{
		var presentcode = RandomWeighted();
		var winning = Random.value;
		var emas = 0;
		EXPValueText.text = "100";
		var presentType = PlayerPrefs.GetString("RewardItemType"+presentcode.ToString());
		var presentQuantity = PlayerPrefs.GetString("RewardItemQuantity"+presentcode.ToString());
		var presentName = PlayerPrefs.GetString("RewardItemName"+presentcode.ToString());
		var presentFileName = PlayerPrefs.GetString("RewardItemFN"+presentcode.ToString());
		if(presentType=="Item")
		{
			if(presentFileName=="Coin")
			{
				emas = int.Parse(presentQuantity);
			}
			else
			{
				formkirimreward.AddField(presentName, presentQuantity);
			}
			DropRewardsImage[0].sprite=Resources.Load<Sprite>("icon_item/" + presentFileName);
			
			ClaimText.text = presentQuantity + " " + presentName;
		}
		else
		{
			DropRewardsImage[1].sprite=Resources.Load<Sprite>("icon_item/" + presentFileName);
			//formkirimreward.AddField(presentName, presentQuantity);
			formkirimreward.AddField ("ITEM", presentName);
			ClaimText.text = presentQuantity + " " + presentName;
		}
		//formkirimreward.AddField ("GOLD", 100);
		EXPValueText.text = "100";
		
			formkirimreward.AddField ("GOLD", 100 + emas);
 			StartCoroutine (SendReward ());
			//StartCoroutine (sendEXP (idhantuplayer, 1000));
		// }
		ClaimUI.SetActive (true);
		presentDone = true;
		PlayerPrefs.SetString ("1player", "selesai");
		PlayerPrefs.SetString ("2player", "selesai");
		PlayerPrefs.SetString ("3player", "selesai");
		}
		
	

	}

	IEnumerator SendReward(){
		
		yield return new WaitForSeconds (.5f);
		//var expsingle = PlayerPrefs.GetInt ("MAPSEXP") * 3;
	//	Debug.Log (expsingle);
			string url = Link.url + "update_data_user";
			//WWWForm form = new WWWForm ();
		//formkirimreward.AddField ("JumlahXpTransfer", (expsingle));
		formkirimreward.AddField ("MY_ID", PlayerID);
		formkirimreward.AddField ("MODE", PlayerPrefs.GetString(Link.SEARCH_BATTLE));
		formkirimreward.AddField ("WIN", 1);
		formkirimreward.AddField ("xpm", mapexpsimpan);
		formkirimreward.AddField ("xpp", "100");

		//formkirimreward.AddField ("ITEM", equipmentreward[0]);
		WWW www = new WWW(url,formkirimreward);
			yield return www;

			if (www.error == null) {
			var jsonStringer =  JSON.Parse (www.text);
			PlayerPrefs.SetString("MaxE",jsonStringer["data"]["MaxEnergy"]);
			monsterleveling();
			//berburuselesai

			} 

		Debug.Log ("sendreward");
	//	var jsonString = JSON.Parse (www.text);
		//PlayerPrefs.SetString ("BATU", jsonString ["data"]);


		
	}
	IEnumerator SendReward2(){

		//yield return new WaitForSeconds (.5f);
		//var expsingle = PlayerPrefs.GetInt ("MAPSEXP") * 3;
		//	Debug.Log (expsingle);
		string url = Link.url + "update_data_user";
		//WWWForm form = new WWWForm ();
		//formkirimreward.AddField ("JumlahXpTransfer", (expsingle));
		formkirimreward.AddField ("MY_ID", PlayerID);
		formkirimreward.AddField ("ar", PlayerPrefs.GetString (Link.ArenaGetPoint, "50"));
		formkirimreward.AddField ("MODE", PlayerPrefs.GetString(Link.SEARCH_BATTLE));
		formkirimreward.AddField ("WIN", 1);

		//formkirimreward.AddField ("ITEM", equipmentreward[0]);
		WWW www = new WWW(url,formkirimreward);
		yield return www;

		if (www.error == null) {
			var jsonStringer =  JSON.Parse (www.text);
			print(www.text);
			PlayerPrefs.SetString("MaxE",jsonStringer["data"]["MaxEnergy"]);
			monsterleveling();
			//berburuselesai

		} 

		Debug.Log ("sendreward");
		//	var jsonString = JSON.Parse (www.text);
		//PlayerPrefs.SetString ("BATU", jsonString ["data"]);



	}

	private IEnumerator sendEXPtri(string hantuplayerid1,string hantuplayerid2, string hantuplayerid3, int Exp)
	{

		Debug.Log ("TES");
		Debug.Log (PlayerID);
		Debug.Log (hantuplayerid1);
		Debug.Log (hantuplayerid2);
		Debug.Log (hantuplayerid3);
		Debug.Log (Exp);
		string url = Link.url + "send_xp_tri";
		WWWForm form = new WWWForm ();
		form.AddField ("MY_ID", PlayerID);
		form.AddField ("PlayerHantuID1", hantuplayerid1);
		form.AddField ("PlayerHantuID2", hantuplayerid2);
		form.AddField ("PlayerHantuID3", hantuplayerid3);
		form.AddField ("EXPERIENCE", Exp);
		//form.AddField ("CURRENTEXPB", Latestexpbank);

		WWW www = new WWW(url,form);
		yield return www;

		if (www.error == null) {

			var jsonString = JSON.Parse (www.text);
			PlayerPrefs.SetFloat("target1", float.Parse(jsonString ["code"] ["Targetnextlevel1"]));
			PlayerPrefs.SetFloat("target2", float.Parse(jsonString ["code"] ["Targetnextlevel2"]));
			PlayerPrefs.SetFloat("target3", float.Parse(jsonString ["code"] ["Targetnextlevel3"]));
			monstercurrentexp1 += Exp;
			monstercurrentexp2 += Exp;
			monstercurrentexp3 += Exp;
			PlayerPrefs.SetString (Link.CHAR_1_MONSTEREXP, jsonString ["code"] ["monstercurrentexp1"]);
			PlayerPrefs.SetString(Link.CHAR_1_TARGETNL,PlayerPrefs.GetFloat("target1").ToString());
			PlayerPrefs.SetString (Link.CHAR_1_LEVEL, jsonString ["code"] ["HantuLevel1"]);
			PlayerPrefs.SetString (Link.CHAR_2_MONSTEREXP,jsonString ["code"] ["monstercurrentexp2"]);
			PlayerPrefs.SetString(Link.CHAR_2_TARGETNL,PlayerPrefs.GetFloat("target2").ToString());
			PlayerPrefs.SetString (Link.CHAR_2_LEVEL,jsonString ["code"] ["HantuLevel2"]);
			PlayerPrefs.SetString (Link.CHAR_3_MONSTEREXP,jsonString ["code"] ["monstercurrentexp3"]);
			PlayerPrefs.SetString(Link.CHAR_3_TARGETNL,PlayerPrefs.GetFloat("target3").ToString());
			PlayerPrefs.SetString (Link.CHAR_3_LEVEL,jsonString ["code"] ["HantuLevel3"]);
			Debug.Log (www.text);
		//	monsterleveling2();


		} else {
			Debug.Log (www.text);
			Debug.Log (www.error);
			Debug.Log ("Failed kirim data");
			yield return new WaitForSeconds (5);


		}
	}
		private IEnumerator sendEXP2(string hantuplayerid, int Exp)
		{

			Debug.Log ("TES");
			string url = Link.url + "send_xp_enchance";
			WWWForm form = new WWWForm ();
			form.AddField ("MY_ID", PlayerID);
			form.AddField ("PlayerHantuID", hantuplayerid);
			form.AddField ("EXPERIENCE", Exp);
			//form.AddField ("CURRENTEXPB", Latestexpbank);

			WWW www = new WWW(url,form);
			yield return www;

			if (www.error == null) {

				var jsonString = JSON.Parse (www.text);
				PlayerPrefs.SetFloat("target2", float.Parse(jsonString ["code"] ["Targetnextlevel"]));
		
				monstercurrentexp2 += Exp;
			PlayerPrefs.SetString (Link.CHAR_2_MONSTEREXP,monstercurrentexp2.ToString());
			PlayerPrefs.SetString(Link.CHAR_2_TARGETNL,PlayerPrefs.GetFloat("target2").ToString());
			PlayerPrefs.SetString (Link.CHAR_2_LEVEL,MonsterLevel2.ToString());
			monsterleveling3();

			} else {
				Debug.Log ("Failed kirim data");
				yield return new WaitForSeconds (5);


			}
	}
			private IEnumerator sendEXP3(string hantuplayerid, int Exp)
			{

				Debug.Log ("TES");
				string url = Link.url + "send_xp_enchance";
				WWWForm form = new WWWForm ();
				form.AddField ("MY_ID", PlayerID);
				form.AddField ("PlayerHantuID", hantuplayerid);
				form.AddField ("EXPERIENCE", Exp);
				//form.AddField ("CURRENTEXPB", Latestexpbank);

				WWW www = new WWW(url,form);
				yield return www;

				if (www.error == null) {

					var jsonString = JSON.Parse (www.text);
					PlayerPrefs.SetFloat("target3", float.Parse(jsonString ["code"] ["Targetnextlevel"]));

					monstercurrentexp3 += Exp;
			PlayerPrefs.SetString (Link.CHAR_3_MONSTEREXP,monstercurrentexp3.ToString());
			PlayerPrefs.SetString(Link.CHAR_3_TARGETNL,PlayerPrefs.GetFloat("target3").ToString());
			PlayerPrefs.SetString (Link.CHAR_3_LEVEL,MonsterLevel3.ToString());
				} else {
					Debug.Log ("Failed kirim data");
					yield return new WaitForSeconds (5);
				

				}
	}
	//tambah exp habis game single player
	IEnumerator DistribusiEXPMonsterItem(string hantuplayerid1,string hantuplayerid2,string hantuplayerid3,string hantuplayerid1item1,string hantuplayerid1item2,string hantuplayerid1item3,string hantuplayerid1item4,string hantuplayerid2item1,string hantuplayerid2item2,string hantuplayerid2item3,string hantuplayerid2item4,string hantuplayerid3item1,string hantuplayerid3item2,string hantuplayerid3item3,string hantuplayerid3item4, int Exp){

		Debug.Log ("TES");
		string url = Link.url + "send_xp_enchance";
		WWWForm form = new WWWForm ();
				form.AddField ("MY_ID", PlayerID);
		form.AddField ("PlayerHantuID1", hantuplayerid1);
		form.AddField ("PlayerHantuID2", hantuplayerid2);
		form.AddField ("PlayerHantuID3", hantuplayerid3);
		form.AddField ("PlayerHantuID1item1", hantuplayerid1item1);
		form.AddField ("PlayerHantuID2item1", hantuplayerid2item1);
		form.AddField ("PlayerHantuID3item1", hantuplayerid3item1);
		form.AddField ("PlayerHantuID1item2", hantuplayerid1item2);
		form.AddField ("PlayerHantuID2item2", hantuplayerid2item2);
		form.AddField ("PlayerHantuID3item2", hantuplayerid3item2);
		form.AddField ("PlayerHantuID1item3", hantuplayerid1item3);
		form.AddField ("PlayerHantuID2item3", hantuplayerid2item3);
		form.AddField ("PlayerHantuID3item3", hantuplayerid3item3);
		form.AddField ("PlayerHantuID1item4", hantuplayerid1item4);
		form.AddField ("PlayerHantuID2item4", hantuplayerid2item4);
		form.AddField ("PlayerHantuID3item4", hantuplayerid3item4);
		form.AddField ("EXPERIENCE", Exp);
		//form.AddField ("CURRENTEXPB", Latestexpbank);

		WWW www = new WWW(url,form);
		yield return www;

		if (www.error == null) {

			var jsonString = JSON.Parse (www.text);
			PlayerPrefs.SetFloat("target", float.Parse(jsonString ["code"] ["Targetnextlevel"]));
			//monstercurrentexp += Exp;
			monstercurrentexp1 += Exp;
			monstercurrentexp2 += Exp;
			monstercurrentexp3 += Exp;


		} else {
			Debug.Log ("Failed kirim data");
			//yield return new WaitForSeconds (5);
			//StartCoroutine (updateData());

		}
		
	}
	IEnumerator Apimusuh(string musuh)
	{
		if (ulang) {
			if (musuh == "Hantu1A") {
				sh1a.SetActive (true);
			}
			if (musuh == "Hantu2A") {
				sh2a.SetActive (true);
			}
			if (musuh == "Hantu3A") {
				sh3a.SetActive (true);
			}
		} 
		else {

			yield return new WaitForSeconds (.5f);
			if (musuh == "Hantu1A") {
				sh1a.SetActive (true);
			}
			if (musuh == "Hantu2A") {
				sh2a.SetActive (true);
			} 
			if (musuh== "Hantu3A") {
				sh3a.SetActive (true);
			}
		}
	
	}
	IEnumerator randomenemiesmovement(){
		Debug.Log ("sekali");
		int j = Random.Range (0, 3);
		int k = Random.Range (0, 3);
		int l = Random.Range (0, 3);
		if (PlayerPrefs.GetString ("berburu") != "ya") {
			if(PlayerPrefs.GetString("PLAY_TUTORIAL")=="TRUE")
			{
			urutan1 [0] = GameObject.Find ("Hantu1A");
			StartCoroutine (Apimusuh (urutan1[0].name));
			PlayerPrefs.SetString ("Urutan1m", urutan1 [0].name);
			PlayerPrefs.SetString ("hantumusuh", urutan1 [0].name);
			}
			else
			{
			if (PlayerPrefs.GetString ("musuh1") != "mati" && PlayerPrefs.GetString ("musuh2") != "mati" && PlayerPrefs.GetString ("musuh3") != "mati") {
			
				int urut = Random.Range (0, 3);
				//urutan
				if (urut == 0) {
					urutan1 [0] = GameObject.Find ("Hantu1A");

				}
				if (urut == 1) {
					urutan1 [0] = GameObject.Find ("Hantu2A");

				}
				if (urut == 2) {
					urutan1 [0] = GameObject.Find ("Hantu3A");

				} else {
					urut = Random.Range (0, 2);
					//urutan
					if (urut == 0) {
						urutan1 [0] = GameObject.Find ("Hantu1A");
					
					}
					if (urut == 1) {
						urutan1 [0] = GameObject.Find ("Hantu2A");

					}
					if (urut == 2) {
						urutan1 [0] = GameObject.Find ("Hantu3A");

					} 
				}

			}
			if (PlayerPrefs.GetString ("musuh1") == "mati" && PlayerPrefs.GetString ("musuh2") != "mati") {
				int urut = Random.Range (0, 1);
				if (urut == 0) {
					urutan1 [0] = GameObject.Find ("Hantu2A");

				}
				if (urut == 1) {
					urutan1 [0] = GameObject.Find ("Hantu3A");

				}
				if (PlayerPrefs.GetString ("musuh3") == "mati") {
					urutan1 [0] = GameObject.Find ("Hantu2A");

				}


			}
			if (PlayerPrefs.GetString ("musuh1") == "mati" && PlayerPrefs.GetString ("musuh3") != "mati") {
				int urut = Random.Range (0, 1);
				if (urut == 0) {
					urutan1 [0] = GameObject.Find ("Hantu2A");

				}
				if (urut == 1) {
					urutan1 [0] = GameObject.Find ("Hantu3A");

				}
				if (PlayerPrefs.GetString ("musuh2") == "mati") {
					urutan1 [0] = GameObject.Find ("Hantu3A");

				}


			}
			if (PlayerPrefs.GetString ("musuh2") == "mati" && PlayerPrefs.GetString ("musuh3") != "mati") {
				int urut = Random.Range (0, 1);
				if (urut == 0) {
					urutan1 [0] = GameObject.Find ("Hantu1A");

				}
				if (urut == 1) {
					urutan1 [0] = GameObject.Find ("Hantu3A");

				}
				if (PlayerPrefs.GetString ("musuh1") == "mati") {
					urutan1 [0] = GameObject.Find ("Hantu3A");

				}


			}
			if (PlayerPrefs.GetString ("musuh2") == "mati" && PlayerPrefs.GetString ("musuh1") != "mati") {
				int urut = Random.Range (0, 1);
				if (urut == 0) {
					urutan1 [0] = GameObject.Find ("Hantu1A");

				}
				if (urut == 1) {
					urutan1 [0] = GameObject.Find ("Hantu3A");

				}
				if (PlayerPrefs.GetString ("musuh3") == "mati") {
					urutan1 [0] = GameObject.Find ("Hantu1A");

				}


			}
			if (PlayerPrefs.GetString ("musuh3") == "mati" && PlayerPrefs.GetString ("musuh1") != "mati") {
				int urut = Random.Range (0, 1);
				if (urut == 0) {
					urutan1 [0] = GameObject.Find ("Hantu1A");
				
				}
				if (urut == 1) {
					urutan1 [0] = GameObject.Find ("Hantu2A");

				}
				if (PlayerPrefs.GetString ("musuh2") == "mati") {
					urutan1 [0] = GameObject.Find ("Hantu1A");

				}


			}
			if (PlayerPrefs.GetString ("musuh3") == "mati" && PlayerPrefs.GetString ("musuh2") != "mati") {
				int urut = Random.Range (0, 1);
				if (urut == 0) {
					urutan1 [0] = GameObject.Find ("Hantu1A");
				
				}
				if (urut == 1) {
					urutan1 [0] = GameObject.Find ("Hantu2A");

				}
				if (PlayerPrefs.GetString ("musuh1") == "mati") {
					urutan1 [0] = GameObject.Find ("Hantu2A");
				
				}


			}
			StartCoroutine (Apimusuh (urutan1[0].name));
			PlayerPrefs.SetString ("Urutan1m", urutan1 [0].name);
			PlayerPrefs.SetString ("hantumusuh", urutan1 [0].name);
		} 
		}
		else {
			urutan1 [0] = GameObject.Find ("Hantu1A");
			StartCoroutine (Apimusuh (urutan1[0].name));
			PlayerPrefs.SetString ("Urutan1m", urutan1 [0].name);
			PlayerPrefs.SetString ("hantumusuh", urutan1 [0].name);
		}


		//urutan
		if (PlayerPrefs.GetString ("PLAY_TUTORIAL") != "TRUE") {
			if (j == 0) {
				suit1 [0] = "Charge";
			}
			if (j == 1) {
				suit1 [0] = "Block";
			}
			if (j == 2) {
				suit1 [0] = "Focus";
			}
			//yield return new WaitForSeconds(1);
			if (k == 0) {
				suit2 [0] = "Charge";
			}
			if (k == 1) {
				suit2 [0] = "Block";
			}
			if (k == 2) {
				suit2 [0] = "Focus";
			}
			//

			if (l == 0) {
				suit3 [0] = "Charge";
			}
			if (l == 1) {
				suit3 [0] = "Block";
			}
			if (l == 2) {
				suit3 [0] = "Focus";
			}
			StartCoroutine (Apimusuh (urutan1[0].name));
			Debug.Log (urutan1[0].name);
			PlayerPrefs.SetString ("Urutan1m", urutan1 [0].name);
	}
	

		yield return null;

		PlayerPrefs.SetString("hantumusuh",urutan1[0].name);
	}
	IEnumerator randomPilihanInput(){
		//int j = Random.Range (0, 2);
		if (PlayerPrefs.GetInt ("pos") == 1) {
			if (PlayerPrefs.GetString ("Urutan1") == "Hantu1A") {
				pilihanInputSuit [0].GetComponent<RandomClick> ().RandomPilih ();


				//		if (hantuchoose2.activeSelf) {
				//			hantuchoose2.GetComponent<RandomClick> ().RandomPilih ();
				//			}
				//			yield return new WaitForSeconds(1);
				//
				//		if (hantuchoose3.activeSelf) {
				//			hantuchoose3.GetComponent<RandomClick> ().RandomPilih ();
				//			}
				//			if (PlayerPrefs.GetString ("PLAY_TUTORIAL") == "TRUE") {
				//				firstTimerTanding ();
				//				//StartCoroutine (urutanPlay());
				//
				//			} 
			}

			if (PlayerPrefs.GetString ("Urutan1") == "Hantu2A") {
				pilihanInputSuit [1].GetComponent<RandomClick> ().RandomPilih ();
			}

			if (PlayerPrefs.GetString ("Urutan1") == "Hantu3A") {


				pilihanInputSuit [2].GetComponent<RandomClick> ().RandomPilih ();
			}
		} else {
			if (PlayerPrefs.GetString ("Urutan1") == "Hantu1B") {
				pilihanInputSuit [0].GetComponent<RandomClick> ().RandomPilih ();
			
		
//		if (hantuchoose2.activeSelf) {
//			hantuchoose2.GetComponent<RandomClick> ().RandomPilih ();
//			}
//			yield return new WaitForSeconds(1);
//
//		if (hantuchoose3.activeSelf) {
//			hantuchoose3.GetComponent<RandomClick> ().RandomPilih ();
//			}
//			if (PlayerPrefs.GetString ("PLAY_TUTORIAL") == "TRUE") {
//				firstTimerTanding ();
//				//StartCoroutine (urutanPlay());
//
//			} 
			}

			if (PlayerPrefs.GetString ("Urutan1") == "Hantu2B") {
				pilihanInputSuit [1].GetComponent<RandomClick> ().RandomPilih ();
			}

			if (PlayerPrefs.GetString ("Urutan1") == "Hantu3B") {


				pilihanInputSuit [2].GetComponent<RandomClick> ().RandomPilih ();
			}
		}
//		else if (j == 3) {
//
//
//			if (pilihanInputSuit [2].activeSelf) {
//				pilihanInputSuit [2].GetComponent<RandomClick> ().RandomPilih ();
//			}
//			yield return new WaitForSeconds(1);
//			if (pilihanInputSuit [1].activeSelf) {
//				pilihanInputSuit [1].GetComponent<RandomClick> ().RandomPilih ();
//			}
//
//			yield return new WaitForSeconds(1);
//			if (pilihanInputSuit [0].activeSelf) {
//				pilihanInputSuit [0].GetComponent<RandomClick> ().RandomPilih ();
//			}if (PlayerPrefs.GetString ("PLAY_TUTORIAL") == "TRUE") {
//				firstTimerTanding ();
//				//StartCoroutine (urutanPlay());
//
//			} 
//
//
//		}
		yield return null;
	}


	private IEnumerator sendFormation()
	{
		ImDoneForSendBool = true;
		StartCoroutine (ImDoneForSend ());
		Debug.Log ("send prrogress");

		string url = Link.url + "send_formation";
		WWWForm form = new WWWForm ();
				form.AddField (Link.ID, PlayerID);
		form.AddField ("pos", PlayerPrefs.GetInt("pos").ToString());
		if (PlayerPrefs.GetInt ("pos") == 1) {
			form.AddField ("urutan_1", PlayerPrefs.GetString ("Urutan1m"));
		} else {
			form.AddField ("urutan_1", PlayerPrefs.GetString ("Urutan1"));
		}
		form.AddField ("suit_1", PlayerPrefs.GetString("Suit1"));

		//form.AddField ("urutan_2", PlayerPrefs.GetString("Urutan2"));
		//form.AddField ("suit_2", PlayerPrefs.GetString("Suit2"));

		//form.AddField ("urutan_3", PlayerPrefs.GetString("Urutan3"));
		//form.AddField ("suit_3", PlayerPrefs.GetString("Suit3"));

		form.AddField ("room_name", PlayerPrefs.GetString ("RoomName"));

		WWW www = new WWW(url,form);
		yield return www;
		if (www.error == null) {
			Debug.Log ("send success");
			var jsonString = JSON.Parse (www.text);
			int a = 0;

			for (int i = 0; i < int.Parse (jsonString ["code"]); i++) {
				a++;
			}

			if (a == 1) {
				ImDoneForSendInteger = 0;
				ImDoneForSendBool = false;

				ImDoneForWaitingBool = true;
				StartCoroutine (ImDoneForWaiting ());
				StartCoroutine (onCoroutine());
			} else {
				Debug.Log ("fail");
			}

		} else {
			Debug.Log ("fail");
		}
	}

	public bool ImDoneForWaitingBool = true;
	public int ImDoneForWaitingInteger = 0;
	public GameObject done;

    public void waitplayer() {
        ImDoneForWaitingInteger = 0;
        StartCoroutine(ImDoneForWaiting());
    }
	IEnumerator ImDoneForWaiting () {
		while(ImDoneForWaitingBool) 
		{ 
			Debug.Log ("TikTok : " + ImDoneForWaitingInteger.ToString ());
			ImDoneForWaitingInteger++;
			if (ImDoneForWaitingInteger>30) {
				done.SetActive (true);
			}
			yield return new WaitForSeconds(1f);
		}
	}

	public void OnClickDone () {
		if (PlayerPrefs.GetString ("PLAY_TUTORIAL") == "TRUE") {
			PlayerPrefs.SetString ("PLAY_TUTORIAL","FALSE");
			PlayerPrefs.SetString ("lewat","ya");
		}
			
			
		
		SceneManagerHelper.LoadScene ("Home");
	}


	public bool ImDoneForSendBool = true;
	public int ImDoneForSendInteger = 0;
	public GameObject Send;

	IEnumerator ImDoneForSend () {
		while(ImDoneForSendBool) 
		{ 
			Debug.Log ("TikTok : " + ImDoneForSendInteger.ToString ());
			ImDoneForSendInteger++;
			if (ImDoneForSendInteger>30) {
				Send.SetActive (true);
			}
			yield return new WaitForSeconds(1f);
		}
	}

	public void OnClickSend () {
		SceneManagerHelper.LoadScene ("Home");
	}



	IEnumerator onCoroutine(){
		while(data_belum_ada) 
		{ 
			StartCoroutine (cekFormation());
			yield return new WaitForSeconds(1f);
		}
	}
	private IEnumerator cekFormation()
	{
		if (data_belum_ada) {
			string url = Link.url + "cek_formation";
			WWWForm form = new WWWForm ();
					form.AddField (Link.ID, PlayerID);
			form.AddField ("room_name", PlayerPrefs.GetString ("RoomName"));


			WWW www = new WWW(url,form);
			yield return www;
			if (www.error == null) {

				var jsonString = JSON.Parse (www.text);
				int a = 0;
//				int c = 0;
//
				for (int i = 0; i < int.Parse (jsonString ["code"]); i++) {
					a++;
				}



				if (a == 2 && data_belum_ada) {
					data_belum_ada = false;

					ImDoneForWaitingBool = false;
					ImDoneForWaitingInteger = 0;


					Debug.Log ("SUDAH DI FALSE KAN !!!!");
					Debug.Log (data_belum_ada);



					urutan1 [0] = GameObject.Find (jsonString ["data"] [0] ["urutan_1"]);
					urutan1 [1] = GameObject.Find (jsonString ["data"] [1] ["urutan_1"]);


					healthBar1 [0] = urutan1 [0].transform.Find ("Canvas").transform.Find ("Image").gameObject;
					healthBar1 [1] = urutan1 [1].transform.Find ("Canvas").transform.Find ("Image").gameObject;


					suit1 [0] = jsonString ["data"] [0] ["suit_1"];
					suit1 [1] = jsonString ["data"] [1] ["suit_1"];


					//urutan2 [0] = GameObject.Find (jsonString ["data"] [0] ["urutan_2"]);
					//urutan2 [1] = GameObject.Find (jsonString ["data"] [1] ["urutan_2"]);

				//	healthBar2 [0] = urutan2 [0].transform.FindChild ("Canvas").transform.FindChild ("Image").gameObject;
				//	healthBar2 [1] = urutan2 [1].transform.FindChild ("Canvas").transform.FindChild ("Image").gameObject;



					//suit2 [0] = jsonString ["data"] [0] ["suit_2"];
					//suit2 [1] = jsonString ["data"] [1] ["suit_2"];

					//urutan3 [0] = GameObject.Find (jsonString ["data"] [0] ["urutan_3"]);
					//urutan3 [1] = GameObject.Find (jsonString ["data"] [1] ["urutan_3"]);


					//healthBar3 [0] = urutan3 [0].transform.FindChild ("Canvas").transform.FindChild ("Image").gameObject;
				//	healthBar3 [1] = urutan3 [1].transform.FindChild ("Canvas").transform.FindChild ("Image").gameObject;


					//suit3 [0] = jsonString ["data"] [0] ["suit_3"];
					//suit3 [1] = jsonString ["data"] [1] ["suit_3"];




					waiting.SetActive (false);
					//information.SetActive (true);
					if (PlayerPrefs.GetInt ("pos") == 1) {
						PlayerPrefs.SetString ("Urutan1", urutan1 [1].name);
						PlayerPrefs.SetString ("hantumusuh", urutan1 [1].name);
						PlayerPrefs.SetString ("Suit1", suit1 [1]);
					} else {
						Debug.Log(PlayerPrefs.GetString ("Urutan1m"));
						PlayerPrefs.SetString ("Urutan1m",urutan1 [0].name);
						PlayerPrefs.SetString ("hantumusuh", urutan1 [0].name);
						PlayerPrefs.SetString ("Suit1", suit1 [0]);
					}

					StartCoroutine (urutanPlay());








				}
				else {
					waiting.SetActive (true);

				}

			} else {
				Debug.Log ("fail");
			}
		}

	}

	public Image[] kertasButton;
	public Image[] batuButton;
	public Image[] guntingButton;

	public Sprite kertasSprite;
	public Sprite batuSprite;
	public Sprite guntingSprite;

public void GetCriticalValue()
{
GetCritical = Random.Range(0,10);
}

	IEnumerator urutanPlay(){
		tanding = true;
		if (PlayerPrefs.GetString ("PLAY_TUTORIAL") == "TRUE") {
			firstTimerTanding ();
		}
		
		cameraB.GetComponent<Animator> ().SetBool ("vanny", false);
		if (critical && attacking>=3 && PlayerPrefs.GetString(Link.JENIS) == "SINGLE") {
			effect1_1.SetActive (true);
			effect2_1.SetActive (true);
			effect1_2.SetActive (true);
			effect2_2.SetActive (true);
			effect1_3.SetActive (true);
			effect2_3.SetActive (true);
			level1 = true;
			cameraB.transform.Find ("PlaneP").gameObject.SetActive (true);
			cameraB.GetComponent<Animator> ().SetBool ("vanny", true);
			cameraB.GetComponent<Camera> ().cullingMask = -139265;
			times = 100;
			PlayerPrefs.SetString ("Critical", "n");
			karaA.GetComponent<Animation>().PlayQueued("seranggame",QueueMode.PlayNow);
			karaBanimation.PlayQueued("seranggame",QueueMode.PlayNow);

			yield return new WaitForSeconds (1f);	
			
		}
		yield return new WaitForSeconds (.1f);
		sebelumwar (GetCritical);
		if(GetCritical<=1)
		{
			yield return new WaitForSeconds (2);
			sebelumwar2 ();
		}
		else
		{
			if (critical && attacking>=3 && PlayerPrefs.GetString(Link.JENIS) == "SINGLE") 
			{
			yield return new WaitForSeconds (2);
			sebelumwar2 ();
			}
		}


	//	yield return new WaitForSeconds (1);
		scrollBar.SetActive (false);

		cameraA.GetComponent<Animator> ().SetBool ("Fighting", true);
	//	yield return new WaitForSeconds(1f);
	//	vs.SetActive (true);

		Aobject.GetComponent<Animator> ().SetBool ("LeftFight", true);
		Bobject.GetComponent<Animator> ().SetBool ("RightFight", true);

		//		Aaobject.GetComponent<Animator> ().SetBool ("LeftFight", true);
		//		Baobject.GetComponent<Animator> ().SetBool ("RightFight", true);


		if (suit1 [0] == "Charge") {
			Aobject.GetComponent<Animator> ().SetBool ("FightCharge", true);
		}
		if (suit1 [0] == "Focus") {
			Aobject.GetComponent<Animator> ().SetBool ("FightFocus", true);
		}
		if (suit1 [0] == "Block") {
			Aobject.GetComponent<Animator> ().SetBool ("FightBlock", true);
		}
		if (suit1 [1] == "Charge") {
			Bobject.GetComponent<Animator> ().SetBool ("FightCharge", true);
		}
		if (suit1 [1] == "Focus") {
			Bobject.GetComponent<Animator> ().SetBool ("FightFocus", true);
		}
		if (suit1 [1] == "Block") {
			Bobject.GetComponent<Animator> ().SetBool ("FightBlock", true);
		}


		StartCoroutine (War(urutan1[0],urutan1[1],suit1[0],suit1[1],1,GetCritical));
		pilihanInputSuit [0].SetActive (false);
		pilihanInputSuit [1].SetActive (false);
		pilihanInputSuit [2].SetActive (false);
        if (PlayerPrefs.GetString(Link.JENIS) == "SINGLE")
        {
            //healthBar1[1].SetActive(false);
            //healthBar2[1].SetActive(false);
            //healthBar3[1].SetActive(false);
        }
        //cameraB.GetComponent<Animator> ().SetBool ("Fighting", false);
//        yield return new WaitForSeconds(5f);
//		cameraB.GetComponent<Animator> ().SetBool ("Fighting", true);
//		cameraA.GetComponent<Animator> ().SetBool ("Fighting", true);
//		Aobject.GetComponent<Animator> ().SetBool ("LeftFight", true);
//		Bobject.GetComponent<Animator> ().SetBool ("RightFight", true);
//		//		Aaobject.GetComponent<Animator> ().SetBool ("LeftFight", true);
//		//		Baobject.GetComponent<Animator> ().SetBool ("RightFight", true);
//
//		if (suit2 [0] == "Charge") {
//			Aobject.GetComponent<Animator> ().SetBool ("FightCharge", true);
//		}
//		if (suit2 [0] == "Focus") {
//			Aobject.GetComponent<Animator> ().SetBool ("FightFocus", true);
//		}
//		if (suit2 [0] == "Block") {
//			Aobject.GetComponent<Animator> ().SetBool ("FightBlock", true);
//		}
//		if (suit2 [1] == "Charge") {
//			Bobject.GetComponent<Animator> ().SetBool ("FightCharge", true);
//		}
//		if (suit2 [1] == "Focus") {
//			Bobject.GetComponent<Animator> ().SetBool ("FightFocus", true);
//		}
//		if (suit2 [1] == "Block") {
//			Bobject.GetComponent<Animator> ().SetBool ("FightBlock", true);
//		}
//
//
//		StartCoroutine (War(urutan2[0],urutan2[1],suit2[0],suit2[1],2));
//
//		yield return new WaitForSeconds(5.3f);
//		cameraB.GetComponent<Animator> ().SetBool ("Fighting", true);
//		cameraA.GetComponent<Animator> ().SetBool ("Fighting", true);
//		Aobject.GetComponent<Animator> ().SetBool ("LeftFight", true);
//		Bobject.GetComponent<Animator> ().SetBool ("RightFight", true);
//
//		//		Aaobject.GetComponent<Animator> ().SetBool ("LeftFight", true);
//		//		Baobject.GetComponent<Animator> ().SetBool ("RightFight", true);
//
//
//		if (suit3 [0] == "Charge") {
//			Aobject.GetComponent<Animator> ().SetBool ("FightCharge", true);
//		}
//		if (suit3 [0] == "Focus") {
//			Aobject.GetComponent<Animator> ().SetBool ("FightFocus", true);
//		}
//		if (suit3 [0] == "Block") {
//			Aobject.GetComponent<Animator> ().SetBool ("FightBlock", true);
//		}
//		if (suit3 [1] == "Charge") {
//			Bobject.GetComponent<Animator> ().SetBool ("FightCharge", true);
//		}
//		if (suit3 [1] == "Focus") {
//			Bobject.GetComponent<Animator> ().SetBool ("FightFocus", true);
//		}
//		if (suit3 [1] == "Block") {
//			Bobject.GetComponent<Animator> ().SetBool ("FightBlock", true);
//		}
//
//
//
//		StartCoroutine (War(urutan3[0],urutan3[1],suit3[0],suit3[1],3));
//
		yield return new WaitForSeconds(1.4f);
		cameraB.GetComponent<Animator> ().SetBool ("Fighting", false);
		cameraA.GetComponent<Animator> ().SetBool ("Fighting", false);
		cameraB.GetComponent<Animator> ().SetBool ("vanny", false);
		//cameraB.GetComponent<Camera> ().cullingMask = -8193;
		cameraB.GetComponent<Animator> ().SetBool ("idling", false);
		cameraB.GetComponent<Animator> ().SetBool ("hitted", false);
		cameraA.GetComponent<Animator> ().SetBool ("idling", false);
		cameraA.GetComponent<Animator> ().SetBool ("hitted", false);
		//urutan1 [1].GetComponent<Animator> ().enabled = false;
		urutan1 [1].GetComponent<Animator> ().Play ("New State");
		urutan1 [0].GetComponent<Animator> ().Play ("New State");
		kertasButton [0].sprite = kertasSprite;
		kertasButton [1].sprite = kertasSprite;
		kertasButton [2].sprite = kertasSprite;
		batuButton [0].sprite = batuSprite;
		batuButton [1].sprite = batuSprite;
		batuButton [2].sprite = batuSprite;
		guntingButton [0].sprite = guntingSprite;
		guntingButton [1].sprite = guntingSprite;
		guntingButton [2].sprite = guntingSprite;

		kertasButton [0].transform.GetComponent<ButtonInput> ().tekan = true;
		kertasButton [1].transform.GetComponent<ButtonInput> ().tekan = true;
		kertasButton [2].transform.GetComponent<ButtonInput> ().tekan = true;
		batuButton [0].transform.GetComponent<ButtonInput> ().tekan = true;
		batuButton [1].transform.GetComponent<ButtonInput> ().tekan = true;
		batuButton [2].transform.GetComponent<ButtonInput> ().tekan = true;
		guntingButton [0].transform.GetComponent<ButtonInput> ().tekan = true;
		guntingButton [1].transform.GetComponent<ButtonInput> ().tekan = true;
		guntingButton [2].transform.GetComponent<ButtonInput> ().tekan = true;
		scrollBar.SetActive (true);
	//	vs.SetActive (false);
		hantugo1.SetActive(true);
		hantugo2.SetActive(true);
		hantugo3.SetActive(true);
		hantugo1.transform.Find("COPY_POSITION").GetComponentInChildren<SkinnedMeshRenderer>().enabled=true;
		hantugo2.transform.Find("COPY_POSITION").GetComponentInChildren<SkinnedMeshRenderer>().enabled=true;
		hantugo3.transform.Find("COPY_POSITION").GetComponentInChildren<SkinnedMeshRenderer>().enabled=true;
		hantugo1.transform.localPosition= new Vector3 (0.3f, 0.011f, 0.444f);
		hantugo2.transform.localPosition= new Vector3 (0f, 0.011f, 0.444f);
		hantugo3.transform.localPosition= new Vector3 (-0.3f, 0.011f, 0.444f);

		hantugom1.transform.Find("COPY_POSITION").GetComponentInChildren<SkinnedMeshRenderer>().enabled=true;
		hantugom2.transform.Find("COPY_POSITION").GetComponentInChildren<SkinnedMeshRenderer>().enabled=true;
		hantugom3.transform.Find("COPY_POSITION").GetComponentInChildren<SkinnedMeshRenderer>().enabled=true;
		hantugo1.transform.Find("Canvas").gameObject.SetActive(true);
		hantugo2.transform.Find("Canvas").gameObject.SetActive(true);
		hantugo3.transform.Find("Canvas").gameObject.SetActive(true);
		hantugom1.transform.Find("Canvas").gameObject.SetActive(true);
		hantugom2.transform.Find("Canvas").gameObject.SetActive(true);
		hantugom3.transform.Find("Canvas").gameObject.SetActive(true);
		hantugom1.SetActive(true);
		hantugom2.SetActive(true);
		hantugom3.SetActive(true);
		hantugom1.transform.localPosition= new Vector3 (-0.3f, 0.011f, -.523f);
		hantugom2.transform.localPosition= new Vector3 (0f, 0.011f,  -.523f);
		hantugom3.transform.localPosition= new Vector3 (0.3f, 0.011f,  -.523f);
		if (level1) {
			effect1_1.SetActive (true);
			effect2_1.SetActive (true);
			effect1_2.SetActive (true);
			effect2_2.SetActive (true);
			effect1_3.SetActive (true);
			effect2_3.SetActive (true);
		}

		if (repeat) {
			ulang = true;
			if (Time.timeScale == .6f) {
				Time.timeScale = 1f;
			}
			attacking++;
			Debug.Log (PlayerPrefs.GetString ("musuh1") + "1");
			Debug.Log (PlayerPrefs.GetString ("musuh2") + "2");
			Debug.Log (PlayerPrefs.GetString ("musuh3") + "3");
			Debug.Log ("Repeat");
			if (PlayerPrefs.GetString (Link.JENIS) == "SINGLE") {
				if (PlayerPrefs.GetString ("PLAY_TUTORIAL") != "TRUE") {
				
					StartCoroutine (randomenemiesmovement ());
				}
			 else {
				//firstTimerTanding ();

				StartCoroutine (randomenemiesmovement ());

				//StartCoroutine (randomenemiesmovement ());
			}
		}
			if (PlayerPrefs.GetString (Link.JENIS) == "SINGLE") {
				karaBbukuskin.enabled = true;
				karaBskin.enabled = true;
				karaBanimation.PlayQueued ("idlegame", QueueMode.PlayNow);

				speedOption.SetActive (true);
				scrollBar.transform.Find ("Scrollbar").GetComponent<Scrollbar> ().size = 1;
				timer = 3f;

				timeUps = false;
				panggil_url = false;
				data_belum_ada = true;
				PlayerPrefs.SetInt ("Jumlah", 0);
				PlayerPrefs.SetString ("Main", "tidak");
				PlayerPrefs.SetString ("Urutan1", "Kosong");
				PlayerPrefs.SetString ("Suit1", "Kosong");
				cameraB.transform.position = new Vector3 (12.9f, 25.5f, 63.7f);
				cameraB.transform.rotation = Quaternion.Euler (23.09f, 191.491f, 1.302f);
				cameraB.transform.Find ("Plane").gameObject.SetActive (false);
//				hantugo1.SetActive(true);
//				hantugo2.SetActive(true);
//				hantugo3.SetActive(true);
				hantuchoose1.SetActive (false);
				hantuchoose2.SetActive (false);
				hantuchoose3.SetActive (false);
				hantugo1.transform.localPosition = new Vector3 (0.3f, 0.011f, 0.444f);
				hantugo2.transform.localPosition = new Vector3 (0f, 0.011f, 0.444f);
				hantugo3.transform.localPosition = new Vector3 (-0.3f, 0.011f, 0.444f);
				if (PlayerPrefs.GetString ("kenahit") == "w") {
					karaBanimation.PlayQueued ("menanggame", QueueMode.PlayNow);
					karaBanimation.PlayQueued ("idlegame", QueueMode.CompleteOthers);
				} else {
					karaBanimation.PlayQueued ("kalahgame", QueueMode.PlayNow);
					karaBanimation.PlayQueued ("idlegame", QueueMode.CompleteOthers);
				}
				if (critical && attacking >= 3) {
					
					critical = false;
					attacking = 0;
				}
				tanding = false;
			

				if (PlayerPrefs.GetString ("berburu") != "ya" && !PlayerPrefs.HasKey ("win")) {
					if (PlayerPrefs.GetString("PLAY_TUTORIAL")=="TRUE") {
						if(!PlayerPrefs.HasKey("win")){
					hantugom1.transform.localPosition = new Vector3 (0f, 0.011f, -.523f);
					if (PlayerPrefs.GetString ("musuh1") == "selesai") {
							model11a.PlayQueued ("idle", QueueMode.PlayNow);

					}
					if (PlayerPrefs.GetString ("musuh1") == "mati") {
							model11a.PlayQueued ("kalah", QueueMode.PlayNow);
							hantugom1.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);

					}

					if (PlayerPrefs.GetString ("1player") == "selesai") {
							model21a.PlayQueued ("idle", QueueMode.PlayNow);
						pilihanInputSuit [3].SetActive (true);
                            h1cubeb.SetActive(true);
                        } 
					if (PlayerPrefs.GetString ("1player") == "mati") {
							model21a.PlayQueued ("kalah", QueueMode.PlayNow);
							hantugo1.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
							hantugo1.transform.Find ("COPY_POSITION").GetComponent<Animator> ().Play ("small3");
					}
					if (PlayerPrefs.GetString ("2player") == "selesai") {
							model22a.PlayQueued ("idle", QueueMode.PlayNow);
						pilihanInputSuit [4].SetActive (true);
                            h2cubeb.SetActive(true);
                        }
					if (PlayerPrefs.GetString ("2player") == "mati") {
							model22a.PlayQueued ("kalah", QueueMode.PlayNow);
							hantugo2.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
							hantugo2.transform.Find ("COPY_POSITION").GetComponent<Animator> ().Play ("small4");
					}
					if (PlayerPrefs.GetString ("3player") == "selesai") {
							model23a.PlayQueued ("idle", QueueMode.PlayNow);
						pilihanInputSuit [5].SetActive (true);
                            h3cubeb.SetActive(true);
                        }
					if (PlayerPrefs.GetString ("3player") == "mati") {
							model23a.PlayQueued ("kalah", QueueMode.PlayNow);
							hantugo3.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
							hantugo3.transform.Find ("COPY_POSITION").GetComponent<Animator> ().Play ("small5");
					}

				 
				}
			}
			else{
					if (PlayerPrefs.GetString ("musuh1") == "selesai") {
						model11a.PlayQueued ("idle", QueueMode.PlayNow);
					}
					if (PlayerPrefs.GetString ("musuh2") == "selesai") {
						model12a.PlayQueued ("idle", QueueMode.PlayNow);
					}
					if (PlayerPrefs.GetString ("musuh3") == "selesai") {
						model13a.PlayQueued ("idle", QueueMode.PlayNow);
					}
					if (PlayerPrefs.GetString ("musuh1") == "mati") {
						model11a.PlayQueued ("kalah", QueueMode.PlayNow);
						hantugom1.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
						hantugom1.transform.Find ("COPY_POSITION").GetComponent<Animator> ().Play ("small");
					}
					if (PlayerPrefs.GetString ("musuh2") == "mati") {
						model12a.PlayQueued ("kalah", QueueMode.PlayNow);
						hantugom2.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
						hantugom2.transform.Find ("COPY_POSITION").GetComponent<Animator> ().Play ("small1");
					}
					if (PlayerPrefs.GetString ("musuh3") == "mati") {
						model13a.PlayQueued ("kalah", QueueMode.PlayNow);
						hantugom3.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
						hantugom3.transform.Find ("COPY_POSITION").GetComponent<Animator> ().Play ("small2");
					}
					if (PlayerPrefs.GetString ("1player") == "selesai") {
						model21a.PlayQueued ("idle", QueueMode.PlayNow);
						pilihanInputSuit [3].SetActive (true);
                        h1cubeb.SetActive(true);
					} 
					if (PlayerPrefs.GetString ("1player") == "mati") {
						model21a.PlayQueued ("kalah", QueueMode.PlayNow);
						hantugo1.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
						hantugo1.transform.Find ("COPY_POSITION").GetComponent<Animator> ().Play ("small3");
					}
					if (PlayerPrefs.GetString ("2player") == "selesai") {
						model22a.PlayQueued ("idle", QueueMode.PlayNow);
						pilihanInputSuit [4].SetActive (true);
                        h2cubeb.SetActive(true);
                    }
					if (PlayerPrefs.GetString ("2player") == "mati") {
						model22a.PlayQueued ("kalah", QueueMode.PlayNow);
						hantugo2.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
						hantugo2.transform.Find ("COPY_POSITION").GetComponent<Animator> ().Play ("small4");
					}
					if (PlayerPrefs.GetString ("3player") == "selesai") {
						model23a.PlayQueued ("idle", QueueMode.PlayNow);
						pilihanInputSuit [5].SetActive (true);
                        h3cubeb.SetActive(true);
                    }
					if (PlayerPrefs.GetString ("3player") == "mati") {
						model23a.PlayQueued ("kalah", QueueMode.PlayNow);
						hantugo3.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
						hantugo3.transform.Find ("COPY_POSITION").GetComponent<Animator> ().Play ("small5");
					}

				} 
				}
				else {
						if(!PlayerPrefs.HasKey("win")){
					hantugom1.transform.localPosition = new Vector3 (0f, 0.011f, -.523f);
					if (PlayerPrefs.GetString ("musuh1") == "selesai") {
							model11a.PlayQueued ("idle", QueueMode.PlayNow);

					}
					if (PlayerPrefs.GetString ("musuh1") == "mati") {
							model11a.PlayQueued ("kalah", QueueMode.PlayNow);
							hantugom1.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);

					}

					if (PlayerPrefs.GetString ("1player") == "selesai") {
							model21a.PlayQueued ("idle", QueueMode.PlayNow);
						pilihanInputSuit [3].SetActive (true);
                            h1cubeb.SetActive(true);
                        } 
					if (PlayerPrefs.GetString ("1player") == "mati") {
							model21a.PlayQueued ("kalah", QueueMode.PlayNow);
							hantugo1.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
							hantugo1.transform.Find ("COPY_POSITION").GetComponent<Animator> ().Play ("small3");
					}
					if (PlayerPrefs.GetString ("2player") == "selesai") {
							model22a.PlayQueued ("idle", QueueMode.PlayNow);
						pilihanInputSuit [4].SetActive (true);
                            h2cubeb.SetActive(true);
                        }
					if (PlayerPrefs.GetString ("2player") == "mati") {
							model22a.PlayQueued ("kalah", QueueMode.PlayNow);
							hantugo2.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
							hantugo2.transform.Find ("COPY_POSITION").GetComponent<Animator> ().Play ("small4");
					}
					if (PlayerPrefs.GetString ("3player") == "selesai") {
							model23a.PlayQueued ("idle", QueueMode.PlayNow);
						pilihanInputSuit [5].SetActive (true);
                            h3cubeb.SetActive(true);
                        }
					if (PlayerPrefs.GetString ("3player") == "mati") {
							model23a.PlayQueued ("kalah", QueueMode.PlayNow);
							hantugo3.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
							hantugo3.transform.Find ("COPY_POSITION").GetComponent<Animator> ().Play ("small5");
					}

				 
				}
			}
				getReadyStatus = false;
				//	PlayerPrefs.SetString ("id_device","2");
				//			PlayerPrefs.SetString ("pos","2");
				PlayerPrefs.SetString ("RoomName", "SINGLE");


//				plihan1.SetActive (true);
//				plihan2.SetActive (true);
//				plihan3.SetActive (true);
                if (PlayerPrefs.GetString(Link.JENIS) == "SINGLE")
                {
					if (auto) {
						Debug.Log ("ulang");
						automatic ();

					}
//                    healthBar1[1].SetActive(true);
//                    healthBar2[1].SetActive(true);
//                    healthBar3[1].SetActive(true);
                }
            } 
			else {
				if (PlayerPrefs.GetInt ("pos") == 1) 
				{
					if (PlayerPrefs.GetString ("musuh1") == "selesai") {
						pilihanInputSuit[3].SetActive (true);
                        h1cubea.SetActive(true);
                    }
					if (PlayerPrefs.GetString ("musuh2") == "selesai") {
						pilihanInputSuit[4].SetActive (true);
                        h2cubea.SetActive(true);
                    }
					if (PlayerPrefs.GetString ("musuh3") == "selesai") {
						pilihanInputSuit[5].SetActive (true);
                        h3cubea.SetActive(true);
                    }
					if (PlayerPrefs.GetString ("musuh1") == "mati") 
					{
						pilihanInputSuit[3].SetActive (false);
                        h1cubea.SetActive(false);
                    }
					if (PlayerPrefs.GetString ("musuh2") == "mati") 
					{
						pilihanInputSuit[4].SetActive (false);
                        h2cubea.SetActive(false);
                    }
					if (PlayerPrefs.GetString ("musuh3") == "mati") 
					{
						pilihanInputSuit[5].SetActive (false);
                        h3cubea.SetActive(false);
                    }
				} 
				else 
				{
					if (PlayerPrefs.GetString ("1player") == "selesai") {
						pilihanInputSuit[3].SetActive (true);
                        h1cubeb.SetActive(true);
                    }
					if (PlayerPrefs.GetString ("2player") == "selesai") {
						pilihanInputSuit[4].SetActive (true);
                        h2cubeb.SetActive(true);
                    }
					if (PlayerPrefs.GetString ("3player") == "selesai") {
						pilihanInputSuit[5].SetActive (true);
                        h3cubeb.SetActive(true);
                    }
					if (PlayerPrefs.GetString ("1player") == "mati") {
						pilihanInputSuit[3].SetActive (false);
                        h1cubeb.SetActive(false);
                    }
					if (PlayerPrefs.GetString ("2player") == "mati") {
						pilihanInputSuit[4].SetActive (false);
                        h2cubeb.SetActive(false);
                    }
					if (PlayerPrefs.GetString ("3player") == "mati") {
						pilihanInputSuit[5].SetActive (false);
                        h3cubeb.SetActive(false);
                    }
				}
				if (PlayerPrefs.GetString ("berburu") != "ya" && !PlayerPrefs.HasKey ("win")) {

					if(PlayerPrefs.GetString("PLAY_TUTORIAL")=="TRUE") {
					if(!PlayerPrefs.HasKey("win")){
						hantugom1.transform.localPosition = new Vector3 (0f, 0.011f, -.523f);
						if (PlayerPrefs.GetString ("musuh1") == "selesai") {
							model11a.PlayQueued ("idle", QueueMode.PlayNow);

						}
						if (PlayerPrefs.GetString ("musuh1") == "mati") {
							model11a.PlayQueued ("kalah", QueueMode.PlayNow);
							hantugom1.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);

						}

						if (PlayerPrefs.GetString ("1player") == "selesai") {
							model21a.PlayQueued ("idle", QueueMode.PlayNow);
						//	pilihanInputSuit [3].SetActive (true);
						} 
						if (PlayerPrefs.GetString ("1player") == "mati") {
							model21a.PlayQueued ("kalah", QueueMode.PlayNow);
							hantugo1.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
							hantugo1.transform.Find ("COPY_POSITION").GetComponent<Animator> ().Play ("small3");
						}
						if (PlayerPrefs.GetString ("2player") == "selesai") {
							model22a.PlayQueued ("idle", QueueMode.PlayNow);
						//	pilihanInputSuit [4].SetActive (true);
						}
						if (PlayerPrefs.GetString ("2player") == "mati") {
							model22a.PlayQueued ("kalah", QueueMode.PlayNow);
							hantugo2.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
							hantugo2.transform.Find ("COPY_POSITION").GetComponent<Animator> ().Play ("small4");
						}
						if (PlayerPrefs.GetString ("3player") == "selesai") {
							model23a.PlayQueued ("idle", QueueMode.PlayNow);
						//	pilihanInputSuit [5].SetActive (true);
						}
						if (PlayerPrefs.GetString ("3player") == "mati") {
							model23a.PlayQueued ("kalah", QueueMode.PlayNow);
							hantugo3.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
							hantugo3.transform.Find ("COPY_POSITION").GetComponent<Animator> ().Play ("small5");
						}


					}
				}
				else {
					if (PlayerPrefs.GetString ("musuh1") == "selesai") {
						model11a.PlayQueued ("idle", QueueMode.PlayNow);
					}
					if (PlayerPrefs.GetString ("musuh2") == "selesai") {
						model12a.PlayQueued ("idle", QueueMode.PlayNow);
					}
					if (PlayerPrefs.GetString ("musuh3") == "selesai") {
						model13a.PlayQueued ("idle", QueueMode.PlayNow);
					}
					if (PlayerPrefs.GetString ("musuh1") == "mati") {
						model11a.PlayQueued ("kalah", QueueMode.PlayNow);
						hantugom1.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
						hantugom1.transform.Find ("COPY_POSITION").GetComponent<Animator> ().Play ("small");
					}
					if (PlayerPrefs.GetString ("musuh2") == "mati") {
						model12a.PlayQueued ("kalah", QueueMode.PlayNow);
						hantugom2.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
						hantugom2.transform.Find ("COPY_POSITION").GetComponent<Animator> ().Play ("small1");
					}
					if (PlayerPrefs.GetString ("musuh3") == "mati") {
						model13a.PlayQueued ("kalah", QueueMode.PlayNow);
						hantugom3.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
						hantugom3.transform.Find ("COPY_POSITION").GetComponent<Animator> ().Play ("small2");
					}
					if (PlayerPrefs.GetString ("1player") == "selesai") {
						model21a.PlayQueued ("idle", QueueMode.PlayNow);
					//	pilihanInputSuit [3].SetActive (true);
					} 
					if (PlayerPrefs.GetString ("1player") == "mati") {
						model21a.PlayQueued ("kalah", QueueMode.PlayNow);
						hantugo1.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
						hantugo1.transform.Find ("COPY_POSITION").GetComponent<Animator> ().Play ("small3");
					}
					if (PlayerPrefs.GetString ("2player") == "selesai") {
						model22a.PlayQueued ("idle", QueueMode.PlayNow);
					//	pilihanInputSuit [4].SetActive (true);
					}
					if (PlayerPrefs.GetString ("2player") == "mati") {
						model22a.PlayQueued ("kalah", QueueMode.PlayNow);
						hantugo2.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
						hantugo2.transform.Find ("COPY_POSITION").GetComponent<Animator> ().Play ("small4");
					}
					if (PlayerPrefs.GetString ("3player") == "selesai") {
						model23a.PlayQueued ("idle", QueueMode.PlayNow);
					//	pilihanInputSuit [5].SetActive (true);
					}
					if (PlayerPrefs.GetString ("3player") == "mati") {
						model23a.PlayQueued ("kalah", QueueMode.PlayNow);
						hantugo3.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
						hantugo3.transform.Find ("COPY_POSITION").GetComponent<Animator> ().Play ("small5");
					}
				}

				} else {
					if(!PlayerPrefs.HasKey("win")){
						hantugom1.transform.localPosition = new Vector3 (0f, 0.011f, -.523f);
						if (PlayerPrefs.GetString ("musuh1") == "selesai") {
							model11a.PlayQueued ("idle", QueueMode.PlayNow);

						}
						if (PlayerPrefs.GetString ("musuh1") == "mati") {
							model11a.PlayQueued ("kalah", QueueMode.PlayNow);
							hantugom1.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);

						}

						if (PlayerPrefs.GetString ("1player") == "selesai") {
							model21a.PlayQueued ("idle", QueueMode.PlayNow);
						//	pilihanInputSuit [3].SetActive (true);
						} 
						if (PlayerPrefs.GetString ("1player") == "mati") {
							model21a.PlayQueued ("kalah", QueueMode.PlayNow);
							hantugo1.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
							hantugo1.transform.Find ("COPY_POSITION").GetComponent<Animator> ().Play ("small3");
						}
						if (PlayerPrefs.GetString ("2player") == "selesai") {
							model22a.PlayQueued ("idle", QueueMode.PlayNow);
						//	pilihanInputSuit [4].SetActive (true);
						}
						if (PlayerPrefs.GetString ("2player") == "mati") {
							model22a.PlayQueued ("kalah", QueueMode.PlayNow);
							hantugo2.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
							hantugo2.transform.Find ("COPY_POSITION").GetComponent<Animator> ().Play ("small4");
						}
						if (PlayerPrefs.GetString ("3player") == "selesai") {
							model23a.PlayQueued ("idle", QueueMode.PlayNow);
						//	pilihanInputSuit [5].SetActive (true);
						}
						if (PlayerPrefs.GetString ("3player") == "mati") {
							model23a.PlayQueued ("kalah", QueueMode.PlayNow);
							hantugo3.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
							hantugo3.transform.Find ("COPY_POSITION").GetComponent<Animator> ().Play ("small5");
						}


					}
				}
				hantuchoose1.SetActive (false);
				hantuchoose2.SetActive (false);
				hantuchoose3.SetActive (false);
				PlayerPrefs.SetString ("hantumusuh", "kosong");
				StartCoroutine (resetFormation());
			}


			//repeat = false;
		} 
		else {	
			if (PlayerPrefs.GetString ("musuh1") == "mati") {
				model11a.PlayQueued ("kalah", QueueMode.PlayNow);
				hantugom1.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
				hantugom1.transform.Find ("COPY_POSITION").GetComponent<Animator> ().Play ("small");
			}
			if (PlayerPrefs.GetString ("musuh2") == "mati") {
				model12a.PlayQueued ("kalah", QueueMode.PlayNow);
				hantugom2.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
				hantugom2.transform.Find ("COPY_POSITION").GetComponent<Animator> ().Play ("small1");
			}
			if (PlayerPrefs.GetString ("musuh3") == "mati") {
				model13a.PlayQueued ("kalah", QueueMode.PlayNow);
				hantugom3.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
				hantugom3.transform.Find ("COPY_POSITION").GetComponent<Animator> ().Play ("small2");
			}	if (PlayerPrefs.GetString ("2player") == "mati") {
				model22a.PlayQueued ("kalah", QueueMode.PlayNow);
				hantugo2.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
				hantugo2.transform.Find ("COPY_POSITION").GetComponent<Animator> ().Play ("small4");
			}if (PlayerPrefs.GetString ("3player") == "mati") {
				model23a.PlayQueued ("kalah", QueueMode.PlayNow);
				hantugo3.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
				hantugo3.transform.Find ("COPY_POSITION").GetComponent<Animator> ().Play ("small5");
			}	if (PlayerPrefs.GetString ("1player") == "mati") {
				model21a.PlayQueued ("kalah", QueueMode.PlayNow);
				hantugo1.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
				hantugo1.transform.Find ("COPY_POSITION").GetComponent<Animator> ().Play ("small3");
			}
			karaBbukuskin.enabled = true;
			karaBskin.enabled = true;
			karaA.transform.Find ("book001").GetComponent<SkinnedMeshRenderer> ().enabled = true;
			karaA.GetComponent<SkinnedMeshRenderer> ().enabled = true;
			urutan1 [0] = GameObject.Find ("Hantu1A");
			urutan1 [1] = GameObject.Find ("Hantu1B");

			urutan2 [0] = GameObject.Find ("Hantu2A");
			urutan2 [1] = GameObject.Find ("Hantu2B");

			urutan3 [0] = GameObject.Find ("Hantu3A");
			urutan3 [1] = GameObject.Find ("Hantu3B");
			resetDatabaseYo = true;

			if (PlayerPrefs.GetString ("berburu") != "ya") {
				if(PlayerPrefs.GetString("PLAY_TUTORIAL")=="TRUE") 
				{
				hantugo1.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
				hantugo2.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
				hantugo3.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
				hantugom1.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
				hantugom2.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
				hantugom3.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
				if (Bb) {
					
					Debug.Log ("MENANG");
					PlayerPrefs.SetInt ("win", 1);
					urutan1 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
//					urutan2 [0].transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
//					urutan3 [0].transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
					urutan1 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
					urutan2 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
					urutan3 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
					karaBanimation.PlayQueued ("menanggame", QueueMode.PlayNow);
					cameraA.SetActive (false);
					cameraB.SetActive (false);
					//	CameraEnd.SetActive (true);
					plihan1.SetActive (false);
					plihan2.SetActive (false);
					plihan3.SetActive (false);
					//	EndOptionButton.SetActive (true);
					winner.SetActive (true);
					losser.SetActive (false);
					scrollBar.SetActive (false);
					speedOption.SetActive (false);
					Time.timeScale = 1;
					SceneManagerHelper.LoadSoundFX("Win");
				


				} else {
					PlayerPrefs.SetInt ("win", 0);
					urutan1 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
//					urutan2 [0].transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
//					urutan3 [0].transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
					urutan1 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
					urutan2 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
					urutan3 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
					karaBanimation.PlayQueued ("kalahend", QueueMode.PlayNow);
					cameraA.SetActive (false);
					cameraB.SetActive (false);
					plihan1.SetActive (false);
					plihan2.SetActive (false);
					plihan3.SetActive (false);
					//	EndOptionButton.SetActive (true);
					losser2.SetActive (true);
					winner3.SetActive (false);
					scrollBar.SetActive (false);
					speedOption.SetActive (false);
					Time.timeScale = 1;
					SceneManagerHelper.LoadSoundFX("Lose");
					

				
				}


				} 
				else
				{			
				hantugo1.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
				hantugo2.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
				hantugo3.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
				hantugom1.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
				hantugom2.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
				hantugom3.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
				if (Bb) {

					if (PlayerPrefs.GetString (Link.JENIS) == "SINGLE") {
						if (ApakahCameraA) {

							Debug.Log ("KALAH");
							PlayerPrefs.SetInt ("win", 0);

							urutan1 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
							urutan2 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
							urutan3 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
							urutan1 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
							urutan2 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
							urutan3 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
							karaBanimation.PlayQueued ("kalahend", QueueMode.PlayNow);
							cameraA.SetActive (false);
							cameraB.SetActive (false);
							plihan1.SetActive (false);
							plihan2.SetActive (false);
							plihan3.SetActive (false);
							EndOption[5].SetActive (true);
							losser.SetActive (true);
                            winner.SetActive (false);
							scrollBar.SetActive (false);
							speedOption.SetActive (false);
							Time.timeScale = 1;
							SceneManagerHelper.LoadSoundFX("Lose");
							

						} else {
							Debug.Log ("MENANG");
							PlayerPrefs.SetInt ("win", 1);
							urutan1 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
							urutan2 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
							urutan3 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
							urutan1 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
							urutan2 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
							urutan3 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
							karaBanimation.PlayQueued ("menanggame", QueueMode.PlayNow);
							cameraA.SetActive (false);
							cameraB.SetActive (false);
							//	CameraEnd.SetActive (true);
							plihan1.SetActive (false);
							plihan2.SetActive (false);
							plihan3.SetActive (false);
							//	EndOptionButton.SetActive (true);
							winner.SetActive (true);
							losser.SetActive (false);
							scrollBar.SetActive (false);
							speedOption.SetActive (false);
							Time.timeScale = 1;
							SceneManagerHelper.LoadSoundFX("Win");
							
						}


					} 
				//Multiplayer
				//Multiplayer
				//Multiplayer

				else {
						if (ApakahCameraA) {
							Debug.Log ("KALAH");
							PlayerPrefs.SetInt ("win", 0);
							urutan1 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
							urutan2 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
							urutan3 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
							urutan1 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
							urutan2 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
							urutan3 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
							karaA.GetComponent<Animation> ().PlayQueued ("kalahend", QueueMode.PlayNow);
						//	karaB.GetComponent<Animation> ().PlayQueued ("menanggame", QueueMode.PlayNow);
							cameraA.SetActive (false);
							cameraB.SetActive (false);
							plihan1.SetActive (false);
							plihan2.SetActive (false);
							plihan3.SetActive (false);
							EndOption[5].SetActive (true);
							losser.SetActive (true);
							winner2.SetActive (false);
							scrollBar.SetActive (false);
							speedOption.SetActive (false);
							Time.timeScale = 1;
							SceneManagerHelper.LoadSoundFX("Lose");
							

						} else {
							Debug.Log ("MENANG");
							PlayerPrefs.SetInt ("win", 1);
							urutan1 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
							urutan2 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
							urutan3 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
							urutan1 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
							urutan2 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
							urutan3 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
							karaBanimation.PlayQueued ("menanggame", QueueMode.PlayNow);
						//	karaA.GetComponent<Animation> ().PlayQueued ("kalahgame", QueueMode.PlayNow);
							cameraA.SetActive (false);
							cameraB.SetActive (false);
							//	CameraEnd.SetActive (true);
							plihan1.SetActive (false);
							plihan2.SetActive (false);
							plihan3.SetActive (false);
							//	EndOptionButton.SetActive (true);
							winner2.SetActive (true);
							losser.SetActive (false);
							scrollBar.SetActive (false);
							speedOption.SetActive (false);
							Time.timeScale = 1;
							SceneManagerHelper.LoadSoundFX("Win");
							

						}


					} 
				} else {//kondisi A menang
					if (PlayerPrefs.GetString (Link.JENIS) == "SINGLE") {
						if (ApakahCameraA) {
							Debug.Log ("MENANG");
							PlayerPrefs.SetInt ("win", 1);
							urutan1 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
							urutan2 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
							urutan3 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
							urutan1 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
							urutan2 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
							urutan3 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
							karaBanimation.PlayQueued ("menanggame", QueueMode.PlayNow);
							cameraA.SetActive (false);
							cameraB.SetActive (false);
							//	CameraEnd.SetActive (true);
							plihan1.SetActive (false);
							plihan2.SetActive (false);
							plihan3.SetActive (false);
							//EndOptionButton.SetActive (true);
							winner2.SetActive (true);
							losser.SetActive (false);
							scrollBar.SetActive (false);
							speedOption.SetActive (false);
							Time.timeScale = 1;
							SceneManagerHelper.LoadSoundFX("Win");
						

						} else {
							Debug.Log ("KALAH");
							PlayerPrefs.SetInt ("win", 0);
							urutan1 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
							urutan2 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
							urutan3 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
							urutan1 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
							urutan2 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
							urutan3 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
							karaBanimation.PlayQueued ("kalahend", QueueMode.PlayNow);
							cameraA.SetActive (false);
							cameraB.SetActive (false);
							plihan1.SetActive (false);
							plihan2.SetActive (false);
							plihan3.SetActive (false);
							EndOption[5].SetActive (true);
							losser.SetActive (true);
							winner2.SetActive (false);
							scrollBar.SetActive (false);
							speedOption.SetActive (false);
							Time.timeScale = 1;
							SceneManagerHelper.LoadSoundFX("Lose");

						}


					} else {				//multiplayer
						if (ApakahCameraA) {
							Debug.Log ("MENANG");
							PlayerPrefs.SetInt ("win", 1);
							urutan1 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
							urutan2 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
							urutan3 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
							urutan1 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
							urutan2 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
							urutan3 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
							karaA.GetComponent<Animation> ().PlayQueued ("menanggame", QueueMode.PlayNow);
							//karaB.GetComponent<Animation> ().PlayQueued ("kalahgame", QueueMode.PlayNow);
							cameraA.SetActive (false);
							cameraB.SetActive (false);
							//	CameraEnd.SetActive (true);
							plihan1.SetActive (false);
							plihan2.SetActive (false);
							plihan3.SetActive (false);
							//	EndOptionButton.SetActive (true);
							winner2.SetActive (true);
							losser.SetActive (false);
							scrollBar.SetActive (false);
							speedOption.SetActive (false);
							Time.timeScale = 1;
							SceneManagerHelper.LoadSoundFX("Win");


						} else {
							Debug.Log ("KALAH");
							PlayerPrefs.SetInt ("win", 0);
							urutan1 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
							urutan2 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
							urutan3 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
							urutan1 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
							urutan2 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
							urutan3 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
							karaBanimation.PlayQueued ("kalahend", QueueMode.PlayNow);
							cameraA.SetActive (false);
							cameraB.SetActive (false);
							plihan1.SetActive (false);
							plihan2.SetActive (false);
							plihan3.SetActive (false);
							EndOption[5].SetActive (true);
							losser.SetActive (true);
							winner2.SetActive (false);
							scrollBar.SetActive (false);
							speedOption.SetActive (false);
							Time.timeScale = 1;
							SceneManagerHelper.LoadSoundFX("Lose");
				
						}


					}
				}
			}
			}
			//berburu
			else {
				hantugo1.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
				hantugo2.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
				hantugo3.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
				hantugom1.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
				hantugom2.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
				hantugom3.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
				if (Bb) {
					
					Debug.Log ("MENANG");
					PlayerPrefs.SetInt ("win", 1);
					urutan1 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
//					urutan2 [0].transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
//					urutan3 [0].transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
					urutan1 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
					urutan2 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
					urutan3 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
					karaBanimation.PlayQueued ("menanggame", QueueMode.PlayNow);
					cameraA.SetActive (false);
					cameraB.SetActive (false);
					//	CameraEnd.SetActive (true);
					plihan1.SetActive (false);
					plihan2.SetActive (false);
					plihan3.SetActive (false);
					//	EndOptionButton.SetActive (true);
					winner3.SetActive (true);
					losser.SetActive (false);
					scrollBar.SetActive (false);
					speedOption.SetActive (false);
					Time.timeScale = 1;
					SceneManagerHelper.LoadSoundFX("Win");


				} else {
					PlayerPrefs.SetInt ("win", 0);
					urutan1 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
//					urutan2 [0].transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
//					urutan3 [0].transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
					urutan1 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
					urutan2 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
					urutan3 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
					karaBanimation.PlayQueued ("kalahend", QueueMode.PlayNow);
					cameraA.SetActive (false);
					cameraB.SetActive (false);
					plihan1.SetActive (false);
					plihan2.SetActive (false);
					plihan3.SetActive (false);
					//	EndOptionButton.SetActive (true);
					losser2.SetActive (true);
					winner3.SetActive (false);
					scrollBar.SetActive (false);
					speedOption.SetActive (false);
					Time.timeScale = 1;
					SceneManagerHelper.LoadSoundFX("Lose");

				
				}


				} 



			if (ApakahCameraA) {
				CameraEndA.SetActive (true);
				canvasEnd ();
			} else {
				CameraEnd.SetActive (true);
				canvasEnd ();
			}
			Debug.Log (PlayerPrefs.GetInt ("win"));

		}

	}

	public GameObject winner, winner2,winner3;
	public GameObject losser,losser2;


	private IEnumerator resetFormation()
	{
		Debug.Log ("RESET !!");
		string url = Link.url + "reset_formation";
		WWWForm form = new WWWForm ();
				form.AddField (Link.ID, PlayerID);
		form.AddField ("room_name", PlayerPrefs.GetString ("RoomName"));
		WWW www = new WWW(url,form);
		yield return www;
		if (www.error == null) {



			timer =  3f;
			timeUps = false;
			panggil_url = false;
			data_belum_ada = true;
			PlayerPrefs.SetInt ("Jumlah", 0);
			PlayerPrefs.SetString ("Main", "tidak");
			PlayerPrefs.SetString ("Urutan1", "Kosong");
			PlayerPrefs.SetString ("Urutan1m", "Kosong");
			PlayerPrefs.SetString ("Suit1", "Kosong");
			cameraB.transform.position = new Vector3 (12.9f, 25.5f, 63.7f);
			cameraB.transform.rotation = Quaternion.Euler (23.09f, 191.491f, 1.302f);
			cameraB.transform.Find ("Plane").gameObject.SetActive (false);
			hantuchoose1.SetActive (false);
			hantuchoose2.SetActive (false);
			hantuchoose3.SetActive (false);
			//pilihanInputSuit [3].SetActive (true);
			//pilihanInputSuit [4].SetActive (true);
			//pilihanInputSuit [5].SetActive (true);
//			plihan1.SetActive (true);
//			plihan2.SetActive (true);
//			plihan3.SetActive (true);
		}
	}

	bool resetDatabaseYo = false;

	private IEnumerator resetDatabase()
	{
		waiting.SetActive (false);
		string url = Link.url + "reset_database";
		WWWForm form = new WWWForm ();
				form.AddField (Link.ID,PlayerID);
		WWW www = new WWW(url,form);
		yield return www;
		if (www.error == null) {
			SceneManagerHelper.LoadScene ("Home");
		}
	}

	public void PlaySajaLah(int i) {
		if (i==1) {
			StartCoroutine (War(GameObject.Find("Hantu1A"),GameObject.Find("Hantu2B"),"Charge","Block",1,GetCritical));
		}
		else if  (i==2) {
			StartCoroutine (War(GameObject.Find("Hantu2A"),GameObject.Find("Hantu3B"),"Block","Focus",1,GetCritical));
		}
		else if  (i==3) {
			StartCoroutine (War(GameObject.Find("Hantu2A"),GameObject.Find("Hantu3B"),"Charge","Focus",1,GetCritical));
		}
		else if  (i==4) {
			StartCoroutine (War(GameObject.Find("Hantu2A"),GameObject.Find("Hantu3B"),"Charge","Charge",1,GetCritical));
		}

	}

	IEnumerator War (GameObject aObject, GameObject bObject, string pilA, string pilB, int urutan, int getCritical) {

		Debug.Log (pilA + "   " + pilB);
		dg.text = (pilA + "   " + pilB);
		//aObject.GetComponent<PlayAnimation> ().PlayMaju ();
		//bObject.GetComponent<PlayAnimation> ().PlayMaju ();


		switch (pilA) {
		case "Charge":
			//	Aobject.GetComponent<Animator> ().SetBool ("FightCharge", true);
			Aobject.GetComponent<Image> ().sprite = Charge;
			break;
		case "Block":
			//	Aobject.GetComponent<Animator> ().SetBool ("FightBlock", true);
			Aobject.GetComponent<Image> ().sprite = Block;
			break;
		case "Focus":
			//Aobject.GetComponent<Animator> ().SetBool ("FightFocus", true);
			Aobject.GetComponent<Image> ().sprite = Focus;
			break;
		}

		switch (pilB) {
		case "Charge":
			//bObject.transform.FindChild ("Select").GetComponent<SpriteRenderer>().sprite = Charge;
			Bobject.GetComponent<Animator> ().SetBool ("FightCharge", true);
			Bobject.GetComponent<Image> ().sprite = Charge;
			break;
		case "Block":
			//bObject.transform.FindChild ("Select").GetComponent<SpriteRenderer> ().sprite = Block;
			Bobject.GetComponent<Animator> ().SetBool ("FightBlock", true);
			Bobject.GetComponent<Image> ().sprite = Block;
			break;
		case "Focus":
			//bObject.transform.FindChild ("Select").GetComponent<SpriteRenderer>().sprite = Focus;
			Bobject.GetComponent<Animator> ().SetBool ("FightFocus", true);
			Bobject.GetComponent<Image> ().sprite = Focus;
			break;
		}


	

	//	yield return new WaitForSeconds (1f);
	
		if (pilA == "Charge" && pilB == "Block") {
			damage = bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +50 ));
			if (bObject.GetComponent<PlayAnimation> ().element == "Fire" && aObject.GetComponent<PlayAnimation> ().element == "Fire") {
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}

			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Fire" && aObject.GetComponent<PlayAnimation> ().element == "Water") {
				damage -= damage * 20 / 100;
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}
				ReallyStriking();
			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Fire" && aObject.GetComponent<PlayAnimation> ().element == "Wind") {
				damage += damage * 20 / 100;
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}

			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Water" && aObject.GetComponent<PlayAnimation> ().element == "Water") {
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}

			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Water" && aObject.GetComponent<PlayAnimation> ().element == "Wind") {
				damage -= damage * 20 / 100;
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}
				ReallyStriking();
			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Water" && aObject.GetComponent<PlayAnimation> ().element == "Fire") {
				damage += damage * 20 / 100;
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}
				ReallyStriking();
			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Wind" && aObject.GetComponent<PlayAnimation> ().element == "Wind") {
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}

			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Wind" && aObject.GetComponent<PlayAnimation> ().element == "Fire") {
				damage -= damage * 20 / 100;
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}
				ReallyStriking();
			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Wind" && aObject.GetComponent<PlayAnimation> ().element == "Water") {
				damage += damage * 20 / 100;
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}
				ReallyStriking();
			}


			if (level1 == true) {
				damage = damage * 2;
			
			} 
			else {
				if(getCritical<=1f)
				{
					damage = damage*1.25f;
				}
				else
				{
					damage = damage;
				}
				

			}
			Bobject.GetComponent<Animator> ().SetBool ("win", true);
			Aobject.GetComponent<Animator> ().SetBool ("chargekalah", true);
			Debug.Log ("CB");
			//aObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("maju");
			//bObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("maju");
//			aObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("attack",QueueMode.PlayNow);
//
//			bObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("nangkis",QueueMode.PlayNow);
//
			yield return new WaitForSeconds (0.1f);
//			Seri_Bdef.Play ();
//
//			aObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
//			bObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle",QueueMode.PlayNow,PlayMode.StopAll);

			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("attackbaru2",QueueMode.PlayNow);
			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("hitbaru",QueueMode.PlayNow);
			//yield return new WaitForSeconds (.5f);

			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			yield return new WaitForSeconds (0.3f);
			damageA.gameObject.SetActive (true);
			int damaged = (int)damage;
			damageA.text = "- "+damaged.ToString ();
			damageB.text = "- "+damaged.ToString ();
			HealthReduction (urutan,0,damage);
			A.Play ();
			playoneshot(0);
			PlayerPrefs.SetString ("kenahit","w") ;

		}
		 if (pilA == "Block" && pilB == "Charge") {
			Debug.Log ("BC");
			//bObject.GetComponent<Animator> ().enabled = true;
			damage = aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +50) );
			if (bObject.GetComponent<PlayAnimation> ().element == "Fire" && aObject.GetComponent<PlayAnimation> ().element == "Fire") {
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}

			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Fire" && aObject.GetComponent<PlayAnimation> ().element == "Water") {
				damage += damage * 20 / 100;
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}
				ReallyStriking();
			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Fire" && aObject.GetComponent<PlayAnimation> ().element == "Wind") {
				damage -= damage * 20 / 100;
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}
				ReallyStriking();
			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Water" && aObject.GetComponent<PlayAnimation> ().element == "Water") {
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}

			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Water" && aObject.GetComponent<PlayAnimation> ().element == "Wind") {
				damage += damage * 20 / 100;
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}
				ReallyStriking();
			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Water" && aObject.GetComponent<PlayAnimation> ().element == "Fire") {
				damage -= damage * 20 / 100;
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}
				ReallyStriking();
			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Wind" && aObject.GetComponent<PlayAnimation> ().element == "Wind") {
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}

			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Wind" && aObject.GetComponent<PlayAnimation> ().element == "Fire") {
				damage += damage * 20 / 100;
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}
				ReallyStriking();
			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Wind" && aObject.GetComponent<PlayAnimation> ().element == "Water") {
				damage -= damage * 20 / 100;
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}
				ReallyStriking();
			}


			if (level1 == true) {
				damage = damage * 2;

			} 
			else {
				damage = damage;

			}
			int damaged = (int)damage;
			damageA.text = "- "+damaged.ToString ();
			damageB.text = "- "+damaged.ToString ();
			Aobject.GetComponent<Animator> ().SetBool ("win", true);
			Bobject.GetComponent<Animator> ().SetBool ("chargekalah", true);
		
			if (getCritical<=1){
				aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().Play("attackbaru2");
				bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().Play ("hitbaru");
			}
			else
			{
				Debug.Log("this animation");
				aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued("attackbaru2",QueueMode.PlayNow);
				bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("hitbaru",QueueMode.PlayNow);
			}
			

			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
		
			yield return new WaitForSeconds (0.3f);
			damageB.gameObject.SetActive (true);
			HealthReduction (urutan,1,damage);
			B.Play ();
			playoneshot(0);
			PlayerPrefs.SetString ("kenahit","l") ;

		}
		 if (pilA == "Block" && pilB == "Focus") {
			Debug.Log ("BF");
			damage = bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +50 ));
	
			if (bObject.GetComponent<PlayAnimation> ().element == "Fire" && aObject.GetComponent<PlayAnimation> ().element == "Fire") {
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}

			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Fire" && aObject.GetComponent<PlayAnimation> ().element == "Water") {
				damage -= damage * 20 / 100;
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}
				ReallyStriking();
			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Fire" && aObject.GetComponent<PlayAnimation> ().element == "Wind") {
				damage += damage * 20 / 100;
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}
				ReallyStriking();
			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Water" && aObject.GetComponent<PlayAnimation> ().element == "Water") {
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}

			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Water" && aObject.GetComponent<PlayAnimation> ().element == "Wind") {
				damage -= damage * 20 / 100;
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}
				ReallyStriking();
			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Water" && aObject.GetComponent<PlayAnimation> ().element == "Fire") {
				damage += damage * 20 / 100;
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}
				ReallyStriking();
			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Wind" && aObject.GetComponent<PlayAnimation> ().element == "Wind") {
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}

			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Wind" && aObject.GetComponent<PlayAnimation> ().element == "Fire") {
				damage -= damage * 20 / 100;
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}
				ReallyStriking();
			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Wind" && aObject.GetComponent<PlayAnimation> ().element == "Water") {
				damage += damage * 20 / 100;
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}
				ReallyStriking();
			}


			if (level1 == true) {
				damage = damage * 2;

			} 
			else {
				damage = damage;

			}
			Bobject.GetComponent<Animator> ().SetBool ("win", true);
			Aobject.GetComponent<Animator> ().SetBool ("blokkalah", true);
			Debug.Log ("CB");
			//aObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("maju");
			//bObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("maju");
			//			aObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("attack",QueueMode.PlayNow);
			//
			//			bObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("nangkis",QueueMode.PlayNow);
			//
			yield return new WaitForSeconds (0.1f);
			//			Seri_Bdef.Play ();
			//
			//			aObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			//			bObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle",QueueMode.PlayNow,PlayMode.StopAll);

			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("attackbaru2",QueueMode.PlayNow);
			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("hitbaru",QueueMode.PlayNow);
			//yield return new WaitForSeconds (.5f);

			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			yield return new WaitForSeconds (0.3f);
			damageA.gameObject.SetActive (true);
			int damaged = (int)damage;
			damageA.text = "- "+damaged.ToString ();
			damageB.text = "- "+damaged.ToString ();
			HealthReduction (urutan,0,damage);
			A.Play ();
			playoneshot(0);
			PlayerPrefs.SetString ("kenahit","w") ;

		}
		 if (pilA == "Focus" && pilB == "Block") {
			damage = aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +50 ));
//			bObject.GetComponent<PlayAnimation> ().PlayMaju ();
//			cameraB.GetComponent<Animator> ().SetBool ("hitted", true);
//			//bObject.GetComponent<Animator> ().enabled = true;
//			Debug.Log ("FB");
//			damage = aObject.transform.FindChild ("Canvas").transform.FindChild ("Image").GetComponent<filled> ().damage- bObject.transform.FindChild ("Canvas").transform.FindChild ("Image").GetComponent<filled> ().defend/2;
//			if (damage <= 0) {
//				damage = 0;
//			}damageA.text = "- "+damage.ToString ();
//			damageB.text = "- "+damage.ToString ();
//			Aobject.GetComponent<Animator> ().SetBool ("win", true);
//			Bobject.GetComponent<Animator> ().SetBool ("blokkalah", true);
//			//bObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("maju");
//			//aObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("maju");
////			bObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle",QueueMode.PlayNow);
////			aObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("charge",QueueMode.PlayNow);
////
////			Charge_A.Play ();
////			//
////			//			aObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
////			//			bObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
////
////
////
////			yield return new WaitForSeconds (1f);
////
////			aObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("attack");
//
//			bObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("nangkis_loss",QueueMode.PlayNow);
//			yield return new WaitForSeconds (0.5f);
//			damageB.gameObject.SetActive (true);
//
//			aObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
//			bObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
//
//			yield return new WaitForSeconds (0.3f);
//			HealthReduction (urutan,1,damage);
//			B.Play ();
//			hitYa.Play ();
			if (bObject.GetComponent<PlayAnimation> ().element == "Fire" && aObject.GetComponent<PlayAnimation> ().element == "Fire") {
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}

			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Fire" && aObject.GetComponent<PlayAnimation> ().element == "Water") {
				damage += damage * 20 / 100;
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}
				ReallyStriking();
			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Fire" && aObject.GetComponent<PlayAnimation> ().element == "Wind") {
				damage -= damage * 20 / 100;
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}
				ReallyStriking();
			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Water" && aObject.GetComponent<PlayAnimation> ().element == "Water") {
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}

			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Water" && aObject.GetComponent<PlayAnimation> ().element == "Wind") {
				damage += damage * 20 / 100;
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}
				ReallyStriking();
			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Water" && aObject.GetComponent<PlayAnimation> ().element == "Fire") {
				damage -= damage * 20 / 100;
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}
				ReallyStriking();
			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Wind" && aObject.GetComponent<PlayAnimation> ().element == "Wind") {
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}

			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Wind" && aObject.GetComponent<PlayAnimation> ().element == "Fire") {
				damage += damage * 20 / 100;
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}
				ReallyStriking();
			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Wind" && aObject.GetComponent<PlayAnimation> ().element == "Water") {
				damage -= damage * 20 / 100;
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}
				ReallyStriking();
			}


			if (level1 == true) {
				damage = damage * 2;

			} 
			else {
				damage = damage;

			}
			int damaged = (int)damage;
			damageA.text = "- "+damaged.ToString ();
			damageB.text = "- "+damaged.ToString ();
			Aobject.GetComponent<Animator> ().SetBool ("win", true);
			Bobject.GetComponent<Animator> ().SetBool ("blokkalah", true);
			//bObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("maju");
			//aObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("maju");
			//			bObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("attack",QueueMode.PlayNow);
			//
			//			aObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("nangkis",QueueMode.PlayNow);
			//			yield return new WaitForSeconds (.5f);
			//			Seri_Adef.Play ();
			//
			//
			//			bObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			//			aObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle",QueueMode.PlayNow,PlayMode.StopAll);
			//
			//
			//
			//
				if (getCritical<=1){
				aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().Play("attackbaru2");
				bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().Play ("hitbaru");
			}
			else
			{
				Debug.Log("this animation");
				aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued("attackbaru2",QueueMode.PlayNow);
				bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("hitbaru",QueueMode.PlayNow);
			}
			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");

			yield return new WaitForSeconds (0.3f);
			damageB.gameObject.SetActive (true);
			HealthReduction (urutan,1,damage);
			B.Play ();
			playoneshot(0);
			PlayerPrefs.SetString ("kenahit","l") ;

		}
		 if (pilA == "Focus" && pilB == "Charge") {
			Debug.Log ("FC");
			damage = bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +50 ));
//			damage = bObject.transform.FindChild ("Canvas").transform.FindChild ("Image").GetComponent<filled> ().damage- aObject.transform.FindChild ("Canvas").transform.FindChild ("Image").GetComponent<filled> ().defend/2;
//			if (damage <= 0) {
//				damage = 0;
//			}damageA.text = "- "+damage.ToString ();
//			damageB.text = "- "+damage.ToString ();
//			Bobject.GetComponent<Animator> ().SetBool ("win", true);
//			Aobject.GetComponent<Animator> ().SetBool ("fokuskalah", true);
//			//aObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("maju");
//			//bObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("maju");
////			aObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("charge",QueueMode.PlayNow);
////			bObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle",QueueMode.PlayNow);
////
////			Charge_A.Play ();
////
////			//			aObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
////			//			bObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
////
////
////
////			yield return new WaitForSeconds (.5f);
////
////			bObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("attack");
//
//			aObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("hit");
//			yield return new WaitForSeconds (0.5f);
//			damageA.gameObject.SetActive (true);
//
//			aObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
//			bObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
//
//
//			yield return new WaitForSeconds (0.3f);
//			HealthReduction (urutan,0,damage);
//			A.Play ();
//			hitYa.Play ();
			if (bObject.GetComponent<PlayAnimation> ().element == "Fire" && aObject.GetComponent<PlayAnimation> ().element == "Fire") {
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}

			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Fire" && aObject.GetComponent<PlayAnimation> ().element == "Water") {
				damage -= damage * 20 / 100;
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}
				ReallyStriking();
			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Fire" && aObject.GetComponent<PlayAnimation> ().element == "Wind") {
				damage += damage * 20 / 100;
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}
				ReallyStriking();
			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Water" && aObject.GetComponent<PlayAnimation> ().element == "Water") {
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}

			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Water" && aObject.GetComponent<PlayAnimation> ().element == "Wind") {
				damage -= damage * 20 / 100;
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}
				ReallyStriking();
			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Water" && aObject.GetComponent<PlayAnimation> ().element == "Fire") {
				damage += damage * 20 / 100;
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}
				ReallyStriking();
			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Wind" && aObject.GetComponent<PlayAnimation> ().element == "Wind") {
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}

			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Wind" && aObject.GetComponent<PlayAnimation> ().element == "Fire") {
				damage -= damage * 20 / 100;
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}
				ReallyStriking();
			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Wind" && aObject.GetComponent<PlayAnimation> ().element == "Water") {
				damage += damage * 20 / 100;
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}
				ReallyStriking();
			}


			if (level1 == true) {
				damage = damage * 2;

			} 
			else {
				damage = damage;

			}
			Bobject.GetComponent<Animator> ().SetBool ("win", true);
			Aobject.GetComponent<Animator> ().SetBool ("fokuskalah", true);
//			Debug.Log ("CB");
			//aObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("maju");
			//bObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("maju");
			//			aObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("attack",QueueMode.PlayNow);
			//
			//			bObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("nangkis",QueueMode.PlayNow);
			//
			yield return new WaitForSeconds (0.1f);
			//			Seri_Bdef.Play ();
			//
			//			aObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			//			bObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle",QueueMode.PlayNow,PlayMode.StopAll);

			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("attackbaru2",QueueMode.PlayNow);
			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("hitbaru",QueueMode.PlayNow);
			//yield return new WaitForSeconds (.5f);

			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			yield return new WaitForSeconds (0.3f);
			damageA.gameObject.SetActive (true);
			int damaged = (int)damage;
			damageA.text = "- "+damaged.ToString ();
			damageB.text = "- "+damaged.ToString ();
			HealthReduction (urutan,0,damage);
			A.Play ();
			playoneshot(0);
			PlayerPrefs.SetString ("kenahit","w") ;

		}   
		if (pilA == "Charge" && pilB == "Focus") {
			damage = aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +50 ));
			//bObject.GetComponent<Animator> ().enabled = true;
//			cameraB.GetComponent<Animator> ().SetBool ("hitted", true);
//			Debug.Log ("CF");
//			damage = aObject.transform.FindChild ("Canvas").transform.FindChild ("Image").GetComponent<filled> ().damage- bObject.transform.FindChild ("Canvas").transform.FindChild ("Image").GetComponent<filled> ().defend/2;
//			if (damage <= 0) {
//				damage = 0;
//			}damageA.text = "- "+damage.ToString ();
//			damageB.text = "- "+damage.ToString ();
//			Aobject.GetComponent<Animator> ().SetBool ("win", true);
//			Bobject.GetComponent<Animator> ().SetBool ("fokuskalah", true);
//			//bObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("maju");
//			//aObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("maju");
////			bObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued("charge",QueueMode.PlayNow);
////			aObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
////
////			Charge_B.Play ();
////
////			//			aObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
////			//			bObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
////
////
////			yield return new WaitForSeconds (.5f);
////			aObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("attack");
//
//			bObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("hit");
//			yield return new WaitForSeconds (0.5f);
//			damageB.gameObject.SetActive (true);
//			//
//			aObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
//			bObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
//
//			yield return new WaitForSeconds (0.1f);
//			HealthReduction (urutan,1,damage);
//			B.Play ();
//			hitYa.Play ();
//
			if (bObject.GetComponent<PlayAnimation> ().element == "Fire" && aObject.GetComponent<PlayAnimation> ().element == "Fire") {
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}

			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Fire" && aObject.GetComponent<PlayAnimation> ().element == "Water") {
				damage += damage * 20 / 100;
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}
				ReallyStriking();
			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Fire" && aObject.GetComponent<PlayAnimation> ().element == "Wind") {
				damage -= damage * 20 / 100;
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}
				ReallyStriking();
			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Water" && aObject.GetComponent<PlayAnimation> ().element == "Water") {
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}

			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Water" && aObject.GetComponent<PlayAnimation> ().element == "Wind") {
				damage += damage * 20 / 100;
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}
				ReallyStriking();
			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Water" && aObject.GetComponent<PlayAnimation> ().element == "Fire") {
				damage -= damage * 20 / 100;
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}
				ReallyStriking();
			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Wind" && aObject.GetComponent<PlayAnimation> ().element == "Wind") {
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}

			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Wind" && aObject.GetComponent<PlayAnimation> ().element == "Fire") {
				damage += damage * 20 / 100;
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}
				ReallyStriking();
			}
			if (bObject.GetComponent<PlayAnimation> ().element == "Wind" && aObject.GetComponent<PlayAnimation> ().element == "Water") {
				damage -= damage * 20 / 100;
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage+=damage*5/100;
				}
				if (again == 1) {
					damage-=damage*5/100;
				}
				ReallyStriking();
			}


			if (level1 == true) {
				damage = damage * 2;

			} 
			else {
				damage = damage;

			}
			int damaged = (int)damage;
			damageA.text = "- "+damaged.ToString ();
			damageB.text = "- "+damaged.ToString ();
			Aobject.GetComponent<Animator> ().SetBool ("win", true);
			Bobject.GetComponent<Animator> ().SetBool ("fokuskalah", true);
			//bObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("maju");
			//aObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("maju");
			//			bObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("attack",QueueMode.PlayNow);
			//
			//			aObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("nangkis",QueueMode.PlayNow);
			//			yield return new WaitForSeconds (.5f);
			//			Seri_Adef.Play ();
			//
			//
			//			bObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			//			aObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle",QueueMode.PlayNow,PlayMode.StopAll);
			//
			//
			//
			//
			print(getCritical);
				if (getCritical<=1){
				aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().Play("attackbaru2");
				bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().Play ("hitbaru");
				}
			else
			{
				Debug.Log("this animation");
				aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued("attackbaru2",QueueMode.PlayNow);
				bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("hitbaru",QueueMode.PlayNow);
			}
			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");

			yield return new WaitForSeconds (0.3f);
			damageB.gameObject.SetActive (true);
			HealthReduction (urutan,1,damage);
			B.Play ();
			playoneshot(0);
			PlayerPrefs.SetString ("kenahit","l") ;
		}

		 if (pilA == "Focus" && pilB == "Focus") {
			//air
			if (urutan1[0].GetComponent<PlayAnimation> ().element == "Fire" && urutan1[1].GetComponent<PlayAnimation> ().element =="Fire") {

			

				 damage2=bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
					damage = aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				Debug.Log("sama api");

			}
			if (urutan1[0].GetComponent<PlayAnimation> ().element  == "Fire" && urutan1[1].GetComponent<PlayAnimation> ().element =="Water") {
				damage2=bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				damage = aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				damage2 += damage2 * 20 / 100;
				damage -= damage * 20 / 100;
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage2+=damage2*5/100;
					damage+=damage2*5/100;
				}
				if (again == 1) {
					damage2-=damage2*5/100;
					damage-=damage*5/100;
				}

				Debug.Log("musuh api, player air");
				Debug.Log("sama api");
			

			}
			if (urutan1[0].GetComponent<PlayAnimation> ().element  == "Fire" && urutan1[1].GetComponent<PlayAnimation> ().element =="Wind") {
				Debug.Log("musuh api, player angin");
				 damage2=bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				damage = aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				damage2 -= damage2 * 20 / 100;
				damage += damage * 20 / 100;
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage2+=damage2*5/100;
					damage+=damage2*5/100;
				}
				if (again == 1) {
					damage2-=damage2*5/100;
					damage-=damage*5/100;
				}

				Debug.Log("sama api");
			

			}
			//Api
			if (urutan1[0].GetComponent<PlayAnimation> ().element == "Water" && urutan1[1].GetComponent<PlayAnimation> ().element =="Fire") {
				Debug.Log("musuh air, player api");
				 damage2=bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				damage = aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				damage2 -= damage2 * 20 / 100;
				damage += damage * 20 / 100;
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage2+=damage2*5/100;
					damage+=damage2*5/100;
				}
				if (again == 1) {
					damage2-=damage2*5/100;
					damage-=damage*5/100;
				}

				Debug.Log("sama api");
			

			}
			if (urutan1[0].GetComponent<PlayAnimation> ().element  == "Water" && urutan1[1].GetComponent<PlayAnimation> ().element =="Water") {
				Debug.Log("sama air");
				 damage2=bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				damage = aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				Debug.Log("sama api");
		

			}
			if (urutan1[0].GetComponent<PlayAnimation> ().element  == "Water" && urutan1[1].GetComponent<PlayAnimation> ().element =="Wind") {
				Debug.Log("musuh air, player angin");
				 damage2=bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				damage = aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				Debug.Log("sama api");
				damage2 += damage2 * 20 / 100;
				damage -= damage * 20 / 100;
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage2+=damage2*5/100;
					damage+=damage2*5/100;
				}
				if (again == 1) {
					damage2-=damage2*5/100;
					damage-=damage*5/100;
				}


			}
			//angin
			if (urutan1[0].GetComponent<PlayAnimation> ().element == "Wind" && urutan1[1].GetComponent<PlayAnimation> ().element =="Fire") {
				Debug.Log("musuh angin, player api");
				 damage2=bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				damage = aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				Debug.Log("sama api");
				damage2 += damage2 * 20 / 100;
				damage -= damage * 20 / 100;
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage2+=damage2*5/100;
					damage+=damage2*5/100;
				}
				if (again == 1) {
					damage2-=damage2*5/100;
					damage-=damage*5/100;
				}


			}
			if (urutan1[0].GetComponent<PlayAnimation> ().element  == "Wind" && urutan1[1].GetComponent<PlayAnimation> ().element =="Water") {
				Debug.Log("musuh angin, player air");
				 damage2=bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				damage = aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				Debug.Log("sama api");
				damage2 -= damage2 * 20 / 100;
				damage += damage * 20 / 100;
				int again = Random.Range (0, 1);
				if (again == 0) {
					damage2+=damage2*5/100;
					damage+=damage2*5/100;
				}
				if (again == 1) {
					damage2-=damage2*5/100;
					damage-=damage*5/100;
				}


			}
			if (urutan1[0].GetComponent<PlayAnimation> ().element  == "Wind" && urutan1[1].GetComponent<PlayAnimation> ().element =="Wind") {
				Debug.Log("sama angin");
				 damage2=bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				damage = aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				Debug.Log("sama api");
		

			}
			//bObject.GetComponent<Animator> ().enabled = true;
			cameraB.GetComponent<Animator> ().SetBool ("hitted", true);
			bObject.GetComponent<PlayAnimation> ().PlayMaju ();
			
			//bObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("maju");
			//aObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("maju");
			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().Play ("hitbaru");
			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().Play ("hitbaru");
			
			//			aObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			//			bObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			//

			Bobject.GetComponent<Animator> ().SetBool ("fokuskalah", true);
			Aobject.GetComponent<Animator> ().SetBool ("fokuskalah", true);



			//bObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("draw");
			//aObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("draw");

			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");


			//Seri_A.Play ();

			yield return new WaitForSeconds (.25f);
			int damaged = (int)damage;
			int damaged2 = (int)damage2;
			damageA.text = "- "+damaged2.ToString ();
			damageB.text = "- "+damaged.ToString ();
			HealthReduction (urutan,1,damage);
			HealthReduction (urutan,0,damage2);
			damageA.gameObject.SetActive (true);
			damageB.gameObject.SetActive (true);
			Seri_A.Play ();
			playoneshot(1);
			PlayerPrefs.SetString ("kenahit","l") ;

		}

		 if (pilA == "Charge" && pilB == "Charge") {
			//air
			if (urutan1[0].GetComponent<PlayAnimation> ().element == "Fire" && urutan1[1].GetComponent<PlayAnimation> ().element =="Fire") {
				 damage2=bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				damage = aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				Debug.Log("sama api");

			}
			if (urutan1[0].GetComponent<PlayAnimation> ().element  == "Fire" && urutan1[1].GetComponent<PlayAnimation> ().element =="Water") {
				Debug.Log("musuh api, player air");
				 damage2=bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				damage = aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				Debug.Log("sama api");


			}
			if (urutan1[0].GetComponent<PlayAnimation> ().element  == "Fire" && urutan1[1].GetComponent<PlayAnimation> ().element =="Wind") {
				Debug.Log("musuh api, player angin");
				 damage2=bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				damage = aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				Debug.Log("sama api");


			}
			//Api
			if (urutan1[0].GetComponent<PlayAnimation> ().element == "Water" && urutan1[1].GetComponent<PlayAnimation> ().element =="Fire") {
				Debug.Log("musuh air, player api");
				 damage2=bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				damage = aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				Debug.Log("sama api");


			}
			if (urutan1[0].GetComponent<PlayAnimation> ().element  == "Water" && urutan1[1].GetComponent<PlayAnimation> ().element =="Water") {
				Debug.Log("sama air");
				 damage2=bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				damage = aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				Debug.Log("sama api");

			}
			if (urutan1[0].GetComponent<PlayAnimation> ().element  == "Water" && urutan1[1].GetComponent<PlayAnimation> ().element =="Wind") {
				Debug.Log("musuh air, player angin");
				 damage2=bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				damage = aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				Debug.Log("sama api");
			

			}
			//angin
			if (urutan1[0].GetComponent<PlayAnimation> ().element == "Wind" && urutan1[1].GetComponent<PlayAnimation> ().element =="Fire") {
				Debug.Log("musuh angin, player api");
				 damage2=bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				damage = aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				Debug.Log("sama api");


			}
			if (urutan1[0].GetComponent<PlayAnimation> ().element  == "Wind" && urutan1[1].GetComponent<PlayAnimation> ().element =="Water") {
				Debug.Log("musuh angin, player air");
				 damage2=bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				damage = aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				Debug.Log("sama api");


			}
			if (urutan1[0].GetComponent<PlayAnimation> ().element  == "Wind" && urutan1[1].GetComponent<PlayAnimation> ().element =="Wind") {
				Debug.Log("sama angin");
				 damage2=bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				damage = aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				Debug.Log("sama api");


			}
			//bObject.GetComponent<Animator> ().enabled = true;
			cameraB.GetComponent<Animator> ().SetBool ("hitted", true);
			bObject.GetComponent<PlayAnimation> ().PlayMaju ();
			//bObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("maju");
			//aObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("maju");
			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().Play ("hitbaru");
			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().Play ("hitbaru");
			
			//			aObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			//			bObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			//

			Bobject.GetComponent<Animator> ().SetBool ("chargekalah", true);
			Aobject.GetComponent<Animator> ().SetBool ("chargekalah", true);



			//bObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("draw");
			//aObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("draw");

			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");


			//Seri_A.Play ();
			yield return new WaitForSeconds (.25f);
			int damaged = (int)damage;
			int damaged2 = (int)damage2;
			damageA.text = "- "+damaged2.ToString ();
			damageB.text = "- "+damaged.ToString ();
			damageA.gameObject.SetActive (true);
			damageB.gameObject.SetActive (true);
			HealthReduction (urutan,1,damage);
			HealthReduction (urutan,0,damage2);
			Seri_A.Play ();
			playoneshot(1);
			PlayerPrefs.SetString ("kenahit","l") ;
		
		}
		 if (pilA == "Block" && pilB == "Block") {
			//air
			if (urutan1[0].GetComponent<PlayAnimation> ().element == "Fire" && urutan1[1].GetComponent<PlayAnimation> ().element =="Fire") {
				damage2=bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				damage = aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				Debug.Log("sama api");

			}
			if (urutan1[0].GetComponent<PlayAnimation> ().element  == "Fire" && urutan1[1].GetComponent<PlayAnimation> ().element =="Water") {
				Debug.Log("musuh api, player air");
				 damage2=bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				damage = aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				Debug.Log("sama api");


			}
			if (urutan1[0].GetComponent<PlayAnimation> ().element  == "Fire" && urutan1[1].GetComponent<PlayAnimation> ().element =="Wind") {
				Debug.Log("musuh api, player angin");
				 damage2=bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				damage = aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				Debug.Log("sama api");


			}
			//Api
			if (urutan1[0].GetComponent<PlayAnimation> ().element == "Water" && urutan1[1].GetComponent<PlayAnimation> ().element =="Fire") {
				Debug.Log("musuh air, player api");
				 damage2=bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				damage = aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				Debug.Log("sama api");


			}
			if (urutan1[0].GetComponent<PlayAnimation> ().element  == "Water" && urutan1[1].GetComponent<PlayAnimation> ().element =="Water") {
				Debug.Log("sama air");
				 damage2=bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				damage = aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				Debug.Log("sama api");
			

			}
			if (urutan1[0].GetComponent<PlayAnimation> ().element  == "Water" && urutan1[1].GetComponent<PlayAnimation> ().element =="Wind") {
				Debug.Log("musuh air, player angin");
				 damage2=bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				damage = aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				Debug.Log("sama api");
			

			}
			//angin
			if (urutan1[0].GetComponent<PlayAnimation> ().element == "Wind" && urutan1[1].GetComponent<PlayAnimation> ().element =="Fire") {
				Debug.Log("musuh angin, player api");
				 damage2=bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				damage = aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				Debug.Log("sama api");
			

			}
			if (urutan1[0].GetComponent<PlayAnimation> ().element  == "Wind" && urutan1[1].GetComponent<PlayAnimation> ().element =="Water") {
				Debug.Log("musuh angin, player air");
				 damage2=bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				damage = aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				Debug.Log("sama api");


			}
			if (urutan1[0].GetComponent<PlayAnimation> ().element  == "Wind" && urutan1[1].GetComponent<PlayAnimation> ().element =="Wind") {
				Debug.Log("sama angin");
				 damage2=bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				damage = aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage* (aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage/( bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend +100 ));
				Debug.Log("sama api");
			

			}
			//bObject.GetComponent<Animator> ().enabled = true;
			cameraB.GetComponent<Animator> ().SetBool ("hitted", true);
			bObject.GetComponent<PlayAnimation> ().PlayMaju ();
			//bObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("maju");
			//aObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("maju");
			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().Play ("hitbaru");
			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().Play ("hitbaru");
			
			//			aObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			//			bObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			//

			Bobject.GetComponent<Animator> ().SetBool ("blokkalah", true);
			Aobject.GetComponent<Animator> ().SetBool ("blokkalah", true);



			//bObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("draw");
			//aObject.transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("draw");
			
			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");


			//Seri_A.Play ();
			yield return new WaitForSeconds (.25f);

			int damaged = (int)damage;
			int damaged2 = (int)damage2;
			damageA.text = "- "+damaged2.ToString ();
			damageB.text = "- "+damaged.ToString ();
			damageA.gameObject.SetActive (true);
			damageB.gameObject.SetActive (true);
			HealthReduction (urutan,1,damage);
			HealthReduction (urutan,0,damage2);
			Seri_A.Play ();
			playoneshot(1);
			PlayerPrefs.SetString ("kenahit","l") ;
		}

		yield return new WaitForSeconds (.5f);

		aObject.transform.Find ("Select").GetComponent<SpriteRenderer>().sprite = null;
		bObject.transform.Find ("Select").GetComponent<SpriteRenderer>().sprite = null;


		//aObject.GetComponent<PlayAnimation> ().PlayBalik();
		//bObject.GetComponent<PlayAnimation> ().PlayBalik();

		Aobject.GetComponent<Animator> ().SetBool ("LeftFight", false);
		Bobject.GetComponent<Animator> ().SetBool ("RightFight", false);
		Aobject.GetComponent<Animator> ().SetBool ("blokkalah", false);
		Bobject.GetComponent<Animator> ().SetBool ("blokkalah", false);
		Aobject.GetComponent<Animator> ().SetBool ("chargekalah", false);
		Bobject.GetComponent<Animator> ().SetBool ("chargekalah", false);
		Aobject.GetComponent<Animator> ().SetBool ("fokuskalah", false);
		Bobject.GetComponent<Animator> ().SetBool ("fokuskalah", false);
		Aobject.GetComponent<Animator> ().SetBool ("FightCharge", false);
		Bobject.GetComponent<Animator> ().SetBool ("FightCharge", false);
		Aobject.GetComponent<Animator> ().SetBool ("FightFocus", false);
		Bobject.GetComponent<Animator> ().SetBool ("FightFocus", false);
		Aobject.GetComponent<Animator> ().SetBool ("FightBlock", false);
		Bobject.GetComponent<Animator> ().SetBool ("FightBlock", false);
		Bobject.GetComponent<Animator> ().SetBool ("win", false);
		Aobject.GetComponent<Animator> ().SetBool ("win", false);
		damageA.gameObject.SetActive (false);
		damageB.gameObject.SetActive (false);

	


		//
//				pilihanInputSuit [0].SetActive (true);
//				pilihanInputSuit [1].SetActive (true);
//				pilihanInputSuit [2].SetActive (true);
		//		Aaobject.GetComponent<Animator> ().SetBool ("LeftFight", false);
		//		Baobject.GetComponent<Animator> ().SetBool ("RightFight", false);



	}





	public Sprite half;
	public Sprite empty;
	IEnumerator tunggudulu(string posisihantu){

		if (posisihantu == "1") {
			yield return new WaitForSeconds (3);
			model21a.enabled = false;

		}
		if (posisihantu == "2") {
			yield return new WaitForSeconds (3);
			model22a.enabled = false;

		}
		if (posisihantu == "3") {
			yield return new WaitForSeconds (3);
			model23a.enabled = false;

		}
	}
	IEnumerator tunggudulu2(string posisihantu){

		if (posisihantu == "1") {
			yield return new WaitForSeconds (3);
			model11a.enabled = false;

		}
		if (posisihantu == "2") {
			yield return new WaitForSeconds (3);
			model12a.enabled = false;

		}
		if (posisihantu == "3") {
			yield return new WaitForSeconds (3);
			model13a.enabled = false;

		}
	}
	public void HealthReduction (int urutan, int player,float damaged) {

		
		if (urutan == 1) {
			if (player == 1) {
				PlayerHPCurrent=PlayerHPCurrent-damaged;
				var z = (PlayerHPCurrent/PlayerHPMax);
				if(PlayerHPCurrent< 0){
					z=0;
				}
				PlayerHP.GetComponent<Image>().fillAmount=z;
				
				Debug.Log("Player Damaged"+ damaged);
				healthBar1 [1].GetComponent<filled> ().currenthealth = healthBar1 [1].GetComponent<filled> ().currenthealth - damaged;
				//healthBar1 [1].GetComponent<filled> ().currenthealth = health1 [1];
				//healthBar1[1].GetComponent<filled>().currenthealth = healthBar1[1].GetComponent<filled>().currenthealth - damaged;

				if (healthBar1 [1].GetComponent<filled> ().currenthealth  <=0) {

//					repeat = false;
//
//					if (Bb == false) {
//						Ab = true;
						Debug.Log ("1 mati");
//					}
					if(urutan1[1].name=="Hantu1B")
					{
					PlayerPrefs.SetString("1player","mati");
						model21a.PlayQueued ("kalah",QueueMode.CompleteOthers);
					pilihanInputSuit[3].SetActive(false);
                        h1cubeb.SetActive(false);
                        StartCoroutine (tunggudulu ("1"));
					//healthBar1 [1].GetComponent<SpriteRenderer> ().sprite = empty;
					}
					if(urutan1[1].name=="Hantu2B")
					{
						PlayerPrefs.SetString("2player","mati");
						model22a.PlayQueued ("kalah",QueueMode.CompleteOthers);
						pilihanInputSuit[4].SetActive(false);
                        h2cubeb.SetActive(false);
                        StartCoroutine (tunggudulu ("2"));
						//healthBar1 [1].GetComponent<SpriteRenderer> ().sprite = empty;
					}
					if(urutan1[1].name=="Hantu3B")
					{
						PlayerPrefs.SetString("3player","mati");
						model23a.PlayQueued ("kalah",QueueMode.CompleteOthers);
						pilihanInputSuit[5].SetActive(false);
                        h3cubeb.SetActive(false);
                        StartCoroutine (tunggudulu ("3"));
						//healthBar1 [1].GetComponent<SpriteRenderer> ().sprite = empty;
					}
				}

				//healthBar1[1].transform.localScale = new Vector3(health1[1], healthBar1[1].transform.localScale.y, healthBar1[1].transform.localScale.z);
			} else {
				EnemiesHPCurrent=EnemiesHPCurrent-damaged;
				var z = (EnemiesHPCurrent/EnemiesHPMax);
				if(EnemiesHPCurrent< 0){
					z=0;
				}
				EnemiesHP.GetComponent<Image>().fillAmount=z;
				Debug.Log("Enemies Damaged"+ damaged);
				//healthBar1[0].GetComponent<filled>().currenthealth = healthBar1[0].GetComponent<filled>().currenthealth - damaged;
				//health1 [0] = health1 [0] - damaged;
				//	healthBar1 [0].GetComponent<filled> ().currenthealth = health1 [0];
				healthBar1 [0].GetComponent<filled> ().currenthealth= healthBar1 [0].GetComponent<filled> ().currenthealth-damaged;
				//health1 [0] = health1 [0] - damaged;
				//healthBar1 [0].transform.localScale = new Vector3 (health1 [0], healthBar1 [0].transform.localScale.y, healthBar1 [0].transform.localScale.z);

				if (healthBar1 [0].GetComponent<filled> ().currenthealth <= 0) {

					if(urutan1[0].name=="Hantu1A")
					{
						PlayerPrefs.SetString("musuh1","mati");
						model11a.PlayQueued ("kalah",QueueMode.CompleteOthers);
						//pilihanInputSuit[3].SetActive(false);
						StartCoroutine (tunggudulu2 ("1"));
						//healthBar1 [1].GetComponent<SpriteRenderer> ().sprite = empty;
						Debug.Log ("1a mati");
					}
					if(urutan1[0].name=="Hantu2A")
					{
						PlayerPrefs.SetString("musuh2","mati");
						model12a.PlayQueued ("kalah",QueueMode.CompleteOthers);
						//pilihanInputSuit[4].SetActive(false);
						StartCoroutine (tunggudulu2 ("2"));
						//healthBar1 [1].GetComponent<SpriteRenderer> ().sprite = empty;
						Debug.Log ("2a mati");
					}
					if(urutan1[0].name=="Hantu3A")
					{
							PlayerPrefs.SetString("musuh3","mati");
						model13a.PlayQueued ("kalah",QueueMode.CompleteOthers);
						//pilihanInputSuit[5].SetActive(false);
						StartCoroutine (tunggudulu2 ("3"));
						Debug.Log ("3a mati");
						//healthBar1 [1].GetComponent<SpriteRenderer> ().sprite = empty;
					}
					//repeat = false;
					//if (Ab == false) {
					//	Bb = true;

					//}
					//healthBar1 [0].GetComponent<SpriteRenderer> ().sprite = empty;
				}



			}

		} 
//		else if (urutan == 2) {
//
//			if (player == 1) {
//				//	health2 [1] = health2 [1] - damaged;
//				//health2 [1] = health2 [1] - damaged;
//				healthBar2 [1].GetComponent<filled> ().currenthealth = healthBar2 [1].GetComponent<filled> ().currenthealth-damaged;
//				//healthBar2[1].GetComponent<filled>().currenthealth = healthBar2[1].GetComponent<filled>().currenthealth - damaged;
//				//healthBar2[1].transform.localScale = new Vector3(health2[1], healthBar2[1].transform.localScale.y, healthBar2[1].transform.localScale.z);
//
//				if (healthBar2 [1].GetComponent<filled> ().currenthealth <= 0) {
////
////					repeat = false;
////					if (Bb == false) {
////						Ab = true;
//					PlayerPrefs.SetString("2player","mati");
//					Debug.Log ("2player mati");
//					model2_2.GetComponent<Animation> ().PlayQueued ("kalah",QueueMode.PlayNow);
//					pilihanInputSuit[4].SetActive(false);
////					}
//					//healthBar2 [1].GetComponent<SpriteRenderer> ().sprite = empty;
//				}
//
//			} else {
//				//health2 [0] = health2 [0] - damaged;
//				//health2 [0] = health2 [0] - damaged;
//				healthBar2 [0].GetComponent<filled> ().currenthealth = healthBar2 [0].GetComponent<filled> ().currenthealth - damaged;
//				//healthBar2[0].GetComponent<filled>().currenthealth = healthBar2[0].GetComponent<filled>().currenthealth - damaged;
//				//healthBar2 [0].transform.localScale = new Vector3 (health2 [0], healthBar2 [0].transform.localScale.y, healthBar2 [0].transform.localScale.z);
//
//				if (healthBar2 [0].GetComponent<filled> ().currenthealth <= 0) {
//					repeat = false;
//					if (Ab == false) {
//						Bb = true;
//						Debug.Log ("Its Done Dude B is the Winner");
//					}
//					//healthBar2 [0].GetComponent<SpriteRenderer> ().sprite = empty;
//				}
//
//			}
//
//		} else {
//
//			if (player == 1) {
//				//health3 [1] = health3 [1] - damaged;
//				//health3 [1] = health3 [1] - damaged;
//				healthBar3 [1].GetComponent<filled> ().currenthealth = healthBar3 [1].GetComponent<filled> ().currenthealth - damaged;
//				//healthBar3[1].GetComponent<filled>().currenthealth = healthBar3[1].GetComponent<filled>().currenthealth - damaged;
//				//healthBar3[1].transform.localScale = new Vector3(health3[1], healthBar3[1].transform.localScale.y, healthBar3[1].transform.localScale.z);
//
//
//				if (healthBar3 [1].GetComponent<filled> ().currenthealth <= 0) {
//
////					repeat = false;
////					if (Bb == false) {
////						Ab = true;
//					PlayerPrefs.SetString("3player","mati");
//						Debug.Log ("3player mati");
//					model2_3.GetComponent<Animation> ().PlayQueued ("kalah",QueueMode.PlayNow);
//					pilihanInputSuit[5].SetActive(false);
////					}
//					//healthBar3 [1].GetComponent<SpriteRenderer> ().sprite = empty;
//				}
//
//			} else {
//				//	health3 [0] = health3 [0] - damaged;
//				healthBar3 [0].GetComponent<filled> ().currenthealth = healthBar3 [0].GetComponent<filled> ().currenthealth - damaged;
//				//healthBar3 [0].transform.localScale = new Vector3 (health3 [0], healthBar3 [0].transform.localScale.y, healthBar3 [0].transform.localScale.z);
//
//				if (healthBar3 [0].GetComponent<filled> ().currenthealth <= 0) {
//
//					repeat = false;
//					if (Ab == false) {
//						Bb = true;
//						Debug.Log ("Its Done Dude B is the Winner");
//					}
//					//	healthBar3 [0].GetComponent<SpriteRenderer> ().sprite = empty;
//				}
//
//			}
//
//
//
//		}
		if (PlayerPrefs.GetString ("berburu") != "ya") {
			if (PlayerPrefs.GetString ("1player") == "mati" && PlayerPrefs.GetString ("2player") == "mati" && PlayerPrefs.GetString ("3player") == "mati") {
				repeat = false;
				ulang = false;
				Ab = true;
				Debug.Log ("Its Done Dude A is the Winner");
		
			}
			if(PlayerPrefs.GetString("PLAY_TUTORIAL")=="TRUE")
			{
			if (PlayerPrefs.GetString ("musuh1") == "mati" )	
			{
				repeat = false;
				ulang = false;
				Bb = true;
				Debug.Log ("Its Done Dude B is the Winner");

			}
			}
			else
			{
			if (PlayerPrefs.GetString ("musuh1") == "mati" && PlayerPrefs.GetString ("musuh2") == "mati" && PlayerPrefs.GetString ("musuh3") == "mati") {
				repeat = false;
				ulang = false;
				Bb = true;
				Debug.Log ("Its Done Dude B is the Winner");
			}
			}
		} 
			else {
			if (PlayerPrefs.GetString ("1player") == "mati" && PlayerPrefs.GetString ("2player") == "mati" && PlayerPrefs.GetString ("3player") == "mati") {
				repeat = false;
				ulang = false;
				Ab = true;
				Debug.Log ("Its Done Dude A is the Winner");

			}
			if (PlayerPrefs.GetString ("musuh1") == "mati" )	{
				repeat = false;
				ulang = false;
				Bb = true;
				Debug.Log ("Its Done Dude B is the Winner");

			}
		
		}



	}

	public void Replay () {
		if (PlayerPrefs.GetString (Link.JENIS) != "SINGLE"||PlayerPrefs.GetString (Link.SEARCH_BATTLE)=="ONLINE") {
			SceneManagerHelper.LoadScene (Link.Arena);
		} else {
			if (pressed) {
				StartCoroutine (kurangEnergy ());
			}
		}

	}
	private IEnumerator kurangEnergy ()
	{
		string url = Link.url + "energy";
		WWWForm form = new WWWForm ();
		form.AddField (Link.ID,PlayerID);
		form.AddField ("EUsed", PlayerPrefs.GetInt("EUsed").ToString());
        form.AddField("DID", PlayerPrefs.GetString(Link.DEVICE_ID));
        WWW www = new WWW(url,form);
		yield return www;
		if (www.error == null) {

			var jsonString = JSON.Parse (www.text);
			Debug.Log (www.text);
			PlayerPrefs.SetString (Link.FOR_CONVERTING, jsonString["code"]);
			if (int.Parse(PlayerPrefs.GetString(Link.FOR_CONVERTING))==1) {
				lf.lostLife (PlayerPrefs.GetInt("EUsed"),int.Parse(jsonString["data"]["energy"]));
				PlayerPrefs.SetString (Link.ENERGY,jsonString["data"]["energy"]);
				//yield return new WaitForSeconds (1);
				SceneManagerHelper.LoadScene ("Game 1");
			}
            else if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == "33")
            {	
                validationError.SetActive(true);
            }
        } else {
			pressed = false;
			//trouble.SetActive (true);
			Debug.Log ("GAGAL");
		}
	}
	public void KurangEnergy()
	{
		StartCoroutine(kurangEnergy());
	}
	public void Berburu () {
		PlayerPrefs.SetString ("berburu", "tidak");
		if (PlayerPrefs.GetInt ("win") == 1) {
            SceneManagerHelper.LoadScene("Home");

        } else {
			SceneManagerHelper.LoadScene ("Home");
		}
	}
	public void Berburu2 () {
		PlayerPrefs.SetString ("berburu", "tidak");
			SceneManagerHelper.LoadScene ("Home");


	}

	public void Map () {
		if (PlayerPrefs.GetString ("PLAY_TUTORIAL") == "TRUE") {
			PlayerPrefs.SetString ("Tutorgame", "TRUE");
		}
		SceneManagerHelper.LoadScene (Link.Map);
	}
	public void GameSpeed(int speed){
		Time.timeScale = speed;
		PlayerPrefs.SetInt ("speedscale", speed);
	}
	public void givingup(){

		Ab = true;
		repeat = false;
		ulang = false;
		PlayerPrefs.SetInt ("win", 0);
		karaBbukuskin.enabled = true;
		karaBskin.enabled = true;
		karaA.transform.Find ("book001").GetComponent<SkinnedMeshRenderer> ().enabled = true;
		karaA.GetComponent<SkinnedMeshRenderer> ().enabled = true;
		urutan1 [0] = GameObject.Find ("Hantu1A");
		urutan1 [1] = GameObject.Find ("Hantu1B");

		urutan2 [0] = GameObject.Find ("Hantu2A");
		urutan2 [1] = GameObject.Find ("Hantu2B");

		urutan3 [0] = GameObject.Find ("Hantu3A");
		urutan3 [1] = GameObject.Find ("Hantu3B");
		resetDatabaseYo = true;
		//			model11a.enabled = true;
		//			model21a.enabled = true;
		//			model12a.enabled = true;
		//			model22a.enabled = true;
		//			model13a.enabled = true;
		//			model23a.enabled = true;
		if (PlayerPrefs.GetString ("berburu") != "ya") {
			hantugo1.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
			hantugo2.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
			hantugo3.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
			hantugom1.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
			hantugom2.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
			hantugom3.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
			if (Bb) {

				if (PlayerPrefs.GetString (Link.JENIS) == "SINGLE") {
					if (ApakahCameraA) {

						Debug.Log ("KALAH");
						PlayerPrefs.SetInt ("win", 0);

						urutan1 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
						urutan2 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
						urutan3 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
						urutan1 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
						urutan2 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
						urutan3 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
						karaBanimation.PlayQueued ("kalahend", QueueMode.PlayNow);
						cameraA.SetActive (false);
						cameraB.SetActive (false);
						plihan1.SetActive (false);
						plihan2.SetActive (false);
						plihan3.SetActive (false);
						EndOption[5].SetActive (true);
						losser.SetActive (true);
                        winner.SetActive (false);
						scrollBar.SetActive (false);
						speedOption.SetActive (false);
						Time.timeScale = 1;
						SceneManagerHelper.LoadSoundFX("Lose");

					} else {
						Debug.Log ("MENANG");
						PlayerPrefs.SetInt ("win", 1);
						urutan1 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
						urutan2 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
						urutan3 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
						urutan1 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
						urutan2 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
						urutan3 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
						karaBanimation.PlayQueued ("menanggame", QueueMode.PlayNow);
						cameraA.SetActive (false);
						cameraB.SetActive (false);
						//	CameraEnd.SetActive (true);
						plihan1.SetActive (false);
						plihan2.SetActive (false);
						plihan3.SetActive (false);
						//	EndOptionButton.SetActive (true);
						winner.SetActive (true);
						losser.SetActive (false);
						scrollBar.SetActive (false);
						speedOption.SetActive (false);
						Time.timeScale = 1;
						SceneManagerHelper.LoadSoundFX("Win");

					}


				} 
				//Multiplayer
				//Multiplayer
				//Multiplayer


			} else {//kondisi A menang
				if (PlayerPrefs.GetString (Link.JENIS) == "SINGLE") {
					if (ApakahCameraA) {
						Debug.Log ("MENANG");
						PlayerPrefs.SetInt ("win", 1);
						urutan1 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
						urutan2 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
						urutan3 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
						urutan1 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
						urutan2 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
						urutan3 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
						karaBanimation.PlayQueued ("menanggame", QueueMode.PlayNow);
						cameraA.SetActive (false);
						cameraB.SetActive (false);
						//	CameraEnd.SetActive (true);
						plihan1.SetActive (false);
						plihan2.SetActive (false);
						plihan3.SetActive (false);
						//EndOptionButton.SetActive (true);
						winner2.SetActive (true);
						losser.SetActive (false);
						scrollBar.SetActive (false);
						speedOption.SetActive (false);
						Time.timeScale = 1;
						SceneManagerHelper.LoadSoundFX("Win");


					} else {
						Debug.Log ("KALAH");
						PlayerPrefs.SetInt ("win", 0);
						urutan1 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
						urutan2 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
						urutan3 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
						urutan1 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
						urutan2 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
						urutan3 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
						karaBanimation.PlayQueued ("kalahend", QueueMode.PlayNow);
						cameraA.SetActive (false);
						cameraB.SetActive (false);
						plihan1.SetActive (false);
						plihan2.SetActive (false);
						plihan3.SetActive (false);
						EndOption[5].SetActive (true);
						losser.SetActive (true);
                        winner2.SetActive (false);
						scrollBar.SetActive (false);
						speedOption.SetActive (false);
						Time.timeScale = 1;
						SceneManagerHelper.LoadSoundFX("Lose");

					}


				} 
			}
		}
		//berburu
		else {
			hantugo1.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
			hantugo2.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
			hantugo3.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
			hantugom1.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
			hantugom2.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
			hantugom3.transform.Find ("COPY_POSITIONE").gameObject.SetActive (false);
			if (Bb) {

				Debug.Log ("MENANG");
				PlayerPrefs.SetInt ("win", 1);
				urutan1 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
				//					urutan2 [0].transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
				//					urutan3 [0].transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
				urutan1 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
				urutan2 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
				urutan3 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
				//winner3.transform.FindChild("KartuHantu").GetComponent<Image>().overrideSprite=Resources.Load<Sprite>("icon_char_Maps/" + PlayerPrefs.GetString (Link.POS_1_CHAR_1_FILE));
				karaBanimation.PlayQueued ("menanggame", QueueMode.PlayNow);
				cameraA.SetActive (false);
				cameraB.SetActive (false);
				//	CameraEnd.SetActive (true);
				plihan1.SetActive (false);
				plihan2.SetActive (false);
				plihan3.SetActive (false);
				//	EndOptionButton.SetActive (true);
				winner3.SetActive (true);
				losser.SetActive (false);
				scrollBar.SetActive (false);
				speedOption.SetActive (false);
				Time.timeScale = 1;
				SceneManagerHelper.LoadSoundFX("Win");


			} else {
				PlayerPrefs.SetInt ("win", 0);
				urutan1 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
				//					urutan2 [0].transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
				//					urutan3 [0].transform.FindChild ("COPY_POSITION").transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
				urutan1 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
				urutan2 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
				urutan3 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
				karaBanimation.PlayQueued ("kalahend", QueueMode.PlayNow);
				cameraA.SetActive (false);
				cameraB.SetActive (false);
				plihan1.SetActive (false);
				plihan2.SetActive (false);
				plihan3.SetActive (false);
				//	EndOptionButton.SetActive (true);
				losser2.SetActive (true);
				winner3.SetActive (false);
				scrollBar.SetActive (false);
				speedOption.SetActive (false);
				Time.timeScale = 1;
				SceneManagerHelper.LoadSoundFX("Lose");
				


			}


		} 



		if (ApakahCameraA) {
			CameraEndA.SetActive (true);
			canvasEnd ();
		} else {
			CameraEnd.SetActive (true);
			canvasEnd ();
		}

	}
	public void testeronly(){
		StartCoroutine (SendReward ());
	}

	public void ReallyStriking()
	{
	if(PlayerPrefs.GetString("PLAY_TUTORIAL")=="TRUE")
		{
		if(Strike_Ele==0)
		{
			Strike_Ele++;
			SceneManagerHelper.LoadTutorial("Game_2");
		}
	}
	}
	public void LoadTutorial(string game)
	{
		if(PlayerPrefs.GetString("PLAY_TUTORIAL")=="TRUE")
		{
		
	SceneManagerHelper.LoadTutorial(game);
		
	
	}
	if (PlayerPrefs.GetString (Link.JENIS) == "SINGLE") {
	Dialogue(false);
	}
	}

 


 
   
 
    void SetReward () {
        ItemRate = new int[3]; //number of things
        ItemName = new string[3];
		ItemType = new string[3];
		ItemQuantity = new string[3];
		ItemFileName = new string[3];
        //weighting of each thing, high number means more occurrance
        for(int i = 0; i<3;i++)
        {
			ItemFileName[i] = PlayerPrefs.GetString("RewardItemFN"+i.ToString());
			ItemQuantity[i] = PlayerPrefs.GetString("RewardItemQuantity"+i.ToString());
			ItemType[i] = PlayerPrefs.GetString("RewardItemType"+i.ToString());
            ItemName[i] = PlayerPrefs.GetString("RewardItemName"+i.ToString());
            ItemRate[i] = int.Parse(PlayerPrefs.GetString("RewardItemRate"+i.ToString()));
			
			
        }
        
        
        weightTotal = 0;
        foreach ( int w in ItemRate ) {
            weightTotal += w;
        }
    }
 
	public void getresult()
	{
		var result = RandomWeighted ();
	}
 
    int RandomWeighted () {
        int result = 0, total = 0;
        int randVal = Random.Range( 0, weightTotal );
        for ( result = 0; result < ItemRate.Length; result++ ) {
            total += ItemRate[result];
            if ( total > randVal ) break;
        }
		print(result);
        return result;
    }


}
