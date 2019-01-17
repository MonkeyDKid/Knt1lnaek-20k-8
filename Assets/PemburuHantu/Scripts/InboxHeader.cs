using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;

public class InboxHeader : MonoBehaviour
{
	public string Description, Claimed,MessID,ItemName,ItemQuantity;
	public Text Title,iName,iQuantity;
	public InboxContent MessageDetails;
	public GameObject Opened,Loading;
	public Home HomeScript;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Message(){
		StartCoroutine(MessageDetail());
	}
		IEnumerator MessageDetail()
	
	{	Loading.SetActive (true);
		//yield return new WaitForSeconds(0.3f);
		var url = "http://139.59.100.192/PH/GetInboxDetail";
		var form = new WWWForm();
		form.AddField("ID", MessID);
		form.AddField("PID", PlayerPrefs.GetString(Link.ID));
		form.AddField("DID", PlayerPrefs.GetString(Link.DEVICE_ID));
		WWW www = new WWW(url, form);
		yield return www;
		Debug.Log(www.text);
		if (www.error == null)
		{
				
			var jsonString = JSON.Parse(www.text);
//			Debug.Log(jsonString["data"][0]["QS1"]);
			int ResCode = int.Parse(jsonString["code"]);


			switch (ResCode)
			{
				case 9:
					print("pop up already sent it");
				//	complete_button.interactable = false;
					break;
				case 8:
					print("pop up expired event");
				//	complete_button.interactable = false;
					break;
				case 7:
					print("Whadya want?");
					break;
				case 6:
					print("nothing to see yet");
					break;
			case 1:
				Loading.SetActive (false);
				print ("check inbox");
				MessageDetails.Title.text = jsonString ["data"] ["Title"];
				if (int.Parse (jsonString ["data"] ["Claimed"]) == 0) {
					MessageDetails.Claimed.transform.Find ("Text").GetComponent<Text> ().text = "Claim";
				} else {
					MessageDetails.Claimed.transform.Find ("Text").GetComponent<Text> ().text = "Claimed";
				}
				MessageDetails.HomeScript=HomeScript;
				MessageDetails.Claimed.interactable = (int.Parse (jsonString ["data"] ["Claimed"]) == 0);
				MessageDetails.Claimed.gameObject.SetActive (bool.Parse (jsonString ["button"]) == true);
				MessageDetails.Description.text = jsonString ["data"] ["Description"];
				MessageDetails.EventID = MessID;

					break;
				default:
					break;
			}
		}
	}
}
