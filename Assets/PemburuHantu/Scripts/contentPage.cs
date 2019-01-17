using System.Collections;
using SimpleJSON;using System.Collections.Generic;
using System.Security;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class contentPage : MonoBehaviour
{
	public string EventID, Title, Description, ImageURL, M1, M2, M3, M4, M5,F1,F2,F3,F4,F5,F6,F7,F8, QS, QR;

	public Button complete_button1,complete_button2,complete_button3,complete_button4,complete_button5,complete_button6,complete_button7,complete_button8;
	public GameObject M1GO, M2GO, M3GO, M4GO, M5GO,EventGO,RedeemCodeHandle;
	public RawImage Rimage;
	public Text TitleText, DescriptionText, M1Text, M2Text, M3Text, M4Text, M5Text,PP1,PP2,PP3,PP4,PP5;
	public string M1Quantity,M2Quantity,M3Quantity,M4Quantity,M5Quantity,P1Quantity,P2Quantity,P3Quantity,P4Quantity,P5Quantity;
	// Use this for initialization
	void Start()
	{
		StartCoroutine (CachedLoad ());
	}

	IEnumerator CachedLoad()
	{
		yield return new WaitForSeconds(.6f);
		if (File.Exists(Application.persistentDataPath + EventID + ".jpg"))
		{print("cached");
			byte[] byteArray = File.ReadAllBytes(Application.persistentDataPath + EventID + ".jpg");
			Texture2D texture = new Texture2D(9,9);
			texture.LoadImage(byteArray);
			texture.filterMode = FilterMode.Point;
			Rimage.texture = texture;

		}
		else
		{print("download");
			WWW www = new WWW(ImageURL);
			yield return www;
			Texture2D texture = www.texture;
			texture.filterMode = FilterMode.Point;
			Rimage.texture = texture;
			byte[] bytes = texture.EncodeToJPG();
			File.WriteAllBytes(Application.persistentDataPath+EventID+".jpg",bytes);
		}
	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnDisable()
	{
		Debug.Log("PrintOnDisable: script was disabled");
	}

	void OnEnable()
	{
		//Debug.Log("PrintOnEnable: script was enabled");
		StartCoroutine(LoadNewsDetail());
	}

	IEnumerator LoadNewsDetail()
	{EventGO.SetActive (true);
		yield return new WaitForSeconds(0.3f);
		var url = "http://139.59.100.192/PH/GetQuestID";
		var form = new WWWForm();
		form.AddField("ID",EventID);
		form.AddField("PID",PlayerPrefs.GetString(Link.ID));
		WWW www = new WWW(url,form);
		yield return www;
		Debug.Log(www.text);
		if (www.error == null)
		{
			
			var jsonString = JSON.Parse(www.text);
			Debug.Log(jsonString["data"][0]["QS1"]);
			int ResCode = int.Parse(jsonString["code"]);
			print (jsonString ["data"] [0] ["Qcode1"] + "1");
			
			switch (ResCode)
			{
			case 9:
				print ("pop up expired event");
				EventGO.SetActive (false);
					break;
				case 8:
					print ("pop up expired event");
					complete_button1.interactable = false;
				complete_button2.interactable = false;
				complete_button3.interactable = false;
				complete_button4.interactable = false;
				complete_button5.interactable = false;
				complete_button6.interactable = false;
				EventGO.SetActive (false);
					break;
				case 7:
					print ("Whadya want?");
				EventGO.SetActive (false);
					break;
				case 6:
					print ("nothing to see yet");
				EventGO.SetActive (false);
					break;
			case 1:

				M1Quantity = jsonString ["data"] [0] ["MissionC1"];
				M2Quantity = jsonString ["data"] [0] ["MissionC2"];
				M3Quantity = jsonString ["data"] [0] ["MissionC3"];
				M4Quantity = jsonString ["data"] [0] ["MissionC4"];
				M5Quantity = jsonString ["data"] [0] ["MissionC5"];

				P1Quantity = jsonString ["data"] [0] ["PlayerC1"];
				P2Quantity = jsonString ["data"] [0] ["PlayerC2"];
				P3Quantity = jsonString ["data"] [0] ["PlayerC3"];
				P4Quantity = jsonString ["data"] [0] ["PlayerC4"];
				P5Quantity = jsonString ["data"] [0] ["PlayerC5"];

				M1Text.text = jsonString ["data"] [0] ["Mission1"];
				M2Text.text = jsonString ["data"] [0] ["Mission2"];
				M3Text.text = jsonString ["data"] [0] ["Mission3"];
				M4Text.text = jsonString ["data"] [0] ["Mission4"];
				M5Text.text = jsonString ["data"] [0] ["Mission5"];
				PP1.text = P1Quantity + "/" + M1Quantity;
				PP2.text = P2Quantity + "/" + M2Quantity;
				PP3.text = P3Quantity + "/" + M3Quantity;
				PP4.text = P4Quantity + "/" + M4Quantity;
				PP5.text = P5Quantity + "/" + M5Quantity;
				TitleText.text = jsonString ["data"] [0] ["Title"];
				DescriptionText.text = jsonString ["data"] [0] ["Description"];
					M1 = jsonString["data"][0]["QS1"];
			
					M2 = jsonString["data"][0]["QS2"];
			
					M3 = jsonString["data"][0]["QS3"];
			
					M4 = jsonString["data"][0]["QS4"];
			
					M5 = jsonString["data"][0]["QS5"];
					
					F1 = jsonString["data"][0]["Q1OK"];
			
					F2 = jsonString["data"][0]["Q2OK"];
			
					F3 = jsonString["data"][0]["Q3OK"];
			
					F4 = jsonString["data"][0]["Q4OK"];
			
					F5 = jsonString["data"][0]["Q5OK"];
					
					F6 = jsonString["data"][0]["QC1"];

				F7 = jsonString["data"][0]["QC2"];

				F8 = jsonString["data"][0]["QC3"];


						if (F1 == "1")
						{
					complete_button1.interactable = true;
					complete_button1.onClick.AddListener(delegate {Complete(jsonString["data"][0]["Qcode1"]+"1"); });
						}
						else
						{
					complete_button1.interactable = false;
						}
					
				if (F2 == "1")
				{
					complete_button2.interactable = true;
					complete_button2.onClick.AddListener(delegate {Complete(jsonString["data"][0]["Qcode2"]+"2"); });
				}
				else
				{
					complete_button2.interactable = false;
				}
					
						if (F3 == "1")
						{
					complete_button3.interactable = true;
					complete_button3.onClick.AddListener(delegate {Complete(jsonString["data"][0]["Qcode3"]+"3"); });
						}
						else
						{
					complete_button3.interactable = false;
						}
					
						if (F4 == "1")
						{
					complete_button4.interactable = true;
					complete_button4.onClick.AddListener(delegate {Complete(jsonString["data"][0]["Qcode4"]+"4"); });
						}
						else
						{
					complete_button4.interactable = false;
						}
					
						if (F5 == "1")
						{
					complete_button5.interactable = true;
					complete_button5.onClick.AddListener(delegate {Complete(jsonString["data"][0]["Qcode5"]+"5"); });
						}
						else
						{
					complete_button5.interactable = false;
						}
					
						if (F6 == "1")
						{
					complete_button6.interactable = true;
					complete_button6.onClick.AddListener(delegate {Complete("81"); });
						}
						else
						{
					complete_button6.interactable = false;
						}
				if (F7 == "1")
				{
					complete_button7.interactable = true;
					complete_button7.onClick.AddListener(delegate {Complete("82"); });
				}
				else
				{
					complete_button7.interactable = false;
				}
				if (F8 == "1")
				{
					complete_button8.interactable = true;
					complete_button8.onClick.AddListener(delegate {Complete("83"); });
				}
				else
				{
					complete_button8.interactable = false;
				}
					
					M1GO.SetActive(M1 == "1");
					M2GO.SetActive(M2 == "1");
					M3GO.SetActive(M3 == "1");
					M4GO.SetActive(M4 == "1");
					M5GO.SetActive(M5 == "1");
					EventGO.SetActive (false);
					break;
				default:
					print ("NaN");
					break;
			}
			
		
			



		}
	}

	public void Complete(string Qtype)
	{
		StartCoroutine(RedeemIt(Qtype));
	}

	IEnumerator RedeemIt(string QType)
	{
		yield return new WaitForSeconds(0.3f);
		var url = "http://139.59.100.192/PH/ClaimMission";
		var form = new WWWForm();
		form.AddField("ID", EventID);
		form.AddField("PID", PlayerPrefs.GetString(Link.ID));
		form.AddField("QType", QType);
		form.AddField("DID",PlayerPrefs.GetString(Link.DEVICE_ID));
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
				RedeemCodeHandle.SetActive(true);
				RedeemCodeHandle.transform.Find ("Text").GetComponent<Text> ().text = "Event Expired,\n Please Close this page.";
					break;
				case 8:
					print("pop up expired event");
				RedeemCodeHandle.SetActive(true);
				RedeemCodeHandle.transform.Find ("Text").GetComponent<Text> ().text = "Event Expired,\n Please Close this page.";
					break;
				case 77:
					print("Whadya want?");
				RedeemCodeHandle.SetActive(true);
				RedeemCodeHandle.transform.Find ("Text").GetComponent<Text> ().text = "Already Taken,\n wait till tommorrow.";
				StartCoroutine(LoadNewsDetail());
					break;
				case 6:
					print("nothing to see yet");
					break;
				case 1:
				RedeemCodeHandle.SetActive(true);
				RedeemCodeHandle.transform.Find ("Text").GetComponent<Text> ().text = "Done,\n Check your inbox.";
				StartCoroutine(LoadNewsDetail());
					print("check inbox");
					break;
				default:
					break;
			}
		}
	}

}
