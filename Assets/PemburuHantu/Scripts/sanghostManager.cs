using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
public class sanghostManager : MonoBehaviour {

public GameObject[] Sanghost;
	public void ShowStats(int ghostpos)
	{
		string fakeJson = PlayerPrefs.GetString("DataBuru");
		var jsonString = JSON.Parse (fakeJson);
		Sanghost[ghostpos].GetComponent<summonstats>().Lain.SetActive(true);
		Sanghost[ghostpos].GetComponent<summonstats>().Name.text = jsonString["kodehantus"][ghostpos][2];
		int grade = int.Parse(jsonString["kodehantus"][ghostpos][5]);
		switch(grade)
		{
			case 0 :
			Sanghost[ghostpos].GetComponent<summonstats>().bintang[0].SetActive(true);
			break;
			case 1 :
			Sanghost[ghostpos].GetComponent<summonstats>().bintang[1].SetActive(true);
			break;
			case 2 :
			Sanghost[ghostpos].GetComponent<summonstats>().bintang[2].SetActive(true);
			break;
			case 3 :
			Sanghost[ghostpos].GetComponent<summonstats>().bintang[3].SetActive(true);
			break;
			case 4 :
			Sanghost[ghostpos].GetComponent<summonstats>().bintang[4].SetActive(true);
			break;
		}
		
	}
}
