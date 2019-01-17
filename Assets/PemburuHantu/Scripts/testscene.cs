using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testscene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void hantu_kiri(){

		PlayerPrefs.SetString (Link.POS_1_CHAR_1_FILE, "Jelangkung_Fire");
		PlayerPrefs.SetString (Link.POS_1_CHAR_2_FILE, "Jelangkung_Fire");
		PlayerPrefs.SetString (Link.POS_1_CHAR_3_FILE, "Jelangkung_Fire");
		PlayerPrefs.SetString (Link.POS_2_CHAR_1_FILE, "Lembuswana_Fire");
		PlayerPrefs.SetString (Link.POS_2_CHAR_2_FILE, "Leak_Fire");
		PlayerPrefs.SetString (Link.POS_2_CHAR_3_FILE, "SundelBolong_Fire");
		PlayerPrefs.SetString (Link.CHAR_1_FILE, "Kolorijo_Fire");
		PlayerPrefs.SetString (Link.CHAR_2_FILE, "Leak_Fire");
		PlayerPrefs.SetString (Link.CHAR_3_FILE, "Jelangkung_Fire");

		PlayerPrefs.SetString (Link.CHAR_1_ID,"1");
		PlayerPrefs.SetString (Link.CHAR_2_ID,"2");
		PlayerPrefs.SetString (Link.CHAR_3_ID,"3");
		PlayerPrefs.SetString (Link.CHAR_1_LEVEL,"1");
		PlayerPrefs.SetString (Link.CHAR_2_LEVEL,"1");
		PlayerPrefs.SetString (Link.CHAR_3_LEVEL,"1");
		PlayerPrefs.SetString (Link.CHAR_1_GRADE,"1");
		PlayerPrefs.SetString (Link.CHAR_2_GRADE,"1");
		PlayerPrefs.SetString (Link.CHAR_3_GRADE,"1");
		PlayerPrefs.SetString (Link.CHAR_1_MONSTEREXP,"1");
		PlayerPrefs.SetString (Link.CHAR_2_MONSTEREXP,"1");
		PlayerPrefs.SetString (Link.CHAR_3_MONSTEREXP,"1");
		PlayerPrefs.SetString (Link.CHAR_1_TARGETNL,"9999");
		PlayerPrefs.SetString (Link.CHAR_2_TARGETNL,"9999");
		PlayerPrefs.SetString (Link.CHAR_3_TARGETNL,"9999");

		PlayerPrefs.SetString (Link.POS_2_CHAR_1_ATTACK, "266");
		PlayerPrefs.SetString (Link.POS_2_CHAR_1_DEFENSE, "380");
		PlayerPrefs.SetString (Link.POS_2_CHAR_1_HP, "1662");

		PlayerPrefs.SetString (Link.POS_2_CHAR_2_ATTACK, "304");
		PlayerPrefs.SetString (Link.POS_2_CHAR_2_DEFENSE, "600");
		PlayerPrefs.SetString (Link.POS_2_CHAR_2_HP, "1188");

		PlayerPrefs.SetString (Link.POS_2_CHAR_3_ATTACK, "431");
		PlayerPrefs.SetString (Link.POS_2_CHAR_3_DEFENSE, "478");
		PlayerPrefs.SetString (Link.POS_2_CHAR_3_HP, "1473");


		PlayerPrefs.SetString (Link.POS_1_CHAR_1_GRADE, "1");
		PlayerPrefs.SetString (Link.POS_1_CHAR_1_LEVEL, "1");
		PlayerPrefs.SetString (Link.POS_1_CHAR_1_ATTACK, "322");//401 //483 //1248
		PlayerPrefs.SetString (Link.POS_1_CHAR_1_DEFENSE, "300");
		PlayerPrefs.SetString (Link.POS_1_CHAR_1_HP, "1248");

		PlayerPrefs.SetString (Link.POS_1_CHAR_2_GRADE, "1");
		PlayerPrefs.SetString (Link.POS_1_CHAR_2_LEVEL, "1");
		PlayerPrefs.SetString (Link.POS_1_CHAR_2_ATTACK, "322");//	322	300	1734
		PlayerPrefs.SetString (Link.POS_1_CHAR_2_DEFENSE, "300");
		PlayerPrefs.SetString (Link.POS_1_CHAR_2_HP, "1248");

		PlayerPrefs.SetString (Link.POS_1_CHAR_3_GRADE, "1");
		PlayerPrefs.SetString (Link.POS_1_CHAR_3_LEVEL, "1");
		PlayerPrefs.SetString (Link.POS_1_CHAR_3_ATTACK, "322");//552 450 1044
		PlayerPrefs.SetString (Link.POS_1_CHAR_3_DEFENSE, "300");
		PlayerPrefs.SetString (Link.POS_1_CHAR_3_HP, "1248");
		Application.LoadLevel ("Game 1");

	}
	public void hantu_kanan(){
		PlayerPrefs.SetString (Link.POS_1_CHAR_1_FILE, "Jelangkung_Fire");
		PlayerPrefs.SetString (Link.POS_1_CHAR_2_FILE, "Jelangkung_Fire");
		PlayerPrefs.SetString (Link.POS_1_CHAR_3_FILE, "Jelangkung_Fire");
		PlayerPrefs.SetString (Link.POS_2_CHAR_1_FILE, "Lembuswana_Fire");
		PlayerPrefs.SetString (Link.POS_2_CHAR_2_FILE, "Mukarata_Fire");
		PlayerPrefs.SetString (Link.POS_2_CHAR_3_FILE, "SundelBolong_Fire");
		PlayerPrefs.SetString (Link.CHAR_1_FILE, "Lembuswana_Fire");
		PlayerPrefs.SetString (Link.CHAR_2_FILE, "Mukarata_Fire");
		PlayerPrefs.SetString (Link.CHAR_3_FILE, "SundelBolong_Fire");

		PlayerPrefs.SetString (Link.CHAR_1_ID,"1");
		PlayerPrefs.SetString (Link.CHAR_2_ID,"2");
		PlayerPrefs.SetString (Link.CHAR_3_ID,"3");
		PlayerPrefs.SetString (Link.CHAR_1_LEVEL,"1");
		PlayerPrefs.SetString (Link.CHAR_2_LEVEL,"1");
		PlayerPrefs.SetString (Link.CHAR_3_LEVEL,"1");
		PlayerPrefs.SetString (Link.CHAR_1_GRADE,"1");
		PlayerPrefs.SetString (Link.CHAR_2_GRADE,"1");
		PlayerPrefs.SetString (Link.CHAR_3_GRADE,"1");
		PlayerPrefs.SetString (Link.CHAR_1_MONSTEREXP,"1");
		PlayerPrefs.SetString (Link.CHAR_2_MONSTEREXP,"1");
		PlayerPrefs.SetString (Link.CHAR_3_MONSTEREXP,"1");
		PlayerPrefs.SetString (Link.CHAR_1_TARGETNL,"9999");
		PlayerPrefs.SetString (Link.CHAR_2_TARGETNL,"9999");
		PlayerPrefs.SetString (Link.CHAR_3_TARGETNL,"9999");

		PlayerPrefs.SetString (Link.POS_2_CHAR_1_ATTACK, "266");
		PlayerPrefs.SetString (Link.POS_2_CHAR_1_DEFENSE, "380");
		PlayerPrefs.SetString (Link.POS_2_CHAR_1_HP, "1662");

		PlayerPrefs.SetString (Link.POS_2_CHAR_2_ATTACK, "304");
		PlayerPrefs.SetString (Link.POS_2_CHAR_2_DEFENSE, "600");
		PlayerPrefs.SetString (Link.POS_2_CHAR_2_HP, "1188");

		PlayerPrefs.SetString (Link.POS_2_CHAR_3_ATTACK, "431");
		PlayerPrefs.SetString (Link.POS_2_CHAR_3_DEFENSE, "478");
		PlayerPrefs.SetString (Link.POS_2_CHAR_3_HP, "1473");


		PlayerPrefs.SetString (Link.POS_1_CHAR_1_GRADE, "1");
		PlayerPrefs.SetString (Link.POS_1_CHAR_1_LEVEL, "1");
		PlayerPrefs.SetString (Link.POS_1_CHAR_1_ATTACK, "322");//401 //483 //1248
		PlayerPrefs.SetString (Link.POS_1_CHAR_1_DEFENSE, "300");
		PlayerPrefs.SetString (Link.POS_1_CHAR_1_HP, "1248");

		PlayerPrefs.SetString (Link.POS_1_CHAR_2_GRADE, "1");
		PlayerPrefs.SetString (Link.POS_1_CHAR_2_LEVEL, "1");
		PlayerPrefs.SetString (Link.POS_1_CHAR_2_ATTACK, "322");//	322	300	1734
		PlayerPrefs.SetString (Link.POS_1_CHAR_2_DEFENSE, "300");
		PlayerPrefs.SetString (Link.POS_1_CHAR_2_HP, "1248");

		PlayerPrefs.SetString (Link.POS_1_CHAR_3_GRADE, "1");
		PlayerPrefs.SetString (Link.POS_1_CHAR_3_LEVEL, "1");
		PlayerPrefs.SetString (Link.POS_1_CHAR_3_ATTACK, "322");//552 450 1044
		PlayerPrefs.SetString (Link.POS_1_CHAR_3_DEFENSE, "300");
		PlayerPrefs.SetString (Link.POS_1_CHAR_3_HP, "1248");

		Application.LoadLevel ("Game 1");

	}
}
