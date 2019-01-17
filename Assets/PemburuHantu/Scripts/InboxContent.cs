using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;

public class InboxContent : MonoBehaviour {
	public string EventID;
	public Text Description,Title;
	public Button Claimed;
	public Home HomeScript;
	public GameObject Loading, Dialog;

	public void ClaimIt(){
		StartCoroutine (RedeemIt ());
	}
	IEnumerator RedeemIt()
	{
		Loading.SetActive (true);
		//yield return new WaitForSeconds(0.3f);
		var url = "http://139.59.100.192/PH/ClaimInbox";
		var form = new WWWForm();
		form.AddField("ID", EventID);
		form.AddField("PID", PlayerPrefs.GetString(Link.ID));
		WWW www = new WWW(url, form);
		yield return www;
		Debug.Log(www.text);
		if (www.error == null) {

			var jsonString = JSON.Parse (www.text);
//			Debug.Log(jsonString["data"][0]["QS1"]);
			int ResCode = int.Parse (jsonString ["code"]);

			switch (ResCode) {
			case 9:
				print ("pop up already sent it");
				//	complete_button.interactable = false;
				break;
			case 8:
				print ("pop up expired event");
				//	complete_button.interactable = false;
				break;
			case 7:
				print ("Whadya want?");
				break;
			case 6:
				print ("nothing to see yet");
				break;
			case 1:
				string Quantity = jsonString ["data"] ["Quantity"]; 
				string ItemName = jsonString ["data"] ["ItemClaimName"]; 
				Loading.SetActive (false);
				Dialog.transform.Find ("Text").GetComponent<Text> ().text = "You got \n" + Quantity + " " + ItemName + ".";
				Claimed.interactable = false;
				Dialog.SetActive (true);
				HomeScript.GDUShop();
				print ("You Got");
				break;
			default:
				break;
			}
		} 
		{
			Loading.SetActive(false);
		}
	}

}
