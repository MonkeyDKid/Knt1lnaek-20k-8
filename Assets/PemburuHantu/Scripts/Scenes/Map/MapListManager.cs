using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
public class MapListManager : MonoBehaviour {
	public GameObject[] MapListGameObject;
	public Sprite[] Imagetitle;
	public Transform[] StageSelectPosition;
	public Vector3[] StageSelectPositions;
	public Image[] GhostSelectedTarget;
	public GameObject MapPrefab, MapButtonPrefab;
	public GameObject StageBackground;
	public Image StageImage;
	public MapSelect MapSelect;
	public Map Map;	
	public Transform LevelSelectionParentTarget;
	public Transform MapListParentTarget;
	public Button StartButton;
	public Text LevelNameText;
	// Use this for initialization
	void Start () {
		StartCoroutine(GetMapData());
	}
	
	private int titlemap(string titlemap)
	{
		int getdata;
		switch(titlemap)
		{
			case "Old House":
			getdata = 0;
			break;
			case "School":
			getdata = 1;
			break;
			case "Hospital":
			getdata = 2;
			break;
			case "Bridge":
			getdata = 3;
			break;
			case "Graveyard":
			getdata = 4;
			break;
			case "Warehouse":
			getdata = 5;
			break;
			default:
			getdata = 6;
			break;

		}
		return getdata;
	}
	IEnumerator GetMapData()
	{	
			
		for (int x = MapListParentTarget.childCount - 1; x >= 0; x--) {
			Destroy (MapListParentTarget.GetChild (x).gameObject);
		}
		
		var url = "http://139.59.100.192/PH/GetMapList";
		var form = new WWWForm();
		form.AddField("ID",PlayerPrefs.GetString(Link.ID));
		WWW www = new WWW(url,form);
		yield return www;
		Debug.Log(www.text);
		if (www.error == null) {
			Debug.Log (www.text);
			var jsonString = JSON.Parse (www.text);

				GameObject[] entry;
				GameObject[] tab;
				int count = int.Parse (jsonString ["MapCount"]);
				int StageTab = int.Parse (jsonString ["StageTab"]);
				entry = new GameObject[count];
				tab = new GameObject[StageTab];
				MapSelect.SelectLevel = new GameObject[StageTab];
				MapListGameObject = new GameObject[count];
				if(StageTab>0)
				{
					MapSelect.RightButton.interactable = true;
				}
				else
				{
					MapSelect.RightButton.interactable = false;
				}
				for(int t = 0;t<StageTab;t++)
				{
					tab [t] = Instantiate (MapButtonPrefab);
					MapSelect.SelectLevel[t]=tab[t];
					tab [t].transform.SetParent (MapListParentTarget, false);
				}
				for (int x = 0; x < count; x++) 
				{
					if(x%6==0&&x!=0)
					{
						print(x);
						print("tambah Stage");
					}
					else
					{
					
					entry [x] = Instantiate (MapPrefab);
					var stagetab = int.Parse(jsonString ["MapData"] [x] ["StageTab"]);
					if(stagetab>0)
					{
						entry[x].gameObject.GetComponent<Button>().interactable = true;
					}
					else
					{
						
					}
					entry [x].GetComponent<MapInfo> ().Map = Map;
					entry [x].GetComponent<MapInfo> ().TitleMap = Imagetitle[titlemap(jsonString ["MapData"] [x] ["Lokasi"])];
					entry [x].GetComponent<MapInfo> ().StartButton = StartButton;
					entry [x].GetComponent<MapInfo> ().Stage = int.Parse(jsonString ["MapData"] [x] ["StageNumber"]);
					entry [x].GetComponent<MapInfo> ().MapLManager = this;
					entry [x].GetComponent<MapInfo> ().EnergyUsed = int.Parse(jsonString ["MapData"] [x] ["EU"]);
					entry [x].GetComponent<MapInfo> ().EXP = int.Parse(jsonString ["MapData"] [x] ["EXP"]);
					entry [x].GetComponent<MapInfo> ().Lokasi = jsonString ["MapData"] [x] ["Lokasi"];
					entry [x].GetComponent<MapInfo> ().StageLevelParentTarget = LevelSelectionParentTarget;
					MapListGameObject[x]=entry[x];
					entry [x].transform.SetParent (tab[stagetab].gameObject.transform, false);
					}
				}
				// }
				
		
		} else {
			
		}
	}
}
