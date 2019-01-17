using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System.Collections;


public class FusionItem : MonoBehaviour {

	public Image icon,selected;
	public Text Level;
	public string PlayerHantuId;
	public string hantuId;
	public string Grade;
	public string file;
	public string name;
	public string type;
	public string currentexp;
	public string nextlevelexp;
	public int pos,bintangbefore;
	public int attack;
	public int defense;
	public int stamina;
	public string sudah = "oke";
	public Fusion fusion;
	public GameObject bintang1,bintang2,bintang3,bintang4,bintang5;
	void Awake(){
		Grade="0";
	}
	void Start () {
		fusion = GameObject.Find ("Fusion").GetComponent<Fusion>();
		pos = 0;


	}
	private void Update()
	{
		//		if (fusion.before.activeInHierarchy == false) {
		//			
		//			selected.gameObject.SetActive (false);
		//			GetComponent<Button> ().enabled = true;
		//		}  
		if (pos != 0) {
			selected.gameObject.SetActive (true);
			GetComponent<Button> ().enabled = false;
		}  
		if (pos==1&&fusion.before.activeInHierarchy==false){
			pos = 0;
			selected.gameObject.SetActive (false);
			GetComponent<Button> ().enabled = true;

		}
		if (pos==2&&fusion.Slot[0].activeInHierarchy==false){
			pos = 0;
			fusion.selected =0 ;
			selected.gameObject.SetActive (false);
			GetComponent<Button> ().enabled = true;

		}
		if (pos==3&&fusion.Slot[1].activeInHierarchy==false){
			pos = 0;
			fusion.selected =0 ;
			selected.gameObject.SetActive (false);
			GetComponent<Button> ().enabled = true;

		}
		if (pos==4&&fusion.Slot[2].activeInHierarchy==false){
			pos = 0;
			fusion.selected =0 ;
			selected.gameObject.SetActive (false);
			GetComponent<Button> ().enabled = true;

		}
		if (pos==5&&fusion.Slot[3].activeInHierarchy==false){
			pos = 0;
			fusion.selected =0 ;
			selected.gameObject.SetActive (false);
			GetComponent<Button> ().enabled = true;

		}
		if (pos==6&&fusion.Slot[4].activeInHierarchy==false){
			pos = 0;
			fusion.selected =0 ;
			selected.gameObject.SetActive (false);
			GetComponent<Button> ().enabled = true;

		}
		var angka = int.Parse (Grade);
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
		default:
			//	Debug.Log ("nothing");
			break;
		}
		if (PlayerPrefs.GetString ("enchance") == "y") {
			//Debug.Log ("nothing happend");
		}
		else{
		bintangbefore=int.Parse(fusion.before.GetComponent<FusionItem>().Grade);
		switch (bintangbefore)
		{
		case 1:
			if (fusion.selected == 1 && attack!=0 ) {
				GetComponent<Button> ().enabled=false;
				selected.gameObject.SetActive (true);
				//fusion.button.SetActive (false);
				//	Debug.Log ("pilih");
			}  
			else {
				//	Debug.Log ("ndakpilih");
				//fusion.button.SetActive (true);
				GetComponent<Button> ().enabled= true;
			}
			break;
		case 2:
			if (fusion.selected == 2 && attack!=0) {
				GetComponent<Button> ().enabled=false;
				selected.gameObject.SetActive (true);
			}  
			else {
				GetComponent<Button> ().enabled= true;
			}
			break;
		case 3:
			if (fusion.selected == 3&& attack!=0) {
				GetComponent<Button> ().enabled=false;
				selected.gameObject.SetActive (true);
			}  
			else {
				GetComponent<Button> ().enabled= true;
			}
			break;
		case 4:
			if (fusion.selected == 4&& attack!=0) {
				GetComponent<Button> ().enabled=false;
				selected.gameObject.SetActive (true);
			}  
			else {
				GetComponent<Button> ().enabled= true;
			}
			break;
		case 5:
			if (fusion.selected == 5&& attack!=0) {
				GetComponent<Button> ().enabled=false;
				selected.gameObject.SetActive (true);
			}  
			else {
				GetComponent<Button> ().enabled= true;
			}
			break;
		case 6:
			if (fusion.selected == 6&& attack!=0) {
				GetComponent<Button> ().enabled=false;
				selected.gameObject.SetActive (true);
			}  
			else {
				GetComponent<Button> ().enabled= true;
			}
			break;

		}


		switch (bintangbefore)
		{
		case 1:
			if (fusion.selected == 1) {
				fusion.button.SetActive (false);
			}
			break;
		case 2:
			if (fusion.selected == 2 ) {
				fusion.button.SetActive (false);
			}
			break;
		case 3:
			if (fusion.selected == 3) {
				fusion.button.SetActive (false);
			}
			break;
		case 4:
			if (fusion.selected == 4 ) {
				fusion.button.SetActive (false);
			}
			break;
		case 5:
			if (fusion.selected == 5) {
				fusion.button.SetActive (false);
			}
			break;
		}



		//		if (sudah==PlayerPrefs.GetString ("sudahbool") && pos==0) {
		//			selected.gameObject.SetActive (true);
		//			GetComponent<Button> ().enabled = false;
		//		}  
		}
	}
	public void OnClick () {

		selected.gameObject.SetActive (true);
		if (!fusion.before.active){
			pos = 1;
			fusion.before.SetActive (true);
			fusion.before.transform.Find ("Icon_Char").GetComponent<Image> ().sprite = icon.sprite;
			fusion.before.transform.Find ("Level").GetComponent<Text> ().text = Level.text;
			fusion.monsterlevel =int.Parse( Level.text);
			fusion.before.GetComponent<FusionItem> ().Grade = Grade;
			fusion.before.GetComponent<FusionItem> ().PlayerHantuId = PlayerHantuId;
			fusion.before.GetComponent<FusionItem> ().hantuId = hantuId;
			fusion.before.GetComponent<FusionItem> ().currentexp = currentexp;
			fusion.before.GetComponent<FusionItem> ().nextlevelexp = nextlevelexp;
			fusion.displayenhance.GetComponent<expbar> ().currentEXP = float.Parse(currentexp);
			fusion.displayenhance.GetComponent<expbar> ().targetEXP = float.Parse(nextlevelexp);
			fusion.MonsterEXP1 = int.Parse(currentexp);
					//fusion.before.GetComponent<FusionItem> ().pos=pos;
			PlayerPrefs.SetString ("currentxp", fusion.before.GetComponent<FusionItem> ().currentexp);
			PlayerPrefs.SetString ("nextlevel", fusion.before.GetComponent<FusionItem> ().nextlevelexp);
			PlayerPrefs.SetString ("HantuNaikGrade", PlayerHantuId);
			if (int.Parse (fusion.before.GetComponent<FusionItem> ().Grade) == 1 && int.Parse (fusion.before.GetComponent<FusionItem> ().Level.text) < 15 || int.Parse (fusion.before.GetComponent<FusionItem> ().Grade) == 2 && int.Parse (fusion.before.GetComponent<FusionItem> ().Level.text) < 20 || int.Parse (fusion.before.GetComponent<FusionItem> ().Grade) == 3 && int.Parse (fusion.before.GetComponent<FusionItem> ().Level.text) < 25 || int.Parse (fusion.before.GetComponent<FusionItem> ().Grade) == 4 && int.Parse (fusion.before.GetComponent<FusionItem> ().Level.text) < 30 || int.Parse (fusion.before.GetComponent<FusionItem> ().Grade) == 5 && int.Parse (fusion.before.GetComponent<FusionItem> ().Level.text) < 35) {
				
				fusion.carilevelkecil = true;
				//fusion.carilevelkecil = true;
			}
			else if (int.Parse (fusion.before.GetComponent<FusionItem> ().Grade) == 1 && int.Parse (fusion.before.GetComponent<FusionItem> ().Level.text) == 15 || int.Parse (fusion.before.GetComponent<FusionItem> ().Grade) == 2 && int.Parse (fusion.before.GetComponent<FusionItem> ().Level.text) == 20 || int.Parse (fusion.before.GetComponent<FusionItem> ().Grade) == 3 && int.Parse (fusion.before.GetComponent<FusionItem> ().Level.text)== 25 || int.Parse (fusion.before.GetComponent<FusionItem> ().Grade) == 4 && int.Parse (fusion.before.GetComponent<FusionItem> ().Level.text) == 30 || int.Parse (fusion.before.GetComponent<FusionItem> ().Grade) == 5 && int.Parse (fusion.before.GetComponent<FusionItem> ().Level.text) == 35) {
//				pos = 1;
//				fusion.before.SetActive (true);
//				fusion.before.transform.FindChild ("Icon_Char").GetComponent<Image> ().sprite = icon.sprite;
//				fusion.before.transform.FindChild ("Level").GetComponent<Text> ().text = Level.text;
//				fusion.before.GetComponent<FusionItem> ().Grade = Grade;
//				fusion.before.GetComponent<FusionItem> ().PlayerHantuId = PlayerHantuId;
//				fusion.before.GetComponent<FusionItem> ().hantuId = hantuId;
//				//fusion.before.GetComponent<FusionItem> ().pos=pos;
//				PlayerPrefs.SetString ("HantuNaikGrade", PlayerHantuId);
				fusion.carilevelkecil2 = true;
				//fusion.carilevelkecil = true;
			}
		}  
		else if (!fusion.Slot [0].active) {
			fusion.selected = 1;
			//			fusion.Slot [1].GetComponent<FusionItem> ().pos = 2;
			pos = 2;
			fusion.Slot [0].SetActive (true);
			fusion.Slot [0].transform.Find ("Icon_Char").GetComponent<Image> ().sprite = icon.sprite;
			fusion.Slot [0].transform.Find ("Level").GetComponent<Text> ().text = Level.text;
			fusion.Slot [0].GetComponent<FusionItem> ().Grade = Grade;
			fusion.Slot [0].GetComponent<FusionItem> ().PlayerHantuId = PlayerHantuId;
			fusion.Slot [0].GetComponent<FusionItem> ().hantuId = hantuId;
			//fusion.Slot [0].GetComponent<FusionItem> ().pos=pos;
			PlayerPrefs.SetString("hantukorban1ID",PlayerHantuId) ;
		}  
		else if (!fusion.Slot [1].active) {
			fusion.selected = 2;
			pos = 3;
			fusion.Slot [1].SetActive (true);
			fusion.Slot [1].transform.Find ("Icon_Char").GetComponent<Image> ().sprite = icon.sprite;
			fusion.Slot [1].transform.Find ("Level").GetComponent<Text> ().text = Level.text;
			fusion.Slot [1].GetComponent<FusionItem> ().Grade = Grade;
			fusion.Slot [1].GetComponent<FusionItem> ().PlayerHantuId = PlayerHantuId;
			fusion.Slot [1].GetComponent<FusionItem> ().hantuId = hantuId;
			//fusion.Slot [1].GetComponent<FusionItem> ().pos=pos;
			PlayerPrefs.SetString("hantukorban2ID",PlayerHantuId) ;
		}  
		else if (!fusion.Slot [2].active) {
			fusion.selected = 3;
			pos = 4;
			fusion.Slot [2].SetActive (true);
			fusion.Slot [2].transform.Find ("Icon_Char").GetComponent<Image> ().sprite = icon.sprite;
			fusion.Slot [2].transform.Find ("Level").GetComponent<Text> ().text = Level.text;
			fusion.Slot [2].GetComponent<FusionItem> ().Grade = Grade;
			fusion.Slot [2].GetComponent<FusionItem> ().PlayerHantuId = PlayerHantuId;
			fusion.Slot [2].GetComponent<FusionItem> ().hantuId = hantuId;
			//fusion.Slot [2].GetComponent<FusionItem> ().pos=pos;
			PlayerPrefs.SetString("hantukorban3ID",PlayerHantuId);
		}  
		else if (!fusion.Slot [3].active) {
			fusion.selected = 4;
			pos = 5;
			fusion.Slot [3].SetActive (true);
			fusion.Slot [3].transform.Find ("Icon_Char").GetComponent<Image> ().sprite = icon.sprite;
			fusion.Slot [3].transform.Find ("Level").GetComponent<Text> ().text = Level.text;
			fusion.Slot [3].GetComponent<FusionItem> ().Grade = Grade;
			fusion.Slot [3].GetComponent<FusionItem> ().PlayerHantuId = PlayerHantuId;
			fusion.Slot [3].GetComponent<FusionItem> ().hantuId = hantuId;
			//fusion.Slot [3].GetComponent<FusionItem> ().pos=pos;
			PlayerPrefs.SetString("hantukorban4ID",PlayerHantuId) ;
		}  
		else if (!fusion.Slot [4].active) {
			fusion.selected = 5;
			pos = 6;
			fusion.Slot [4].SetActive (true);
			fusion.Slot [4].transform.Find ("Icon_Char").GetComponent<Image> ().sprite = icon.sprite;
			fusion.Slot [4].transform.Find ("Level").GetComponent<Text> ().text = Level.text;
			fusion.Slot [4].GetComponent<FusionItem> ().Grade = Grade;
			fusion.Slot [4].GetComponent<FusionItem> ().PlayerHantuId = PlayerHantuId;
			fusion.Slot [4].GetComponent<FusionItem> ().hantuId = hantuId;
			//fusion.Slot [4].GetComponent<FusionItem> ().pos=pos;
			PlayerPrefs.SetString("hantukorban5ID",PlayerHantuId) ;
			PlayerPrefs.SetString ("sudahbool", "oke");
		}  else {
			selected.gameObject.SetActive (false);
			GetComponent<Button> ().enabled = true;
		}
		//	GetComponent<Button> ().enabled = false;
	
	}
}

