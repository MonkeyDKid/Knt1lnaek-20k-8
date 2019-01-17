using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
public class StageLevel : MonoBehaviour {

	public string GhostMap1, GhostMap2, GhostMap3;
	public string LevelName;
	public Button StartButton, LevelButton;
	public Text LevelNameText;
	public Text LevelText;
	public int StageChoosen;
	private int localStagenumber;
	private bool pressed;
	[HideInInspector]
	public Map Map;
	[HideInInspector]
	public MapListManager MapLM;
	[HideInInspector]
	public bool complete;
	public GameObject Panah;
	public GameObject CompleteText;
	JSONNode jsonString;
	// Use this for initialization
	void Start () {
		this.GetComponent<Button>().onClick.AddListener(OnClick);
		if(complete)
		{
			CompleteText.SetActive(true);
		}
		
		jsonString = JSON.Parse (PlayerPrefs.GetString(Link.StageData));
		//LevelNameText = MapLM.LevelNameText;
		
	}
	
	// Update is called once per frame
	void Update () {		
	}
	 private void OnClick()
	{
		int n;
		int mystage = int.Parse(PlayerPrefs.GetString(Link.Stage));
		 PlayerPrefs.SetString(Link.StageChoose, StageChoosen.ToString());
		Map.R1.text="";
		if (PlayerPrefs.GetString ("PLAY_TUTORIAL") == "TRUE")
		{
			if(StageChoosen==99)
			{
				StartButton.interactable = true;
				StartButton.onClick.AddListener(OnStart);
			}
			else
			{
				StartButton.interactable = false;
			}
				MapLM.GhostSelectedTarget[0].sprite  = Resources.Load<Sprite> ("icon_char_Maps/" + GhostMap1);
				if(!string.IsNullOrEmpty(GhostMap2))
				{
					MapLM.GhostSelectedTarget[1].sprite = Resources.Load<Sprite> ("icon_char_Maps/" + GhostMap2);
				}
				else
				{
					MapLM.GhostSelectedTarget[1].sprite  = Map.DefaultSelectedGhostTarget;
				}
				if(!string.IsNullOrEmpty(GhostMap3))
				{
					MapLM.GhostSelectedTarget[2].sprite = Resources.Load<Sprite> ("icon_char_Maps/" + GhostMap3);
				}
				else
				{
					MapLM.GhostSelectedTarget[2].sprite  = Map.DefaultSelectedGhostTarget;
				}
				
				
		
			LevelNameText.text = LevelName;
			

		}

		else
		{
		if(mystage >= StageChoosen)
		{
			StartButton.interactable = true;
			StartButton.onClick.AddListener(OnStart);
		}
		else
		{
			StartButton.interactable = false;
		}
		
		ShowDrop(StageChoosen);
		
		MapLM.GhostSelectedTarget[0].sprite = Resources.Load<Sprite> ("icon_char_Maps/" + GhostMap1);
		if(!string.IsNullOrEmpty(GhostMap2))
				{
					MapLM.GhostSelectedTarget[1].sprite = Resources.Load<Sprite> ("icon_char_Maps/" + GhostMap2);
				}
				else
				{
					MapLM.GhostSelectedTarget[1].sprite  = Map.DefaultSelectedGhostTarget;
				}
				if(!string.IsNullOrEmpty(GhostMap3))
				{
					MapLM.GhostSelectedTarget[2].sprite = Resources.Load<Sprite> ("icon_char_Maps/" + GhostMap3);
				}
				else
				{
					MapLM.GhostSelectedTarget[2].sprite  = Map.DefaultSelectedGhostTarget;
				}
		LevelNameText.text= LevelName;
	}
	}
	private void ShowDrop(int stageChoosen)
	{
		// if(stageChoosen==0||stageChoosen==6){
		// 	n=0;
		// 	for(int i=0;i<3;i++)
		// 	{
		// 		Map.R1.text+=Map.dropItemQuantity[i]+" "+Map.dropItemName[i]+" Chance "+Map.dropItemRate[i]+"% \n";
		// 	}
		// 		for(int z=0;z<3;z++)
		// 	{
		// 		PlayerPrefs.SetString("RewardItemFN"+z.ToString(),Map.dropItemFileName[n]);
		// 		PlayerPrefs.SetString("RewardItemName"+z.ToString(),Map.dropItemName[n]);
        //     	PlayerPrefs.SetString("RewardItemQuantity"+z.ToString(),Map.dropItemQuantity[n]);
        //     	PlayerPrefs.SetString("RewardItemType"+z.ToString(),Map.dropItemType[n]);
        //     	PlayerPrefs.SetString("RewardItemRate"+z.ToString(),Map.dropItemRate[n]);
		// 		n++;
		// 	}
		
		if(stageChoosen>=6)
		{
			float hasilbagi = stageChoosen/6;

		
			stageChoosen-=(int) hasilbagi*6;
			localStagenumber=stageChoosen;
		}
		print(stageChoosen);
		
		SetGhost();
		var choose=0;
		var n=0;
		n = stageChoosen*3;
			if(stageChoosen==0)
			{
				
				choose = stageChoosen+3;
			}
			else
			{
				
				choose = stageChoosen+1*3;
			}
			
			for(int i=stageChoosen;i<choose;i++)
			{
				Map.R1.text+=Map.dropItemQuantity[i]+" "+Map.dropItemName[i]+" Chance "+Map.dropItemRate[i]+"% \n";
			}	
				for(int z=0;z<3;z++)
			{
				PlayerPrefs.SetString("RewardItemFN"+z.ToString(),Map.dropItemFileName[n]);
				PlayerPrefs.SetString("RewardItemName"+z.ToString(),Map.dropItemName[n]);
            	PlayerPrefs.SetString("RewardItemQuantity"+z.ToString(),Map.dropItemQuantity[n]);
            	PlayerPrefs.SetString("RewardItemType"+z.ToString(),Map.dropItemType[n]);
            	PlayerPrefs.SetString("RewardItemRate"+z.ToString(),Map.dropItemRate[n]);
				n++;
			}		

		}
		// else if(stageChoosen==1||stageChoosen==7){
		// 	n=3;
		// 	for(int i=3;i<6;i++)
		// 	{
		// 		Map.R1.text+=Map.dropItemQuantity[i]+" "+Map.dropItemName[i]+" Chance "+Map.dropItemRate[i]+"% \n";
		// 	}	
		// 		for(int z=0;z<3;z++)
		// 	{
		// 		PlayerPrefs.SetString("RewardItemFN"+z.ToString(),Map.dropItemFileName[n]);
		// 		PlayerPrefs.SetString("RewardItemName"+z.ToString(),Map.dropItemName[n]);
        //     	PlayerPrefs.SetString("RewardItemQuantity"+z.ToString(),Map.dropItemQuantity[n]);
        //     	PlayerPrefs.SetString("RewardItemType"+z.ToString(),Map.dropItemType[n]);
        //     	PlayerPrefs.SetString("RewardItemRate"+z.ToString(),Map.dropItemRate[n]);
		// 		n++;
		// 	}

	private void OnStart()
	{
		Map.On_Start();
	}

	void SetGhost()
	{
			 
		for(int i=1;i<4;i++)
			 {
				 PlayerPrefs.SetString("pos_1_char_"+i.ToString()+"_file", jsonString [localStagenumber]["HantuId"+i.ToString()]["name_file"]);
				 PlayerPrefs.SetString("pos_1_char_"+i.ToString()+"_element", jsonString [localStagenumber]["HantuId"+i.ToString()]["type"]);
				 PlayerPrefs.SetString("pos_1_char_"+i.ToString()+"_mode", jsonString [localStagenumber]["HantuId"+i.ToString()]["element"]);
				 PlayerPrefs.SetString("pos_1_char_"+i.ToString()+"_grade", jsonString [localStagenumber]["HantuId"+i.ToString()]["grade"]);
				 PlayerPrefs.SetString("pos_1_char_"+i.ToString()+"_attack", jsonString [localStagenumber]["HantuId"+i.ToString()]["ATTACK"]);
				 PlayerPrefs.SetString("pos_1_char_"+i.ToString()+"_defense", jsonString [localStagenumber]["HantuId"+i.ToString()]["DEFEND"]);
				 PlayerPrefs.SetString("pos_1_char_"+i.ToString()+"_hp", jsonString [localStagenumber]["HantuId"+i.ToString()]["HP"]);
			 
			 }	 
	          print(jsonString[0]);
			 for(int i=1;i<4;i++)
			 {
				 print(PlayerPrefs.GetString("pos_1_char_"+i.ToString()+"_hp"));
			 }

	}
	
}

