using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using SimpleJSON;
using UnityEngine;

public class MapList : MonoBehaviour {
	public GameObject NoEnergyGUI ;
	public bool pressed;
    private Game GameScript;
	public int currentEnergy, MaxEnergy,energyused;
	lifeless lf;
	// Use this for initialization
	public string lokasi = "";
	void Start () {
		GameScript = GetComponent<Game>();
		lokasi = PlayerPrefs.GetString (Link.LOKASI);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

// private IEnumerator kurangEnergy ()
// 	{
// 		string url = Link.url + "energy";
// 		WWWForm form = new WWWForm ();
// 		form.AddField (Link.ID, PlayerPrefs.GetString(Link.ID));
//         form.AddField("DID", PlayerPrefs.GetString(Link.DEVICE_ID));
//         form.AddField ("EUsed",PlayerPrefs.GetInt("EUsed").ToString());
// 		WWW www = new WWW(url,form);
// 		yield return www;
// 		if (www.error == null) {
			
// 			var jsonString = JSON.Parse (www.text);
// 			Debug.Log (www.text);
// 			PlayerPrefs.SetString (Link.FOR_CONVERTING, jsonString["code"]);
//             if (int.Parse(PlayerPrefs.GetString(Link.FOR_CONVERTING)) == 1)
//             {
//                lf.lostLife (PlayerPrefs.GetInt("EUsed"),int.Parse(jsonString["data"]["energy"]));
//                 PlayerPrefs.SetString(Link.ENERGY, jsonString["data"]["energy"]);
//                 //yield return new WaitForSeconds (1);
//                 Application.LoadLevel("Game 1");
//             }
//             else if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == "33")
//             {
//                 ValidationError.SetActive(true);
//             }
//         } else {
// 			pressed = false;
// 			//trouble.SetActive (true);
// 			Debug.Log ("GAGAL");
// 		}
// 	}
public void NextStage () 
{
	var currentStage = int.Parse(PlayerPrefs.GetString(Link.StageChoose));
	switch(currentStage)
	{
	case 0:
		OnOld_Building2();
	break;
	case 1:
		OnOld_Building3();
	break;
	case 2:
		OnOld_Building4();
	break;
	case 3:
		OnOld_Building5();
	break;
	case 4:
		OnOld_Building6();
	break;
	case 5:
        Dialogue("SchoolStart");
		OnSchool1();
	break;
	case 6:
		OnSchool2();
	break;
	case 7:
		OnSchool3();
	break;
	case 8:
		OnSchool4();
	break;
	case 9:
		OnSchool5();
	break;
	case 10:
		OnSchool6();
	break;
	case 11:
        Dialogue("HospitalStart");
		Onhospital1();
	break;
	case 12:
		Onhospital2();
	break;
	case 13:
		Onhospital3();
	break;
	case 14:
		Onhospital4();
	break;
	case 15:
		Onhospital5();
	break;
	case 16:
		Onhospital6();
	break;
	case 17:
        Dialogue("BridgeStart");
		OnBridge1();
	break;
	case 18:
		OnBridge2();
	break;
	case 19:
		OnBridge3();
	break;
	case 20:
		OnBridge4();
	break;
	case 21:
		OnBridge5();
	break;
	case 22:
		OnBridge6();
	break;
	case 23:
        Dialogue("GraveyardStart");
		OnGraveyard1();
	break;
	case 24:
		OnGraveyard2();
	break;
	case 25:
		OnGraveyard3();
	break;
	case 26:
		OnGraveyard4();
	break;
	case 27:
		OnGraveyard5();
	break;
	case 28:
		OnGraveyard6();
	break;
    case 29:
        Dialogue("WarehouseStart");
		OnWarehouse1();
	break;
	case 30:
		OnWarehouse2();
	break;
	case 31:
		OnWarehouse3();
	break;
	case 32:
		OnWarehouse4();
	break;
	case 33:
		OnWarehouse5();
	break;
	case 34:
		OnWarehouse6();
	break;
	}
		
}

public void Dialogue(string name)
{
   // SceneManagerHelper.LoadTutorial(name);
}

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

            				GameScript.KurangEnergy();
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
        			GameScript.KurangEnergy();
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
							GameScript.KurangEnergy();
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
				GameScript.KurangEnergy();
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
				GameScript.KurangEnergy();
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
				GameScript.KurangEnergy();
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
        			GameScript.KurangEnergy();
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
        			GameScript.KurangEnergy();
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
        			GameScript.KurangEnergy();
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
				GameScript.KurangEnergy();
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
				GameScript.KurangEnergy();
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
				GameScript.KurangEnergy();
			}
			else {
				NoEnergyGUI.SetActive (true);
			}
			pressed = true;
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
				GameScript.KurangEnergy();
			} else {
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
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_HP, "1399");

            PlayerPrefs.SetString(Link.POS_1_CHAR_2_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ATTACK, "218");//	322	300	1734
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_DEFENSE, "519");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_HP, "1498");

            PlayerPrefs.SetString(Link.POS_1_CHAR_3_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ATTACK, "271");//	501	355	1332
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_DEFENSE, "385");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_HP, "1752");
            if (currentEnergy >= energyused) {
              


              
				//Application.LoadLevel (Link.PilihCharacter);
				GameScript.KurangEnergy();
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
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_HP, "1498");

            PlayerPrefs.SetString(Link.POS_1_CHAR_2_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ATTACK, "218");// 456 421 969
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_DEFENSE, "519");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_HP, "1498");

            PlayerPrefs.SetString(Link.POS_1_CHAR_3_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ATTACK, "440");// 330 487 1449
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_DEFENSE, "407");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_HP, "1629");

            if (currentEnergy >= energyused) {
              
          
        //Application.LoadLevel(Link.PilihCharacter);
        			GameScript.KurangEnergy();
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
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_HP, "1914");
            if (currentEnergy >=energyused) {
	
		
    //   Application.LoadLevel(Link.PilihCharacter);
        			GameScript.KurangEnergy();
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
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_HP, "1469");

            PlayerPrefs.SetString(Link.POS_1_CHAR_2_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ATTACK, "332");// 213 511	1428
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_DEFENSE, "310");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_HP, "1914");

            PlayerPrefs.SetString(Link.POS_1_CHAR_3_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ATTACK, "276");//	376	350	1572
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_DEFENSE, "390");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_HP, "1842");
            if (currentEnergy >=energyused) {

				//   Application.LoadLevel(Link.PilihCharacter);
				GameScript.KurangEnergy();
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
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_HP, "1638");

            PlayerPrefs.SetString(Link.POS_1_CHAR_2_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ATTACK, "450");// 213 511	1428
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_DEFENSE, "417");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_HP, "1809");

            PlayerPrefs.SetString(Link.POS_1_CHAR_3_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ATTACK, "480");//	376	350	1572
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_DEFENSE, "436");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_HP, "1179");
            if (currentEnergy >=energyused) {

				
				//   Application.LoadLevel(Link.PilihCharacter);
				GameScript.KurangEnergy();
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
            PlayerPrefs.SetString(Link.POS_1_CHAR_1_HP, "1350");

            PlayerPrefs.SetString(Link.POS_1_CHAR_2_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_ATTACK, "459");// 213 511	1428
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_DEFENSE, "337");
            PlayerPrefs.SetString(Link.POS_1_CHAR_2_HP, "1539");

            PlayerPrefs.SetString(Link.POS_1_CHAR_3_GRADE, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_LEVEL, "1");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_ATTACK, "228");//	376	350	1572
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_DEFENSE, "535");
            PlayerPrefs.SetString(Link.POS_1_CHAR_3_HP, "1638");
            if (currentEnergy >=energyused) {

				
				//   Application.LoadLevel(Link.PilihCharacter);
				GameScript.KurangEnergy();
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
        			GameScript.KurangEnergy();
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
				GameScript.KurangEnergy();
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
				GameScript.KurangEnergy();
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
				GameScript.KurangEnergy();
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
				GameScript.KurangEnergy();
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
				GameScript.KurangEnergy();
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
				GameScript.KurangEnergy();
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
				GameScript.KurangEnergy();
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
				GameScript.KurangEnergy();
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
				GameScript.KurangEnergy();
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
				GameScript.KurangEnergy();
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
				GameScript.KurangEnergy();
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
				GameScript.KurangEnergy();
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
				GameScript.KurangEnergy();
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
				GameScript.KurangEnergy();
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
				GameScript.KurangEnergy();
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
				GameScript.KurangEnergy();
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
				GameScript.KurangEnergy();
			} else {
				NoEnergyGUI.SetActive (true);
			}
			pressed = true;
		}
	}

}
