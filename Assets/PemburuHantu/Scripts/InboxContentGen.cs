using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.UI;

public class InboxContentGen : MonoBehaviour
{
	//public string EventID, Title, Description,Opened,Claimed;
	public GameObject prefabHeader, prefabContent,emptyText,LoadinInbox;
	public Transform HeaderParent;
	public InboxContent MD;
	public Home HomeScript;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnEnable()
	{
		//Debug.Log("PrintOnEnable: script was enabled");
		StartCoroutine(GetInbox());
	}
	



	IEnumerator GetInbox()
	{
		LoadinInbox.SetActive (true);
		yield return new WaitForSeconds(0.3f);
		var url = "http://139.59.100.192/PH/GetInbox";
		var form = new WWWForm();
		//form.AddField("ID", EventID);
		form.AddField("DID", PlayerPrefs.GetString(Link.DEVICE_ID));
		form.AddField("ID", PlayerPrefs.GetString(Link.ID));
		WWW www = new WWW(url, form);
		yield return www;
		Debug.Log(www.text);
		if (www.error == null)
		{
				
			var jsonString = JSON.Parse(www.text);
			//Debug.Log(jsonString["data"][0]["QS1"]);
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
				emptyText.SetActive (false);
				LoadinInbox.SetActive (false);
					print("check inbox");

				for (int x = HeaderParent.childCount - 1; x >= 0; x--) {
					Destroy (HeaderParent.GetChild (x).gameObject);
				}

				GameObject[] entry;
				entry = new GameObject[int.Parse(jsonString["count"])];
					for (int x = 0; x < int.Parse(jsonString["count"]); x++)
			{
				string opened=jsonString["data"][x]["Opened"];
				string Claimed=jsonString["data"][x]["Opened"];

				print(opened);
				entry[x] = Instantiate(prefabHeader);
				if(Claimed==null){
					entry[x].GetComponent<InboxHeader>().Claimed="false";
				}
				else{
					entry[x].GetComponent<InboxHeader>().Claimed="Claimed";
				}
				entry[x].GetComponent<InboxHeader>().HomeScript = HomeScript;
				entry[x].GetComponent<InboxHeader>().Title.text = jsonString["data"][x]["Title"];
				entry[x].GetComponent<InboxHeader>().MessID = jsonString["data"][x]["MessageID"];
				entry[x].GetComponent<InboxHeader>().Opened.SetActive(opened == "0");
				entry[x].GetComponent<InboxHeader>().MessageDetails=MD;
				entry[x].GetComponent<InboxHeader>().Loading=LoadinInbox;
				entry[x].transform.SetParent(HeaderParent, false);
			}

					break;
			default:
				emptyText.SetActive (true);
				LoadinInbox.SetActive(false);
					break;
			}
		}
		else {
			LoadinInbox.SetActive(false);
		}
	}
}
