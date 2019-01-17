using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
public class Game1 : MonoBehaviour {
	public int MonsterLevel1,MonsterEXP1,MonsterGrade1,MonsterLevel2,MonsterEXP2,MonsterGrade2,MonsterLevel3,MonsterEXP3,MonsterGrade3;
	public float monstercurrentexp1,tempmonsterexp1,monstercurrentexp2,tempmonsterexp2,monstercurrentexp3,tempmonsterexp3;
	public float Targetnextlevel1, Targetnextlevel2, Targetnextlevel3;
	public string playerhantuid1,playerhantuid2,playerhantuid3;
	public Image[] Rewards;
	public Image[] DropRewards;
	public AudioClip[] ending;
	public AudioSource Audioplay;
	bool data_belum_ada = true;
	bool panggil_url = false;
	bool repeat = true;
	bool Ab = false;
	bool Bb = false;
	public GameObject waiting,CameraEnd,CameraEndA,EndOptionButton,ClaimUI;
	public TextMesh damageA, damageB;
	public float damage;
	public bool levelingmate;
	public WWWForm formkirimreward;
	public GameObject[] urutan1;
	public GameObject[] urutan2;
	public GameObject[] urutan3;
	public GameObject Aobject, Bobject;
	public GameObject canvas1,canvas2,canvas3,canvas4,canvas5,canvas6;
	public GameObject Monster1GO, Monster2GO, Monster3GO;
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


	float timer  = 10f;
	public bool timeUps = false;

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
	public AudioSource hitYa;

	//	int pos1_car1_int = 0;
	//	int pos1_car2_int = 0;
	//	int pos1_car3_int = 0;
	//
	//	int pos2_car1_int = 0;
	//	int pos2_car2_int = 0;
	//	int pos2_car3_int = 0;


	public GameObject healthA1,healthA2,healthA3,healthB1,healthB2,healthB3,firstTimerGame,CB;




	public Text User1, debug,ClaimText,EXPValueText;
	public Text User2;

	GameObject model1_1;
	GameObject model2_1;

	GameObject model1_2;
	GameObject model2_2;

	GameObject model1_3;
	GameObject model2_3;


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
	public GameObject hospital, school, warehouse,oldhouse,bridge,graveyard;

	//Tambah New Variabel untuk JOUSTING
	[Header("Diperlukan Untuk JOUSTING")]
	public GameObject envi;
	public GameObject CameraAR;
	public GameObject CameraTarget;
	public GameObject hospitalAR;

	private bool ApakahCameraA = false;

	public Text dg;

	void Awake(){
		SetReward();
		//PlayerPrefs.SetInt ("pos",2);
	}
	void Start () {
		CB.SetActive(false);
		#if UNITY_EDITOR
		CB.SetActive(true);
		#endif
		Debug.Log (PlayerPrefs.GetString ("PLAY_TUTORIAL"));
		//PlayerPrefs.SetString (Link.SEARCH_BATTLE, "JOUSTING");
		if (PlayerPrefs.GetString ("PLAY_TUTORIAL") == "TRUE") {
			firstTimerGame.gameObject.SetActive (true);
			Time.timeScale = 0;
		} else {
			firstTimerGame.gameObject.SetActive (false);}
		formkirimreward= new WWWForm ();
		PlayerPrefs.DeleteKey ("win");
		presentDone = false;

		//debug.text = PlayerPrefs.GetInt ("pos").ToString ();
		EndOptionButton.SetActive (false);
		Debug.Log (PlayerPrefs.GetString (Link.POS_1_CHAR_1_ATTACK));
		Debug.Log (PlayerPrefs.GetInt ("pos"));
		damageA.gameObject.SetActive (false);
		damageB.gameObject.SetActive (false);
		PlayerPrefs.SetInt ("Jumlah",0);

		if (PlayerPrefs.GetString (Link.JENIS) == "SINGLE") {
			Audioplay.clip = ending [1];
			Audioplay.Play ();
			monsterInfo ();
			EndOptionButton.transform.Find ("Replay").gameObject.SetActive (true);
			EndOptionButton.transform.Find ("Maps").gameObject.SetActive (true);
			EndOptionButton.transform.Find ("Arena").gameObject.SetActive (false);
			speedOption.SetActive (true);
		} else {
			Audioplay.clip = ending [0];
			Audioplay.Play ();
			EndOptionButton.transform.Find ("Arena").gameObject.SetActive (true);
			EndOptionButton.transform.Find ("Replay").gameObject.SetActive (false);
			EndOptionButton.transform.Find ("Maps").gameObject.SetActive (false);
			speedOption.SetActive (false);
            // perlu di cek
            // perlu di cek
            // perlu di cek
            //urutan1[1].transform.Find("Canvas2").gameObject.SetActive(false);
            //urutan2[1].transform.Find("Canvas2").gameObject.SetActive(false);
            //urutan3[1].transform.Find("Canvas2").gameObject.SetActive(false);

        }


		//TAMBAHAN DISINI
		if (PlayerPrefs.GetString (Link.SEARCH_BATTLE) == "SINGLE" && PlayerPrefs.GetString (Link.JENIS) == "SINGLE") {
			PlayerPrefs.SetString (Link.USER_1, "Musuh");
			PlayerPrefs.SetString (Link.USER_2, PlayerPrefs.GetString (Link.FULL_NAME));

		} else {

			//BIARKAN NAMA DARI MASING MASING PEMAIN.
		}


		if (PlayerPrefs.GetString (Link.SEARCH_BATTLE) == "JOUSTING") {
			this.gameObject.transform.SetParent (CameraTarget.transform);
			speedOption.SetActive (false);
			EndOptionButton.transform.Find ("Arena").gameObject.SetActive (true);
			EndOptionButton.transform.Find ("Replay").gameObject.SetActive (false);
			EndOptionButton.transform.Find ("Maps").gameObject.SetActive (false);
			CameraAR.SetActive (true);
			//hospitalAR.SetActive (true);
			envi.transform.SetParent (CameraTarget.transform);
		} 
		else {

			if (PlayerPrefs.GetString (Link.LOKASI) == "warehouse") {
				warehouse.SetActive (true);
			} else if (PlayerPrefs.GetString (Link.LOKASI) == "school") {
				school.SetActive (true);
			} else if (PlayerPrefs.GetString (Link.LOKASI) == "hospital") {
				hospital.SetActive (true);
			} else if (PlayerPrefs.GetString (Link.LOKASI) == "bridge") {
				bridge.SetActive (true);
			}else if (PlayerPrefs.GetString (Link.LOKASI) == "graveyard") {
				graveyard.SetActive (true);
			}
				else {
				oldhouse.SetActive (true);
			}
			if (PlayerPrefs.GetInt ("pos") == 1) {
				cameraA.SetActive (true);
				ApakahCameraA = true;
			} else {
				Debug.Log ("single player");
				cameraB.SetActive (true);
				ApakahCameraA = false;
			}
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



		model1_1 = Instantiate (Resources.Load ("PrefabsChar/" + PlayerPrefs.GetString (Link.POS_1_CHAR_1_FILE)) as GameObject,  new Vector3(0f,0f,0f), Quaternion.identity);
		model1_1.transform.SetParent (urutan1[0].transform);
		model1_1.transform.localPosition = urutan1 [0].transform.Find ("COPY_POSITION").transform.localPosition;
		model1_1.transform.localScale = urutan1 [0].transform.Find ("COPY_POSITION").transform.localScale;
		model1_1.transform.localEulerAngles = urutan1 [0].transform.Find ("COPY_POSITION").transform.localEulerAngles;
		model1_1.name = "Genderuwo_Fire";
		model1_1.transform.SetParent (urutan1 [0].transform.Find ("COPY_POSITION"));

		//LANGSUNG SY MASUKKAN ATT,HP,DEFENSE
		urutan1 [0].transform.Find("Canvas").transform.Find ("Image").GetComponent<filled> ().damage = float.Parse(PlayerPrefs.GetString(Link.POS_1_CHAR_1_ATTACK));
		urutan1 [0].transform.Find("Canvas").transform.Find ("Image").GetComponent<filled> ().defend = float.Parse(PlayerPrefs.GetString(Link.POS_1_CHAR_1_DEFENSE));
		urutan1 [0].transform.Find("Canvas").transform.Find ("Image").GetComponent<filled> ().maxhealth = float.Parse(PlayerPrefs.GetString(Link.POS_1_CHAR_1_HP));
		urutan1 [0].transform.Find("Canvas").transform.Find ("Image").GetComponent<filled> ().currenthealth = float.Parse(PlayerPrefs.GetString(Link.POS_1_CHAR_1_HP));
       
            //SERTA DATA LAIN, MUNGKIN AKAN DIPERLUKAN NANTI
            //PlayerPrefs.GetString(Link.POS_1_CHAR_1_GRADE);
            //PlayerPrefs.GetString(Link.POS_1_CHAR_1_LEVEL);



            model2_1 = Instantiate (Resources.Load ("PrefabsChar/" + PlayerPrefs.GetString (Link.POS_2_CHAR_1_FILE)) as GameObject,  new Vector3(0f,0f,0f), Quaternion.identity);
		model2_1.transform.SetParent (urutan1[1].transform);
		model2_1.transform.localPosition = urutan1 [1].transform.Find ("COPY_POSITION").transform.localPosition;
		model2_1.transform.localScale = urutan1 [1].transform.Find ("COPY_POSITION").transform.localScale;
		model2_1.transform.localEulerAngles = urutan1 [1].transform.Find ("COPY_POSITION").transform.localEulerAngles;
		model2_1.name = "Genderuwo_Fire";
		model2_1.transform.SetParent (urutan1 [1].transform.Find ("COPY_POSITION"));

		//LANGSUNG SY MASUKKAN ATT,HP,DEFENSE
		urutan1 [1].transform.Find("Canvas").transform.Find ("Image").GetComponent<filled> ().damage = float.Parse(PlayerPrefs.GetString(Link.POS_2_CHAR_1_ATTACK));
		urutan1 [1].transform.Find("Canvas").transform.Find ("Image").GetComponent<filled> ().defend = float.Parse(PlayerPrefs.GetString(Link.POS_2_CHAR_1_DEFENSE));
		urutan1 [1].transform.Find("Canvas").transform.Find ("Image").GetComponent<filled> ().maxhealth = float.Parse(PlayerPrefs.GetString(Link.POS_2_CHAR_1_HP));
		urutan1 [1].transform.Find("Canvas").transform.Find ("Image").GetComponent<filled> ().currenthealth = float.Parse(PlayerPrefs.GetString(Link.POS_2_CHAR_1_HP));
        //if (PlayerPrefs.GetString(Link.JENIS) == "SINGLE")
        //{
        //    urutan1[1].transform.Find("Canvas2").transform.FindChild("Image").GetComponent<filled>().damage = float.Parse(PlayerPrefs.GetString(Link.POS_2_CHAR_1_ATTACK));
        //    urutan1[1].transform.Find("Canvas2").transform.FindChild("Image").GetComponent<filled>().defend = float.Parse(PlayerPrefs.GetString(Link.POS_2_CHAR_1_DEFENSE));
        //    urutan1[1].transform.Find("Canvas2").transform.FindChild("Image").GetComponent<filled>().maxhealth = float.Parse(PlayerPrefs.GetString(Link.POS_2_CHAR_1_HP));
        //    urutan1[1].transform.Find("Canvas2").transform.FindChild("Image").GetComponent<filled>().currenthealth = float.Parse(PlayerPrefs.GetString(Link.POS_2_CHAR_1_HP));



        //}
        //SERTA DATA LAIN, MUNGKIN AKAN DIPERLUKAN NANTI
        //PlayerPrefs.GetString(Link.POS_2_CHAR_1_GRADE);
        //PlayerPrefs.GetString(Link.POS_2_CHAR_1_LEVEL);

        model1_2 = Instantiate (Resources.Load ("PrefabsChar/" + PlayerPrefs.GetString (Link.POS_1_CHAR_2_FILE)) as GameObject,  new Vector3(0f,0f,0f), Quaternion.identity);
		model1_2.transform.SetParent (urutan2[0].transform);
		model1_2.transform.localPosition = urutan2 [0].transform.Find ("COPY_POSITION").transform.localPosition;
		model1_2.transform.localScale = urutan2 [0].transform.Find ("COPY_POSITION").transform.localScale;
		model1_2.transform.localEulerAngles = urutan2 [0].transform.Find ("COPY_POSITION").transform.localEulerAngles;
		model1_2.name = "Genderuwo_Fire";
		model1_2.transform.SetParent (urutan2 [0].transform.Find ("COPY_POSITION"));

		//LANGSUNG SY MASUKKAN ATT,HP,DEFENSE
		urutan2 [0].transform.Find("Canvas").transform.Find ("Image").GetComponent<filled> ().damage = float.Parse(PlayerPrefs.GetString(Link.POS_1_CHAR_2_ATTACK));
		urutan2 [0].transform.Find("Canvas").transform.Find ("Image").GetComponent<filled> ().defend = float.Parse(PlayerPrefs.GetString(Link.POS_1_CHAR_2_DEFENSE));
		urutan2 [0].transform.Find("Canvas").transform.Find ("Image").GetComponent<filled> ().maxhealth = float.Parse(PlayerPrefs.GetString(Link.POS_1_CHAR_2_HP));
		urutan2 [0].transform.Find("Canvas").transform.Find ("Image").GetComponent<filled> ().currenthealth = float.Parse(PlayerPrefs.GetString(Link.POS_1_CHAR_2_HP));
		//SERTA DATA LAIN, MUNGKIN AKAN DIPERLUKAN NANTI
		//PlayerPrefs.GetString(Link.POS_1_CHAR_2_GRADE);
		//PlayerPrefs.GetString(Link.POS_1_CHAR_2_LEVEL);

		model2_2 = Instantiate (Resources.Load ("PrefabsChar/" + PlayerPrefs.GetString (Link.POS_2_CHAR_2_FILE)) as GameObject,  new Vector3(0f,0f,0f), Quaternion.identity);
		model2_2.transform.SetParent (urutan2[1].transform);
		model2_2.transform.localPosition = urutan2 [1].transform.Find ("COPY_POSITION").transform.localPosition;
		model2_2.transform.localScale = urutan2 [1].transform.Find ("COPY_POSITION").transform.localScale;
		model2_2.transform.localEulerAngles = urutan2 [1].transform.Find ("COPY_POSITION").transform.localEulerAngles;
		model2_2.name = "Genderuwo_Fire";
		model2_2.transform.SetParent (urutan2 [1].transform.Find ("COPY_POSITION"));

		//LANGSUNG SY MASUKKAN ATT,HP,DEFENSE
		urutan2 [1].transform.Find("Canvas").transform.Find ("Image").GetComponent<filled> ().damage = float.Parse(PlayerPrefs.GetString(Link.POS_2_CHAR_2_ATTACK));
		urutan2 [1].transform.Find("Canvas").transform.Find ("Image").GetComponent<filled> ().defend = float.Parse(PlayerPrefs.GetString(Link.POS_2_CHAR_2_DEFENSE));
		urutan2 [1].transform.Find("Canvas").transform.Find ("Image").GetComponent<filled> ().maxhealth = float.Parse(PlayerPrefs.GetString(Link.POS_2_CHAR_2_HP));
		urutan2 [1].transform.Find("Canvas").transform.Find ("Image").GetComponent<filled> ().currenthealth = float.Parse(PlayerPrefs.GetString(Link.POS_2_CHAR_2_HP));
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

        model1_3 = Instantiate (Resources.Load ("PrefabsChar/" + PlayerPrefs.GetString (Link.POS_1_CHAR_3_FILE)) as GameObject,  new Vector3(0f,0f,0f), Quaternion.identity);
		model1_3.transform.SetParent (urutan3[0].transform);
		model1_3.transform.localPosition = urutan3 [0].transform.Find ("COPY_POSITION").transform.localPosition;
		model1_3.transform.localScale = urutan3 [0].transform.Find ("COPY_POSITION").transform.localScale;
		model1_3.transform.localEulerAngles = urutan3 [0].transform.Find ("COPY_POSITION").transform.localEulerAngles;
		model1_3.name = "Genderuwo_Fire";
		model1_3.transform.SetParent (urutan3 [0].transform.Find ("COPY_POSITION"));

		//LANGSUNG SY MASUKKAN ATT,HP,DEFENSE
		urutan3 [0].transform.Find("Canvas").transform.Find ("Image").GetComponent<filled> ().damage = float.Parse(PlayerPrefs.GetString(Link.POS_1_CHAR_3_ATTACK));
		urutan3 [0].transform.Find("Canvas").transform.Find ("Image").GetComponent<filled> ().defend = float.Parse(PlayerPrefs.GetString(Link.POS_1_CHAR_3_DEFENSE));
		urutan3 [0].transform.Find("Canvas").transform.Find ("Image").GetComponent<filled> ().maxhealth = float.Parse(PlayerPrefs.GetString(Link.POS_1_CHAR_3_HP));
		urutan3 [0].transform.Find("Canvas").transform.Find ("Image").GetComponent<filled> ().currenthealth = float.Parse(PlayerPrefs.GetString(Link.POS_1_CHAR_3_HP));
		//SERTA DATA LAIN, MUNGKIN AKAN DIPERLUKAN NANTI
		//PlayerPrefs.GetString(Link.POS_1_CHAR_3_GRADE);
		//PlayerPrefs.GetString(Link.POS_1_CHAR_3_LEVEL);

		model2_3 = Instantiate (Resources.Load ("PrefabsChar/" + PlayerPrefs.GetString (Link.POS_2_CHAR_3_FILE)) as GameObject,  new Vector3(0f,0f,0f), Quaternion.identity);
		model2_3.transform.SetParent (urutan3[1].transform);
		model2_3.transform.localPosition = urutan3 [1].transform.Find ("COPY_POSITION").transform.localPosition;
		model2_3.transform.localScale = urutan3 [1].transform.Find ("COPY_POSITION").transform.localScale;
		model2_3.transform.localEulerAngles = urutan3 [1].transform.Find ("COPY_POSITION").transform.localEulerAngles;
		model2_3.name = "Genderuwo_Fire";
		model2_3.transform.SetParent (urutan3 [1].transform.Find ("COPY_POSITION"));

		//LANGSUNG SY MASUKKAN ATT,HP,DEFENSE
		urutan3 [1].transform.Find("Canvas").transform.Find ("Image").GetComponent<filled> ().damage = float.Parse(PlayerPrefs.GetString(Link.POS_2_CHAR_3_ATTACK));
		urutan3 [1].transform.Find("Canvas").transform.Find ("Image").GetComponent<filled> ().defend = float.Parse(PlayerPrefs.GetString(Link.POS_2_CHAR_3_DEFENSE));
		urutan3 [1].transform.Find("Canvas").transform.Find ("Image").GetComponent<filled> ().maxhealth = float.Parse(PlayerPrefs.GetString(Link.POS_2_CHAR_3_HP));
		urutan3 [1].transform.Find("Canvas").transform.Find ("Image").GetComponent<filled> ().currenthealth = float.Parse(PlayerPrefs.GetString(Link.POS_2_CHAR_3_HP));
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



        //ModelAllStatus (false);

        //PlayerPrefs.DeleteAll ();
        //ganti perbandingan nilai N apabila jumlah monster bertambah
        if (PlayerPrefs.GetInt ("pos") == 1) {

			User2.text = PlayerPrefs.GetString (Link.USER_1);
			User1.text = PlayerPrefs.GetString (Link.USER_2);

			icon1.sprite = Resources.Load<Sprite>("icon_char/" + PlayerPrefs.GetString(Link.POS_1_CHAR_1_FILE));
			icon2.sprite = Resources.Load<Sprite>("icon_char/" + PlayerPrefs.GetString(Link.POS_1_CHAR_2_FILE));
			icon3.sprite = Resources.Load<Sprite>("icon_char/" + PlayerPrefs.GetString(Link.POS_1_CHAR_3_FILE));


		} else {

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


		health1 [0] = healthA1.GetComponent<filled> ().maxhealth;
		health1 [1] = healthB1.GetComponent<filled> ().maxhealth;


		health2 [0] =  healthA2.GetComponent<filled> ().maxhealth;
		health2 [1] =  healthB2.GetComponent<filled> ().maxhealth;

		health3 [0] =  healthA3.GetComponent<filled> ().maxhealth;
		health3 [1] =  healthB3.GetComponent<filled> ().maxhealth;


		//SY TAMBAHIN JIKA SINGLE KE SINI
		if (PlayerPrefs.GetString (Link.JENIS) == "SINGLE") {

			if (PlayerPrefs.GetString ("PLAY_TUTORIAL") != "TRUE") {
				StartCoroutine (randomenemiesmovement ());
			} else {
			//	firstTimerTanding ();
			}
		}
		StartCoroutine (areuReady());

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
		Targetnextlevel1= float.Parse(PlayerPrefs.GetString (Link.CHAR_1_TARGETNL));

		monstercurrentexp2= float.Parse(PlayerPrefs.GetString (Link.CHAR_2_MONSTEREXP));
		Targetnextlevel2= float.Parse(PlayerPrefs.GetString (Link.CHAR_2_TARGETNL));

		monstercurrentexp3= float.Parse(PlayerPrefs.GetString (Link.CHAR_3_MONSTEREXP));
		Targetnextlevel3= float.Parse(PlayerPrefs.GetString (Link.CHAR_3_TARGETNL));

	}
	public IEnumerator areuReady () {

		yield return new WaitForSeconds (1);
		getReady.SetActive (true);
		yield return new WaitForSeconds (1f);
		getReady.SetActive (false);
		Nyala.SetActive (true);
		yield return new WaitForSeconds (.2f);
		//ModelAllStatus (true);
		yield return new WaitForSeconds (1);
		model1_1.GetComponent<Animation> ().Play ("select");
		model2_1.GetComponent<Animation> ().Play ("select");
		model1_2.GetComponent<Animation> ().Play ("select");
		model2_2.GetComponent<Animation> ().Play ("select");
		model1_3.GetComponent<Animation> ().Play ("select");
		model2_3.GetComponent<Animation> ().Play ("select");

		model1_1.GetComponent<Animation> ().PlayQueued ("idle");
		model2_1.GetComponent<Animation> ().PlayQueued ("idle");
		model1_2.GetComponent<Animation> ().PlayQueued ("idle");
		model2_2.GetComponent<Animation> ().PlayQueued ("idle");
		model1_3.GetComponent<Animation> ().PlayQueued ("idle");
		model2_3.GetComponent<Animation> ().PlayQueued ("idle");
		pilihanInputSuit [0].SetActive (true);
		pilihanInputSuit [1].SetActive (true);
		pilihanInputSuit [2].SetActive (true);

		yield return new WaitForSeconds (1);
		getReadyStatus = true;
	}
	void suitanimation(){


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
				if (suit2 [1] == "Charge") {
					suit1 [0] = "Focus";
					//	urutan1[0].GetComponent<>
				}	
				if (suit2 [1] == "Focus") {
					suit1 [0] = "Block";
				}	
				if (suit2 [1] == "Block") {
					suit1 [0] = "Charge";
				}	
			}
			if (urutan1 [1].gameObject.name == "Hantu3B") {
				if (suit3 [1] == "Charge") {
					suit1 [0] = "Focus";
					//	urutan1[0].GetComponent<>
				}	
				if (suit3 [1] == "Focus") {
					suit1 [0] = "Block";
				}	
				if (suit3 [1] == "Block") {
					suit1 [0] = "Charge";
				}	
			}


			//kondisi 2
			if (urutan2 [1].gameObject.name == "Hantu1B") {
				if (suit1 [1] == "Charge") {
					suit2 [0] = "Focus";
					//	urutan1[0].GetComponent<>
				}	
				if (suit1 [1] == "Focus") {
					suit2 [0] = "Block";
				}	
				if (suit1 [1] == "Block") {
					suit2 [0] = "Charge";
				}	
			}
			if (urutan2 [1].gameObject.name == "Hantu2B") {
				if (suit2 [1] == "Charge") {
					suit2 [0] = "Focus";
					//	urutan1[0].GetComponent<>
				}	
				if (suit2 [1] == "Focus") {
					suit2 [0] = "Block";
				}	
				if (suit2 [1] == "Block") {
					suit2 [0] = "Charge";
				}	
			}
			if (urutan2 [1].gameObject.name == "Hantu3B") {
				if (suit3 [1] == "Charge") {
					suit2 [0] = "Focus";
					//	urutan1[0].GetComponent<>
				}	
				if (suit3 [1] == "Focus") {
					suit2 [0] = "Block";
				}	
				if (suit3 [1] == "Block") {
					suit2 [0] = "Charge";
				}	
			}

			//kondisi 3

			if (urutan3 [1].gameObject.name == "Hantu1B") {
				if (suit1 [1] == "Charge") {
					suit3 [0] = "Focus";
					//	urutan1[0].GetComponent<>
				}	
				if (suit1 [1] == "Focus") {
					suit3 [0] = "Block";
				}	
				if (suit1 [1] == "Block") {
					suit3 [0] = "Charge";
				}	
			}
			if (urutan3 [1].gameObject.name == "Hantu2B") {
				if (suit2 [1] == "Charge") {
					suit3 [0] = "Focus";
					//	urutan1[0].GetComponent<>
				}	
				if (suit2 [1] == "Focus") {
					suit3 [0] = "Block";
				}	
				if (suit2 [1] == "Block") {
					suit3 [0] = "Charge";
				}	
			}
			if (urutan3 [1].gameObject.name == "Hantu3B") {
				if (suit3 [1] == "Charge") {
					suit3 [0] = "Focus";
					//	urutan1[0].GetComponent<>
				}	
				if (suit3 [1] == "Focus") {
					suit3 [0] = "Block";
				}	
				if (suit3 [1] == "Block") {
					suit3 [0] = "Charge";
				}	
			}
		//}
	
	}
	void Update () {
		
		//Debug.Log (Random.value);

		dg.text = PlayerPrefs.GetInt ("pos").ToString ();

		//Debug.Log (PlayerPrefs.GetString (Link.JENIS));
		//Debug.Log (PlayerPrefs.GetInt ("Jumlah"));
		//Debug.Log (panggil_url);
		//		Debug.Log (timeUps);

		if (PlayerPrefs.GetInt ("Jumlah") == 3) {

			if (PlayerPrefs.GetString (Link.JENIS) == "SINGLE") {

				//INI SAYA TARUH DISINI.

			}


			timeUps = true;
			if (panggil_url == false) {
				panggil_url = true;


				if (PlayerPrefs.GetString (Link.JENIS) == "SINGLE") {
                    


                    urutan1 [0] = GameObject.Find ("Hantu1A");
					urutan1 [1] = GameObject.Find (PlayerPrefs.GetString ("Urutan1"));


					healthBar1 [0] = urutan1 [0].transform.Find ("Canvas").transform.Find ("Image").gameObject;
					healthBar1 [1] = urutan1 [1].transform.Find ("Canvas").transform.Find ("Image").gameObject;


					//suit1 [0] = "Block";
					suit1 [1] = PlayerPrefs.GetString ("Suit1");


					urutan2 [0] = GameObject.Find ("Hantu2A");
					urutan2 [1] = GameObject.Find (PlayerPrefs.GetString ("Urutan2"));

					healthBar2 [0] = urutan2 [0].transform.Find ("Canvas").transform.Find ("Image").gameObject;
					healthBar2 [1] = urutan2 [1].transform.Find ("Canvas").transform.Find ("Image").gameObject;



					//suit2 [0] = "Charge";
					suit2 [1] = PlayerPrefs.GetString ("Suit2");

					urutan3 [0] = GameObject.Find ("Hantu3A");
					urutan3 [1] = GameObject.Find (PlayerPrefs.GetString ("Urutan3"));


					healthBar3 [0] = urutan3 [0].transform.Find ("Canvas").transform.Find ("Image").gameObject;
					healthBar3 [1] = urutan3 [1].transform.Find ("Canvas").transform.Find ("Image").gameObject;


					//suit3 [0] = "Focus";
					suit3 [1] = PlayerPrefs.GetString ("Suit3");




					waiting.SetActive (false);
					//information.SetActive (true);
					if (PlayerPrefs.GetString ("PLAY_TUTORIAL") == "TRUE") {
						firstTimerTanding ();
						StartCoroutine (urutanPlay());

					} 

					else {
						StartCoroutine (urutanPlay());
					}


				} 
				else {
					StartCoroutine (sendFormation());
				}


			}

		}

		if (getReadyStatus) {
			timer -= Time.deltaTime;
			scrollBar.transform.Find("Scrollbar").GetComponent<Scrollbar>().size = timer / 10;
		}




		if (timer  < 0 && timeUps == false) {
			timeUps = true;


			for (int i = 0; i < alpha.Count; i++) {
				string temp = alpha [0];
				int randomIndex = Random.Range (i, alpha.Count);
				alpha [i] = alpha [randomIndex];
				alpha [randomIndex] = temp;
			}

			StartCoroutine (randomPilihanInput());



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

			if (MonsterEXP1 >= Targetnextlevel1) {

				tempmonsterexp1 = monstercurrentexp1 - Targetnextlevel1;

				MonsterEXP1 = (int)tempmonsterexp1;
				monstercurrentexp1 = tempmonsterexp1;

				MonsterLevel1 += 1;
				MonsterEXP1 = (int)Mathf.MoveTowards (0, monstercurrentexp1, 10);
			}
			if (MonsterEXP2 >= Targetnextlevel2) {

				tempmonsterexp2 = monstercurrentexp2 - Targetnextlevel2;

				MonsterEXP2 = (int)tempmonsterexp2;
				monstercurrentexp2 = tempmonsterexp2;

				MonsterLevel2 += 1;
				MonsterEXP2 = (int)Mathf.MoveTowards (0, monstercurrentexp2, 10);
			}

			if (MonsterEXP3 >= Targetnextlevel3) {

				tempmonsterexp3 = monstercurrentexp3 - Targetnextlevel3;

				MonsterEXP3 = (int)tempmonsterexp3;
				monstercurrentexp3 = tempmonsterexp3;

				MonsterLevel3 += 1;
				MonsterEXP3 = (int)Mathf.MoveTowards (0, monstercurrentexp3, 10);
			}


			MonsterEXP1 = (int)Mathf.MoveTowards (MonsterEXP1, monstercurrentexp1, 10);
			MonsterEXP2 = (int)Mathf.MoveTowards (MonsterEXP2, monstercurrentexp2, 10);
			MonsterEXP3 = (int)Mathf.MoveTowards (MonsterEXP3, monstercurrentexp3, 10);
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

			} else {


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
				} else {
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

		if (PlayerPrefs.GetString (Link.JENIS) == "SINGLE"&& presentDone==false ) {

			if (PlayerPrefs.GetInt ("win") == 1) {
				WinnerPresent ();
				Audioplay.clip = ending [2];
				Audioplay.Play ();
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
				//Audioplay.clip = ending [3];
				//Audioplay.Play ();
			}
		}

		//done 

	}
	void monsterleveling(){
		if (MonsterGrade1 == 1) {
			if (MonsterLevel1 >= 15) {
				//do nothing
				Targetnextlevel1=999999;
			} else {
				StartCoroutine(sendEXP1(playerhantuid1,PlayerPrefs.GetInt ("MAPSEXP")));
			}
		}
		 if (MonsterGrade1 == 2) {
			if (MonsterLevel1 >= 20) {
				Targetnextlevel1=999999;
				//do nothing
			} else {
				StartCoroutine(sendEXP1(playerhantuid1,PlayerPrefs.GetInt ("MAPSEXP")));
			}
		}
		 if (MonsterGrade1 == 3) {
			if (MonsterLevel1 >= 25) {
				Targetnextlevel1=999999;
				//do nothing
			} else {
				StartCoroutine(sendEXP1(playerhantuid1,PlayerPrefs.GetInt ("MAPSEXP")));
			}
		}
		 if (MonsterGrade1 == 4) {
			if (MonsterLevel1 >= 30) {
				Targetnextlevel1=999999;
				//do nothing
			} else {
				StartCoroutine(sendEXP1(playerhantuid1,PlayerPrefs.GetInt ("MAPSEXP")));
			}
		}
		 if (MonsterGrade1 == 5) {
			if (MonsterLevel1 >= 35) {
				Targetnextlevel1=999999;
				//do nothing
			} else {
				StartCoroutine(sendEXP1(playerhantuid1,PlayerPrefs.GetInt ("MAPSEXP")));
			}
		}
		 if (MonsterGrade1 == 6) {
			if (MonsterLevel1 >= 40) {
				Targetnextlevel1=999999;
				//do nothing
			} else {
				StartCoroutine(sendEXP1(playerhantuid1,PlayerPrefs.GetInt ("MAPSEXP")));
			}
		}

	}
	void monsterleveling2(){
		
		 if (MonsterGrade2 == 1) {
			if (MonsterLevel2 >= 15) {
				Targetnextlevel2=999999;
				//do nothing
			} else {
				StartCoroutine(sendEXP2(playerhantuid2,PlayerPrefs.GetInt ("MAPSEXP")));
			}
		}
		if (MonsterGrade2 == 2) {
			if (MonsterLevel2 >= 20) {
				Targetnextlevel2=999999;
				//do nothing
			} else {
				StartCoroutine(sendEXP2(playerhantuid2,PlayerPrefs.GetInt ("MAPSEXP")));
			}
		}
		 if (MonsterGrade2 == 3) {
			if (MonsterLevel2 >= 25) {
				Targetnextlevel2=999999;
				//do nothing
			} else {
				StartCoroutine(sendEXP2(playerhantuid2,PlayerPrefs.GetInt ("MAPSEXP")));
			}
		}
		if (MonsterGrade2 == 4) {
			if (MonsterLevel2 >= 30) {
				Targetnextlevel2=999999;
				//do nothing
			} else {
				StartCoroutine(sendEXP2(playerhantuid2,PlayerPrefs.GetInt ("MAPSEXP")));
			}
		}
		if (MonsterGrade2 == 5) {
			if (MonsterLevel2 >= 35) {
				Targetnextlevel2=999999;
				//do nothing
			} else {
				StartCoroutine(sendEXP2(playerhantuid2,PlayerPrefs.GetInt ("MAPSEXP")));
			}
		}
		if (MonsterGrade2 == 6) {
			if (MonsterLevel2 >= 40) {
				Targetnextlevel2=999999;
				//do nothing
			} else {
				StartCoroutine(sendEXP2(playerhantuid2,PlayerPrefs.GetInt ("MAPSEXP")));
			}
		}

	}
	void monsterleveling3(){
		
		if (MonsterGrade3 == 1) {
			if (MonsterLevel3 >= 15) {
				Targetnextlevel3=999999;
				//do nothing
			} else {
				StartCoroutine(sendEXP3(playerhantuid3,PlayerPrefs.GetInt ("MAPSEXP")));
			}
		}
		if (MonsterGrade3 == 2) {
			if (MonsterLevel3 >= 20) {
				Targetnextlevel3=999999;
				//do nothing
			} else {
				StartCoroutine(sendEXP3(playerhantuid3,PlayerPrefs.GetInt ("MAPSEXP")));
			}
		}
		if (MonsterGrade3 == 3) {
			if (MonsterLevel3 >= 25) {
				Targetnextlevel3=999999;
				//do nothing
			} else {
				StartCoroutine(sendEXP3(playerhantuid3,PlayerPrefs.GetInt ("MAPSEXP")));
			}
		}
		if (MonsterGrade3 == 4) {
			if (MonsterLevel3 >= 30) {
				Targetnextlevel3=999999;
				//do nothing
			} else {
				StartCoroutine(sendEXP3(playerhantuid3,PlayerPrefs.GetInt ("MAPSEXP")));
			}
		}
		if (MonsterGrade3 == 5) {
			if (MonsterLevel3 >= 35) {
				Targetnextlevel3=999999;
				//do nothing
			} else {
				StartCoroutine(sendEXP3(playerhantuid3,PlayerPrefs.GetInt ("MAPSEXP")));
			}
		}
		if (MonsterGrade3 == 6) {
			if (MonsterLevel3 >= 40) {
				Targetnextlevel3=999999;
				//do nothing
			} else {
				StartCoroutine(sendEXP3(playerhantuid3,PlayerPrefs.GetInt ("MAPSEXP")));
			}

		}
	}
	public void levelingbro(){
		levelingmate = true;
	}
	void WinnerPresent(){
		
		//DistribusiEXPMonsterItem (playerhantuid1, playerhantuid2, playerhantuid3, "somthing", "somthing", "somthing", "somthing", "somthing", "somthing", "somthing", "somthing", "somthing", "somthing", "somthing", "somthing", int.Parse (EXPValueText.text));
//		StartCoroutine(sendEXP1(playerhantuid1,PlayerPrefs.GetInt ("MAPSEXP")));
//		StartCoroutine(sendEXP2(playerhantuid2,PlayerPrefs.GetInt ("MAPSEXP")));
//		StartCoroutine(sendEXP3(playerhantuid3,PlayerPrefs.GetInt ("MAPSEXP")));


		// float.Parse(EXPValueText.text);
		//monstercurrentexp2 += Exp;
		//monstercurrentexp3 += Exp;
		var presentcode = RandomWeighted();
		var winning = Random.value;
		formkirimreward.AddField ("GOLD", 100);
		EXPValueText.text = "100";
		var presentType = PlayerPrefs.GetString("RewardItemType"+presentcode.ToString());
		var presentQuantity = PlayerPrefs.GetString("RewardItemQuantity"+presentcode.ToString());
		var presentName = PlayerPrefs.GetString("RewardItemName"+presentcode.ToString());
		if(presentType=="Item")
		{
			formkirimreward.AddField(presentName,presentQuantity);
			ClaimText.text = presentQuantity + presentName;
		}
		
		// if (winning > 0.25f) {
		// 	Debug.Log ("dapet coin / sampah");
		// 	var hadiah = Random.Range (1000, 1400);
		// 	Debug.Log (hadiah);
		// 	formkirimreward.AddField ("GOLD", hadiah);
		// 	ClaimText.text = hadiah.ToString()+"X";
		// 	EXPValueText.text = hadiah.ToString()+"X";
		// 	StartCoroutine (SendReward ());
		// 	Rewards [7].gameObject.SetActive (true);
		// }
		// else if (winning < 0.25f && Random.value > 0.1f) {
		// 	Debug.Log ("dapet hadiah lumayan lah");
		// 	var value = Random.Range (0, equipmentreward.Length);
		// 	if (value == 0) {
		// 		Rewards [6].gameObject.SetActive (true);

		// 	}
		// 	if (value == 1) {

		// 		Rewards [3].gameObject.SetActive (true);
		// 	}
		// 	if (value == 2) {
				
		// 		Rewards [5].gameObject.SetActive (true);
		// 	}
		// 	if (value == 3) {
				
		// 		Rewards [4].gameObject.SetActive (true);
		// 	}
		// 	var hadiah = equipmentreward [value];
		// 	formkirimreward.AddField ("ITEM", hadiah);
		// 	ClaimText.text = 1.ToString()+"X";
		// 	StartCoroutine (SendReward ());
		// 	Debug.Log (hadiah);
		// }
		// else if (winning < 0.05f) {
		// 	Debug.Log ("dapet door price");
		// 	var randomagain = Random.value;

		// 	if (randomagain < 0.85f) {
		// 		nilai = 0;
		// 		Rewards [2].gameObject.SetActive (true);
		// 	} 
		// 	else if (randomagain > 0.85f && randomagain < 0.95) {
		// 		nilai = 1;
		// 		Rewards [1].gameObject.SetActive (true);
		// 	} 
		// 	else if (randomagain > 0.95) {
				
		// 		nilai = 2;
		// 		Rewards [0].gameObject.SetActive (true);
		// 	}
		// 	ClaimText.text = 1.ToString()+"X";
		// 	var hadiah = itemsreward [nilai];
		// 	Debug.Log (hadiah);
		// 	formkirimreward.AddField (hadiah, 1);
			StartCoroutine (SendReward ());
			//StartCoroutine (sendEXP (idhantuplayer, 1000));
		// }
		ClaimUI.SetActive (true);
		presentDone = true;


	}

	IEnumerator SendReward(){
		

		var expsingle = PlayerPrefs.GetInt ("MAPSEXP") * 3;
		Debug.Log (expsingle);
			string url = Link.url + "update_data_user";
			//WWWForm form = new WWWForm ();
		formkirimreward.AddField ("JumlahXpTransfer", (expsingle));
		formkirimreward.AddField ("MY_ID", PlayerPrefs.GetString(Link.ID));
		//formkirimreward.AddField ("ITEM", equipmentreward[0]);
		WWW www = new WWW(url,formkirimreward);
			yield return www;
			if (www.error == null) {
			monsterleveling();
			} 
		Debug.Log (www.text);
	//	var jsonString = JSON.Parse (www.text);
		//PlayerPrefs.SetString ("BATU", jsonString ["data"]);


		
	}
	private IEnumerator sendEXP1(string hantuplayerid, int Exp)
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
			PlayerPrefs.SetFloat("target1", float.Parse(jsonString ["code"] ["Targetnextlevel"]));
			monstercurrentexp1 += Exp;
			Debug.Log (www.text);
			monsterleveling2();


		} else {
			Debug.Log ("Failed kirim data");
			yield return new WaitForSeconds (5);


		}
	}
		private IEnumerator sendEXP2(string hantuplayerid, int Exp)
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
				PlayerPrefs.SetFloat("target2", float.Parse(jsonString ["code"] ["Targetnextlevel"]));
				monstercurrentexp2 += Exp;
			monsterleveling3();

			} else {
				Debug.Log ("Failed kirim data");
				yield return new WaitForSeconds (5);


			}
	}
			private IEnumerator sendEXP3(string hantuplayerid, int Exp)
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
					PlayerPrefs.SetFloat("target3", float.Parse(jsonString ["code"] ["Targetnextlevel"]));
					monstercurrentexp3 += Exp;
				

				} else {
					Debug.Log ("Failed kirim data");
					yield return new WaitForSeconds (5);
				

				}
	}
	//tambah exp habis game single player
	IEnumerator DistribusiEXPMonsterItem(string hantuplayerid1,string hantuplayerid2,string hantuplayerid3,string hantuplayerid1item1,string hantuplayerid1item2,string hantuplayerid1item3,string hantuplayerid1item4,string hantuplayerid2item1,string hantuplayerid2item2,string hantuplayerid2item3,string hantuplayerid2item4,string hantuplayerid3item1,string hantuplayerid3item2,string hantuplayerid3item3,string hantuplayerid3item4, int Exp){

		Debug.Log ("TES");
		string url = Link.url + "send_xp";
		WWWForm form = new WWWForm ();
		form.AddField ("MY_ID", PlayerPrefs.GetString(Link.ID));
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
	IEnumerator randomenemiesmovement(){
		int j = Random.Range (0, 3);
		int k = Random.Range (0, 3);
		int l = Random.Range (0, 3);

		if (j==0) {
			suit1[0]="Charge";
		}
		if (j==1) {
			suit1[0]="Block";
		}
		if (j==2) {
			suit1[0]="Focus";
		}
		yield return new WaitForSeconds(1);
		if (k==0) {
			suit2[0]="Charge";
		}
		if (k==1) {
			suit2[0]="Block";
		}
		if (k==2) {
			suit2[0]="Focus";
		}
		yield return new WaitForSeconds(1);

		if (l==0) {
			suit3[0]="Charge";
		}
		if (l==1) {
			suit3[0]="Block";
		}
		if (l==2) {
			suit3[0]="Focus";
		}


	}
	IEnumerator randomPilihanInput(){
		int j = Random.Range (0, 3);

		if (j == 0) {
			if (pilihanInputSuit [0].activeSelf) {
				pilihanInputSuit [0].GetComponent<RandomClick> ().RandomPilih ();
			}
			yield return new WaitForSeconds(1);
			if (pilihanInputSuit [1].activeSelf) {
				pilihanInputSuit [1].GetComponent<RandomClick> ().RandomPilih ();
			}
			yield return new WaitForSeconds(1);

			if (pilihanInputSuit [2].activeSelf) {
				pilihanInputSuit [2].GetComponent<RandomClick> ().RandomPilih ();
			}
			if (PlayerPrefs.GetString ("PLAY_TUTORIAL") == "TRUE") {
				firstTimerTanding ();
				//StartCoroutine (urutanPlay());

			} 
		}

		else if (j == 1) {
			if (pilihanInputSuit [0].activeSelf) {
				pilihanInputSuit [0].GetComponent<RandomClick> ().RandomPilih ();
			}
			yield return new WaitForSeconds(1);
			if (pilihanInputSuit [2].activeSelf) {
				pilihanInputSuit [2].GetComponent<RandomClick> ().RandomPilih ();
			}
			yield return new WaitForSeconds(1);

			if (pilihanInputSuit [1].activeSelf) {
				pilihanInputSuit [1].GetComponent<RandomClick> ().RandomPilih ();
			}if (PlayerPrefs.GetString ("PLAY_TUTORIAL") == "TRUE") {
				firstTimerTanding ();
				//StartCoroutine (urutanPlay());

			} 
		}

		else if (j == 2) {


			if (pilihanInputSuit [2].activeSelf) {
				pilihanInputSuit [2].GetComponent<RandomClick> ().RandomPilih ();
			}
			yield return new WaitForSeconds(1);
			if (pilihanInputSuit [0].activeSelf) {
				pilihanInputSuit [0].GetComponent<RandomClick> ().RandomPilih ();
			}
			yield return new WaitForSeconds(1);
			if (pilihanInputSuit [1].activeSelf) {
				pilihanInputSuit [1].GetComponent<RandomClick> ().RandomPilih ();
			}if (PlayerPrefs.GetString ("PLAY_TUTORIAL") == "TRUE") {
				firstTimerTanding ();
				//StartCoroutine (urutanPlay());

			} 
		}

		else if (j == 3) {


			if (pilihanInputSuit [2].activeSelf) {
				pilihanInputSuit [2].GetComponent<RandomClick> ().RandomPilih ();
			}
			yield return new WaitForSeconds(1);
			if (pilihanInputSuit [1].activeSelf) {
				pilihanInputSuit [1].GetComponent<RandomClick> ().RandomPilih ();
			}

			yield return new WaitForSeconds(1);
			if (pilihanInputSuit [0].activeSelf) {
				pilihanInputSuit [0].GetComponent<RandomClick> ().RandomPilih ();
			}if (PlayerPrefs.GetString ("PLAY_TUTORIAL") == "TRUE") {
				firstTimerTanding ();
				//StartCoroutine (urutanPlay());

			} 


		}

	}


	private IEnumerator sendFormation()
	{
		ImDoneForSendBool = true;
		StartCoroutine (ImDoneForSend ());
		Debug.Log ("send prrogress");

		string url = Link.url + "send_formation";
		WWWForm form = new WWWForm ();
		form.AddField (Link.ID, PlayerPrefs.GetString(Link.ID));
		form.AddField ("pos", PlayerPrefs.GetInt("pos").ToString());

		form.AddField ("urutan_1", PlayerPrefs.GetString("Urutan1"));
		form.AddField ("suit_1", PlayerPrefs.GetString("Suit1"));

		form.AddField ("urutan_2", PlayerPrefs.GetString("Urutan2"));
		form.AddField ("suit_2", PlayerPrefs.GetString("Suit2"));

		form.AddField ("urutan_3", PlayerPrefs.GetString("Urutan3"));
		form.AddField ("suit_3", PlayerPrefs.GetString("Suit3"));

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
		Application.LoadLevel ("Home");
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
		Application.LoadLevel ("Home");
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
			form.AddField (Link.ID, PlayerPrefs.GetString(Link.ID));
			form.AddField ("room_name", PlayerPrefs.GetString ("RoomName"));


			WWW www = new WWW(url,form);
			yield return www;
			if (www.error == null) {

				var jsonString = JSON.Parse (www.text);
				int a = 0;
				int c = 0;

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


					urutan2 [0] = GameObject.Find (jsonString ["data"] [0] ["urutan_2"]);
					urutan2 [1] = GameObject.Find (jsonString ["data"] [1] ["urutan_2"]);

					healthBar2 [0] = urutan2 [0].transform.Find ("Canvas").transform.Find ("Image").gameObject;
					healthBar2 [1] = urutan2 [1].transform.Find ("Canvas").transform.Find ("Image").gameObject;



					suit2 [0] = jsonString ["data"] [0] ["suit_2"];
					suit2 [1] = jsonString ["data"] [1] ["suit_2"];

					urutan3 [0] = GameObject.Find (jsonString ["data"] [0] ["urutan_3"]);
					urutan3 [1] = GameObject.Find (jsonString ["data"] [1] ["urutan_3"]);


					healthBar3 [0] = urutan3 [0].transform.Find ("Canvas").transform.Find ("Image").gameObject;
					healthBar3 [1] = urutan3 [1].transform.Find ("Canvas").transform.Find ("Image").gameObject;


					suit3 [0] = jsonString ["data"] [0] ["suit_3"];
					suit3 [1] = jsonString ["data"] [1] ["suit_3"];




					waiting.SetActive (false);
					//information.SetActive (true);


					StartCoroutine (urutanPlay());








				} else {
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







	IEnumerator urutanPlay(){

		scrollBar.SetActive (false);
		cameraB.GetComponent<Animator> ().SetBool ("Fighting", true);
		cameraA.GetComponent<Animator> ().SetBool ("Fighting", true);
		yield return new WaitForSeconds(1f);
		vs.SetActive (true);

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


		StartCoroutine (War(urutan1[0],urutan1[1],suit1[0],suit1[1],1));
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
        yield return new WaitForSeconds(5f);
		cameraB.GetComponent<Animator> ().SetBool ("Fighting", true);
		cameraA.GetComponent<Animator> ().SetBool ("Fighting", true);
		Aobject.GetComponent<Animator> ().SetBool ("LeftFight", true);
		Bobject.GetComponent<Animator> ().SetBool ("RightFight", true);
		//		Aaobject.GetComponent<Animator> ().SetBool ("LeftFight", true);
		//		Baobject.GetComponent<Animator> ().SetBool ("RightFight", true);

		if (suit2 [0] == "Charge") {
			Aobject.GetComponent<Animator> ().SetBool ("FightCharge", true);
		}
		if (suit2 [0] == "Focus") {
			Aobject.GetComponent<Animator> ().SetBool ("FightFocus", true);
		}
		if (suit2 [0] == "Block") {
			Aobject.GetComponent<Animator> ().SetBool ("FightBlock", true);
		}
		if (suit2 [1] == "Charge") {
			Bobject.GetComponent<Animator> ().SetBool ("FightCharge", true);
		}
		if (suit2 [1] == "Focus") {
			Bobject.GetComponent<Animator> ().SetBool ("FightFocus", true);
		}
		if (suit2 [1] == "Block") {
			Bobject.GetComponent<Animator> ().SetBool ("FightBlock", true);
		}


		StartCoroutine (War(urutan2[0],urutan2[1],suit2[0],suit2[1],2));

		yield return new WaitForSeconds(5.3f);
		cameraB.GetComponent<Animator> ().SetBool ("Fighting", true);
		cameraA.GetComponent<Animator> ().SetBool ("Fighting", true);
		Aobject.GetComponent<Animator> ().SetBool ("LeftFight", true);
		Bobject.GetComponent<Animator> ().SetBool ("RightFight", true);

		//		Aaobject.GetComponent<Animator> ().SetBool ("LeftFight", true);
		//		Baobject.GetComponent<Animator> ().SetBool ("RightFight", true);


		if (suit3 [0] == "Charge") {
			Aobject.GetComponent<Animator> ().SetBool ("FightCharge", true);
		}
		if (suit3 [0] == "Focus") {
			Aobject.GetComponent<Animator> ().SetBool ("FightFocus", true);
		}
		if (suit3 [0] == "Block") {
			Aobject.GetComponent<Animator> ().SetBool ("FightBlock", true);
		}
		if (suit3 [1] == "Charge") {
			Bobject.GetComponent<Animator> ().SetBool ("FightCharge", true);
		}
		if (suit3 [1] == "Focus") {
			Bobject.GetComponent<Animator> ().SetBool ("FightFocus", true);
		}
		if (suit3 [1] == "Block") {
			Bobject.GetComponent<Animator> ().SetBool ("FightBlock", true);
		}



		StartCoroutine (War(urutan3[0],urutan3[1],suit3[0],suit3[1],3));

		yield return new WaitForSeconds(4);
		cameraB.GetComponent<Animator> ().SetBool ("Fighting", false);
		cameraA.GetComponent<Animator> ().SetBool ("Fighting", false);
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
		vs.SetActive (false);
		if (repeat) {

			Debug.Log ("Repeat");
			if (PlayerPrefs.GetString ("PLAY_TUTORIAL") != "TRUE") {
				StartCoroutine (randomenemiesmovement ());
			} else {
				firstTimerTanding ();
			}
			if (PlayerPrefs.GetString (Link.JENIS) == "SINGLE") {
				timer = 10f;
				timeUps = false;
				panggil_url = false;
				data_belum_ada = true;
				PlayerPrefs.SetInt ("Jumlah", 0);

				//	PlayerPrefs.SetString ("id_device","2");
				//			PlayerPrefs.SetString ("pos","2");
				PlayerPrefs.SetString ("RoomName", "SINGLE");


				plihan1.SetActive (true);
				plihan2.SetActive (true);
				plihan3.SetActive (true);
                if (PlayerPrefs.GetString(Link.JENIS) == "SINGLE")
                {
                    healthBar1[1].SetActive(true);
                    healthBar2[1].SetActive(true);
                    healthBar3[1].SetActive(true);
                }
            } else {
				StartCoroutine (resetFormation());
			}



		} 
		else {
			resetDatabaseYo = true;
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
						cameraA.SetActive (false);
						cameraB.SetActive (false);
						plihan1.SetActive (false);
						plihan2.SetActive (false);
						plihan3.SetActive (false);
					//	EndOptionButton.SetActive (true);
						losser.SetActive (true);
						winner.SetActive (false);
						scrollBar.SetActive (false);
						speedOption.SetActive (false);
						Time.timeScale = 1;
                        Audioplay.loop = false;
                        Audioplay.clip = ending [3];
						Audioplay.Play ();

					} else {
						Debug.Log ("MENANG");
						PlayerPrefs.SetInt ("win", 1);
						urutan1 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
						urutan2 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
						urutan3 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
						urutan1 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
						urutan2 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
						urutan3 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
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
                        Audioplay.loop = false;
                        Audioplay.clip = ending [2];
						Audioplay.Play ();

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
						cameraA.SetActive (false);
						cameraB.SetActive (false);
						plihan1.SetActive (false);
						plihan2.SetActive (false);
						plihan3.SetActive (false);
					//	EndOptionButton.SetActive (true);
						losser.SetActive (true);
						winner2.SetActive (false);
						scrollBar.SetActive (false);
						speedOption.SetActive (false);
						Time.timeScale = 1;
                        Audioplay.loop = false;
                        Audioplay.clip = ending [3];
						Audioplay.Play ();


					} else {
						Debug.Log ("MENANG");
						PlayerPrefs.SetInt ("win", 1);
						urutan1 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
						urutan2 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
						urutan3 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
						urutan1 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
						urutan2 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
						urutan3 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
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
                        Audioplay.loop = false;
                        Audioplay.clip = ending [2];
						Audioplay.Play ();

					}


				} 
			} 

			else 
//kondisi A menang
			{
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
                        Audioplay.loop = false;
                        Audioplay.clip = ending [2];
						Audioplay.Play ();


					} else {
						Debug.Log ("KALAH");
						PlayerPrefs.SetInt ("win", 0);
						urutan1 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
						urutan2 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
						urutan3 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
						urutan1 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
						urutan2 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
						urutan3 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
						cameraA.SetActive (false);
						cameraB.SetActive (false);
						plihan1.SetActive (false);
						plihan2.SetActive (false);
						plihan3.SetActive (false);
					//	EndOptionButton.SetActive (true);
						losser.SetActive (true);
						winner2.SetActive (false);
						scrollBar.SetActive (false);
						speedOption.SetActive (false);
						Time.timeScale = 1;
                        Audioplay.loop = false;
                        Audioplay.clip = ending [3];
						Audioplay.Play ();

					}


				} else 
				//multiplayer
				{
					if (ApakahCameraA) {
						Debug.Log ("MENANG");
						PlayerPrefs.SetInt ("win", 1);
						urutan1 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
						urutan2 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
						urutan3 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
						urutan1 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
						urutan2 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
						urutan3 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
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
                        Audioplay.loop = false;
                        Audioplay.clip = ending [2];
						Audioplay.Play ();


					} else {
						Debug.Log ("KALAH");
						PlayerPrefs.SetInt ("win", 0);
						urutan1 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
						urutan2 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
						urutan3 [0].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("menang", QueueMode.PlayNow);
						urutan1 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
						urutan2 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
						urutan3 [1].transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("kalah", QueueMode.PlayNow);
						cameraA.SetActive (false);
						cameraB.SetActive (false);
						plihan1.SetActive (false);
						plihan2.SetActive (false);
						plihan3.SetActive (false);
					//	EndOptionButton.SetActive (true);
						losser.SetActive (true);
						winner2.SetActive (false);
						scrollBar.SetActive (false);
						speedOption.SetActive (false);
						Time.timeScale = 1;
                        Audioplay.loop = false;
                        Audioplay.clip = ending [3];
                        
						Audioplay.Play ();
				
					}


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



	IEnumerator GoEND () {
		yield return new WaitForSeconds (1);
		Application.LoadLevel ("End");
	}


	public GameObject winner, winner2;
	public GameObject losser;


	private IEnumerator resetFormation()
	{
		Debug.Log ("RESET !!");
		string url = Link.url + "reset_formation";
		WWWForm form = new WWWForm ();
		form.AddField (Link.ID, PlayerPrefs.GetString(Link.ID));
		form.AddField ("room_name", PlayerPrefs.GetString ("RoomName"));
		WWW www = new WWW(url,form);
		yield return www;
		if (www.error == null) {



			timer = 10f;
			timeUps = false;
			panggil_url = false;
			data_belum_ada = true;
			PlayerPrefs.SetInt ("Jumlah", 0);


			plihan1.SetActive (true);
			plihan2.SetActive (true);
			plihan3.SetActive (true);
		}
	}

	bool resetDatabaseYo = false;

	public void ResetDatabase () {
		Application.LoadLevel ("MainMenu");
	}

	private IEnumerator resetDatabase()
	{
		waiting.SetActive (false);
		string url = Link.url + "reset_database";
		WWWForm form = new WWWForm ();
		form.AddField (Link.ID, PlayerPrefs.GetString(Link.ID));
		WWW www = new WWW(url,form);
		yield return www;
		if (www.error == null) {
			Application.LoadLevel ("MainMenu");
		}
	}

	public void PlaySajaLah(int i) {
		if (i==1) {
			StartCoroutine (War(GameObject.Find("Hantu1A"),GameObject.Find("Hantu2B"),"Charge","Block",1));
		}
		else if  (i==2) {
			StartCoroutine (War(GameObject.Find("Hantu2A"),GameObject.Find("Hantu3B"),"Block","Focus",1));
		}
		else if  (i==3) {
			StartCoroutine (War(GameObject.Find("Hantu2A"),GameObject.Find("Hantu3B"),"Charge","Focus",1));
		}
		else if  (i==4) {
			StartCoroutine (War(GameObject.Find("Hantu2A"),GameObject.Find("Hantu3B"),"Charge","Charge",1));
		}

	}

	IEnumerator War (GameObject aObject, GameObject bObject, string pilA, string pilB, int urutan) {

		Debug.Log (pilA + "   " + pilB);
		dg.text = (pilA + "   " + pilB);

		aObject.GetComponent<PlayAnimation> ().PlayMaju ();
		bObject.GetComponent<PlayAnimation> ().PlayMaju ();


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




		yield return new WaitForSeconds (1.3f);

		if (pilA == "Charge" && pilB == "Block") {
			damage = bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage- (aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend/2);
			if (damage <= 0) {
				damage = 0;
			}damageA.text = "- "+damage.ToString ();
			damageB.text = "- "+damage.ToString ();
			Bobject.GetComponent<Animator> ().SetBool ("win", true);
			Aobject.GetComponent<Animator> ().SetBool ("chargekalah", true);
			Debug.Log ("CB");
			//aObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("maju");
			//bObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("maju");
			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("attack",QueueMode.PlayNow);

			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("nangkis",QueueMode.PlayNow);

			yield return new WaitForSeconds (0.5f);
			Seri_Bdef.Play ();

			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle",QueueMode.PlayNow,PlayMode.StopAll);

			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("attack",QueueMode.PlayNow);
			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("hit",QueueMode.PlayNow);
			yield return new WaitForSeconds (.5f);
			damageA.gameObject.SetActive (true);
			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			yield return new WaitForSeconds (0.3f);
			HealthReduction (urutan,0,damage);
			A.Play ();
			hitYa.Play ();


		}
		else if (pilA == "Block" && pilB == "Charge") {
			Debug.Log ("BC");
			yield return new WaitForSeconds (0.5f);
			damage = aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage- bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend/2;
			if (damage <= 0) {
				damage = 0;
			}damageA.text = "- "+damage.ToString ();
			damageB.text = "- "+damage.ToString ();
			Aobject.GetComponent<Animator> ().SetBool ("win", true);
			Bobject.GetComponent<Animator> ().SetBool ("chargekalah", true);
			//bObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("maju");
			//aObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("maju");
			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("attack",QueueMode.PlayNow);

			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("nangkis",QueueMode.PlayNow);
			yield return new WaitForSeconds (.5f);
			Seri_Adef.Play ();


			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle",QueueMode.PlayNow,PlayMode.StopAll);




			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().Play ("attack");
			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().Play ("hit");
			yield return new WaitForSeconds (0.5f);
			damageB.gameObject.SetActive (true);
			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			HealthReduction (urutan,1,damage);
			yield return new WaitForSeconds (0.1f);
			B.Play ();
			hitYa.Play ();


		}
		else if (pilA == "Block" && pilB == "Focus") {
			Debug.Log ("BF");
			damage = bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage- aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend/2;
			if (damage <= 0) {
				damage = 0;
			}
			damageA.text = "- "+damage.ToString ();
			damageB.text = "- "+damage.ToString ();
			Bobject.GetComponent<Animator> ().SetBool ("win", true);
			Aobject.GetComponent<Animator> ().SetBool ("blokkalah", true);
			//aObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("maju");
			//bObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("maju");
			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued("idle");
			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued("charge");

			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");


			Charge_B.Play ();

			yield return new WaitForSeconds (1f);

			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().Play ("attack");

			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().Play ("nangkis_loss");
			yield return new WaitForSeconds (0.5f);
			damageA.gameObject.SetActive (true);

			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			yield return new WaitForSeconds (0.3f);
			HealthReduction (urutan,0,damage);


			A.Play ();
			hitYa.Play ();


		}
		else if (pilA == "Focus" && pilB == "Block") {
			Debug.Log ("FB");
			damage = aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage- bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend/2;
			if (damage <= 0) {
				damage = 0;
			}damageA.text = "- "+damage.ToString ();
			damageB.text = "- "+damage.ToString ();
			Aobject.GetComponent<Animator> ().SetBool ("win", true);
			Bobject.GetComponent<Animator> ().SetBool ("blokkalah", true);
			//bObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("maju");
			//aObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("maju");
			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle",QueueMode.PlayNow);
			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("charge",QueueMode.PlayNow);

			Charge_A.Play ();
			//
			//			aObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			//			bObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");



			yield return new WaitForSeconds (1f);

			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().Play ("attack");

			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().Play ("nangkis_loss");
			yield return new WaitForSeconds (0.5f);
			damageB.gameObject.SetActive (true);

			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");

			yield return new WaitForSeconds (0.3f);
			HealthReduction (urutan,1,damage);
			B.Play ();
			hitYa.Play ();

		}
		else if (pilA == "Focus" && pilB == "Charge") {
			Debug.Log ("FC");
			damage = bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage- aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend/2;
			if (damage <= 0) {
				damage = 0;
			}damageA.text = "- "+damage.ToString ();
			damageB.text = "- "+damage.ToString ();
			Bobject.GetComponent<Animator> ().SetBool ("win", true);
			Aobject.GetComponent<Animator> ().SetBool ("fokuskalah", true);
			//aObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("maju");
			//bObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("maju");
			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("charge",QueueMode.PlayNow);
			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle",QueueMode.PlayNow);

			Charge_A.Play ();

			//			aObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			//			bObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");



			yield return new WaitForSeconds (.5f);

			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().Play ("attack");

			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().Play ("hit");
			yield return new WaitForSeconds (0.5f);
			damageA.gameObject.SetActive (true);

			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");


			yield return new WaitForSeconds (0.3f);
			HealthReduction (urutan,0,damage);
			A.Play ();
			hitYa.Play ();


		}  else if (pilA == "Charge" && pilB == "Focus") {
			Debug.Log ("CF");
			damage = aObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().damage- bObject.transform.Find ("Canvas").transform.Find ("Image").GetComponent<filled> ().defend/2;
			if (damage <= 0) {
				damage = 0;
			}damageA.text = "- "+damage.ToString ();
			damageB.text = "- "+damage.ToString ();
			Aobject.GetComponent<Animator> ().SetBool ("win", true);
			Bobject.GetComponent<Animator> ().SetBool ("fokuskalah", true);
			//bObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("maju");
			//aObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("maju");
			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued("charge",QueueMode.PlayNow);
			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");

			Charge_B.Play ();

			//			aObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			//			bObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");


			yield return new WaitForSeconds (.5f);
			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().Play ("attack");

			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().Play ("hit");
			yield return new WaitForSeconds (0.5f);
			damageB.gameObject.SetActive (true);
			//
			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");

			yield return new WaitForSeconds (0.1f);
			HealthReduction (urutan,1,damage);
			B.Play ();
			hitYa.Play ();

		}

		else if (pilA == "Focus" && pilB == "Focus") {
			//bObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("maju");
			//aObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("maju");
			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("charge");
			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("charge");

			//			aObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			//			bObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			//

			Bobject.GetComponent<Animator> ().SetBool ("fokuskalah", true);
			Aobject.GetComponent<Animator> ().SetBool ("fokuskalah", true);



			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().Play ("draw");
			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().Play ("draw");

			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");


			//Seri_A.Play ();
			yield return new WaitForSeconds (.5f);
			Seri_A.Play ();
		}

		else if (pilA == "Charge" && pilB == "Charge") {
			//bObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("maju");
			//aObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("maju");
			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("charge");
			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("charge");

			//			aObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			//			bObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			//

			Bobject.GetComponent<Animator> ().SetBool ("chargekalah", true);
			Aobject.GetComponent<Animator> ().SetBool ("chargekalah", true);



			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().Play ("draw");
			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().Play ("draw");

			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");


			//Seri_A.Play ();
			yield return new WaitForSeconds (.5f);
			Seri_A.Play ();
		}
		else if (pilA == "Block" && pilB == "Block") {
			//bObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("maju");
			//aObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().Play ("maju");
			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("charge");
			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("charge");

			//			aObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			//			bObject.transform.FindChild ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			//

			Bobject.GetComponent<Animator> ().SetBool ("blokkalah", true);
			Aobject.GetComponent<Animator> ().SetBool ("blokkalah", true);



			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().Play ("draw");
			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().Play ("draw");

			aObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");
			bObject.transform.Find ("COPY_POSITION").transform.Find ("Genderuwo_Fire").GetComponent<Animation> ().PlayQueued ("idle");


			//Seri_A.Play ();
			yield return new WaitForSeconds (.5f);
			Seri_A.Play ();
		}

		yield return new WaitForSeconds (.5f);

		aObject.transform.Find ("Select").GetComponent<SpriteRenderer>().sprite = null;
		bObject.transform.Find ("Select").GetComponent<SpriteRenderer>().sprite = null;


		aObject.GetComponent<PlayAnimation> ().PlayBalik();
		bObject.GetComponent<PlayAnimation> ().PlayBalik();
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

	public void HealthReduction (int urutan, int player,float damaged) {

		Debug.Log ("Health Reduction"+Bb+player);
		if (urutan == 1) {
			if (player == 1) {
				//health1 [1] = health1 [1] - damaged;
				healthBar1 [1].GetComponent<filled> ().currenthealth = healthBar1 [1].GetComponent<filled> ().currenthealth - damaged;
				//healthBar1 [1].GetComponent<filled> ().currenthealth = health1 [1];
				//healthBar1[1].GetComponent<filled>().currenthealth = healthBar1[1].GetComponent<filled>().currenthealth - damaged;

				if (healthBar1 [1].GetComponent<filled> ().currenthealth  <=0) {

					repeat = false;

					if (Bb == false) {
						Ab = true;
						Debug.Log ("Its Done Dude, A is the Winner");
					}

					//healthBar1 [1].GetComponent<SpriteRenderer> ().sprite = empty;
				}

				//healthBar1[1].transform.localScale = new Vector3(health1[1], healthBar1[1].transform.localScale.y, healthBar1[1].transform.localScale.z);
			} else {
				//healthBar1[0].GetComponent<filled>().currenthealth = healthBar1[0].GetComponent<filled>().currenthealth - damaged;
				//health1 [0] = health1 [0] - damaged;
				//	healthBar1 [0].GetComponent<filled> ().currenthealth = health1 [0];
				healthBar1 [0].GetComponent<filled> ().currenthealth= healthBar1 [0].GetComponent<filled> ().currenthealth-damaged;
				//health1 [0] = health1 [0] - damaged;
				//healthBar1 [0].transform.localScale = new Vector3 (health1 [0], healthBar1 [0].transform.localScale.y, healthBar1 [0].transform.localScale.z);

				if (healthBar1 [0].GetComponent<filled> ().currenthealth <= 0) {
					repeat = false;
					if (Ab == false) {
						Bb = true;
						Debug.Log ("Its Done Dude, B is the Winner");
					}
					//healthBar1 [0].GetComponent<SpriteRenderer> ().sprite = empty;
				}



			}

		} else if (urutan == 2) {

			if (player == 1) {
				//	health2 [1] = health2 [1] - damaged;
				//health2 [1] = health2 [1] - damaged;
				healthBar2 [1].GetComponent<filled> ().currenthealth = healthBar2 [1].GetComponent<filled> ().currenthealth-damaged;
				//healthBar2[1].GetComponent<filled>().currenthealth = healthBar2[1].GetComponent<filled>().currenthealth - damaged;
				//healthBar2[1].transform.localScale = new Vector3(health2[1], healthBar2[1].transform.localScale.y, healthBar2[1].transform.localScale.z);

				if (healthBar2 [1].GetComponent<filled> ().currenthealth <= 0) {

					repeat = false;
					if (Bb == false) {
						Ab = true;
						Debug.Log ("Its Done Dude A is the Winner");
					}
					//healthBar2 [1].GetComponent<SpriteRenderer> ().sprite = empty;
				}

			} else {
				//health2 [0] = health2 [0] - damaged;
				//health2 [0] = health2 [0] - damaged;
				healthBar2 [0].GetComponent<filled> ().currenthealth = healthBar2 [0].GetComponent<filled> ().currenthealth - damaged;
				//healthBar2[0].GetComponent<filled>().currenthealth = healthBar2[0].GetComponent<filled>().currenthealth - damaged;
				//healthBar2 [0].transform.localScale = new Vector3 (health2 [0], healthBar2 [0].transform.localScale.y, healthBar2 [0].transform.localScale.z);

				if (healthBar2 [0].GetComponent<filled> ().currenthealth <= 0) {
					repeat = false;
					if (Ab == false) {
						Bb = true;
						Debug.Log ("Its Done Dude B is the Winner");
					}
					//healthBar2 [0].GetComponent<SpriteRenderer> ().sprite = empty;
				}

			}

		} else {

			if (player == 1) {
				//health3 [1] = health3 [1] - damaged;
				//health3 [1] = health3 [1] - damaged;
				healthBar3 [1].GetComponent<filled> ().currenthealth = healthBar3 [1].GetComponent<filled> ().currenthealth - damaged;
				//healthBar3[1].GetComponent<filled>().currenthealth = healthBar3[1].GetComponent<filled>().currenthealth - damaged;
				//healthBar3[1].transform.localScale = new Vector3(health3[1], healthBar3[1].transform.localScale.y, healthBar3[1].transform.localScale.z);


				if (healthBar3 [1].GetComponent<filled> ().currenthealth <= 0) {

					repeat = false;
					if (Bb == false) {
						Ab = true;
						Debug.Log ("Its Done Dude A is the Winner");
					}
					//healthBar3 [1].GetComponent<SpriteRenderer> ().sprite = empty;
				}

			} else {
				//	health3 [0] = health3 [0] - damaged;
				healthBar3 [0].GetComponent<filled> ().currenthealth = healthBar3 [0].GetComponent<filled> ().currenthealth - damaged;
				//healthBar3 [0].transform.localScale = new Vector3 (health3 [0], healthBar3 [0].transform.localScale.y, healthBar3 [0].transform.localScale.z);

				if (healthBar3 [0].GetComponent<filled> ().currenthealth <= 0) {

					repeat = false;
					if (Ab == false) {
						Bb = true;
						Debug.Log ("Its Done Dude B is the Winner");
					}
					//	healthBar3 [0].GetComponent<SpriteRenderer> ().sprite = empty;
				}

			}



		}



	}

	public void Replay () {
		if (PlayerPrefs.GetString (Link.JENIS) != "SINGLE") {
			Application.LoadLevel (Link.Arena);
		} else {
			Application.LoadLevel (Link.Game);
		}

	}

	public void Map () {
		if (PlayerPrefs.GetString ("PLAY_TUTORIAL") == "TRUE") {
			PlayerPrefs.SetString ("Tutorgame", "TRUE");
		}
		Application.LoadLevel (Link.Map);
	}
	public void GameSpeed(int speed){
		Time.timeScale = speed;
	}

public int[] ItemRate;
public string[] ItemQuantity;
public string[] ItemType;
public string[] ItemName;
public int weightTotal;

 
   
 
    void SetReward () {
        ItemRate = new int[3]; //number of things
        ItemName = new string[3];
        //weighting of each thing, high number means more occurrance
        for(int i = 0; i<3;i++)
        {
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
		
        return result;
    }


}
