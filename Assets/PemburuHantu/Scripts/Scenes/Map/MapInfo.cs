using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
public class MapInfo : MonoBehaviour {

[HideInInspector]public int EnergyUsed;
[HideInInspector]public int EXP;
[HideInInspector]public string Lokasi;
[HideInInspector]public Map Map;
[HideInInspector]public Button StartButton;
[HideInInspector]public Text LevelNameText;
[HideInInspector]public MapListManager MapLManager;
[HideInInspector]public int Stage;
[HideInInspector]public bool Event;
[HideInInspector]public int MapUpdateVersion;
public Image Gambar;
public Transform StageLevelParentTarget;
public GameObject StageLevelPrefab;
void Start()
{
	CheckStage();
	StartCoroutine(LoadGambar());
}
public void OnMapClick()
{
	PlayerPrefs.SetString(Link.SEARCH_BATTLE, "SINGLE");
    PlayerPrefs.SetString(Link.LOKASI, Lokasi);
    PlayerPrefs.SetString(Link.JENIS, "SINGLE");
	//if(SceneManagerHelper.Haske)
	Map.CheckStage();
	StartCoroutine(Map.GetStageDrop(Lokasi));
	CheckMap();
	
}
private void CheckMap()
{
	if(SceneManagerHelper.HasKey("MapUpdateVersion"))
	{
		var lastupdateMap = PlayerPrefs.GetInt("MapUpdateVersion");
		if(MapUpdateVersion>lastupdateMap)
		{
			PlayerPrefs.SetInt("MapUpdateVersion", MapUpdateVersion);
			StartCoroutine(GetSelectedMapList(true));
		}
		else
		{
			StartCoroutine(GetSelectedMapList(false));
		}

	}

	else
	{
		PlayerPrefs.SetInt("MapUpdateVersion", MapUpdateVersion);
		StartCoroutine(GetSelectedMapList(true));
	}
}
private IEnumerator GetSelectedMapList(bool whichLoad)
{
	var angka = int.Parse(PlayerPrefs.GetString(Link.Stage));
	for (int x = StageLevelParentTarget.childCount - 1; x >= 0; x--) 
		{
			Destroy (StageLevelParentTarget.GetChild (x).gameObject);
		}
		if(whichLoad)
		{
		var url = "http://139.59.100.192/PH/GetSelectedMapList";
		var form = new WWWForm();
		form.AddField("ID",PlayerPrefs.GetString(Link.ID));
		form.AddField("Lokasi", Lokasi);
		WWW www = new WWW(url,form);
		yield return www;
		Debug.Log(www.text);
		if (www.error == null) {
			Debug.Log (www.text);
			var jsonString = JSON.Parse (www.text);
				
				GameObject[] entry;
				int count = int.Parse (jsonString ["LevelCount"]);
				entry = new GameObject[count];
				string stagedata = jsonString ["Hantudata"].ToString();
				string mapdata = www.text;
				print(stagedata);
				PlayerPrefs.SetString(Link.StageData, stagedata);
				PlayerPrefs.SetString(Link.MapData, mapdata);
				for (int x = 0; x < count; x++) {
					if(x%6==0&&x!=0)
					{
						print("tambah Stage");
					}
					
					int level = int.Parse(jsonString ["HantuMapList"] [x] ["Stage"])+1;
					int normallevel = int.Parse(jsonString ["HantuMapList"] [x] ["Stage"]);
					entry [x] = Instantiate (StageLevelPrefab);
					entry [x].GetComponent<StageLevel> ().Map = Map;
					entry [x].GetComponent<StageLevel> ().LevelNameText = MapLManager.LevelNameText;
					entry [x].GetComponent<StageLevel> ().LevelText.text =  "Level " + level.ToString();					
					entry [x].GetComponent<StageLevel> ().LevelName = "Level " + level.ToString();
					entry [x].GetComponent<StageLevel> ().StartButton = StartButton;
					entry [x].GetComponent<StageLevel> ().StageChoosen = int.Parse(jsonString ["HantuMapList"] [x] ["Stage"]);
					entry [x].GetComponent<StageLevel> ().GhostMap1 = jsonString ["Hantudata"][x] ["HantuId1"]["name_file"];
					entry [x].GetComponent<StageLevel> ().GhostMap2 = jsonString ["Hantudata"][x] ["HantuId2"]["name_file"];
					entry [x].GetComponent<StageLevel> ().GhostMap3 = jsonString ["Hantudata"][x] ["HantuId3"]["name_file"];
					
					if(angka>normallevel)
					{
						entry [x].GetComponent<StageLevel> ().complete=true;
					}
					
					if(int.Parse(jsonString ["HantuMapList"] [x] ["Stage"])==99)
					{
						if (PlayerPrefs.GetString ("PLAY_TUTORIAL") == "TRUE")
					{
						entry [x].GetComponent<StageLevel> ().Panah.SetActive(true);
						entry [x].GetComponent<StageLevel> ().LevelText.text =  "Tutorial";					
						entry [x].GetComponent<StageLevel> ().LevelName = "Tutorial";				
						entry [x].GetComponent<StageLevel> ().MapLM = MapLManager;entry[x].transform.position = MapLManager.StageSelectPositions[0];
					}
					else
					{
						entry [x].SetActive(false);
					}
						
					}
					else 
					{
						entry [x].GetComponent<StageLevel> ().MapLM = MapLManager;entry[x].transform.position = MapLManager.StageSelectPositions[x+1];
					}
					
					entry [x].transform.SetParent (StageLevelParentTarget, false);

				}
				Map.LevelSelection.SetActive(true);
				
		
		} else {
			
		}
		}
		else
		{
			GameObject[] entry;
			var isi = PlayerPrefs.GetString(Link.MapData);
			var jsonString = JSON.Parse (isi);
			int count = int.Parse (jsonString ["LevelCount"]);
			entry = new GameObject[count];
			string stagedata = jsonString ["Hantudata"].ToString();
			for (int x = 0; x < count; x++) {
					if(x%6==0&&x!=0)
					{
						print("tambah Stage");
					}
					
					int level = int.Parse(jsonString ["HantuMapList"] [x] ["Stage"])+1;
					int normallevel = int.Parse(jsonString ["HantuMapList"] [x] ["Stage"]);
					entry [x] = Instantiate (StageLevelPrefab);
					entry [x].GetComponent<StageLevel> ().Map = Map;
					entry [x].GetComponent<StageLevel> ().LevelNameText = MapLManager.LevelNameText;
					entry [x].GetComponent<StageLevel> ().LevelText.text =  "Level " + level.ToString();					
					entry [x].GetComponent<StageLevel> ().LevelName = "Level " + level.ToString();
					entry [x].GetComponent<StageLevel> ().StartButton = StartButton;
					entry [x].GetComponent<StageLevel> ().StageChoosen = int.Parse(jsonString ["HantuMapList"] [x] ["Stage"]);
					entry [x].GetComponent<StageLevel> ().GhostMap1 = jsonString ["Hantudata"][x] ["HantuId1"]["name_file"];
					entry [x].GetComponent<StageLevel> ().GhostMap2 = jsonString ["Hantudata"][x] ["HantuId2"]["name_file"];
					entry [x].GetComponent<StageLevel> ().GhostMap3 = jsonString ["Hantudata"][x] ["HantuId3"]["name_file"];
					
					if(angka>normallevel)
					{
						entry [x].GetComponent<StageLevel> ().complete=true;
					}
					
					if(int.Parse(jsonString ["HantuMapList"] [x] ["Stage"])==99)
					{
						if (PlayerPrefs.GetString ("PLAY_TUTORIAL") == "TRUE")
					{
						entry [x].GetComponent<StageLevel> ().Panah.SetActive(true);
						entry [x].GetComponent<StageLevel> ().LevelText.text =  "Tutorial";					
						entry [x].GetComponent<StageLevel> ().LevelName = "Tutorial";				
						entry [x].GetComponent<StageLevel> ().MapLM = MapLManager;entry[x].transform.position = MapLManager.StageSelectPositions[0];
					}
					else
					{
						entry [x].SetActive(false);
					}
						
					}
					else 
					{
						entry [x].GetComponent<StageLevel> ().MapLM = MapLManager;entry[x].transform.position = MapLManager.StageSelectPositions[x+1];
					}
					
					entry [x].transform.SetParent (StageLevelParentTarget, false);

				}
				Map.LevelSelection.SetActive(true);						
		
		}
}
IEnumerator LoadGambar()
{
	if(SceneManagerHelper.HasKey(Lokasi))
	{
		 byte[] b64_bytes = System.Convert.FromBase64String(PlayerPrefs.GetString(Lokasi));
            Texture2D tex = new Texture2D(1, 1);
            tex.LoadImage(b64_bytes);

            var rect = new Rect(0, 0, tex.width, tex.height);

            if (tex.height != 8)
            {
				tex.filterMode = FilterMode.Point;
				tex.alphaIsTransparency=true;
                Gambar.sprite = Sprite.Create(tex, rect, Vector2.zero, 128.0f);
            }
	}
	else
	{
		 string url = Link.urlAvatar + "Lokasi/" + Lokasi + ".png";

        Debug.Log("AVATAR : " + url);
        WWWForm form = new WWWForm();
        WWW www = new WWW(url);
        yield return www;
        	Debug.Log (www.text);
        if (www.error == null)
        {
            Debug.Log(url);
			 Texture2D tex = www.texture;
            var rect = new Rect(0, 0, tex.width,tex.height);
            
                Debug.Log(www.texture.height);
				tex.filterMode = FilterMode.Point;
				tex.alphaIsTransparency=true;
                Gambar.sprite = Sprite.Create(tex, rect, Vector2.zero, 128.0f);
           
            string s = System.Convert.ToBase64String(tex.EncodeToPNG());
            PlayerPrefs.SetString(Lokasi, s);
            Debug.Log("Succes");
        }
        else {
            Debug.Log("Faill");
        }
	}
	
	
}
  private void CheckStage()
    {
      var angka = int.Parse(PlayerPrefs.GetString(Link.Stage));
	 if(angka >= Stage)
	 {
		GetComponent<Button>().interactable=true;
	 }
	  
	}

}
