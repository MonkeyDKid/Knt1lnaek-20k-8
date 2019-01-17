using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ButttonImage : MonoBehaviour
{
	public Image image;
	public Transform Head;
	public Text Done;
	public string ImageURL,EventID,EventName;
	public RawImage Rimage;
	public GameObject Prefab,RedeemHandle;
	// Use this for initialization
	void Start ()
	{
		StartCoroutine(CachedLoad());
	}
	
	// Update is called once per frame
	void Update () {
		
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

	public void EventInformation()
	{
		
		if (Head.transform.Find("Event" + EventID)!=null)
		{
			var Findit = Head.transform.Find("Event" + EventID).gameObject;
			Findit.SetActive(true);
		}
		else
		{
			GameObject entry;
			entry = Instantiate(Prefab);
			//entry.GetComponent<contentPage>().Title = ImageURL;
			entry.GetComponent<contentPage>().EventID = EventID;
			//entry.GetComponent<contentPage>().Description = ImageURL;
			entry.GetComponent<contentPage>().ImageURL = ImageURL;
			entry.gameObject.name = "Event"+EventID;
			entry.transform.SetParent(Head, false);
			entry.GetComponent<contentPage> ().RedeemCodeHandle = RedeemHandle;
		}
		
	}
}
