using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageButton : MonoBehaviour {
	public Image GhostMap1, GhostMap2, GhostMap3;
	public Image GhostSelect1, GhostSelect2, GhostSelect3;
	public string LevelName;
	public Button StartButton, LevelButton;
	public Text LevelNameText;
	public int StageChoosen;
	public Map Map;
	// Use this for initialization
	void Start () {
		this.GetComponent<Button>().onClick.AddListener(OnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	 private void OnClick()
	{
		int n;
		int mystage = 2;
		//int.Parse(PlayerPrefs.GetString(Link.Stage));
		Map.R1.text="";
		if (PlayerPrefs.GetString ("PLAY_TUTORIAL") == "TRUE")
		{
			if(StageChoosen==99)
			{
				StartButton.interactable = true;
				StartButton.onClick = LevelButton.onClick;
			}
			else
			{
				StartButton.interactable = false;
			}
			GhostSelect1.sprite = GhostMap1.sprite;
			if(GhostMap2!=null)
			GhostSelect2.sprite = GhostMap2.sprite;
			if(GhostMap2!=null)
			GhostSelect3.sprite = GhostMap3.sprite;
			LevelNameText.text = LevelName;

		}

		else
		{
		if(mystage >= StageChoosen)
		{
			StartButton.interactable = true;
			StartButton.onClick = LevelButton.onClick;
		}
		else
		{
			StartButton.interactable = false;
		}
		if(StageChoosen==0||StageChoosen==6){
			n=0;
			for(int i=0;i<3;i++)
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
		else if(StageChoosen==1||StageChoosen==7){
			n=3;
			for(int i=3;i<6;i++)
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
		
		GhostSelect1.sprite = GhostMap1.sprite;
		if(GhostMap2!=null)
		GhostSelect2.sprite = GhostMap2.sprite;
		if(GhostMap2!=null)
		GhostSelect3.sprite = GhostMap3.sprite;
		LevelNameText.text= LevelName;
	}
	}
	
}
