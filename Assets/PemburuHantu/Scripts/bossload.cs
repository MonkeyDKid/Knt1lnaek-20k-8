using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.UI;
public class bossload : MonoBehaviour
{
	public GameObject Prefab,Loading,EmptyText,RedeemHandle;

	public Transform Parent, Head;

	// Use this for initialization
	public void Load()
	{
		StartCoroutine(LoadNews());
	}

	// Update is called once per frame
	void Update()
	{

	}

	IEnumerator LoadNews()
	{
		
		for (int x = Parent.childCount - 1; x >= 0; x--) {
			Destroy (Parent.GetChild (x).gameObject);
		}
		Loading.SetActive(true);
		var url = "http://139.59.100.192/PH/GetQuest";
		var form = new WWWForm();
		form.AddField("ID",PlayerPrefs.GetString(Link.ID));
		WWW www = new WWW(url,form);
		yield return www;
		Debug.Log(www.text);
		if (www.error == null) {
			Debug.Log (www.text);
			var jsonString = JSON.Parse (www.text);
			if (int.Parse(jsonString ["code"]) == 1) {
				EmptyText.SetActive (false);
				GameObject[] entry;
				entry = new GameObject[int.Parse (jsonString ["NewsCount"])];
				for (int x = 0; x < int.Parse (jsonString ["NewsCount"]); x++) {
					entry [x] = Instantiate (Prefab);
					entry [x].GetComponent<ButttonImage> ().EventID = jsonString ["data"] [x] ["id"];
					entry [x].GetComponent<ButttonImage> ().ImageURL = jsonString ["data"] [x] ["ImageURL"];
					entry [x].GetComponent<ButttonImage> ().Done.GetComponent<Text> ().enabled = (int.Parse (jsonString ["data"] [x] ["QD"]) == 1);
					entry [x].GetComponent<ButttonImage> ().Head = Head;
					entry [x].GetComponent<ButttonImage> ().RedeemHandle = RedeemHandle;
					entry [x].transform.SetParent (Parent, false);

				}
				Loading.SetActive (false);
			} else {
				EmptyText.SetActive (true);
				Loading.SetActive (false);
			
			}
		} else {
			Loading.SetActive(false);
		}

	}
}
