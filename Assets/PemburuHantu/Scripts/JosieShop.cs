using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class JosieShop : MonoBehaviour {
public Transform WardrobeImageParent;
public GameObject WardrobePrefab;
public SkinnedMeshRenderer renderer;

	// Use this for initialization
	void Start () {
		StartCoroutine(LoadTextures());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator LoadTextures()
	{
		int count;
		if(SceneManagerHelper.HasKey("josieCount"))
		{
			 count = int.Parse(PlayerPrefs.GetString("josieCount"));
		}
		else
		{
			 count = 0;
		}
		
		string url = Link.url + "playerjosie";
		WWWForm form = new WWWForm ();
		form.AddField ("MY_ID", PlayerPrefs.GetString(Link.ID));
		WWW www = new WWW(url,form);
		yield return www;
		print(www.text);
		if (www.error == null) 
		{
			var jsonString = JSON.Parse (www.text);
		    for (int x = WardrobeImageParent.childCount - 1; x >= 0; x--) {
					Destroy (WardrobeImageParent.GetChild (x).gameObject);
				}
			count = int.Parse (jsonString ["count"]);
			GameObject[] entry;
			entry = new GameObject[int.Parse (jsonString ["count"])];
			for(int i = 0; i<count; i++)
			{
				entry [i] = Instantiate (WardrobePrefab);
				entry [i].GetComponent<wardrobeItem>().ID = jsonString ["data"] [i] ["id"];
				entry [i].GetComponent<wardrobeItem>().Url = jsonString ["data"] [i] ["Url"];
				entry [i].GetComponent<wardrobeItem>().IconCode = jsonString ["data"] [i] ["IconCode"];
				entry [i].GetComponent<wardrobeItem>().PurchaseAble = int.Parse(jsonString ["data"] [i] ["Purchase"]);
				entry [i].GetComponent<wardrobeItem>().Bought = int.Parse(jsonString ["data"] [i] ["Bought"]);
				
				if(entry [i].GetComponent<wardrobeItem>().Bought==1)
				{
					entry [i].GetComponent<wardrobeItem>().Sell.SetActive(false);
				}
				else
				{
					if( int.Parse(jsonString ["data"] [i] ["Purchase"])==0)
					{
						entry [i].GetComponent<wardrobeItem>().Sell.SetActive(false);
					}
					else
					{
						entry [i].GetComponent<wardrobeItem>().Sell.SetActive(true);
					}
					
				}
				entry [i].GetComponent<wardrobeItem>().JosieSkinMesh = renderer ;
				entry [i].GetComponent<wardrobeItem>().JosieCustume = renderer.material.mainTexture;
				entry [i].transform.SetParent (WardrobeImageParent, false);
			}
			
		
		} 

		yield return null;
	}
}
