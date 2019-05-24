using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
public class BattlePeta : MonoBehaviour {

public Button StartButton;
public GameObject ValidationError,trouble;
public Image[] GhostImage;
public Text[] DropText;
public string NodeID;
// public JSONNode json;

public void Start() {
	{
		randomPeta();
	}
}
public void Set(JSONNode json)
{
for(int i=1;i<4;i++)
			 {
				 PlayerPrefs.SetString("pos_1_char_"+i.ToString()+"_file", json ["data"]["hantu"]["Hantu"+i.ToString()]["name_file"]);
				 PlayerPrefs.SetString("pos_1_char_"+i.ToString()+"_element", json ["data"]["hantu"]["Hantu"+i.ToString()]["type"]);
				 PlayerPrefs.SetString("pos_1_char_"+i.ToString()+"_mode", json ["data"]["hantu"]["Hantu"+i.ToString()]["element"]);
				 PlayerPrefs.SetString("pos_1_char_"+i.ToString()+"_grade", json ["data"]["hantu"]["Hantu"+i.ToString()]["grade"]);
				 PlayerPrefs.SetString("pos_1_char_"+i.ToString()+"_attack", json ["data"]["hantu"]["Hantu"+i.ToString()]["ATTACK"]);
				 PlayerPrefs.SetString("pos_1_char_"+i.ToString()+"_defense", json ["data"]["hantu"]["Hantu"+i.ToString()]["DEFEND"]);
				 PlayerPrefs.SetString("pos_1_char_"+i.ToString()+"_hp", json ["data"]["hantu"]["Hantu"+i.ToString()]["HP"]);
			 
			 }
StartButton.onClick.RemoveAllListeners();
StartButton.onClick.AddListener(delegate{ StartCoroutine(kurangEnergy(NodeID));});
}
private void randomPeta()
{
	string[] lokasi = new string[5]	{"School","Hospital","Oldhouse","Bridge","Graveyard"};
	int rand = Random.Range(0,4);
	print(lokasi[rand]);
	PlayerPrefs.SetString(Link.LOKASI, lokasi[rand]);
}
private IEnumerator kurangEnergy (string NID)
	{
		
		string url = Link.url + "energy2";
		WWWForm form = new WWWForm ();
		form.AddField ("PID", PlayerPrefs.GetString(Link.ID));
		form.AddField ("NID", NID);
        form.AddField("DID", PlayerPrefs.GetString(Link.DEVICE_ID));
        form.AddField ("EUsed", 1);
		WWW www = new WWW(url,form);
		yield return www;
		if (www.error == null) {
			
			var jsonString = JSON.Parse (www.text);
			Debug.Log (www.text);
			PlayerPrefs.SetString (Link.FOR_CONVERTING, jsonString["code"]);
            if (int.Parse(PlayerPrefs.GetString(Link.FOR_CONVERTING)) == 1)
            {
                PlayerPrefs.SetString(Link.ENERGY, jsonString["data"]["energy"]);
                //yield return new WaitForSeconds (1);
                SceneManagerHelper.LoadScene(Link.PilihCharacter);
            }
            else if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == "33")
            {
                ValidationError.SetActive(true);
            }
        } else {
			Debug.Log (www.text);
			trouble.SetActive (true);
			Debug.Log ("GAGAL");
		}
	}


}
