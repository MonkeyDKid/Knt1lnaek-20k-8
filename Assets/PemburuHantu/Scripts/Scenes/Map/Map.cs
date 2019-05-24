using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System.Collections;
using DG.Tweening;

public class Map : MonoBehaviour
{
    public GameObject BG1,BG2,BG3,BG3T,BG4,BG5,BG6,Loadscene;
	public GameObject imagebutton,firstTimerMAP,FirstTimerMap2,NoEnergyGUI,trouble, ValidationError;
    public GameObject[] Locks, Done;
    public GameObject LevelSelection, TutorialLevel, LevelImageGO;
    public Button schoolbutton, hospitalbutton, bridgebutton, graveyardbutton, warehousebutton;
	lifeless lf;
	public Text EnergyBar,R1,R2,R3;
	public bool pressed;
    public GameObject CameraObject;
    public float nilai;
    public Sprite[] levelimage;

	public int currentEnergy, MaxEnergy,energyused;
	public string lokasi = "";

    public Image G1, G2, G3;
    public Sprite DefaultSelectedGhostTarget;

    public string[] dropItemName;
    public string[] dropItemQuantity;
    public string[] dropItemType;
    public string[] dropItemFileName;
    public string[] dropItemRate;
	public void Start()
    {
     
        //	PlayerPrefs.SetString ("berburu", "tidak");
        lf = this.gameObject.GetComponent<lifeless> ();
        // if (PlayerPrefs.GetString ("PLAY_TUTORIAL") == "TRUE" && PlayerPrefs.GetString ("Tutorgame") != "TRUE") {
		// 	TutorialLevel.SetActive(true);
        //     //firstTimerMAP.gameObject.SetActive (true);
		// 	//SceneManagerHelper.LoadTutorial("Map");
		// 	///FirstTimerMap2.SetActive (false);
		// } 
        // else 
        // {
		// 	//SceneManagerHelper.StopTutorial ();
        //     TutorialLevel.SetActive(false);
		// 	firstTimerMAP.gameObject.SetActive (false);
		// }
		// if (PlayerPrefs.GetString ("Tutorgame") == "TRUE") {
		// 	FirstTimerMap2.SetActive (true);
		
		// }

		StartCoroutine(GetDataUser ());
	
	}

    public void ClearSheet()
    {
        G1.sprite = DefaultSelectedGhostTarget;
        G2.sprite = DefaultSelectedGhostTarget;
        G3.sprite = DefaultSelectedGhostTarget;
    }
     public void SetStage(string name)
    {
        switch(name)
        {
            case "Old House":
            LevelImageGO.GetComponent<Image>().sprite = levelimage[0];
            break;
            case "Graveyard":
            LevelImageGO.GetComponent<Image>().sprite = levelimage[1];
            break;
            case "Bridge":
            LevelImageGO.GetComponent<Image>().sprite = levelimage[3];
            break;
            case "Warehouse":
            LevelImageGO.GetComponent<Image>().sprite = levelimage[5];
            break;
            case "School":
            LevelImageGO.GetComponent<Image>().sprite = levelimage[4];
            break;
            case "Hospital":
            LevelImageGO.GetComponent<Image>().sprite = levelimage[2];
            break;

        }

    }
    

    public void CheckStage()
    {
      var angka = int.Parse(PlayerPrefs.GetString(Link.Stage));
    
     
        if (angka >= 1)
        {
             CameraMovement(6.753331f,1.5f);
			Locks [0].SetActive (false);
            Done [0].transform.Find("Comp").gameObject.SetActive (true);
           // schoolbutton.interactable = enabled;
        }
        if (angka >= 2)
        {
           
           CameraMovement(25f,1.5f);
			Locks[1].SetActive (false);
             Done [1].transform.Find("Comp").gameObject.SetActive (true);
          //  schoolbutton.interactable = enabled;
        }
        if (angka >= 3)
        {
             
          CameraMovement(40f,1.5f);
			Locks[2].SetActive (false);
             Done [2].transform.Find("Comp").gameObject.SetActive (true);
           // schoolbutton.interactable = enabled;
        }
        if (angka >= 4)
        {
              
            CameraMovement(60f,1.5f);
			Locks[3].SetActive (false);
             Done [3].transform.Find("Comp").gameObject.SetActive (true);
            //schoolbutton.interactable = enabled;
        }
        if (angka >= 5)
        {
            
            CameraMovement(85.56001f,1.5f);
			Locks[4].SetActive (false);
             Done [4].transform.Find("Comp").gameObject.SetActive (true);
            //schoolbutton.interactable = enabled;
        }
        if (angka >= 6)
        {
            
            CameraMovement(6.753331f,1.5f);
             Done [5].transform.Find("Comp").gameObject.SetActive (true);
            schoolbutton.interactable = enabled;
        }
        if (angka >= 7)
        {

			Locks[5].SetActive (false);
             Done [6].transform.Find("Comp").gameObject.SetActive (true);
          
           // schoolbutton.interactable = enabled;
        }
        if (angka >= 8)
        {
			Locks[6].SetActive (false);
             Done [7].transform.Find("Comp").gameObject.SetActive (true);
          
          //  schoolbutton.interactable = enabled;
        }
        if (angka >= 9)
        {
            Locks[7].SetActive(false);
             Done [8].transform.Find("Comp").gameObject.SetActive (true);
          
          //  schoolbutton.interactable = enabled;
        }
        if (angka >= 10)
        {
            Locks[8].SetActive(false);
             Done [9].transform.Find("Comp").gameObject.SetActive (true);
           
          //  schoolbutton.interactable = enabled;
        }
        if (angka >= 11)
        {
            Locks[9].SetActive(false);
             Done [10].transform.Find("Comp").gameObject.SetActive (true);
          
          //  hospitalbutton.interactable = enabled;
        }
        if (angka >= 12)
        {
           
          
             Done [11].transform.Find("Comp").gameObject.SetActive (true);
            hospitalbutton.interactable = enabled;
        }
        if (angka >= 13)
        {
            Locks[10].SetActive(false);
             Done [12].transform.Find("Comp").gameObject.SetActive (true);
           
            //schoolbutton.interactable = enabled;
        }
        if (angka >= 14)
        {
            Locks[11].SetActive(false);
             Done [13].transform.Find("Comp").gameObject.SetActive (true);
           
           
           // schoolbutton.interactable = enabled;
        }
        if (angka >= 15)
        {
            Locks[12].SetActive(false);
             Done [0].SetActive (true);
           
           
            //schoolbutton.interactable = enabled;
        }
        if (angka >= 16)
        {
            Locks[13].SetActive(false);
             Done [0].SetActive (true);
          
           
           // schoolbutton.interactable = enabled;
        }
        if (angka >= 17)
        {
            Locks[14].SetActive(false);
             Done [0].SetActive (true);
          
          //  schoolbutton.interactable = enabled;
        }
        if (angka >= 18)
        {
           
            bridgebutton.interactable = enabled;
             Done [0].SetActive (true);
        }
        if (angka >= 19)
        {
            Locks[15].SetActive(false);
             Done [0].SetActive (true);
          
          //  schoolbutton.interactable = enabled;
        }
        if (angka >= 20)
        {
            Locks[16].SetActive(false);
             Done [0].SetActive (true);
            
          //  schoolbutton.interactable = enabled;
        }
        if (angka >= 21)
        {
            Locks[17].SetActive(false);
             Done [0].SetActive (true);
           
          //  schoolbutton.interactable = enabled;
        }
        if (angka >= 22)
        {
            Locks[18].SetActive(false);
             Done [0].SetActive (true);
           
          //  schoolbutton.interactable = enabled;
        }
        if (angka >= 23)
        {
            Locks[19].SetActive(false);
        
             Done [0].SetActive (true);
        //    schoolbutton.interactable = enabled;
        }
        if (angka >= 24)
        {
           
             Done [0].SetActive (true);
          
            graveyardbutton.interactable = enabled;
        }
        if (angka >= 25)
        {
            Locks[20].SetActive(false);
             Done [0].SetActive (true);
           
          //  schoolbutton.interactable = enabled;
        }
        if (angka >= 26)
        {
            Locks[21].SetActive(false);
             Done [0].SetActive (true);
           
          //  schoolbutton.interactable = enabled;
        }
        if (angka >= 27)
        {
             Done [0].SetActive (true);
            Locks[22].SetActive(false);
          
          //  schoolbutton.interactable = enabled;
        }
        if (angka >= 28)
        {
             Done [0].SetActive (true);
            Locks[23].SetActive(false);
         
         //   schoolbutton.interactable = enabled;
        }
        if (angka >= 29)
        {
             Done [0].SetActive (true);
            Locks[24].SetActive(false);
           
         //   schoolbutton.interactable = enabled;
        }
        if (angka >= 30)
        {
             Done [0].SetActive (true);
            warehousebutton.interactable = enabled;
           
         
         //   schoolbutton.interactable = enabled;
        }
        if (angka >= 31)
        {
             Done [0].SetActive (true);
            Locks[25].SetActive(false);
           
          
            //   schoolbutton.interactable = enabled;
        }
        if (angka >= 32)
        {
             Done [0].SetActive (true);
             Locks[26].SetActive(false);
                      //   schoolbutton.interactable = enabled;
        }
        if (angka >= 33)
        {
            
             Done [0].SetActive (true);
            Locks[27].SetActive(false);
                      
            //   schoolbutton.interactable = enabled;
        }
        if (angka >= 34)
        {
             Done [0].SetActive (true);
            Locks[28].SetActive(false);
        }
         if (angka >= 35)
        {
             Done [0].SetActive (true);
            Locks[29].SetActive(false);
        }
    }
	public void OnWarehouse () {
        LevelSelected();
		lokasi = "warehouse";
		StartCoroutine(GetDataUser ());
		BG5.SetActive (true);
	
	}
	void Update(){
        if(Input.GetKeyUp(KeyCode.K))
        {
            //ZoominPopUp(NoEnergyGUI);
             SceneManagerHelper._instance.HandleError(33);
        }
        if(Input.GetKeyUp(KeyCode.L))
        {
            ZoomoutPopUp(NoEnergyGUI);
        }

	}
    public void ZoominPopUp(GameObject item)
    {
        item.transform.DOPunchScale((new Vector3(1,1,1)),.15f,10);
        
        item.SetActive(true);
        
    }
    public void ZoomoutPopUp(GameObject item)
    {
        item.transform.DOScale(0,.15f).OnComplete(()=>close(item));
    }

    void close(GameObject item)
    {
        item.SetActive(false);
    }
    void CameraMovement(float pos, float time)
    {
        CameraObject.transform.DOMoveX(pos,time);
    }
	private IEnumerator GetDataUser ()
	{
		string url = Link.url + "getDataUser";
		WWWForm form = new WWWForm ();
		form.AddField (Link.ID, PlayerPrefs.GetString(Link.ID));
        form.AddField("DID", PlayerPrefs.GetString(Link.DEVICE_ID));
        WWW www = new WWW(url,form);
		yield return www;
		if (www.error == null) {

			var jsonString = JSON.Parse (www.text);
			Debug.Log (www.text);
			PlayerPrefs.SetString (Link.FOR_CONVERTING, jsonString["code"]);
			if (PlayerPrefs.GetString(Link.FOR_CONVERTING)=="0") {
				PlayerPrefs.SetString ("BonusEnergy", jsonString ["data"] ["BonusEnergy"]);
				var energy = int.Parse (jsonString ["data"] ["energy"]) + int.Parse (jsonString ["data"] ["BonusEnergy"]);
				PlayerPrefs.SetString ("EnergyCombo", energy.ToString());
				EnergyBar.text = energy.ToString();
				currentEnergy = int.Parse(jsonString ["data"] ["energy"]);
				PlayerPrefs.SetString (Link.ENERGY, currentEnergy.ToString());
				PlayerPrefs.SetString("MaxE",jsonString ["data"] ["MaxEnergy"]);
				PlayerPrefs.SetString (Link.ENERGY, jsonString["data"]["energy"]);
				PlayerPrefs.SetString (Link.GOLD, jsonString["data"]["coin"]);
				PlayerPrefs.SetString (Link.SOUL_STONE, jsonString["data"]["soulstone"]);
                PlayerPrefs.SetString(Link.Stage, jsonString["data"]["Stage"]);
				lf.enabled = true;
               // CheckStage();
			}
            else if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == "33")
            {
                ValidationError.SetActive(true);
            }
        } else {
			Debug.Log ("GAGAL");
		}
	}
	private IEnumerator kurangEnergy ()
	{
		string url = Link.url + "energy";
		WWWForm form = new WWWForm ();
		form.AddField (Link.ID, PlayerPrefs.GetString(Link.ID));
        form.AddField("DID", PlayerPrefs.GetString(Link.DEVICE_ID));
        form.AddField ("EUsed", energyused);
		WWW www = new WWW(url,form);
		yield return www;
		if (www.error == null) {
			
			var jsonString = JSON.Parse (www.text);
			Debug.Log (www.text);
			PlayerPrefs.SetString (Link.FOR_CONVERTING, jsonString["code"]);
            if (int.Parse(PlayerPrefs.GetString(Link.FOR_CONVERTING)) == 1)
            {
                lf.lostLife(energyused, int.Parse(jsonString["data"]["energy"]));
                PlayerPrefs.SetString(Link.ENERGY, jsonString["data"]["energy"]);
                //yield return new WaitForSeconds (1);
                SceneManagerHelper.LoadScene(Link.PilihCharacter);
            }
            else if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == "33")
            {
                ValidationError.SetActive(true);
            }
        } else {
			 pressed = false;
			trouble.SetActive (true);
			Debug.Log ("GAGAL");
		}
	}

    public void PlayTutorial () {
        PlayerPrefs.SetString(Link.StageChoose, "0");
        if (!pressed) {
            PlayerPrefs.SetString(Link.SEARCH_BATTLE, "SINGLE");
            PlayerPrefs.SetString(Link.LOKASI, lokasi);
            PlayerPrefs.SetString(Link.JENIS, "SINGLE");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_FILE, "Pocong_Fire");
            
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ELEMENT, "Fire");
           
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_MODE, "ATTACK");
           
            //DISESUAIKAN DENGAN KEBUTUHAN YANG BERSANGKUTAN + EXCEL MAS TONI
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ATTACK, "443");// 302	442	1518
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_DEFENSE, "327");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_HP, "1399");

            if (currentEnergy >= energyused) {
				//Application.LoadLevel (Link.PilihCharacter);
				StartCoroutine (kurangEnergy ());
			} else {
				NoEnergyGUI.SetActive (true);
			}
			 pressed = true;
		}
	
	}

	public void OnSchool () {
        LevelSelected();
		energyused = 4;
		PlayerPrefs.SetInt ("EUsed", energyused);
		lokasi = "School";
		StartCoroutine(GetDataUser ());
		BG2.SetActive (true);
         Normal();
	//	Debug.Log(imagebutton.GetComponent<Image> ().sprite.name);
	}

	public void OnHospital () {
        LevelSelected();
		energyused = 5;
		PlayerPrefs.SetInt ("EUsed", energyused);
		lokasi = "Hospital";
		StartCoroutine(GetDataUser ());
		BG1.SetActive (true);
         Normal();
	}
	public void OnOldhouse () {
       
        LevelSelected();
		energyused = 3;
		PlayerPrefs.SetInt ("EUsed", energyused);
		lokasi = "Oldhouse";
		if (PlayerPrefs.GetString ("PLAY_TUTORIAL") == "TRUE") {
			//BG3T.SetActive (true);
            StartCoroutine(GetDataUser ());
			BG3.SetActive (true);
		} else {
            StartCoroutine(GetStageDrop("Old House"));
			StartCoroutine(GetDataUser ());
			BG3.SetActive (true);
		}
         Normal();
	}
	public void OnBridge () {
        LevelSelected();
		energyused = 6;
		PlayerPrefs.SetInt ("EUsed", energyused);
		lokasi = "Bridge";
		StartCoroutine(GetDataUser ());
		BG4.SetActive (true);
         Normal();
	}
	public void OnGraveyard () {
        LevelSelected();
		energyused = 7;
		PlayerPrefs.SetInt ("EUsed", energyused);
		lokasi = "Graveyard";
		StartCoroutine(GetDataUser ());
		BG6.SetActive (true);
        Normal();
	}

	public void OnWareHouse () {
        LevelSelected();
		energyused = 8;
		PlayerPrefs.SetInt ("EUsed", energyused);
		lokasi = "Warehouse";
		StartCoroutine(GetDataUser ());
		BG5.SetActive (true);
        Normal();

	}
	public void OnClose () {
		
		BG1.SetActive (false);
		BG2.SetActive (false);
		BG3.SetActive (false);
		BG4.SetActive (false);
		BG5.SetActive (false);
		BG6.SetActive (false);
        ClearSheet();
//        G1.sprite = DefaultSelectedGhostTarget;
//        G2.sprite = DefaultSelectedGhostTarget;
//        G3.sprite = DefaultSelectedGhostTarget;
	}

    private void LevelSelected()
    {
        LevelSelection.SetActive(true);
    }
	public void OnArena () {
		SceneManagerHelper.LoadScene ("Arena");
	}

	public void Normal(){
		PlayerPrefs.SetInt ("MapPlayerXP", 100);
		PlayerPrefs.SetString ("Difficulty", "Normal");
		if (lokasi == "school") {
			PlayerPrefs.SetInt ("MAPSEXP", 381);	
		}
		if (lokasi == "hospital") {
			PlayerPrefs.SetInt ("MAPSEXP", 510);	
		}
		if (lokasi == "oldhouse") {
			PlayerPrefs.SetInt ("MAPSEXP", 107);	
		}
		if (lokasi == "bridge") {
			PlayerPrefs.SetInt ("MAPSEXP", 606);	
		}
		if (lokasi == "warehouse") {
			PlayerPrefs.SetInt ("MAPSEXP", 802);	
		} 
		else {
			PlayerPrefs.SetInt ("MAPSEXP", 696);	
		}

	}
	public void Hard(){
		PlayerPrefs.SetInt ("MapPlayerXP", 100);
		PlayerPrefs.SetString ("Difficulty", "Hard");
		if (lokasi == "school") {
			PlayerPrefs.SetInt ("MAPSEXP", 570);	
		}
		if (lokasi == "hospital") {
			PlayerPrefs.SetInt ("MAPSEXP", 625);	
		}
		if (lokasi == "oldhouse") {
			PlayerPrefs.SetInt ("MAPSEXP", 594);	
		}
		if (lokasi == "bridge") {
			PlayerPrefs.SetInt ("MAPSEXP", 932);	
		}
		if (lokasi == "warehouse") {
			PlayerPrefs.SetInt ("MAPSEXP", 1056);	
		} 
		else {
			PlayerPrefs.SetInt ("MAPSEXP", 822);	
		}
	}
	public void Brutal(){
		PlayerPrefs.SetInt ("MapPlayerXP", 100);
		PlayerPrefs.SetString ("Difficulty", "Brutal");
		if (lokasi == "school") {
			PlayerPrefs.SetInt ("MAPSEXP", 960);	
		}
		if (lokasi == "hospital") {
			PlayerPrefs.SetInt ("MAPSEXP", 1080);	
		}
		if (lokasi == "oldhouse") {
			PlayerPrefs.SetInt ("MAPSEXP", 960);	
		}
		if (lokasi == "bridge") {
			PlayerPrefs.SetInt ("MAPSEXP", 1320);	
		}
		if (lokasi == "warehouse") {
			PlayerPrefs.SetInt ("MAPSEXP", 1440);	
		} 
		else {
			PlayerPrefs.SetInt ("MAPSEXP", 1200);	
		}
	}



	//Hostpital
	public void Onhospital1 () {
        PlayerPrefs.SetString(Link.StageChoose, "12");
        if (!pressed) {
            PlayerPrefs.SetString(Link.SEARCH_BATTLE, "SINGLE");
            PlayerPrefs.SetString(Link.LOKASI, lokasi);
            PlayerPrefs.SetString(Link.JENIS, "SINGLE");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_FILE, "Kunti_Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_FILE, "SusterNgesot_Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_FILE, "SusterNgesot_Water");

            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ELEMENT, "Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ELEMENT, "Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ELEMENT, "Water");

            PlayerPrefs.SetString(Link.POS_1_CHAR_1_MODE, "DEFEND");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_MODE, "DEFEND");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_MODE, "HP");

            //DISESUAIKAN DENGAN KEBUTUHAN YANG BERSANGKUTAN + EXCEL MAS TONI
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_GRADE, "4");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ATTACK, "437");//401 //483 //1248
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_DEFENSE, "574");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_HP, "1612");

            PlayerPrefs.SetString(Link.POS_1_CHAR_2_GRADE, "4");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ATTACK, "424");// 621  340 1317
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_DEFENSE, "547");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_HP, "1900");

            PlayerPrefs.SetString(Link.POS_1_CHAR_3_GRADE, "4");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ATTACK, "421");//552 450 1044
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_DEFENSE, "423");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_HP, "2358");
            if (currentEnergy >= energyused) {
			
          //  Application.LoadLevel(Link.PilihCharacter);

            				StartCoroutine (kurangEnergy ());
            			} 
            			else {
            				NoEnergyGUI.SetActive (true);
            			}
            //		
            pressed = true;	
		}
	}
	public void Onhospital2 () {
        PlayerPrefs.SetString(Link.StageChoose, "13");
        if (!pressed) {
            PlayerPrefs.SetString(Link.SEARCH_BATTLE, "SINGLE");
            PlayerPrefs.SetString(Link.LOKASI, lokasi);
            PlayerPrefs.SetString(Link.JENIS, "SINGLE");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_FILE, "Kunti_Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_FILE, "Kunti_Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_FILE, "Kunti_Water");

            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ELEMENT, "Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ELEMENT, "Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ELEMENT, "Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_MODE, "ATTACK");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_MODE, "ATTACK");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_MODE, "ATTACK");
            //DISESUAIKAN DENGAN KEBUTUHAN YANG BERSANGKUTAN + EXCEL MAS TONI
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_GRADE, "4");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ATTACK, "636");//380 315 1665
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_DEFENSE, "354");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_HP, "1738");

            PlayerPrefs.SetString(Link.POS_1_CHAR_2_GRADE, "4");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ATTACK, "636");// 456 421 969
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_DEFENSE, "354");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_HP, "1738");


            PlayerPrefs.SetString(Link.POS_1_CHAR_3_GRADE, "4");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ATTACK, "636");// 330 487 1449
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_DEFENSE, "354");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_HP, "1738");
            if (currentEnergy >= energyused) {
		
		
       // Application.LoadLevel(Link.PilihCharacter);
        			StartCoroutine (kurangEnergy ());
        		}
        		else {
        			NoEnergyGUI.SetActive (true);
        	}
        pressed = true;
	}
	}
		public void Onhospital3 () {
        PlayerPrefs.SetString(Link.StageChoose, "14");
        if (!pressed) {

            PlayerPrefs.SetString(Link.SEARCH_BATTLE, "SINGLE");
            PlayerPrefs.SetString(Link.LOKASI, lokasi);
            PlayerPrefs.SetString(Link.JENIS, "SINGLE");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_FILE, "SusterNgesot_Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_FILE, "SusterNgesot_Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_FILE, "SusterNgesot_Wind");

            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ELEMENT, "Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ELEMENT, "Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ELEMENT, "Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_MODE, "ATTACK");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_MODE, "ATTACK");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_MODE, "ATTACK");
            //DISESUAIKAN DENGAN KEBUTUHAN YANG BERSANGKUTAN + EXCEL MAS TONI
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ATTACK, "562"); // 370 367 1839
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_DEFENSE, "407");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_HP, "2015");

            PlayerPrefs.SetString(Link.POS_1_CHAR_2_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ATTACK, "562");// 213 511	1428
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_DEFENSE, "407");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_HP, "2015");

            PlayerPrefs.SetString(Link.POS_1_CHAR_3_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ATTACK, "562");//	376	350	1572
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_DEFENSE, "407");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_HP, "2015");
            if (currentEnergy >= energyused) {

				//Application.LoadLevel (Link.PilihCharacter);
							StartCoroutine (kurangEnergy ());
						}
				
						else {
							NoEnergyGUI.SetActive (true);
					}
				 pressed = true;
			}
	}
	public void Onhospital4 () {
        PlayerPrefs.SetString(Link.StageChoose, "15");
        if (!pressed) {
            PlayerPrefs.SetString(Link.SEARCH_BATTLE, "SINGLE");
            PlayerPrefs.SetString(Link.LOKASI, lokasi);
            PlayerPrefs.SetString(Link.JENIS, "SINGLE");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_FILE, "Pocong_Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_FILE, "Pocong_Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_FILE, "Pocong_Fire");

            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ELEMENT, "Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ELEMENT, "Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ELEMENT, "Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_MODE, "ATTACK");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_MODE, "DEFEND");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_MODE, "ATTACK");
            //DISESUAIKAN DENGAN KEBUTUHAN YANG BERSANGKUTAN + EXCEL MAS TONI
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ATTACK, "499"); // 370 367 1839
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_DEFENSE, "322");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_HP, "1889");

            PlayerPrefs.SetString(Link.POS_1_CHAR_2_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ATTACK, "253");// 213 511	1428
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_DEFENSE, "575");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_HP, "1988");

            PlayerPrefs.SetString(Link.POS_1_CHAR_3_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ATTACK, "499");//	376	350	1572
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_DEFENSE, "322");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_HP, "1889");
            if (currentEnergy >= energyused) {

				
			//	Application.LoadLevel (Link.PilihCharacter);
				StartCoroutine (kurangEnergy ());
			}

			else {
				NoEnergyGUI.SetActive (true);
			}
			pressed = true;
		}
	}
	public void Onhospital5 () {
        PlayerPrefs.SetString(Link.StageChoose, "16");
        if (!pressed)
        {
            PlayerPrefs.SetString(Link.SEARCH_BATTLE, "SINGLE");
            PlayerPrefs.SetString(Link.LOKASI, lokasi);
            PlayerPrefs.SetString(Link.JENIS, "SINGLE");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_FILE, "Tuyul_Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_FILE, "Tuyul_Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_FILE, "SusterNgesot_Fire");

            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ELEMENT, "Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ELEMENT, "Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ELEMENT, "Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_MODE, "ATTACK");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_MODE, "DEFEND");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_MODE, "DEFEND");
            //DISESUAIKAN DENGAN KEBUTUHAN YANG BERSANGKUTAN + EXCEL MAS TONI
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ATTACK, "505"); // 370 367 1839
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_DEFENSE, "400");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_HP, "2442");

            PlayerPrefs.SetString(Link.POS_1_CHAR_2_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ATTACK, "454");// 213 511	1428
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_DEFENSE, "562");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_HP, "2215");

            PlayerPrefs.SetString(Link.POS_1_CHAR_3_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ATTACK, "424");//	376	350	1572
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_DEFENSE, "547");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_HP, "1900");
            if (currentEnergy >= energyused) {

			
				//Application.LoadLevel (Link.PilihCharacter);
				StartCoroutine (kurangEnergy ());
			}

			else {
				NoEnergyGUI.SetActive (true);
			}
			pressed = true;
		}
	}
	public void Onhospital6 () {
        PlayerPrefs.SetString(Link.StageChoose, "17");
        if (!pressed)
        {
            PlayerPrefs.SetString(Link.SEARCH_BATTLE, "SINGLE");
            PlayerPrefs.SetString(Link.LOKASI, lokasi);
            PlayerPrefs.SetString(Link.JENIS, "SINGLE");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_FILE, "Tuyul_Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_FILE, "Tuyul_Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_FILE, "Tuyul_Wind");

            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ELEMENT, "Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ELEMENT, "Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ELEMENT, "Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_MODE, "HP");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_MODE, "HP");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_MODE, "HP");
            //DISESUAIKAN DENGAN KEBUTUHAN YANG BERSANGKUTAN + EXCEL MAS TONI
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ATTACK, "421"); // 370 367 1839
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_DEFENSE, "395");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_HP, "2382");

            PlayerPrefs.SetString(Link.POS_1_CHAR_2_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ATTACK, "421");// 213 511	1428
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_DEFENSE, "395");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_HP, "2382");

            PlayerPrefs.SetString(Link.POS_1_CHAR_3_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ATTACK, "421");//	376	350	1572
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_DEFENSE, "395");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_HP, "2382");
            if (currentEnergy >= energyused) {

			//	Application.LoadLevel (Link.PilihCharacter);
				StartCoroutine (kurangEnergy ());
			}

			else {
				NoEnergyGUI.SetActive (true);
			}
			pressed = true;
		}
	}
	//School
			public void OnSchool1 () {
        PlayerPrefs.SetString(Link.StageChoose, "6");
        if (!pressed)
        {
            PlayerPrefs.SetString(Link.SEARCH_BATTLE, "SINGLE");
            PlayerPrefs.SetString(Link.LOKASI, lokasi);
            PlayerPrefs.SetString(Link.JENIS, "SINGLE");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_FILE, "Pocong_Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_FILE, "Babingepet_Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_FILE, "Tuyul_Fire");

            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ELEMENT, "Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ELEMENT, "Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ELEMENT, "Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_MODE, "DEFEND");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_MODE, "HP");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_MODE, "ATTACK");
            //DISESUAIKAN DENGAN KEBUTUHAN YANG BERSANGKUTAN + EXCEL MAS TONI
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ATTACK, "233");// 302	442	1518
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_DEFENSE, "543");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_HP, "1708");

            PlayerPrefs.SetString(Link.POS_1_CHAR_2_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ATTACK, "400");//	322	300	1734
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_DEFENSE, "335");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_HP, "2025");

            PlayerPrefs.SetString(Link.POS_1_CHAR_3_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ATTACK, "465");//	501	355	1332
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_DEFENSE, "365");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_HP, "1696");
            if (currentEnergy >= energyused) {
	
      //  Application.LoadLevel(Link.PilihCharacter);
        			StartCoroutine (kurangEnergy ());
        		}
        		else {
        			NoEnergyGUI.SetActive (true);
        	}
        pressed = true;
	}
	}
				public void OnSchool2 () {
        PlayerPrefs.SetString(Link.StageChoose, "7");
        if (!pressed) {
            PlayerPrefs.SetString(Link.SEARCH_BATTLE, "SINGLE");
            PlayerPrefs.SetString(Link.LOKASI, lokasi);
            PlayerPrefs.SetString(Link.JENIS, "SINGLE");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_FILE, "Babingepet_Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_FILE, "Jelangkung_Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_FILE, "Kolorijo_Fire");

            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ELEMENT, "Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ELEMENT, "Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ELEMENT, "Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_MODE, "DEFEND");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_MODE, "DEFEND");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_MODE, "ATTACK");
            //DISESUAIKAN DENGAN KEBUTUHAN YANG BERSANGKUTAN + EXCEL MAS TONI
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ATTACK, "322");//380 315 1665
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_DEFENSE, "474");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_HP, "1798");

            PlayerPrefs.SetString(Link.POS_1_CHAR_2_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ATTACK, "362");// 456 421 969
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_DEFENSE, "510");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_HP, "1420");

            PlayerPrefs.SetString(Link.POS_1_CHAR_3_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ATTACK, "533");// 330 487 1449
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_DEFENSE, "387");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_HP, "1612");
            if (currentEnergy >= energyused) {
		
		
       // Application.LoadLevel(Link.PilihCharacter);
        			StartCoroutine (kurangEnergy ());
        		}
        		else {
        			NoEnergyGUI.SetActive (true);
        	}
        pressed = true;
	}
	}
					public void OnSchool3 () {
        PlayerPrefs.SetString(Link.StageChoose, "8");
        if (!pressed) {
            PlayerPrefs.SetString(Link.SEARCH_BATTLE, "SINGLE");
            PlayerPrefs.SetString(Link.LOKASI, lokasi);
            PlayerPrefs.SetString(Link.JENIS, "SINGLE");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_FILE, "Kolorijo_Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_FILE, "Jelangkung_Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_FILE, "Kolorijo_Fire");

            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ELEMENT, "Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ELEMENT, "Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ELEMENT, "Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_MODE, "DEFEND");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_MODE, "HP");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_MODE, "ATTACK");
            //DISESUAIKAN DENGAN KEBUTUHAN YANG BERSANGKUTAN + EXCEL MAS TONI
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ATTACK, "355"); // 370 367 1839
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_DEFENSE, "527");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_HP, "1799");

            PlayerPrefs.SetString(Link.POS_1_CHAR_2_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ATTACK, "347");// 213 511	1428
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_DEFENSE, "325");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_HP, "2184");

            PlayerPrefs.SetString(Link.POS_1_CHAR_3_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ATTACK, "541");//	376	350	1572
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_DEFENSE, "380");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_HP, "1682");
            if (currentEnergy >=energyused) {
		
		
       // Application.LoadLevel(Link.PilihCharacter);
        			StartCoroutine (kurangEnergy ());
        		}
        		else {
        			NoEnergyGUI.SetActive (true);
        	}
        pressed = true;
	}
	}
	public void OnSchool4 () {
        PlayerPrefs.SetString(Link.StageChoose, "9");
        if (!pressed) {
            PlayerPrefs.SetString(Link.SEARCH_BATTLE, "SINGLE");
            PlayerPrefs.SetString(Link.LOKASI, lokasi);
            PlayerPrefs.SetString(Link.JENIS, "SINGLE");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_FILE, "Pocong_Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_FILE, "Pocong_Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_FILE, "Kolorijo_Wind");

            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ELEMENT, "Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ELEMENT, "Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ELEMENT, "Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_MODE, "ATTACK");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_MODE, "HP");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_MODE, "HP");
            //DISESUAIKAN DENGAN KEBUTUHAN YANG BERSANGKUTAN + EXCEL MAS TONI
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ATTACK, "475"); // 370 367 1839
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_DEFENSE, "347");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_HP, "1679");

            PlayerPrefs.SetString(Link.POS_1_CHAR_2_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ATTACK, "291");// 213 511	1428
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_DEFENSE, "405");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_HP, "2112");

            PlayerPrefs.SetString(Link.POS_1_CHAR_3_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ATTACK, "414");//	376	350	1572
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_DEFENSE, "403");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_HP, "2049");
            if (currentEnergy >=energyused) {

				
				// Application.LoadLevel(Link.PilihCharacter);
				StartCoroutine (kurangEnergy ());
			}
			else {
				NoEnergyGUI.SetActive (true);
			}
			pressed = true;
		}
	}
	public void OnSchool5 () {
        PlayerPrefs.SetString(Link.StageChoose, "10");
        if (!pressed) {
            PlayerPrefs.SetString(Link.SEARCH_BATTLE, "SINGLE");
            PlayerPrefs.SetString(Link.LOKASI, lokasi);
            PlayerPrefs.SetString(Link.JENIS, "SINGLE");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_FILE, "Kunti_fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_FILE, "Kolorijo_Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_FILE, "Pocong_Fire");

            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ELEMENT, "Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ELEMENT, "Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ELEMENT, "Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_MODE, "HP");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_MODE, "DEFEND");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_MODE, "ATTACK");
            //DISESUAIKAN DENGAN KEBUTUHAN YANG BERSANGKUTAN + EXCEL MAS TONI
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ATTACK, "400"); // 370 367 1839
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_DEFENSE, "397");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_HP, "2379");

            PlayerPrefs.SetString(Link.POS_1_CHAR_2_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ATTACK, "517");// 213 511	1428
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_DEFENSE, "535");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_HP, "1869");

            PlayerPrefs.SetString(Link.POS_1_CHAR_3_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ATTACK, "483");//	376	350	1572
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_DEFENSE, "352");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_HP, "1749");
            if (currentEnergy >=energyused) {

				
				// Application.LoadLevel(Link.PilihCharacter);
				StartCoroutine (kurangEnergy ());
			}
			else {
				NoEnergyGUI.SetActive (true);
			}
			pressed = true;
		}
	}
	public void OnSchool6 () {
        PlayerPrefs.SetString(Link.StageChoose, "11");
        if (!pressed)
        {
            PlayerPrefs.SetString(Link.SEARCH_BATTLE, "SINGLE");
            PlayerPrefs.SetString(Link.LOKASI, lokasi);
            PlayerPrefs.SetString(Link.JENIS, "SINGLE");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_FILE, "Jelangkung_Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_FILE, "Kunti_Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_FILE, "Kunti_Wind");

            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ELEMENT, "Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ELEMENT, "Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ELEMENT, "Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_MODE, "HP");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_MODE, "ATTACK");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_MODE, "DEFEND");
            //DISESUAIKAN DENGAN KEBUTUHAN YANG BERSANGKUTAN + EXCEL MAS TONI
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ATTACK, "352"); // 370 367 1839
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_DEFENSE, "330");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_HP, "2274");

            PlayerPrefs.SetString(Link.POS_1_CHAR_2_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ATTACK, "628");// 213 511	1428
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_DEFENSE, "384");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_HP, "1668");

            PlayerPrefs.SetString(Link.POS_1_CHAR_3_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ATTACK, "432");//	376	350	1572
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_DEFENSE, "622");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_HP, "1542");
            if (currentEnergy >=energyused) {

				// Application.LoadLevel(Link.PilihCharacter);
				StartCoroutine (kurangEnergy ());
			}
			else {
				NoEnergyGUI.SetActive (true);
			}
			pressed = true;
		}
	}
	//Old_Building
		public void OnOld_Building1 () {
        PlayerPrefs.SetString(Link.StageChoose, "0");
        if (!pressed) {
            PlayerPrefs.SetString(Link.SEARCH_BATTLE, "SINGLE");
            PlayerPrefs.SetString(Link.LOKASI, lokasi);
            PlayerPrefs.SetString(Link.JENIS, "SINGLE");
        if( PlayerPrefs.GetString ("PLAY_TUTORIAL")=="TRUE")
        {
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_FILE, "Pocong_Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ELEMENT, "Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_MODE, "ATTACK");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ATTACK, "443");// 302	442	1518
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_DEFENSE, "327");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_HP, "900");
        }
        else
        {

        	PlayerPrefs.SetString(Link.POS_1_CHAR_1_FILE, "Pocong_Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_FILE, "Pocong_Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_FILE, "Pocong_Wind");

            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ELEMENT, "Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ELEMENT, "Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ELEMENT, "Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_MODE, "ATTACK");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_MODE, "DEFEND");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_MODE, "HP");
            //DISESUAIKAN DENGAN KEBUTUHAN YANG BERSANGKUTAN + EXCEL MAS TONI
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ATTACK, "443");// 302	442	1518
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_DEFENSE, "327");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_HP, "900");

            PlayerPrefs.SetString(Link.POS_1_CHAR_2_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ATTACK, "218");//	322	300	1734
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_DEFENSE, "519");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_HP, "1098");

            PlayerPrefs.SetString(Link.POS_1_CHAR_3_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ATTACK, "271");//	501	355	1332
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_DEFENSE, "385");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_HP, "1252");

        }
          
            if (currentEnergy >= energyused) {
              


              
				//Application.LoadLevel (Link.PilihCharacter);
				StartCoroutine (kurangEnergy ());
			} else {
				NoEnergyGUI.SetActive (true);
			}
			 pressed = true;
		}
	
	}
public void OnOld_Building2 () {
        PlayerPrefs.SetString(Link.StageChoose, "1");
        if (!pressed) {
            PlayerPrefs.SetString(Link.SEARCH_BATTLE, "SINGLE");
            PlayerPrefs.SetString(Link.LOKASI, lokasi);
            PlayerPrefs.SetString(Link.JENIS, "SINGLE");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_FILE, "Pocong_Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_FILE, "Pocong_Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_FILE, "SundelBolong_Wind");

            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ELEMENT, "Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ELEMENT, "Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ELEMENT, "Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_MODE, "DEFEND");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_MODE, "DEFEND");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_MODE, "HP");
            //DISESUAIKAN DENGAN KEBUTUHAN YANG BERSANGKUTAN + EXCEL MAS TONI
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ATTACK, "218");//380 315 1665
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_DEFENSE, "519");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_HP, "1048");

            PlayerPrefs.SetString(Link.POS_1_CHAR_2_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ATTACK, "218");// 456 421 969
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_DEFENSE, "519");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_HP, "1048");

            PlayerPrefs.SetString(Link.POS_1_CHAR_3_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ATTACK, "440");// 330 487 1449
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_DEFENSE, "407");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_HP, "1029");

            if (currentEnergy >= energyused) {
              
          
        //Application.LoadLevel(Link.PilihCharacter);
        			StartCoroutine (kurangEnergy ());
        		}
        		else {
        			NoEnergyGUI.SetActive (true);
        	}	
        pressed = true;}
	}
								public void OnOld_Building3 () {
        PlayerPrefs.SetString(Link.StageChoose, "2");
        if (!pressed) {
            PlayerPrefs.SetString(Link.SEARCH_BATTLE, "SINGLE");
            PlayerPrefs.SetString(Link.LOKASI, lokasi);
            PlayerPrefs.SetString(Link.JENIS, "SINGLE");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_FILE, "Jelangkung_Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_FILE, "Jelangkung_Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_FILE, "Jelangkung_Fire");

            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ELEMENT, "Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ELEMENT, "Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ELEMENT, "Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_MODE, "DEFEND");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_MODE, "ATTACK");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_MODE, "HP");
            //DISESUAIKAN DENGAN KEBUTUHAN YANG BERSANGKUTAN + EXCEL MAS TONI
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ATTACK, "472"); // 370 367 1839
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_DEFENSE, "431");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_HP, "1109");

            PlayerPrefs.SetString(Link.POS_1_CHAR_2_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ATTACK, "352");// 213 511	1428
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_DEFENSE, "494");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_HP, "1280");

            PlayerPrefs.SetString(Link.POS_1_CHAR_3_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ATTACK, "332");//	376	350	1572
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_DEFENSE, "310");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_HP, "1514");
            if (currentEnergy >=energyused) {
	
		
    //   Application.LoadLevel(Link.PilihCharacter);
        			StartCoroutine (kurangEnergy ());
        		}
        		else {
        			NoEnergyGUI.SetActive (true);
        	}
        pressed = true;
	}
	}
	public void OnOld_Building4 () {
        PlayerPrefs.SetString(Link.StageChoose, "3");
        if (!pressed) {

            PlayerPrefs.SetString(Link.SEARCH_BATTLE, "SINGLE");
            PlayerPrefs.SetString(Link.LOKASI, lokasi);
            PlayerPrefs.SetString(Link.JENIS, "SINGLE");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_FILE, "Pocong_Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_FILE, "Jelangkung_Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_FILE, "Pocong_Wind");

            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ELEMENT, "Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ELEMENT, "Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ELEMENT, "Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_MODE, "ATTACK");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_MODE, "HP");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_MODE, "HP");
            //DISESUAIKAN DENGAN KEBUTUHAN YANG BERSANGKUTAN + EXCEL MAS TONI
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ATTACK, "451"); // 370 367 1839
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_DEFENSE, "332");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_HP, "1200");

            PlayerPrefs.SetString(Link.POS_1_CHAR_2_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ATTACK, "332");// 213 511	1428
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_DEFENSE, "310");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_HP, "1315");

            PlayerPrefs.SetString(Link.POS_1_CHAR_3_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ATTACK, "276");//	376	350	1572
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_DEFENSE, "390");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_HP, "1200");
            if (currentEnergy >=energyused) {

				//   Application.LoadLevel(Link.PilihCharacter);
				StartCoroutine (kurangEnergy ());
			}
			else {
				NoEnergyGUI.SetActive (true);
			}
			pressed = true;
		}
	}
	public void OnOld_Building5 () {
        PlayerPrefs.SetString(Link.StageChoose, "4");
        if (!pressed) {
            PlayerPrefs.SetString(Link.SEARCH_BATTLE, "SINGLE");
            PlayerPrefs.SetString(Link.LOKASI, lokasi);
            PlayerPrefs.SetString(Link.JENIS, "SINGLE");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_FILE, "Pocong_Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_FILE, "SundelBolong_Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_FILE, "Jelangkung_Water");

            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ELEMENT, "Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ELEMENT, "Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ELEMENT, "Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_MODE, "DEFEND");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_MODE, "HP");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_MODE, "ATTACK");
            //DISESUAIKAN DENGAN KEBUTUHAN YANG BERSANGKUTAN + EXCEL MAS TONI
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ATTACK, "228"); // 370 367 1839
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_DEFENSE, "535");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_HP, "1338");

            PlayerPrefs.SetString(Link.POS_1_CHAR_2_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ATTACK, "450");// 213 511	1428
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_DEFENSE, "417");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_HP, "1509");

            PlayerPrefs.SetString(Link.POS_1_CHAR_3_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ATTACK, "480");//	376	350	1572
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_DEFENSE, "436");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_HP, "1179");
            if (currentEnergy >=energyused) {

				
				//   Application.LoadLevel(Link.PilihCharacter);
				StartCoroutine (kurangEnergy ());
			}
			else {
				NoEnergyGUI.SetActive (true);
			}
			pressed = true;
		}
	}
	public void OnOld_Building6() {
        PlayerPrefs.SetString(Link.StageChoose, "5");
        if (!pressed) {
            PlayerPrefs.SetString(Link.SEARCH_BATTLE, "SINGLE");
            PlayerPrefs.SetString(Link.LOKASI, lokasi);
            PlayerPrefs.SetString(Link.JENIS, "SINGLE");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_FILE, "Jelangkung_Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_FILE, "Pocong_Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_FILE, "Pocong_Water");

            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ELEMENT, "Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ELEMENT, "Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ELEMENT, "Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_MODE, "DEFEND");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_MODE, "ATTACK");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_MODE, "DEFEND");
            //DISESUAIKAN DENGAN KEBUTUHAN YANG BERSANGKUTAN + EXCEL MAS TONI
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ATTACK, "357"); // 370 367 1839
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_DEFENSE, "502");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_HP, "1150");

            PlayerPrefs.SetString(Link.POS_1_CHAR_2_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ATTACK, "459");// 213 511	1428
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_DEFENSE, "337");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_HP, "1128");

            PlayerPrefs.SetString(Link.POS_1_CHAR_3_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ATTACK, "228");//	376	350	1572
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_DEFENSE, "535");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_HP, "1638");
            if (currentEnergy >=energyused) {

				
				//   Application.LoadLevel(Link.PilihCharacter);
				StartCoroutine (kurangEnergy ());
			}
			else {
				NoEnergyGUI.SetActive (true);
			}
			pressed = true;
		}
	}
	//Bridge
									public void OnBridge1 () {
        PlayerPrefs.SetString(Link.StageChoose, "18");
        if (!pressed) {
            PlayerPrefs.SetString(Link.SEARCH_BATTLE, "SINGLE");
            PlayerPrefs.SetString(Link.LOKASI, lokasi);
            PlayerPrefs.SetString(Link.JENIS, "SINGLE");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_FILE, "Mukarata_Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_FILE, "SundelBolong_Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_FILE, "Pocong_Water");

            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ELEMENT, "Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ELEMENT, "Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ELEMENT, "Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_MODE, "DEFEND");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_MODE, "ATTACK");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_MODE, "DEFEND");
            //DISESUAIKAN DENGAN KEBUTUHAN YANG BERSANGKUTAN + EXCEL MAS TONI
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ATTACK, "451");// 302	442	1518
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_DEFENSE, "563");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_HP, "1948");

            PlayerPrefs.SetString(Link.POS_1_CHAR_2_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ATTACK, "485");//	322	300	1734
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_DEFENSE, "452");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_HP, "2439");

            PlayerPrefs.SetString(Link.POS_1_CHAR_3_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ATTACK, "263");//	501	355	1332
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_DEFENSE, "591");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_HP, "2128");
            if (currentEnergy >=energyused) {
		
	
   //     Application.LoadLevel(Link.PilihCharacter);
        			StartCoroutine (kurangEnergy ());
        		}
        		else {
        			NoEnergyGUI.SetActive (true);
        	}
        pressed = true;
	}
	}
										public void OnBridge2 () {
        PlayerPrefs.SetString(Link.StageChoose, "19");
        if (!pressed) {
            PlayerPrefs.SetString(Link.SEARCH_BATTLE, "SINGLE");
            PlayerPrefs.SetString(Link.LOKASI, lokasi);
            PlayerPrefs.SetString(Link.JENIS, "SINGLE");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_FILE, "Mukarata_Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_FILE, "Kolorijo_Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_FILE, "Pocong_Water");

            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ELEMENT, "Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ELEMENT, "Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ELEMENT, "Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_MODE, "HP");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_MODE, "DEFEND");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_MODE, "DEFEND");
            //DISESUAIKAN DENGAN KEBUTUHAN YANG BERSANGKUTAN + EXCEL MAS TONI
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ATTACK, "426");//380 315 1665
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_DEFENSE, "434");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_HP, "2520");

            PlayerPrefs.SetString(Link.POS_1_CHAR_2_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ATTACK, "380");// 456 421 969
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_DEFENSE, "567");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_HP, "2149");

            PlayerPrefs.SetString(Link.POS_1_CHAR_3_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ATTACK, "263");// 330 487 1449
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_DEFENSE, "591");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_HP, "2128");
            if (currentEnergy >= energyused) {

				
				// Application.LoadLevel(Link.PilihCharacter);
				StartCoroutine (kurangEnergy ());
			} else {
				NoEnergyGUI.SetActive (true);
			}
			 pressed = true;
		}
	}
											public void OnBridge3 () {
        PlayerPrefs.SetString(Link.StageChoose, "20");
        if (!pressed) {
            PlayerPrefs.SetString(Link.SEARCH_BATTLE, "SINGLE");
            PlayerPrefs.SetString(Link.LOKASI, lokasi);
            PlayerPrefs.SetString(Link.JENIS, "SINGLE");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_FILE, "Mukarata_Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_FILE, "Pocong_Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_FILE, "Mukarata_Fire");

            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ELEMENT, "Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ELEMENT, "Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ELEMENT, "Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_MODE, "ATTACK");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_MODE, "ATTACK");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_MODE, "DEFEND");
            //DISESUAIKAN DENGAN KEBUTUHAN YANG BERSANGKUTAN + EXCEL MAS TONI
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ATTACK, "597"); // 370 367 1839
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_DEFENSE, "489");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_HP, "1841");

            PlayerPrefs.SetString(Link.POS_1_CHAR_2_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ATTACK, "523");// 213 511	1428
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_DEFENSE, "377");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_HP, "2099");

            PlayerPrefs.SetString(Link.POS_1_CHAR_3_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ATTACK, "456");//	376	350	1572
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_DEFENSE, "571");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_HP, "2018");
            if (currentEnergy >= energyused) {
				
				
				//Application.LoadLevel(Link.PilihCharacter);
				StartCoroutine (kurangEnergy ());
			} else {
				NoEnergyGUI.SetActive (true);
			}
			 pressed = true;
		}
	}
	public void OnBridge4 () {
        PlayerPrefs.SetString(Link.StageChoose, "21");
        if (!pressed) {
            PlayerPrefs.SetString(Link.SEARCH_BATTLE, "SINGLE");
            PlayerPrefs.SetString(Link.LOKASI, lokasi);
            PlayerPrefs.SetString(Link.JENIS, "SINGLE");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_FILE, "Hantutanpakepala_Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_FILE, "Hantutanpakepala_Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_FILE, "Mukarata_Water");

            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ELEMENT, "Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ELEMENT, "Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ELEMENT, "Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_MODE, "DEFEND");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_MODE, "DEFEND");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_MODE, "HP");
            //DISESUAIKAN DENGAN KEBUTUHAN YANG BERSANGKUTAN + EXCEL MAS TONI
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ATTACK, "375"); // 370 367 1839
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_DEFENSE, "610");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_HP, "2144");

            PlayerPrefs.SetString(Link.POS_1_CHAR_2_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ATTACK, "375");// 213 511	1428
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_DEFENSE, "610");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_HP, "2144");

            PlayerPrefs.SetString(Link.POS_1_CHAR_3_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ATTACK, "431");//	376	350	1572
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_DEFENSE, "439");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_HP, "2610");
            if (currentEnergy >= energyused) {

				
				//Application.LoadLevel(Link.PilihCharacter);
				StartCoroutine (kurangEnergy ());
			} else {
				NoEnergyGUI.SetActive (true);
			}
			pressed = true;
		}
	}
	public void OnBridge5 () {
        PlayerPrefs.SetString(Link.StageChoose, "22");
        if (!pressed) {
            PlayerPrefs.SetString(Link.SEARCH_BATTLE, "SINGLE");
            PlayerPrefs.SetString(Link.LOKASI, lokasi);
            PlayerPrefs.SetString(Link.JENIS, "SINGLE");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_FILE, "Kolorijo_Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_FILE, "Pocong_Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_FILE, "Mukarata_Wind");

            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ELEMENT, "Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ELEMENT, "Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ELEMENT, "Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_MODE, "HP");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_MODE, "HP");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_MODE, "ATTACK");
            //DISESUAIKAN DENGAN KEBUTUHAN YANG BERSANGKUTAN + EXCEL MAS TONI
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ATTACK, "389"); // 370 367 1839
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_DEFENSE, "378");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_HP, "2679");

            PlayerPrefs.SetString(Link.POS_1_CHAR_2_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ATTACK, "326");// 213 511	1428
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_DEFENSE, "440");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_HP, "2742");

            PlayerPrefs.SetString(Link.POS_1_CHAR_3_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ATTACK, "605");//	376	350	1572
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_DEFENSE, "494");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_HP, "1911");
            if (currentEnergy >= energyused) {

			
				//Application.LoadLevel(Link.PilihCharacter);
				StartCoroutine (kurangEnergy ());
			} else {
				NoEnergyGUI.SetActive (true);
			}
			pressed = true;
		}
	}
	public void OnBridge6 () {
        PlayerPrefs.SetString(Link.StageChoose, "23");
        if (!pressed) {
            PlayerPrefs.SetString(Link.SEARCH_BATTLE, "SINGLE");
            PlayerPrefs.SetString(Link.LOKASI, lokasi);
            PlayerPrefs.SetString(Link.JENIS, "SINGLE");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_FILE, "Mukarata_Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_FILE, "Mukarata_Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_FILE, "Mukarata_Water");

            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ELEMENT, "Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ELEMENT, "Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ELEMENT, "Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_MODE, "HP");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_MODE, "HP");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_MODE, "HP");
            //DISESUAIKAN DENGAN KEBUTUHAN YANG BERSANGKUTAN + EXCEL MAS TONI
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ATTACK, "436"); // 370 367 1839
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_DEFENSE, "444");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_HP, "2700");

            PlayerPrefs.SetString(Link.POS_1_CHAR_2_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ATTACK, "436");// 213 511	1428
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_DEFENSE, "444");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_HP, "2700");

            PlayerPrefs.SetString(Link.POS_1_CHAR_3_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ATTACK, "436");//	376	350	1572
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_DEFENSE, "444");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_HP, "2700");
            if (currentEnergy >= energyused) {

				
				//Application.LoadLevel(Link.PilihCharacter);
				StartCoroutine (kurangEnergy ());
			} else {
				NoEnergyGUI.SetActive (true);
			}
			pressed = true;
		}
	}
	//Graveyard
	public void OnGraveyard1 () {
        PlayerPrefs.SetString(Link.StageChoose, "24");
        if (!pressed) {

            PlayerPrefs.SetString(Link.SEARCH_BATTLE, "SINGLE");
            PlayerPrefs.SetString(Link.LOKASI, lokasi);
            PlayerPrefs.SetString(Link.JENIS, "SINGLE");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_FILE, "Kolorijo_Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_FILE, "Hantutanpakepala_Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_FILE, "Genderuwo_Fire");

            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ELEMENT, "Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ELEMENT, "Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ELEMENT, "Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_MODE, "DEFEND");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_MODE, "DEFEND");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_MODE, "ATTACK");
            //DISESUAIKAN DENGAN KEBUTUHAN YANG BERSANGKUTAN + EXCEL MAS TONI
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ATTACK, "395");// 302	442	1518
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_DEFENSE, "591");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_HP, "2359");

            PlayerPrefs.SetString(Link.POS_1_CHAR_2_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ATTACK, "385");//	322	300	1734
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_DEFENSE, "626");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_HP, "2284");

            PlayerPrefs.SetString(Link.POS_1_CHAR_3_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ATTACK, "656");//	501	355	1332
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_DEFENSE, "515");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_HP, "1954");
            if (currentEnergy >= energyused) {
			
				//     Application.LoadLevel(Link.PilihCharacter);
				StartCoroutine (kurangEnergy ());
			} else {
				NoEnergyGUI.SetActive (true);
			}
			 pressed = true;
		}
	}
	public void OnGraveyard2 () {
        PlayerPrefs.SetString(Link.StageChoose, "25");
        if (!pressed) {
            PlayerPrefs.SetString(Link.SEARCH_BATTLE, "SINGLE");
            PlayerPrefs.SetString(Link.LOKASI, lokasi);
            PlayerPrefs.SetString(Link.JENIS, "SINGLE");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_FILE, "Genderuwo_Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_FILE, "Pocong_Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_FILE, "Genderuwo_Water");

            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ELEMENT, "Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ELEMENT, "Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ELEMENT, "Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_MODE, "DEFEND");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_MODE, "ATTACK");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_MODE, "DEFEND");
            //DISESUAIKAN DENGAN KEBUTUHAN YANG BERSANGKUTAN + EXCEL MAS TONI
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ATTACK, "467");//380 315 1665
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_DEFENSE, "592");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_HP, "2290");

            PlayerPrefs.SetString(Link.POS_1_CHAR_2_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ATTACK, "539");// 456 421 969
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_DEFENSE, "387");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_HP, "2239");

            PlayerPrefs.SetString(Link.POS_1_CHAR_3_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ATTACK, "467");// 330 487 1449
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_DEFENSE, "592");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_HP, "2290");
            if (currentEnergy >= energyused) {
				
				
				// Application.LoadLevel(Link.PilihCharacter);
				StartCoroutine (kurangEnergy ());
			} else {
				NoEnergyGUI.SetActive (true);
			}
			 pressed = true;
		}
	}
	public void OnGraveyard3 ()
    {
        PlayerPrefs.SetString(Link.StageChoose, "26");
        if (!pressed) {
            PlayerPrefs.SetString(Link.SEARCH_BATTLE, "SINGLE");
            PlayerPrefs.SetString(Link.LOKASI, lokasi);
            PlayerPrefs.SetString(Link.JENIS, "SINGLE");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_FILE, "Jin_Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_FILE, "Jin_Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_FILE, "Jin_Fire");

            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ELEMENT, "Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ELEMENT, "Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ELEMENT, "Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_MODE, "HP");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_MODE, "HP");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_MODE, "HP");
            //DISESUAIKAN DENGAN KEBUTUHAN YANG BERSANGKUTAN + EXCEL MAS TONI
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ATTACK, "375"); // 370 367 1839
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_DEFENSE, "418");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_HP, "3201");

            PlayerPrefs.SetString(Link.POS_1_CHAR_2_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ATTACK, "375");// 213 511	1428
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_DEFENSE, "418");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_HP, "3201");

            PlayerPrefs.SetString(Link.POS_1_CHAR_3_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ATTACK, "375");//	376	350	1572
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_DEFENSE, "418");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_HP, "3201");
            if (currentEnergy >= energyused) {
				
			
				//  Application.LoadLevel(Link.PilihCharacter);
				StartCoroutine (kurangEnergy ());
			} else {
				NoEnergyGUI.SetActive (true);
			}
			 pressed = true;
		}
	}
	public void OnGraveyard4 ()
    {
        PlayerPrefs.SetString(Link.StageChoose, "27");
        if (!pressed) {
            PlayerPrefs.SetString(Link.SEARCH_BATTLE, "SINGLE");
            PlayerPrefs.SetString(Link.LOKASI, lokasi);
            PlayerPrefs.SetString(Link.JENIS, "SINGLE");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_FILE, "Hantutanpakepala_Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_FILE, "Genderuwo_Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_FILE, "Hantutanpakepala_Fire");

            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ELEMENT, "Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ELEMENT, "Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ELEMENT, "Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_MODE, "HP");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_MODE, "DEFEND");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_MODE, "HP");
            //DISESUAIKAN DENGAN KEBUTUHAN YANG BERSANGKUTAN + EXCEL MAS TONI
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ATTACK, "426"); // 370 367 1839
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_DEFENSE, "415");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_HP, "3057");

            PlayerPrefs.SetString(Link.POS_1_CHAR_2_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ATTACK, "472");// 213 511	1428
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_DEFENSE, "600");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_HP, "2360");

            PlayerPrefs.SetString(Link.POS_1_CHAR_3_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ATTACK, "426");//	376	350	1572
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_DEFENSE, "415");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_HP, "3057");
            if (currentEnergy >= energyused) {

			
				//  Application.LoadLevel(Link.PilihCharacter);
				StartCoroutine (kurangEnergy ());
			} else {
				NoEnergyGUI.SetActive (true);
			}
			pressed = true;
		}
	}
	public void OnGraveyard5 ()
    {
        PlayerPrefs.SetString(Link.StageChoose, "28");
        if (!pressed) {
            PlayerPrefs.SetString(Link.SEARCH_BATTLE, "SINGLE");
            PlayerPrefs.SetString(Link.LOKASI, lokasi);
            PlayerPrefs.SetString(Link.JENIS, "SINGLE");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_FILE, "Mukarata_Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_FILE, "Genderuwo_Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_FILE, "Mukarata_Water");

            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ELEMENT, "Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ELEMENT, "Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ELEMENT, "Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_MODE, "HP");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_MODE, "HP");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_MODE, "HP");
            //DISESUAIKAN DENGAN KEBUTUHAN YANG BERSANGKUTAN + EXCEL MAS TONI
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ATTACK, "451"); // 370 367 1839
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_DEFENSE, "459");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_HP, "2970");

            PlayerPrefs.SetString(Link.POS_1_CHAR_2_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ATTACK, "420");// 213 511	1428
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_DEFENSE, "442");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_HP, "3264");

            PlayerPrefs.SetString(Link.POS_1_CHAR_3_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ATTACK, "451");//	376	350	1572
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_DEFENSE, "459");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_HP, "2970");
            if (currentEnergy >= energyused) {

				
				//  Application.LoadLevel(Link.PilihCharacter);
				StartCoroutine (kurangEnergy ());
			} else {
				NoEnergyGUI.SetActive (true);
			}
			pressed = true;
		}
	}
	public void OnGraveyard6 ()
    {
        PlayerPrefs.SetString(Link.StageChoose, "29");
        if (!pressed) {

            PlayerPrefs.SetString(Link.SEARCH_BATTLE, "SINGLE");
            PlayerPrefs.SetString(Link.LOKASI, lokasi);
            PlayerPrefs.SetString(Link.JENIS, "SINGLE");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_FILE, "Genderuwo_Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_FILE, "Kunti_Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_FILE, "SusterNgesot_Water");

            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ELEMENT, "Fire");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ELEMENT, "Water");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ELEMENT, "Wind");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_MODE, "ATTACK");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_MODE, "ATTACK");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_MODE, "HP");
            //DISESUAIKAN DENGAN KEBUTUHAN YANG BERSANGKUTAN + EXCEL MAS TONI
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_ATTACK, "672"); // 370 367 1839  , "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_DEFENSE, "525");
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_HP, "2394");

            PlayerPrefs.SetString(Link.POS_1_CHAR_2_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ATTACK, "700");// 213 511	1428
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_DEFENSE, "429");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_HP, "2598");

            PlayerPrefs.SetString(Link.POS_1_CHAR_3_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ATTACK, "461");//	376	350	1572
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_DEFENSE, "463");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_HP, "3078");
            if (currentEnergy >= energyused) {

				//  Application.LoadLevel(Link.PilihCharacter);
				StartCoroutine (kurangEnergy ());
			} else {
				NoEnergyGUI.SetActive (true);
			}
			pressed = true;
		}
	}
	//WareHouse
	public void OnWarehouse1 () {
        PlayerPrefs.SetString(Link.StageChoose, "30");
        if (!pressed) {
			if (currentEnergy >= energyused) {

				PlayerPrefs.SetString (Link.SEARCH_BATTLE, "SINGLE");
				PlayerPrefs.SetString (Link.LOKASI, lokasi);
				PlayerPrefs.SetString (Link.JENIS, "SINGLE");
				PlayerPrefs.SetString (Link.POS_1_CHAR_1_FILE, "Babingepet_Fire");
				PlayerPrefs.SetString (Link.POS_1_CHAR_2_FILE, "Jelangkung_Fire");
				PlayerPrefs.SetString (Link.POS_1_CHAR_3_FILE, "Kolorijo_Fire");

				PlayerPrefs.SetString (Link.POS_1_CHAR_1_ELEMENT, "Fire");
				PlayerPrefs.SetString (Link.POS_1_CHAR_2_ELEMENT, "Fire");
				PlayerPrefs.SetString (Link.POS_1_CHAR_3_ELEMENT, "Fire");
				//DISESUAIKAN DENGAN KEBUTUHAN YANG BERSANGKUTAN + EXCEL MAS TONI
				PlayerPrefs.SetString (Link.POS_1_CHAR_1_GRADE, "1");
				PlayerPrefs.SetString (Link.POS_1_CHAR_1_LEVEL, "1");
				PlayerPrefs.SetString (Link.POS_1_CHAR_1_ATTACK, "302");// 302	442	1518
				PlayerPrefs.SetString (Link.POS_1_CHAR_1_DEFENSE, "442");
				PlayerPrefs.SetString (Link.POS_1_CHAR_1_HP, "1518");

				PlayerPrefs.SetString (Link.POS_1_CHAR_2_GRADE, "1");
				PlayerPrefs.SetString (Link.POS_1_CHAR_2_LEVEL, "1");
				PlayerPrefs.SetString (Link.POS_1_CHAR_2_ATTACK, "322");//	322	300	1734
				PlayerPrefs.SetString (Link.POS_1_CHAR_2_DEFENSE, "300");
				PlayerPrefs.SetString (Link.POS_1_CHAR_2_HP, "1734");

				PlayerPrefs.SetString (Link.POS_1_CHAR_3_GRADE, "1");
				PlayerPrefs.SetString (Link.POS_1_CHAR_3_LEVEL, "1");
				PlayerPrefs.SetString (Link.POS_1_CHAR_3_ATTACK, "501");//	501	355	1332
				PlayerPrefs.SetString (Link.POS_1_CHAR_3_DEFENSE, "355");
				PlayerPrefs.SetString (Link.POS_1_CHAR_3_HP, "1332");
				//  Application.LoadLevel(Link.PilihCharacter);
				StartCoroutine (kurangEnergy ());
			} else {
				NoEnergyGUI.SetActive (true);
			}
			 pressed = true;
		}
	}
	public void OnWarehouse2 () {
        PlayerPrefs.SetString(Link.StageChoose, "31");
        if (!pressed) {
			if (currentEnergy >= energyused) {

				PlayerPrefs.SetString (Link.SEARCH_BATTLE, "SINGLE");
				PlayerPrefs.SetString (Link.LOKASI, lokasi);
				PlayerPrefs.SetString (Link.JENIS, "SINGLE");
				PlayerPrefs.SetString (Link.POS_1_CHAR_1_FILE, "Babingepet_Water");
				PlayerPrefs.SetString (Link.POS_1_CHAR_2_FILE, "Jelangkung_Water");
				PlayerPrefs.SetString (Link.POS_1_CHAR_3_FILE, "Kolorijo_Water");

				PlayerPrefs.SetString (Link.POS_1_CHAR_1_ELEMENT, "Water");
				PlayerPrefs.SetString (Link.POS_1_CHAR_2_ELEMENT, "Water");
				PlayerPrefs.SetString (Link.POS_1_CHAR_3_ELEMENT, "Water");
				//DISESUAIKAN DENGAN KEBUTUHAN YANG BERSANGKUTAN + EXCEL MAS TONI
				PlayerPrefs.SetString (Link.POS_1_CHAR_1_GRADE, "1");
				PlayerPrefs.SetString (Link.POS_1_CHAR_1_LEVEL, "1");
				PlayerPrefs.SetString (Link.POS_1_CHAR_1_ATTACK, "380");//380 315 1665
				PlayerPrefs.SetString (Link.POS_1_CHAR_1_DEFENSE, "315");
				PlayerPrefs.SetString (Link.POS_1_CHAR_1_HP, "1665");

				PlayerPrefs.SetString (Link.POS_1_CHAR_2_GRADE, "1");
				PlayerPrefs.SetString (Link.POS_1_CHAR_2_LEVEL, "1");
				PlayerPrefs.SetString (Link.POS_1_CHAR_2_ATTACK, "456");// 456 421 969
				PlayerPrefs.SetString (Link.POS_1_CHAR_2_DEFENSE, "421");
				PlayerPrefs.SetString (Link.POS_1_CHAR_2_HP, "969");

				PlayerPrefs.SetString (Link.POS_1_CHAR_3_GRADE, "1");
				PlayerPrefs.SetString (Link.POS_1_CHAR_3_LEVEL, "1");
				PlayerPrefs.SetString (Link.POS_1_CHAR_3_ATTACK, "330");// 330 487 1449
				PlayerPrefs.SetString (Link.POS_1_CHAR_3_DEFENSE, "487");
				PlayerPrefs.SetString (Link.POS_1_CHAR_3_HP, "1449");
				//   Application.LoadLevel(Link.PilihCharacter);
				StartCoroutine (kurangEnergy ());
			} else {
				NoEnergyGUI.SetActive (true);
			}
			 pressed = true;
		}
	}
	public void OnWarehouse3 () {
        PlayerPrefs.SetString(Link.StageChoose, "32");
        if (!pressed) {
			if (currentEnergy >= energyused) {
				
				PlayerPrefs.SetString (Link.SEARCH_BATTLE, "SINGLE");
				PlayerPrefs.SetString (Link.LOKASI, lokasi);
				PlayerPrefs.SetString (Link.JENIS, "SINGLE");
				PlayerPrefs.SetString (Link.POS_1_CHAR_1_FILE, "Kunti_fire");
				PlayerPrefs.SetString (Link.POS_1_CHAR_2_FILE, "Leak_Water");
				PlayerPrefs.SetString (Link.POS_1_CHAR_3_FILE, "Genderuwo_Wind");

				PlayerPrefs.SetString (Link.POS_1_CHAR_1_ELEMENT, "Fire");
				PlayerPrefs.SetString (Link.POS_1_CHAR_2_ELEMENT, "Water");
				PlayerPrefs.SetString (Link.POS_1_CHAR_3_ELEMENT, "Wind");
				//DISESUAIKAN DENGAN KEBUTUHAN YANG BERSANGKUTAN + EXCEL MAS TONI
				PlayerPrefs.SetString (Link.POS_1_CHAR_1_GRADE, "1");
				PlayerPrefs.SetString (Link.POS_1_CHAR_1_LEVEL, "1");
				PlayerPrefs.SetString (Link.POS_1_CHAR_1_ATTACK, "370"); // 370 367 1839
				PlayerPrefs.SetString (Link.POS_1_CHAR_1_DEFENSE, "367");
				PlayerPrefs.SetString (Link.POS_1_CHAR_1_HP, "1839");

				PlayerPrefs.SetString (Link.POS_1_CHAR_2_GRADE, "1");
				PlayerPrefs.SetString (Link.POS_1_CHAR_2_LEVEL, "1");
				PlayerPrefs.SetString (Link.POS_1_CHAR_2_ATTACK, "213");// 213 511	1428
				PlayerPrefs.SetString (Link.POS_1_CHAR_2_DEFENSE, "511");
				PlayerPrefs.SetString (Link.POS_1_CHAR_2_HP, "1428");

				PlayerPrefs.SetString (Link.POS_1_CHAR_3_GRADE, "1");
				PlayerPrefs.SetString (Link.POS_1_CHAR_3_LEVEL, "1");
				PlayerPrefs.SetString (Link.POS_1_CHAR_3_ATTACK, "376");//	376	350	1572
				PlayerPrefs.SetString (Link.POS_1_CHAR_3_DEFENSE, "350");
				PlayerPrefs.SetString (Link.POS_1_CHAR_3_HP, "1572");
//        Application.LoadLevel(Link.PilihCharacter);
				StartCoroutine (kurangEnergy ());
			} else {
				NoEnergyGUI.SetActive (true);
			}
			 pressed = true;
		}
	}
	public void OnWarehouse4 () {
        PlayerPrefs.SetString(Link.StageChoose, "33");
        if (!pressed) {
			if (currentEnergy >= energyused) {

				PlayerPrefs.SetString (Link.SEARCH_BATTLE, "SINGLE");
				PlayerPrefs.SetString (Link.LOKASI, lokasi);
				PlayerPrefs.SetString (Link.JENIS, "SINGLE");
				PlayerPrefs.SetString (Link.POS_1_CHAR_1_FILE, "Zombie_Fire");
				PlayerPrefs.SetString (Link.POS_1_CHAR_2_FILE, "Zombie_Water");
				PlayerPrefs.SetString (Link.POS_1_CHAR_3_FILE, "Zombie_Wind");

				PlayerPrefs.SetString (Link.POS_1_CHAR_1_ELEMENT, "Fire");
				PlayerPrefs.SetString (Link.POS_1_CHAR_2_ELEMENT, "Water");
				PlayerPrefs.SetString (Link.POS_1_CHAR_3_ELEMENT, "Wind");
				//DISESUAIKAN DENGAN KEBUTUHAN YANG BERSANGKUTAN + EXCEL MAS TONI
				PlayerPrefs.SetString (Link.POS_1_CHAR_1_GRADE, "1");
				PlayerPrefs.SetString (Link.POS_1_CHAR_1_LEVEL, "1");
				PlayerPrefs.SetString (Link.POS_1_CHAR_1_ATTACK, "365"); // 370 367 1839
				PlayerPrefs.SetString (Link.POS_1_CHAR_1_DEFENSE, "366");
				PlayerPrefs.SetString (Link.POS_1_CHAR_1_HP, "1857");

				PlayerPrefs.SetString (Link.POS_1_CHAR_2_GRADE, "1");
				PlayerPrefs.SetString (Link.POS_1_CHAR_2_LEVEL, "1");
				PlayerPrefs.SetString (Link.POS_1_CHAR_2_ATTACK, "477");// 213 511	1428
				PlayerPrefs.SetString (Link.POS_1_CHAR_2_DEFENSE, "433");
				PlayerPrefs.SetString (Link.POS_1_CHAR_2_HP, "1320");

				PlayerPrefs.SetString (Link.POS_1_CHAR_3_GRADE, "1");
				PlayerPrefs.SetString (Link.POS_1_CHAR_3_LEVEL, "1");
				PlayerPrefs.SetString (Link.POS_1_CHAR_3_ATTACK, "379");//	376	350	1572
				PlayerPrefs.SetString (Link.POS_1_CHAR_3_DEFENSE, "478");
				PlayerPrefs.SetString (Link.POS_1_CHAR_3_HP, "1479");
				//        Application.LoadLevel(Link.PilihCharacter);
				StartCoroutine (kurangEnergy ());
			} else {
				NoEnergyGUI.SetActive (true);
			}
			pressed = true;
		}
	}
	public void OnWarehouse5 () {
        PlayerPrefs.SetString(Link.StageChoose, "34");
        if (!pressed) {
			if (currentEnergy >= energyused) {

				PlayerPrefs.SetString (Link.SEARCH_BATTLE, "SINGLE");
				PlayerPrefs.SetString (Link.LOKASI, lokasi);
				PlayerPrefs.SetString (Link.JENIS, "SINGLE");
				PlayerPrefs.SetString (Link.POS_1_CHAR_1_FILE, "NagaBesukih_Water");
				PlayerPrefs.SetString (Link.POS_1_CHAR_2_FILE, "Jerangkong_Water");
				PlayerPrefs.SetString (Link.POS_1_CHAR_3_FILE, "Palasik_Water");

				PlayerPrefs.SetString (Link.POS_1_CHAR_1_ELEMENT, "Water");
				PlayerPrefs.SetString (Link.POS_1_CHAR_2_ELEMENT, "Water");
				PlayerPrefs.SetString (Link.POS_1_CHAR_3_ELEMENT, "Water");
				//DISESUAIKAN DENGAN KEBUTUHAN YANG BERSANGKUTAN + EXCEL MAS TONI
				PlayerPrefs.SetString (Link.POS_1_CHAR_1_GRADE, "1");
				PlayerPrefs.SetString (Link.POS_1_CHAR_1_LEVEL, "1");
				PlayerPrefs.SetString (Link.POS_1_CHAR_1_ATTACK, "411"); // 370 367 1839
				PlayerPrefs.SetString (Link.POS_1_CHAR_1_DEFENSE, "420");
				PlayerPrefs.SetString (Link.POS_1_CHAR_1_HP, "1807");

				PlayerPrefs.SetString (Link.POS_1_CHAR_2_GRADE, "1");
				PlayerPrefs.SetString (Link.POS_1_CHAR_2_LEVEL, "1");
				PlayerPrefs.SetString (Link.POS_1_CHAR_2_ATTACK, "420");// 213 511	1428
				PlayerPrefs.SetString (Link.POS_1_CHAR_2_DEFENSE, "611");
				PlayerPrefs.SetString (Link.POS_1_CHAR_2_HP, "1307");

				PlayerPrefs.SetString (Link.POS_1_CHAR_3_GRADE, "1");
				PlayerPrefs.SetString (Link.POS_1_CHAR_3_LEVEL, "1");
				PlayerPrefs.SetString (Link.POS_1_CHAR_3_ATTACK, "500");//	376	350	1572
				PlayerPrefs.SetString (Link.POS_1_CHAR_3_DEFENSE, "420");
				PlayerPrefs.SetString (Link.POS_1_CHAR_3_HP, "1542");
				//        Application.LoadLevel(Link.PilihCharacter);
				StartCoroutine (kurangEnergy ());
			} else {
				NoEnergyGUI.SetActive (true);
			}
			pressed = true;
		}
	}
	public void OnWarehouse6 () {
        PlayerPrefs.SetString(Link.StageChoose, "35");
        if (!pressed) {
			if (currentEnergy >= energyused) {

				PlayerPrefs.SetString (Link.SEARCH_BATTLE, "SINGLE");
				PlayerPrefs.SetString (Link.LOKASI, lokasi);
				PlayerPrefs.SetString (Link.JENIS, "SINGLE");
				PlayerPrefs.SetString (Link.POS_1_CHAR_1_FILE, "NagaBesukih_Wind");
				PlayerPrefs.SetString (Link.POS_1_CHAR_2_FILE, "Jerangkong_Fire");
				PlayerPrefs.SetString (Link.POS_1_CHAR_3_FILE, "Nyiroro_Water");

				PlayerPrefs.SetString (Link.POS_1_CHAR_1_ELEMENT, "Wind");
				PlayerPrefs.SetString (Link.POS_1_CHAR_2_ELEMENT, "Fire");
				PlayerPrefs.SetString (Link.POS_1_CHAR_3_ELEMENT, "Water");
				//DISESUAIKAN DENGAN KEBUTUHAN YANG BERSANGKUTAN + EXCEL MAS TONI
				PlayerPrefs.SetString (Link.POS_1_CHAR_1_GRADE, "1");
				PlayerPrefs.SetString (Link.POS_1_CHAR_1_LEVEL, "1");
				PlayerPrefs.SetString (Link.POS_1_CHAR_1_ATTACK, "602"); // 370 367 1839
				PlayerPrefs.SetString (Link.POS_1_CHAR_1_DEFENSE, "365");
				PlayerPrefs.SetString (Link.POS_1_CHAR_1_HP, "1839");

				PlayerPrefs.SetString (Link.POS_1_CHAR_2_GRADE, "1");
				PlayerPrefs.SetString (Link.POS_1_CHAR_2_LEVEL, "1");
				PlayerPrefs.SetString (Link.POS_1_CHAR_2_ATTACK, "621");// 213 511	1428
				PlayerPrefs.SetString (Link.POS_1_CHAR_2_DEFENSE, "340");
				PlayerPrefs.SetString (Link.POS_1_CHAR_2_HP, "1428");

				PlayerPrefs.SetString (Link.POS_1_CHAR_3_GRADE, "1");
				PlayerPrefs.SetString (Link.POS_1_CHAR_3_LEVEL, "1");
				PlayerPrefs.SetString (Link.POS_1_CHAR_3_ATTACK, "376");//	376	350	1572
				PlayerPrefs.SetString (Link.POS_1_CHAR_3_DEFENSE, "354");
				PlayerPrefs.SetString (Link.POS_1_CHAR_3_HP, "2010");
				//        Application.LoadLevel(Link.PilihCharacter);
				StartCoroutine (kurangEnergy ());
			} else {
				NoEnergyGUI.SetActive (true);
			}
			pressed = true;
		}
	}
		
	public void OnBack () {
		// if (PlayerPrefs.GetString ("Tutorgame") == "TRUE") {
		// 	PlayerPrefs.SetString ("PLAY_TUTORIAL","FALSE");
		// 	PlayerPrefs.SetString ("lewat","ya");
		// }
		SceneManagerHelper.LoadScene ("Home");
		//Loadscene.GetComponent<SceneLoader> ().LoadingScreeen ();
	}
		
	public void noEnergy(){
		SceneManagerHelper.LoadScene (Link.Home);
		PlayerPrefs.SetString ("GoShop", "yes");
	}
    public IEnumerator GetStageDrop (string name)
	{
		string url = Link.url + "getStageDrop";
		WWWForm form = new WWWForm ();
		form.AddField (Link.ID, PlayerPrefs.GetString(Link.ID));
        form.AddField("DID", PlayerPrefs.GetString(Link.DEVICE_ID));
        form.AddField("StageName", name);
        WWW www = new WWW(url,form);
		yield return www;
        Debug.Log (www.text);
		if (www.error == null) {

			var jsonString = JSON.Parse (www.text);
			Debug.Log (www.text);
			PlayerPrefs.SetString (Link.FOR_CONVERTING, jsonString["code"]);
			if (PlayerPrefs.GetString(Link.FOR_CONVERTING)=="1") {
			dropItemName = new string[18];
            dropItemRate = new string[18];
            dropItemQuantity = new string[18];
            dropItemFileName = new string[18];
            dropItemType = new string[18];
        int i=0;
            for(int j=0; j<6;j++)
         {
             for(int k=0; k<3;k++)
         {
                 dropItemQuantity[i]=jsonString["ItemName"][j][k]["Quantity"];
                 dropItemType[i]=jsonString["ItemName"][j][k]["Type"];
                 dropItemFileName[i]=jsonString["ItemName"][j][k]["FileName"];
                 dropItemName[i]=jsonString["ItemName"][j][k]["Name"];                 
                 dropItemRate[i]=jsonString["ItemRate"][j][k];
                
         i++;
         }
         }
             
         
        
           
           
			}
            else if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == "33")
            {
                ValidationError.SetActive(true);
            }
        } else {
			Debug.Log ("GAGAL");
		}
	}

    	public void On_Start () {
        if (!pressed) {
        
        }
          
            if (currentEnergy >= energyused) {
              


              
				//Application.LoadLevel (Link.PilihCharacter);
				StartCoroutine (kurangEnergy ());
			} else {
				NoEnergyGUI.SetActive (true);
			}
			 pressed = true;
		}
	
	

}

