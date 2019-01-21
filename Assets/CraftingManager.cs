using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using SimpleJSON;
public class CraftingManager : MonoBehaviour {
float myFloat;
string ItemName;
string ItemFile;
public Sprite[] Gem;
public GameObject[] SeqObject;
	void Awake()
	{
			StartCoroutine (updateData ());
	}
	void Start () {

		//StartSequence();

	}
	
public void StartSequence()
{
	
	for (int i=0; i<3;i++)
	{
		SeqObject[i].transform.DOLocalMoveY(-215f,1).OnComplete(ABC);
	}
	SeqObject[3].transform.DOLocalMoveY(4.5f,1);
	
	
}

public void ClickSummon (int WhichSummon) {
		string jenis;
		SeqObject[6].GetComponent<SpriteRenderer>().sprite = Gem[WhichSummon];
		if(WhichSummon == 0)
		{
			jenis = "COMMON";
		}
		else if(WhichSummon == 1)
		{
			jenis = "RARE";
		}
		else
		{
			jenis = "LEGENDARY";
		}
		if (int.Parse (PlayerPrefs.GetString (Link.GOLD)) >= 100 && int.Parse (PlayerPrefs.GetString (Link.LEGENDARYGem)) >= 1) {
				StartCoroutine(CraftEquipment(jenis));
		} 
		else 
		{
			print("Error");
		}
	}

	private IEnumerator CraftEquipment(string jenis)
	{
		string url = Link.url + "CraftEquipment";
		WWWForm form = new WWWForm ();
		form.AddField ("MY_ID", PlayerPrefs.GetString(Link.ID));
		form.AddField ("JENIS", jenis);

		WWW www = new WWW(url,form);
		yield return www;
		if (www.error == null) {
            //PlayerPrefs.SetString("SummonStats", "Summoned");
			//testsummonings
			
			var jsonString = JSON.Parse (www.text);

			if(int.Parse(jsonString ["code"])!=0)
			// {
			// SummonItem.gameObject.SetActive(true);
			// Debug.Log(jsonString ["data"] ["id"] );
			// SummonItem.Atk = jsonString ["data"] ["ATTACK"] ;
			// SummonItem.Def = jsonString ["data"] ["DEFEND"] ;
			// SummonItem.Hp = jsonString ["data"] ["HP"] ;
			// SummonItem.Type = jsonString ["data"] ["type"] ;
			// SummonItem.Atk = jsonString ["data"] ["ATTACK"] ;
			ItemName = jsonString ["data"] ["name"] ;		
			ItemFile = jsonString ["data"] ["image"];

			Debug.Log (www.text);
		
			StartCoroutine (updateData ());
           yield return new WaitForSeconds(1f);
		   StartSequence();
    
        }
		else
		{
			print("failed");
		}
		}
	private IEnumerator updateData()
	{
        string url = Link.url + "getDataUser";
        WWWForm form = new WWWForm();
        form.AddField(Link.ID, PlayerPrefs.GetString(Link.ID));
        form.AddField("DID", PlayerPrefs.GetString(Link.DEVICE_ID));
        WWW www = new WWW(url, form);
        yield return www;
        if (www.error == null)
        {
            PlayerPrefs.SetString("SummonStats", "Idling");
            var jsonString = JSON.Parse(www.text);
            Debug.Log(jsonString);
            PlayerPrefs.SetString(Link.FOR_CONVERTING, jsonString["code"]);
            if (PlayerPrefs.GetString(Link.FOR_CONVERTING) == "0")
            {

                PlayerPrefs.SetString(Link.ENERGY, jsonString["data"]["energy"]);
                PlayerPrefs.SetString(Link.GOLD, jsonString["data"]["coin"]);
                PlayerPrefs.SetString("Crystal", jsonString["data"]["crystal"]);
                PlayerPrefs.SetString(Link.COMMONGem, jsonString["data"]["CommonGem"]);
                PlayerPrefs.SetString(Link.RAREGem, jsonString["data"]["RareGem"]);
                PlayerPrefs.SetString(Link.LEGENDARYGem, jsonString["data"]["LegendaryGem"]);
			}
		}
	}

public void ABC()
{
		
		SeqObject[4].transform.DOScale(new Vector3(1.5f,1.5f,1),1).OnComplete(()=>{
			SeqObject[10].GetComponent<Image>().DOFillAmount(1,7).SetEase(Ease.InCubic);
			SeqObject[8].transform.DOScale(new Vector3(.4f,.4f,1),1);
			SeqObject[5].SetActive(true);
			SeqObject[6].GetComponent<SpriteRenderer>().DOFade(0,2);
		});
}
public void ShowItem()
{
	SeqObject[9].transform.DOScale(new Vector3(4f,4f,4f),0);
	SeqObject[7].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite> ("icon_item/" + ItemFile);
	SeqObject[11].SetActive(true);
	SeqObject[8].GetComponent<SpriteRenderer>().DOFade(0,0);
	SeqObject[7].GetComponent<SpriteRenderer>().DOFade(1,0f);
}

}
